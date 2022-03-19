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
namespace DevKbfSteel.Controllers
{
    [Route("api/[controller]/[action]")]

    public class ApproFournituresArticlesController : Controller
    {
        private KBFsteelContext _context;
        public ApproFournituresArticlesController(KBFsteelContext context) {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> Get(int id, DataSourceLoadOptions loadOptions) {
            var approFournituresArticles = _context.ApproFournituresArticles
                .Where(c => c.NumeroDemandeFourniture == id)
                .Select(i => new {
                    i.Id,
                    i.CodeArticle,
                    i.CodeUniteMesure,
                    i.QteDemande
                });
            // If you work with a large amount of data, consider specifying the PaginateViaPrimaryKey and PrimaryKey properties.
            // In this case, keys and data are loaded in separate queries. This can make the SQL execution plan more efficient.
            // Refer to the topic https://github.com/DevExpress/DevExtreme.AspNet.Data/issues/336.
            // loadOptions.PrimaryKey = new[] { "NumBon" };
            // loadOptions.PaginateViaPrimaryKey = true;
            return Json(await DataSourceLoader.LoadAsync(approFournituresArticles, loadOptions));
        }
        [HttpGet]
        public async Task<IActionResult> GetPdr(int id, DataSourceLoadOptions loadOptions)
        {
            var approFournituresArticles = _context.StkPdr
                .Select(i => new {
                    i.CodePdr,
                    i.DesignationPdr,
                    i.CodeUniteMesurePdr
                });
            // If you work with a large amount of data, consider specifying the PaginateViaPrimaryKey and PrimaryKey properties.
            // In this case, keys and data are loaded in separate queries. This can make the SQL execution plan more efficient.
            // Refer to the topic https://github.com/DevExpress/DevExtreme.AspNet.Data/issues/336.
            // loadOptions.PrimaryKey = new[] { "NumBon" };
            // loadOptions.PaginateViaPrimaryKey = true;
            return Json(await DataSourceLoader.LoadAsync(approFournituresArticles, loadOptions));
        }
        [HttpPost]
        public async Task<IActionResult> Post(string values) {
            var model = new ApproFournituresArticles();
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModel(model, valuesDict);
            var ordres = _context.ApproFournituresArticles
                .OrderBy(o => o.Id)
                .Select(i => new
                {
                    i.Id
                }).ToList();
                if (ordres.Count == 0)
                    model.Id = 1;
                else
                {
                    var m = ordres.Last();
                    model.Id = Convert.ToInt32(m.Id) + 1;
                }
            if (!TryValidateModel(model))
                return BadRequest(GetFullErrorMessage(ModelState));
            var result = _context.ApproFournituresArticles.Add(model);
            await _context.SaveChangesAsync();
            return Json(result.Entity.Id);
        }
        [HttpPut]
        public async Task<IActionResult> Put(int key, string values) {
            var model = await _context.ApproFournituresArticles.FirstOrDefaultAsync(item => item.Id == key);
            if(model == null)
                return StatusCode(409, "Object not found");
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModel(model, valuesDict);
            if (!TryValidateModel(model))
                return BadRequest(GetFullErrorMessage(ModelState));

            await _context.SaveChangesAsync();
            return Ok();
        }
        [HttpDelete]
        public async Task Delete(int key) {
            var model = await _context.ApproFournituresArticles.FirstOrDefaultAsync(item => item.Id == key);
            _context.ApproFournituresArticles.Remove(model);
            await _context.SaveChangesAsync();
        }
        [HttpGet]
        public async Task<IActionResult> DesignationArticleLookup(DataSourceLoadOptions loadOptions) {
            var lookup = from i in _context.ApproNatureDemandeFourniture
                         orderby i.CodeNatureDemande
                         select new {
                             Value = i.CodeNatureDemande,
                             Text = i.DesignationNatureDemande
                         };
            return Json(await DataSourceLoader.LoadAsync(lookup, loadOptions));
        }
        [HttpGet]
        public async Task<IActionResult> QteStockLookup(DataSourceLoadOptions loadOptions)
        {
            var lookup = from i in _context.RhListeDesEmployes
                         orderby i.Id
                         select new
                         {
                             Value = i.Id,
                             Text = i.TelProfesionnel
                         };
            return Json(await DataSourceLoader.LoadAsync(lookup, loadOptions));
        }
        private void PopulateModel(ApproFournituresArticles model, IDictionary values) {

            string Id = nameof(ApproFournituresArticles.Id);
            string NumeroDemandeFourniture = nameof(ApproFournituresArticles.NumeroDemandeFourniture);
            string CodeArticle = nameof(ApproFournituresArticles.CodeArticle);
            string QteDemande = nameof(ApproFournituresArticles.QteDemande);

            if (values.Contains(Id))
            {
                model.Id = Convert.ToInt32(values[Id]);
            }
            if (values.Contains(NumeroDemandeFourniture))
            {
                model.NumeroDemandeFourniture = Convert.ToInt32(values[NumeroDemandeFourniture]);
            }
            if (values.Contains(CodeArticle))
            {
                model.CodeArticle = Convert.ToInt32(values[CodeArticle]);
            }
            if (values.Contains(QteDemande))
            {
                model.QteDemande = Convert.ToInt32(values[QteDemande]);
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
    }
}