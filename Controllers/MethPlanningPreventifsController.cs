using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using Microsoft.Extensions.Caching.Memory;
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
using DevKbfSteel.Areas.MethodeManager.Models;
using DevKbfSteel.Helpers;
using Microsoft.AspNetCore.Http;

namespace DevKbfSteel.Controllers
{
    [Route("api/[controller]/[action]")]

    public class MethPlanningPreventifsController : Controller
    {

        private KBFsteelContext _context;
        InMemoryPreventifDataContext _data;
        public  MethPlanningPreventifsController(IHttpContextAccessor httpContextAccessor, IMemoryCache memoryCache, KBFsteelContext context)
        {
            _context = context;
            XpertHelper.XpertIHttpContextAccessor = httpContextAccessor;
            XpertHelper.XpertIMemoryCache = memoryCache;
            _data = new InMemoryPreventifDataContext(XpertHelper.XpertIHttpContextAccessor, XpertHelper.XpertIMemoryCache);
        }
        [HttpGet]
        public object GetElectrique(DataSourceLoadOptions loadOptions)
        {
            var methAppointementsPreventifs = _context.MethAppointementsPreventifs
                .Select(i => new {
                    i.AppointmentId,
                    i.Description,
                    i.EndDate,
                    i.StartDate,
                    i.Text,
                    i.RecurrenceException,
                    i.RecurrenceRule,
                    i.Statut,
                    i.IdOperation
                });
            // If you work with a large amount of data, consider specifying the PaginateViaPrimaryKey and PrimaryKey properties.
            // In this case, keys and data are loaded in separate queries. This can make the SQL execution plan more efficient.
            // Refer to the topic https://github.com/DevExpress/DevExtreme.AspNet.Data/issues/336.
            // loadOptions.PrimaryKey = new[] { "Id" };
            // loadOptions.PaginateViaPrimaryKey = true;
            List<int> IdsOperations = new List<int>();
            List<int> ElectriqueIdsOperations = new List<int>();
            List<MethAppointementsPreventifs> ElectriqueOperations = new List<MethAppointementsPreventifs>();

            foreach (var itemmethAppointementsPreventifs in methAppointementsPreventifs)
            {
                if(IdsOperations.Count() == 0)
                {
                    IdsOperations.Add(itemmethAppointementsPreventifs.IdOperation);
                }
                var exists = 0;
                foreach (var itemIdsOperations in IdsOperations)
                {
                    if(itemIdsOperations==itemmethAppointementsPreventifs.IdOperation)
                    {
                        exists = 1;
                    }
                }
                if(exists == 0)
                {
                    IdsOperations.Add(itemmethAppointementsPreventifs.IdOperation);
                }
            }
            foreach (var itemIdsOperations in IdsOperations)
            {
                var methOperations = _context.MethOperations
                    .Where(c=>c.Idoperation== itemIdsOperations && c.StructreConcernée == XpertHelper.CodeElectrique)
                    .Select(i => new {
                        i.Idoperation
                    }).ToList();
                if(methOperations.Count !=0)
                    ElectriqueIdsOperations.Add(methOperations.Last().Idoperation);
            }
            foreach (var itemElectriqueIdsOperations in ElectriqueIdsOperations)
            {
                var methAppointementsPreventifsElectrique = _context.MethAppointementsPreventifs
                    .Where(c => c.IdOperation == itemElectriqueIdsOperations)
                    .Select(i => new {
                        i.AppointmentId,
                        i.Description,
                        i.EndDate,
                        i.StartDate,
                        i.Text,
                        i.RecurrenceException,
                        i.RecurrenceRule,
                        i.Statut,
                        i.IdOperation
                    });
                foreach (var itemmethAppointementsPreventifsElectrique in methAppointementsPreventifsElectrique)
                {
                    MethAppointementsPreventifs ElectriqueOperation = new MethAppointementsPreventifs();
                    ElectriqueOperation.AppointmentId = itemmethAppointementsPreventifsElectrique.AppointmentId;
                    ElectriqueOperation.Description = itemmethAppointementsPreventifsElectrique.Description;                    
                    ElectriqueOperation.EndDate = itemmethAppointementsPreventifsElectrique.EndDate;
                    ElectriqueOperation.IdOperation = itemmethAppointementsPreventifsElectrique.IdOperation;                    
                    ElectriqueOperation.RecurrenceException = itemmethAppointementsPreventifsElectrique.RecurrenceException;
                    ElectriqueOperation.RecurrenceRule = itemmethAppointementsPreventifsElectrique.RecurrenceRule;                    
                    ElectriqueOperation.StartDate = itemmethAppointementsPreventifsElectrique.StartDate;
                    ElectriqueOperation.Statut = itemmethAppointementsPreventifsElectrique.Statut;
                    ElectriqueOperation.Text = itemmethAppointementsPreventifsElectrique.Text;
                    ElectriqueOperations.Add(ElectriqueOperation);
                }
            }
            return DataSourceLoader.Load(ElectriqueOperations.AsEnumerable(), loadOptions);
        }
        [HttpGet]
        public object GetMecanique(DataSourceLoadOptions loadOptions)
        {
            var methAppointementsPreventifs = _context.MethAppointementsPreventifs
                .Select(i => new {
                    i.AppointmentId,
                    i.Description,
                    i.EndDate,
                    i.StartDate,
                    i.Text,
                    i.RecurrenceException,
                    i.RecurrenceRule,
                    i.IdOperation,
                    i.Statut
                });
            // If you work with a large amount of data, consider specifying the PaginateViaPrimaryKey and PrimaryKey properties.
            // In this case, keys and data are loaded in separate queries. This can make the SQL execution plan more efficient.
            // Refer to the topic https://github.com/DevExpress/DevExtreme.AspNet.Data/issues/336.
            // loadOptions.PrimaryKey = new[] { "Id" };
            // loadOptions.PaginateViaPrimaryKey = true;
            List<int> IdsOperations = new List<int>();
            List<int> MecaniqueIdsOperations = new List<int>();
            List<MethAppointementsPreventifs> MecaniqueOperations = new List<MethAppointementsPreventifs>();

