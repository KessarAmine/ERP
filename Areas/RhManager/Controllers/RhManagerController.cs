using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevExtreme.AspNet.Mvc;
using DevKbfSteel.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DevKbfSteel.Areas.RhManager.Controllers
{
    [Area("RhManager")]
    [Authorize(Roles = "RhManager")]

    public class RhManagerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ListeEmployes()
        {
            return View();
        }
        public IActionResult ContratsEmployes()
        {
            return View();
        } 
        public IActionResult Formations()
        {
            return View();
        } 
        public IActionResult Tables()
        {
            return View();
        } 
        public IActionResult Configuration()
        {
            return View();
        }
        public IActionResult FormationViewer(int id)
        {
            XpertHelper.RhIdFormation = id;
            return View();
        }
        public IActionResult FicheSuiviPersonnelViewer(int id)
        {
            XpertHelper.CodeEmpSuivi = id;
            return View();
        }
        public IActionResult ContratTravailViewer(int id)
        {
            XpertHelper.RhNumContrat = id;
            return View();
        }
        public IActionResult ContratTravailStagiereViewer(int id)
        {
            XpertHelper.RhNumContrat = id;
            return View();
        }
    }

}
