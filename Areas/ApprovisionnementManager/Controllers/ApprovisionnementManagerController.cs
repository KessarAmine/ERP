using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DevKbfSteel.Areas.ApprovisionnementManager.Controllers
{
    [Area("ApprovisionnementManager")]
    [Authorize(Roles = "ApprovisionnementManager")]

    public class ApprovisionnementManagerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult BonCommandes()
        {
            return View();
        }
        public IActionResult SuiviAchats()
        {
            return View();
        }
        

    }
}