            foreach (var itemmethAppointementsPreventifs in methAppointementsPreventifs)
            {
                if(IdsOperations.Count() == 0)
                {
                    IdsOperations.Add(itemmethAppointementsPreventifs.IdOperation);
                }
                var exists = 0;
                foreach (var itemIdsOperations in IdsOperations)
                {
                    if(itemIdsOperations==itemmethAppointementsPreventifs.IdOperation)
                    {
                        exists = 1;
                    }
                }
                if(exists == 0)
                {
                    IdsOperations.Add(itemmethAppointementsPreventifs.IdOperation);
                }
            }
            foreach (var itemIdsOperations in IdsOperations)
            {
                var methOperations = _context.MethOperations
                    .Where(c=>c.Idoperation== itemIdsOperations && c.StructreConcernée == XpertHelper.CodeMecanqiue)
                    .Select(i => new {
                        i.Idoperation
                    }).ToList();
                if(methOperations.Count !=0)
                    MecaniqueIdsOperations.Add(methOperations.Last().Idoperation);
            }
            foreach (var itemMecaniqueIdsOperationss in MecaniqueIdsOperations)
            {
                var methAppointementsPreventifsMecanique = _context.MethAppointementsPreventifs
                    .Where(c => c.IdOperation == itemMecaniqueIdsOperationss)
                    .Select(i => new {
                        i.AppointmentId,
                        i.Description,
                        i.EndDate,
                        i.StartDate,
                        i.Text,
                        i.RecurrenceException,
                        i.RecurrenceRule,
                        i.Statut,
                        i.IdOperation
                    });
                foreach (var itemmethAppointementsPreventifsMecanique in methAppointementsPreventifsMecanique)
                {
                    MethAppointementsPreventifs MecaniqueOperation = new MethAppointementsPreventifs();
                    MecaniqueOperation.AppointmentId = itemmethAppointementsPreventifsMecanique.AppointmentId;
                    MecaniqueOperation.Description = itemmethAppointementsPreventifsMecanique.Description;
                    MecaniqueOperation.EndDate = itemmethAppointementsPreventifsMecanique.EndDate;
                    MecaniqueOperation.IdOperation = itemmethAppointementsPreventifsMecanique.IdOperation;
                    MecaniqueOperation.RecurrenceException = itemmethAppointementsPreventifsMecanique.RecurrenceException;
                    MecaniqueOperation.RecurrenceRule = itemmethAppointementsPreventifsMecanique.RecurrenceRule;
                    MecaniqueOperation.StartDate = itemmethAppointementsPreventifsMecanique.StartDate;
                    MecaniqueOperation.Text = itemmethAppointementsPreventifsMecanique.Text;
                    MecaniqueOperation.Statut = itemmethAppointementsPreventifsMecanique.Statut;
                    MecaniqueOperations.Add(MecaniqueOperation);
                }
            }
            return DataSourceLoader.Load(MecaniqueOperations.AsEnumerable(), loadOptions);
        }
        [HttpGet]
        public object Get(DataSourceLoadOptions loadOptions)
        {
            var methAppointementsPreventifs = _context.MethAppointementsPreventifs
                .Select(i => new {
                    i.AppointmentId,
                    i.Description,
                    i.EndDate,
                    i.StartDate,
                    i.Text,
                    i.RecurrenceException,
                    i.RecurrenceRule,
                    i.Statut,
                    i.IdOperation
                });
            // If you work with a large amount of data, consider specifying the PaginateViaPrimaryKey and PrimaryKey properties.
            // In this case, keys and data are loaded in separate queries. This can make the SQL execution plan more efficient.
            // Refer to the topic https://github.com/DevExpress/DevExtreme.AspNet.Data/issues/336.
            // loadOptions.PrimaryKey = new[] { "Id" };
            // loadOptions.PaginateViaPrimaryKey = true;

