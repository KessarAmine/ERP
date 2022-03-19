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
using DevKbfSteel.Models;
namespace DevKbfSteel.Controllers
{
    [Route("api/[controller]/[action]")]

    public class AssOtConsommableController : Controller
    {
        private KBFsteelContext _context;
        public AssOtConsommableController(KBFsteelContext context) {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> Get(int id, DataSourceLoadOptions loadOptions) {
            XpertHelper.NumIntervention = id;
            var bonproduction = _context.AssOtConsommable
                .Where(c => c.NumIntervention == id)
                .Select(i => new {
                    i.Id,
                    i.CodeConsommable,
                    i.Qte,
                    i.PrixUnitaire,
                    i.Montant
            });
            // If you work with a large amount of data, consider specifying the PaginateViaPrimaryKey and PrimaryKey properties.
            // In this case, keys and data are loaded in separate queries. This can make the SQL execution plan more efficient.
            // Refer to the topic https://github.com/DevExpress/DevExtreme.AspNet.Data/issues/336.
            // loadOptions.PrimaryKey = new[] { "NumBon" };
            // loadOptions.PaginateViaPrimaryKey = true;
            return Json(await DataSourceLoader.LoadAsync(bonproduction, loadOptions));
        }
        [HttpPost]
        public async Task<IActionResult> Post(string values) {
            var model = new AssOtConsommable();
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModel(model, valuesDict);
            var ordres = _context.AssOtConsommable
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
            model.NumIntervention = (int)XpertHelper.NumIntervention;
            var Movements = _context.StkMovements.AsNoTracking()
              .Where(o => o.CodePdr == model.CodeConsommable)
              .Select(i => new
              {
                  i.ValeurValorisation
              }).ToList();
            var LastMovements = Movements.Last();
            if (!LastMovements.ValeurValorisation.Equals(null))
            {
                model.PrixUnitaire = (double)LastMovements.ValeurValorisation;
                model.Montant = model.PrixUnitaire * model.Qte;
            }
            else
            {
                var PrixUnitaire = _context.StkStockInitial.AsNoTracking()
                .Where(o => o.CodePdr == model.CodeConsommable)
                .Select(i => new
                {
                    i.PrixUnitare
                }).ToList();
                var LastPrixUnitaire = PrixUnitaire.Last();
                if (!LastPrixUnitaire.PrixUnitare.Equals(null))
                {
                    model.PrixUnitaire = LastPrixUnitaire.PrixUnitare;
                    model.Montant = LastPrixUnitaire.PrixUnitare * model.Qte;
                }
                else
                {
                    model.PrixUnitaire = 0;
                    model.Montant = 0;
                }
            }
            var result = _context.AssOtConsommable.Add(model);
            await _context.SaveChangesAsync();
            //Check this Rapoort its Ots if it an operation = Get its Id = go to suivi et planning 
            return Json(result.Entity.Id);
        }
        [HttpPut]
        public async Task<IActionResult> Put(int key, string values) {
            var model = await _context.AssOtConsommable.FirstOrDefaultAsync(item => item.Id == key);
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
            var model = await _context.AssOtConsommable.FirstOrDefaultAsync(item => item.Id == key);
            _context.AssOtConsommable.Remove(model);
            await _context.SaveChangesAsync();
        }
        [HttpGet]
        public async Task<IActionResult> StkPdrLookup(DataSourceLoadOptions loadOptions)
        {
            var lookup = from i in _context.StkPdr
                         where i.TypeArticle == 3
                         select new
                         {
                             Value = i.CodePdr,
                             Text = i.DesignationPdr
                         };
            return Json(await DataSourceLoader.LoadAsync(lookup, loadOptions));
        }
        private void PopulateModel(AssOtConsommable model, IDictionary values) {
            string CodeConsommable = nameof(AssOtConsommable.CodeConsommable);
            string Qte = nameof(AssOtConsommable.Qte);
            if (values.Contains(CodeConsommable))
            {
                model.CodeConsommable = Convert.ToInt32(values[CodeConsommable]);
            }
            if (values.Contains(Qte))
            {
                model.Qte = Convert.ToDouble(values[Qte]);
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