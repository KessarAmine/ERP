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
    public class TempAssOtTravauxController : Controller
    {
        private KBFsteelContext _context;
        public TempAssOtTravauxController(KBFsteelContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> Get(DataSourceLoadOptions loadOptions)
        {
            var bonproduction = _context.TempAssOtTravaux
                .Select(i => new {
                    i.Id,
                    i.CodeEquipement,
                    i.CodeMachine,
                    i.Qte,
                    i.TypeTraveaux,
                    i.Autres
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
            var model = new TempAssOtTravaux();
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModel(model, valuesDict);
            var ordres = _context.TempAssOtTravaux
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
            if (model.TypeTraveaux.Equals(null))
                model.TypeTraveaux = 0;
            var result = _context.TempAssOtTravaux.Add(model);
            await _context.SaveChangesAsync();
            return Json(result.Entity.Id);
        }
        [HttpPut]
        public async Task<IActionResult> Put(int key, string values)
        {
            var model = await _context.TempAssOtTravaux.FirstOrDefaultAsync(item => item.Id == key);
            if (model == null)
                return StatusCode(409, "Object not found");

            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModel(model, valuesDict);
            if (model.TypeTraveaux.Equals(null))
                model.TypeTraveaux = 0;
            await _context.SaveChangesAsync();
            return Ok();
        }
        [HttpDelete]
        public async Task Delete(int key)
        {
            var model = await _context.TempAssOtTravaux.FirstOrDefaultAsync(item => item.Id == key);
            //TODO : Get Last Plannification of that Op
            _context.TempAssOtTravaux.Remove(model);
            await _context.SaveChangesAsync();
        }
        public async static Task PostToAssOtTravaux(KBFsteelContext context, AssOtTraveaux model)
        {
            var ordres = context.AssOtTraveaux
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
            if (model.TypeTraveaux == null)
                model.TypeTraveaux = 0;

            var result = context.AssOtTraveaux.Add(model);
            context.SaveChanges();
            var ordre = context.OrdreTravail.AsNoTracking().Where(o => o.NumOt == model.NumOt).FirstOrDefault();
            //checking this with Plannification des operations
            if(model.CodeEquipement!="")
                XpertHelper.NumEquipement = Convert.ToInt32(model.CodeEquipement);
            if (model.CodeMachine != null)
                XpertHelper.CodeMachine = Convert.ToInt32(model.CodeMachine);
            XpertHelper.NumOt = Convert.ToInt32(model.NumOt);
            //
            RapportIntervention rapport = new RapportIntervention();
            rapport.NumOt = model.NumOt;
            rapport.DateIntervention = ordre.DateOt;
            XpertHelper.DateIntervention = ordre.DateOt;
            await XpertHelper.CheckOtOperationFromRapportInterventions(context, rapport);
        }
        private void PopulateModel(TempAssOtTravaux model, IDictionary values)
        {

            string Id = nameof(TempAssOtTravaux.Id);
            string CodeEquipement = nameof(TempAssOtTravaux.CodeEquipement);
            string CodeMachine = nameof(TempAssOtTravaux.CodeMachine);
            string TypeTraveaux = nameof(TempAssOtTravaux.TypeTraveaux);
            string Qte = nameof(TempAssOtTravaux.Qte);
            string Autres = nameof(TempAssOtTravaux.Autres);

            if (values.Contains(Id))
            {
                model.Id = Convert.ToInt32(values[Id]);
            }
            if (values.Contains(CodeEquipement))
            {
                var CodePdrvar = values[CodeEquipement];
                var Idemployestrings = CodePdrvar.ToString();
                var SplitThefirst = Idemployestrings.Split("[");
                var SplitThesecond = SplitThefirst[1].Split("]");
                var CodePdrSplited = SplitThesecond[0];
                model.CodeEquipement = Convert.ToInt32(CodePdrSplited);
            }
            if (values.Contains(CodeMachine))
            {
                model.CodeMachine = Convert.ToInt32(values[CodeMachine]);
            }
            if (values.Contains(TypeTraveaux))
            {
                model.TypeTraveaux = Convert.ToInt32(values[TypeTraveaux]);
            }
            if (values.Contains(Qte))
            {
                model.Qte = Convert.ToInt32(values[Qte]);
            }
            if (values.Contains(Autres))
            {
                model.Autres = Convert.ToString(values[Autres]);
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