            return DataSourceLoader.Load(methAppointementsPreventifs.AsEnumerable(), loadOptions);
        }
        [HttpGet]
        public object GetIdOperationLookUp(DataSourceLoadOptions loadOptions)
        {
            var methOperations = _context.MethOperations
                .Select(i => new {
                    i.Idoperation,
                    i.Description,
                    i.NumMachine,
                    i.NumEquipement
                });
            List<PlanningOperationsModel> PlanningOperationsModelList = new List<PlanningOperationsModel>();
            foreach (var itemmethOperations in methOperations)
            {
                PlanningOperationsModel planningOperationsModel = new PlanningOperationsModel();
                planningOperationsModel.Idoperation = itemmethOperations.Idoperation;
                var machine = _context.Machines.AsNoTracking().Where(c => c.NumMachine == itemmethOperations.NumMachine).FirstOrDefault();
                var equipement = _context.MethStructureMachine.AsNoTracking().Where(c => c.Id == itemmethOperations.NumEquipement).FirstOrDefault();
                string Op="";
                if (itemmethOperations.Description == "Changement")
                    Op = "CH";
                planningOperationsModel.Description = Op + ": " +
                    machine.NomMachine + "/" + equipement.Equipement;
                PlanningOperationsModelList.Add(planningOperationsModel);
            }
            // If you work with a large amount of data, consider specifying the PaginateViaPrimaryKey and PrimaryKey properties.
            // In this case, keys and data are loaded in separate queries. This can make the SQL execution plan more efficient.
            // Refer to the topic https://github.com/DevExpress/DevExtreme.AspNet.Data/issues/336.
            // loadOptions.PrimaryKey = new[] { "Id" };
            // loadOptions.PaginateViaPrimaryKey = true;

