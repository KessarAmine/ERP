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

    public class ReintegrationController : Controller
    {
        private KBFsteelContext _context;
        public ReintegrationController(KBFsteelContext context)
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
        public async Task<IActionResult> GetReintegration(DateTime dateDebut, DateTime dateFin, DataSourceLoadOptions loadOptions)
        {
            var StkAffectations = _context.StkReintegration
                .Where(c => c.DateReingegration.Date >= dateDebut.Date && c.DateReingegration.Date <= dateFin.Date)
                .Select(i => new {
                    i.DateReingegration,
                    i.NumBonReintegration,
                    i.ServiceEmetteur,
                    i.CodeIntervenant
                });
            return Json(await DataSourceLoader.LoadAsync(StkAffectations, loadOptions));
        }
        [HttpGet]
        public async Task<IActionResult> GetReintegrationDetails(int id, DataSourceLoadOptions loadOptions)
        {
            XpertHelper.NumReintegrationAgent = id;
            var StkAffectations = _context.StkReintegrationArticles
                .Where(c => c.NumBonReintegration == id)
                .Select(i => new {
                    i.Id,
                    i.DateReingegration,
                    i.CodeArticle,
                    i.Qte,
                    i.CodeIntervenant,
                    i.LieuDemande
                });
            return Json(await DataSourceLoader.LoadAsync(StkAffectations, loadOptions));
        }
        //=================================================Posts===================================
        [HttpPost]
        public async Task<IActionResult> PostReintegration(string values)
        {
            var model = new StkReintegration();
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModelReintegration(model, valuesDict);
            var StkReintegration = _context.StkReintegration
                .OrderBy(o => o.NumBonReintegration)
                .Select(i => new
                {
                    i.NumBonReintegration
                }).ToList();

            if (StkReintegration.Count == 0)
                model.NumBonReintegration = 1;
            else
            {
                var m = StkReintegration.Last();
                model.NumBonReintegration = Convert.ToInt32(m.NumBonReintegration) + 1;
            }
            model.DateReingegration = DateTime.Now.Date;

            var result = _context.StkReintegration.Add(model);
            await _context.SaveChangesAsync();

            return Json(result.Entity.NumBonReintegration);
        }
        [HttpPost]
        public async Task<IActionResult> PostReintegrationDetails(string values)
        {
            var model = new StkReintegrationArticles();
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModelReintegrationArticles(model, valuesDict);
            var StkReintegration = _context.StkReintegration
                .AsNoTracking()
                .Where(o => o.NumBonReintegration == XpertHelper.NumReintegrationAgent)
                .Select(i => new
                {
                    i.DateReingegration
                }).Last();
            var StkReintegrationArticles = _context.StkReintegrationArticles
                .OrderBy(o => o.Id)
                .Select(i => new
                {
                    i.Id
                }).ToList();

            if (StkReintegrationArticles.Count == 0)
                model.Id = 1;
            else
            {
                var m = StkReintegrationArticles.Last();
                model.Id = Convert.ToInt32(m.Id) + 1;
            }
            model.DateReingegration = StkReintegration.DateReingegration;
            model.NumBonReintegration = XpertHelper.NumReintegrationAgent;
            var result = _context.StkReintegrationArticles.Add(model);
            await _context.SaveChangesAsync();

            return Json(result.Entity.Id);
        }
        //=================================================Puts===================================
        [HttpPut]
        public async Task<IActionResult> PutReintegration(int key, string values)
        {
            var model = await _context.StkReintegration.FirstOrDefaultAsync(item => item.NumBonReintegration == key);
            if (model == null)
                return StatusCode(409, "Object not found");
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModelReintegration(model, valuesDict);
            await _context.SaveChangesAsync();
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> PutReintegrationDetails(int key, string values)
        {
            var model = await _context.StkReintegrationArticles.FirstOrDefaultAsync(item => item.Id == key);
            if (model == null)
                return StatusCode(409, "Object not found");
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModelReintegrationArticles(model, valuesDict);
            await _context.SaveChangesAsync();
            return Ok();
        }
        //=================================================Deletes===================================
        [HttpDelete]
        public async Task DeleteReintegration(int key)
        {
            var model = await _context.StkReintegration.FirstOrDefaultAsync(item => item.NumBonReintegration == key);
            _context.StkReintegration.Remove(model);
            await _context.SaveChangesAsync();
        }
        [HttpDelete]
        public async Task DeleteReintegrationDetails(int key)
        {
            var model = await _context.StkReintegrationArticles.FirstOrDefaultAsync(item => item.Id == key);
            _context.StkReintegrationArticles.Remove(model);
            await _context.SaveChangesAsync();
        }
        //=================================================Lookups===================================

        [HttpGet]
        public async Task<IActionResult> EmployeLookup(DataSourceLoadOptions loadOptions)
        {
            var lookup = from i in _context.RhListeDesEmployes
                         orderby i.Id
                         select new
                         {
                             Value = i.Id,
                             Text = Convert.ToString(string.Format("{0} {1}", i.Nom, i.Prenom))
                         };
            return Json(await DataSourceLoader.LoadAsync(lookup, loadOptions));
        }
        //=================================================PopulateModels===================================
        private void PopulateModelReintegration(StkReintegration model, IDictionary values)
        {
            string DateReingegration = nameof(StkReintegration.DateReingegration);
            string ServiceEmetteur = nameof(StkReintegration.ServiceEmetteur);
            string CodeIntervenant = nameof(StkReintegration.CodeIntervenant);
            if (values.Contains(DateReingegration))
            {
                model.DateReingegration = Convert.ToDateTime(values[DateReingegration]);
            }
            if (values.Contains(CodeIntervenant))
            {
                model.CodeIntervenant = Convert.ToInt32(values[CodeIntervenant]);
            }
            if (values.Contains(ServiceEmetteur))
            {
                model.ServiceEmetteur = Convert.ToInt32(values[ServiceEmetteur]);
            }
        }
        private void PopulateModelReintegrationArticles(StkReintegrationArticles model, IDictionary values)
        {
            string CodeArticle = nameof(StkReintegrationArticles.CodeArticle);
            string Qte = nameof(StkReintegrationArticles.Qte);
            string CodeIntervenant = nameof(StkReintegrationArticles.CodeIntervenant); 
            string LieuDemande = nameof(StkReintegrationArticles.LieuDemande); 
            string DateReingegration = nameof(StkReintegrationArticles.DateReingegration); 
            if (values.Contains(CodeArticle))
            {
                var CodePdrvar = values[CodeArticle];
                var Idemployestrings = CodePdrvar.ToString();
                var SplitThefirst = Idemployestrings.Split("[");
                var SplitThesecond = SplitThefirst[1].Split("]");
                var CodePdrSplited = SplitThesecond[0];
                model.CodeArticle = Convert.ToInt32(CodePdrSplited);
            }
            if (values.Contains(CodeIntervenant))
            {
                var CodePdrvar = values[CodeIntervenant];
                var Idemployestrings = CodePdrvar.ToString();
                var SplitThefirst = Idemployestrings.Split("[");
                var SplitThesecond = SplitThefirst[1].Split("]");
                var CodePdrSplited = SplitThesecond[0];
                model.CodeIntervenant = Convert.ToInt32(CodePdrSplited);
            }
            if (values.Contains(DateReingegration))
            {
                model.DateReingegration = Convert.ToDateTime(values[DateReingegration]);
            }
            if (values.Contains(Qte))
            {
                model.Qte = Convert.ToInt32(values[Qte]);
            }
            if (values.Contains(LieuDemande))
            {
                model.LieuDemande = Convert.ToString(values[LieuDemande]);
            }
        }
    }
}
