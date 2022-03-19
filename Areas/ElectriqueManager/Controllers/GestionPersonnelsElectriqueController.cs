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
    [Area(nameof(Areas.ElectriqueManager))]
    public class GestionPersonnelsElectriqueController : Controller
    {
        private KBFsteelContext _context;
        public GestionPersonnelsElectriqueController(KBFsteelContext context) {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> Get(DataSourceLoadOptions loadOptions) {
            var intervenants = _context.RhListeDesEmployes
                .Where(c => c.Disponnible != 3 && c.Disponnible != null)
                .Where(c =>c.Departement == XpertHelper.CodeElectrique)
                .Select(i => new {
                    i.Id,
                    i.Nom,
                    i.Prenom,
                    i.CodeSpecialité,
                    i.CodeEquipe,
                    i.TelProfesionnel
            });
            // If you work with a large amount of data, consider specifying the PaginateViaPrimaryKey and PrimaryKey properties.
            // In this case, keys and data are loaded in separate queries. This can make the SQL execution plan more efficient.
            // Refer to the topic https://github.com/DevExpress/DevExtreme.AspNet.Data/issues/336.
            // loadOptions.PrimaryKey = new[] { "NumEquipement" };
            // loadOptions.PaginateViaPrimaryKey = true;
            return Json(await DataSourceLoader.LoadAsync(intervenants, loadOptions));
        }
        [HttpGet]
        public async void GetId(int id)
        {
            var intervenants = _context.RhListeDesEmployes
                .Where(c => c.Disponnible != 3 && c.Disponnible != null)
                .Where(c => c.Id != id)
                .Select(i => new {
                    i.Id,
                    i.Nom,
                    i.Prenom,
                    i.CodeSpecialité,
                    i.CodeEquipe,
                    i.TelProfesionnel
                });
            // If you work with a large amount of data, consider specifying the PaginateViaPrimaryKey and PrimaryKey properties.
            // In this case, keys and data are loaded in separate queries. This can make the SQL execution plan more efficient.
            // Refer to the topic https://github.com/DevExpress/DevExtreme.AspNet.Data/issues/336.
            // loadOptions.PrimaryKey = new[] { "NumEquipement" };
            // loadOptions.PaginateViaPrimaryKey = true;
        }
        [HttpPut]
        public async Task<IActionResult> Put(int key, string values)
        {
            var model = await _context.RhListeDesEmployes.FirstOrDefaultAsync(item => item.Id == key);
            if (model == null)
                return StatusCode(409, "Object not found");

            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModel(model, valuesDict);

            await _context.SaveChangesAsync();
            return Ok();
        }
        private void PopulateModel(RhListeDesEmployes model, IDictionary values)
        {
            string CodeEquipe = nameof(RhListeDesEmployes.CodeEquipe);

            if (values.Contains(CodeEquipe))
            {
                model.CodeEquipe = Convert.ToInt32(values[CodeEquipe]);
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
        [HttpGet]
        public async Task<IActionResult> EquipeLookup(DataSourceLoadOptions loadOptions)
        {
            var lookup = from i in _context.LookupEquipes
                         orderby i.CodeEquipe
                         select new
                         {
                             Value = i.CodeEquipe,
                             Text = i.DesignationEquipe
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
        [HttpGet]
        public async Task<IActionResult> DureeeInterventionLookup(DataSourceLoadOptions loadOptions)
        {
            var lookup = from i in _context.RapportIntervention
                         orderby i.NumIntervention
                         select new
                         {
                             Value = i.NumIntervention,
                             Text = i.DureeIntervention
                         };
            return Json(await DataSourceLoader.LoadAsync(lookup, loadOptions));
        }
        [HttpGet]
        public async Task<IActionResult> DateInterventionLookup(DataSourceLoadOptions loadOptions)
        {
            var lookup = from i in _context.RapportIntervention
                         orderby i.NumIntervention
                         select new
                         {
                             Value = i.NumIntervention,
                             Text = i.DateIntervention
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
        public async Task<IActionResult> NomLookup(DataSourceLoadOptions loadOptions)
        {
            var lookup = from i in _context.RhListeDesEmployes
                         orderby i.Id
                         where i.Departement == XpertHelper.CodeElectrique && i.Disponnible != 3 && i.Disponnible != null
                         select new
                         {
                             Value = i.Id,
                             Text = Convert.ToString(string.Format("{0} {1}", i.Nom, i.Prenom))
                         };
            return Json(await DataSourceLoader.LoadAsync(lookup, loadOptions));
        }
        [HttpGet]
        public async Task<IActionResult> PrenomLookup(DataSourceLoadOptions loadOptions)
        {
            var lookup = from i in _context.RhListeDesEmployes
                         orderby i.Id
                         where i.Departement == XpertHelper.CodeElectrique && i.Disponnible != 3 && i.Disponnible != null
                         select new
                         {
                             Value = i.Id,
                             Text = i.Prenom
                         };
            return Json(await DataSourceLoader.LoadAsync(lookup, loadOptions));
        }
        [HttpGet]
        public async Task<IActionResult> SpecieliteLookup(DataSourceLoadOptions loadOptions)
        {
            var lookup = from i in _context.Specialite
                         orderby i.CodeSpecialite
                         select new
                         {
                             Value = i.CodeSpecialite,
                             Text = i.Designation
                         };
            return Json(await DataSourceLoader.LoadAsync(lookup, loadOptions));
        }

    }
}