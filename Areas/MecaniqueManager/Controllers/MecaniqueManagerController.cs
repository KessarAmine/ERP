using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DevKbfSteel.Helpers;
namespace DevKbfSteel.Areas.MecaniqueManager.Controllers
{
    [Area("MecaniqueManager")]
    public class MecaniqueManagerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult DemandeTravailsMecaniqueRecieved()
        {
            XpertHelper.InitConsts();
            XpertHelper.NavigationDrawerKey = "1";
            return View();
        }
        public IActionResult DemandeTravailsMecaniqueSent()
        {
            XpertHelper.InitConsts();
            XpertHelper.NavigationDrawerKey = "0";
            return View();
        }
        public IActionResult PdrSurveille()
        {
            XpertHelper.NavigationDrawerKey = "10";
            return View();
        }
        public IActionResult OrdresTravailMecaniqueRecieved()
        {
            XpertHelper.InitConsts();
            XpertHelper.NavigationDrawerKey = "3";
            return View();
        }
        public IActionResult OrdresTravailMecaniqueSent()
        {
            XpertHelper.InitConsts();
            XpertHelper.NavigationDrawerKey = "2";
            return View();
        }

        public IActionResult GestionPersonnels()
        {
            XpertHelper.InitConsts();
            XpertHelper.NavigationDrawerKey = "4";
            return View();
        }        
        public IActionResult SuiviTraveaux()
        {
            XpertHelper.InitConsts();
            XpertHelper.NavigationDrawerKey = "5";
            return View();
        }        
        public IActionResult ListePDR()
        {
            XpertHelper.InitConsts();
            XpertHelper.NavigationDrawerKey = "9";
            return View();
        }
        public IActionResult DossierMachines()
        {
            XpertHelper.NavigationDrawerKey = "7";
            return View();
        }
        public IActionResult DossierMachinesTemp()
        {
            XpertHelper.NavigationDrawerKey = "7";
            return View();
        }
        public IActionResult SchedulerPlanningPreventifs()
        {
            XpertHelper.NavigationDrawerKey = "6";
            return View();
        }  
        public IActionResult DemandesFourniture()
        {
            XpertHelper.NavigationDrawerKey = "12";
            return View();
        }
        public IActionResult DemandeService()
        {
            XpertHelper.NavigationDrawerKey = "13";
            return View();
        }
        public IActionResult Consignation()
        {
            XpertHelper.NavigationDrawerKey = "14";
            return View();
        }
        public IActionResult Configuration()
        {
            XpertHelper.NavigationDrawerKey = "15";
            return View();
        }
        public IActionResult CheckList()
        {
            XpertHelper.NavigationDrawerKey = "8";
            return View();
        }
        public IActionResult FicheArticleViewer(int id)
        {
            XpertHelper.FicheArticlePdr = id;
            return View();
        }
        public IActionResult ConsignationMecaniqueViewer(int id)
        {
            XpertHelper.ConsignationMecanique = id;
            return View();
        }
        public IActionResult FicheSuiviPersonnelViewer(int id)
        {
            XpertHelper.CodeEmpSuivi = id;
            return View();
        }
        public IActionResult CheckListViewer(int NumCheckList)
        {
            XpertHelper.NumCheckList = NumCheckList;
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
        public IActionResult ActiviteMecaniqueViewer(string ServiceCurrent, DateTime Datedebut, DateTime Datefin)
        {
            XpertHelper.ServiceCurrent = ServiceCurrent;
            XpertHelper.Datedebut = Datedebut;
            XpertHelper.Datefin = Datefin;
            return View();
        }
        public IActionResult SuiviEquipementViewer(int CodeMachineReport)
        {
            XpertHelper.CodeMachineReport = CodeMachineReport;
            XpertHelper.ServiceCurrent = "Mécanique";
            return View();
        }
        public IActionResult PlanningEquipementViewer(int CodeMachineReport)
        {
            XpertHelper.CodeMachineReport = CodeMachineReport;
            return View();
        }
        public IActionResult ObjectifsQualiteViewerMecanique(DateTime Datedebut, DateTime Datefin)
        {
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
    }
}
