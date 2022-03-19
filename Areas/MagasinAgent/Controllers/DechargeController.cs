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

    public class DechargeController : Controller
    {
        private KBFsteelContext _context;
        public DechargeController(KBFsteelContext context)
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
        public async Task<IActionResult> GetDecharge(DateTime dateDebut, DateTime dateFin, DataSourceLoadOptions loadOptions)
        {
            var StkAffectations = _context.StkDecharge
                .Where(c => c.DateDecharge.Date >= dateDebut.Date && c.DateDecharge.Date <= dateFin.Date)
                .Select(i => new {
                    i.DateDecharge,
                    i.NumDecharge,
                    i.ServiceReceveur,
                    i.CodeIntervenant
                });
            return Json(await DataSourceLoader.LoadAsync(StkAffectations, loadOptions));
        }
        [HttpGet]
        public async Task<IActionResult> GetDechargeDetails(int id, DataSourceLoadOptions loadOptions)
        {
            XpertHelper.NumDechargeAgent = id;
            var StkAffectations = _context.StkDechargeArticles
                .Where(c => c.NumDecharge == id)
                .Select(i => new {
                    i.Id,
                    i.CodeArticle,
                    i.Qte,
                    i.NumDecharge,
                    i.Observation,
                    i.DateDecharge
                });
            return Json(await DataSourceLoader.LoadAsync(StkAffectations, loadOptions));
        }
        //=================================================Posts===================================
        [HttpPost]
        public async Task<IActionResult> PostDecharge(string values)
        {
            var model = new StkDecharge();
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModelDecharge(model, valuesDict);
            var StkDecharge = _context.StkDecharge
                .OrderBy(o => o.NumDecharge)
                .Select(i => new
                {
                    i.NumDecharge
                }).ToList();
            if (StkDecharge.Count == 0)
                model.NumDecharge = 1;
            else
            {
                var m = StkDecharge.Last();
                model.NumDecharge = Convert.ToInt32(m.NumDecharge) + 1;
            }
            model.DateDecharge = DateTime.Now.Date;

            var result = _context.StkDecharge.Add(model);
            await _context.SaveChangesAsync();

            return Json(result.Entity.NumDecharge);
        }
        [HttpPost]
        public async Task<IActionResult> PostDechargeDetails(string values)
        {
            var model = new StkDechargeArticles();
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModelDechargeArticles(model, valuesDict);
            var StkDecharge = _context.StkDecharge
                .Where(o => o.NumDecharge == XpertHelper.NumDechargeAgent)
                .Select(i => new
                {
                    i.DateDecharge
                }).Last();
            var StkDechargeArticles = _context.StkDechargeArticles
                .OrderBy(o => o.Id)
                .Select(i => new
                {
                    i.Id
                }).ToList();

            if (StkDechargeArticles.Count == 0)
                model.Id = 1;
            else
            {
                var m = StkDechargeArticles.Last();
                model.Id = Convert.ToInt32(m.Id) + 1;
            }
            model.DateDecharge = StkDecharge.DateDecharge;
            model.NumDecharge = XpertHelper.NumDechargeAgent;
            var result = _context.StkDechargeArticles.Add(model);
            await _context.SaveChangesAsync();

            return Json(result.Entity.Id);
        }
        //=================================================Puts===================================
        [HttpPut]
        public async Task<IActionResult> PutDecharge(int key, string values)
        {
            var model = await _context.StkDecharge.FirstOrDefaultAsync(item => item.NumDecharge == key);
            if (model == null)
                return StatusCode(409, "Object not found");
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModelDecharge(model, valuesDict);
            await _context.SaveChangesAsync();
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> PutDechargeDetails(int key, string values)
        {
            var model = await _context.StkDechargeArticles.FirstOrDefaultAsync(item => item.Id == key);
            if (model == null)
                return StatusCode(409, "Object not found");
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModelDechargeArticles(model, valuesDict);
            await _context.SaveChangesAsync();
            return Ok();
        }
        //=================================================Deletes===================================
        [HttpDelete]
        public async Task DeleteDecharge(int key)
        {
            var model = await _context.StkDecharge.FirstOrDefaultAsync(item => item.NumDecharge == key);
            _context.StkDecharge.Remove(model);
            await _context.SaveChangesAsync();
        }
        [HttpDelete]
        public async Task DeleteDechargeDetails(int key)
        {
            var model = await _context.StkDechargeArticles.FirstOrDefaultAsync(item => item.Id == key);
            _context.StkDechargeArticles.Remove(model);
            await _context.SaveChangesAsync();
        }
        //=================================================Lookups===================================
        
        //=================================================PopulateModels===================================
        private void PopulateModelDecharge(StkDecharge model, IDictionary values)
        {
            string DateDecharge = nameof(StkDecharge.DateDecharge);
            string ServiceReceveur = nameof(StkDecharge.ServiceReceveur);
            string CodeIntervenant = nameof(StkDecharge.CodeIntervenant);
            if (values.Contains(DateDecharge))
            {
                model.DateDecharge = Convert.ToDateTime(values[DateDecharge]);
            }
            if (values.Contains(ServiceReceveur))
            {
                model.ServiceReceveur = Convert.ToInt32(values[ServiceReceveur]);
            }
            if (values.Contains(CodeIntervenant))
            {
                model.CodeIntervenant = Convert.ToInt32(values[CodeIntervenant]);
            }
        }
        private void PopulateModelDechargeArticles(StkDechargeArticles model, IDictionary values)
        {
            string CodeArticle = nameof(StkDechargeArticles.CodeArticle);
            string Qte = nameof(StkDechargeArticles.Qte);
            string Observation = nameof(StkDechargeArticles.Observation); 
            string DateDecharge = nameof(StkDechargeArticles.DateDecharge); 
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
            if (values.Contains(Observation))
            {
                model.Observation = Convert.ToString(values[Observation]);
            }
            if (values.Contains(DateDecharge))
            {
                model.DateDecharge = Convert.ToDateTime(values[DateDecharge]);
            }
        }
    }
}
