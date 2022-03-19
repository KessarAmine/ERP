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
using DevKbfSteel.Models;
using Microsoft.AspNetCore.Http;

namespace DevKbfSteel.Controllers
{
    [Route("api/[controller]/[action]")]

    public class ProjectsController : Controller
    {

        private KBFsteelContext _context;
        public ProjectsController( KBFsteelContext context)
        {
            _context = context;
        }
        [HttpGet]
        public object GetTasks(DataSourceLoadOptions loadOptions)
        {
            var Taks = _context.PrjTasks.AsNoTracking().ToList();
            List<Object> PrjTasks = new List<Object>();
            foreach (var itemTaks in Taks)
            {
                Models.PrjTasks Task = new Models.PrjTasks();
                Task.End = itemTaks.EndDate;
                Task.ParentId = itemTaks.ParentId;
                Task.Start = itemTaks.Start;
                Task.ID = itemTaks.Id;
                Task.Title = itemTaks.Title;
                Task.Progress = (int)itemTaks.Progress;
                PrjTasks.Add(Task);
            }
            return DataSourceLoader.Load(PrjTasks.ToArray(), loadOptions) ;
        }
        [HttpGet]
        public object GetRessources(DataSourceLoadOptions loadOptions)
        {
            var ressources = _context.PrjRessources.AsNoTracking().ToList();
            return DataSourceLoader.Load(ressources.AsEnumerable(), loadOptions);
        }
        [HttpGet]
        public object GetDependencies(DataSourceLoadOptions loadOptions)
        {
            var dependecies = _context.PrjDependecies.AsNoTracking().ToList();
            return DataSourceLoader.Load(dependecies.AsEnumerable(), loadOptions);
        }
        [HttpGet]
        public object GetRessourcesAssignements(DataSourceLoadOptions loadOptions)
        {
            var ressourceAssignements = _context.PrjRessourceAssignements.AsNoTracking().ToList();
            return DataSourceLoader.Load(ressourceAssignements.AsEnumerable(), loadOptions);
        }
        [HttpGet]
        public object GetCagesTravaux(int codeService,DataSourceLoadOptions loadOptions)
        {
            List<DashboardCagesInterventions> dashboardCagesInterventions = new List<DashboardCagesInterventions>();
            var Ots = _context.OrdreTravail
                    .Where(c => c.CodeReceveur == codeService && c.DateOt.Date.Month == DateTime.Now.Month).AsNoTracking().ToList();
            for (int CodeMachine = 3; CodeMachine < 15; CodeMachine++)
            {
                var totalDuree = 0.0;
                var totalIntervention = 0;
                var cage = _context.Machines
                    .Where(c => c.NumMachine == CodeMachine).AsNoTracking().ToList();
                if(cage != null)
                {
                    foreach (var itemOts in Ots)
                    {
                        var Interventions = _context.AssOtTraveaux
                            .Where(c => c.NumOt == itemOts.NumOt && c.CodeMachine == CodeMachine).AsNoTracking().ToList();
                        if(Interventions.Count() > 0)
                        {
                            totalIntervention += Interventions.Count();
                            var rapport = _context.RapportIntervention
                                .Where(c => c.NumOt == itemOts.NumOt).AsNoTracking().ToList();
                            if (rapport.Count() > 0)
                                totalDuree += rapport.Last().DureeIntervention;
                        }
                    }
                    DashboardCagesInterventions dashboardCagesIntervention = new DashboardCagesInterventions();
                    dashboardCagesIntervention.NomCage = cage.Last().NomMachine;
                    dashboardCagesIntervention.DureeInterventions = totalDuree;
                    dashboardCagesIntervention.NombreInterventions = totalIntervention;
                    dashboardCagesInterventions.Add(dashboardCagesIntervention);
                }
            }
            return DataSourceLoader.Load(dashboardCagesInterventions.AsEnumerable(), loadOptions);
        }
        [HttpGet]
        public object GetStatutDtsMethode(DataSourceLoadOptions loadOptions)
        {
            var DemandeTravailEnAttenteMecanique = _context.DemandeTravail
                    .Where(c => c.CodeReceveur == XpertHelper.CodeMecanqiue && c.DateDt.Date.Month == DateTime.Now.Month && c.CodeStatut == 1).AsNoTracking();
            var DemandeTravailFaiteMecanique = _context.DemandeTravail
                    .Where(c => c.CodeReceveur == XpertHelper.CodeMecanqiue && c.DateDt.Date.Month == DateTime.Now.Month && c.CodeStatut == 2).AsNoTracking();
            var DemandeTravailEnAttenteElectrique = _context.DemandeTravail
                    .Where(c => c.CodeReceveur == XpertHelper.CodeElectrique && c.DateDt.Date.Month == DateTime.Now.Month && c.CodeStatut == 1).AsNoTracking();
            var DemandeTravailFaiteElectrique = _context.DemandeTravail
                    .Where(c => c.CodeReceveur == XpertHelper.CodeElectrique && c.DateDt.Date.Month == DateTime.Now.Month && c.CodeStatut == 2).AsNoTracking();
            
