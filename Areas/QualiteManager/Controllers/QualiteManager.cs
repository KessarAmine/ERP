using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DevKbfSteel.Helpers;

namespace DevKbfSteel.Areas.QualiteManager.Controllers
{
    [Area("QualiteManager")]
    public class QualiteManagerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }        
        public IActionResult BonCession()
        {
            return View();
        }           
        public IActionResult BonCessionViewer(int id)
        {
            XpertHelper.QualiteBonCession = id;
            return View();
        }        
        public IActionResult ControlGeometrique()
        {
            return View();
        }          
        public IActionResult ControlGeometriqueViewer(int id)
        {
            XpertHelper.QualiteControlGeometrique = id;
            return View();
        }        
        public IActionResult EssaisMecanique()
        {
            return View();
        }              
        public IActionResult EssaisMecaniqueViewer(int id)
        {
            XpertHelper.QualiteEssaisMecanique = id;
            return View();
        }
        public IActionResult RapportQualite()
        {
            return View();
        }      
        public IActionResult RapportQualiteViewer(int id)
        {
            XpertHelper.QualiteRapports = id;
            return View();
        }      
        public IActionResult Configuration()
        {
            return View();
        }
    }
}
