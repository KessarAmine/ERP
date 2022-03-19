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
using DevKbfSteel.Areas.MagasinSuperviseur.Models;

namespace DevKbfSteel.Areas.MagasinSuperviseur.Controllers
{
    [Area(nameof(Areas.MagasinSuperviseur))]

    public class LieuxStockageController : Controller
    {
        private KBFsteelContext _context;
        public LieuxStockageController(KBFsteelContext context)
        {
            _context = context;
        }
        //=================================================BonTransfert===================================
        [HttpGet]
        public Object GetArticlesLieux(int CodeLieu, DataSourceLoadOptions loadOptions)
        {
            List<LieuPdrModel> LieuPdrModelList = new List<LieuPdrModel>();
            var empl = _context.StkEmplacement.AsNoTracking().Where(c => c.CodeLieu == CodeLieu).ToList();
            foreach (var itemempl in empl)
            {
                LieuPdrModel lieuPdrModel = new LieuPdrModel();
                var pdr = _context.StkPdr.AsNoTracking().Where(c => c.CodePdr == itemempl.CodePdr).ToList();
                if (pdr.Count() >0) 
                {
                    var PDR = pdr.Last();
                    lieuPdrModel.CodePdr = (int)itemempl.CodePdr;
                    lieuPdrModel.DesignationPdr = PDR.DesignationPdr;
                    lieuPdrModel.ReferenceModele = PDR.ReferenceModele;
                    var lastmovement = _context.StkMovements.AsNoTracking().Where(c => c.CodePdr == lieuPdrModel.CodePdr).ToList();
                    if (lastmovement.Count() > 0)
                    {
                        var mvt = lastmovement.Last();
                        lieuPdrModel.Quantite = (float)mvt.StockTotalSythese;
                    }
                    else
                    {
                        var stockinitial = _context.StkStockInitial.AsNoTracking().Where(c => c.CodePdr == lieuPdrModel.CodePdr).ToList();
                        if (stockinitial.Count() > 0)
                        {
                            var stk = stockinitial.Last();
                            lieuPdrModel.Quantite = (float)stk.Qte;
                        }
                        else
                        {
                            lieuPdrModel.Quantite = 0;
                        }
                    }
                    LieuPdrModelList.Add(lieuPdrModel);
                }
            }
            return DataSourceLoader.Load(LieuPdrModelList.AsEnumerable(), loadOptions);
        }
        [HttpGet]
        public async Task<IActionResult> GetLieux(DataSourceLoadOptions loadOptions)
        {
            var StkBonTransfert = _context.StkLieu
                .Select(i => new {
                    i.CodeLieu,
                    i.DesignationLieu
                });
            return Json(await DataSourceLoader.LoadAsync(StkBonTransfert, loadOptions));
        }
        [HttpGet]
        public async Task<IActionResult> GetGisement(DataSourceLoadOptions loadOptions)
        {
            var StkBonTransfertArticles = _context.StkGismentPdr
                .Select(i => new {
                    i.CodeGisment,
                    i.DesignationGisment
                });
            return Json(await DataSourceLoader.LoadAsync(StkBonTransfertArticles, loadOptions));
        }
        [HttpPost]
        public async Task<IActionResult> PostLieux(string values)
        {
            var model = new StkLieu();
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModelLieu(model, valuesDict);
            var StkReceptionBillette = _context.StkLieu
                .Select(i => new
                {
                    i.CodeLieu
                }).ToList();
            if (StkReceptionBillette.Count == 0)
                model.CodeLieu = 1;
            else
            {
                var m = StkReceptionBillette.Last();
                model.CodeLieu = Convert.ToInt32(m.CodeLieu) + 1;
            }
            var result = _context.StkLieu.Add(model);
            //Change Lieu of that Pdr in Emplacement
            await _context.SaveChangesAsync();

            return Json(result.Entity.CodeLieu);
        }
        [HttpPost]
        public async Task<IActionResult> PostGisement(string values)
        {
            var model = new StkGismentPdr();
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModelGisement(model, valuesDict);
            var StkReceptionBillette = _context.StkGismentPdr
                .Select(i => new
                {
                    i.CodeGisment
                }).ToList();

            if (StkReceptionBillette.Count == 0)
                model.CodeGisment = 1;
            else
            {
                var m = StkReceptionBillette.Last();
                model.CodeGisment = Convert.ToInt32(m.CodeGisment) + 1;
            }
            var result = _context.StkGismentPdr.Add(model);
            await _context.SaveChangesAsync();
            return Json(result.Entity.CodeGisment);
        }
        [HttpPut]
        public async Task<IActionResult> PutLieux(int key, string values)
        {
            var model = await _context.StkLieu.FirstOrDefaultAsync(item => item.CodeLieu == key);
            if (model == null)
                return StatusCode(409, "Object not found");
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModelLieu(model, valuesDict);
            await _context.SaveChangesAsync();
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> PutGisement(int key, string values)
        {
            var model = await _context.StkGismentPdr.FirstOrDefaultAsync(item => item.CodeGisment == key);
            if (model == null)
                return StatusCode(409, "Object not found");
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModelGisement(model, valuesDict);
            await _context.SaveChangesAsync();
            return Ok();
        }
        [HttpDelete]
        public async Task DeleteLieux(int key)
        {
            var model = await _context.StkLieu.FirstOrDefaultAsync(item => item.CodeLieu == key);
            _context.StkLieu.Remove(model);
            await _context.SaveChangesAsync();
        }
        [HttpDelete]
        public async Task DeleteGisement(int key)
        {
            var model = await _context.StkGismentPdr.FirstOrDefaultAsync(item => item.CodeGisment == key);
            _context.StkGismentPdr.Remove(model);
            await _context.SaveChangesAsync();
        }
        //=================================================LookUps==========================================
        [HttpGet]
        public async Task<IActionResult> SourceDestinationLookup(DataSourceLoadOptions loadOptions)
        {
            var lookup = from i in _context.StkLieu
                         orderby i.CodeLieu
                         select new
                         {
                             Value = i.CodeLieu,
                             Text = i.DesignationLieu
                         };
            return Json(await DataSourceLoader.LoadAsync(lookup, loadOptions));
        }
        //=================================================PopulateModels===================================
        private void PopulateModelLieu(StkLieu model, IDictionary values)
        {
            string DesignationLieu = nameof(StkLieu.DesignationLieu);
            if (values.Contains(DesignationLieu))
            {
                model.DesignationLieu = Convert.ToString(values[DesignationLieu]);
            }
        }
        private void PopulateModelGisement(StkGismentPdr model, IDictionary values)
        {
            string DesignationGisment = nameof(StkGismentPdr.DesignationGisment);
            if (values.Contains(DesignationGisment))
            {
                model.DesignationGisment = Convert.ToString(values[DesignationGisment]);
            }
        }
    }
}
