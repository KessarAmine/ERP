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

    public class DashboardController : Controller
    {

        private KBFsteelContext _context;
        public DashboardController( KBFsteelContext context)
        {
            _context = context;
        }
        [HttpGet]
        public object GetMachinesTravauxAnalytics(int Codemaintenance,DataSourceLoadOptions loadOptions)
        {
            List<AnalyticsTravauxMachines> AnalyticsTravauxMachines = new List<AnalyticsTravauxMachines>();
            var machines = _context.Machines.AsNoTracking().ToList();
            List<int> OtsPreventif = new List<int>();
            List<int> OtsCorrectif = new List<int>();
            foreach (var itemmachines in machines)
            {
                int toADD = 0;
                AnalyticsTravauxMachines AnalyticsTravauxMachine = new AnalyticsTravauxMachines();
                AnalyticsTravauxMachine.NomMachine = itemmachines.NomMachine;
                AnalyticsTravauxMachine.DureeInterventionsCorrectif = 0.0;
                AnalyticsTravauxMachine.DureeInterventionsPréventif = 0.0;
                AnalyticsTravauxMachine.PourcentageDureeInterventionsCorrectif = 0.0;
                AnalyticsTravauxMachine.PourcentageDureeInterventionsPréventif = 0.0;
                AnalyticsTravauxMachine.PourcentageCumuleDureeInterventionsCorrectif = 0.0;
                AnalyticsTravauxMachine.PourcentageCumuleDureeInterventionsPréventif = 0.0;
                var Interventions = _context.AssOtTraveaux.Where(c => c.CodeMachine == itemmachines.NumMachine).AsNoTracking().ToList();
                foreach (var itemInterventions in Interventions)
                {
                    var Ots = _context.OrdreTravail.Where(c => c.DateOt.Date.Year == DateTime.Now.Year && c.NumOt == itemInterventions.NumOt).AsNoTracking().ToList();
                    foreach (var itemOts in Ots)
                    {
                        if (itemOts.CodeMaintenance == Convert.ToBoolean(0))
                        {
                            OtsCorrectif.Add(itemOts.NumOt);
                        }
                        else
                        {
                            OtsPreventif.Add(itemOts.NumOt);
                        }
                    }
                }
                foreach (var itemOtsCorrectif in OtsCorrectif)
                {
                    var rapportCorrectif = _context.RapportIntervention.Where(c => c.NumOt == itemOtsCorrectif).AsNoTracking().ToList();
                    if (rapportCorrectif.Count > 0)
                    {
                        toADD = 1; 
                        AnalyticsTravauxMachine.DureeInterventionsCorrectif += rapportCorrectif.Last().DureeIntervention;
                    }
                }
                foreach (var itemOtsPreventif in OtsPreventif)
                {
                    var rapportPreventif = _context.RapportIntervention.Where(c => c.NumOt == itemOtsPreventif).AsNoTracking().ToList();
                    if (rapportPreventif.Count > 0)
                    {
                        toADD = 1;
                        AnalyticsTravauxMachine.DureeInterventionsPréventif += rapportPreventif.Last().DureeIntervention;
                    }
                }
                if(toADD == 1)
                {
                    OtsCorrectif.Clear();
                    OtsPreventif.Clear();
                    AnalyticsTravauxMachines.Add(AnalyticsTravauxMachine);
                }
            }
            if(Codemaintenance == 0)
                AnalyticsTravauxMachines = AnalyticsTravauxMachines.OrderByDescending(d => d.DureeInterventionsCorrectif).ToList();
            if(Codemaintenance == 1)
                AnalyticsTravauxMachines = AnalyticsTravauxMachines.OrderByDescending(d => d.DureeInterventionsPréventif).ToList();
            //Sort from large to small
            //Calcul Totaux 
            var TotalCorrectif = 0.0;
            var TotalPreventif = 0.0;
            foreach (var itemAnalyticsTravauxMachines in AnalyticsTravauxMachines)
            {
                TotalCorrectif += itemAnalyticsTravauxMachines.DureeInterventionsCorrectif;
                TotalPreventif += itemAnalyticsTravauxMachines.DureeInterventionsPréventif;
            }
            //Calcul Pourcentage 
            foreach (var itemAnalyticsTravauxMachines in AnalyticsTravauxMachines)
            {
                itemAnalyticsTravauxMachines.PourcentageDureeInterventionsCorrectif = (double)System.Math.Round(itemAnalyticsTravauxMachines.DureeInterventionsCorrectif / TotalCorrectif * 100, 2, MidpointRounding.ToEven);
                itemAnalyticsTravauxMachines.PourcentageDureeInterventionsPréventif = (double)System.Math.Round(itemAnalyticsTravauxMachines.DureeInterventionsPréventif / TotalPreventif *100, 2, MidpointRounding.ToEven); 
            }
            //Calcul Pourcentage Cumule
            for (int i = 0; i < AnalyticsTravauxMachines.Count(); i++)
            {
                if (i < 1)
                {
                    AnalyticsTravauxMachines[i].PourcentageCumuleDureeInterventionsCorrectif = AnalyticsTravauxMachines[i].PourcentageDureeInterventionsCorrectif;
                    AnalyticsTravauxMachines[i].PourcentageCumuleDureeInterventionsPréventif = AnalyticsTravauxMachines[i].PourcentageDureeInterventionsPréventif;
                }
                else
                {
                    
                    AnalyticsTravauxMachines[i].PourcentageCumuleDureeInterventionsCorrectif = (double)System.Math.Round((decimal)(AnalyticsTravauxMachines[i].PourcentageDureeInterventionsCorrectif + AnalyticsTravauxMachines[i - 1].PourcentageCumuleDureeInterventionsCorrectif), 2);
                    AnalyticsTravauxMachines[i].PourcentageCumuleDureeInterventionsPréventif = (double)System.Math.Round((decimal)(AnalyticsTravauxMachines[i].PourcentageDureeInterventionsPréventif + AnalyticsTravauxMachines[i - 1].PourcentageCumuleDureeInterventionsPréventif), 2);
                }
            }
            return DataSourceLoader.Load(AnalyticsTravauxMachines.AsEnumerable(), loadOptions);
        }
        [HttpGet]
        public object GetCagesTravauxMethode(DataSourceLoadOptions loadOptions)
        {
            List<DashboardCagesInterventionsMethodes> dashboardCagesInterventionsMethodes = new List<DashboardCagesInterventionsMethodes>();
            var OtsElectrique = _context.OrdreTravail
                    .Where(c => c.CodeReceveur == XpertHelper.CodeElectrique && c.DateOt.Date.Month == DateTime.Now.Month).AsNoTracking().ToList();
             var OtsMecanique = _context.OrdreTravail
                    .Where(c => c.CodeReceveur == XpertHelper.CodeMecanqiue && c.DateOt.Date.Month == DateTime.Now.Month).AsNoTracking().ToList();
            for (int CodeMachine = 3; CodeMachine < 15; CodeMachine++)
            {
                var totalDureeMecanique = 0.0;
                var totalInterventionMecanique = 0;
                var totalDureeElectrique = 0.0;
                var totalInterventionElectrique = 0;
                var cage = _context.Machines
                    .Where(c => c.NumMachine == CodeMachine).AsNoTracking().ToList();
                if(cage != null)
                {
                    foreach (var itemOtsMecanique in OtsMecanique)
                    {
                        var Interventions = _context.AssOtTraveaux
                            .Where(c => c.NumOt == itemOtsMecanique.NumOt && c.CodeMachine == CodeMachine).AsNoTracking().ToList();
                        if(Interventions.Count() > 0)
                        {
                            totalInterventionMecanique += Interventions.Count();
                            var rapport = _context.RapportIntervention
                                .Where(c => c.NumOt == itemOtsMecanique.NumOt).AsNoTracking().ToList();
                            if (rapport.Count() > 0)
                                totalDureeMecanique += rapport.Last().DureeIntervention;
                        }
                    }
                    foreach (var itemOtsElectrique in OtsElectrique)
                    {
                        var Interventions = _context.AssOtTraveaux
                            .Where(c => c.NumOt == itemOtsElectrique.NumOt && c.CodeMachine == CodeMachine).AsNoTracking().ToList();
                        if(Interventions.Count() > 0)
                        {
                            totalInterventionElectrique += Interventions.Count();
                            var rapport = _context.RapportIntervention
                                .Where(c => c.NumOt == itemOtsElectrique.NumOt).AsNoTracking().ToList();
                            if (rapport.Count() > 0)
                                totalDureeElectrique += rapport.Last().DureeIntervention;
                        }
                    }
                    DashboardCagesInterventionsMethodes dashboardCagesInterventionsMethode = new DashboardCagesInterventionsMethodes();
                    dashboardCagesInterventionsMethode.NomCage = cage.Last().NomMachine;
                    dashboardCagesInterventionsMethode.DureeInterventionsElectrique = totalDureeElectrique;
                    dashboardCagesInterventionsMethode.DureeInterventionsMecanique = totalDureeMecanique;
                    dashboardCagesInterventionsMethode.NombreInterventionsElectrique = totalInterventionElectrique;
                    dashboardCagesInterventionsMethode.NombreInterventionsMecanique = totalInterventionMecanique;
                    dashboardCagesInterventionsMethodes.Add(dashboardCagesInterventionsMethode);
                }
            }
            return DataSourceLoader.Load(dashboardCagesInterventionsMethodes.AsEnumerable(), loadOptions);
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
        [HttpGet]
        public object GetTonnageCages(DataSourceLoadOptions loadOptions)
        {
            var LimiteTonnageCages = _context.ConfigExploitation
                 .AsNoTracking()
                 .Select(i => new
                 {
                     i.LimiteCage1,
                     i.LimiteCage2,
                     i.LimiteCage3,
                     i.LimiteCage4,
                     i.LimiteCage5,
                     i.LimiteCage6,
                     i.LimiteCage7,
                     i.LimiteCage8,
                     i.LimiteCage9,
                     i.LimiteCage10,
                     i.LimiteCage11,
                     i.LimiteCage12,
                     i.LimiteCage13
                 }).ToList();
            List<DashboardTonnagesCages> dashboardTonnagesCages = new List<DashboardTonnagesCages>();

            for (int CodeMachine = 3; CodeMachine < 15; CodeMachine++)
            {
                var tonnagesCages = _context.ProdTonnagesCages.AsNoTracking().ToList();
                if (tonnagesCages != null)
                {
                    var data = tonnagesCages.Last();
                    DashboardTonnagesCages dashboardTonnagesCage = new DashboardTonnagesCages();
                    var cage = _context.Machines
                        .Where(c => c.NumMachine == CodeMachine).AsNoTracking().ToList().Last();
                    dashboardTonnagesCage.NomCage = cage.NomMachine;
                    dashboardTonnagesCage.color = "#6effcc";
                    if (cage.NomMachine.Equals("Cage01"))
                    {
                        if (data.Cage01.Contains("-"))
                        {
                            var splited = data.Cage01.Split("-");
                            dashboardTonnagesCage.TonnageCage = double.Parse(splited[1]);
                        }
                        else
                        {
                            dashboardTonnagesCage.TonnageCage = Convert.ToDouble(data.Cage01.ToString());
                        }
                        if (LimiteTonnageCages.Last().LimiteCage1 != null)
                        {
                            if (dashboardTonnagesCage.TonnageCage >= LimiteTonnageCages.Last().LimiteCage1)
                            {
                                dashboardTonnagesCage.color = "#ff756e";
                            }
                        }
                    }
                    if (cage.NomMachine.Equals("Cage02"))
                    {
                        if (data.Cage02.Contains("-"))
                        {
                            var splited = data.Cage02.Split("-");
                            dashboardTonnagesCage.TonnageCage = double.Parse(splited[1]);
                        }
                        else
                        {
                            dashboardTonnagesCage.TonnageCage = Convert.ToDouble(data.Cage02.ToString());
                        }
                        if (LimiteTonnageCages.Last().LimiteCage2 != null)
                        {
                            if (dashboardTonnagesCage.TonnageCage >= LimiteTonnageCages.Last().LimiteCage2)
                            {
                                dashboardTonnagesCage.color = "#ff756e";
                            }
                        }
                    }
                    if (cage.NomMachine.Equals("Cage03"))
                    {
                        if (data.Cage03.Contains("-"))
                        {
                            var splited = data.Cage03.Split("-");
                            dashboardTonnagesCage.TonnageCage = double.Parse(splited[1]);
                        }
                        else
                        {
                            dashboardTonnagesCage.TonnageCage = Convert.ToDouble(data.Cage03.ToString());
                        }
                        if (LimiteTonnageCages.Last().LimiteCage3 != null)
                        {
                            if (dashboardTonnagesCage.TonnageCage >= LimiteTonnageCages.Last().LimiteCage3)
                            {
                                dashboardTonnagesCage.color = "#ff756e";
                            }
                        }
                    }
                    if (cage.NomMachine.Equals("Cage04"))
                    {
                        if (data.Cage04.Contains("-"))
                        {
                            var splited = data.Cage04.Split("-");
                            dashboardTonnagesCage.TonnageCage = double.Parse(splited[1]);
                        }
                        else
                        {
                            dashboardTonnagesCage.TonnageCage = Convert.ToDouble(data.Cage04.ToString());
                        }
                        if (LimiteTonnageCages.Last().LimiteCage4 != null)
                        {
                            if (dashboardTonnagesCage.TonnageCage >= LimiteTonnageCages.Last().LimiteCage4)
                            {
                                dashboardTonnagesCage.color = "#ff756e";
                            }
                        }
                    }
                    if (cage.NomMachine.Equals("Cage05"))
                    {
                        if (data.Cage05.Contains("-"))
                        {
                            var splited = data.Cage05.Split("-");
                            dashboardTonnagesCage.TonnageCage = double.Parse(splited[1]);
                        }
                        else
                        {
                            dashboardTonnagesCage.TonnageCage = Convert.ToDouble(data.Cage05.ToString());
                        }
                        if (LimiteTonnageCages.Last().LimiteCage5 != null)
                        {
                            if (dashboardTonnagesCage.TonnageCage >= LimiteTonnageCages.Last().LimiteCage5)
                            {
                                dashboardTonnagesCage.color = "#ff756e";
                            }
                        }
                    }
                    if (cage.NomMachine.Equals("Cage06_07"))
                    {
                        if (data.Cage06.Contains("-"))
                        {
                            var splited = data.Cage06.Split("-");
                            dashboardTonnagesCage.TonnageCage = double.Parse(splited[1]);
                        }
                        else
                        {
                            dashboardTonnagesCage.TonnageCage = Convert.ToDouble(data.Cage06.ToString());
                        }
                        if (LimiteTonnageCages.Last().LimiteCage6 != null)
                        {
                            if (dashboardTonnagesCage.TonnageCage >= LimiteTonnageCages.Last().LimiteCage6)
                            {
                                dashboardTonnagesCage.color = "#ff756e";
                            }
                        }
                    }
                    if (cage.NomMachine.Equals("Cage08"))
                    {
                        if (data.Cage08.Contains("-"))
                        {
                            var splited = data.Cage08.Split("-");
                            dashboardTonnagesCage.TonnageCage = double.Parse(splited[1]);
                        }
                        else
                        {
                            dashboardTonnagesCage.TonnageCage = Convert.ToDouble(data.Cage08.ToString());
                        }
                        if (LimiteTonnageCages.Last().LimiteCage8 != null)
                        {
                            if (dashboardTonnagesCage.TonnageCage >= LimiteTonnageCages.Last().LimiteCage8)
                            {
                                dashboardTonnagesCage.color = "#ff756e";
                            }
                        }
                    }
                    if (cage.NomMachine.Equals("Cage09"))
                    {
                        if (data.Cage09.Contains("-"))
                        {
                            var splited = data.Cage09.Split("-");
                            dashboardTonnagesCage.TonnageCage = double.Parse(splited[1]);
                        }
                        else
                        {
                            dashboardTonnagesCage.TonnageCage = Convert.ToDouble(data.Cage09.ToString());
                        }
                        if (LimiteTonnageCages.Last().LimiteCage9 != null)
                        {
                            if (dashboardTonnagesCage.TonnageCage >= LimiteTonnageCages.Last().LimiteCage9)
                            {
                                dashboardTonnagesCage.color = "#ff756e";
                            }
                        }
                    }
                    if (cage.NomMachine.Equals("Cage10"))
                    {
                        if (data.Cage10.Contains("-"))
                        {
                            var splited = data.Cage10.Split("-");
                            dashboardTonnagesCage.TonnageCage = double.Parse(splited[1]);
                        }
                        else
                        {
                            dashboardTonnagesCage.TonnageCage = Convert.ToDouble(data.Cage10.ToString());
                        }
                        if (LimiteTonnageCages.Last().LimiteCage10 != null)
                        {
                            if (dashboardTonnagesCage.TonnageCage >= LimiteTonnageCages.Last().LimiteCage10)
                            {
                                dashboardTonnagesCage.color = "#ff756e";
                            }
                        }
                    }
                    if (cage.NomMachine.Equals("Cage11"))
                    {
                        if (data.Cage11.Contains("-"))
                        {
                            var splited = data.Cage11.Split("-");
                            dashboardTonnagesCage.TonnageCage = double.Parse(splited[1]);
                        }
                        else
                        {
                            dashboardTonnagesCage.TonnageCage = Convert.ToDouble(data.Cage11.ToString());
                        }
                        if (LimiteTonnageCages.Last().LimiteCage11 != null)
                        {
                            if (dashboardTonnagesCage.TonnageCage >= LimiteTonnageCages.Last().LimiteCage11)
                            {
                                dashboardTonnagesCage.color = "#ff756e";
                            }
                        }
                    }
                    if (cage.NomMachine.Equals("Cage12"))
                    {
                        if (data.Cage12.Contains("-"))
                        {
                            var splited = data.Cage12.Split("-");
                            dashboardTonnagesCage.TonnageCage = double.Parse(splited[1]);
                        }
                        else
                        {
                            dashboardTonnagesCage.TonnageCage = Convert.ToDouble(data.Cage12.ToString());
                        }
                        if (LimiteTonnageCages.Last().LimiteCage12 != null)
                        {
                            if (dashboardTonnagesCage.TonnageCage >= LimiteTonnageCages.Last().LimiteCage12)
                            {
                                dashboardTonnagesCage.color = "#ff756e";
                            }
                        }
                    }
                    if (cage.NomMachine.Equals("Cage13"))
                    {
                        if (data.Cage13.Contains("-"))
                        {
                            var splited = data.Cage13.Split("-");
                            dashboardTonnagesCage.TonnageCage = double.Parse(splited[1]);
                        }
                        else
                        {
                            dashboardTonnagesCage.TonnageCage = Convert.ToDouble(data.Cage13.ToString());
                        }
                        if (LimiteTonnageCages.Last().LimiteCage13 != null)
                        {
                            if (dashboardTonnagesCage.TonnageCage >= LimiteTonnageCages.Last().LimiteCage13)
                            {
                                dashboardTonnagesCage.color = "#ff756e";
                            }
                        }
                    }
                    dashboardTonnagesCages.Add(dashboardTonnagesCage);
                }
            }
            return DataSourceLoader.Load(dashboardTonnagesCages.AsEnumerable(), loadOptions);
        }
        [HttpGet]
        public object GetArretService(DataSourceLoadOptions loadOptions)
        {
            List<DashboardArretsService> dashboardArretsServices = new List<DashboardArretsService>();
            var arrets = _context.ProdSuiviArretsServices
                    .Where(c => c.DateArret.Date.Month == 11).AsNoTracking().Select(i => new
                    {
                        i.Hi,
                        i.Hh,
                        i.Kk,
                        i.Dg,
                        i.Eb,
                        i.Mb,
                        i.Ps,
                        i.Sonalgaz,
                        i.Tf
                    });
            DashboardArretsService dashboardArretsServiceHI = new DashboardArretsService();
            dashboardArretsServiceHI.NomService = "HI";
            dashboardArretsServiceHI.TotalArret = (double)arrets.Select(c => c.Hi).Sum();

            DashboardArretsService dashboardArretsServiceHH = new DashboardArretsService();
            dashboardArretsServiceHH.NomService = "HH";
            dashboardArretsServiceHH.TotalArret = (double)arrets.Select(c => c.Hh).Sum();

            DashboardArretsService dashboardArretsServiceKK = new DashboardArretsService();
            dashboardArretsServiceKK.NomService = "KK";
            dashboardArretsServiceKK.TotalArret = (double)arrets.Select(c => c.Kk).Sum();

            DashboardArretsService dashboardArretsServicePS = new DashboardArretsService();
            dashboardArretsServicePS.NomService = "PS";
            dashboardArretsServicePS.TotalArret = (double)arrets.Select(c => c.Ps).Sum();

            DashboardArretsService dashboardArretsServiceTF = new DashboardArretsService();
            dashboardArretsServiceTF.NomService = "TF";
            dashboardArretsServiceTF.TotalArret = (double)arrets.Select(c => c.Tf).Sum();

            DashboardArretsService dashboardArretsServiceEB = new DashboardArretsService();
            dashboardArretsServiceEB.NomService = "EB";
            dashboardArretsServiceEB.TotalArret = (double)arrets.Select(c => c.Eb).Sum();

            DashboardArretsService dashboardArretsServiceMB = new DashboardArretsService();
            dashboardArretsServiceMB.NomService = "MB";
            dashboardArretsServiceMB.TotalArret = (double)arrets.Select(c => c.Mb).Sum();

            DashboardArretsService dashboardArretsServiceSonalgaz = new DashboardArretsService();
            dashboardArretsServiceSonalgaz.NomService = "Sonalgaz";
            dashboardArretsServiceSonalgaz.TotalArret = (double)arrets.Select(c => c.Sonalgaz).Sum();

            DashboardArretsService dashboardArretsServiceDG = new DashboardArretsService();
            dashboardArretsServiceDG.NomService = "DG";
            dashboardArretsServiceDG.TotalArret = (double)arrets.Select(c => c.Dg).Sum();

            dashboardArretsServices.Add(dashboardArretsServiceHI);
            dashboardArretsServices.Add(dashboardArretsServiceHH);
            dashboardArretsServices.Add(dashboardArretsServiceKK);
            dashboardArretsServices.Add(dashboardArretsServicePS);
            dashboardArretsServices.Add(dashboardArretsServiceTF);
            dashboardArretsServices.Add(dashboardArretsServiceEB);
            dashboardArretsServices.Add(dashboardArretsServiceMB);
            dashboardArretsServices.Add(dashboardArretsServiceSonalgaz);
            dashboardArretsServices.Add(dashboardArretsServiceDG);

            return DataSourceLoader.Load(dashboardArretsServices.AsEnumerable(), loadOptions);
        }
    }
}