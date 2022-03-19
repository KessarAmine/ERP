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
    public class TempAssOtIntervenantsController : Controller
    {
        private KBFsteelContext _context;
        public TempAssOtIntervenantsController(KBFsteelContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> Get(DataSourceLoadOptions loadOptions)
        {
            var bonproduction = _context.TempAssOtIntervenants
                .Select(i => new {
                    i.Id,
                    i.CodeEquipement,
                    i.CodeMachine,
                    i.CodeIntervenant,
                    i.DureeInervention
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
            var model = new TempAssOtIntervenants();
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModel(model, valuesDict);
            var ordres = _context.TempAssOtIntervenants
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
            var result = _context.TempAssOtIntervenants.Add(model);
            await _context.SaveChangesAsync();
            return Json(result.Entity.Id);
        }
        [HttpPut]
        public async Task<IActionResult> Put(int key, string values)
        {
            var model = await _context.TempAssOtIntervenants.FirstOrDefaultAsync(item => item.Id == key);
            if (model == null)
                return StatusCode(409, "Object not found");

            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModel(model, valuesDict);
            await _context.SaveChangesAsync();
            return Ok();
        }
        [HttpDelete]
        public async Task Delete(int key)
        {
            var model = await _context.TempAssOtIntervenants.FirstOrDefaultAsync(item => item.Id == key);
            _context.TempAssOtIntervenants.Remove(model);
            await _context.SaveChangesAsync();
        }
        public async static Task PostToAssOtConsommable(KBFsteelContext context, AssOtConsommable model)
        {
            var ordres = context.AssOtConsommable
                .AsNoTracking()
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

            var result = context.AssOtConsommable.Add(model);
            await context.SaveChangesAsync();
        }
        public async static Task PostToAssOtPdr(KBFsteelContext context, AssOtPdr model)
        {
            var ordres = context.AssOtPdr
                .AsNoTracking()
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

            var result = context.AssOtPdr.Add(model);
            await context.SaveChangesAsync();
        }
        public async static Task PostToAssOtIntervenants(KBFsteelContext context, AssOtIntervenants model)
        {
            var ordres = context.AssOtIntervenants
                .AsNoTracking()
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
            var dateInter = context.RapportIntervention
            .AsNoTracking()
            .Where(c => c.NumIntervention == model.NumIntervention)
            .Select(i => new
            {
                i.DateIntervention,
                i.DureeIntervention
            }).FirstOrDefault();
            model.DateIntervention = dateInter.DateIntervention;
            model.DureeInervention = dateInter.DureeIntervention;
            var result = context.AssOtIntervenants.Add(model);
            await context.SaveChangesAsync();
        }
        private void PopulateModel(TempAssOtIntervenants model, IDictionary values)
        {
            string Id = nameof(TempAssOtIntervenants.Id);
            string CodeEquipement = nameof(TempAssOtIntervenants.CodeEquipement);
            string CodeMachine = nameof(TempAssOtIntervenants.CodeMachine);
            string DureeInervention = nameof(TempAssOtIntervenants.DureeInervention);
            string CodeIntervenant = nameof(TempAssOtIntervenants.CodeIntervenant);
            var Idemployevar = values[CodeIntervenant];
            var Idemployestrings = Idemployevar.ToString();
            var SplitThefirst = Idemployestrings.Split("[");
            var SplitThesecond = SplitThefirst[1].Split("]");
            var value = SplitThesecond[0];
            if (values.Contains(CodeIntervenant))
            {
                model.CodeIntervenant = Convert.ToInt32(value);
            }
            if (values.Contains(Id))
            {
                model.Id = Convert.ToInt32(values[Id]);
            }
            if (values.Contains(CodeEquipement))
            {
                var CodePdrvar = values[CodeEquipement];
                var IdemployestringsS = CodePdrvar.ToString();
                var SplitThefirstS = IdemployestringsS.Split("[");
                var SplitThesecondS = SplitThefirstS[1].Split("]");
                var CodePdrSplited = SplitThesecondS[0];
                model.CodeEquipement = Convert.ToInt32(CodePdrSplited.Trim());
            }
            if (values.Contains(CodeMachine))
            {
                model.CodeMachine = Convert.ToInt32(values[CodeMachine]);
            }
            if (values.Contains(DureeInervention))
            {
                model.DureeInervention = Convert.ToDouble(values[DureeInervention]);
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
    }
    
}
