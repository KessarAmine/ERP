using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevKbfSteel.Entities;
using DevKbfSteel.Helpers;

namespace DevKbfSteel.Controllers
{
    [Route("api/[controller]/[action]")]

    public class SmartAssistCtrlController : Controller
    {
        private KBFsteelContext _context;
        public SmartAssistCtrlController(KBFsteelContext context)
        {
            _context = context;
        }
        public  IEnumerable<SmartAssistItem> GeUsinage()
        {
            List<SmartAssistItem> dtSentAttente = SmartAssist.GetDtSentAttente(_context, XpertHelper.CodeUsinage);
            List<SmartAssistItem> GdtRecuesAttente = SmartAssist.GetDtRecuesAttente(_context, XpertHelper.CodeUsinage);
            List<SmartAssistItem> getPreventif = SmartAssist.GetPreventif(_context, XpertHelper.CodeUsinage);
            List<SmartAssistItem> getMachinesAnomalies = SmartAssist.GetMachinesAnomalies(_context, XpertHelper.CodeUsinage);
            List<SmartAssistItem> getOtRecuAttente = SmartAssist.GetOtRecuAttente(_context, XpertHelper.CodeUsinage);
            List<SmartAssistItem> GetCylindresunderPreporcess = SmartAssist.GetCylindresunderPreporcess(_context, XpertHelper.CodeUsinage);
            List<SmartAssistItem> getFournituresEnAttente = SmartAssist.GetFournituresEnAttente(_context, XpertHelper.CodeUsinage);
            List<SmartAssistItem> GetOtSentSansRapport = SmartAssist.GetOtSentSansRapport(_context, XpertHelper.CodeUsinage);
            List<SmartAssistItem> SmartAsssitUsinage = new List<SmartAssistItem>();
            foreach (var itemGetOtSentSansRapport in GetOtSentSansRapport)
            {
                SmartAsssitUsinage.Add(itemGetOtSentSansRapport);
            }
            foreach (var itemGetCylindresunderPreporcess in GetCylindresunderPreporcess)
            {
                SmartAsssitUsinage.Add(itemGetCylindresunderPreporcess);
            }
            foreach (var itemdtSentAttente in dtSentAttente)
            {
                SmartAsssitUsinage.Add(itemdtSentAttente);
            }
            foreach (var itemGdtRecuesAttente in GdtRecuesAttente)
            {
                SmartAsssitUsinage.Add(itemGdtRecuesAttente);
            }
            foreach (var itemgetPreventif in getPreventif)
            {
                SmartAsssitUsinage.Add(itemgetPreventif);
            }
            foreach (var itemgetMachinesAnomalies in getMachinesAnomalies)
            {
                SmartAsssitUsinage.Add(itemgetMachinesAnomalies);
            }
            foreach (var itemgetOtRecuAttente in getOtRecuAttente)
            {
                SmartAsssitUsinage.Add(itemgetOtRecuAttente);
            }
            foreach (var itemgetFournituresEnAttente in getFournituresEnAttente)
            {
                SmartAsssitUsinage.Add(itemgetFournituresEnAttente);
            }

            return SmartAsssitUsinage.AsEnumerable();
        }
        public  IEnumerable<SmartAssistItem> GeSodure()
        {
            List<SmartAssistItem> dtSentAttente = SmartAssist.GetDtSentAttente(_context, XpertHelper.CodeSodure);
            List<SmartAssistItem> GdtRecuesAttente = SmartAssist.GetDtRecuesAttente(_context, XpertHelper.CodeSodure);
            List<SmartAssistItem> getPreventif = SmartAssist.GetPreventif(_context, XpertHelper.CodeSodure);
            List<SmartAssistItem> getMachinesAnomalies = SmartAssist.GetMachinesAnomalies(_context, XpertHelper.CodeSodure);
            List<SmartAssistItem> getOtRecuAttente = SmartAssist.GetOtRecuAttente(_context, XpertHelper.CodeSodure);
            List<SmartAssistItem> getFournituresEnAttente = SmartAssist.GetFournituresEnAttente(_context, XpertHelper.CodeSodure);
            List<SmartAssistItem> getGetOtSentSansRapport = SmartAssist.GetOtSentSansRapport(_context, XpertHelper.CodeSodure);
            List<SmartAssistItem> SmartAsssitSodure = new List<SmartAssistItem>();
            foreach (var itemgetGetOtSentSansRapport in getGetOtSentSansRapport)
            {
                SmartAsssitSodure.Add(itemgetGetOtSentSansRapport);
            }
            foreach (var itemdtSentAttente in dtSentAttente)
            {
                SmartAsssitSodure.Add(itemdtSentAttente);
            }
            foreach (var itemGdtRecuesAttente in GdtRecuesAttente)
            {
                SmartAsssitSodure.Add(itemGdtRecuesAttente);
            }
            foreach (var itemgetPreventif in getPreventif)
            {
                SmartAsssitSodure.Add(itemgetPreventif);
            }
            foreach (var itemgetMachinesAnomalies in getMachinesAnomalies)
            {
                SmartAsssitSodure.Add(itemgetMachinesAnomalies);
            }
            foreach (var itemgetOtRecuAttente in getOtRecuAttente)
            {
                SmartAsssitSodure.Add(itemgetOtRecuAttente);
            }
            foreach (var itemgetFournituresEnAttente in getFournituresEnAttente)
            {
                SmartAsssitSodure.Add(itemgetFournituresEnAttente);
            }

            return SmartAsssitSodure.AsEnumerable();
        }
        public  IEnumerable<SmartAssistItem> GetElectrique()
        {
            List<SmartAssistItem> dtSentAttente = SmartAssist.GetDtSentAttente(_context, XpertHelper.CodeElectrique);
            List<SmartAssistItem> GdtRecuesAttente = SmartAssist.GetDtRecuesAttente(_context, XpertHelper.CodeElectrique);
            List<SmartAssistItem> getPreventif = SmartAssist.GetPreventif(_context, XpertHelper.CodeElectrique);
            List<SmartAssistItem> getMachinesAnomalies = SmartAssist.GetMachinesAnomalies(_context, XpertHelper.CodeElectrique);
            List<SmartAssistItem> getOtRecuAttente = SmartAssist.GetOtRecuAttente(_context, XpertHelper.CodeElectrique);
            List<SmartAssistItem> getFournituresEnAttente = SmartAssist.GetFournituresEnAttente(_context, XpertHelper.CodeElectrique);
            List<SmartAssistItem> GetOtSentSansRapport = SmartAssist.GetOtSentSansRapport(_context, XpertHelper.CodeElectrique);
            List<SmartAssistItem> SmartAsssitElectrique = new List<SmartAssistItem>();
            foreach (var itemGetOtSentSansRapport in GetOtSentSansRapport)
            {
                SmartAsssitElectrique.Add(itemGetOtSentSansRapport);
            }
            foreach (var itemdtSentAttente in dtSentAttente)
            {
                SmartAsssitElectrique.Add(itemdtSentAttente);
            }
            foreach (var itemGdtRecuesAttente in GdtRecuesAttente)
            {
                SmartAsssitElectrique.Add(itemGdtRecuesAttente);
            }
            foreach (var itemgetPreventif in getPreventif)
            {
                SmartAsssitElectrique.Add(itemgetPreventif);
            }
            foreach (var itemgetMachinesAnomalies in getMachinesAnomalies)
            {
                SmartAsssitElectrique.Add(itemgetMachinesAnomalies);
            }
            foreach (var itemgetOtRecuAttente in getOtRecuAttente)
            {
                SmartAsssitElectrique.Add(itemgetOtRecuAttente);
            }
            foreach (var itemgetFournituresEnAttente in getFournituresEnAttente)
            {
                SmartAsssitElectrique.Add(itemgetFournituresEnAttente);
            }

            return SmartAsssitElectrique.AsEnumerable();
        }
        public  IEnumerable<SmartAssistItem> GetMecanique()
        {
            List<SmartAssistItem> dtSentAttente = SmartAssist.GetDtSentAttente(_context, XpertHelper.CodeMecanqiue);
            List<SmartAssistItem> GdtRecuesAttente = SmartAssist.GetDtRecuesAttente(_context, XpertHelper.CodeMecanqiue);
            List<SmartAssistItem> getPreventif = SmartAssist.GetPreventif(_context, XpertHelper.CodeMecanqiue);
            List<SmartAssistItem> getMachinesAnomalies = SmartAssist.GetMachinesAnomalies(_context, XpertHelper.CodeMecanqiue);
            List<SmartAssistItem> getOtRecuAttente = SmartAssist.GetOtRecuAttente(_context, XpertHelper.CodeMecanqiue);
            List<SmartAssistItem> getFournituresEnAttente = SmartAssist.GetFournituresEnAttente(_context, XpertHelper.CodeMecanqiue);
            List<SmartAssistItem> GetOtSentSansRapport = SmartAssist.GetOtSentSansRapport(_context, XpertHelper.CodeMecanqiue);
            List<SmartAssistItem> SmartAsssitMecanique = new List<SmartAssistItem>();
            foreach (var itemGetOtSentSansRapport in GetOtSentSansRapport)
            {
                SmartAsssitMecanique.Add(itemGetOtSentSansRapport);
            }
            foreach (var itemdtSentAttente in dtSentAttente)
            {
                SmartAsssitMecanique.Add(itemdtSentAttente);
            }
            foreach (var itemGdtRecuesAttente in GdtRecuesAttente)
            {
                SmartAsssitMecanique.Add(itemGdtRecuesAttente);
            }
            foreach (var itemgetPreventif in getPreventif)
            {
                SmartAsssitMecanique.Add(itemgetPreventif);
            }
            foreach (var itemgetMachinesAnomalies in getMachinesAnomalies)
            {
                SmartAsssitMecanique.Add(itemgetMachinesAnomalies);
            }
            foreach (var itemgetOtRecuAttente in getOtRecuAttente)
            {
                SmartAsssitMecanique.Add(itemgetOtRecuAttente);
            }
            foreach (var itemgetFournituresEnAttente in getFournituresEnAttente)
            {
                SmartAsssitMecanique.Add(itemgetFournituresEnAttente);
            }

            return SmartAsssitMecanique.AsEnumerable();
        }
        public IEnumerable<SmartAssistItem> GetExploitation()
        {
            List<SmartAssistItem> dtSentAttente = SmartAssist.GetDtSentAttente(_context, XpertHelper.CodeExploitation);
            List<SmartAssistItem> GetDtSentEnCours = SmartAssist.GetDtSentEnCours(_context, XpertHelper.CodeExploitation);
            List<SmartAssistItem> getFournituresEnAttente = SmartAssist.GetFournituresEnAttente(_context, XpertHelper.CodeExploitation);
            List<SmartAssistItem> GdtRecuesAttente = SmartAssist.GetDtRecuesAttente(_context, XpertHelper.CodeExploitation);
            List<SmartAssistItem> getPreventif = SmartAssist.GetPreventif(_context, XpertHelper.CodeExploitation);
            List<SmartAssistItem> GetOtSentSansRapport = SmartAssist.GetOtSentSansRapport(_context, XpertHelper.CodeExploitation);
            List<SmartAssistItem> GetCylindresunderPreporcess = SmartAssist.GetCylindresunderPreporcess(_context, XpertHelper.CodeExploitation);
            List<SmartAssistItem> GetTonnageCagesWarnning = SmartAssist.GetTonnageCagesWarnning(_context);

            List<SmartAssistItem> SmartAsssitExploitation= new List<SmartAssistItem>();
            foreach (var itemGetOtSentSansRapport in GetOtSentSansRapport)
            {
                SmartAsssitExploitation.Add(itemGetOtSentSansRapport);
            }
            foreach (var itemGetCylindresunderPreporcess in GetCylindresunderPreporcess)
            {
                SmartAsssitExploitation.Add(itemGetCylindresunderPreporcess);
            }
            foreach (var itemGetTonnageCagesWarnning in GetTonnageCagesWarnning)
            {
                SmartAsssitExploitation.Add(itemGetTonnageCagesWarnning);
            }
            foreach (var itemgetFournituresEnAttente in getFournituresEnAttente)
            {
                SmartAsssitExploitation.Add(itemgetFournituresEnAttente);
            }
            foreach (var itemdtSentAttente in dtSentAttente)
            {
                SmartAsssitExploitation.Add(itemdtSentAttente);
            }
            foreach (var itemGdtRecuesAttente in GdtRecuesAttente)
            {
                SmartAsssitExploitation.Add(itemGdtRecuesAttente);
            }
            foreach (var itemgetPreventif in getPreventif)
            {
                SmartAsssitExploitation.Add(itemgetPreventif);
            }
            foreach (var itemGetDtSentEnCours in GetDtSentEnCours)
            {
                SmartAsssitExploitation.Add(itemGetDtSentEnCours);
            }
            return SmartAsssitExploitation.AsEnumerable();
        }
        public IEnumerable<SmartAssistItem> GetMethodes()
        {
            List<SmartAssistItem> dtSentAttente = SmartAssist.GetDtSentAttente(_context, XpertHelper.CodeMethode);
            List<SmartAssistItem> GetDtSentEnCours = SmartAssist.GetDtSentEnCours(_context, XpertHelper.CodeMethode);
            List<SmartAssistItem> GdtRecuesAttente = SmartAssist.GetDtRecuesAttente(_context, XpertHelper.CodeMethode);
            List<SmartAssistItem> getPreventif = SmartAssist.GetPreventif(_context, XpertHelper.CodeMethode);
            List<SmartAssistItem> getMachinesAnomalies = SmartAssist.GetMachinesAnomalies(_context, XpertHelper.CodeMethode);
            List<SmartAssistItem> getOtSentAttente = SmartAssist.GetOtSentAttente(_context);
            List<SmartAssistItem> getFournituresEnAttente = SmartAssist.GetFournituresEnAttente(_context, XpertHelper.CodeMethode);
            List<SmartAssistItem> GetOtSentSansRapportMethodes = SmartAssist.GetOtSentSansRapportMethodes(_context);

            List<SmartAssistItem> SmartAsssitMethodes = new List<SmartAssistItem>();
            foreach (var itemGetOtSentSansRapportMethodes in GetOtSentSansRapportMethodes)
            {
                SmartAsssitMethodes.Add(itemGetOtSentSansRapportMethodes);
            }
            foreach (var itemdtSentAttente in dtSentAttente)
            {
                SmartAsssitMethodes.Add(itemdtSentAttente);
            }
            foreach (var itemGdtRecuesAttente in GdtRecuesAttente)
            {
                SmartAsssitMethodes.Add(itemGdtRecuesAttente);
            }
            foreach (var itemgetPreventif in getPreventif)
            {
                SmartAsssitMethodes.Add(itemgetPreventif);
            }
            foreach (var itemGetDtSentEnCours in GetDtSentEnCours)
            {
                SmartAsssitMethodes.Add(itemGetDtSentEnCours);
            }
            foreach (var itemgetMachinesAnomalies in getMachinesAnomalies)
            {
                SmartAsssitMethodes.Add(itemgetMachinesAnomalies);
            }
            foreach (var itemgetOtSentAttente in getOtSentAttente)
            {
                SmartAsssitMethodes.Add(itemgetOtSentAttente);
            }
            foreach (var itemgetFournituresEnAttente in getFournituresEnAttente)
            {
                SmartAsssitMethodes.Add(itemgetFournituresEnAttente);
            }
            return SmartAsssitMethodes.AsEnumerable();
        }
        public IEnumerable<SmartAssistItem> GetMagasinSuperviseur()
        {
            List<SmartAssistItem> getArticleStockAlerte = SmartAssist.GetArticleStockAlerte(_context,1);
            List<SmartAssistItem> SmartAsssitMagasinSuperviseur = new List<SmartAssistItem>();
            foreach (var itemgetArticleStockAlerte in getArticleStockAlerte)
            {
                SmartAsssitMagasinSuperviseur.Add(itemgetArticleStockAlerte);
            }
            return SmartAsssitMagasinSuperviseur.AsEnumerable();
        }
        public IEnumerable<SmartAssistItem> GetMagasinManager()
        {
            List<SmartAssistItem> getArticleStockAlerte = SmartAssist.GetArticleStockAlerte(_context,2);
            List<SmartAssistItem> SmartAsssitMagasinManager = new List<SmartAssistItem>();
            foreach (var itemgetArticleStockAlerte in getArticleStockAlerte)
            {
                SmartAsssitMagasinManager.Add(itemgetArticleStockAlerte);
            }
            return SmartAsssitMagasinManager.AsEnumerable();
        }
        public IEnumerable<SmartAssistItem> GetGestionnaireMagasin()
        {
            List<SmartAssistItem> getSoritesSansDetails = SmartAssist.GetSoritesSansDetails(_context);
            List<SmartAssistItem> SmartAsssitMagasinManager = new List<SmartAssistItem>();
            foreach (var itemgetSoritesSansDetails in getSoritesSansDetails)
            {
                SmartAsssitMagasinManager.Add(itemgetSoritesSansDetails);
            }
            return SmartAsssitMagasinManager.AsEnumerable();
        }
        public IEnumerable<SmartAssistItem> GetRh()
        {
            List<SmartAssistItem> getContratTravailEnding = SmartAssist.GetContratTravailEnding(_context);
            List<SmartAssistItem> SmartAsssitRH = new List<SmartAssistItem>();
            foreach (var itemgetContratTravailEnding in getContratTravailEnding)
            {
                SmartAsssitRH.Add(itemgetContratTravailEnding);
            }
            return SmartAsssitRH.AsEnumerable();
        }
    }
}
