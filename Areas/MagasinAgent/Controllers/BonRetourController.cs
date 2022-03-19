using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using DevKbfSteel.Entities;
using Microsoft.AspNetCore.Authorization;
using DevKbfSteel.Helpers;
using DevKbfSteel.Models;
using DevKbfSteel.Areas.MagasinAgent.Models;

namespace DevKbfSteel.Areas.MagasinAgent.Controllers
{
    [Area(nameof(Areas.MagasinAgent))]

    public class BonRetourController : Controller
    {
        private KBFsteelContext _context;
        public BonRetourController(KBFsteelContext context)
        {
            _context = context;
        }
        //=================================================Gets===================================
        [HttpGet]
        public object GetDechargee(DateTime dateDebut, DateTime dateFin, DataSourceLoadOptions loadOptions)
        {
            List<RecapBillettesModel> RecapBillettesModelList = new List<RecapBillettesModel>();
            int NbrFdx = 0;
            int NbrPieces = 0;
            int NbrRot = 0;
            double Tonnage= 0.0;
            var StkReceptionBillette = _context.StkReceptionBillette
                .Where(c => c.DateReception.Date >= dateDebut.Date && c.DateReception.Date <= dateFin.Date)
                .Select(i => new {
                    i.NumReception,
                    i.BilleteRecue,
                    i.Navire,
                    i.DateReception
                }).ToList();
            foreach (var itemStkReceptionBillette in StkReceptionBillette)
            {
                RecapBillettesModel RecapBillettesModel = new RecapBillettesModel();
                RecapBillettesModel.Date = itemStkReceptionBillette.DateReception;
                RecapBillettesModel.Navire = itemStkReceptionBillette.Navire;
                var StkRapportTransfertBillette = _context.StkRapportTransfertBillette
                .Where(c => c.DateTransfert.Date >= itemStkReceptionBillette.DateReception.Date && c.DateTransfert.Date <= itemStkReceptionBillette.DateReception.Date)
                .Select(i => new
                {
                    i.NumRapportTransfert
                }).ToList();
                if(StkRapportTransfertBillette.Count() > 0)
                {
                    var StkRapportTransfertBillettesDetails = _context.StkRapportTransfertBillettesDetails
                    .Where(c => c.NumRapportTransfert == StkRapportTransfertBillette.Last().NumRapportTransfert)
                    .Select(i => new {
                        i.Id
                    });
                    NbrRot = StkRapportTransfertBillettesDetails.Count();
                }

                RecapBillettesModel.NbrRotations = NbrRot;

                var StkReceptionBilletteDetails = _context.StkReceptionBilletteDetails
                .Where(c => c.NumReception == itemStkReceptionBillette.NumReception)
                .Select(i => new
                {
                    i.NbrFdx,
                    i.NbrPieces,
                    i.NetPoidTh
                }).ToList();
                foreach (var itemStkReceptionBilletteDetails in StkReceptionBilletteDetails)
                {
                    NbrFdx = NbrFdx + itemStkReceptionBilletteDetails.NbrFdx;
                    NbrPieces = NbrPieces + itemStkReceptionBilletteDetails.NbrPieces;
                    Tonnage = Tonnage + itemStkReceptionBilletteDetails.NetPoidTh;
                }

                RecapBillettesModel.NbrPieces = NbrPieces;
                RecapBillettesModel.NbrFdx = NbrFdx;
                RecapBillettesModel.Tonnage = Tonnage;
                RecapBillettesModelList.Add(RecapBillettesModel);
                NbrFdx = 0;
                NbrPieces = 0;
                NbrRot = 0;
                Tonnage = 0.0;
            }
            return DataSourceLoader.Load(RecapBillettesModelList.AsEnumerable(), loadOptions);
        }
        [HttpGet]
        public async Task<IActionResult> GetBonRetour(DateTime dateDebut, DateTime dateFin, DataSourceLoadOptions loadOptions)
        {
            var StkAffectations = _context.SrkBonRetour
                .Where(c => c.DateRetour.Date >= dateDebut.Date && c.DateRetour.Date <= dateFin.Date)
                .Select(i => new {
                    i.CodeFournisseur,
                    i.DateRetour,
                    i.NumBonEntree,
                    i.NumBonRetour,
                    i.CodeIntervenant
                });
            return Json(await DataSourceLoader.LoadAsync(StkAffectations, loadOptions));
        }
        [HttpGet]
        public async Task<IActionResult> GetBonRetourDetails(int id, DataSourceLoadOptions loadOptions)
        {
            XpertHelper.NumBonRetourAgent = id;
            var StkAffectations = _context.StkBonRetourArticles
                .Where(c => c.NumBonRetour == id)
                .Select(i => new {
                    i.Id,
                    i.DateRetour,
                    i.CodeArticle,
                    i.Qte,
                    i.PrixUnitaire,
                    i.MotifRetour
                });
            return Json(await DataSourceLoader.LoadAsync(StkAffectations, loadOptions));
        }
        //=================================================Posts===================================
        [HttpPost]
        public async Task<IActionResult> PostBonRetour(string values)
        {
            var model = new SrkBonRetour();
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModelBonRetour(model, valuesDict);
            var SrkBonRetour = _context.SrkBonRetour
                .OrderBy(o => o.NumBonRetour)
                .Select(i => new
                {
                    i.NumBonRetour
                }).ToList();

            if (SrkBonRetour.Count == 0)
                model.NumBonRetour = 1;
            else
            {
                var m = SrkBonRetour.Last();
                model.NumBonRetour = Convert.ToInt32(m.NumBonRetour) + 1;
            }
            model.DateRetour = DateTime.Now.Date;
            var result = _context.SrkBonRetour.Add(model);
            await _context.SaveChangesAsync();

            return Json(result.Entity.NumBonRetour);
        }
        [HttpPost]
        public async Task<IActionResult> PostBonRetourDetails(string values)
        {
            var model = new StkBonRetourArticles();
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModelBonRetourArticles(model, valuesDict);
            var StkBonRetourArticles = _context.StkBonRetourArticles
                .OrderBy(o => o.Id)
                .Select(i => new
                {
                    i.Id
                }).ToList();            
            var SrkBonRetour = _context.SrkBonRetour
                .AsNoTracking()
                .Where(o => o.NumBonRetour == XpertHelper.NumBonRetourAgent)
                .Select(i => new
                {
                    i.DateRetour
                }).Last();

            if (StkBonRetourArticles.Count == 0)
                model.Id = 1;
            else
            {
                var m = StkBonRetourArticles.Last();
                model.Id = Convert.ToInt32(m.Id) + 1;
            }
            model.DateRetour = SrkBonRetour.DateRetour;
            model.NumBonRetour = XpertHelper.NumBonRetourAgent;
            var result = _context.StkBonRetourArticles.Add(model);
            await _context.SaveChangesAsync();

            return Json(result.Entity.Id);
        }
        //=================================================Puts===================================
        [HttpPut]
        public async Task<IActionResult> PutBonRetour(int key, string values)
        {
            var model = await _context.SrkBonRetour.FirstOrDefaultAsync(item => item.NumBonRetour == key);
            if (model == null)
                return StatusCode(409, "Object not found");
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModelBonRetour(model, valuesDict);
            await _context.SaveChangesAsync();
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> PutBonRetourDetails(int key, string values)
        {
            var model = await _context.StkBonRetourArticles.FirstOrDefaultAsync(item => item.Id == key);
            if (model == null)
                return StatusCode(409, "Object not found");
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModelBonRetourArticles(model, valuesDict);
            await _context.SaveChangesAsync();
            return Ok();
        }
        //=================================================Deletes===================================
        [HttpDelete]
        public async Task DeleteBonRetour(int key)
        {
            var model = await _context.SrkBonRetour.FirstOrDefaultAsync(item => item.NumBonRetour == key);
            _context.SrkBonRetour.Remove(model);
            await _context.SaveChangesAsync();
        }
        [HttpDelete]
        public async Task DeleteBonRetourDetails(int key)
        {
            var model = await _context.StkBonRetourArticles.FirstOrDefaultAsync(item => item.Id == key);
            _context.StkBonRetourArticles.Remove(model);
            await _context.SaveChangesAsync();
        }
        //=================================================Lookups===================================
        
        //=================================================PopulateModels===================================
        private void PopulateModelBonRetour(SrkBonRetour model, IDictionary values)
        {
            string CodeFournisseur = nameof(SrkBonRetour.CodeFournisseur);
            string DateRetour = nameof(SrkBonRetour.DateRetour);
            string NumBonEntree = nameof(SrkBonRetour.NumBonEntree);
            string CodeIntervenant = nameof(SrkBonRetour.CodeIntervenant);
            if (values.Contains(DateRetour))
            {
                model.DateRetour = Convert.ToDateTime(values[DateRetour]);
            }
            if (values.Contains(CodeFournisseur))
            {
                model.CodeFournisseur = Convert.ToString(values[CodeFournisseur]);
            }
            if (values.Contains(CodeIntervenant))
            {
                model.CodeIntervenant = Convert.ToInt32(values[CodeIntervenant]);
            }
            if (values.Contains(NumBonEntree))
            {
                model.NumBonEntree = Convert.ToInt32(values[NumBonEntree]);
            }
        }
        private void PopulateModelBonRetourArticles(StkBonRetourArticles model, IDictionary values)
        {
            string CodeArticle = nameof(StkBonRetourArticles.CodeArticle);
            string Qte = nameof(StkBonRetourArticles.Qte);
            string MotifRetour = nameof(StkBonRetourArticles.MotifRetour); 
            string PrixUnitaire = nameof(StkBonRetourArticles.PrixUnitaire);
            string DateRetour = nameof(StkBonRetourArticles.DateRetour);
            if (values.Contains(CodeArticle))
            {
                var CodePdrvar = values[CodeArticle];
                var Idemployestrings = CodePdrvar.ToString();
                var SplitThefirst = Idemployestrings.Split("[");
                var SplitThesecond = SplitThefirst[1].Split("]");
                var CodePdrSplited = SplitThesecond[0];
                model.CodeArticle = Convert.ToInt32(CodePdrSplited);
            }
            if (values.Contains(Qte))
            {
                model.Qte = Convert.ToInt32(values[Qte]);
            }
            if (values.Contains(DateRetour))
            {
                model.DateRetour = Convert.ToDateTime(values[DateRetour]);
            }
            if (values.Contains(MotifRetour))
            {
                model.MotifRetour = Convert.ToString(values[MotifRetour]);
            }
            if (values.Contains(PrixUnitaire))
            {
                model.PrixUnitaire = Convert.ToDouble(values[PrixUnitaire]);
            }
        }
    }
}
