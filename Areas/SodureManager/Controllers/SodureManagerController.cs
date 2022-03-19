using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DevKbfSteel.Helpers;
namespace DevKbfSteel.Areas.SodureManager.Controllers
{
    [Area("SodureManager")]
    public class SodureManagerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult DemandeTravailsSodureRecieved()
        {
            XpertHelper.InitConsts();
            return View();
        }
        public IActionResult DemandeTravailsSodureSent()
        {
            XpertHelper.InitConsts();
            return View();
        }
        public IActionResult OrdresTravailSodureRecieved()
        {
            XpertHelper.InitConsts();
            return View();
        }
        public IActionResult OrdresTravailSodureSent()
        {
            XpertHelper.InitConsts();
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
        public IActionResult ActiviteSodureViewer(string ServiceCurrent, DateTime Datedebut, DateTime Datefin)
        {
            XpertHelper.ServiceCurrent = ServiceCurrent;
            XpertHelper.Datedebut = Datedebut;
            XpertHelper.Datefin = Datefin;
            return View();
        }        
        public IActionResult SuiviEquipementViewer(int CodeMachineReport)
        {
            XpertHelper.CodeMachineReport = CodeMachineReport;
            XpertHelper.ServiceCurrent = "Electrique";
            return View();
        }
        public IActionResult PlanningEquipementViewer(int CodeMachineReport)
        {
            XpertHelper.CodeMachineReport = CodeMachineReport;
            return View();
        }
        public IActionResult ObjectifsQualiteViewerSodure(DateTime Datedebut, DateTime Datefin)
        {
            XpertHelper.Datedebut = Datedebut;
            XpertHelper.Datefin = Datefin;
            return View();
        }
        public IActionResult RapportMensuelViewerSodure(DateTime Datedebut, DateTime Datefin)
        {
            XpertHelper.Datedebut = Datedebut;
            XpertHelper.Datefin = Datefin;
            return View();
        }
        public IActionResult GestionPersonnels()
        {
            XpertHelper.InitConsts();
            return View();
        }        
        public IActionResult SuiviTraveaux()
        {
            XpertHelper.InitConsts();
            return View();
        }        
        public IActionResult ListePDR()
        {
            XpertHelper.InitConsts();
            return View();
        }
        public IActionResult DossierMachines()
        {
            return View();
        }
        public IActionResult SchedulerPlanningPreventifs()
        {
            return View();
        }        
        public IActionResult FicheSuiviPersonnelViewer(int id)
        {
            XpertHelper.CodeEmpSuivi = id;
            return View();
        }                
        public IActionResult DemandesFourniture()
        {
            return View();
        }
        public IActionResult DemandeService()
        {
            return View();
        }
        public IActionResult Configuration()
        {
            return View();
        }
    }
}