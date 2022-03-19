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
using DevKbfSteel.Models;

namespace DevKbfSteel.Controllers
{
    [Route("api/[controller]/[action]")]
    public class SuiviEntretienPersonnelsController : Controller
    {
        private KBFsteelContext _context;
        public SuiviEntretienPersonnelsController(KBFsteelContext context)
        {
            _context = context;
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
        [HttpGet]
        public object GetSuiviPersonnel(int id, DataSourceLoadOptions loadOptions)
        {
            var toSave = _context.RhListeDesEmployes.AsNoTracking().Where(c => c.Id == id).FirstOrDefault();
            XpertHelper.NomEmpSuivi = toSave.Nom;
            XpertHelper.PrenomEmpSuivi = toSave.Prenom;
            XpertHelper.CodeEmpSuivi = id;
            XpertHelper.RenumerationValue = (double)toSave.RénumerationParHeure;

            var assIntervantOt = _context.AssOtIntervenants
                .Where(c => c.CodeIntervenant == id)
                .Select(i => new {
                    i.Id,
                    i.NumIntervention,
                    i.CodeEquipement,
                    i.CodeMachine,
                    i.DateIntervention,
                    i.DureeInervention
                });
            List<SuiviInterventionPersonnelRh> ListSuiviInterventionPersonnelRh = new List<SuiviInterventionPersonnelRh>();
            foreach (var itemassIntervantOt in assIntervantOt)
            {
                SuiviInterventionPersonnelRh suiviInterventionPersonnelRh = new SuiviInterventionPersonnelRh();
                suiviInterventionPersonnelRh.Id = itemassIntervantOt.Id;
                suiviInterventionPersonnelRh.NumIntervention = itemassIntervantOt.NumIntervention;
                suiviInterventionPersonnelRh.CodeEquipement = itemassIntervantOt.CodeEquipement;
                suiviInterventionPersonnelRh.CodeMachine = itemassIntervantOt.CodeMachine;
                suiviInterventionPersonnelRh.DateIntervention = itemassIntervantOt.DateIntervention;
                suiviInterventionPersonnelRh.DureeInervention = itemassIntervantOt.DureeInervention;
                suiviInterventionPersonnelRh.Remunération = XpertHelper.RenumerationValue;
                ListSuiviInterventionPersonnelRh.Add(suiviInterventionPersonnelRh);
            }
            // If you work with a large amount of data, consider specifying the PaginateViaPrimaryKey and PrimaryKey properties.
            // In this case, keys and data are loaded in separate queries. This can make the SQL execution plan more efficient.
            // Refer to the topic https://github.com/DevExpress/DevExtreme.AspNet.Data/issues/336.
            // loadOptions.PrimaryKey = new[] { "NumEquipement" };
            // loadOptions.PaginateViaPrimaryKey = true;
            return DataSourceLoader.Load(ListSuiviInterventionPersonnelRh.AsEnumerable(), loadOptions);
        }
        [HttpGet]
        public async Task<IActionResult> GetSuiviEntretiens(int id, DataSourceLoadOptions loadOptions)
        {
            var toSave = _context.RhListeDesEmployes.AsNoTracking().Where(c => c.Id == id).FirstOrDefault();
            XpertHelper.NomEmpSuivi = toSave.Nom;
            XpertHelper.PrenomEmpSuivi = toSave.Prenom;
            XpertHelper.CodeEmpSuivi = id;
            var suiviEntretien = _context.SuiviEntretienPersonnels
                .Where(c => c.IdEmployee == id)
                .Select(i => new {
                    i.IdEntretien,
                    i.Sujet,
                    i.Lieu,
                    i.Explication,
                    i.Observation,
                    i.Poste,
                    i.Date,
                    i.DateIncidant
                });
            // If you work with a large amount of data, consider specifying the PaginateViaPrimaryKey and PrimaryKey properties.
            // In this case, keys and data are loaded in separate queries. This can make the SQL execution plan more efficient.
            // Refer to the topic https://github.com/DevExpress/DevExtreme.AspNet.Data/issues/336.
            // loadOptions.PrimaryKey = new[] { "NumEquipement" };
            // loadOptions.PaginateViaPrimaryKey = true;
            return Json(await DataSourceLoader.LoadAsync(suiviEntretien, loadOptions));
        }
        [HttpPut]
        public async Task<IActionResult> PutEntretien(int key, string values)
        {
            var model = await _context.SuiviEntretienPersonnels.FirstOrDefaultAsync(item => item.IdEntretien == key);
            if (model == null)
                return StatusCode(409, "Object not found");

            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModelEntretien(model, valuesDict);
            model.IdEmployee = (int)XpertHelper.CodeEmpSuivi;
            await _context.SaveChangesAsync();
            return Ok();
        }
        [HttpPost]
        public async Task<IActionResult> PostEntretien(string values)
        {
            var model = new SuiviEntretienPersonnels();
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModelEntretien(model, valuesDict);
            model.IdEmployee = (int)XpertHelper.CodeEmpSuivi;
            var suivis = _context.SuiviEntretienPersonnels
            .OrderBy(o => o.IdEntretien)
            .Select(i => new
            {
                i.IdEntretien
            }).ToList();
            if (suivis.Count == 0)
                model.IdEntretien = 1;
            else
            {
                var m = suivis.Last();
                model.IdEntretien = m.IdEntretien + 1;
            }
            model.Date = DateTime.Now;
            var result = _context.SuiviEntretienPersonnels.Add(model);
            await _context.SaveChangesAsync();
            return Json(result.Entity.IdEntretien);
        }
        [HttpDelete]
        public async Task DeleteEntretien(int key)
        {
            var model = await _context.SuiviEntretienPersonnels.FirstOrDefaultAsync(item => item.IdEntretien == key);
            _context.SuiviEntretienPersonnels.Remove(model);
            await _context.SaveChangesAsync();
        }
        private void PopulateModelEntretien(SuiviEntretienPersonnels model, IDictionary values)
        {
            string IdEmployee = nameof(SuiviEntretienPersonnels.IdEmployee);
            string Date = nameof(SuiviEntretienPersonnels.Date);
            string Explication = nameof(SuiviEntretienPersonnels.Explication);
            string Lieu = nameof(SuiviEntretienPersonnels.Lieu);
            string Observation = nameof(SuiviEntretienPersonnels.Observation);
            string Poste = nameof(SuiviEntretienPersonnels.Poste);
            string Sujet = nameof(SuiviEntretienPersonnels.Sujet);
            string DateIncidant = nameof(SuiviEntretienPersonnels.DateIncidant);
            if (values.Contains(IdEmployee))
            {
                var Idemployevar = values[IdEmployee];
                var Idemployestrings = Idemployevar.ToString();
                var SplitThefirst = Idemployestrings.Split("[");
                var SplitThesecond = SplitThefirst[1].Split("]");
                var value = SplitThesecond[0];
                model.IdEmployee = Convert.ToInt32(value);
            }
            if (values.Contains(Poste))
            {
                model.Poste = Convert.ToInt32(values[Poste]);
            }
            if (values.Contains(Explication))
            {
                model.Explication = Convert.ToString(values[Explication]);
            }
            if (values.Contains(Lieu))
            {
                model.Lieu = Convert.ToString(values[Lieu]);
            }
            if (values.Contains(Observation))
            {
                model.Observation = Convert.ToString(values[Observation]);
            }
            if (values.Contains(Sujet))
            {
                model.Sujet = Convert.ToString(values[Sujet]);
            }
            if (values.Contains(DateIncidant))
            {
                model.DateIncidant = Convert.ToDateTime(values[DateIncidant]);
            }
            if (values.Contains(Date))
            {
                model.Date = DateTime.Now;
            }
        }
    }
}
