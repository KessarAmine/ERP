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
    public class RhPostesController : Controller
    {
        private KBFsteelContext _context;
        public RhPostesController(KBFsteelContext context) {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> Get(DataSourceLoadOptions loadOptions) {
            var rhContratsEmployes = _context.GrhPostes.Select(i => new {
                i.CodeDepartement,
                i.CodePoste,
                i.EffectifRequis,
                i.Intitule,
                i.IntituleArabe,
                i.SalaireBase
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
            var model = new GrhPostes();
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModel(model, valuesDict);
            var result = _context.GrhPostes.Add(model);
            await _context.SaveChangesAsync();
            return Json(result.Entity.CodePoste);
        }
        [HttpPut]
        public async Task<IActionResult> Put(int key, string values) {
            var model = await _context.GrhPostes.FirstOrDefaultAsync(item => item.CodePoste == key);
            if(model == null)
                return StatusCode(409, "Object not found");
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModel(model, valuesDict);
            await _context.SaveChangesAsync();
            return Ok();
        }
        [HttpDelete]
        public async Task Delete(int key) {
            var model = await _context.GrhPostes.FirstOrDefaultAsync(item => item.CodePoste == key);
            _context.GrhPostes.Remove(model);
            await _context.SaveChangesAsync();
        }
        private void PopulateModel(GrhPostes model, IDictionary values) {
            string CodeDepartement = nameof(GrhPostes.CodeDepartement);
            string EffectifRequis = nameof(GrhPostes.EffectifRequis);
            string Intitule = nameof(GrhPostes.Intitule);
            string IntituleArabe = nameof(GrhPostes.IntituleArabe);
            string SalaireBase = nameof(GrhPostes.SalaireBase);
            if (values.Contains(CodeDepartement))
            {
                model.CodeDepartement = Convert.ToInt32(CodeDepartement);
            }
            if (values.Contains(EffectifRequis))
            {
                model.EffectifRequis = Convert.ToInt32(values[EffectifRequis]);
            }
            if (values.Contains(Intitule))
            {
                model.Intitule = Convert.ToString(values[Intitule]);
            }
            if (values.Contains(IntituleArabe))
            {
                model.IntituleArabe = Convert.ToString(values[IntituleArabe]);
            }
            if (values.Contains(SalaireBase))
            {
                model.SalaireBase = Convert.ToDouble(values[SalaireBase]);
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
        public async Task<IActionResult> DepartementLookup(DataSourceLoadOptions loadOptions)
        {
            var lookup = from i in _context.Structure
                         orderby i.CodeStructure
                         select new
                         {
                             Value = i.CodeStructure,
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