            return DataSourceLoader.Load(PlanningOperationsModelList.AsQueryable(), loadOptions);
        }
        [HttpPost]
        public IActionResult Post(string values)
        {
            var newAppointment = new MethAppointementsPreventifs();
            JsonConvert.PopulateObject(values, newAppointment);
            var appointements = _context.MethAppointementsPreventifs
             .OrderBy(o => o.AppointmentId)
             .Select(i => new
             {
                 i.AppointmentId
             }).ToList();
            if(appointements.Count > 0)
            {
                var m = appointements.Last();
                newAppointment.AppointmentId = Convert.ToInt32(m.AppointmentId) + 1;
            }
            else
            {
                newAppointment.AppointmentId = 1;
            }
            _context.MethAppointementsPreventifs.Add(newAppointment);
            _context.SaveChanges();
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> Put(int key, string values) {
            var model = await _context.MethAppointementsPreventifs.FirstOrDefaultAsync(item => item.AppointmentId == key);
            if(model == null)
                return StatusCode(409, "Object not found");
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModel(model, valuesDict);
            XpertHelper.DateIntervention = model.StartDate;
            XpertHelper.IdOperation = model.IdOperation;
            var operation = _context.MethOperations
            .Where(c => c.Idoperation == XpertHelper.IdOperation)
            .Select(i => new
            {
                i.Idoperation,
                i.Description,
                i.Fréquence,
                i.NumEquipement,
                i.NumMachine,
                i.Unité
            }).ToList();
            var idOp = operation.Last();
            List<PlanningOperationsModel> planningOperationsModels = new List<PlanningOperationsModel>();
            foreach (var itemoperations in operation)
            {
                PlanningOperationsModel planningOperationsModel = new PlanningOperationsModel();
                planningOperationsModel.Idoperation = itemoperations.Idoperation;
                planningOperationsModel.Fréquence = itemoperations.Fréquence;
                planningOperationsModel.Unité = itemoperations.Unité;
                planningOperationsModel.Description = itemoperations.Description;
                planningOperationsModel.NumEquipement = itemoperations.NumEquipement;
                planningOperationsModel.NumMachine = itemoperations.NumMachine;
                planningOperationsModels.Add(planningOperationsModel);
            }
            var wt = await XpertHelper.CheckOtOperation(_context, planningOperationsModels,0);
            return Ok();
        }
        [HttpDelete]
        public async Task Delete(int key) {
            var model = await _context.MethAppointementsPreventifs.FirstOrDefaultAsync(item => item.AppointmentId == key);
            _context.MethAppointementsPreventifs.Remove(model);
            await _context.SaveChangesAsync();
            //deleting from suivi et planning
            var modeleSuivi = await _context.MethPlanningEtSuiviMateriel
                 .FirstOrDefaultAsync(item => item.Year == model.StartDate.Year && item.IdOperation == XpertHelper.IdOperation);
            while (!(modeleSuivi == null))
            {
                _context.MethPlanningEtSuiviMateriel.Remove(modeleSuivi);
                await _context.SaveChangesAsync();
                modeleSuivi = await _context.MethPlanningEtSuiviMateriel
                .FirstOrDefaultAsync(item => item.Year == model.StartDate.Year && item.IdOperation == XpertHelper.IdOperation);
            }
            var planning = _context.MethAppointementsPreventifs
            .Where(c => c.IdOperation == model.IdOperation && c.StartDate < model.StartDate)
            .Select(i => new
            {
                i.IdOperation,
                i.StartDate
            }).ToList();
            var idp = planning.Last();
            XpertHelper.DateIntervention = idp.StartDate;
            XpertHelper.IdOperation = idp.IdOperation;
            var operation = _context.MethOperations
            .Where(c => c.Idoperation == XpertHelper.IdOperation)
            .Select(i => new
            {
                i.Idoperation,
                i.Description,
                i.Fréquence,
                i.NumEquipement,
                i.NumMachine,
                i.Unité
            }).ToList();
            var idOp = operation.Last();
            List<PlanningOperationsModel> planningOperationsModels = new List<PlanningOperationsModel>();
            foreach (var itemoperations in operation)
            {
                PlanningOperationsModel planningOperationsModel = new PlanningOperationsModel();
                planningOperationsModel.Idoperation = itemoperations.Idoperation;
                planningOperationsModel.Fréquence = itemoperations.Fréquence;
                planningOperationsModel.Unité = itemoperations.Unité;
                planningOperationsModel.Description = itemoperations.Description;
                planningOperationsModel.NumEquipement = itemoperations.NumEquipement;
                planningOperationsModel.NumMachine = itemoperations.NumMachine;
                planningOperationsModels.Add(planningOperationsModel);
            }
            var wt = await XpertHelper.CheckOtOperation(_context, planningOperationsModels,1);
        }
        private void PopulateModel(MethAppointementsPreventifs model, IDictionary values) {
            string AppointmentId = nameof(MethAppointementsPreventifs.AppointmentId);
            string Text = nameof(MethAppointementsPreventifs.Text);
            string Description = nameof(MethAppointementsPreventifs.Description);
            string StartDate = nameof(MethAppointementsPreventifs.StartDate);
            string EndDate = nameof(MethAppointementsPreventifs.EndDate);
            if(values.Contains(AppointmentId)) {
                model.AppointmentId = Convert.ToInt32(values[AppointmentId]);
            }
            if(values.Contains(Text)) {
                model.Text = Convert.ToString(values[Text]);
            }
            if(values.Contains(Description)) {
                model.Description = Convert.ToString(values[Description]);
            }
            if(values.Contains(StartDate)) {
                model.StartDate = Convert.ToDateTime(values[StartDate]);
            }
            if(values.Contains(EndDate))
            {
                model.EndDate = Convert.ToDateTime(values[EndDate]);
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
        public async Task<IActionResult> StatutLookup(DataSourceLoadOptions loadOptions)
        {
            var lookup = from i in _context.Statut
                         orderby i.Designation
                         select new
                         {
                             Value = i.CodeStatut,
                             Text = i.Designation
                         };
            return Json(await DataSourceLoader.LoadAsync(lookup, loadOptions));
        }
    }
}