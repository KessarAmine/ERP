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

    public class TransfertController : Controller
    {
        private KBFsteelContext _context;
        public TransfertController(KBFsteelContext context)
        {
            _context = context;
        }
        //=================================================BonTransfert===================================
        [HttpGet]
        public async Task<IActionResult> GetTransfert(DateTime dateDebut, DateTime dateFin, DataSourceLoadOptions loadOptions)
        {
            var StkBonTransfert = _context.StkBonTransfert
                .Where(c => c.DateTransfert.Date >= dateDebut.Date && c.DateTransfert.Date <= dateFin.Date)
                .Select(i => new {
                    i.DateTransfert,
                    i.Destination,
                    i.Source,
                    i.NumBonTransfert,
                    i.CodeIntervenant
                });
            return Json(await DataSourceLoader.LoadAsync(StkBonTransfert, loadOptions));
        }
        [HttpGet]
        public async Task<IActionResult> GetTransfertArticles(int NumBonTransfert, DataSourceLoadOptions loadOptions)
        {
            XpertHelper.NumBonTransfert = NumBonTransfert;
            var StkBonTransfertArticles = _context.StkBonTransfertArticles
                .Where(c => c.NumBonTransfert == NumBonTransfert)
                .Select(i => new {
                    i.Id,
                    i.CodePdr,
                    i.Qte,
                    i.DateTransfert
                });
            return Json(await DataSourceLoader.LoadAsync(StkBonTransfertArticles, loadOptions));
        }
        [HttpPost]
        public async Task<IActionResult> PostTransfert(string values)
        {
            var model = new StkBonTransfert();
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModelTransfert(model, valuesDict);
            var Lieu = _context.StkLieu
            .Where(o => o.CodeLieu == model.Source)
            .Select(i => new
            {
                i.DesignationLieu
            }).ToList().Last();
            var Lieux = _context.StkEmplacement
            .Where(o => o.CodeLieu == model.Source)
            .Select(i => new
            {
                i.CodePdr
            }).ToList();
            if (model.Source == model.Destination)
            {
                return StatusCode(409, "La source et la destination doivent être différent");
            }
            int found = 0;
            foreach (var itemLieux in Lieux)
            {
                if (itemLieux.CodePdr == model.Source)
                    found = 1;
            }
            if(found == 0)
            {
                return StatusCode(409,Lieu.DesignationLieu+" ne contient pas cette article");
            }
            var StkReceptionBillette = _context.StkBonTransfert
                .OrderBy(o => o.NumBonTransfert)
                .Select(i => new
                {
                    i.NumBonTransfert
                }).ToList();
            if (StkReceptionBillette.Count == 0)
                model.NumBonTransfert = 1;
            else
            {
                var m = StkReceptionBillette.Last();
                model.NumBonTransfert = Convert.ToInt32(m.NumBonTransfert) + 1;
            }
            model.DateTransfert = DateTime.Now.Date;
            var result = _context.StkBonTransfert.Add(model);
            //Change Lieu of that Pdr in Emplacement
            await _context.SaveChangesAsync();

            return Json(result.Entity.NumBonTransfert);
        }
        [HttpPost]
        public async Task<IActionResult> PostTransfertArticles(string values)
        {
            var model = new StkBonTransfertArticles();
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModelTransfertArticles(model, valuesDict);
            var StkBonTransfert = _context.StkBonTransfert
                .Where(c => c.NumBonTransfert == (int)XpertHelper.NumBonTransfert)
                .Select(i => new {
                    i.DateTransfert
                }).Last();
            var StkReceptionBillette = _context.StkBonTransfertArticles
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
            model.DateTransfert = StkBonTransfert.DateTransfert;
            model.NumBonTransfert = (int)XpertHelper.NumBonTransfert;
            var result = _context.StkBonTransfertArticles.Add(model);
            /*
            var destination = _context.StkBonTransfert
            .Where(o => o.NumBonTransfert == model.NumBonTransfert)
            .AsNoTracking()
            .Select(i => new
            {
                i.Destination
            }).LastOrDefault();

            var empl = _context.StkEmplacement
            .Where(o => o.CodePdr == model.CodePdr).LastOrDefault();
            empl.CodeLieu = destination.Destination;
            _context.StkEmplacement.Update(empl);
            */
            await _context.SaveChangesAsync();
            return Json(result.Entity.Id);
        }
        [HttpPut]
        public async Task<IActionResult> PutTransfert(int key, string values)
        {
            var model = await _context.StkBonTransfert.FirstOrDefaultAsync(item => item.NumBonTransfert == key);
            if (model == null)
                return StatusCode(409, "Object not found");
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModelTransfert(model, valuesDict);
            await _context.SaveChangesAsync();
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> PutTransfertArticles(int key, string values)
        {
            var model = await _context.StkBonTransfertArticles.FirstOrDefaultAsync(item => item.Id == key);
            if (model == null)
                return StatusCode(409, "Object not found");
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModelTransfertArticles(model, valuesDict);
            await _context.SaveChangesAsync();
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteTransfert(int key)
        {
            var model = await _context.StkBonTransfert.FirstOrDefaultAsync(item => item.NumBonTransfert == key);
            var details = _context.StkBonTransfertArticles.Where(item => item.NumBonTransfert == key).ToList();
            if (details.Count > 0)
                return StatusCode(409, "Non autorisé : vueillez suprimmer les détails avant");
            _context.StkBonTransfert.Remove(model);
            await _context.SaveChangesAsync();
            return Ok();
        }
        [HttpDelete]
        public async Task DeleteTransfertArticles(int key)
        {
            var model = await _context.StkBonTransfertArticles.FirstOrDefaultAsync(item => item.Id == key);
            _context.StkBonTransfertArticles.Remove(model);
            await _context.SaveChangesAsync();
        }
        //=================================================BonRetourTransfert===================================
        [HttpGet]
        public async Task<IActionResult> GetRetourTransfert(int NumBonTransfert, DataSourceLoadOptions loadOptions)
        {
            XpertHelper.NumBonTransfert = NumBonTransfert;
            var StkBonRetourTransfert = _context.StkBonRetourTransfert
                .Where(c => c.NumBonTransfert == NumBonTransfert)
                .Select(i => new {
                    i.Chauffeur,
                    i.DateRetour,
                    i.Source,
                    i.Matricule,
                    i.Npc,
                    i.NumBonTransfert,
                    i.NumBonRetourTransfert
                });
            return Json(await DataSourceLoader.LoadAsync(StkBonRetourTransfert, loadOptions));
        }
        [HttpGet]
        public async Task<IActionResult> GetRetourTransfertArticles(int NumBonRetourTransfert, DataSourceLoadOptions loadOptions)
        {
            XpertHelper.NumBonRetourTransfert = NumBonRetourTransfert;
            var StkBonRetourTransfertArticles = _context.StkBonRetourTransfertArticles
                .Where(c => c.NumBonRetourTransfert == NumBonRetourTransfert)
                .Select(i => new {
                    i.Id,
                    i.CodePdr,
                    i.Qte
                });
            return Json(await DataSourceLoader.LoadAsync(StkBonRetourTransfertArticles, loadOptions));
        }
        [HttpPost]
        public async Task<IActionResult> PostRetourTransfert(string values)
        {
            var model = new StkBonRetourTransfert();
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModelRetourTransfert(model, valuesDict);
            var StkReceptionBillette = _context.StkBonRetourTransfert
                .OrderBy(o => o.NumBonTransfert)
                .Select(i => new
                {
                    i.NumBonRetourTransfert
                }).ToList();

            if (StkReceptionBillette.Count == 0)
                model.NumBonRetourTransfert = 1;
            else
            {
                var m = StkReceptionBillette.Last();
                model.NumBonRetourTransfert = Convert.ToInt32(m.NumBonRetourTransfert) + 1;
            }
            model.NumBonTransfert = (int)XpertHelper.NumBonTransfert;
            var result = _context.StkBonRetourTransfert.Add(model);
            await _context.SaveChangesAsync();

            return Json(result.Entity.NumBonRetourTransfert);
        }
        [HttpPost]
        public async Task<IActionResult> PostRetourTransfertArticles(string values)
        {
            var model = new StkBonRetourTransfertArticles();
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModelRetourTransfertArticles(model, valuesDict);
            var StkReceptionBillette = _context.StkBonRetourTransfertArticles
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
            model.NumBonRetourTransfert = (int)XpertHelper.NumBonRetourTransfert;
            var result = _context.StkBonRetourTransfertArticles.Add(model);
            await _context.SaveChangesAsync();

            return Json(result.Entity.Id);
        }
        [HttpPut]
        public async Task<IActionResult> PutRetourTransfert(int key, string values)
        {
            var model = await _context.StkBonRetourTransfert.FirstOrDefaultAsync(item => item.NumBonRetourTransfert == key);
            if (model == null)
                return StatusCode(409, "Object not found");
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModelRetourTransfert(model, valuesDict);
            await _context.SaveChangesAsync();
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> PutRetourTransfertArticles(int key, string values)
        {
            var model = await _context.StkBonRetourTransfertArticles.FirstOrDefaultAsync(item => item.Id == key);
            if (model == null)
                return StatusCode(409, "Object not found");
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModelRetourTransfertArticles(model, valuesDict);
            await _context.SaveChangesAsync();
            return Ok();
        }
        [HttpDelete]
        public async Task DeleteRetourTransfert(int key)
        {
            var model = await _context.StkBonRetourTransfert.FirstOrDefaultAsync(item => item.NumBonRetourTransfert == key);
            _context.StkBonRetourTransfert.Remove(model);
            await _context.SaveChangesAsync();
        }
        [HttpDelete]
        public async Task DeleteRetourTransfertArticles(int key)
        {
            var model = await _context.StkBonRetourTransfertArticles.FirstOrDefaultAsync(item => item.Id == key);
            _context.StkBonRetourTransfertArticles.Remove(model);
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
        private void PopulateModelRetourTransfert(StkBonRetourTransfert model, IDictionary values)
        {
            string DateRetour = nameof(StkBonRetourTransfert.DateRetour);
            string Chauffeur = nameof(StkBonRetourTransfert.Chauffeur);
            string Source = nameof(StkBonRetourTransfert.Source);
            string Matricule = nameof(StkBonRetourTransfert.Matricule);
            string Npc = nameof(StkBonRetourTransfert.Npc);
            if (values.Contains(Chauffeur))
            {
                model.Chauffeur = Convert.ToString(values[Chauffeur]);
            }
            if (values.Contains(Source))
            {
                model.Source = Convert.ToString(values[Source]);
            }
            if (values.Contains(Npc))
            {
                model.Npc = Convert.ToString(values[Npc]);
            }
            if (values.Contains(Matricule))
            {
                model.Matricule = Convert.ToInt32(values[Matricule]);
            }
            if (values.Contains(DateRetour))
            {
                model.DateRetour = Convert.ToDateTime(values[DateRetour]);
            }
        }
        private void PopulateModelRetourTransfertArticles(StkBonRetourTransfertArticles model, IDictionary values)
        {
            string CodePdr = nameof(StkBonRetourTransfertArticles.CodePdr);
            string Qte = nameof(StkBonRetourTransfertArticles.Qte);
            if (values.Contains(CodePdr))
            {
                model.CodePdr = Convert.ToInt32(values[CodePdr]);
            }
            if (values.Contains(Qte))
            {
                model.Qte = Convert.ToInt32(values[Qte]);
            }
        }
        private void PopulateModelTransfert(StkBonTransfert model, IDictionary values)
        {
            string DateTransfert = nameof(StkBonTransfert.DateTransfert);
            string Source = nameof(StkBonTransfert.Source);
            string Destination = nameof(StkBonTransfert.Destination);
            string CodeIntervenant = nameof(StkBonTransfert.CodeIntervenant);
            if (values.Contains(CodeIntervenant))
            {
                model.CodeIntervenant = Convert.ToInt32(values[CodeIntervenant]);
            }
            if (values.Contains(Destination))
            {
                model.Destination = Convert.ToInt32(values[Destination]);
            }
            if (values.Contains(Source))
            {
                model.Source = Convert.ToInt32(values[Source]);
            }
            if (values.Contains(DateTransfert))
            {
                model.DateTransfert = Convert.ToDateTime(values[DateTransfert]);
            }
        }
        private void PopulateModelTransfertArticles(StkBonTransfertArticles model, IDictionary values)
        {
            string CodePdr = nameof(StkBonTransfertArticles.CodePdr);
            string Qte = nameof(StkBonTransfertArticles.Qte);
            string DateTransfert = nameof(StkBonTransfertArticles.DateTransfert);
            if (values.Contains(DateTransfert))
            {
                model.DateTransfert = Convert.ToDateTime(values[DateTransfert]);
            }
            if (values.Contains(CodePdr))
            {
                model.CodePdr = Convert.ToInt32(values[CodePdr]);
            }
            if (values.Contains(Qte))
            {
                model.Qte = Convert.ToInt32(values[Qte]);
            }
        }
    }
}
