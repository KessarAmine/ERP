using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DevKbfSteel.Helpers;
namespace DevKbfSteel.Areas.MecaniqueManager.Controllers
{
    [Area("ElectriqueManager")]
    public class ElectriqueManagerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult DemandeTravailsElectriqueRecieved()
        {
            XpertHelper.InitConsts();
            XpertHelper.NavigationDrawerKey = "1";
            return View();
        }
        public IActionResult DemandeTravailsElectriqueSent()
        {
            XpertHelper.InitConsts();
            XpertHelper.NavigationDrawerKey = "0";
            return View();
        }
        public IActionResult OrdresTravailElectriqueRecieved()
        {
            XpertHelper.InitConsts();
            XpertHelper.NavigationDrawerKey = "3";
            return View();
        }
        public IActionResult OrdresTravailElectriqueSent()
        {
            XpertHelper.InitConsts();
            XpertHelper.NavigationDrawerKey = "2";
            return View();
        }

        public IActionResult CheckList()
        {
            XpertHelper.NavigationDrawerKey = "8";
            return View();
        }

        public IActionResult PdrSurveille()
        {
            XpertHelper.NavigationDrawerKey = "10";
            return View();
        }
        public IActionResult GestionPersonnels()
        {
            XpertHelper.NavigationDrawerKey = "4";
            XpertHelper.InitConsts();
            return View();
        }        
        public IActionResult SuiviTraveaux()
        {
            XpertHelper.NavigationDrawerKey = "5";
            XpertHelper.InitConsts();
            return View();
        }        
        public IActionResult ListePDR()
        {
            XpertHelper.NavigationDrawerKey = "9";
            XpertHelper.InitConsts();
            return View();
        }
        public IActionResult DossierMachines()
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
        public IActionResult Configuration()
        {
            XpertHelper.NavigationDrawerKey = "15";
            return View();
        }
        public IActionResult Consignation()
        {
            XpertHelper.NavigationDrawerKey = "14";
            return View();
        }
        public IActionResult FicheArticleViewer(int id)
        {
            XpertHelper.FicheArticlePdr = id;
            return View();
        }
        public IActionResult ActiviteElectriqueViewer(string ServiceCurrent, DateTime Datedebut, DateTime Datefin)
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
        public IActionResult ConsignationElectriqueViewer(int id)
        {
            XpertHelper.ConsignationElectrique = id;
            return View();
        }
        public IActionResult PlanningEquipementViewer(int CodeMachineReport)
        {
            XpertHelper.CodeMachineReport = CodeMachineReport;
            return View();
        }
        public IActionResult ObjectifsQualiteViewerElectrique(DateTime Datedebut, DateTime Datefin)
        {
            XpertHelper.Datedebut = Datedebut;
            XpertHelper.Datefin = Datefin;
            return View();
        }
        public IActionResult RapportMensuelViewerElectrique(DateTime Datedebut, DateTime Datefin)
        {
            XpertHelper.Datedebut = Datedebut;
            XpertHelper.Datefin = Datefin;
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
        public IActionResult CheckListViewer(int NumCheckList)
        {
            XpertHelper.NumCheckList = NumCheckList;
            return View();
        }
        public IActionResult FicheSuiviPersonnelViewer(int id)
        {
            XpertHelper.CodeEmpSuivi = id;
            XpertHelper.ServiceCurrent = "Electrique";
            return View();
        }

    }
}