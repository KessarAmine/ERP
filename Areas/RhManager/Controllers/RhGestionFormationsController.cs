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
    [Area(nameof(Areas.RhManager))]
    public class RhGestionFormationsController : Controller
    {
        private KBFsteelContext _context;
        public RhGestionFormationsController(KBFsteelContext context) {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> Get(DataSourceLoadOptions loadOptions) {
            var rhContratsEmployes = _context.GrhFormations.AsNoTracking().Select(i => new {
                i.Id,
                i.Intitule,
                i.Description,
                i.DateFin,
                i.DateDebut,
                i.Cout,
                i.CapitalHumain
            });
            return Json(await DataSourceLoader.LoadAsync(rhContratsEmployes, loadOptions));
        }
        [HttpGet]
        public async Task<IActionResult> GetPersonnels(int id,DataSourceLoadOptions loadOptions) {
            XpertHelper.RhIdFormation = id;
            var rhContratsEmployes = _context.GrhFormationsPersonnels.AsNoTracking().Where(c =>c.IdFormation == id).Select(i => new {
                i.Id,
                i.IdFormation,
                i.IdEmployee,
                i.CapitalHumain
            });
            return Json(await DataSourceLoader.LoadAsync(rhContratsEmployes, loadOptions));
        }
        [HttpPost]
        public async Task<IActionResult> Post(string values) {
            var model = new GrhFormations();
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModel(model, valuesDict);
            var result = _context.GrhFormations.Add(model);
            await _context.SaveChangesAsync();
            return Json(result.Entity.Id);
        }
        [HttpPost]
        public async Task<IActionResult> PostPersonnel(string values) {
            var model = new GrhFormationsPersonnels();
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModelPersonnel(model, valuesDict);
            model.IdFormation = XpertHelper.RhIdFormation;
            model.CapitalHumain = ComputeCapitalHumain(model.IdFormation, model.IdEmployee);
            var result = _context.GrhFormationsPersonnels.Add(model);
            await _context.SaveChangesAsync();
            return Json(result.Entity.Id);
        }
        [HttpPut]
        public async Task<IActionResult> Put(int key, string values) {
            var model = await _context.GrhFormations.FirstOrDefaultAsync(item => item.Id == key);
            if(model == null)
                return StatusCode(409, "Object not found");
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModel(model, valuesDict);
            await _context.SaveChangesAsync();
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> PutPersonnel(int key, string values) {
            var model = await _context.GrhFormationsPersonnels.FirstOrDefaultAsync(item => item.Id == key);
            if (model == null)
                return StatusCode(409, "Object not found");
            var Formation = _context.GrhFormations.Where(c => c.Id == model.IdFormation).FirstOrDefault();
            Formation.CapitalHumain -= model.CapitalHumain;
            _context.GrhFormations.Update(Formation);
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModelPersonnel(model, valuesDict);
            model.CapitalHumain = ComputeCapitalHumain(model.IdFormation, model.IdEmployee);
            await _context.SaveChangesAsync();
            return Ok();
        }
        [HttpDelete]
        public async Task Delete(int key) {
            var model = await _context.GrhFormations.FirstOrDefaultAsync(item => item.Id == key);
            _context.GrhFormations.Remove(model);
            await _context.SaveChangesAsync();
        }
        [HttpDelete]
        public async Task DeletePersonnel(int key) {
            var model = await _context.GrhFormationsPersonnels.FirstOrDefaultAsync(item => item.Id == key);
            _context.GrhFormationsPersonnels.Remove(model);
            var Formation = _context.GrhFormations.Where(c => c.Id == model.IdFormation).FirstOrDefault();
            Formation.CapitalHumain -= model.CapitalHumain;
            _context.GrhFormations.Update(Formation);
            await _context.SaveChangesAsync();
        }
        public double ComputeCapitalHumain(int idFormation,int idEmployee)
        {
            var Formation =  _context.GrhFormations.Where(c => c.Id == idFormation).FirstOrDefault();
            var timeLaps = (Formation.DateFin - Formation.DateDebut).TotalHours;
            var Empl =  _context.RhListeDesEmployes.AsNoTracking().Where(c => c.Id == idEmployee).FirstOrDefault();
            var renumeration = Empl.RénumerationParHeure;
            Formation.CapitalHumain += (double)(renumeration * timeLaps);
            _context.GrhFormations.Update(Formation);
            return (double)(renumeration * timeLaps);
        }
        private void PopulateModel(GrhFormations model, IDictionary values) {
            string Intitule = nameof(GrhFormations.Intitule);
            string Description = nameof(GrhFormations.Description);
            string DateDebut = nameof(GrhFormations.DateDebut);
            string DateFin = nameof(GrhFormations.DateFin);
            string Cout = nameof(GrhFormations.Cout);
            if (values.Contains(Intitule))
            {
                model.Intitule = Convert.ToString(values[Intitule]);
            }
            if (values.Contains(Description))
            {
                model.Description = Convert.ToString(values[Description]);
            }
            if (values.Contains(DateDebut))
            {
                model.DateDebut = Convert.ToDateTime(values[DateDebut]);
            }
            if (values.Contains(DateFin))
            {
                model.DateFin = Convert.ToDateTime(values[DateFin]);
            }
            if (values.Contains(Cout))
            {
                model.Cout = Convert.ToDouble(values[Cout]);
            }
        }
        private void PopulateModelPersonnel(GrhFormationsPersonnels model, IDictionary values) {
            string IdEmployee = nameof(GrhFormationsPersonnels.IdEmployee);
            if (values.Contains(IdEmployee))
            {
                model.IdEmployee = Convert.ToInt32(values[IdEmployee]);
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

        //===================Lookups=================
        [HttpGet]
        public async Task<IActionResult> UniteRecrutementLookup(DataSourceLoadOptions loadOptions)
        {
            var lookup = from i in _context.LookupUniteRecrutement
                         orderby i.CodeUniteRecrutement
                         select new
                         {
                             Value = i.CodeUniteRecrutement,
                             Text = i.DesignatioUniteRecrutement
                         };
            return Json(await DataSourceLoader.LoadAsync(lookup, loadOptions));
        }
        [HttpGet]
        public async Task<IActionResult> TypeContratLookup(DataSourceLoadOptions loadOptions)
        {
            var lookup = from i in _context.LookupTypeContrats
                         orderby i.CodeTypeContrat
                         select new
                         {
                             Value = i.CodeTypeContrat,
                             Text = i.DesignationTypeContrat
                         };
            return Json(await DataSourceLoader.LoadAsync(lookup, loadOptions));
        }
        [HttpGet]
        public async Task<IActionResult> EtatLookup(DataSourceLoadOptions loadOptions)
        {
            var lookup = from i in _context.LookupEtatContrat
                         orderby i.CodeEtatContrat
                         select new
                         {
                             Value = i.CodeEtatContrat,
                             Text = i. DesignationEtatContrat
                         };
            return Json(await DataSourceLoader.LoadAsync(lookup, loadOptions));
        }
        [HttpGet]
        public async Task<IActionResult> EmployeLookup(DataSourceLoadOptions loadOptions)
        {
            var lookup = from i in _context.RhListeDesEmployes
                         orderby i.Id
                         select new
                         {
                             Value = i.Id,
                             Text = Convert.ToString(string.Format("{0} {1}", i.Nom, i.Prenom))
                         };

            var resultorderbyelement = from i in _context.RhListeDesEmployes
                                       group i by i.Departement
                                       into egroup
                                       orderby egroup.Key
                                       select new
                                       {
                                           Key = egroup.Key,
                                           studentobj = egroup.OrderBy(g => g.Nom)
                                       };
            return Json(await DataSourceLoader.LoadAsync(lookup, loadOptions));
        }
    }
}