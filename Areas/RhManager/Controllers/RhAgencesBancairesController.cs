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
    public class RhAgencesBancairesController : Controller
    {
        private KBFsteelContext _context;
        public RhAgencesBancairesController(KBFsteelContext context) {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> Get(DataSourceLoadOptions loadOptions) {
            var rhContratsEmployes = _context.GrhAgencesBancaire.Select(i => new {
                i.Id,
                i.Localisation,
                i.NatureAgence,
                i.NomAgence,
                i.RibEntreprise
            });
            return Json(await DataSourceLoader.LoadAsync(rhContratsEmployes, loadOptions));
        }
        [HttpPost]
        public async Task<IActionResult> Post(string values) {
            var model = new GrhAgencesBancaire();
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModel(model, valuesDict);
            var result = _context.GrhAgencesBancaire.Add(model);
            await _context.SaveChangesAsync();
            return Json(result.Entity.Id);
        }
        [HttpPut]
        public async Task<IActionResult> Put(int key, string values) {
            var model = await _context.GrhAgencesBancaire.FirstOrDefaultAsync(item => item.Id == key);
            if(model == null)
                return StatusCode(409, "Object not found");
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModel(model, valuesDict);
            await _context.SaveChangesAsync();
            return Ok();
        }
        [HttpDelete]
        public async Task Delete(int key) {
            var model = await _context.GrhAgencesBancaire.FirstOrDefaultAsync(item => item.Id == key);
            _context.GrhAgencesBancaire.Remove(model);
            await _context.SaveChangesAsync();
        }
        private void PopulateModel(GrhAgencesBancaire model, IDictionary values) {
            string Localisation = nameof(GrhAgencesBancaire.Localisation);
            string NatureAgence = nameof(GrhAgencesBancaire.NatureAgence);
            string NomAgence = nameof(GrhAgencesBancaire.NomAgence);
            string RibEntreprise = nameof(GrhAgencesBancaire.RibEntreprise);
            if (values.Contains(Localisation))
            {
                model.Localisation = Convert.ToString(Localisation);
            }
            if (values.Contains(NatureAgence))
            {
                model.NatureAgence = Convert.ToInt32(values[NatureAgence]);
            }
            if (values.Contains(NomAgence))
            {
                model.NomAgence = Convert.ToString(values[NomAgence]);
            }
            if (values.Contains(RibEntreprise))
            {
                model.RibEntreprise = Convert.ToInt32(values[RibEntreprise]);
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
        public async Task<IActionResult> NatureAgenceLookup(DataSourceLoadOptions loadOptions)
        {
            var lookup = from i in _context.GrhLookupNatureAgenceBnacaire
                         orderby i.Id
                         select new
                         {
                             Value = i.Id,
                             Text = i.Designation
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

            var resultorderbyelement = from i in _context.RhListeDesEmployes
                                       group i by i.Departement
                                       into egroup
                                       orderby egroup.Key
                                       select new
                                       {
                                           Key = egroup.Key,
                                           studentobj = egroup.OrderBy(g => g.Nom)
                                       };
            return Json(await DataSourceLoader.LoadAsync(lookup, loadOptions));
        }

    }
}