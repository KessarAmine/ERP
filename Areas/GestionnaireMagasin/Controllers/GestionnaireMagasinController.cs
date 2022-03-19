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
    [Area("GestionnaireMagasin")]
    [Authorize(Roles = "GestionnaireMagasin")]

    public class GestionnaireMagasinController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult StockInitial()
        {
            XpertHelper.NavigationDrawerKeyMagasin = "0";
            return View();
        }
        public IActionResult Entree()
        {
            XpertHelper.NavigationDrawerKeyMagasin = "1";
            return View();
        }
        public IActionResult Sorties()
        {
            XpertHelper.NavigationDrawerKeyMagasin = "2";
            return View();
        }
        public IActionResult DemandesFourniture()
        {
            XpertHelper.NavigationDrawerKeyMagasin = "3";
            return View();
        }
        public IActionResult DemandesAchats()
        {
            XpertHelper.NavigationDrawerKeyMagasin = "4";
            return View();
        }
        public IActionResult BonAffectations()
        {
            XpertHelper.NavigationDrawerKeyMagasin = "5";
            return View();
        }
        public IActionResult SuiviBillettes()
        {
            
            XpertHelper.NavigationDrawerKeyMagasin = "6";
            /*
            if (XpertHelper.UserRole.Equals("MagasinManager"))
            else
            {
                return StatusCode(409, "En tant que: " + XpertHelper.UserRole + " Vous n'avez pas le droit d'acceder a cette rubrique");
            }
            */
            return View();

        }
        public IActionResult Decharges()
        {
            XpertHelper.NavigationDrawerKeyMagasin = "7";
            return View();
        }
        public IActionResult BonReintegration()
        {
            XpertHelper.NavigationDrawerKeyMagasin = "8";
            return View();
        }
        public IActionResult BonRetour()
        {
            XpertHelper.NavigationDrawerKeyMagasin = "9";
            return View();
        }
        public IActionResult Movements()
        {
            XpertHelper.NavigationDrawerKeyMagasin = "11";
            return View();
        }
        public IActionResult Fournisseurs()
        {
            XpertHelper.NavigationDrawerKeyMagasin = "10";
            return View();
        }
        public IActionResult ListePDR()
        {
            XpertHelper.NavigationDrawerKeyMagasin = "13";
            return View();
        }
        public IActionResult ListeArticles()
        {
            XpertHelper.NavigationDrawerKeyMagasin = "12";
            return View();
        }
        public IActionResult Outillage()
        {
            XpertHelper.NavigationDrawerKeyMagasin = "14";
            return View();
        }
        public IActionResult Transferts()
        {
            XpertHelper.NavigationDrawerKeyMagasin = "15";
            return View();
        }
        public IActionResult Lieux()
        {
            XpertHelper.NavigationDrawerKeyMagasin = "16";
            return View();
        }
        public IActionResult Inventaire()
        {
            XpertHelper.NavigationDrawerKeyMagasin = "17";
            return View();
        }
        public IActionResult Personnels()
        {
            XpertHelper.NavigationDrawerKeyMagasin = "18";
            return View();
        }
        public IActionResult ComptesComptable()
        {
            XpertHelper.NavigationDrawerKeyMagasin = "19";
            return View();
        }
        public IActionResult Configuration()
        {
            XpertHelper.NavigationDrawerKeyMagasin = "20";
            return View();
        }
        public IActionResult SuiviCompteComptableViewer()
        {
            return View();
        }
        public IActionResult FournisseursGlobalViewer()
        {
            return View();
        }
        public IActionResult SuiviESViewer()
        {
            return View();
        }
        public IActionResult EtatFournisseurViewer(string id)
        {
            XpertHelper.EtatFournisseur = id;
            return View();
        }
        public IActionResult SuiviMovementViewer()
        {
            return View();
        }
        public IActionResult EtatCompteComptableViewer(int id)
        {
            XpertHelper.Cc = id;
            return View();
        }
        public IActionResult EcartInventaireViewer()
        {
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
            XpertHelper.FicheArticlePdr = id;
            return View();
        }
        public IActionResult BonTransertViewer(int id)
        {
            XpertHelper.NumBonTransfertXtra = id;
            return View();
        }
        public IActionResult BonRetourTransfertViewer(int id)
        {
            XpertHelper.NumBonRetourTransfertXtra = id;
            return View();
        }
        public IActionResult BonSortieViewer(int id)
        {
            XpertHelper.NumBonSortieMagasin = id;
            return View();
        }
        public IActionResult BonEntreeViewer(int id)
        {
            XpertHelper.NumBonEntreeMagasin = id;
            return View();
        }
        public IActionResult DemandeFournitureViewer(int id)
        {
            XpertHelper.NumDemandeFournitureMagasin = id;
            return View();
        }
        public IActionResult BonAffectationViewer(int id)
        {
            XpertHelper.NumBonAffectationXtra = id;
            return View();
        }
        public IActionResult BonReintegrationViewer(int id)
        {
            XpertHelper.NumBonReintegrationXtra = id;
            return View();
        }
        public IActionResult BonRestitutionViewer(int id)
        {
            XpertHelper.NumBonRestitutionXtra = id;
            return View();
        }
        public IActionResult BonRetourViewer(int id)
        {
            XpertHelper.NumBonRetourXtra = id;
            return View();
        }
        public IActionResult DechargeViewer(int id)
        {
            XpertHelper.NumDechargeXtra = id;
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
    }
}
