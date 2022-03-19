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
    [Route("api/[controller]/[action]")]

    public class EquipementsController : Controller
    {
        private KBFsteelContext _context;

        public EquipementsController(KBFsteelContext context) {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetEquipements(DataSourceLoadOptions loadOptions) {
            XpertHelper.GridMachineId++;
            var equipements = _context.Equipements.Select(i => new {
                i.NumEquipement,
                i.Nom,
                i.Designation
            });
            // If you work with a large amount of data, consider specifying the PaginateViaPrimaryKey and PrimaryKey properties.
            // In this case, keys and data are loaded in separate queries. This can make the SQL execution plan more efficient.
            // Refer to the topic https://github.com/DevExpress/DevExtreme.AspNet.Data/issues/336.
            // loadOptions.PrimaryKey = new[] { "NumEquipement" };
            // loadOptions.PaginateViaPrimaryKey = true;

            return Json(await DataSourceLoader.LoadAsync(equipements, loadOptions));
        }
        [HttpGet]
        public async Task<IActionResult> Get(DataSourceLoadOptions loadOptions) {
            XpertHelper.GridMachineId++;
            var equipements = _context.MachineEquioement.Select(i => new {
                i.Id,
                i.NumEquipement,
                i.NumMachine
            });
            // If you work with a large amount of data, consider specifying the PaginateViaPrimaryKey and PrimaryKey properties.
            // In this case, keys and data are loaded in separate queries. This can make the SQL execution plan more efficient.
            // Refer to the topic https://github.com/DevExpress/DevExtreme.AspNet.Data/issues/336.
            // loadOptions.PrimaryKey = new[] { "NumEquipement" };
            // loadOptions.PaginateViaPrimaryKey = true;

            return Json(await DataSourceLoader.LoadAsync(equipements, loadOptions));
        }
        [HttpGet]
        public async Task<IActionResult> GetEqp(DataSourceLoadOptions loadOptions) {
            XpertHelper.GridMachineId++;
            var equipements = _context.MethStructureMachine.Select(i => new {
                i.Id,
                i.Equipement,
                i.CodeInstallation
            });
            // If you work with a large amount of data, consider specifying the PaginateViaPrimaryKey and PrimaryKey properties.
            // In this case, keys and data are loaded in separate queries. This can make the SQL execution plan more efficient.
            // Refer to the topic https://github.com/DevExpress/DevExtreme.AspNet.Data/issues/336.
            // loadOptions.PrimaryKey = new[] { "NumEquipement" };
            // loadOptions.PaginateViaPrimaryKey = true;

            return Json(await DataSourceLoader.LoadAsync(equipements, loadOptions));
        }

        [HttpGet]
        public async Task<IActionResult> GetID(int id, DataSourceLoadOptions loadOptions)
        {
            var equipements = _context.Equipements
            .Where(x => x.NumMachine == id)
            .Select(i => new {
            i.NumEquipement,
            i.Nom,
            i.Designation,
            i.ValeurUnitaire
        });
            // In this case, keys and data are loaded in separate queries. This can make the SQL execution plan more efficient.
            // Refer to the topic https://github.com/DevExpress/DevExtreme.AspNet.Data/issues/336.
            // loadOptions.PrimaryKey = new[] { "NumEquipement" };
            // loadOptions.PaginateViaPrimaryKey = true;

            return Json(await DataSourceLoader.LoadAsync(equipements, loadOptions));
        }

        [HttpPost]
        public async Task<IActionResult> Post(string values) {
            var model = new Equipements();
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModel(model, valuesDict);
            if (!TryValidateModel(model))
                return BadRequest(GetFullErrorMessage(ModelState));
            var equipements = _context.Equipements
                           .OrderBy(o => o.NumEquipement)
                           .Select(i => new
                           {
                               i.NumEquipement
                           }).ToList();
            var m = equipements.Last();
            model.NumEquipement = Convert.ToInt32(m.NumEquipement) + 1;
            var result = _context.Equipements.Add(model);
            await _context.SaveChangesAsync();

            return Json(result.Entity.NumEquipement);
        }

        [HttpPut]
        public async Task<IActionResult> Put(int key, string values) {
            var model = await _context.Equipements.FirstOrDefaultAsync(item => item.NumEquipement == key);
            if(model == null)
                return StatusCode(409, "Object not found");

            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModel(model, valuesDict);

            if(!TryValidateModel(model))
                return BadRequest(GetFullErrorMessage(ModelState));
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete]
        public async Task Delete(int key) {
            var model = await _context.Equipements.FirstOrDefaultAsync(item => item.NumEquipement == key);

            _context.Equipements.Remove(model);
            await _context.SaveChangesAsync();
        }


        private void PopulateModel(Equipements model, IDictionary values) {
            string NUM_EQUIPEMENT = nameof(Equipements.NumEquipement);
            string NOM = nameof(Equipements.Nom);
            string DESIGNATION = nameof(Equipements.Designation);
            string VALEUR_UNITAIRE = nameof(Equipements.ValeurUnitaire);

            if(values.Contains(NUM_EQUIPEMENT)) {
                model.NumEquipement = Convert.ToInt32(values[NUM_EQUIPEMENT]);
            }

            if(values.Contains(NOM)) {
                model.Nom = Convert.ToString(values[NOM]);
            }

            if(values.Contains(DESIGNATION)) {
                model.Designation = Convert.ToString(values[DESIGNATION]);
            }

            if(values.Contains(VALEUR_UNITAIRE)) {
                model.ValeurUnitaire = values[VALEUR_UNITAIRE] != null ? Convert.ToSingle(values[VALEUR_UNITAIRE], CultureInfo.InvariantCulture) : (float?)null;
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