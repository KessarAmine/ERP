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
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Microsoft.EntityFrameworkCore.Internal;
using DevExpress.Data.Extensions;
using Newtonsoft.Json.Linq;
using DevKbfSteel.Helpers;
namespace DevKbfSteel.Controllers
{
    [Area(nameof(Areas.RhManager))]
    public class RhContratsEmployesController : Controller
    {
        private KBFsteelContext _context;
        public RhContratsEmployesController(KBFsteelContext context) {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> Get(DataSourceLoadOptions loadOptions) {
            var rhContratsEmployes = _context.RhContratsEmployes.Select(i => new {
                i.Id,
                i.IdEmployee,
                i.DateAmbouche,
                i.DateFinAmbouche,
                i.Periode,
                i.UniteRecrutement,
                i.TypeContrat,
                i.Etat
            });
            // If you work with a large amount of data, consider specifying the PaginateViaPrimaryKey and PrimaryKey properties.
            // In this case, keys and data are loaded in separate queries. This can make the SQL execution plan more efficient.
            // Refer to the topic https://github.com/DevExpress/DevExtreme.AspNet.Data/issues/336.
            // loadOptions.PrimaryKey = new[] { "NumEquipement" };
            // loadOptions.PaginateViaPrimaryKey = true;

            return Json(await DataSourceLoader.LoadAsync(rhContratsEmployes, loadOptions));
        }
        [HttpPost]
        public async Task<IActionResult> Post(string values) {
            var model = new RhContratsEmployes();
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModel(model, valuesDict);

            model.DateAmbouche = model.DateAmbouche.AddHours(1.0);
            var lastRhContratsEmployes = _context.RhContratsEmployes
                .Select(i => new {
                i.Id
            }).ToList();

            if (lastRhContratsEmployes.Count == 0)
            {
                model.Id = 1;
            }
            else
            {
                var m = lastRhContratsEmployes.Last();
                model.Id = m.Id+1;
            }
            var result = _context.RhContratsEmployes.Add(model);
            if (model.UniteRecrutement == 1)
            {
                model.DateFinAmbouche = model.DateAmbouche.AddMonths(model.Periode);
            }
            if (model.UniteRecrutement == 2)
            {
                model.DateFinAmbouche = model.DateAmbouche.AddYears(model.Periode);
            }
            var updt = await _context.RhListeDesEmployes.Where(c => c.Id == model.IdEmployee).FirstOrDefaultAsync();
            updt.DateAmbouche = model.DateAmbouche;
            updt.DateFinAmbouche = model.DateFinAmbouche;
            updt.Disponnible = model.Etat;
            _context.RhListeDesEmployes.Update(updt);
            await _context.SaveChangesAsync();
            return Json(result.Entity.Id);
        }
        [HttpPut]
        public async Task<IActionResult> Put(int key, string values) {
            var model = await _context.RhContratsEmployes.FirstOrDefaultAsync(item => item.Id == key);
            if(model == null)
                return StatusCode(409, "Object not found");

            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModel(model, valuesDict);
            if (model.UniteRecrutement == 1)
            {
                model.DateFinAmbouche = model.DateAmbouche.AddMonths(model.Periode);
            }
            if (model.UniteRecrutement == 2)
            {
                model.DateFinAmbouche = model.DateAmbouche.AddYears(model.Periode);
            }
            var updt = await _context.RhListeDesEmployes.Where(c => c.Id == model.IdEmployee).FirstOrDefaultAsync();
            updt.DateAmbouche = model.DateAmbouche;
            updt.DateFinAmbouche = model.DateFinAmbouche;
            updt.Disponnible = model.Etat;
            _context.RhListeDesEmployes.Update(updt);
            await _context.SaveChangesAsync();
            return Ok();
        }
        [HttpDelete]
        public async Task Delete(int key) {
            var model = await _context.RhContratsEmployes.FirstOrDefaultAsync(item => item.Id == key);
            _context.RhContratsEmployes.Remove(model);
            var updt = await _context.RhListeDesEmployes.Where(c => c.Id == model.IdEmployee).FirstOrDefaultAsync();
            if(updt != null)
            {
                updt.DateAmbouche = null;
                updt.DateFinAmbouche = null;
                updt.Disponnible = null;
                _context.RhListeDesEmployes.Update(updt);
            }
            await _context.SaveChangesAsync();
        }
        private void PopulateModel(RhContratsEmployes model, IDictionary values) {
            string IdEmployee = nameof(RhContratsEmployes.IdEmployee);
            string DateAmbouche = nameof(RhContratsEmployes.DateAmbouche);
            string Periode = nameof(RhContratsEmployes.Periode);
            string UniteRecrutement = nameof(RhContratsEmployes.UniteRecrutement);
            string TypeContrat = nameof(RhContratsEmployes.TypeContrat);
            string Etat = nameof(RhContratsEmployes.Etat);
            if (values.Contains(IdEmployee))
            {
                var Idemployevar = values[IdEmployee];
                var Idemployestrings = Idemployevar.ToString();
                var SplitThefirst = Idemployestrings.Split("[");
                var SplitThesecond = SplitThefirst[1].Split("]");
                var value = SplitThesecond[0];
                model.IdEmployee = Convert.ToInt32(value);
            }
            if (values.Contains(Periode))
            {
                model.Periode = Convert.ToInt32(values[Periode]);
            }
            if (values.Contains(UniteRecrutement))
            {
                model.UniteRecrutement = Convert.ToInt32(values[UniteRecrutement]);
            }
            if (values.Contains(TypeContrat))
            {
                //Stage = 4
                //checking if its a stage set the status to en essaie 1 else set to actif 2
                if (TypeContrat.Equals(4))
                {
                    model.Etat = 1;
                }
                else
                {
                    model.Etat = 2;
                }
                model.TypeContrat = Convert.ToInt32(values[TypeContrat]);
            }
            if (values.Contains(Etat))
            {
                model.Etat = Convert.ToInt32(values[Etat]);
            }
            if (values.Contains(DateAmbouche))
            {
                model.DateAmbouche = Convert.ToDateTime(values[DateAmbouche]);
            }
        }
        private string GetFullErrorMessage(ModelStateDictionary modelState) {
            var messages = new List<string>();

            foreach(var entry in modelState) {
                foreach(var error in entry.Value.Errors)
                    messages.Add(error.ErrorMessage);
            }

            return String.Join(" ", messages);
        }

        //===================Lookups=================
        [HttpGet]
        public async Task<IActionResult> UniteRecrutementLookup(DataSourceLoadOptions loadOptions)
        {
            var lookup = from i in _context.LookupUniteRecrutement
                         orderby i.CodeUniteRecrutement
                         select new
                         {
                             Value = i.CodeUniteRecrutement,
                             Text = i.DesignatioUniteRecrutement
                         };
            return Json(await DataSourceLoader.LoadAsync(lookup, loadOptions));
        }
        [HttpGet]
        public async Task<IActionResult> TypeContratLookup(DataSourceLoadOptions loadOptions)
        {
            var lookup = from i in _context.LookupTypeContrats
                         orderby i.CodeTypeContrat
                         select new
                         {
                             Value = i.CodeTypeContrat,
                             Text = i.DesignationTypeContrat
                         };
            return Json(await DataSourceLoader.LoadAsync(lookup, loadOptions));
        }
        [HttpGet]
        public async Task<IActionResult> EtatLookup(DataSourceLoadOptions loadOptions)
        {
            var lookup = from i in _context.LookupEtatContrat
                         orderby i.CodeEtatContrat
                         select new
                         {
                             Value = i.CodeEtatContrat,
                             Text = i. DesignationEtatContrat
                         };
            return Json(await DataSourceLoader.LoadAsync(lookup, loadOptions));
        }
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

    }
}