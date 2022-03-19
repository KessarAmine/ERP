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
    public class BonCessionController : Controller
    {
        private KBFsteelContext _context;
        public BonCessionController(KBFsteelContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> Get(DateTime dateDebut, DateTime dateFin, DataSourceLoadOptions loadOptions)
        {
            var QualiteBonCession = _context.QualiteBonCession.AsNoTracking().Where(c => c.DateBonCession.Date >= dateDebut.Date && c.DateBonCession.Date <= dateFin.Date)
                .Select(i => new {
                    i.DateBonCession,
                    i.DateBonProduction,
                    i.IdResponsableProduction,
                    i.IdResponsableQualite,
                    i.IdResponsableStock,
                    i.NumBonCession,
                    i.NumBonProduction
                });
            // If you work with a large amount of data, consider specifying the PaginateViaPrimaryKey and PrimaryKey properties.
            // In this case, keys and data are loaded in separate queries. This can make the SQL execution plan more efficient.
            // Refer to the topic https://github.com/DevExpress/DevExtreme.AspNet.Data/issues/336.
            // loadOptions.PrimaryKey = new[] { "NumEquipement" };
            // loadOptions.PaginateViaPrimaryKey = true;
            return Json(await DataSourceLoader.LoadAsync(QualiteBonCession, loadOptions));
        }
        [HttpGet]
        public async Task<IActionResult> GetDetails(int id, DataSourceLoadOptions loadOptions)
        {
            XpertHelper.QualiteBonCession = id;
            var QualiteBonCessionDetails = _context.QualiteBonCessionDetails.AsNoTracking().Where(c => c.NumBonCession == id)
                .Select(i => new {
                    i.CodeArticle,
                    i.Id,
                    i.Conforme,
                    i.Defournee,
                    i.DimBillette,
                    i.MoyenneNbrBarreFardeau,
                    i.NumBonCession,
                    i.Poids,
                    i.Realisee,
                    i.Rebuts
                });
            // If you work with a large amount of data, consider specifying the PaginateViaPrimaryKey and PrimaryKey properties.
            // In this case, keys and data are loaded in separate queries. This can make the SQL execution plan more efficient.
            // Refer to the topic https://github.com/DevExpress/DevExtreme.AspNet.Data/issues/336.
            // loadOptions.PrimaryKey = new[] { "NumEquipement" };
            // loadOptions.PaginateViaPrimaryKey = true;
            return Json(await DataSourceLoader.LoadAsync(QualiteBonCessionDetails, loadOptions));
        }
        [HttpPost]
        public async Task<IActionResult> Post(string values)
        {
            var model = new QualiteBonCession();
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModel(model, valuesDict);
            var result = _context.QualiteBonCession.Add(model);
            await _context.SaveChangesAsync();
            return Json(result.Entity.NumBonCession);
        }
        [HttpPost]
        public async Task<IActionResult> PostDetails(string values)
        {
            var model = new QualiteBonCessionDetails();
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModelDetails(model, valuesDict);
            model.NumBonCession = XpertHelper.QualiteBonCession;
            var result = _context.QualiteBonCessionDetails.Add(model);
            await _context.SaveChangesAsync();
            return Json(result.Entity.Id);
        }
        [HttpPut]
        public async Task<IActionResult> Put(int key, string values)
        {
            var model = await _context.QualiteBonCession.FirstOrDefaultAsync(item => item.NumBonCession == key);
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
            var model = await _context.QualiteBonCessionDetails.FirstOrDefaultAsync(item => item.Id == key);
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
            var model = await _context.QualiteBonCession.FirstOrDefaultAsync(item => item.NumBonCession == key);

            _context.QualiteBonCession.Remove(model);
            await _context.SaveChangesAsync();
        }
        [HttpDelete]
        public async Task DeleteDetails(int key)
        {
            var model = await _context.QualiteBonCessionDetails.FirstOrDefaultAsync(item => item.Id == key);

            _context.QualiteBonCessionDetails.Remove(model);
            await _context.SaveChangesAsync();
        }
        private void PopulateModel(QualiteBonCession model, IDictionary values)
        {
            string DateBonCession = nameof(QualiteBonCession.DateBonCession);
            string DateBonProduction = nameof(QualiteBonCession.DateBonProduction);
            string IdResponsableProduction = nameof(QualiteBonCession.IdResponsableProduction);
            string IdResponsableQualite = nameof(QualiteBonCession.IdResponsableQualite);
            string IdResponsableStock = nameof(QualiteBonCession.IdResponsableStock);
            string NumBonProduction = nameof(QualiteBonCession.NumBonProduction);
            string NumBonCession = nameof(QualiteBonCession.NumBonCession);

            if (values.Contains(DateBonCession))
            {
                model.DateBonCession = Convert.ToDateTime(values[DateBonCession]);
            }
            if (values.Contains(DateBonProduction))
            {
                model.DateBonProduction = Convert.ToDateTime(values[DateBonProduction]);
            }
            if (values.Contains(IdResponsableProduction))
            {
                model.IdResponsableProduction = Convert.ToInt32(values[IdResponsableProduction]);
            }
            if (values.Contains(IdResponsableQualite))
            {
                model.IdResponsableQualite = Convert.ToInt32(values[IdResponsableQualite]);
            }
            if (values.Contains(IdResponsableStock))
            {
                model.IdResponsableStock = Convert.ToInt32(values[IdResponsableStock]);
            }
            if (values.Contains(NumBonProduction))
            {
                model.NumBonProduction = Convert.ToInt32(values[NumBonProduction]);
            }
            if (values.Contains(NumBonCession))
            {
                model.NumBonCession = Convert.ToInt32(values[NumBonCession]);
            }
        }
        private void PopulateModelDetails(QualiteBonCessionDetails model, IDictionary values)
        {
            string CodeArticle = nameof(QualiteBonCessionDetails.CodeArticle);
            string Conforme = nameof(QualiteBonCessionDetails.Conforme);
            string Defournee = nameof(QualiteBonCessionDetails.Defournee);
            string DimBillette = nameof(QualiteBonCessionDetails.DimBillette);
            string MoyenneNbrBarreFardeau = nameof(QualiteBonCessionDetails.MoyenneNbrBarreFardeau);
            string Poids = nameof(QualiteBonCessionDetails.Poids);
            string Realisee = nameof(QualiteBonCessionDetails.Realisee);
            string Rebuts = nameof(QualiteBonCessionDetails.Rebuts);
            if (values.Contains(CodeArticle))
            {
                model.CodeArticle = Convert.ToString(values[CodeArticle]);
            }
            if (values.Contains(Conforme))
            {
                model.Conforme = Convert.ToInt32(values[Conforme]);
            }
            if (values.Contains(Defournee))
            {
                model.Defournee = Convert.ToInt32(values[Defournee]);
            }
            if (values.Contains(DimBillette))
            {
                model.DimBillette = Convert.ToInt32(values[DimBillette]);
            }
            if (values.Contains(MoyenneNbrBarreFardeau))
            {
                model.MoyenneNbrBarreFardeau = Convert.ToInt32(values[MoyenneNbrBarreFardeau]);
            }
            if (values.Contains(Poids))
            {
                model.Poids = Convert.ToDouble(values[Poids]);
            }
            if (values.Contains(Realisee))
            {
                model.Realisee = Convert.ToInt32(values[Realisee]);
            }
            if (values.Contains(Rebuts))
            {
                model.Rebuts = Convert.ToInt32(values[Rebuts]);
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
        public async Task<IActionResult> QualitePersonnelLookup(DataSourceLoadOptions loadOptions)
        {
            var lookup = from i in _context.RhListeDesEmployes
                         where i.Departement == 11
                         select new
                         {
                             Value = i.Id,
                             Text = Convert.ToString(string.Format("{0} {1}", i.Nom, i.Prenom))
                         };
            return Json(await DataSourceLoader.LoadAsync(lookup, loadOptions));
        }
        [HttpGet]
        public async Task<IActionResult> MagasinPersonnelLookup(DataSourceLoadOptions loadOptions)
        {
            var lookup = from i in _context.RhListeDesEmployes
                         where i.Departement == 10
                         select new
                         {
                             Value = i.Id,
                             Text = Convert.ToString(string.Format("{0} {1}", i.Nom, i.Prenom))
                         };
            return Json(await DataSourceLoader.LoadAsync(lookup, loadOptions));
        }
        [HttpGet]
        public async Task<IActionResult> ProductionPersonnelLookup(DataSourceLoadOptions loadOptions)
        {
            var lookup = from i in _context.RhListeDesEmployes
                         where i.Departement == 10
                         select new
                         {
                             Value = i.Id,
                             Text = Convert.ToString(string.Format("{0} {1}", i.Nom, i.Prenom))
                         };
            return Json(await DataSourceLoader.LoadAsync(lookup, loadOptions));
        }
        [HttpGet]
        public async Task<IActionResult> ProduiFiniLookup(DataSourceLoadOptions loadOptions)
        {
            var lookup = from i in _context.QualiteProduitsFini
                         select new
                         {
                             Value = i.Id,
                             Text = i.Designation
                         };
            return Json(await DataSourceLoader.LoadAsync(lookup, loadOptions));
        }
    }
}