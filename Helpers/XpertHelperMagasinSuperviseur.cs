using DevKbfSteel.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevKbfSteel.Areas.MethodeManager.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;
using DevKbfSteel.Models;
using Microsoft.AspNetCore.Mvc;

namespace DevKbfSteel.Helpers
{
    public static class XpertHelperMagasinSuperviseur
    {

        public static int typeMovment_Entree = 2;
        public static int typeMovment_Sortie = 3;
        public static int typeMovment_Affectation = 4;
        public static int typeMovment_Decharge = 5;
        public static int typeMovment_Retour = 8;
        public static int typeMovment_Reintegration = 6;
        public static int typeMovment_Restitution = 7;
        public static List<float> TonnageCage = new List<float>();
        public static string UserRole;
        public static string EtatFournisseur;
        //XtraRport 

        public static DateTime Datefin ;
        public static DateTime Datedebut;
        public static string ServiceCurrent;
        public static int ServiceDemandeur;
        public static int ServiceReceveur;
        public static int CodeMachineReport;
        public static int GridMachineId =0;
        public static int NumRapportProductionJournee;
        public static int FicheArticlePdr;
        public static int FicheArticlePdrAgent;
        public static int FicheArticlePdrSuperviseur;
        public static int CodePdrSuivi;
        public static int CodePdrSuiviAgent;
        public static int CodePdrSuiviSuperviseur;

        // Adding a contract
        public static int IdEmployeeAddContrat;

        //Suivi Personnel Intervention
        public static string NomEmpSuivi;
        public static string PrenomEmpSuivi;
        public static int CodeEmpSuivi;
        public static double RenumerationValue;

        public static int? NumDemandeFournitureMagasin;

        public static int? NumDemandeFourniture;
        public static int? NumBonAffectationMagasin;
        public static int? NumDemandeAchatMagasin;
        public static int? NumReceptionBilletteMagasin;
        public static int? NumTransfertBilletteMagasin;
        public static int? NumDemandeService;
        public static int CodeServicePdrSureveilleCurrent;
        public static int CodeServiceFicheArticleElectrique;
        public static int GestionFicheArticleCodePdrElectrique;

        public static int CodeServiceFicheArticleMecanique;
        public static int GestionFicheArticleCodePdrMecanique;

        public static int CodeServiceFicheArticleMethodes;
        public static int GestionFicheArticleCodePdrMetodes;

        public static int CodeServiceFicheArticleMagasin;
        public static int GestionFicheArticleCodePdrMagasin;

        public static int CodeServiceFicheArticleUsinage;
        public static int GestionFicheArticleCodePdrUsinage;

        public static int CodeServiceFicheArticleSoudure;
        public static int GestionFicheArticleCodePdrSoudure;

        public static int NumDecharge;
        public static int NumRestitution;

        public static int NumReintegration;

        public static int NumBonRetour;

        public static int NumBonEntreeMagasin;

        public static int NumBonSortieMagasin;

        public static int? NumOtOutils;

        public static int? IdEmploye;
        public static int? NumIntervention;

        public static int? NumStkEmplacementPdr;
        public static int? NumBonTransfert;
        public static int? NumBonTransfertAgent;
        public static int? NumBonTransfertSuperviseur;
        public static int? NumBonTransfertXtra;
        public static int? NumBonTransfertXtraAgent;
        public static int? NumBonTransfertXtraSuperviseur;
        public static int? NumBonRetourTransfert;
        public static int? NumBonRetourTransfertXtra;
        public static int? NumBonRetourTransfertXtraAgent;
        public static int? NumBonRetourTransfertXtraSuperviseur;

        public static int? NumBonAffectationXtra;
        public static int? NumBonAffectationXtraAgent;
        public static int? NumBonAffectationXtraSuperviseur;
        public static int? NumBonRetourXtra;
        public static int? NumBonRetourXtraAgent;
        public static int? NumBonRetourXtraSuperviseur;
        public static int? NumBonReintegrationXtra;
        public static int? NumBonReintegrationXtraAgent;
        public static int? NumBonReintegrationXtraSuperviseur;
        public static int? NumBonRestitutionXtra;
        public static int? NumBonRestitutionXtraAgent;
        public static int? NumBonRestitutionXtraSuperviseur;
        public static int? NumBonReceptionBilletteXtra;
        public static int? NumBonTransfertBilletteXtra;
        public static DateTime? NumDateDebutRecapeBilletteXtra;
        public static DateTime? NumDateFinRecapeBilletteXtra;
        public static int? NumDemandeAchatXtra;
        public static int? NumDechargeXtra;
        public static int? NumDechargeXtraAgent;
        public static int? NumDechargeXtraSuperviseur;

        public static int? NumInventaire;
        public static int? NumInventaireEquipe;
        public static int? IdEquipeXtra;

        //Code structures
        public static int CodeMethode = 6;
        public static int CodeMecanqiue = 1;
        public static int CodeElectrique = 2;
        public static int CodeExploitation = 3;
        public static int CodeRh = 4;
        public static int CodeAppro =9;
        public static int CodeUsinage = 0;
        public static int CodeSodure = 5;
        public static int CodeMagasin = 10;

        //=============================Methodes=======================
        public static StkMovements ComputeValorisation(StkMovements model, int Case, KBFsteelContext _context)
        {
            model.StockTotalSythese = model.Qte;
            model.ValeurStockTotal = model.Montant;
            //if case = 1 we compute from stockInitial 
            if (Case == 1)
            {
                var StkStockInitial = _context.StkStockInitial
                    .OrderBy(o => o.Id)
                    .Where(c => c.CodePdr == model.CodePdr)
                    .Select(i => new
                    {
                        i.Id,
                        i.Qte,
                        i.PrixUnitare
                    }).ToList();

                model.StockTotalSythese += StkStockInitial.Last().Qte;
                model.ValeurStockTotal += Math.Round((double)(StkStockInitial.Last().PrixUnitare * StkStockInitial.Last().Qte), 2);
            }
            //If case = 2 we get last movement
            if (Case == 2)
            {
                var StkMovements = _context.StkMovements
                .OrderBy(o => o.IdMovement)
                .Where(c => c.CodePdr == model.CodePdr && c.DateMovment.Date < model.DateMovment.Date)
                .Select(i => new
                {
                    i.IdMovement,
                    i.StockTotalSythese,
                    i.ValeurStockTotal
                }).ToList();
                model.StockTotalSythese += StkMovements.Last().StockTotalSythese;
                model.ValeurStockTotal += Math.Round((double)(StkMovements.Last().ValeurStockTotal), 2);
            }
            model.ValeurValorisation = Math.Round((double)(model.ValeurStockTotal / model.StockTotalSythese), 2);
            return model;
        }

    }
}