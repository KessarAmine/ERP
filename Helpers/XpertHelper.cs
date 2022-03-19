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
    public static class XpertHelper
    {
        public static int getTravauxDashboard()
        {
            return 0;
        }
        public static int MagasinSupervieurCodificationFournisseur = 5;
        //Consignation
        public static int ConsignationMecanique;
        public static int ConsignationElectrique;
        public static int ConsignationExploitation;
        public static int ConsignationUsinage;
        public static int ConsignationMethodes;
        //Qualite 
        public static int QualiteControlGeometrique;
        public static int QualiteEssaisMecanique;
        public static int QualiteRapports;
        public static int QualiteBonCession;


        public static List<float> TonnageCage = new List<float>();
        public static string UserRole;
        public static void GetTonnageLimites(KBFsteelContext context)
        {
            var TonnageCages = context.ConfigExploitation
                .Select(i => new
                {
                    i.LimiteCage1,
                    i.LimiteCage2,
                    i.LimiteCage3,
                    i.LimiteCage4,
                    i.LimiteCage5,
                    i.LimiteCage6,
                    i.LimiteCage7,
                    i.LimiteCage8,
                    i.LimiteCage9,
                    i.LimiteCage10,
                    i.LimiteCage11,
                    i.LimiteCage12,
                    i.LimiteCage13
                }).ToList().Last();
            TonnageCage.Add((float)TonnageCages.LimiteCage1);
            TonnageCage.Add((float)TonnageCages.LimiteCage2);
            TonnageCage.Add((float)TonnageCages.LimiteCage3);
            TonnageCage.Add((float)TonnageCages.LimiteCage4);
            TonnageCage.Add((float)TonnageCages.LimiteCage5);
            TonnageCage.Add((float)TonnageCages.LimiteCage6);
            TonnageCage.Add((float)TonnageCages.LimiteCage7);
            TonnageCage.Add((float)TonnageCages.LimiteCage8);
            TonnageCage.Add((float)TonnageCages.LimiteCage9);
            TonnageCage.Add((float)TonnageCages.LimiteCage10);
            TonnageCage.Add((float)TonnageCages.LimiteCage11);
            TonnageCage.Add((float)TonnageCages.LimiteCage12);
            TonnageCage.Add((float)TonnageCages.LimiteCage13);
        }
        public static void InitConsts()
        {
            NumDt = null;
            NumOt = null;
            NumOtTaches = null;
            NumOtOutils = null;
            NumIntervention = null;
        }
        public static void InitiRhConfig()
        {
            KBFsteelContext context = new KBFsteelContext();
            XpertHelper.FacteurContratEnding = (int)context.ConfigRhManager.FirstOrDefault().AlerteContratLimit;
        }
        public static int ReportPreventifMonth;
        public static int ReportPreventifYear;
        public static DateTime ReportPreventifDate;

        public static int Cc;

        public static string EtatFournisseur;
        public static void MonthYeaRtoDate(string month, string year)
        {
            if (month.Equals("January"))
            {
                ReportPreventifMonth = 1;
            }
            if (month.Equals("February"))
            {
                ReportPreventifMonth = 2;
            }
            if (month.Equals("March"))
            {
                ReportPreventifMonth = 3;
            }
            if (month.Equals("April"))
            {
                ReportPreventifMonth = 4;
            }
            if (month.Equals("May"))
            {
                ReportPreventifMonth = 5;
            }
            if (month.Equals("June"))
            {
                ReportPreventifMonth = 6;
            }
            if (month.Equals("July"))
            {
                ReportPreventifMonth = 7;
            }
            if (month.Equals("August"))
            {
                ReportPreventifMonth = 8;
            }
            if (month.Equals("September"))
            {
                ReportPreventifMonth = 9;
            }
            if (month.Equals("October"))
            {
                ReportPreventifMonth = 10;
            }
            if (month.Equals("November"))
            {
                ReportPreventifMonth = 11;
            }
            if (month.Equals("December"))
            {
                ReportPreventifMonth = 12;
            }
            ReportPreventifYear = Convert.ToInt32(year);
            ReportPreventifDate = new DateTime(ReportPreventifYear, ReportPreventifMonth,1);
        }
        public static async Task GetPlanningMenseulleTemp(KBFsteelContext context)
        {
            //here we do clear the temp
            context.Database.ExecuteSqlCommand("TRUNCATE TABLE TEMP_PlanningMensuellePreventif");
            //we do poluate the temp
            var Current = context.MethAppointementsPreventifs
            .Where(c => c.StartDate.Month == ReportPreventifMonth && c.StartDate.Year == ReportPreventifYear)
            .Select(i => new {
                i.AppointmentId,
                i.Description,
                i.EndDate,
                i.StartDate,
                i.Text,
                i.RecurrenceException,
                i.RecurrenceRule,
                i.IdOperation
            }).ToList();
            foreach (var itemCurrent in Current)
            {            
                //here we have Operation Maintenance et DateProchaine et Id
                TempPlanningMensuellePreventif temp = new TempPlanningMensuellePreventif();
                var count = context.TempPlanningMensuellePreventif.Select(i => new {
                    i.Id
                }).ToList();
                if(count.Count == 0)
                {
                    temp.Id = 1;
                }
                else
                {
                    var laste = count.Last();
                    temp.Id = laste.Id +1;
                }
                temp.OperationMaintenance = itemCurrent.Description;
                temp.DateProchaine = itemCurrent.StartDate.Date;
                //here we got the dateAnterieure
                var last = context.MethAppointementsPreventifs
                .Where(c => c.StartDate.Month < itemCurrent.StartDate.Month && c.StartDate.Year == itemCurrent.StartDate.Year && c.IdOperation == itemCurrent.IdOperation)
                .Select(i => new {
                    i.StartDate
                }).ToList();
                foreach (var itemlast in last)
                {
                    temp.DateAnterieure = itemlast.StartDate.Date;
                }
                //here we get the equipement
                var operation = context.MethOperations
                .Where(c => c.Idoperation== itemCurrent.IdOperation).FirstOrDefault();
                var machine = context.Machines.Where(c => c.NumMachine == operation.NumMachine).FirstOrDefault();
                temp.Equipement = machine.NomMachine;
                //TODO : jouter designation PDR et qte After avoir ajouter le magasin
                context.TempPlanningMensuellePreventif.Add(temp);
                await context.SaveChangesAsync();
            }
        }
        // DRH
        public static int FacteurContratEnding;
        public static int RhNumContrat;
        public static int RhIdFormation;
        public static int CheckListService;
        public static int NumCheckList;
        public static string NavigationDrawerKey;
        public static string NavigationDrawerKeyMagasin;
        public static DateTime dateJourneeCylindre;
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

        //Adding Travaux Of Ot
        public static List<AssOtTraveaux> TravauxoAddOt { get; set; }

        // Adding a contract
        public static int IdEmployeeAddContrat;

        //Suivi Personnel Intervention
        public static string NomEmpSuivi;
        public static string PrenomEmpSuivi;
        public static int CodeEmpSuivi;
        public static double RenumerationValue;

        //RAPPORT
        public static int? NumDt;
        public static int? NumOtPreventif;
        public static int? NumOt;
        public static int? NumOtTaches;

        public static int? NumDemandeFourniture;
        public static int? NumDemandeFournitureMagasin;
        public static int? NumDemandeFournitureMagasinAgent;

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
        public static int NumDechargeAgent;
        public static int NumDechargeSuperviseur;
        public static int NumRestitution;
        public static int NumRestitutionAgent;
        public static int NumRestitutionSuperviseur;

        public static int NumReintegration;
        public static int NumReintegrationAgent;
        public static int NumReintegrationSuperviseur;
        public static int NumBonRetour;
        public static int NumBonRetourAgent;
        public static int NumBonRetourSuperviseur;

        public static int NumBonEntreeMagasin;
        public static int NumBonEntreeMagasinAgent;
        public static int NumBonEntreeMagasinSuperviseur;
        public static int NumBonSortieMagasin;
        public static int NumBonSortieMagasinAgent;
        public static int NumBonSortieMagasinSuperviseur;

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

        public static int CodeOxygene = 9002001;

        // Menus Utitlies
        // Exploitation..........


        public static IHttpContextAccessor XpertIHttpContextAccessor;
        public static IMemoryCache XpertIMemoryCache;
        //=============================Constantes======================
        //=============================MasterDetails==================
        //=============================View: GestionOperation=========
        public static int IdOperation;
        public static int LimitYear = 2;
        public static  DateTime IncDate = new DateTime();

        //=============================View: DossierMachine=========
        public static int NumMachine;
        //=============================View: DTRecieved=========
        public static int CodeMachine;
        public static int NumEquipement;
        public static DateTime DateIntervention;
        //=============================Tonnage========================
        public static double NetTonnage125 = 0.45;
        public static double BrutTonnage125 = 0.47;
        public static double NetTonnage130 = 0.51;
        public static double BrutTonnage130 = 0.43;
        public static double Total;
        public static int RealiseAtPs1;
        public static int RealiseAfterPs1;
        public static int RealiseAtPs2;
        public static int RealiseAfterPs2;
        public static int RealiseAtPs3;
        public static int RealiseAfterPs3;

        //=============================Methodes=======================
        public static async Task<int> CheckOtOperation(KBFsteelContext context, List<PlanningOperationsModel> planningOperationsModels,int IsDelete) 
        {
            foreach (var itemplanningOperationsModels in planningOperationsModels)
            {
                //clear
                int res = await ClearAppPreventif(context,IsDelete);

                //Reinit The planning from the day of intervention 
                var CurrentYear = XpertHelper.DateIntervention.Year;
                var endYear = CurrentYear + LimitYear;
                IncDate = XpertHelper.DateIntervention;
                var reportStill = 0;
                int first = 0;
                while(IncDate.Year <= endYear)
                {
                    first++;
                    MethAppointementsPreventifs methAppointementsPreventif = new MethAppointementsPreventifs();
                    var methAppointementsPreventifs = context.MethAppointementsPreventifs
                    .Select(i => new
                    {
                        i.AppointmentId,
                        i.StartDate,
                        i.IdOperation
                    }).ToList();
                    if (methAppointementsPreventifs.Count == 0)
                    {
                        methAppointementsPreventif.AppointmentId = 1;
                    }
                    else
                    {
                        var lastmethAppointementsPreventif = methAppointementsPreventifs.Last();
                        methAppointementsPreventif.AppointmentId = lastmethAppointementsPreventif.AppointmentId + 1;
                    }
                    methAppointementsPreventif.StartDate = IncDate.Date;
                    methAppointementsPreventif.EndDate = IncDate.Date;
                    methAppointementsPreventif.IdOperation = itemplanningOperationsModels.Idoperation;
                    var operationDetail = context.MethOperations
                    .AsNoTracking()
                    .Where(c => c.Idoperation == itemplanningOperationsModels.Idoperation)
                    .Select(i => new
                    {
                        i.Description,
                        i.NumEquipement,
                        i.NumMachine
                    }).FirstOrDefault();
                    //Get Machine 
                    var machineDetails = context.Machines
                         .AsNoTracking()
                         .Where(c => c.NumMachine == operationDetail.NumMachine)
                         .Select(i => new
                         {
                             i.NomMachine
                         }).FirstOrDefault();
                    //Get Equipement
                    var equipementsDetails = context.MethStructureMachine
                         .AsNoTracking()
                         .Where(c => c.Id == operationDetail.NumEquipement)
                         .Select(i => new
                         {
                             i.Equipement
                         }).FirstOrDefault();
                    methAppointementsPreventif.Text = machineDetails.NomMachine + " : " + equipementsDetails.Equipement;
                    if (XpertHelper.NumOtPreventif.Equals(null) || XpertHelper.NumOtPreventif == 0)
                    {
                        methAppointementsPreventif.Description = operationDetail.Description + " de l'équipement  " + equipementsDetails.Equipement + " de la machine " + machineDetails.NomMachine;
                    }
                    else
                    {
                        methAppointementsPreventif.Description = operationDetail.Description + " de l'équipement  " + equipementsDetails.Equipement + " de la machine " + machineDetails.NomMachine
                        + "/ Programmé à partir du Ot N°" + XpertHelper.NumOtPreventif;
                    }
                    //Check if it is in plannification or not
                    var exists = 0;
                    foreach (var itemmethAppointementsPreventifs in methAppointementsPreventifs)
                    {
                        if (itemmethAppointementsPreventifs.StartDate == methAppointementsPreventif.StartDate
                            && itemmethAppointementsPreventifs.IdOperation == methAppointementsPreventif.IdOperation)
                            exists = 1;
                    }
                    if(exists == 0)
                    {
                        if (first == 1)
                        {
                            methAppointementsPreventif.Statut = 2;//Fait

                        }
                        else
                        {
                            methAppointementsPreventif.Statut = 1;//En Attente
                        }
                        context.MethAppointementsPreventifs.Add(methAppointementsPreventif);
                    }

                    //Marking th X in the Ms of 12
                    if (reportStill == 0)
                    {
                        //Report
                        //Test if this one exists
                           var element = context.MethPlanningEtSuiviMateriel
                              .Where(c => c.IdOperation == itemplanningOperationsModels.Idoperation).ToList();
                        if(element.Count == 0)
                        {
                            //If it does not exists
                            MethPlanningEtSuiviMateriel methPlanningEtSuiviMaterielModel = new MethPlanningEtSuiviMateriel();
                            var methPlanningEtSuiviMateriels = context.MethPlanningEtSuiviMateriel
                                    .Select(i => new
                                    {
                                        i.Id
                                    }).ToList();
                            if (methPlanningEtSuiviMateriels.Count == 0)
                            {
                                methPlanningEtSuiviMaterielModel.Id = 1;
                            }
                            else
                            {
                                var lastmethPlanningEtSuiviMateriels = methPlanningEtSuiviMateriels.Last();
                                methPlanningEtSuiviMaterielModel.Id = lastmethPlanningEtSuiviMateriels.Id + 1;
                            }
                            //==============
                            methPlanningEtSuiviMaterielModel.ElementMachine = equipementsDetails.Equipement;
                            methPlanningEtSuiviMaterielModel.Activité = operationDetail.Description;
                            methPlanningEtSuiviMaterielModel.Fréquence = itemplanningOperationsModels.Fréquence;
                            methPlanningEtSuiviMaterielModel.CodeMachine = operationDetail.NumMachine;
                            methPlanningEtSuiviMaterielModel.Year = IncDate.Year;
                            methPlanningEtSuiviMaterielModel.IdOperation = itemplanningOperationsModels.Idoperation;
                            if (!XpertHelper.NumOtPreventif.Equals(null))
                                methPlanningEtSuiviMaterielModel.NumOt = (int)XpertHelper.NumOtPreventif;
                            if (IncDate.Month == 1)
                            {
                                methPlanningEtSuiviMaterielModel.M1 = Convert.ToBoolean(1);
                            }
                            if (IncDate.Month == 2)
                            {
                                methPlanningEtSuiviMaterielModel.M2 = Convert.ToBoolean(1);
                            }
                            if (IncDate.Month == 3)
                            {
                                methPlanningEtSuiviMaterielModel.M3 = Convert.ToBoolean(1);
                            }
                            if (IncDate.Month == 4)
                            {
                                methPlanningEtSuiviMaterielModel.M4 = Convert.ToBoolean(1);
                            }
                            if (IncDate.Month == 5)
                            {
                                methPlanningEtSuiviMaterielModel.M5 = Convert.ToBoolean(1);
                            }
                            if (IncDate.Month == 6)
                            {
                                methPlanningEtSuiviMaterielModel.M6 = Convert.ToBoolean(1);
                            }
                            if (IncDate.Month == 7)
                            {
                                methPlanningEtSuiviMaterielModel.M7 = Convert.ToBoolean(1);
                            }
                            if (IncDate.Month == 8)
                            {
                                methPlanningEtSuiviMaterielModel.M8 = Convert.ToBoolean(1);
                            }
                            if (IncDate.Month == 9)
                            {
                                methPlanningEtSuiviMaterielModel.M9 = Convert.ToBoolean(1);
                            }
                            if (IncDate.Month == 10)
                            {
                                methPlanningEtSuiviMaterielModel.M10 = Convert.ToBoolean(1);
                            }
                            if (IncDate.Month == 11)
                            {
                                methPlanningEtSuiviMaterielModel.M11 = Convert.ToBoolean(1);
                            }
                            if (IncDate.Month == 12)
                            {
                                methPlanningEtSuiviMaterielModel.M12 = Convert.ToBoolean(1);
                            }
                            for (int i = IncDate.Month; i <= 12; i = i + methPlanningEtSuiviMaterielModel.Fréquence)
                            {
                                if (i == 1)
                                {
                                    methPlanningEtSuiviMaterielModel.M1 = Convert.ToBoolean(1);
                                }
                                if (i == 2)
                                {
                                    methPlanningEtSuiviMaterielModel.M2 = Convert.ToBoolean(1);
                                }
                                if (i == 3)
                                {
                                    methPlanningEtSuiviMaterielModel.M3 = Convert.ToBoolean(1);
                                }
                                if (i == 4)
                                {
                                    methPlanningEtSuiviMaterielModel.M4 = Convert.ToBoolean(1);
                                }
                                if (i == 5)
                                {
                                    methPlanningEtSuiviMaterielModel.M5 = Convert.ToBoolean(1);
                                }
                                if (i == 6)
                                {
                                    methPlanningEtSuiviMaterielModel.M6 = Convert.ToBoolean(1);
                                }
                                if (i == 7)
                                {
                                    methPlanningEtSuiviMaterielModel.M7 = Convert.ToBoolean(1);
                                }
                                if (i == 8)
                                {
                                    methPlanningEtSuiviMaterielModel.M8 = Convert.ToBoolean(1);
                                }
                                if (i == 9)
                                {
                                    methPlanningEtSuiviMaterielModel.M9 = Convert.ToBoolean(1);
                                }
                                if (i == 10)
                                {
                                    methPlanningEtSuiviMaterielModel.M10 = Convert.ToBoolean(1);
                                }
                                if (i == 11)
                                {
                                    methPlanningEtSuiviMaterielModel.M11 = Convert.ToBoolean(1);
                                }
                                if (i == 12)
                                {
                                    methPlanningEtSuiviMaterielModel.M12 = Convert.ToBoolean(1);
                                }
                            }
                            context.MethPlanningEtSuiviMateriel.Add(methPlanningEtSuiviMaterielModel);
                            reportStill++;
                        }else
                        {
                            //if this exists
                            var LastEle = element.LastOrDefault();
                            if (IncDate.Month == 1)
                            {
                                LastEle.M1 = Convert.ToBoolean(1);
                            }
                            if (IncDate.Month == 2)
                            {
                                LastEle.M2 = Convert.ToBoolean(1);
                            }
                            if (IncDate.Month == 3)
                            {
                                LastEle.M3 = Convert.ToBoolean(1);
                            }
                            if (IncDate.Month == 4)
                            {
                                LastEle.M4 = Convert.ToBoolean(1);
                            }
                            if (IncDate.Month == 5)
                            {
                                LastEle.M5 = Convert.ToBoolean(1);
                            }
                            if (IncDate.Month == 6)
                            {
                                LastEle.M6 = Convert.ToBoolean(1);
                            }
                            if (IncDate.Month == 7)
                            {
                                LastEle.M7 = Convert.ToBoolean(1);
                            }
                            if (IncDate.Month == 8)
                            {
                                LastEle.M8 = Convert.ToBoolean(1);
                            }
                            if (IncDate.Month == 9)
                            {
                                LastEle.M9 = Convert.ToBoolean(1);
                            }
                            if (IncDate.Month == 10)
                            {
                                LastEle.M10 = Convert.ToBoolean(1);
                            }
                            if (IncDate.Month == 11)
                            {
                                LastEle.M11 = Convert.ToBoolean(1);
                            }
                            if (IncDate.Month == 12)
                            {
                                LastEle.M12 = Convert.ToBoolean(1);
                            }
                            List<int> months = new List<int>();
                            for (int i = IncDate.Month; i <= 12; i = i + LastEle.Fréquence)
                            {
                                if (i == 1)
                                {
                                    LastEle.M1 = Convert.ToBoolean(1);
                                    months.Add(i);
                                }
                                if (i == 2)
                                {
                                    LastEle.M2 = Convert.ToBoolean(1);
                                    months.Add(i);
                                }
                                if (i == 3)
                                {
                                    LastEle.M3 = Convert.ToBoolean(1);
                                    months.Add(i);
                                }
                                if (i == 4)
                                {
                                    LastEle.M4 = Convert.ToBoolean(1);
                                    months.Add(i);
                                }
                                if (i == 5)
                                {
                                    LastEle.M5 = Convert.ToBoolean(1);
                                    months.Add(i);
                                }
                                if (i == 6)
                                {
                                    LastEle.M6 = Convert.ToBoolean(1);
                                    months.Add(i);
                                }
                                if (i == 7)
                                {
                                    LastEle.M7 = Convert.ToBoolean(1);
                                    months.Add(i);
                                }
                                if (i == 8)
                                {
                                    LastEle.M8 = Convert.ToBoolean(1);
                                    months.Add(i);
                                }
                                if (i == 9)
                                {
                                    LastEle.M9 = Convert.ToBoolean(1);
                                    months.Add(i);
                                }
                                if (i == 10)
                                {
                                    LastEle.M10 = Convert.ToBoolean(1);
                                    months.Add(i);
                                }
                                if (i == 11)
                                {
                                    LastEle.M11 = Convert.ToBoolean(1);
                                    months.Add(i);
                                }
                                if (i == 12)
                                {
                                    LastEle.M12 = Convert.ToBoolean(1);
                                    months.Add(i);
                                }
                            }
                            List<int> monthsRemove = new List<int>();
                            for (int i = 1; i <= 12;i ++)
                            {
                                if(!months.Contains(i))
                                {
                                    foreach (var itemmonths in months)
                                    {
                                        if(i > itemmonths)
                                        {
                                            if (i == 1)
                                            {
                                                LastEle.M1 = Convert.ToBoolean(0);
                                            }
                                            if (i == 2)
                                            {
                                                LastEle.M2 = Convert.ToBoolean(0);
                                            }
                                            if (i == 3)
                                            {
                                                LastEle.M3 = Convert.ToBoolean(0);
                                            }
                                            if (i == 4)
                                            {
                                                LastEle.M4 = Convert.ToBoolean(0);
                                            }
                                            if (i == 5)
                                            {
                                                LastEle.M5 = Convert.ToBoolean(0);
                                            }
                                            if (i == 6)
                                            {
                                                LastEle.M6 = Convert.ToBoolean(0);
                                            }
                                            if (i == 7)
                                            {
                                                LastEle.M7 = Convert.ToBoolean(0);
                                            }
                                            if (i == 8)
                                            {
                                                LastEle.M8 = Convert.ToBoolean(0);
                                            }
                                            if (i == 9)
                                            {
                                                LastEle.M9 = Convert.ToBoolean(0);
                                            }
                                            if (i == 10)
                                            {
                                                LastEle.M10 = Convert.ToBoolean(0);
                                            }
                                            if (i == 11)
                                            {
                                                LastEle.M11 = Convert.ToBoolean(0);
                                            }
                                            if (i == 12)
                                            {
                                                LastEle.M12 = Convert.ToBoolean(0);
                                            }
                                        }
                                    }
                                }
                            }
                            if (!XpertHelper.NumOtPreventif.Equals(null))
                                    LastEle.NumOt = (int)XpertHelper.NumOtPreventif;
                            context.MethPlanningEtSuiviMateriel.Update(LastEle);
                            reportStill++;
                        }
                    }
                    await context.SaveChangesAsync();
                    if (itemplanningOperationsModels.Unité == 1)
                    {
                        var newDayDate = IncDate.AddDays(itemplanningOperationsModels.Fréquence);
                        IncDate = newDayDate;
                    }//jours
                    if (itemplanningOperationsModels.Unité == 2)
                    {
                        var newDayDate = IncDate.AddMonths(itemplanningOperationsModels.Fréquence);
                        IncDate = newDayDate;
                    }//Mois
                    if (itemplanningOperationsModels.Unité == 3)
                    {
                        var newDayDate = IncDate.AddYears(itemplanningOperationsModels.Fréquence);
                        IncDate = newDayDate;
                    }//Annees
                }
            }
            //this is to not have errors in th case when an operation preventif gets add auto which means the XpertHelper.NumOtPreventif != 0
            // so i set it back to 0 in case i want to add manually after auto
            XpertHelper.NumOtPreventif = 0;
            return 1;
        }
        public static async Task<int> ComputeTonnage(KBFsteelContext context, JourneeProduction Poste)
        {
            var fact = 0.0;
            var totalTonnagePoste = 0.0;
            //Check if this poste Has Tonnage Calculated
            var TonnagesList = context.ProdTonnagesCages
                .AsNoTracking()
                .Select(i => new
                {
                    i.Id,
                    i.DateJournee,
                    i.Cage01,
                    i.Cage02,
                    i.Cage03,
                    i.Cage04,
                    i.Cage05,
                    i.Cage06,
                    i.Cage07,
                    i.Cage08,
                    i.Cage09,
                    i.Cage10,
                    i.Cage11,
                    i.Cage12,
                    i.Cage13
                }).ToList();
            var id = 0;
            foreach (var itemTonnagesList in TonnagesList)
            {
                if(itemTonnagesList.DateJournee.Date == Poste.Date.Date)
                {
                    id = itemTonnagesList.Id;
                }
            }//Get its Id if it does Exist
            if (id == 0)
            {
                ProdTonnagesCages newTonnage= new ProdTonnagesCages();
                newTonnage.Id = TonnagesList.Last().Id+1;
                newTonnage.DateJournee = Poste.Date;
                if (Convert.ToDouble(Poste.DimBillete) == 125)
                    fact = 0.47;
                if (Convert.ToDouble(Poste.DimBillete) == 130)
                    fact = 0.49;
                totalTonnagePoste = (double)Poste.NbrRealisee * fact;
                newTonnage.Cage01 = Convert.ToString(totalTonnagePoste);
                newTonnage.Cage02 = Convert.ToString(totalTonnagePoste);
                newTonnage.Cage03 = Convert.ToString(totalTonnagePoste);
                newTonnage.Cage04 = Convert.ToString(totalTonnagePoste);
                newTonnage.Cage05 = Convert.ToString(totalTonnagePoste);
                newTonnage.Cage06 = Convert.ToString(totalTonnagePoste);
                newTonnage.Cage07 = Convert.ToString(totalTonnagePoste);
                newTonnage.Cage08 = Convert.ToString(totalTonnagePoste);
                newTonnage.Cage09 = Convert.ToString(totalTonnagePoste);
                newTonnage.Cage10 = Convert.ToString(totalTonnagePoste);
                newTonnage.Cage11 = Convert.ToString(totalTonnagePoste);
                newTonnage.Cage12 = Convert.ToString(totalTonnagePoste);
                newTonnage.Cage13 = Convert.ToString(totalTonnagePoste);
                context.ProdTonnagesCages.Add(newTonnage);
                await context.SaveChangesAsync();

            }//If it does not exist
            else
            {
                var tonnageOld = context.ProdTonnagesCages
                    .AsNoTracking()
                    .Where(c => c.DateJournee.Date == Poste.Date.Date)
                    .Select(i => new
                    {
                        i.Id,
                        i.DateJournee,
                        i.Cage01,
                        i.Cage02,
                        i.Cage03,
                        i.Cage04,
                        i.Cage05,
                        i.Cage06,
                        i.Cage07,
                        i.Cage08,
                        i.Cage09,
                        i.Cage10,
                        i.Cage11,
                        i.Cage12,
                        i.Cage13
                    }).FirstOrDefault();
            }//If it does Exist
            return 1;
        }
        public static async Task<int> ClearPlanningPreventif(KBFsteelContext context)
        {
            //clear from the day of intervention 
            var DateTodelete = XpertHelper.DateIntervention;
            bool IsStill = true;
            while (IsStill)
            {
                var model = await context.MethPlanningPreventif.AsNoTracking()
                    .FirstOrDefaultAsync(item => item.DateRealisation >= DateTodelete && item.IdOperation == XpertHelper.IdOperation);
                if (model != null)
                {
                    var OpInfos = await context.MethOperations.FirstOrDefaultAsync(item => item.Idoperation == model.IdOperation);
                    context.MethPlanningPreventif.Remove(model);
                    if (OpInfos.Unité == 1)
                    {
                        var newDayDate = DateTodelete.AddDays(OpInfos.Fréquence);
                        DateTodelete = newDayDate;
                    }//jours
                    if (OpInfos.Unité == 2)
                    {
                        var newDayDate = DateTodelete.AddMonths(OpInfos.Fréquence);
                        DateTodelete = newDayDate;
                    }//Mois
                    if (OpInfos.Unité == 3)
                    {
                        var newDayDate = DateTodelete.AddYears(OpInfos.Fréquence);
                        DateTodelete = newDayDate;
                    }//Annees
                }
                else
                {
                    IsStill = false;
                }
            }
            return 1;
        }
        public static async Task<int> ClearAppPreventif(KBFsteelContext context, int IsDelete)
        {
            //clear from the day of intervention 
            var DateTodelete = XpertHelper.DateIntervention;
            bool IsStill = true;
            while (IsStill)
            {
                var modele = await context.MethAppointementsPreventifs
                    .FirstOrDefaultAsync(item => item.StartDate >= DateTodelete && item.IdOperation == XpertHelper.IdOperation);
                if (modele != null)
                {
                    var operationId = modele.IdOperation;
                    context.MethAppointementsPreventifs.Remove(modele);
                    context.SaveChanges();
                    var OpInfos = await context.MethOperations.AsNoTracking().Where(item => item.Idoperation == modele.IdOperation).FirstOrDefaultAsync();
                    if (OpInfos.Unité == 1)
                    {
                        var newDayDate = DateTodelete.AddDays(OpInfos.Fréquence);
                        DateTodelete = newDayDate;
                    }//jours
                    if (OpInfos.Unité == 2)
                    {
                        var newDayDate = DateTodelete.AddMonths(OpInfos.Fréquence);
                        DateTodelete = newDayDate;
                    }//Mois
                    if (OpInfos.Unité == 3)
                    {
                        var newDayDate = DateTodelete.AddYears(OpInfos.Fréquence);
                        DateTodelete = newDayDate;
                    }//Annees
                }
                else
                {
                    IsStill = false;
                }
                if (IsDelete == 1)
                {
                    //deleting now all those plannified Operation of the year of date to delete
                    var modeleSuivi = await context.MethPlanningEtSuiviMateriel
                        .FirstOrDefaultAsync(item => item.Year == DateTodelete.Year && item.IdOperation == XpertHelper.IdOperation);
                    while (!(modeleSuivi == null))
                    {
                        context.MethPlanningEtSuiviMateriel.Remove(modeleSuivi);
                        context.SaveChanges();
                        modeleSuivi = await context.MethPlanningEtSuiviMateriel
                        .FirstOrDefaultAsync(item => item.Year == DateTodelete.Year && item.IdOperation == XpertHelper.IdOperation);
                    }
                }
            }
            return 1;
        }
        public static async Task<int> CheckOtOperationFromRapportInterventions(KBFsteelContext context, RapportIntervention model)
        {

            var operations = context.MethOperations.AsNoTracking().Where(c => c.NumMachine == XpertHelper.CodeMachine && c.NumEquipement == XpertHelper.NumEquipement)
            .Select(i => new
            {
                i.Idoperation,
                i.Description,
                i.Fréquence,
                i.NumEquipement,
                i.NumMachine,
                i.Unité
            }).ToList();
            //TODO : Check from AssotTaches
            var traveaux = context.AssOtTraveaux.AsNoTracking().Where(c => c.NumOt == model.NumOt)
            .Select(i => new
            {
                i.TypeTraveaux,
                i.CodeMachine,
                i.CodeEquipement
            }).ToList();
                foreach (var itemtraveaux in traveaux)
                {
                    if (itemtraveaux.CodeEquipement != null & itemtraveaux.CodeEquipement != "" & itemtraveaux.CodeMachine != null)
                    {
                        var Typetraveaux = context.LookupTypeTraveauxOt.AsNoTracking().Where(c => c.Id == itemtraveaux.TypeTraveaux)
                                    .Select(i => new
                                    {
                                        i.Designation
                                    }).ToList();
                        var ValTypetraveaux = Typetraveaux.Last();
                        var operation = context.MethOperations.AsNoTracking()
                        .Where(c => c.NumMachine == Convert.ToInt32(itemtraveaux.CodeMachine) && c.NumEquipement == Convert.ToInt32(itemtraveaux.CodeEquipement) && c.Description.Equals(ValTypetraveaux.Designation))
                        .Select(i => new
                        {
                            i.Idoperation,
                            i.Description,
                            i.Fréquence,
                            i.NumEquipement,
                            i.NumMachine,
                            i.Unité
                        }).ToList();
                        if(operation.Count > 0)
                        {
                            var idOp = operation.Last();
                            XpertHelper.IdOperation = idOp.Idoperation;
                            XpertHelper.DateIntervention = model.DateIntervention;
                            List<PlanningOperationsModel> planningOperationsModels = new List<PlanningOperationsModel>();
                            foreach (var itemoperations in operation)
                            {
                                PlanningOperationsModel planningOperationsModel = new PlanningOperationsModel();
                                planningOperationsModel.Idoperation = itemoperations.Idoperation;
                                planningOperationsModel.Fréquence = itemoperations.Fréquence;
                                planningOperationsModel.Unité = itemoperations.Unité;
                                planningOperationsModel.Description = itemoperations.Description;
                                planningOperationsModel.NumEquipement = itemoperations.NumEquipement;
                                planningOperationsModel.NumMachine = itemoperations.NumMachine;
                                planningOperationsModel.Statut = 2;//Fait
                                planningOperationsModels.Add(planningOperationsModel);
                            }
                        XpertHelper.NumOtPreventif = model.NumOt;
                        var wt = await XpertHelper.CheckOtOperation(context, planningOperationsModels,0);
                        }
                    }
                }
            return 1;
        }
    }
}