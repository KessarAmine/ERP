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
using DevKbfSteel.Areas;

namespace DevKbfSteel.Controllers
{
    [Area(nameof(Areas.MaintenanceManager))]
    public class OrdresTravailMaintenanceController : Controller
    {
        private KBFsteelContext _context;

        public OrdresTravailMaintenanceController(KBFsteelContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetSent(DateTime dateDebut, DateTime dateFin, DataSourceLoadOptions loadOptions)
        {
            var ordretravail = _context.OrdreTravail.Where(c => c.DateOt >= dateDebut && c.DateOt <= dateFin)
                .Select(i => new {
                    i.DateOt,
                    i.NumOt,
                    i.NumDt,
                    i.CodeMaintenance,
                    i.CodeMachine,
                    i.NumEquipement,
                    i.HeureInstallation,
                    i.CodeDemandeur,
                    i.CodeReceveur

                });

            // If you work with a large amount of data, consider specifying the PaginateViaPrimaryKey and PrimaryKey properties.
            // In this case, keys and data are loaded in separate queries. This can make the SQL execution plan more efficient.
            // Refer to the topic https://github.com/DevExpress/DevExtreme.AspNet.Data/issues/336.
            // loadOptions.PrimaryKey = new[] { "NumDt" };
            // loadOptions.PaginateViaPrimaryKey = true;

            return Json(await DataSourceLoader.LoadAsync(ordretravail, loadOptions));
        }
        [HttpGet]
        public async Task<IActionResult> GetRecieved(DateTime dateDebut, DateTime dateFin, DataSourceLoadOptions loadOptions)
        {
            var ordretravail = _context.OrdreTravail.Where(c => c.DateOt >= dateDebut && c.DateOt <= dateFin)
                .Where(e => e.CodeReceveur == 2)
                .Select(i => new {
                    i.DateOt,
                    i.NumOt,
                    i.NumDt,
                    i.CodeMaintenance,
                    i.CodeMachine,
                    i.NumEquipement,
                    i.HeureInstallation,
                    i.CodeDemandeur,
                    i.CodeReceveur

                });

            // If you work with a large amount of data, consider specifying the PaginateViaPrimaryKey and PrimaryKey properties.
            // In this case, keys and data are loaded in separate queries. This can make the SQL execution plan more efficient.
            // Refer to the topic https://github.com/DevExpress/DevExtreme.AspNet.Data/issues/336.
            // loadOptions.PrimaryKey = new[] { "NumDt" };
            // loadOptions.PaginateViaPrimaryKey = true;

            return Json(await DataSourceLoader.LoadAsync(ordretravail, loadOptions));
        }



        [HttpGet]
        public async Task<IActionResult> MachinesLookup(DataSourceLoadOptions loadOptions)
        {
            var lookup = from i in _context.Machines
                         orderby i.NumMachine
                         select new
                         {
                             Value = i.NumMachine,
                             Text = i.NomMachine
                         };
            return Json(await DataSourceLoader.LoadAsync(lookup, loadOptions));
        }
        [HttpPost]
        public async Task<IActionResult> Post(string values)
        {
            var model = new OrdreTravail();
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModel(model, valuesDict);
            model.CodeReceveur = 2;

            if (!TryValidateModel(model))
                return BadRequest(GetFullErrorMessage(ModelState));
            var ordres = _context.OrdreTravail
                .OrderBy(o => o.NumOt)
                .Select(i => new
                {
                    i.NumOt
                }).ToList();

            if (ordres.Count == 0)
                model.NumOt = 1;
            else
            {
                var m = ordres.Last();
                model.NumOt = Convert.ToInt32(m.NumOt) + 1;
            }

            var result = _context.OrdreTravail.Add(model);
            await _context.SaveChangesAsync();

            return Json(result.Entity.NumOt);
        }

        [HttpPut]
        public async Task<IActionResult> Put(int key, string values)
        {
            var model = await _context.OrdreTravail.FirstOrDefaultAsync(item => item.NumOt == key);
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
            var model = await _context.OrdreTravail.FirstOrDefaultAsync(item => item.NumOt == key);

            _context.OrdreTravail.Remove(model);
            await _context.SaveChangesAsync();

        }

        public async Task<IActionResult> TypeMaintenanceLookup(DataSourceLoadOptions loadOptions)
        {
            var lookup = from i in _context.TypeMaintenance
                         orderby i.CodeMaintenance
                         select new
                         {
                             Value = i.CodeMaintenance,
                             Text = i.DesignationMaintenance
                         };
            return Json(await DataSourceLoader.LoadAsync(lookup, loadOptions));
        }



        [HttpGet]
        public async Task<IActionResult> AteliersTableLookup(DataSourceLoadOptions loadOptions)
        {
            var lookup = from i in _context.AteliersTable
                         orderby i.DesignationAtelier
                         select new
                         {
                             Value = i.CodeAtelier,
                             Text = i.DesignationAtelier
                         };
            return Json(await DataSourceLoader.LoadAsync(lookup, loadOptions));
        }

        [HttpGet]
        public async Task<IActionResult> StructureLookup(DataSourceLoadOptions loadOptions)
        {
            var lookup = from i in _context.Structure
                         orderby i.Designation
                         select new
                         {
                             Value = i.CodeStructure,
                             Text = i.Designation
                         };
            return Json(await DataSourceLoader.LoadAsync(lookup, loadOptions));
        }

        [HttpGet]
        public async Task<IActionResult> EquipementsLookup(DataSourceLoadOptions loadOptions)
        {
            var lookup = from i in _context.Equipements
                         orderby i.NumEquipement
                         select new
                         {
                             Value = i.NumEquipement,
                             Text = i.Nom
                         };
            return Json(await DataSourceLoader.LoadAsync(lookup, loadOptions));
        }
        private void PopulateModel(OrdreTravail model, IDictionary values)
        {
            string NUM_DT = nameof(OrdreTravail.NumDt);
            string NumOt = nameof(OrdreTravail.NumOt);
            string DATE_OT = nameof(OrdreTravail.DateOt);
            string CodeDemandeur = nameof(OrdreTravail.CodeDemandeur);
            string CodeMaintenance = nameof(OrdreTravail.CodeMaintenance);
            string CodeReceveur = nameof(OrdreTravail.CodeReceveur);
            string HeureInstallation = nameof(OrdreTravail.HeureInstallation);
            string Equipement = nameof(OrdreTravail.NumEquipement);
            string Installation = nameof(OrdreTravail.CodeMachine);
            if (values.Contains(Equipement))
            {
                model.NumEquipement = Convert.ToInt32(values[Equipement]);
            }
            if (values.Contains(Installation))
            {
                model.CodeMachine = Convert.ToInt32(values[Installation]);
            }

            if (values.Contains(NUM_DT))
            {
                model.NumDt = Convert.ToInt32(values[NUM_DT]);
            }

            if (values.Contains(NumOt))
            {
                model.NumOt = Convert.ToInt32(values[NumOt]);
            }

            if (values.Contains(DATE_OT))
            {
                model.DateOt = Convert.ToDateTime(values[DATE_OT]);
            }

            if (values.Contains(CodeDemandeur))
            {
                model.CodeDemandeur = Convert.ToInt32(values[CodeDemandeur]);
            }

            if (values.Contains(CodeMaintenance))
            {
                model.CodeMaintenance = Convert.ToBoolean(values[CodeMaintenance]);
            }

            if (values.Contains(CodeReceveur))
            {
                model.CodeReceveur = Convert.ToInt32(values[CodeReceveur]);
            }

            if (values.Contains(HeureInstallation))
            {
                model.HeureInstallation = Convert.ToDateTime(values[HeureInstallation]);
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
        public IActionResult DemandeTravailViewer()
        {
            return View();
        }
    }
}