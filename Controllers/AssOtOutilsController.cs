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

    public class AssOtOutilsController : Controller
    {
        private KBFsteelContext _context;
        public AssOtOutilsController(KBFsteelContext context) {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> Get(int id, DataSourceLoadOptions loadOptions)
        {
            XpertHelper.NumOtOutils = id;
            var bonproduction = _context.AssOtOutils
                .Where(c => c.NumOt == id)
                .Select(i => new {
                    i.Id,
                    i.CodeOutils
                });
            // If you work with a large amount of data, consider specifying the PaginateViaPrimaryKey and PrimaryKey properties.
            // In this case, keys and data are loaded in separate queries. This can make the SQL execution plan more efficient.
            // Refer to the topic https://github.com/DevExpress/DevExtreme.AspNet.Data/issues/336.
            // loadOptions.PrimaryKey = new[] { "NumBon" };
            // loadOptions.PaginateViaPrimaryKey = true;
            return Json(await DataSourceLoader.LoadAsync(bonproduction, loadOptions));
        }
        [HttpPost]
        public async Task<IActionResult> Post(string values)
        {
            var model = new AssOtOutils();
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModel(model, valuesDict);
            model.NumOt = (int)XpertHelper.NumOtOutils;
            var ordres = _context.AssOtOutils
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

            var result = _context.AssOtOutils.Add(model);
            await _context.SaveChangesAsync();

            return Json(result.Entity.Id);
        }
        [HttpPut]
        public async Task<IActionResult> Put(int key, string values)
        {
            var model = await _context.AssOtOutils.FirstOrDefaultAsync(item => item.Id == key);
            if (model == null)
                return StatusCode(409, "Object not found");

            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModel(model, valuesDict);
            if (!TryValidateModel(model))
                return BadRequest(GetFullErrorMessage(ModelState));

            await _context.SaveChangesAsync();
            return Ok();
        }
        [HttpDelete]
        public async Task Delete(int key)
        {
            var model = await _context.AssOtOutils.FirstOrDefaultAsync(item => item.Id == key);
            _context.AssOtOutils.Remove(model);
            await _context.SaveChangesAsync();
        }
        [HttpGet]
        public async Task<IActionResult> OutilsLookup(DataSourceLoadOptions loadOptions)
        {
            var lookup = from i in _context.StkPdr
                         orderby i.CodePdr
                         select new
                         {
                             Value = i.CodePdr,
                             Text = i.DesignationPdr
                         };
            return Json(await DataSourceLoader.LoadAsync(lookup, loadOptions));
        }
        private void PopulateModel(AssOtOutils model, IDictionary values)
        {
            string NumOt = nameof(AssOtOutils.NumOt);
            string CodeOutils = nameof(AssOtOutils.CodeOutils);
            string Id = nameof(AssOtOutils.Id);
            if (values.Contains(Id))
            {
                model.Id = Convert.ToInt32(values[Id]);
            }
            if (values.Contains(NumOt))
            {
                model.NumOt = Convert.ToInt32(values[NumOt]);
            }
            if (values.Contains(CodeOutils))
            {
                model.CodeOutils = Convert.ToInt32(values[CodeOutils]);
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