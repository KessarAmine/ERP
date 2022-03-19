using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DevKbfSteel.Areas.MethodeManager.Models;
using DevKbfSteel.Entities;
using DevKbfSteel.Helpers;

namespace DevKbfSteel.Areas.MethodeManager.Controllers
{
    [Area("MethodeManager")]
    
    public class MethodeManagerController : Controller
    {
        private KBFsteelContext _context;

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ProjectManager()
        {
            XpertHelper.NavigationDrawerKey = "14";
            return View();
        }
        public IActionResult Consignation()
        {
            XpertHelper.NavigationDrawerKey = "16";
            return View();
        }
        public IActionResult Configuration()
        {
            XpertHelper.NavigationDrawerKey = "17";
            return View();
        }
        public IActionResult Analytics()
        {
            XpertHelper.NavigationDrawerKey = "15";
            return View();
        }
        public IActionResult DemandeTravailsMethodeSuivi()
        {
            XpertHelper.InitConsts();
            XpertHelper.NavigationDrawerKey = "3";
            return View();
        }
        public IActionResult DemandeTravailsMethodeRecieved()
        {
            XpertHelper.NavigationDrawerKey = "1";
            XpertHelper.InitConsts();
            return View();
        }
        public IActionResult DemandeTravailsMethodeSent()
        {
            XpertHelper.NavigationDrawerKey = "0";
            XpertHelper.InitConsts();
            return View();
        }

        public IActionResult OrdresTravailMethodeSent()
        {
            XpertHelper.NavigationDrawerKey = "2";
            XpertHelper.InitConsts();
            return View();
        }
        public IActionResult OrdresTravailsMethodeSuivi()
        {
            XpertHelper.NavigationDrawerKey = "4";
            XpertHelper.InitConsts();
            return View();
        }
        public IActionResult PdrSurveille()
        {
            XpertHelper.NavigationDrawerKey = "11";
            return View();
        }
        public IActionResult ListePDR()
        {
            XpertHelper.NavigationDrawerKey = "10";
            return View();
        }
        public IActionResult DossierMachines()
        {
            XpertHelper.NavigationDrawerKey = "6";
            return View();
        }
        public IActionResult GestionPlannification()
        {
            XpertHelper.NavigationDrawerKey = "8";
            return View();
        }
        public IActionResult DemandesFourniture()
        {
            XpertHelper.NavigationDrawerKey = "12";
            return View();
        }
        public IActionResult GestionPersonnels()
        {
            XpertHelper.NavigationDrawerKey = "9";
            return View();
        }        
        public IActionResult SuiviTraveaux()
        {
            XpertHelper.NavigationDrawerKey = "5";
            return View();
        }
        public IActionResult DemandeService()
        {
            XpertHelper.NavigationDrawerKey = "13";
            return View();
        }
        public IActionResult CheckList()
        {
            XpertHelper.NavigationDrawerKey = "7";
            return View();
        }
        public async Task<IActionResult> PlannificationMensuelleViewerAsync(string Month, string Year)
        {
            XpertHelper.MonthYeaRtoDate(Month, Year);
            await XpertHelper.GetPlanningMenseulleTemp(_context);
            return View();
        }
        public MethodeManagerController(KBFsteelContext context)
        {
            _context = context;
        }
        [HttpPost]
        public async Task<IActionResult> PostManualAsync(MethAppointementsPreventifs userInfo)
        {
            XpertHelper.DateIntervention = userInfo.StartDate;
            XpertHelper.IdOperation = userInfo.IdOperation;
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
            var Equipement = _context.MethStructureMachine
                .Where(c => c.Id == idOp.NumEquipement)
                .Select(i => new
                {
                    i.Equipement
                }).ToList().Last();
            XpertHelper.IdOperation = idOp.Idoperation;
            List<PlanningOperationsModel> planningOperationsModels = new List<PlanningOperationsModel>();
            foreach (var itemoperations in operation)
            {
                PlanningOperationsModel planningOperationsModel = new PlanningOperationsModel();
                planningOperationsModel.Idoperation = itemoperations.Idoperation;
                planningOperationsModel.Fréquence = itemoperations.Fréquence;
                planningOperationsModel.Unité = itemoperations.Unité;
                planningOperationsModel.Description = itemoperations.Description;
                planningOperationsModel.NumEquipement = itemoperations.NumEquipement;
                planningOperationsModel.Statut = 1;//En Attente
                planningOperationsModel.NumMachine = itemoperations.NumMachine;
                planningOperationsModels.Add(planningOperationsModel);
            }
            var wt = await XpertHelper.CheckOtOperation(_context, planningOperationsModels,0);
            return RedirectToAction("GestionPlannification", "MethodeManager", new { area = "MethodeManager" });
        }
        public IActionResult SuiviEquipementViewer(int CodeMachineReport)
        {
            XpertHelper.CodeMachineReport = CodeMachineReport;
            XpertHelper.ServiceCurrent = "Methodes";
            return View();
        }
        public IActionResult PlanningEquipementViewer(int CodeMachineReport)
        {
            XpertHelper.CodeMachineReport = CodeMachineReport;
            XpertHelper.ServiceCurrent = "Methodes";
            return View();
        }
        public IActionResult ConsignationMethodesViewer(int id)
        {
            XpertHelper.ConsignationMethodes = id;
            return View();
        }
        public IActionResult DemandeTravailViewer(int id)
        {
            XpertHelper.NumDt = id;
            return View();
        }
        public IActionResult OrdreTravailViewer(int id)
        {
            XpertHelper.NumOt = id;
            return View();
        }
        public IActionResult DemandeServiceViewer(int id)
        {
            XpertHelper.NumDemandeService = id;
            return View();
        }
        public IActionResult DemandeFournitureViewer(int id)
        {
            XpertHelper.NumDemandeFourniture = id;
            return View();
        }
        public IActionResult FicheSuiviPersonnelViewer(int id)
        {
            XpertHelper.CodeEmpSuivi = id;
            return View();
        }
        public IActionResult ActiviteMecaniqueViewer(string ServiceCurrent, DateTime Datedebut, DateTime Datefin)
        {
            XpertHelper.ServiceCurrent = ServiceCurrent;
            XpertHelper.Datedebut = Datedebut;
            XpertHelper.Datefin = Datefin;
            return View();
        }
        public IActionResult RapportMensuelViewerMecanique(DateTime Datedebut, DateTime Datefin)
        {
            XpertHelper.Datedebut = Datedebut;
            XpertHelper.Datefin = Datefin;
            return View();
        }
        public IActionResult ObjectifsQualiteViewerMecanique(DateTime Datedebut, DateTime Datefin)
        {
            XpertHelper.Datedebut = Datedebut;
            XpertHelper.Datefin = Datefin;
            return View();
        }
        public IActionResult CheckListViewer(int NumCheckList)
        {
            XpertHelper.NumCheckList = NumCheckList;
            return View();
        }
        public IActionResult FicheArticleViewer(int id)
        {
            XpertHelper.FicheArticlePdr = id;
            return View();
        }
    }
}
