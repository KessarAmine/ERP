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

    public class BilettesController : Controller
    {
        private KBFsteelContext _context;
        public BilettesController(KBFsteelContext context)
        {
            _context = context;
        }
        //=================================================Gets===================================
        [HttpGet]
        public object GetRecapBillettes(DateTime dateDebut, DateTime dateFin, DataSourceLoadOptions loadOptions)
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
        public async Task<IActionResult> GetTransfertBillettes(DateTime dateDebut, DateTime dateFin, DataSourceLoadOptions loadOptions)
        {
            var StkAffectations = _context.StkRapportTransfertBillette
                .Where(c => c.DateTransfert.Date >= dateDebut.Date && c.DateTransfert.Date <= dateFin.Date)
                .Select(i => new {
                    i.NumRapportTransfert,
                    i.DateTransfert
                });
            return Json(await DataSourceLoader.LoadAsync(StkAffectations, loadOptions));
        }
        [HttpGet]
        public async Task<IActionResult> GetTransfertBillettesDetails(int id, DataSourceLoadOptions loadOptions)
        {
            XpertHelper.NumTransfertBilletteMagasin = id;
            var StkAffectations = _context.StkRapportTransfertBillettesDetails
                .Where(c => c.NumRapportTransfert == id)
                .Select(i => new {
                    i.Id,
                    i.HeureTransfert,
                    i.Billette,
                    i.NbrFdx,
                    i.NbrPieces
                });
            return Json(await DataSourceLoader.LoadAsync(StkAffectations, loadOptions));
        }
        [HttpGet]
        public async Task<IActionResult> GetReceptionBillettes(DateTime dateDebut, DateTime dateFin, DataSourceLoadOptions loadOptions)
        {
            var StkAffectations = _context.StkReceptionBillette
                .Where(c => c.DateReception.Date >= dateDebut.Date && c.DateReception.Date <= dateFin.Date)
                .Select(i => new {
                    i.NumReception,
                    i.BilleteRecue,
                    i.DateReception,
                    i.Navire
                });
            return Json(await DataSourceLoader.LoadAsync(StkAffectations, loadOptions));
        }
        [HttpGet]
        public async Task<IActionResult> GetReceptionBillettesDetails(int id, DataSourceLoadOptions loadOptions)
        {
            XpertHelper.NumReceptionBilletteMagasin = id;
            var StkAffectationsArticles = _context.StkReceptionBilletteDetails
                .Where(c => c.NumReception == id)
                .Select(i => new {
                    i.Id,
                    i.NbrFdx,
                    i.NbrPieces,
                    i.NetPoidTh,
                    i.NumBon,
                    i.NumImRemorque,
                    i.NumImTracteur
                });
            return Json(await DataSourceLoader.LoadAsync(StkAffectationsArticles, loadOptions));
        }
        //=================================================Posts===================================
        [HttpPost]
        public async Task<IActionResult> PostReceptionBillette(string values)
        {
            var model = new StkReceptionBillette();
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModelReceptionBillette(model, valuesDict);
            var StkReceptionBillette = _context.StkReceptionBillette
                .OrderBy(o => o.NumReception)
                .Select(i => new
                {
                    i.NumReception
                }).ToList();

            if (StkReceptionBillette.Count == 0)
                model.NumReception = 1;
            else
            {
                var m = StkReceptionBillette.Last();
                model.NumReception = Convert.ToInt32(m.NumReception) + 1;
            }
            var result = _context.StkReceptionBillette.Add(model);
            await _context.SaveChangesAsync();

            return Json(result.Entity.NumReception);
        }
        [HttpPost]
        public async Task<IActionResult> PostReceptionBilletteDetails(string values)
        {
            var model = new StkReceptionBilletteDetails();
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModelReceptionBilletteDetails(model, valuesDict);
            var StkReceptionBillette = _context.StkReceptionBilletteDetails
                .OrderBy(o => o.Id)
                .Select(i => new
                {
                    i.Id
                }).ToList();

            if (StkReceptionBillette.Count == 0)
                model.Id = 1;
            else
            {
                var m = StkReceptionBillette.Last();
                model.Id = Convert.ToInt32(m.Id) + 1;
            }
            model.NumReception = (int)XpertHelper.NumReceptionBilletteMagasin;
            var result = _context.StkReceptionBilletteDetails.Add(model);
            await _context.SaveChangesAsync();

            return Json(result.Entity.Id);
        }
        [HttpPost]
        public async Task<IActionResult> PostTransfertBillette(string values)
        {
            var model = new StkRapportTransfertBillette();
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModelTransfertBillette(model, valuesDict);
            var StkReceptionBillette = _context.StkRapportTransfertBillette
                .OrderBy(o => o.NumRapportTransfert)
                .Select(i => new
                {
                    i.NumRapportTransfert
                }).ToList();

            if (StkReceptionBillette.Count == 0)
                model.NumRapportTransfert = 1;
            else
            {
                var m = StkReceptionBillette.Last();
                model.NumRapportTransfert = Convert.ToInt32(m.NumRapportTransfert) + 1;
            }
            var result = _context.StkRapportTransfertBillette.Add(model);
            await _context.SaveChangesAsync();
            return Json(result.Entity.NumRapportTransfert);
        }
        [HttpPost]
        public async Task<IActionResult> PostTransfertBilletteDetails(string values)
        {
            var model = new StkRapportTransfertBillettesDetails();
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModelTransfertBilletteDetails(model, valuesDict);
            var StkReceptionBillette = _context.StkRapportTransfertBillettesDetails
                .OrderBy(o => o.Id)
                .Select(i => new
                {
                    i.Id
                }).ToList();

            if (StkReceptionBillette.Count == 0)
                model.Id = 1;
            else
            {
                var m = StkReceptionBillette.Last();
                model.Id = Convert.ToInt32(m.Id) + 1;
            }
            model.NumRapportTransfert = (int)XpertHelper.NumTransfertBilletteMagasin;
            var result = _context.StkRapportTransfertBillettesDetails.Add(model);
            await _context.SaveChangesAsync();
            return Json(result.Entity.Id);
        }
        //=================================================Puts===================================
        [HttpPut]
        public async Task<IActionResult> PutReceptionBillette(int key, string values)
        {
            var model = await _context.StkReceptionBillette.FirstOrDefaultAsync(item => item.NumReception == key);
            if (model == null)
                return StatusCode(409, "Object not found");
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModelReceptionBillette(model, valuesDict);
            await _context.SaveChangesAsync();
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> PutReceptionBilletteDetails(int key, string values)
        {
            var model = await _context.StkReceptionBilletteDetails.FirstOrDefaultAsync(item => item.Id == key);
            if (model == null)
                return StatusCode(409, "Object not found");
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModelReceptionBilletteDetails(model, valuesDict);
            await _context.SaveChangesAsync();
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> PutTransfertBillette(int key, string values)
        {
            var model = await _context.StkRapportTransfertBillette.FirstOrDefaultAsync(item => item.NumRapportTransfert == key);
            if (model == null)
                return StatusCode(409, "Object not found");
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModelTransfertBillette(model, valuesDict);
            await _context.SaveChangesAsync();
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> PutTransfertBilletteDetails(int key, string values)
        {
            var model = await _context.StkRapportTransfertBillettesDetails.FirstOrDefaultAsync(item => item.Id == key);
            if (model == null)
                return StatusCode(409, "Object not found");
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModelTransfertBilletteDetails(model, valuesDict);
            await _context.SaveChangesAsync();
            return Ok();
        }
        //=================================================Deletes===================================
        [HttpDelete]
        public async Task DeleteTransfertBillette(int key)
        {
            var model = await _context.StkRapportTransfertBillette.FirstOrDefaultAsync(item => item.NumRapportTransfert == key);
            _context.StkRapportTransfertBillette.Remove(model);
            await _context.SaveChangesAsync();
        }
        [HttpDelete]
        public async Task DeleteTransfertBilletteDetails(int key)
        {
            var model = await _context.StkRapportTransfertBillettesDetails.FirstOrDefaultAsync(item => item.Id == key);
            _context.StkRapportTransfertBillettesDetails.Remove(model);
            await _context.SaveChangesAsync();
        }
        [HttpDelete]
        public async Task DeleteReceptionBillette(int key)
        {
            var model = await _context.StkReceptionBillette.FirstOrDefaultAsync(item => item.NumReception == key);
            _context.StkReceptionBillette.Remove(model);
            await _context.SaveChangesAsync();
        }
        [HttpDelete]
        public async Task DeleteReceptionBilletteDetails(int key)
        {
            var model = await _context.StkReceptionBilletteDetails.FirstOrDefaultAsync(item => item.Id == key);
            _context.StkReceptionBilletteDetails.Remove(model);
            await _context.SaveChangesAsync();
        }
        //=================================================Lookups===================================
        
        //=================================================PopulateModels===================================
        private void PopulateModelTransfertBillette(StkRapportTransfertBillette model, IDictionary values)
        {
            string DateTransfert = nameof(StkRapportTransfertBillette.DateTransfert);
            if (values.Contains(DateTransfert))
            {
                model.DateTransfert = Convert.ToDateTime(values[DateTransfert]);
            }
        }
        private void PopulateModelTransfertBilletteDetails(StkRapportTransfertBillettesDetails model, IDictionary values)
        {
            string Billette = nameof(StkRapportTransfertBillettesDetails.Billette);
            string HeureTransfert = nameof(StkRapportTransfertBillettesDetails.HeureTransfert);
            string NbrFdx = nameof(StkRapportTransfertBillettesDetails.NbrFdx);
            string NbrPieces = nameof(StkRapportTransfertBillettesDetails.NbrPieces);  
            string Observation = nameof(StkRapportTransfertBillettesDetails.Observation);  
            if (values.Contains(NbrFdx))
            {
                model.NbrFdx = Convert.ToInt32(values[NbrFdx]);
            }
            if (values.Contains(NbrPieces))
            {
                model.NbrPieces = Convert.ToInt32(values[NbrPieces]);
            }
            if (values.Contains(Observation))
            {
                model.Observation = Convert.ToString(values[Observation]);
            }          
            if (values.Contains(Billette))
            {
                model.Billette = Convert.ToString(values[Billette]);
            }           
            if (values.Contains(HeureTransfert))
            {
                model.HeureTransfert = Convert.ToDateTime(values[HeureTransfert]);
            }
        }
        private void PopulateModelReceptionBillette(StkReceptionBillette model, IDictionary values)
        {
            string BilleteRecue = nameof(StkReceptionBillette.BilleteRecue);
            string DateReception = nameof(StkReceptionBillette.DateReception);  
            string Navire = nameof(StkReceptionBillette.Navire);  
            if (values.Contains(DateReception))
            {
                model.DateReception = Convert.ToDateTime(values[DateReception]);
            }
            if (values.Contains(BilleteRecue))
            {
                model.BilleteRecue = Convert.ToString(values[BilleteRecue]);
            }
            if (values.Contains(Navire))
            {
                model.Navire = Convert.ToString(values[Navire]);
            }
        }
        private void PopulateModelReceptionBilletteDetails(StkReceptionBilletteDetails model, IDictionary values)
        {
            string NbrFdx = nameof(StkReceptionBilletteDetails.NbrFdx);
            string NbrPieces = nameof(StkReceptionBilletteDetails.NbrPieces);
            string NetPoidTh = nameof(StkReceptionBilletteDetails.NetPoidTh);
            string NumBon = nameof(StkReceptionBilletteDetails.NumBon);
            string NumImRemorque = nameof(StkReceptionBilletteDetails.NumImRemorque);
            string NumImTracteur = nameof(StkReceptionBilletteDetails.NumImTracteur);     
            if (values.Contains(NbrFdx))
            {
                model.NbrFdx = Convert.ToInt32(values[NbrFdx]);
            }
            if (values.Contains(NbrPieces))
            {
                model.NbrPieces = Convert.ToInt32(values[NbrPieces]);
            }
            if (values.Contains(NumBon))
            {
                model.NumBon = Convert.ToInt32(values[NumBon]);
            }           
            if (values.Contains(NumImRemorque))
            {
                model.NumImRemorque = Convert.ToInt32(values[NumImRemorque]);
            }
            if (values.Contains(NumImTracteur))
            {
                model.NumImTracteur = Convert.ToInt32(values[NumImTracteur]);
            }
            if (values.Contains(NetPoidTh))
            {
                model.NetPoidTh = Convert.ToDouble(values[NetPoidTh]);
            }
        }
    }
}