            DashboardStatutDts faiteMecanique = new DashboardStatutDts();
            faiteMecanique.StatutDT = "Mécanique/Faite";
            faiteMecanique.CountDt = DemandeTravailFaiteMecanique.Count();
            DashboardStatutDts enAttenteMecanique = new DashboardStatutDts();
            enAttenteMecanique.StatutDT = "Mécanique/En Attente";
            enAttenteMecanique.CountDt = DemandeTravailEnAttenteMecanique.Count();            

            DashboardStatutDts faiteElectrique= new DashboardStatutDts();
            faiteElectrique.StatutDT = "Electrique/Faite";
            faiteElectrique.CountDt = DemandeTravailFaiteElectrique.Count();
            DashboardStatutDts enAttenteEletrique = new DashboardStatutDts();
            enAttenteEletrique.StatutDT = "Electrique/En Attente";
            enAttenteEletrique.CountDt = DemandeTravailEnAttenteElectrique.Count();
            
            List<DashboardStatutDts> dashboardStatutDts = new List<DashboardStatutDts>();
            dashboardStatutDts.Add(enAttenteMecanique);
            dashboardStatutDts.Add(faiteMecanique);
            dashboardStatutDts.Add(faiteElectrique);
            dashboardStatutDts.Add(enAttenteEletrique);

            return DataSourceLoader.Load(dashboardStatutDts.AsEnumerable(), loadOptions);
        }
        [HttpGet]
        public object GetStatutDts(int codeService,DataSourceLoadOptions loadOptions)
        {
            var DemandeTravailEnAttente = _context.DemandeTravail
                    .Where(c => c.CodeReceveur == codeService && c.DateDt.Date.Month == DateTime.Now.Month && c.CodeStatut == 1).AsNoTracking();
            var DemandeTravailFaite = _context.DemandeTravail
                    .Where(c => c.CodeReceveur == codeService && c.DateDt.Date.Month == DateTime.Now.Month && c.CodeStatut == 2).AsNoTracking();
            
            DashboardStatutDts faite = new DashboardStatutDts();
            faite.StatutDT = "Faite";
            faite.CountDt = DemandeTravailFaite.Count();
            DashboardStatutDts enAttente = new DashboardStatutDts();
            enAttente.StatutDT = "En Attente";
            enAttente.CountDt = DemandeTravailEnAttente.Count();
            
            List<DashboardStatutDts> dashboardStatutDts = new List<DashboardStatutDts>();
            dashboardStatutDts.Add(enAttente);
            dashboardStatutDts.Add(faite);

            return DataSourceLoader.Load(dashboardStatutDts.AsEnumerable(), loadOptions);
        }
    }
}