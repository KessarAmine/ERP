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
using DevKbfSteel.Areas.MagasinManager.Models;

namespace DevKbfSteel.Areas.MagasinManager.Controllers
{
    [Area(nameof(Areas.MagasinManager))]

    public class RestitutionController : Controller
    {
        private KBFsteelContext _context;
        public RestitutionController(KBFsteelContext context)
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
        public async Task<IActionResult> GetRestitution(DataSourceLoadOptions loadOptions)
        {
            var StkRestitution = _context.StkRestitution
                .Where(c => c.NumDecharge == XpertHelper.NumDecharge)
                .Select(i => new {
                    i.DateRestitution,
                    i.NumDecharge,
                    i.NumRestitution,
                    i.ServiceEmetteur,
                    i.CodeIntervenant
                });
            return Json(await DataSourceLoader.LoadAsync(StkRestitution, loadOptions));
        }
        [HttpGet]
        public async Task<IActionResult> GetRestitutionDetails(int id, DataSourceLoadOptions loadOptions)
        {
            XpertHelper.NumRestitution = id;
            var StkAffectations = _context.StkRestitutionArticles
                .Where(c => c.NumRestitution == id)
                .Select(i => new {
                    i.Id,
                    i.CodeArticle,
                    i.Qte,
                    i.NumRestitution,
                    i.Observation,
                    i.DateRestitution
                });
            return Json(await DataSourceLoader.LoadAsync(StkAffectations, loadOptions));
        }
        //=================================================Posts===================================
        [HttpPost]
        public async Task<IActionResult> PostRestitution(string values)
        {
            var model = new StkRestitution();
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModelRestitution(model, valuesDict);
            var StkRestitution = _context.StkRestitution
                .OrderBy(o => o.NumRestitution)
                .Select(i => new
                {
                    i.NumRestitution
                }).ToList();

            if (StkRestitution.Count == 0)
                model.NumRestitution = 1;
            else
            {
                var m = StkRestitution.Last();
                model.NumRestitution = Convert.ToInt32(m.NumRestitution) + 1;
            }
            model.NumDecharge = XpertHelper.NumDecharge;
            var result = _context.StkRestitution.Add(model);
            await _context.SaveChangesAsync();

            return Json(result.Entity.NumRestitution);
        }
        [HttpPost]
        public async Task<IActionResult> PostRestitutionDetails(string values)
        {
            var model = new StkRestitutionArticles();
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModelRestitutionArticles(model, valuesDict);
            var StkRestitution = _context.StkRestitution
                .Where(c => c.NumDecharge == XpertHelper.NumDecharge)
                .Select(i => new {
                    i.DateRestitution
                }).Last();
            var StkRestitutionArticles = _context.StkRestitutionArticles
                .OrderBy(o => o.Id)
                .Select(i => new
                {
                    i.Id
                }).ToList();

            if (StkRestitutionArticles.Count == 0)
                model.Id = 1;
            else
            {
                var m = StkRestitutionArticles.Last();
                model.Id = Convert.ToInt32(m.Id) + 1;
            }
            model.DateRestitution = StkRestitution.DateRestitution;
            model.NumRestitution = XpertHelper.NumRestitution;
            var result = _context.StkRestitutionArticles.Add(model);
            await _context.SaveChangesAsync();

            return Json(result.Entity.Id);
        }
        //=================================================Puts===================================
        [HttpPut]
        public async Task<IActionResult> PutRestitution(int key, string values)
        {
            var model = await _context.StkRestitution.FirstOrDefaultAsync(item => item.NumRestitution == key);
            if (model == null)
                return StatusCode(409, "Object not found");
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModelRestitution(model, valuesDict);
            await _context.SaveChangesAsync();
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> PutRestitutionDetails(int key, string values)
        {
            var model = await _context.StkRestitutionArticles.FirstOrDefaultAsync(item => item.Id == key);
            if (model == null)
                return StatusCode(409, "Object not found");
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModelRestitutionArticles(model, valuesDict);
            await _context.SaveChangesAsync();
            return Ok();
        }
        //=================================================Deletes===================================
        [HttpDelete]
        public async Task DeleteRestitution(int key)
        {
            var model = await _context.StkRestitution.FirstOrDefaultAsync(item => item.NumRestitution == key);
            _context.StkRestitution.Remove(model);
            await _context.SaveChangesAsync();
        }
        [HttpDelete]
        public async Task DeleteRestitutionDetails(int key)
        {
            var model = await _context.StkRestitutionArticles.FirstOrDefaultAsync(item => item.Id == key);
            _context.StkRestitutionArticles.Remove(model);
            await _context.SaveChangesAsync();
        }
        //=================================================Lookups===================================
        
        //=================================================PopulateModels===================================
        private void PopulateModelRestitution(StkRestitution model, IDictionary values)
        {
            string DateRestitution = nameof(StkRestitution.DateRestitution);
            string ServiceEmetteur = nameof(StkRestitution.ServiceEmetteur);
            if (values.Contains(DateRestitution))
            {
                model.DateRestitution = Convert.ToDateTime(values[DateRestitution]);
            }
            if (values.Contains(ServiceEmetteur))
            {
                model.ServiceEmetteur = Convert.ToInt32(values[ServiceEmetteur]);
            }
        }
        private void PopulateModelRestitutionArticles(StkRestitutionArticles model, IDictionary values)
        {
            string CodeArticle = nameof(StkRestitutionArticles.CodeArticle);
            string Qte = nameof(StkRestitutionArticles.Qte);
            string Observation = nameof(StkRestitutionArticles.Observation); 
            string DateRestitution = nameof(StkRestitutionArticles.DateRestitution); 
            if (values.Contains(CodeArticle))
            {
                var CodePdrvar = values[CodeArticle];
                var Idemployestrings = CodePdrvar.ToString();
                var SplitThefirst = Idemployestrings.Split("[");
                var SplitThesecond = SplitThefirst[1].Split("]");
                var CodePdrSplited = SplitThesecond[0];
                model.CodeArticle = Convert.ToInt32(CodePdrSplited);
            }
            if (values.Contains(DateRestitution))
            {
                model.DateRestitution = Convert.ToDateTime(values[DateRestitution]);
            }
            if (values.Contains(Qte))
            {
                model.Qte = Convert.ToInt32(values[Qte]);
            }
            if (values.Contains(Observation))
            {
                model.Observation = Convert.ToString(values[Observation]);
            }
        }
    }
}
