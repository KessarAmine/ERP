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
    [Area(nameof(Areas.QualiteManager))]
    public class ControlGeometriqueController : Controller
    {
        private KBFsteelContext _context;
        public ControlGeometriqueController(KBFsteelContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> Get(DateTime dateDebut, DateTime dateFin, DataSourceLoadOptions loadOptions)
        {
            var QualiteControlGeometrique = _context.QualiteControlGeometrique.AsNoTracking().Where(c => c.DateControl.Date >= dateDebut.Date && c.DateControl.Date <= dateFin.Date)
                .Select(i => new {
                    i.NumControl,
                    i.DateControl,
                    i.IdControleur,
                    i.PosteControl,
                    i.Remarque
                });
            // If you work with a large amount of data, consider specifying the PaginateViaPrimaryKey and PrimaryKey properties.
            // In this case, keys and data are loaded in separate queries. This can make the SQL execution plan more efficient.
            // Refer to the topic https://github.com/DevExpress/DevExtreme.AspNet.Data/issues/336.
            // loadOptions.PrimaryKey = new[] { "NumEquipement" };
            // loadOptions.PaginateViaPrimaryKey = true;
            return Json(await DataSourceLoader.LoadAsync(QualiteControlGeometrique, loadOptions));
        }
        [HttpGet]
        public async Task<IActionResult> GetDetails(int id, DataSourceLoadOptions loadOptions)
        {
            XpertHelper.QualiteControlGeometrique = id;
            var QualiteControlGeometriqueDetails = _context.QualiteControlGeometriqueDetails.AsNoTracking().Where(c => c.NumControl == id)
                .Select(i => new {
                    i.NumControl,
                    i.Id,
                    i.AboutLargeur,
                    i.AboutsHauteur,
                    i.HeureMiseCotes,
                    i.MasseLineique,
                    i.MesureProfileLamineExacte,
                    i.NervureHauteur,
                    i.NervureLargeur,
                    i.NervurePas,
                    i.OvaliteSurDiametre,
                    i.Profile,
                    i.Remarque
                });
            // If you work with a large amount of data, consider specifying the PaginateViaPrimaryKey and PrimaryKey properties.
            // In this case, keys and data are loaded in separate queries. This can make the SQL execution plan more efficient.
            // Refer to the topic https://github.com/DevExpress/DevExtreme.AspNet.Data/issues/336.
            // loadOptions.PrimaryKey = new[] { "NumEquipement" };
            // loadOptions.PaginateViaPrimaryKey = true;
            return Json(await DataSourceLoader.LoadAsync(QualiteControlGeometriqueDetails, loadOptions));
        }
        [HttpPost]
        public async Task<IActionResult> Post(string values)
        {
            var model = new QualiteControlGeometrique();
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModel(model, valuesDict);
            var result = _context.QualiteControlGeometrique.Add(model);
            await _context.SaveChangesAsync();
            return Json(result.Entity.NumControl);
        }
        [HttpPost]
        public async Task<IActionResult> PostDetails(string values)
        {
            var model = new QualiteControlGeometriqueDetails();
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModelDetails(model, valuesDict);
            model.NumControl = XpertHelper.QualiteControlGeometrique;
            var result = _context.QualiteControlGeometriqueDetails.Add(model);
            await _context.SaveChangesAsync();
            return Json(result.Entity.Id);
        }
        [HttpPut]
        public async Task<IActionResult> Put(int key, string values)
        {
            var model = await _context.QualiteControlGeometrique.FirstOrDefaultAsync(item => item.NumControl == key);
            if (model == null)
                return StatusCode(409, "Object not found");

            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModel(model, valuesDict);

            await _context.SaveChangesAsync();
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> PutDetails(int key, string values)
        {
            var model = await _context.QualiteControlGeometriqueDetails.FirstOrDefaultAsync(item => item.Id == key);
            if (model == null)
                return StatusCode(409, "Object not found");

            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModelDetails(model, valuesDict);

            await _context.SaveChangesAsync();
            return Ok();
        }
        [HttpDelete]
        public async Task Delete(int key)
        {
            var model = await _context.QualiteControlGeometrique.FirstOrDefaultAsync(item => item.NumControl == key);

            _context.QualiteControlGeometrique.Remove(model);
            await _context.SaveChangesAsync();
        }
        [HttpDelete]
        public async Task DeleteDetails(int key)
        {
            var model = await _context.QualiteControlGeometriqueDetails.FirstOrDefaultAsync(item => item.Id == key);

            _context.QualiteControlGeometriqueDetails.Remove(model);
            await _context.SaveChangesAsync();
        }
        private void PopulateModel(QualiteControlGeometrique model, IDictionary values)
        {
            string DateControl = nameof(QualiteControlGeometrique.DateControl);
            string IdControleur = nameof(QualiteControlGeometrique.IdControleur);
            string PosteControl = nameof(QualiteControlGeometrique.PosteControl);
            string Remarque = nameof(QualiteControlGeometrique.Remarque);
            string NumControl = nameof(QualiteControlGeometrique.NumControl);

            if (values.Contains(DateControl))
            {
                model.DateControl = Convert.ToDateTime(values[DateControl]);
            }
            if (values.Contains(NumControl))
            {
                model.NumControl = Convert.ToInt32(values[NumControl]);
            }
            if (values.Contains(IdControleur))
            {
                model.IdControleur = Convert.ToInt32(values[IdControleur]);
            }
            if (values.Contains(PosteControl))
            {
                model.PosteControl = Convert.ToInt32(values[PosteControl]);
            }
            if (values.Contains(Remarque))
            {
                model.Remarque = Convert.ToString(values[Remarque]);
            }
        }
        private void PopulateModelDetails(QualiteControlGeometriqueDetails model, IDictionary values)
        {
            string AboutLargeur = nameof(QualiteControlGeometriqueDetails.AboutLargeur);
            string AboutsHauteur = nameof(QualiteControlGeometriqueDetails.AboutsHauteur);
            string HeureMiseCotes = nameof(QualiteControlGeometriqueDetails.HeureMiseCotes);
            string MasseLineique = nameof(QualiteControlGeometriqueDetails.MasseLineique);
            string MesureProfileLamineExacte = nameof(QualiteControlGeometriqueDetails.MesureProfileLamineExacte);
            string NervureHauteur = nameof(QualiteControlGeometriqueDetails.NervureHauteur);
            string NervureLargeur = nameof(QualiteControlGeometriqueDetails.NervureLargeur);
            string NervurePas = nameof(QualiteControlGeometriqueDetails.NervurePas);
            string OvaliteSurDiametre = nameof(QualiteControlGeometriqueDetails.OvaliteSurDiametre);
            string Profile = nameof(QualiteControlGeometriqueDetails.Profile);
            string Remarque = nameof(QualiteControlGeometriqueDetails.Remarque);
            if (values.Contains(AboutLargeur))
            {
                model.AboutLargeur = Convert.ToDouble(values[AboutLargeur]);
            }
            if (values.Contains(AboutsHauteur))
            {
                model.AboutsHauteur = Convert.ToDouble(values[AboutsHauteur]);
            }
            if (values.Contains(HeureMiseCotes))
            {
                model.HeureMiseCotes = Convert.ToDateTime(values[HeureMiseCotes]);
            }
            if (values.Contains(MasseLineique))
            {
                model.MasseLineique = Convert.ToDouble(values[MasseLineique]);
            }
            if (values.Contains(MesureProfileLamineExacte))
            {
                model.MesureProfileLamineExacte = Convert.ToDouble(values[MesureProfileLamineExacte]);
            }
            if (values.Contains(NervureHauteur))
            {
                model.NervureHauteur = Convert.ToDouble(values[NervureHauteur]);
            }
            if (values.Contains(NervureLargeur))
            {
                model.NervureLargeur = Convert.ToDouble(values[NervureLargeur]);
            }
            if (values.Contains(NervurePas))
            {
                model.NervurePas = Convert.ToDouble(values[NervurePas]);
            }
            if (values.Contains(OvaliteSurDiametre))
            {
                model.OvaliteSurDiametre = Convert.ToDouble(values[OvaliteSurDiametre]);
            }
            if (values.Contains(Profile))
            {
                model.Profile = Convert.ToString(values[Profile]);
            }
            if (values.Contains(Remarque))
            {
                model.Remarque = Convert.ToString(values[Remarque]);
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
                         where i.Departement == XpertHelper.CodeMecanqiue && i.Disponnible != 3 && i.Disponnible != null
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
                         where i.Departement == XpertHelper.CodeMecanqiue && i.Disponnible != 3 && i.Disponnible != null
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