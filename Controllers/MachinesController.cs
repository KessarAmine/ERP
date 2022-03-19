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
using FluentFTP;
using DevKbfSteel.Models;

namespace DevKbfSteel.Controllers
{
    [Route("api/[controller]/[action]")]

    public class MachinesController : Controller
    {
        private KBFsteelContext _context;

        public MachinesController(KBFsteelContext context) {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get(DataSourceLoadOptions loadOptions) {
            var machines = _context.Machines.Where(c => c.NomMachine != "Train" && c.NomMachine != "Sonalgaz")
                .Select(i => new {
                i.NumMachine,
                i.NomMachine,
                i.NumGroupe,
                i.NumEquipement,
                i.SeuilAlerteAnoamlie
            });

            // If you work with a large amount of data, consider specifying the PaginateViaPrimaryKey and PrimaryKey properties.
            // In this case, keys and data are loaded in separate queries. This can make the SQL execution plan more efficient.
            // Refer to the topic https://github.com/DevExpress/DevExtreme.AspNet.Data/issues/336.
            // loadOptions.PrimaryKey = new[] { "NumMachine" };
            // loadOptions.PaginateViaPrimaryKey = true;

            return Json(await DataSourceLoader.LoadAsync(machines, loadOptions));
        }
        [HttpGet]
        public object GetZones(DataSourceLoadOptions loadOptions) {
            var GroupeMachines = _context.GroupeMachines.AsNoTracking()
                .Select(i => new {
                i.NumGroupe,
                i.NomGroupe
            }).ToList();
            List<MachineZonesModel> Zones = new List<MachineZonesModel>();

            foreach (var itemGroupeMachines in GroupeMachines)
            {
                MachineZonesModel zone = new MachineZonesModel();
                zone.name = itemGroupeMachines.NomGroupe;
                List<MachineModel> composants = new List<MachineModel>();
                var Machines = _context.Machines.AsNoTracking()
                    .Where(c => c.NumGroupe == itemGroupeMachines.NumGroupe)
                    .Select(i => new {
                        i.NomMachine,
                        i.NumMachine
                    }).ToList();
                foreach (var itemMachines in Machines)
                {
                    MachineModel machine = new MachineModel();
                    machine.name = itemMachines.NomMachine;
                    machine.value = itemMachines.NumMachine;
                    composants.Add(machine);
                }
                zone.items = composants.AsEnumerable();
                Zones.Add(zone);
            }

            return DataSourceLoader.Load(Zones.AsEnumerable(), loadOptions);
        }

        [HttpPost]
        public async Task<IActionResult> Post(string values) {
            var model = new Machines();
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModel(model, valuesDict);

            if(!TryValidateModel(model))
                return BadRequest(GetFullErrorMessage(ModelState));

            var machineEquioement = _context.Machines
            .OrderBy(o => o.NumMachine)
            .Select(i => new
            {
                i.NumMachine
            }).ToList();

            var m = machineEquioement.Last();
            model.NumMachine = Convert.ToInt32(m.NumMachine) + 1 ;

            var result = _context.Machines.Add(model);
            await _context.SaveChangesAsync();

            return Json(result.Entity.NumMachine);
        }

        [HttpPut]
        public async Task<IActionResult> Put(int key, string values) {
            var model = await _context.Machines.FirstOrDefaultAsync(item => item.NumMachine == key);
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
            var model = await _context.Machines.FirstOrDefaultAsync(item => item.NumMachine == key);
            var machineEquioement = _context.MachineEquioement
            .Where(o => o.NumMachine == key).ToList();
            foreach (var itemmachineEquioement in machineEquioement)
            {
                _context.MachineEquioement.Remove(itemmachineEquioement);
            }
            _context.Machines.Remove(model);
            await _context.SaveChangesAsync();
        }


        [HttpGet]
        public async Task<IActionResult> ReferenceLookup(DataSourceLoadOptions loadOptions) {
            var lookup = from i in _context.Equipements
                         select new {
                             Value = i.NumEquipement,
                             Text = i.Designation
                         };
            return Json(await DataSourceLoader.LoadAsync(lookup, loadOptions));
        }
        [HttpGet]
        public async Task<IActionResult> EquipementsLookup(DataSourceLoadOptions loadOptions) {
            var lookup = from i in _context.Equipements
                         select new {
                             Value = i.NumEquipement,
                             Text = i.Nom
                         };
            return Json(await DataSourceLoader.LoadAsync(lookup, loadOptions));
        }

        [HttpGet]
        public async Task<IActionResult> EquipementsIntervenuLookup(DataSourceLoadOptions loadOptions)
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

        [HttpGet]
        public async Task<IActionResult> CompositionsLookup(DataSourceLoadOptions loadOptions)
        {
            var lookup = from i in _context.Compositions
                         orderby i.NomComposition
                         select new
                         {
                             Value = i.NumComposition,
                             Text = i.NomComposition
                         };
            return Json(await DataSourceLoader.LoadAsync(lookup, loadOptions));
        }


        [HttpGet]
        public async Task<IActionResult> EquipementsDesLookup(DataSourceLoadOptions loadOptions)
        {
            var lookup = from i in _context.Equipements
                         orderby i.NumEquipement
                         where i.Designation  != null
                         select new
                         {
                             Value = i.Designation,
                             Text = i.Designation
                         };
            return Json(await DataSourceLoader.LoadAsync(lookup, loadOptions));
        }

        [HttpGet]
        public async Task<IActionResult> MaintenanceLookup(DataSourceLoadOptions loadOptions)
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
        public async Task<IActionResult> EquipementsNumLookup(DataSourceLoadOptions loadOptions)
        {
            var lookup = from i in _context.Equipements
                         orderby i.NumEquipement
                         select new
                         {
                             Value = i.NumEquipement,
                             Text = i.NumEquipement
                         };
            return Json(await DataSourceLoader.LoadAsync(lookup, loadOptions));
        }


        [HttpGet]
        public async Task<IActionResult> EquipementsValeurLookup(DataSourceLoadOptions loadOptions)
        {
            var lookup = from i in _context.Equipements
                         orderby i.Nom
                         select new
                         {
                             Value = i.ValeurUnitaire,
                             Text = i.ValeurUnitaire
                         };
            return Json(await DataSourceLoader.LoadAsync(lookup, loadOptions));
        }


        [HttpGet]
        public async Task<IActionResult> GroupeMachinesLookup(DataSourceLoadOptions loadOptions) {
            var lookup = from i in _context.GroupeMachines
                         orderby i.NomGroupe
                         select new {
                             Value = i.NumGroupe,
                             Text = i.NomGroupe
                         };
            return Json(await DataSourceLoader.LoadAsync(lookup, loadOptions));
        }
        [HttpGet]
        public async Task<IActionResult> NumMachinesLookup(DataSourceLoadOptions loadOptions)
        {
            var lookup = from i in _context.Machines
                         orderby i.NumMachine
                         select new
                         {
                             Value = i.NumMachine,
                             Text = i.NumMachine
                         };
            return Json(await DataSourceLoader.LoadAsync(lookup, loadOptions));
        }
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
        private void PopulateModel(Machines model, IDictionary values) {
            string NUM_MACHINE = nameof(Machines.NumMachine);
            string NOM_MACHINE = nameof(Machines.NomMachine);
            string NUM_GROUPE = nameof(Machines.NumGroupe);
            string NUM_EQUIPEMENT = nameof(Machines.NumEquipement);
            string SeuilAlerteAnoamlie = nameof(Machines.SeuilAlerteAnoamlie);

            if(values.Contains(SeuilAlerteAnoamlie)) {
                model.SeuilAlerteAnoamlie = Convert.ToInt32(values[SeuilAlerteAnoamlie]);
            }
            
            if(values.Contains(NUM_MACHINE)) {
                model.NumMachine = Convert.ToInt32(values[NUM_MACHINE]);
            }

            if(values.Contains(NOM_MACHINE)) {
                model.NomMachine = Convert.ToString(values[NOM_MACHINE]);
            }

            if(values.Contains(NUM_GROUPE)) {
                model.NumGroupe = Convert.ToString(values[NUM_GROUPE]);
            }

            if(values.Contains(NUM_EQUIPEMENT)) {
                model.NumEquipement = Convert.ToInt32(values[NUM_EQUIPEMENT]);
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