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
    public class RhListeDesEmployesController : Controller
    {
        private KBFsteelContext _context;
        public RhListeDesEmployesController(KBFsteelContext context){
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> Get(DataSourceLoadOptions loadOptions){
            var rhListeDesEmployes = _context.RhListeDesEmployes.Select(i => new {
                i.Id,
                i.Civilité,
                i.DateNaissance,
                i.Departement,
                i.Email,
                i.Nationalité,
                i.NumeroSecuriteSocial,
                i.Nom,
                i.PaysNaissance,
                i.DateFinAmbouche,
                i.Prenom,
                i.Sexe,
                i.TelPersonnel,
                i.TelProfesionnel,
                i.DateAmbouche
            });
            // If you work with a large amount of data, consider specifying the PaginateViaPrimaryKey and PrimaryKey properties.
            // In this case, keys and data are loaded in separate queries. This can make the SQL execution plan more efficient.
            // Refer to the topic https://github.com/DevExpress/DevExtreme.AspNet.Data/issues/336.
            // loadOptions.PrimaryKey = new[] { "NumEquipement" };
            // loadOptions.PaginateViaPrimaryKey = true;

            return Json(await DataSourceLoader.LoadAsync(rhListeDesEmployes, loadOptions));
        }
        [HttpGet]
        public async Task<IActionResult> GetSodure(DataSourceLoadOptions loadOptions)
        {
            var rhListeDesEmployes = _context.RhListeDesEmployes
                .Where(c => c.Disponnible != 3 && c.Disponnible != null)
                .Where(item => item.Departement == XpertHelper.CodeSodure)
                .Select(i => new {
                i.Id,
                i.Civilité,
                i.DateNaissance,
                i.Departement,
                i.Email,
                i.Nationalité,
                i.NumeroSecuriteSocial,
                i.Nom,
                i.PaysNaissance,
                i.DateFinAmbouche,
                i.Prenom,
                i.Sexe,
                i.TelPersonnel,
                i.TelProfesionnel,
                i.DateAmbouche
            });
            // If you work with a large amount of data, consider specifying the PaginateViaPrimaryKey and PrimaryKey properties.
            // In this case, keys and data are loaded in separate queries. This can make the SQL execution plan more efficient.
            // Refer to the topic https://github.com/DevExpress/DevExtreme.AspNet.Data/issues/336.
            // loadOptions.PrimaryKey = new[] { "NumEquipement" };
            // loadOptions.PaginateViaPrimaryKey = true;

            return Json(await DataSourceLoader.LoadAsync(rhListeDesEmployes, loadOptions));
        }
        [HttpGet]
        public async Task<IActionResult> GetUsinage(DataSourceLoadOptions loadOptions)
        {
            var rhListeDesEmployes = _context.RhListeDesEmployes
                .Where(c => c.Disponnible != 3 && c.Disponnible != null)
                .Where(item => item.Departement == XpertHelper.CodeUsinage)
                .Select(i => new {
                i.Id,
                i.Civilité,
                i.DateNaissance,
                i.Departement,
                i.Email,
                i.Nationalité,
                i.NumeroSecuriteSocial,
                i.Nom,
                i.PaysNaissance,
                i.DateFinAmbouche,
                i.Prenom,
                i.Sexe,
                i.TelPersonnel,
                i.TelProfesionnel,
                i.DateAmbouche
            });
            // If you work with a large amount of data, consider specifying the PaginateViaPrimaryKey and PrimaryKey properties.
            // In this case, keys and data are loaded in separate queries. This can make the SQL execution plan more efficient.
            // Refer to the topic https://github.com/DevExpress/DevExtreme.AspNet.Data/issues/336.
            // loadOptions.PrimaryKey = new[] { "NumEquipement" };
            // loadOptions.PaginateViaPrimaryKey = true;

            return Json(await DataSourceLoader.LoadAsync(rhListeDesEmployes, loadOptions));
        }
        [HttpGet]
        public async Task<IActionResult> GetMethodes(DataSourceLoadOptions loadOptions)
        {
            var rhListeDesEmployes = _context.RhListeDesEmployes
                .Where(c => c.Disponnible != 3 && c.Disponnible != null)
                .Where(item => item.Departement == XpertHelper.CodeMethode)
                .Select(i => new {
                i.Id,
                i.Civilité,
                i.DateNaissance,
                i.Departement,
                i.Email,
                i.Nationalité,
                i.NumeroSecuriteSocial,
                i.Nom,
                i.PaysNaissance,
                i.DateFinAmbouche,
                i.Prenom,
                i.Sexe,
                i.TelPersonnel,
                i.TelProfesionnel,
                i.DateAmbouche
            });
            // If you work with a large amount of data, consider specifying the PaginateViaPrimaryKey and PrimaryKey properties.
            // In this case, keys and data are loaded in separate queries. This can make the SQL execution plan more efficient.
            // Refer to the topic https://github.com/DevExpress/DevExtreme.AspNet.Data/issues/336.
            // loadOptions.PrimaryKey = new[] { "NumEquipement" };
            // loadOptions.PaginateViaPrimaryKey = true;

            return Json(await DataSourceLoader.LoadAsync(rhListeDesEmployes, loadOptions));
        }
        [HttpGet]
        public async Task<IActionResult> GetElectrique(DataSourceLoadOptions loadOptions)
        {
            var rhListeDesEmployes = _context.RhListeDesEmployes
                .Where(c => c.Disponnible != 3 && c.Disponnible != null)
                .Where(item => item.Departement == XpertHelper.CodeElectrique)
                .Select(i => new {
                i.Id,
                i.Civilité,
                i.DateNaissance,
                i.Departement,
                i.Email,
                i.Nationalité,
                i.NumeroSecuriteSocial,
                i.Nom,
                i.PaysNaissance,
                i.DateFinAmbouche,
                i.Prenom,
                i.Sexe,
                i.TelPersonnel,
                i.TelProfesionnel,
                i.DateAmbouche
            });
            // If you work with a large amount of data, consider specifying the PaginateViaPrimaryKey and PrimaryKey properties.
            // In this case, keys and data are loaded in separate queries. This can make the SQL execution plan more efficient.
            // Refer to the topic https://github.com/DevExpress/DevExtreme.AspNet.Data/issues/336.
            // loadOptions.PrimaryKey = new[] { "NumEquipement" };
            // loadOptions.PaginateViaPrimaryKey = true;

            return Json(await DataSourceLoader.LoadAsync(rhListeDesEmployes, loadOptions));
        }
        [HttpGet]
        public async Task<IActionResult> GetExploitation(DataSourceLoadOptions loadOptions)
        {
            var rhListeDesEmployes = _context.RhListeDesEmployes
                .Where(c => c.Disponnible != 3 && c.Disponnible != null)
                .Where(item => item.Departement == XpertHelper.CodeExploitation)
                .Select(i => new {
                i.Id,
                i.Civilité,
                i.DateNaissance,
                i.Departement,
                i.Email,
                i.Nationalité,
                i.NumeroSecuriteSocial,
                i.Nom,
                i.PaysNaissance,
                i.DateFinAmbouche,
                i.Prenom,
                i.Sexe,
                i.TelPersonnel,
                i.TelProfesionnel,
                i.DateAmbouche
            });
            // If you work with a large amount of data, consider specifying the PaginateViaPrimaryKey and PrimaryKey properties.
            // In this case, keys and data are loaded in separate queries. This can make the SQL execution plan more efficient.
            // Refer to the topic https://github.com/DevExpress/DevExtreme.AspNet.Data/issues/336.
            // loadOptions.PrimaryKey = new[] { "NumEquipement" };
            // loadOptions.PaginateViaPrimaryKey = true;

            return Json(await DataSourceLoader.LoadAsync(rhListeDesEmployes, loadOptions));
        }
        [HttpGet]
        public async Task<IActionResult> GetMecanique(DataSourceLoadOptions loadOptions)
        {
            var rhListeDesEmployes = _context.RhListeDesEmployes
                .Where(c => c.Disponnible != 3 && c.Disponnible != null)
                .Where(item => item.Departement == XpertHelper.CodeMecanqiue)
                .Select(i => new {
                i.Id,
                i.Civilité,
                i.DateNaissance,
                i.Departement,
                i.Email,
                i.Nationalité,
                i.NumeroSecuriteSocial,
                i.Nom,
                i.PaysNaissance,
                i.DateFinAmbouche,
                i.Prenom,
                i.Sexe,
                i.TelPersonnel,
                i.TelProfesionnel,
                i.DateAmbouche
            });
            // If you work with a large amount of data, consider specifying the PaginateViaPrimaryKey and PrimaryKey properties.
            // In this case, keys and data are loaded in separate queries. This can make the SQL execution plan more efficient.
            // Refer to the topic https://github.com/DevExpress/DevExtreme.AspNet.Data/issues/336.
            // loadOptions.PrimaryKey = new[] { "NumEquipement" };
            // loadOptions.PaginateViaPrimaryKey = true;

            return Json(await DataSourceLoader.LoadAsync(rhListeDesEmployes, loadOptions));
        }
        [HttpPost]
        public async Task<IActionResult> Post(string values){
            var model = new RhListeDesEmployes();
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModel(model, valuesDict);
            model.DateNaissance = model.DateNaissance.AddDays(1.0);
            if (!TryValidateModel(model))
                return BadRequest(GetFullErrorMessage(ModelState));
            //AutoInc
            var lastrhListeDesEmployes = _context.RhListeDesEmployes.Select(i => new
            {
                i.Id
            }).ToList();
            if (lastrhListeDesEmployes.Count == 0)
            {
                model.Id = 1;
            }
            else
            {
                var m = lastrhListeDesEmployes.Last();
                model.Id = m.Id+1;
            }
            var result = _context.RhListeDesEmployes.Add(model);
            await _context.SaveChangesAsync();
            return Json(result.Entity.Id);
        }
        [HttpPut]
        public async Task<IActionResult> Put(int key, string values){
            var model = await _context.RhListeDesEmployes.FirstOrDefaultAsync(item => item.Id == key);
            if(model == null)
                return StatusCode(409, "Object not found");

            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModel(model, valuesDict);

            await _context.SaveChangesAsync();
            return Ok();
        }
        [HttpDelete]
        public async Task Delete(int key){
            var model = await _context.RhListeDesEmployes.FirstOrDefaultAsync(item => item.Id == key);
            _context.RhListeDesEmployes.Remove(model);
            await _context.SaveChangesAsync();
        }
        private void PopulateModel(RhListeDesEmployes model, IDictionary values){
            string Id = nameof(RhListeDesEmployes.Id);
            string Civilité = nameof(RhListeDesEmployes.Civilité);
            string DateNaissance = nameof(RhListeDesEmployes.DateNaissance);
            string Departement = nameof(RhListeDesEmployes.Departement);
            string Email = nameof(RhListeDesEmployes.Email);
            string Nationalité = nameof(RhListeDesEmployes.Nationalité);
            string NumeroSecuriteSocial = nameof(RhListeDesEmployes.NumeroSecuriteSocial);
            string Nom = nameof(RhListeDesEmployes.Nom);
            string PaysNaissance = nameof(RhListeDesEmployes.PaysNaissance);
            string Prenom = nameof(RhListeDesEmployes.Prenom);
            string Sexe = nameof(RhListeDesEmployes.Sexe);
            string TelPersonnel = nameof(RhListeDesEmployes.TelPersonnel);
            string TelProfesionnel = nameof(RhListeDesEmployes.TelProfesionnel);

            if(values.Contains(Id)) {
                model.Id = Convert.ToInt32(values[Id]);
            }
            if (values.Contains(Civilité))
            {
                model.Civilité = Convert.ToInt32(values[Civilité]);
            }
            if (values.Contains(Departement))
            {
                model.Departement = Convert.ToInt32(values[Departement]);
            }
            if (values.Contains(Nationalité))
            {
                model.Nationalité = Convert.ToInt32(values[Nationalité]);
            }
            if (values.Contains(PaysNaissance))
            {
                model.PaysNaissance = Convert.ToInt32(values[PaysNaissance]);
            }
            if (values.Contains(Sexe))
            {
                model.Sexe = Convert.ToInt32(values[Sexe]);
            }
            if (values.Contains(TelPersonnel))
            {
                model.TelPersonnel = Convert.ToInt32(values[TelPersonnel]);
            }
            if (values.Contains(TelProfesionnel))
            {
                model.TelProfesionnel = Convert.ToInt32(values[TelProfesionnel]);
            }
            if (values.Contains(DateNaissance))
            {
                model.DateNaissance = Convert.ToDateTime(values[DateNaissance]);
            }
            if (values.Contains(Email))
            {
                model.Email = Convert.ToString(values[Email]);
            }
            if (values.Contains(NumeroSecuriteSocial))
            {
                model.NumeroSecuriteSocial = (int?)Convert.ToInt64(values[NumeroSecuriteSocial]);
            }
            if (values.Contains(Nom))
            {
                model.Nom = Convert.ToString(values[Nom]);
            }
            if (values.Contains(Prenom))
            {
                model.Prenom = Convert.ToString(values[Prenom]);
            }

        }
        private string GetFullErrorMessage(ModelStateDictionary modelState){
            var messages = new List<string>();

            foreach(var entry in modelState) {
                foreach(var error in entry.Value.Errors)
                    messages.Add(error.ErrorMessage);
            }

            return String.Join(" ", messages);
        }
        //===================Lookups=================
        [HttpGet]
        public async Task<IActionResult> PaysLookup(DataSourceLoadOptions loadOptions)
        {
            var lookup = from i in _context.LookupPays
                         orderby i.CodePays
                         select new
                         {
                             Value = i.CodePays,
                             Text = i.ReferencePays
                         };
            return Json(await DataSourceLoader.LoadAsync(lookup, loadOptions));
        }
        [HttpGet]
        public async Task<IActionResult> SexeLookup(DataSourceLoadOptions loadOptions)
        {
            var lookup = from i in _context.LookupSexe
                         orderby i.CodeSexe
                         select new
                         {
                             Value = i.CodeSexe,
                             Text = i.DesignationSexe
                         };
            return Json(await DataSourceLoader.LoadAsync(lookup, loadOptions));
        }
        [HttpGet]
        public async Task<IActionResult> CiviliteLookup(DataSourceLoadOptions loadOptions)
        {
            var lookup = from i in _context.LookupCivilite
                         orderby i.CodeCivilite
                         select new
                         {
                             Value = i.CodeCivilite,
                             Text = i. DesignationCivilite
                         };
            return Json(await DataSourceLoader.LoadAsync(lookup, loadOptions));
        }
        [HttpGet]
        public async Task<IActionResult> EmployeeLookup(DataSourceLoadOptions loadOptions)
        {
            var lookup = from i in _context.RhListeDesEmployes
                         orderby i.Id
                         select new
                         {
                             Value = i.Id,
                             Text = Convert.ToString(string.Format("{0} {1}", i.Nom, i.Prenom))
                         };
            return Json(await DataSourceLoader.LoadAsync(lookup, loadOptions));
        }
        [HttpGet]
        public async Task<IActionResult> DepartementsLookup(DataSourceLoadOptions loadOptions)
        {
            var lookup = from i in _context.Structure
                         orderby i.CodeStructure
                         select new
                         {
                             Value = i.CodeStructure,
                             Text = i.Designation
                         };
            return Json(await DataSourceLoader.LoadAsync(lookup, loadOptions));
        }
    }
}