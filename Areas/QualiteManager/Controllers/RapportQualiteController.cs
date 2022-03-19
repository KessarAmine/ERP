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
    [Area(nameof(Areas.QualiteManager))]
    public class RapportQualiteController : Controller
    {
        private KBFsteelContext _context;
        public RapportQualiteController(KBFsteelContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> Get(DateTime dateDebut, DateTime dateFin, DataSourceLoadOptions loadOptions)
        {
            var QualiteRapports = _context.QualiteRapports.AsNoTracking().Where(c => c.Date.Date >= dateDebut.Date && c.Date.Date <= dateFin.Date)
                .Select(i => new {
                    i.Controleur,
                    i.Date,
                    i.Id,
                    i.Profile
                });
            // If you work with a large amount of data, consider specifying the PaginateViaPrimaryKey and PrimaryKey properties.
            // In this case, keys and data are loaded in separate queries. This can make the SQL execution plan more efficient.
            // Refer to the topic https://github.com/DevExpress/DevExtreme.AspNet.Data/issues/336.
            // loadOptions.PrimaryKey = new[] { "NumEquipement" };
            // loadOptions.PaginateViaPrimaryKey = true;
            return Json(await DataSourceLoader.LoadAsync(QualiteRapports, loadOptions));
        }
        [HttpGet]
        public async Task<IActionResult> GetDetails(int id, DataSourceLoadOptions loadOptions)
        {
            XpertHelper.QualiteRapports = id;
            var QualiteRapportsDetails = _context.QualiteRapportsDetails.AsNoTracking().Where(c => c.NumRapport == id)
                .Select(i => new {
                    i.Fardeau1,
                    i.Id,
                    i.Fardeau2,
                    i.Fardeau3,
                    i.FardeauExpedie1,
                    i.FardeauExpedie2,
                    i.FardeauExpedie3,
                    i.FardeauRecupere1,
                    i.FardeauRecupere2,
                    i.FardeauRecupere3,
                    i.FardeauStockReel,
                    i.FardeauStockTheorique,
                    i.Jour,
                    i.NumRapport,
                    i.Rebut1,
                    i.Rebut2,
                    i.Rebut3
                });
            // If you work with a large amount of data, consider specifying the PaginateViaPrimaryKey and PrimaryKey properties.
            // In this case, keys and data are loaded in separate queries. This can make the SQL execution plan more efficient.
            // Refer to the topic https://github.com/DevExpress/DevExtreme.AspNet.Data/issues/336.
            // loadOptions.PrimaryKey = new[] { "NumEquipement" };
            // loadOptions.PaginateViaPrimaryKey = true;
            return Json(await DataSourceLoader.LoadAsync(QualiteRapportsDetails, loadOptions));
        }
        [HttpPost]
        public async Task<IActionResult> Post(string values)
        {
            var model = new QualiteRapports();
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModel(model, valuesDict);
            var result = _context.QualiteRapports.Add(model);
            await _context.SaveChangesAsync();
            return Json(result.Entity.Id);
        }
        [HttpPost]
        public async Task<IActionResult> PostDetails(string values)
        {
            var model = new QualiteRapportsDetails();
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModelDetails(model, valuesDict);
            model.NumRapport = XpertHelper.QualiteRapports;
            var result = _context.QualiteRapportsDetails.Add(model);
            await _context.SaveChangesAsync();
            return Json(result.Entity.Id);
        }
        [HttpPut]
        public async Task<IActionResult> Put(int key, string values)
        {
            var model = await _context.QualiteRapports.FirstOrDefaultAsync(item => item.Id == key);
            if (model == null)
                return StatusCode(409, "Object not found");

            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModel(model, valuesDict);

            await _context.SaveChangesAsync();
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> PutDetails(int key, string values)
        {
            var model = await _context.QualiteRapportsDetails.FirstOrDefaultAsync(item => item.Id == key);
            if (model == null)
                return StatusCode(409, "Object not found");

            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModelDetails(model, valuesDict);

            await _context.SaveChangesAsync();
            return Ok();
        }
        [HttpDelete]
        public async Task Delete(int key)
        {
            var model = await _context.QualiteRapports.FirstOrDefaultAsync(item => item.Id == key);

            _context.QualiteRapports.Remove(model);
            await _context.SaveChangesAsync();
        }
        [HttpDelete]
        public async Task DeleteDetails(int key)
        {
            var model = await _context.QualiteRapportsDetails.FirstOrDefaultAsync(item => item.Id == key);

            _context.QualiteRapportsDetails.Remove(model);
            await _context.SaveChangesAsync();
        }
        private void PopulateModel(QualiteRapports model, IDictionary values)
        {
            string Controleur = nameof(QualiteRapports.Controleur);
            string Date = nameof(QualiteRapports.Date);
            string Profile = nameof(QualiteRapports.Profile);
            string Id = nameof(QualiteRapports.Id);

            if (values.Contains(Date))
            {
                model.Date = Convert.ToDateTime(values[Date]);
            }
            if (values.Contains(Id))
            {
                model.Id = Convert.ToInt32(values[Id]);
            }
            if (values.Contains(Controleur))
            {
                model.Controleur = Convert.ToInt32(values[Controleur]);
            }
            if (values.Contains(Profile))
            {
                model.Profile = Convert.ToString(values[Profile]);
            }
        }
        private void PopulateModelDetails(QualiteRapportsDetails model, IDictionary values)
        {
            string Fardeau1 = nameof(QualiteRapportsDetails.Fardeau1);
            string Fardeau2 = nameof(QualiteRapportsDetails.Fardeau2);
            string Fardeau3 = nameof(QualiteRapportsDetails.Fardeau3);
            string FardeauExpedie1 = nameof(QualiteRapportsDetails.FardeauExpedie1);
            string FardeauExpedie2 = nameof(QualiteRapportsDetails.FardeauExpedie2);
            string FardeauExpedie3 = nameof(QualiteRapportsDetails.FardeauExpedie3);
            string FardeauRecupere1 = nameof(QualiteRapportsDetails.FardeauRecupere1);
            string FardeauRecupere2 = nameof(QualiteRapportsDetails.FardeauRecupere2);
            string FardeauRecupere3 = nameof(QualiteRapportsDetails.FardeauRecupere3);
            string FardeauStockReel = nameof(QualiteRapportsDetails.FardeauStockReel);
            string FardeauStockTheorique = nameof(QualiteRapportsDetails.FardeauStockTheorique);
            string Jour = nameof(QualiteRapportsDetails.Jour);
            string Rebut1 = nameof(QualiteRapportsDetails.Rebut1);
            string Rebut2 = nameof(QualiteRapportsDetails.Rebut2);
            string Rebut3 = nameof(QualiteRapportsDetails.Rebut3);
            if (values.Contains(Fardeau1))
            {
                model.Fardeau1 = Convert.ToInt32(values[Fardeau1]);
            }
            if (values.Contains(Fardeau2))
            {
                model.Fardeau2 = Convert.ToInt32(values[Fardeau2]);
            }
            if (values.Contains(Fardeau3))
            {
                model.Fardeau3 = Convert.ToInt32(values[Fardeau3]);
            }
            if (values.Contains(FardeauExpedie1))
            {
                model.FardeauExpedie1 = Convert.ToInt32(values[FardeauExpedie1]);
            }
            if (values.Contains(FardeauExpedie2))
            {
                model.FardeauExpedie2 = Convert.ToInt32(values[FardeauExpedie2]);
            }
            if (values.Contains(FardeauExpedie3))
            {
                model.FardeauExpedie3 = Convert.ToInt32(values[FardeauExpedie3]);
            }
            if (values.Contains(FardeauRecupere1))
            {
                model.FardeauRecupere1 = Convert.ToInt32(values[FardeauRecupere1]);
            }
            if (values.Contains(FardeauRecupere2))
            {
                model.FardeauRecupere2 = Convert.ToInt32(values[FardeauRecupere2]);
            }
            if (values.Contains(FardeauRecupere3))
            {
                model.FardeauRecupere3 = Convert.ToInt32(values[FardeauRecupere3]);
            }
            if (values.Contains(FardeauStockReel))
            {
                model.FardeauStockReel = Convert.ToInt32(values[FardeauStockReel]);
            }
            if (values.Contains(FardeauStockTheorique))
            {
                model.FardeauStockTheorique = Convert.ToInt32(values[FardeauStockTheorique]);
            }
            if (values.Contains(Rebut1))
            {
                model.Rebut1 = Convert.ToInt32(values[Rebut1]);
            }
            if (values.Contains(Rebut2))
            {
                model.Rebut2 = Convert.ToInt32(values[Rebut2]);
            }
            if (values.Contains(Rebut3))
            {
                model.Rebut3 = Convert.ToInt32(values[Rebut3]);
            }
            if (values.Contains(Jour))
            {
                model.Jour = Convert.ToDateTime(values[Jour]);
            }
        }
        private string GetFullErrorMessage(ModelStateDictionary modelState)
        {
            var messages = new List<string>();

            foreach (var entry in modelState)
            {
                foreach (var error in entry.Value.Errors)
                    messages.Add(error.ErrorMessage);
            }

            return String.Join(" ", messages);
        }
        [HttpGet]
        public async Task<IActionResult> SpecieliteLookup(DataSourceLoadOptions loadOptions)
        {
            var lookup = from i in _context.Specialite
                         orderby i.CodeSpecialite
                         select new
                         {
                             Value = i.CodeSpecialite,
                             Text = i.Designation
                         };
            return Json(await DataSourceLoader.LoadAsync(lookup, loadOptions));
        }
    }
}