using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevExtreme.AspNet.Mvc;
using DevKbfSteel.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace DevKbfSteel.Areas.MagasinAgent.Controllers
{
    [Area("MagasinAgent")]
    [Authorize(Roles = "MagasinAgent")]

    public class MagasinAgentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Entree()
        {
            XpertHelper.NavigationDrawerKeyMagasin = "0";
            return View();
        }
        public IActionResult Sorties()
        {
            XpertHelper.NavigationDrawerKeyMagasin = "1";
            return View();
        }
        public IActionResult BonAffectations()
        {
            XpertHelper.NavigationDrawerKeyMagasin = "2";
            return View();
        }
        public IActionResult Decharges()
        {
            XpertHelper.NavigationDrawerKeyMagasin = "3";
            return View();
        }
        public IActionResult BonReintegration()
        {
            XpertHelper.NavigationDrawerKeyMagasin = "4";
            return View();
        }
        public IActionResult BonRetour()
        {
            XpertHelper.NavigationDrawerKeyMagasin = "5";
            return View();
        }
        public IActionResult Movements()
        {
            XpertHelper.NavigationDrawerKeyMagasin = "6";
            return View();
        }
        public IActionResult ListePDR()
        {
            XpertHelper.NavigationDrawerKeyMagasin = "8";
            return View();
        }
        public IActionResult ListeArticles()
        {
            XpertHelper.NavigationDrawerKeyMagasin = "7";
            return View();
        }
        public IActionResult Outillage()
        {
            XpertHelper.NavigationDrawerKeyMagasin = "9";
            return View();
        }
        public IActionResult Transferts()
        {
            XpertHelper.NavigationDrawerKeyMagasin = "10";
            return View();
        }
        public IActionResult PapillonCmptageViewer(int id)
        {
            XpertHelper.IdEquipeXtra = id;
            return View();
        }
        public IActionResult SuiviArticleViewer()
        {
            return View();
        }
        public IActionResult FicheArticleViewer(int id)
        {
            XpertHelper.FicheArticlePdrAgent = id;
            return View();
        }
        public IActionResult BonTransertViewer(int id)
        {
            XpertHelper.NumBonTransfertXtraAgent = id;
            return View();
        }
        public IActionResult BonRetourTransfertViewer(int id)
        {
            XpertHelper.NumBonRetourTransfertXtra = id;
            return View();
        }
        public IActionResult BonSortieViewer(int id)
        {
            XpertHelper.NumBonSortieMagasinAgent = id;
            return View();
        }
        public IActionResult BonEntreeViewer(int id)
        {
            XpertHelper.NumBonEntreeMagasinAgent = id;
            return View();
        }
        public IActionResult DemandeFournitureViewer(int id)
        {
            XpertHelper.NumDemandeFournitureMagasin = id;
            return View();
        }
        public IActionResult BonAffectationViewer(int id)
        {
            XpertHelper.NumBonAffectationXtraAgent = id;
            return View();
        }
        public IActionResult BonReintegrationViewer(int id)
        {
            XpertHelper.NumBonReintegrationXtraAgent = id;
            return View();
        }
        public IActionResult BonRestitutionViewer(int id)
        {
            XpertHelper.NumBonRestitutionXtraAgent = id;
            return View();
        }
        public IActionResult BonRetourViewer(int id)
        {
            XpertHelper.NumBonRetourXtraAgent = id;
            return View();
        }
        public IActionResult DechargeViewer(int id)
        {
            XpertHelper.NumDechargeXtraAgent = id;
            return View();
        }
        public IActionResult DemandeAchatViewer(int id)
        {
            XpertHelper.NumDemandeAchatXtra = id;
            return View();
        }
        public IActionResult TransfertBilletteViewer(int id)
        {
            XpertHelper.NumBonTransfertBilletteXtra = id;
            return View();
        }
        public IActionResult ReceptionBilletteViewer(int id)
        {
            XpertHelper.NumBonReceptionBilletteXtra = id;
            return View();
        }
        public IActionResult RecapeBilletteViewer(DateTime Datedebut, DateTime Datefin)
        {
            XpertHelper.NumDateDebutRecapeBilletteXtra = Datedebut;
            XpertHelper.NumDateFinRecapeBilletteXtra = Datefin;
            return View();
        }
        public IActionResult Configuration()
        {
            return View();
        }
    }
}
