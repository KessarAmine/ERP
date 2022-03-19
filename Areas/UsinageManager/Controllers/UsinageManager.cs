using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DevKbfSteel.Helpers;

namespace DevKbfSteel.Areas.UsinageManager.Controllers
{
    [Area("UsinageManager")]

    public class UsinageManagerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult DemandeTravailsUsinageRecieved()
        {
            return View();
        }        
        public IActionResult CylindrePreprocessing()
        {
            return View();
        }
        public IActionResult DemandeTravailsUsinageSent()
        {
            return View();
        }
        public IActionResult OrdresTravailUsinageRecieved()
        {
            return View();
        }
        public IActionResult OrdresTravailUsinageSent()
        {
            return View();
        }
        public IActionResult DemandeTravailViewer(int id)
        {
            XpertHelper.NumDt = id;
            return View();
        }
        public IActionResult ConsignationUsinageViewer(int id)
        {
            XpertHelper.ConsignationUsinage = id;
            return View();
        }
        public IActionResult OrdreTravailViewer(int id)
        {
            XpertHelper.NumOt = id;
            return View();
        }

        public IActionResult ObjectifsQualiteViewerUsinage()
        {
            return View();
        }
        public IActionResult RapportMensuelViewerUsinage()
        {
            return View();
        }
        public IActionResult ActiviteUsinageViewer(string ServiceCurrent, DateTime Datedebut, DateTime Datefin)
        {
            XpertHelper.ServiceCurrent = ServiceCurrent;
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
        public IActionResult Consignation()
        {
            return View();
        }
        public IActionResult Configuration()
        {
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
    }
}
