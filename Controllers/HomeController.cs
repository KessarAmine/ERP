using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DevKbfSteel.Models;
using Microsoft.AspNetCore.Authorization;
using DevKbfSteel.Helpers;
using DevKbfSteel.Entities;
using DevKbfSteel.Areas.MagasinManager.Models;

namespace DevKbfSteel.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult DemandeTravails()
        {
            return View();
        }
        public IActionResult MainElectriqueManager()
        {
            XpertHelper.NavigationDrawerKey = null;
            return View();
        }
        public IActionResult MainExploitationManager()
        {
            XpertHelper.NavigationDrawerKey = null;
            return View();
        }
        public IActionResult MainMaintenanceManager()
        {
            XpertHelper.NavigationDrawerKey = null;
            return View();
        }
        public IActionResult MainMecaniqueManager()
        {
            XpertHelper.NavigationDrawerKey = null;
            return View();
        }
        public IActionResult MainMethodeManager()
        {
            XpertHelper.NavigationDrawerKey = null;
            return View();
        }
        public IActionResult MainUsinageManager()
        {
            XpertHelper.NavigationDrawerKey = null;
            return View();
        }
        public IActionResult MainMagasinAgent()
        {
            XpertHelper.NavigationDrawerKey = null;
            return View(SampleDataMenu.GroupedMenuItems);
        }
        public IActionResult MainGestionnaireMagasin()
        {
            XpertHelperGestionnaireMagasin.NavigationDrawerKey = null;
            return View(SampleDataMenu.GroupedMenuItems);
        }
        public IActionResult MainMagasinSuperviseur()
        {
            XpertHelper.NavigationDrawerKey = null;
            return View(SampleDataMenu.GroupedMenuItems);
        }
        public IActionResult MainQualiteManager()
        {
            XpertHelper.NavigationDrawerKey = null;
            return View(SampleDataMenu.GroupedMenuItems);
        }
        public IActionResult MainMagasinManager()
        {
            XpertHelper.NavigationDrawerKey = null;
            return View(SampleDataMenu.GroupedMenuItems);
        }
        public IActionResult MainSodureManager()
        {
            XpertHelper.NavigationDrawerKey = null;
            return View();
        }
        public IActionResult MainRhManager()
        {
            XpertHelper.NavigationDrawerKey = null;
            return View();
        }
        public IActionResult Viewer()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult MainApprovisionnementManager()
        {
            XpertHelper.NavigationDrawerKey = null;
            return View();
        }
        public IActionResult DemandeTravailViewer()
        {
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
