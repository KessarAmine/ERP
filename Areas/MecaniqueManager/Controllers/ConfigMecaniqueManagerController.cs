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

namespace DevKbfSteel.Areas.RhManager.Controllers
{
    [Area(nameof(Areas.MecaniqueManager))]

    public class ConfigMecaniqueManagerController : Controller
    {
        private KBFsteelContext _context;
        public ConfigMecaniqueManagerController(KBFsteelContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> Get(DataSourceLoadOptions loadOptions)
        {
            var rhContratsEmployes = _context.ConfigMecanique.Select(i => new {
                i.Id,
                i.LimiteDemandeFourniture
            });
            // If you work with a large amount of data, consider specifying the PaginateViaPrimaryKey and PrimaryKey properties.
            // In this case, keys and data are loaded in separate queries. This can make the SQL execution plan more efficient.
            // Refer to the topic https://github.com/DevExpress/DevExtreme.AspNet.Data/issues/336.
            // loadOptions.PrimaryKey = new[] { "NumEquipement" };
            // loadOptions.PaginateViaPrimaryKey = true;

            return Json(await DataSourceLoader.LoadAsync(rhContratsEmployes, loadOptions));
        }
        [HttpPost]
        public async Task<IActionResult> Post(string values)
        {
            var model = new ConfigMecanique();
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModel(model, valuesDict);
            var lastRhContratsEmployes = _context.ConfigMecanique
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
                model.Id = m.Id + 1;
            }
            var result = _context.ConfigMecanique.Add(model);
            await _context.SaveChangesAsync();
            return Json(result.Entity.Id);
        }
        [HttpPut]
        public async Task<IActionResult> Put(int key, string values)
        {
            var model = await _context.ConfigMecanique.FirstOrDefaultAsync(item => item.Id == key);
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModel(model, valuesDict);
            _context.ConfigMecanique.Update(model);
            await _context.SaveChangesAsync();
            return Ok();
        }
        [HttpDelete]
        public async Task Delete(int key)
        {
            var model = await _context.ConfigMecanique.FirstOrDefaultAsync(item => item.Id == key);
            _context.ConfigMecanique.Remove(model);
            await _context.SaveChangesAsync();
        }
        private void PopulateModel(ConfigMecanique model, IDictionary values)
        {
            string LimiteDemandeFourniture = nameof(ConfigMecanique.LimiteDemandeFourniture);

            if (values.Contains(LimiteDemandeFourniture))
            {
                model.LimiteDemandeFourniture = Convert.ToInt32(values[LimiteDemandeFourniture]);
            }
        }

    }
}
