using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace DevKbfSteel.Areas.MaintenanceManager.Controllers
{
    [Area("MaintenanceManager")]

    public class MaintenanceManagerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult DemandeTravailsMaintenanceRecieved()
        {
            return View();
        }
        public IActionResult DemandeTravailsMaintenanceSent()
        {
            return View();
        }
        public IActionResult OrdresTravailMaintenanceRecieved()
        {
            return View();
        }
        public IActionResult OrdresTravailMaintenanceSent()
        {
            return View();
        }
        public IActionResult DemandeTravailViewer()
        {
            return View();
        }
        public IActionResult OrdreTravailViewer()
        {
            return View();
        }
        public IActionResult ObjectifsQualiteViewerMaintenance()
        {
            return View();
        }
        public IActionResult RapportMensuelViewerMaintenance()
        {
            return View();
        }
    }
}
