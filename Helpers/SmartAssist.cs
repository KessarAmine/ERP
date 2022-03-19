using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevKbfSteel.Entities;

namespace DevKbfSteel.Helpers
{
    public static class SmartAssist
    {
        public static string SetDtRecuPath(int codeStructure)
        {
            if (codeStructure == XpertHelper.CodeMecanqiue)
            {
                return "MecaniqueManager/MecaniqueManager/DemandeTravailsMecaniqueRecieved";
            }
            if (codeStructure == XpertHelper.CodeExploitation)
            {
                return "ExploitationManager/ExploitationManager/DemandeTravailsExploitationRecieved";
            }
            if (codeStructure == XpertHelper.CodeMethode)
            {
                return "MethodeManager/MethodeManager/DemandeTravailsMethodeRecieved";
            }
            if (codeStructure == XpertHelper.CodeElectrique)
            {
                return "ElectriqueManager/ElectriqueManager/DemandeTravailsElectriqueRecieved";
            }            
            if (codeStructure == XpertHelper.CodeSodure)
            {
                return "SodureManager/SodureManager/DemandeTravailsSodureRecieved";
            }            
            if (codeStructure == XpertHelper.CodeUsinage)
            {
                return "UsinageManager/UsinageManager/DemandeTravailsUsinageRecieved";
            }
            return "";
        }
        public static string SetDtSentPath(int codeStructure)
        {
            if (codeStructure == XpertHelper.CodeMecanqiue)
            {
                return "MecaniqueManager/MecaniqueManager/DemandeTravailsMecaniqueSent";
            }
            if (codeStructure == XpertHelper.CodeExploitation)
            {
                return "ExploitationManager/ExploitationManager/DemandeTravailsExploitationSent";
            }
            if (codeStructure == XpertHelper.CodeMethode)
            {
                return "MethodeManager/MethodeManager/DemandeTravailsMethodeSent";
            }
            if (codeStructure == XpertHelper.CodeElectrique)
            {
                return "ElectriqueManager/ElectriqueManager/DemandeTravailsElectriqueSent";
            }
            if (codeStructure == XpertHelper.CodeSodure)
            {
                return "SodureManager/SodureManager/DemandeTravailsSodureSent";
            }
            if (codeStructure == XpertHelper.CodeUsinage)
            {
                return "UsinageManager/UsinageManager/DemandeTravailsUsinageSent";
            }
            return "";
        }
        public static string SetOtSuiviPath(int codeStructure)
        {
            if (codeStructure == XpertHelper.CodeMethode)
            {
                return "MethodeManager/MethodeManager/OrdresTravailsMethodeSuivi";
            }
            return "";
        }
        public static string SetOtSentPath(int codeStructure)
        {
            if (codeStructure == XpertHelper.CodeMecanqiue)
            {
                return "MecaniqueManager/MecaniqueManager/OrdresTravailMecaniqueSent";
            }
            if (codeStructure == XpertHelper.CodeExploitation)
            {
                return "ExploitationManager/ExploitationManager/OrdresTravailExploitationSent";
            }
            if (codeStructure == XpertHelper.CodeMethode)
            {
                return "MethodeManager/MethodeManager/OrdresTravailMethodeSent";
            }
            if (codeStructure == XpertHelper.CodeElectrique)
            {
                return "ElectriqueManager/ElectriqueManager/OrdresTravailElectriqueSent";
            }
            if (codeStructure == XpertHelper.CodeSodure)
            {
                return "SodureManager/SodureManager/OrdresTravailSodureSent";
            }
            if (codeStructure == XpertHelper.CodeUsinage)
            {
                return "UsinageManager/UsinageManager/OrdresTravailUsinageSent";
            }
            return "";
        }
        public static string SetOtRecuPath(int codeStructure)
        {
            if (codeStructure == XpertHelper.CodeMecanqiue)
            {
                return "MecaniqueManager/MecaniqueManager/OrdresTravailMecaniqueRecieved";
            }
            if (codeStructure == XpertHelper.CodeExploitation)
            {
                return "ExploitationManager/ExploitationManager/OrdresTravailExploitationRecieved";
            }
            if (codeStructure == XpertHelper.CodeMethode)
            {
                return "";
            }
            if (codeStructure == XpertHelper.CodeElectrique)
            {
                return "ElectriqueManager/ElectriqueManager/OrdresTravailElectriqueRecieved";
            }
            if (codeStructure == XpertHelper.CodeSodure)
            {
                return "SodureManager/SodureManager/OrdresTravailSodureRecieved";
            }
            if (codeStructure == XpertHelper.CodeUsinage)
            {
                return "UsinageManager/UsinageManager/OrdresTravailUsinageRecieved";
            }
            return "";
        }
        public static string SetPreventifPath(int codeStructure)
        {
            if (codeStructure == XpertHelper.CodeMecanqiue)
            {
                return "MecaniqueManager/MecaniqueManager/SchedulerPlanningPreventifs";
            }
            if (codeStructure == XpertHelper.CodeExploitation)
            {
                return "";
            }
            if (codeStructure == XpertHelper.CodeMethode)
            {
                return "";
            }
            if (codeStructure == XpertHelper.CodeElectrique)
            {
                return "ElectriqueManager/ElectriqueManager/SchedulerPlanningPreventifs";
            }
            return "";
        }
        public static string SetDemandeFourniturefPath(int codeStructure)
        {
            if (codeStructure == XpertHelper.CodeMecanqiue)
            {
                return "MecaniqueManager/MecaniqueManager/DemandesFourniture";
            }
            if (codeStructure == XpertHelper.CodeExploitation)
            {
                return "ExploitationManager/ExploitationManager/DemandesFourniture";
            }
            if (codeStructure == XpertHelper.CodeMethode)
            {
                return "MethodeManager/MethodeManager/DemandesFourniture";
            }
            if (codeStructure == XpertHelper.CodeElectrique)
            {
                return "ElectriqueManager/ElectriqueManager/DemandesFourniture";
            }
            if (codeStructure == XpertHelper.CodeSodure)
            {
                return "SodureManager/SodureManager/DemandesFourniture";
            }
            if (codeStructure == XpertHelper.CodeUsinage)
            {
                return "UsinageManager/UsinageManager/DemandesFourniture";
            }
            return "";
        }
        public static string SetPreProcessingPath(int codeStructure)
        {

            if (codeStructure == XpertHelper.CodeExploitation)
            {
                return "ExploitationManager/ExploitationManager/CylindrePreprocessing";
            }
            if (codeStructure == XpertHelper.CodeUsinage)
            {
                return "UsinageManager/UsinageManager/CylindrePreprocessing";
            }

            return "";
        }
        public static string SetAnomalieMachinePath(int codeStructure)
        {
            if (codeStructure == XpertHelper.CodeMecanqiue)
            {
                return "MecaniqueManager/MecaniqueManager/DossierMachines";
            }
            if (codeStructure == XpertHelper.CodeExploitation)
            {
                return "";
            }
            if (codeStructure == XpertHelper.CodeMethode)
            {
                return "MethodeManager/MethodeManager/DossierMachines";
            }
            if (codeStructure == XpertHelper.CodeElectrique)
            {
                return "ElectriqueManager/ElectriqueManager/DossierMachines";
            }
            return "";
        }
        public static string SetListeArticlesPath(int codeStructure)
        {
            if (codeStructure == 1)//Superviseur
            {
                return "MagasinSuperviseur/MagasinSuperviseur/ListeArticles";
            }
            if (codeStructure == 2)//Manager
            {
                return "MagasinManager/MagasinManager/ListeArticles";
            }
            return "";
        }
        public static string SetBonSortiePath()
        {
            return "GestionnaireMagasin/GestionnaireMagasin/Sorties";
        }
        public static string SetContratTravailPath()
        {
            return "RhManager/RhManager/ContratsEmployes";
        }
        public static string SetTonnageCagesPath()
        {
            return "ExploitationManager/ExploitationManager/TonnageCages";
        }

        //Smart Assist : Gives the correspanding Service the Taks He has to do

        // 1 gets The Dt (Recues, Envoyées) en Attente 
        public static List<SmartAssistItem> GetDtSentAttente(KBFsteelContext context, int CodeStructure)
        {
            List<SmartAssistItem> dts = new List<SmartAssistItem>();
            var demandesTravails = context.DemandeTravail
                 .Where(c => c.CodeStructure == CodeStructure && c.CodeStatut == 1)//1 : En attente
                 .Select(i => new
                 {
                     i.NumDt,
                     i.RefMachine,
                     i.TravailDemandee,
                     i.DateDt,
                     i.CodeStructure,
                     i.CodeReceveur
                 }).ToList();

            foreach (var itemdemandesTravails in demandesTravails)
            {
                SmartAssistItem dt = new SmartAssistItem();
                var tachesList = context.SmartAssistItem
                 .Select(i => new
                 {
                     i.Id
                 }).ToList();
                if(tachesList.Count == 0)
                {
                    dt.Id = 1;
                }
                else
                {
                    var last = tachesList.Last();
                    dt.Id = last.Id + 1;
                }

                var machine = context.Machines
                 .Where(c => c.NumMachine.ToString() == itemdemandesTravails.RefMachine).FirstOrDefault();
                string[] dateString = Convert.ToString(itemdemandesTravails.DateDt.Date).Split(" ");

                dt.Area = "Demande(s) Travail Envoyé(s) En attente";
                dt.CodeStructure = CodeStructure;
                dt.Path = SetDtSentPath(CodeStructure);
                var destinataire = context.Structure
                .Where(c => c.CodeStructure == Convert.ToInt32(itemdemandesTravails.CodeReceveur)).FirstOrDefault();
                if(machine == null)
                {
                    dt.Action = "DT Evoyé le : " + dateString[0] + ", service : "
                    + destinataire.Designation +" (En attente)";
                }
                else
                {
                    dt.Action = "DT Evoyé le : " + dateString[0] + ", service : "
                    + destinataire.Designation + ", Concernant :" + machine.NomMachine + " (En attente)";
                }

                //verifier quelle strcutre pour le Path
                dts.Add(dt);
            }
            return dts;
        }
        public static List<SmartAssistItem> GetDtSentEnCours(KBFsteelContext context, int CodeStructure)
        {
            List<SmartAssistItem> dts = new List<SmartAssistItem>();
            var demandesTravails = context.DemandeTravail
                 .Where(c => c.CodeStructure == CodeStructure && c.CodeStatut == 0)//1 : En Cours
                 .Select(i => new
                 {
                     i.NumDt,
                     i.RefMachine,
                     i.TravailDemandee,
                     i.DateDt,
                     i.CodeStructure,
                     i.CodeReceveur
                 }).ToList();

            foreach (var itemdemandesTravails in demandesTravails)
            {
                SmartAssistItem dt = new SmartAssistItem();
                var tachesList = context.SmartAssistItem
                 .Select(i => new
                 {
                     i.Id
                 }).ToList();
                if (tachesList.Count == 0)
                {
                    dt.Id = 1;
                }
                else
                {
                    var last = tachesList.Last();
                    dt.Id = last.Id + 1;
                }

                var machine = context.Machines
                 .Where(c => c.NumMachine.ToString() == itemdemandesTravails.RefMachine).FirstOrDefault();
                string[] dateString = Convert.ToString(itemdemandesTravails.DateDt.Date).Split(" ");

                dt.Area = "Demande(s) Travail Envoyé(s) En attente";
                dt.CodeStructure = CodeStructure;
                dt.Path = SetDtSentPath(CodeStructure);
                var destinataire = context.Structure
                .Where(c => c.CodeStructure == Convert.ToInt32(itemdemandesTravails.CodeReceveur)).FirstOrDefault();
                if(machine == null)
                {
                    dt.Action = "DT Evoyé le : " + dateString[0] + ", service : "
                    + destinataire.Designation +" (En Cours)";
                }
                else
                {
                    dt.Action = "DT Evoyé le : " + dateString[0] + ", service : "
                    + destinataire.Designation + ", Concernant :" + machine.NomMachine + " (En Cours)";
                }
                //verifier quelle strcutre pour le Path
                dts.Add(dt);
            }
            return dts;
        }
        public static List<SmartAssistItem> GetDtRecuesAttente(KBFsteelContext context, int CodeStructure)
        {
            List<SmartAssistItem> dts = new List<SmartAssistItem>();
            var demandesTravails = context.DemandeTravail
                 .Where(c => c.CodeReceveur == CodeStructure && c.CodeStatut == 1)//1 : En attente
                 .Select(i => new
                 {
                     i.NumDt,
                     i.RefMachine,
                     i.TravailDemandee,
                     i.DateDt,
                     i.CodeStructure
                 }).ToList();

            foreach (var itemdemandesTravails in demandesTravails)
            {
                SmartAssistItem dt = new SmartAssistItem();
                var tachesList = context.SmartAssistItem
                 .Select(i => new
                 {
                     i.Id
                 }).ToList();
                if (tachesList.Count== 0)
                {
                    dt.Id = 1;
                }
                else
                {
                    var last = tachesList.Last();
                    dt.Id = last.Id + 1;
                }
                string[] dateString = Convert.ToString(itemdemandesTravails.DateDt.Date).Split(" ");

                var machine = context.Machines
                 .Where(c => c.NumMachine.ToString() == itemdemandesTravails.RefMachine).FirstOrDefault();
                var destinataire = context.Structure
                 .Where(c => c.CodeStructure == itemdemandesTravails.CodeStructure).FirstOrDefault();
                dt.Area = "Demande(s) Travail Recue(s) En attente";
                dt.CodeStructure = CodeStructure;
                dt.Path = SetDtRecuPath(CodeStructure);
                if(machine == null)
                {
                    dt.Action = "DT Recue le : " + dateString[0] + ", service : "
                    + destinataire.Designation +" (En attente)";
                }
                else
                {
                    dt.Action = "DT Recue le : " + dateString[0] + ", service : "
                    + destinataire.Designation + ", Concernant :" + machine.NomMachine + " (En attente)";
                }

                //verifier quelle strcutre pour le Path
                dts.Add(dt);
            }
            return dts;
        }
        // 5 Gets Operation à faire dans la plannification
        public static List<SmartAssistItem> GetPreventif(KBFsteelContext context, int CodeStructure)
        {
            List<SmartAssistItem> dts = new List<SmartAssistItem>();
            var x = DateTime.Now.AddDays(1.0);
            var operations = context.MethAppointementsPreventifs
                 .Where(c => c.StartDate.Date == DateTime.Now.Date || c.StartDate.Date == x.Date)//1 : En attente
                 .Select(i => new
                 {
                     i.IdOperation,
                     i.StartDate,
                     i.Description
                 }).ToList();
            List<MethAppointementsPreventifs> methAppointementsPreventifs = new List<MethAppointementsPreventifs>();
            foreach (var itemoperations in operations)
            {
                var operation = context.MethOperations.Where(c => c.Idoperation == itemoperations.IdOperation).FirstOrDefault();
                if(operation.StructreConcernée == CodeStructure)
                {
                    string[] dateString = Convert.ToString(itemoperations.StartDate.Date).Split(" ");

                    SmartAssistItem dt = new SmartAssistItem();
                    dt.Area = "Opération preventif";
                    dt.CodeStructure = CodeStructure;
                    dt.Path = SetPreventifPath(CodeStructure);
                    dt.Action = "Preventif le : "+ dateString [0]+ ","+itemoperations.Description;
                    dts.Add(dt);
                }

            }
            return dts;
        }
        // 7 gets Anomalies of machines
        public static List<SmartAssistItem> GetMachinesAnomalies(KBFsteelContext context,int CodeStructure)
        {
            var currentMonth = DateTime.Now.Month;
            var currentYear = DateTime.Now.Year;
            List<SmartAssistItem> dts = new List<SmartAssistItem>();
            var machines = context.Machines
                .Select(i => new
                {
                    i.NumMachine,
                    i.SeuilAlerteAnoamlie,
                    i.NomMachine
                }).ToList();
            foreach (var itemmachines in machines)
            {
                var count = 0;
                var Alltravaux = context.AssOtTraveaux.Where(c => c.CodeMachine.Equals(itemmachines.NumMachine.ToString())).ToList();
                List<int> OtDone = new List<int>();
                foreach (var itemAlltravaux in Alltravaux)
                {
                    OtDone.Add(itemAlltravaux.NumOt);
                    //Check for occurences to avoid recalculating the Sam Ot with many Travaux
                    var occ = 0;
                    foreach (var itemOtDone in OtDone)
                    {
                        if(itemAlltravaux.NumOt== itemOtDone)
                        {
                            occ += 1;
                        }
                    }
                    if(occ == 1)
                    {
                        //No occurence lets do it
                        var ordres = context.OrdreTravail.Where(c => c.NumOt == itemAlltravaux.NumOt && c.DateOt.Month == currentMonth && c.DateOt.Year == currentYear && c.CodeMaintenance == Convert.ToBoolean(0)).ToList();
                        foreach (var itemordres in ordres)
                        {
                            var travaux = context.AssOtTraveaux.Where(c => c.NumOt == itemordres.NumOt).ToList();
                            if (!itemmachines.SeuilAlerteAnoamlie.Equals(null))
                            {
                                count += travaux.Count;
                                break;
                            }
                        }
                    }
                }
                if(count >= itemmachines.SeuilAlerteAnoamlie)
                {
                    SmartAssistItem dt = new SmartAssistItem();
                    dt.Area = "Machines/Anomalies";
                    dt.CodeStructure = CodeStructure;
                    dt.Path = SetAnomalieMachinePath(CodeStructure);
                    dt.Action = "Possibilité d'anomalie détecté dans la machine : " + itemmachines.NomMachine + ", ayant " + count + " pannes ce mois";
                    dts.Add(dt);
                }
            }
            return dts;
        }
        // 8 get Ot Envyée Par methodes En attente
        public static List<SmartAssistItem> GetOtSentAttente(KBFsteelContext context)
        {
            List<int> OtSentAttente = new List<int>();
            List<SmartAssistItem> dts = new List<SmartAssistItem>();
            var ordresTravails = context.OrdreTravail
                 .Where(c => c.CodeDemandeur == XpertHelper.CodeMethode)
                 .Select(i => new
                 {
                     i.NumOt,
                     i.DateOt,
                     i.CodeMachine,
                     i.CodeReceveur
                 }).ToList();
            foreach (var itemordresTravails in ordresTravails)
            {
                var raport = context.RapportIntervention.Where(c => c.NumOt == itemordresTravails.NumOt).FirstOrDefault();
                if (raport == null)
                {
                    OtSentAttente.Add(itemordresTravails.NumOt);
                }
            }
            if(OtSentAttente.Count > 0)
            {
                foreach (var itemOtSentAttente in OtSentAttente)
                {
                    var raport = context.OrdreTravail.Where(c => c.NumOt == itemOtSentAttente).FirstOrDefault();
                    SmartAssistItem dt = new SmartAssistItem();
                    var tachesList = context.SmartAssistItem
                     .Select(i => new
                     {
                         i.Id
                     }).ToList();
                    if (tachesList.Count == 0)
                    {
                        dt.Id = 1;
                    }
                    else
                    {
                        var last = tachesList.Last();
                        dt.Id = last.Id + 1;
                    }
                    var machine = context.Machines
                    .Where(c => c.NumMachine == raport.CodeMachine).FirstOrDefault();

                    dt.Area = "Demande(s) Travail Envoyé(s) En attente";
                    dt.CodeStructure = Convert.ToInt32(raport.CodeReceveur);
                    dt.Path = SetOtSentPath(XpertHelper.CodeMethode);
                    var destinataire = context.Structure
                    .Where(c => c.CodeStructure == Convert.ToInt32(raport.CodeReceveur)).FirstOrDefault();
                    string[] dateString = Convert.ToString(raport.DateOt.Date).Split(" ");
                    if (machine!= null)
                    {
                        dt.Action = "OT Evoyé le : " + dateString [0]+ ", service : "
                            + destinataire.Designation + ", Concernant :" + machine.NomMachine + " (En attente)";
                    }
                    else
                    {

                    }
                    dt.Action = "OT Evoyé le : " + dateString[0] + ", service : "+ destinataire.Designation+" (En attente)";
                    //verifier quelle strcutre pour le Path
                    dts.Add(dt);
                }
            }
            return dts;
        }
        // 9 get Ot Recu du methodes en attente
        public static List<SmartAssistItem> GetOtRecuAttente(KBFsteelContext context, int codeStructure)
        {
            List<int> OtSentAttente = new List<int>();
            List<SmartAssistItem> dts = new List<SmartAssistItem>();
            var ordresTravails = context.OrdreTravail
                 .Where(c => c.CodeDemandeur == XpertHelper.CodeMethode)
                .Where(c => c.CodeReceveur == codeStructure)
                 .Select(i => new
                 {
                     i.NumOt,
                     i.DateOt,
                     i.CodeMachine,
                     i.CodeReceveur
                 }).ToList();
            foreach (var itemordresTravails in ordresTravails)
            {
                var raport = context.RapportIntervention.Where(c => c.NumOt == itemordresTravails.NumOt).FirstOrDefault();
                if (raport == null)
                {
                    OtSentAttente.Add(itemordresTravails.NumOt);
                }
            }
            if (OtSentAttente.Count > 0)
            {
                foreach (var itemOtSentAttente in OtSentAttente)
                {
                    var raport = context.OrdreTravail.Where(c => c.NumOt == itemOtSentAttente).FirstOrDefault();
                    SmartAssistItem dt = new SmartAssistItem();
                    var tachesList = context.SmartAssistItem
                     .Select(i => new
                     {
                         i.Id
                     }).ToList();
                    if (tachesList.Count == 0)
                    {
                        dt.Id = 1;
                    }
                    else
                    {
                        var last = tachesList.Last();
                        dt.Id = last.Id + 1;
                    }
                    var machine = context.Machines
                    .Where(c => c.NumMachine == raport.CodeMachine).FirstOrDefault();
                    string[] dateString = Convert.ToString(raport.DateOt.Date).Split(" ");

                    dt.Area = "Demande(s) Travail Envoyé(s) En attente";
                    dt.CodeStructure = Convert.ToInt32(raport.CodeReceveur);
                    dt.Path = SetOtRecuPath(codeStructure);
                    var destinataire = context.Structure
                    .Where(c => c.CodeStructure == Convert.ToInt32(raport.CodeReceveur)).FirstOrDefault();
                    if (machine != null)
                    {
                        dt.Action = "OT Recu le : " + dateString[0] + ", Concernant :" + machine.NomMachine + " (En attente)";
                    }
                    else
                    {
                        dt.Action = "OT Recu le : " + dateString[0] + " (En attente)";
                    }
                    //verifier quelle strcutre pour le Path
                    dts.Add(dt);
                }
            }
            return dts;
        }
        // Get Cylindre under Preporcessings
        public static List<SmartAssistItem> GetCylindresunderPreporcess(KBFsteelContext context, int codeStructure)
        {
            List<SmartAssistItem> smartAssistItems = new List<SmartAssistItem>();
            var prodPreProccessingCylindresUsinageEnAttente = context.ProdPreProccessingCylindresUsinage.Where(c => c.EtatPreProcessing ==1).ToList();
            var prodPreProccessingCylindresUsinageEnCours = context.ProdPreProccessingCylindresUsinage.Where(c => c.EtatPreProcessing ==0).ToList();
            foreach (var itemprodPreProccessingCylindresUsinageEnAttente in prodPreProccessingCylindresUsinageEnAttente)
            {
                SmartAssistItem item = new SmartAssistItem();
                item.Area = "CylindrePreprocessing";
                item.CodeStructure = codeStructure;
                item.Path = SetPreProcessingPath(codeStructure);
                item.Action = "Preprocessing du cylindre " + itemprodPreProccessingCylindresUsinageEnAttente.RefCylindre+"(En Attente)";
                smartAssistItems.Add(item);
            }            
            foreach (var itemprodPreProccessingCylindresUsinageEnCours in prodPreProccessingCylindresUsinageEnCours)
            {
                SmartAssistItem item = new SmartAssistItem();
                item.Area = "CylindrePreprocessing";
                item.CodeStructure = codeStructure;
                item.Path = SetPreProcessingPath(codeStructure);
                item.Action = "Preprocessing du cylindre "+ itemprodPreProccessingCylindresUsinageEnCours.RefCylindre+"(En Cours)";
                smartAssistItems.Add(item);
            }
            return smartAssistItems;
        }
        // Get Contrat De travail en finition
        public static List<SmartAssistItem> GetContratTravailEnding(KBFsteelContext context)
        {
            List<SmartAssistItem> dts = new List<SmartAssistItem>();
            DateTime Now = DateTime.Now;
            var LimiteContrat = context.ConfigRhManager.FirstOrDefault().AlerteContratLimit;
            var contratsEncours = context.RhContratsEmployes.Where(c => c.Etat != 3).ToList();
            foreach (var itemcontratsEncours in contratsEncours)
            {
                if(Now.AddDays((double)LimiteContrat) >= itemcontratsEncours.DateFinAmbouche)
                {

                    SmartAssistItem dt = new SmartAssistItem();
                    dt.Area = "Contrat de travail ending";
                    dt.CodeStructure = Convert.ToInt32(XpertHelper.CodeRh);
                    dt.Path = SetContratTravailPath();
                    var employe = context.RhListeDesEmployes.FirstOrDefault(c => c.Id == itemcontratsEncours.IdEmployee);
                    var contrat = context.LookupTypeContrats.FirstOrDefault(c => c.CodeTypeContrat == itemcontratsEncours.TypeContrat);
                    dt.Action = "Renouvlement Contrat du type "+ contrat.DesignationTypeContrat+" pour "+ employe.Nom+" "+ employe.Prenom;
                    dts.Add(dt);
                }
            }
            return dts;
        }
        // 2 get Les demandes fournitures - 2 jour de la date Besoin
        public static List<SmartAssistItem> GetFournituresEnAttente(KBFsteelContext context, int codeStructure)
        {
            List<SmartAssistItem> dts = new List<SmartAssistItem>();
            DateTime Now = DateTime.Now;
            if(codeStructure == XpertHelper.CodeMecanqiue)
            {
                var LimiteLivraisonFournitureList = context.ConfigMecanique
                 .Select(i => new
                 {
                     i.LimiteDemandeFourniture
                 }).ToList();
                var LimiteLivraisonFourniture = 2;
                if (LimiteLivraisonFournitureList.Count() != 0)
                {
                    LimiteLivraisonFourniture = (int)LimiteLivraisonFournitureList.Last().LimiteDemandeFourniture;
                }
                var fournituresEnAttente = context.ApproDemandesFourniture.Where(c => c.Status.Equals("En Attente") && c.CodeServiceDemandeur == codeStructure).ToList();
                foreach (var itemfournituresEnAttente in fournituresEnAttente)
                {
                    if (LimiteLivraisonFourniture >= (itemfournituresEnAttente.DateBesoin.Date - Now.Date).TotalDays)
                    {
                        string[] dateString = Convert.ToString(itemfournituresEnAttente.DateBesoin.Date).Split(" ");
                        SmartAssistItem dt = new SmartAssistItem();
                        dt.Area = "Demande Fourniture Attente";
                        dt.CodeStructure = codeStructure;
                        dt.Path = SetDemandeFourniturefPath(codeStructure);
                        dt.Action = "Demande Fourniture N° " + itemfournituresEnAttente.NumeroDemande + ", pour le " + dateString[0] + "(En attente)";
                        dts.Add(dt);
                    }
                }
            }
            if(codeStructure == XpertHelper.CodeElectrique)
            {
                var LimiteLivraisonFournitureList = context.ConfigElectrique
                 .Select(i => new
                 {
                     i.LimiteDemandeFourniture
                 }).ToList();
                var LimiteLivraisonFourniture = 2;
                if (LimiteLivraisonFournitureList.Count() != 0)
                {
                    LimiteLivraisonFourniture = (int)LimiteLivraisonFournitureList.Last().LimiteDemandeFourniture;
                }
                var fournituresEnAttente = context.ApproDemandesFourniture.Where(c => c.Status.Equals("En Attente") && c.CodeServiceDemandeur == codeStructure).ToList();
                foreach (var itemfournituresEnAttente in fournituresEnAttente)
                {
                    if (LimiteLivraisonFourniture >= (itemfournituresEnAttente.DateBesoin.Date - Now.Date).TotalDays)
                    {
                        string[] dateString = Convert.ToString(itemfournituresEnAttente.DateBesoin.Date).Split(" ");
                        SmartAssistItem dt = new SmartAssistItem();
                        dt.Area = "Demande Fourniture Attente";
                        dt.CodeStructure = codeStructure;
                        dt.Path = SetDemandeFourniturefPath(codeStructure);
                        dt.Action = "Demande Fourniture N° " + itemfournituresEnAttente.NumeroDemande + ", pour le " + dateString[0] + "(En attente)";
                        dts.Add(dt);
                    }
                }
            }
            if(codeStructure == XpertHelper.CodeSodure)
            {
                var LimiteLivraisonFournitureList = context.ConfigSodure
                 .Select(i => new
                 {
                     i.LimiteDemandeFourniture
                 }).ToList();
                var LimiteLivraisonFourniture = 2;
                if (LimiteLivraisonFournitureList.Count() != 0)
                {
                    LimiteLivraisonFourniture = (int)LimiteLivraisonFournitureList.Last().LimiteDemandeFourniture;
                }
                var fournituresEnAttente = context.ApproDemandesFourniture.Where(c => c.Status.Equals("En Attente") && c.CodeServiceDemandeur == codeStructure).ToList();
                foreach (var itemfournituresEnAttente in fournituresEnAttente)
                {
                    if (LimiteLivraisonFourniture >= (itemfournituresEnAttente.DateBesoin.Date - Now.Date).TotalDays)
                    {
                        string[] dateString = Convert.ToString(itemfournituresEnAttente.DateBesoin.Date).Split(" ");
                        SmartAssistItem dt = new SmartAssistItem();
                        dt.Area = "Demande Fourniture Attente";
                        dt.CodeStructure = codeStructure;
                        dt.Path = SetDemandeFourniturefPath(codeStructure);
                        dt.Action = "Demande Fourniture N° " + itemfournituresEnAttente.NumeroDemande + ", pour le " + dateString[0] + "(En attente)";
                        dts.Add(dt);
                    }
                }
            }
            if(codeStructure == XpertHelper.CodeUsinage)
            {
                var LimiteLivraisonFournitureList = context.ConfigUsinage
                 .Select(i => new
                 {
                     i.LimiteDemandeFourniture
                 }).ToList();
                var LimiteLivraisonFourniture = 2;
                if (LimiteLivraisonFournitureList.Count() != 0)
                {
                    LimiteLivraisonFourniture = (int)LimiteLivraisonFournitureList.Last().LimiteDemandeFourniture;
                }
                var fournituresEnAttente = context.ApproDemandesFourniture.Where(c => c.Status.Equals("En Attente") && c.CodeServiceDemandeur == codeStructure).ToList();
                foreach (var itemfournituresEnAttente in fournituresEnAttente)
                {
                    if (LimiteLivraisonFourniture >= (itemfournituresEnAttente.DateBesoin.Date - Now.Date).TotalDays)
                    {
                        string[] dateString = Convert.ToString(itemfournituresEnAttente.DateBesoin.Date).Split(" ");
                        SmartAssistItem dt = new SmartAssistItem();
                        dt.Area = "Demande Fourniture Attente";
                        dt.CodeStructure = codeStructure;
                        dt.Path = SetDemandeFourniturefPath(codeStructure);
                        dt.Action = "Demande Fourniture N° " + itemfournituresEnAttente.NumeroDemande + ", pour le " + dateString[0] + "(En attente)";
                        dts.Add(dt);
                    }
                }
            }
            if(codeStructure == XpertHelper.CodeExploitation)
            {
                var LimiteLivraisonFournitureList = context.ConfigExploitation
                 .Select(i => new
                 {
                     i.LimiteDemandeFourniture
                 }).ToList();
                var LimiteLivraisonFourniture = 2;
                if (LimiteLivraisonFournitureList.Count() > 0)
                {
                    LimiteLivraisonFourniture = (int)LimiteLivraisonFournitureList.Last().LimiteDemandeFourniture;
                }
                var fournituresEnAttente = context.ApproDemandesFourniture.Where(c => c.Status.Equals("En Attente") && c.CodeServiceDemandeur == codeStructure).ToList();
                foreach (var itemfournituresEnAttente in fournituresEnAttente)
                {
                    if (LimiteLivraisonFourniture >= (itemfournituresEnAttente.DateBesoin.Date - Now.Date).TotalDays)
                    {
                        string[] dateString = Convert.ToString(itemfournituresEnAttente.DateBesoin.Date).Split(" ");
                        SmartAssistItem dt = new SmartAssistItem();
                        dt.Area = "Demande Fourniture Attente";
                        dt.CodeStructure = codeStructure;
                        dt.Path = SetDemandeFourniturefPath(codeStructure);
                        dt.Action = "Demande Fourniture N° " + itemfournituresEnAttente.NumeroDemande + ", pour le " + dateString[0] + "(En attente)";
                        dts.Add(dt);
                    }
                }
            }
            if(codeStructure == XpertHelper.CodeMethode)
            {
                var LimiteLivraisonFournitureList = context.ConfigMethode
                 .Select(i => new
                 {
                     i.LimiteDemandeFourniture
                 }).ToList();
                var LimiteLivraisonFourniture = 2;
                if (LimiteLivraisonFournitureList.Count() != 0)
                {
                    LimiteLivraisonFourniture = (int)LimiteLivraisonFournitureList.Last().LimiteDemandeFourniture;
                }
                var fournituresEnAttente = context.ApproDemandesFourniture.Where(c => c.Status.Equals("En Attente") && c.CodeServiceDemandeur == codeStructure).ToList();
                foreach (var itemfournituresEnAttente in fournituresEnAttente)
                {
                    if (LimiteLivraisonFourniture >= (itemfournituresEnAttente.DateBesoin.Date - Now.Date).TotalDays)
                    {
                        string[] dateString = Convert.ToString(itemfournituresEnAttente.DateBesoin.Date).Split(" ");
                        SmartAssistItem dt = new SmartAssistItem();
                        dt.Area = "Demande Fourniture Attente";
                        dt.CodeStructure = codeStructure;
                        dt.Path = SetDemandeFourniturefPath(codeStructure);
                        dt.Action = "Demande Fourniture N° " + itemfournituresEnAttente.NumeroDemande + ", pour le " + dateString[0] + "(En attente)";
                        dts.Add(dt);
                    }
                }
            }
            return dts;
        }
        // 6 gets Ot sans rapport de tout les services
        public static List<SmartAssistItem> GetOtSentSansRapportMethodes(KBFsteelContext context)
        {
            List<int> OtSentAttente = new List<int>();
            List<SmartAssistItem> dts = new List<SmartAssistItem>();
            var ordresTravails = context.OrdreTravail
                 .Select(i => new
                 {
                     i.NumOt,
                     i.DateOt,
                     i.CodeMachine,
                     i.CodeReceveur
                 }).ToList();
            foreach (var itemordresTravails in ordresTravails)
            {
                var raport = context.RapportIntervention.Where(c => c.NumOt == itemordresTravails.NumOt).FirstOrDefault();
                if (raport == null)
                {
                    OtSentAttente.Add(itemordresTravails.NumOt);
                }
            }
            if (OtSentAttente.Count > 0)
            {
                foreach (var itemOtSentAttente in OtSentAttente)
                {
                    var raport = context.OrdreTravail.Where(c => c.NumOt == itemOtSentAttente).FirstOrDefault();
                    var demandeur = context.Structure.Where(c => c.CodeStructure == raport.CodeDemandeur).FirstOrDefault();
                    SmartAssistItem dt = new SmartAssistItem();
                    var tachesList = context.SmartAssistItem
                     .Select(i => new
                     {
                         i.Id
                     }).ToList();
                    if (tachesList.Count == 0)
                    {
                        dt.Id = 1;
                    }
                    else
                    {
                        var last = tachesList.Last();
                        dt.Id = last.Id + 1;
                    }

                    dt.Area = "OT(s) Envoyé(s) sans rapport";
                    dt.CodeStructure = XpertHelper.CodeMethode;
                    dt.Path = SetOtSuiviPath(XpertHelper.CodeMethode);
                    string[] dateString = Convert.ToString(raport.DateOt.Date).Split(" ");
                    dt.Action = "OT N° "+ raport .NumOt+ " Evoyé le : " + dateString[0] + " sans rapport d'intervention; Emmetteur : "+ demandeur.Designation;
                    dts.Add(dt);
                }
            }
            return dts;
        }
        // 6 gets Ot sans rapport
        public static List<SmartAssistItem> GetOtSentSansRapport(KBFsteelContext context, int codeStructure)
        {
            List<int> OtSentAttente = new List<int>();
            List<SmartAssistItem> dts = new List<SmartAssistItem>();
            var ordresTravails = context.OrdreTravail
                 .Where(c => c.CodeDemandeur == codeStructure)
                 .Select(i => new
                 {
                     i.NumOt,
                     i.DateOt,
                     i.CodeMachine,
                     i.CodeReceveur
                 }).ToList();
            foreach (var itemordresTravails in ordresTravails)
            {
                var raport = context.RapportIntervention.Where(c => c.NumOt == itemordresTravails.NumOt).FirstOrDefault();
                if (raport == null)
                {
                    OtSentAttente.Add(itemordresTravails.NumOt);
                }
            }
            if (OtSentAttente.Count > 0)
            {
                foreach (var itemOtSentAttente in OtSentAttente)
                {
                    var raport = context.OrdreTravail.Where(c => c.NumOt == itemOtSentAttente).FirstOrDefault();
                    SmartAssistItem dt = new SmartAssistItem();
                    var tachesList = context.SmartAssistItem
                     .Select(i => new
                     {
                         i.Id
                     }).ToList();
                    if (tachesList.Count == 0)
                    {
                        dt.Id = 1;
                    }
                    else
                    {
                        var last = tachesList.Last();
                        dt.Id = last.Id + 1;
                    }

                    dt.Area = "OT(s) Envoyé(s) sans rapport";
                    dt.CodeStructure = codeStructure;
                    dt.Path = SetOtSentPath(codeStructure);
                    string[] dateString = Convert.ToString(raport.DateOt.Date).Split(" ");
                    dt.Action = "OT Evoyé le : " + dateString[0] + " sans rapport d'intervention";
                    dts.Add(dt);
                }
            }
            return dts;
        }
        // 6 gets Tonnage des cages en mise a vue
        public static List<SmartAssistItem> GetTonnageCagesWarnning(KBFsteelContext context)
        {
            List<SmartAssistItem> dts = new List<SmartAssistItem>();
            var Tonnage = context.ProdTonnagesCages
                .Select(i => new
                {
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
                    i.Cage13,
                }).ToList();
            if (Tonnage.Count > 0)
            {
                var LastToonage = Tonnage.Last();
                var LimiteTonnageCages = context.ConfigExploitation
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
                 }).ToList();
                if (LimiteTonnageCages.Count() > 0)
                {
                    var Value1 = 0.0;
                    var Value2 = 0.0;
                    var Value3 = 0.0;
                    var Value4 = 0.0;
                    var Value5 = 0.0;
                    var Value6 = 0.0;
                    var Value7 = 0.0;
                    var Value8 = 0.0;
                    var Value9 = 0.0;
                    var Value10 = 0.0;
                    var Value11 = 0.0;
                    var Value12 = 0.0;
                    var Value13 = 0.0;

                    if (LastToonage.Cage01.Contains("-"))
                    {
                        var splited = LastToonage.Cage01.Split("-");
                        Value1 = double.Parse(splited[1]);
                    }
                    else
                    {
                        Value1 = Convert.ToDouble(LastToonage.Cage01.ToString());
                    }
                    if (LastToonage.Cage02.Contains("-"))
                    {
                        var splited = LastToonage.Cage02.Split("-");
                        Value2 = double.Parse(splited[1]);
                    }
                    else
                    {
                        Value2 = Convert.ToDouble(LastToonage.Cage02.ToString());
                    }
                    if (LastToonage.Cage03.Contains("-"))
                    {
                        var splited = LastToonage.Cage03.Split("-");
                        Value3 = double.Parse(splited[1]);
                    }
                    else
                    {
                        Value3 = Convert.ToDouble(LastToonage.Cage03.ToString());
                    }
                    if (LastToonage.Cage04.Contains("-"))
                    {
                        var splited = LastToonage.Cage04.Split("-");
                        Value4 = double.Parse(splited[1]);
                    }
                    else
                    {
                        Value4 = Convert.ToDouble(LastToonage.Cage04.ToString());
                    }
                    if (LastToonage.Cage05.Contains("-"))
                    {
                        var splited = LastToonage.Cage05.Split("-");
                        Value5 = double.Parse(splited[1]);
                    }
                    else
                    {
                        Value5 = Convert.ToDouble(LastToonage.Cage05.ToString());
                    }
                    if (LastToonage.Cage06.Contains("-"))
                    {
                        var splited = LastToonage.Cage06.Split("-");
                        Value6 = double.Parse(splited[1]);
                    }
                    else
                    {
                        Value6 = Convert.ToDouble(LastToonage.Cage06.ToString());
                    }
                    if (LastToonage.Cage07.Contains("-"))
                    {
                        var splited = LastToonage.Cage07.Split("-");
                        Value7 = double.Parse(splited[1]);
                    }
                    else
                    {
                        Value7 = Convert.ToDouble(LastToonage.Cage07.ToString());
                    }
                    if (LastToonage.Cage08.Contains("-"))
                    {
                        var splited = LastToonage.Cage08.Split("-");
                        Value8 = double.Parse(splited[1]);
                    }
                    else
                    {
                        Value8 = Convert.ToDouble(LastToonage.Cage08.ToString());
                    }
                    if (LastToonage.Cage09.Contains("-"))
                    {
                        var splited = LastToonage.Cage09.Split("-");
                        Value9 = double.Parse(splited[1]);
                    }
                    else
                    {
                        Value9 = Convert.ToDouble(LastToonage.Cage09.ToString());
                    }
                    if (LastToonage.Cage10.Contains("-"))
                    {
                        var splited = LastToonage.Cage10.Split("-");
                        Value10 = double.Parse(splited[1]);
                    }
                    else
                    {
                        Value10 = Convert.ToDouble(LastToonage.Cage10.ToString());
                    }
                    if (LastToonage.Cage11.Contains("-"))
                    {
                        var splited = LastToonage.Cage11.Split("-");
                        Value11 = double.Parse(splited[1]);
                    }
                    else
                    {
                        Value11 = Convert.ToDouble(LastToonage.Cage11.ToString());
                    }
                    if (LastToonage.Cage12.Contains("-"))
                    {
                        var splited = LastToonage.Cage12.Split("-");
                        Value12 = double.Parse(splited[1]);
                    }
                    else
                    {
                        Value12 = Convert.ToDouble(LastToonage.Cage12.ToString());
                    }
                    if (LastToonage.Cage13.Contains("-"))
                    {
                        var splited = LastToonage.Cage13.Split("-");
                        Value13 = double.Parse(splited[1]);
                    }
                    else
                    {
                        Value13 = Convert.ToDouble(LastToonage.Cage13.ToString());
                    }

                    if (LimiteTonnageCages.Last().LimiteCage1 != null)
                    {
                        if (Value1 >= LimiteTonnageCages.Last().LimiteCage1)
                        {
                            SmartAssistItem dt = new SmartAssistItem();
                            dt.Area = "Tonnage Cages Atteint";
                            dt.CodeStructure = XpertHelper.CodeExploitation;
                            dt.Path = SetTonnageCagesPath();
                            dt.Action = "Tonnage cage1 atteint avec une valeur de " + Value1+" T";
                            dts.Add(dt);
                        }
                    }
                    if (LimiteTonnageCages.Last().LimiteCage2 != null)
                    {
                        if (Value2 >= LimiteTonnageCages.Last().LimiteCage2)
                        {
                            SmartAssistItem dt = new SmartAssistItem();
                            dt.Area = "Tonnage Cages Atteint";
                            dt.CodeStructure = XpertHelper.CodeExploitation;
                            dt.Path = SetTonnageCagesPath();
                            dt.Action = "Tonnage cage2 atteint avec une valeur de " + Value2;
                            dts.Add(dt);
                        }
                    }
                    if (LimiteTonnageCages.Last().LimiteCage3 != null)
                    {
                        if (Value3 >= LimiteTonnageCages.Last().LimiteCage3)
                        {
                            SmartAssistItem dt = new SmartAssistItem();
                            dt.Area = "Tonnage Cages Atteint";
                            dt.CodeStructure = XpertHelper.CodeExploitation;
                            dt.Path = SetTonnageCagesPath();
                            dt.Action = "Tonnage cage3 atteint avec une valeur de" + Value3+"T";
                            dts.Add(dt);
                        }
                    }
                    if (LimiteTonnageCages.Last().LimiteCage4 != null)
                    {
                        if (Value4 >= LimiteTonnageCages.Last().LimiteCage4)
                        {
                            SmartAssistItem dt = new SmartAssistItem();
                            dt.Area = "Tonnage Cages Atteint";
                            dt.CodeStructure = XpertHelper.CodeExploitation;
                            dt.Path = SetTonnageCagesPath();
                            dt.Action = "Tonnage cage4 atteint avec une valeur de " + Value4+"T";
                            dts.Add(dt);
                        }
                    }
                    if (LimiteTonnageCages.Last().LimiteCage5 != null)
                    {
                        if (Value5 >= LimiteTonnageCages.Last().LimiteCage5)
                        {
                            SmartAssistItem dt = new SmartAssistItem();
                            dt.Area = "Tonnage Cages Atteint";
                            dt.CodeStructure = XpertHelper.CodeExploitation;
                            dt.Path = SetTonnageCagesPath();
                            dt.Action = "Tonnage cage5 atteint avec une valeur de " + Value5 + "T";
                            dts.Add(dt);
                        }
                    }
                    if (LimiteTonnageCages.Last().LimiteCage6 != null)
                    {
                        if (Value6 >= LimiteTonnageCages.Last().LimiteCage6)
                        {
                            SmartAssistItem dt = new SmartAssistItem();
                            dt.Area = "Tonnage Cages Atteint";
                            dt.CodeStructure = XpertHelper.CodeExploitation;
                            dt.Path = SetTonnageCagesPath();
                            dt.Action = "Tonnage cage6 atteint avec une valeur de " + Value6 + "T";
                            dts.Add(dt);
                        }
                    }
                    if (LimiteTonnageCages.Last().LimiteCage7 != null)
                    {
                        if (Value7 >= LimiteTonnageCages.Last().LimiteCage7)
                        {
                            SmartAssistItem dt = new SmartAssistItem();
                            dt.Area = "Tonnage Cages Atteint";
                            dt.CodeStructure = XpertHelper.CodeExploitation;
                            dt.Path = SetTonnageCagesPath();
                            dt.Action = "Tonnage cage7 atteint avec une valeur de" + Value7 + "T";
                            dts.Add(dt);
                        }
                    }
                    if (LimiteTonnageCages.Last().LimiteCage8 != null)
                    {
                        if (Value8 >= LimiteTonnageCages.Last().LimiteCage8)
                        {
                            SmartAssistItem dt = new SmartAssistItem();
                            dt.Area = "Tonnage Cages Atteint";
                            dt.CodeStructure = XpertHelper.CodeExploitation;
                            dt.Path = SetTonnageCagesPath();
                            dt.Action = "Tonnage cage8 atteint avec une valeur de " + Value8 + "T";
                            dts.Add(dt);
                        }
                    }
                    if (LimiteTonnageCages.Last().LimiteCage9 != null)
                    {
                        if (Value9 >= LimiteTonnageCages.Last().LimiteCage9)
                        {
                            SmartAssistItem dt = new SmartAssistItem();
                            dt.Area = "Tonnage Cages Atteint";
                            dt.CodeStructure = XpertHelper.CodeExploitation;
                            dt.Path = SetTonnageCagesPath();
                            dt.Action = "Tonnage cage9 atteint avec une valeur de" + Value9 + "T";
                            dts.Add(dt);
                        }
                    }
                    if (LimiteTonnageCages.Last().LimiteCage10 != null)
                    {
                        if (Value10 >= LimiteTonnageCages.Last().LimiteCage10)
                        {
                            SmartAssistItem dt = new SmartAssistItem();
                            dt.Area = "Tonnage Cages Atteint";
                            dt.CodeStructure = XpertHelper.CodeExploitation;
                            dt.Path = SetTonnageCagesPath();
                            dt.Action = "Tonnage cage10 atteint avec une valeur de " + Value10 + "T";
                            dts.Add(dt);
                        }
                    }
                    if (LimiteTonnageCages.Last().LimiteCage11 != null)
                    {
                        if (Value11 >= LimiteTonnageCages.Last().LimiteCage11)
                        {
                            SmartAssistItem dt = new SmartAssistItem();
                            dt.Area = "Tonnage Cages Atteint";
                            dt.CodeStructure = XpertHelper.CodeExploitation;
                            dt.Path = SetTonnageCagesPath();
                            dt.Action = "Tonnage cage11 atteint avec une valeur de " + Value11 + "T";
                            dts.Add(dt);
                        }
                    }
                    if (LimiteTonnageCages.Last().LimiteCage12 != null)
                    {
                        if (Value12 >= LimiteTonnageCages.Last().LimiteCage12)
                        {
                            SmartAssistItem dt = new SmartAssistItem();
                            dt.Area = "Tonnage Cages Atteint";
                            dt.CodeStructure = XpertHelper.CodeExploitation;
                            dt.Path = SetTonnageCagesPath();
                            dt.Action = "Tonnage cage12 atteint avec une valeur de " + Value12 + "T";
                            dts.Add(dt);
                        }
                    }
                    if (LimiteTonnageCages.Last().LimiteCage13 != null)
                    {
                        if (Value13 >= LimiteTonnageCages.Last().LimiteCage13)
                        {
                            SmartAssistItem dt = new SmartAssistItem();
                            dt.Area = "Tonnage Cages Atteint";
                            dt.CodeStructure = XpertHelper.CodeExploitation;
                            dt.Path = SetTonnageCagesPath();
                            dt.Action = "Tonnage cage13 atteint avec une valeur de " + Value13 + "T";
                            dts.Add(dt);
                        }
                    }
                }
            }
            return dts;
        }
        // 3 get Pdr Stock Alerte
        public static List<SmartAssistItem> GetArticleStockAlerte(KBFsteelContext context,int codeStructure)
        {
            List<SmartAssistItem> dts = new List<SmartAssistItem>();
            var articles = context.StkPdr
                 .Select(i => new
                 {
                     i.CodePdr
                 }).ToList();
            foreach (var itemarticles in articles)
            {
                var movementsPdr = context.StkMovements
                .Where(c => c.CodePdr == itemarticles.CodePdr)
                .Select(i => new
                {
                    i.ValeurStockTotal
                }).ToList();
                if(movementsPdr.Count() >0)
                {
                    var LastMvt = movementsPdr.Last();
                    var contrainteStock = context.StkPdrStockContrainte
                        .Where(c => c.CodePdr == itemarticles.CodePdr)
                        .Select(i => new
                        {
                            i.StockAlerte
                        }).ToList();
                    if (contrainteStock.Count() > 0)
                    {
                        var StockAlert = contrainteStock.Last().StockAlerte;
                        if(StockAlert >= LastMvt.ValeurStockTotal)
                        {
                            SmartAssistItem dt = new SmartAssistItem();
                            dt.Area = "StockAlerte";
                            dt.CodeStructure = XpertHelper.CodeMagasin;
                            dt.Path = SetListeArticlesPath(codeStructure);
                            dt.Action = "Stock Alerte singalé: Article N° " + itemarticles.CodePdr;
                            dts.Add(dt);
                        }
                    }
                }
            }
            return dts;
        }
        // 10 get Pdr A SURVEILLER ATTEINT

        // 11 getLast Bs Entrée 
        // 12 get Bs sans détails
        public static List<SmartAssistItem> GetSoritesSansDetails(KBFsteelContext context)
        {
            List<SmartAssistItem> BsList = new List<SmartAssistItem>();
            var StkBonSortie = context.StkBonSortie
             .Select(i => new
             {
                 i.NumBonSortie
             }).ToList();
            foreach (var itemStkBonSortie in StkBonSortie)
            {
                var StkBonSortieArticles = context.StkBonSortieArticles
                     .Where(c => c.NumBonSortie == itemStkBonSortie.NumBonSortie)
                     .Select(i => new
                     {
                         i.NumBonSortie
                     }).ToList();
                if(StkBonSortieArticles.Count == 0)
                {
                    SmartAssistItem bs = new SmartAssistItem();
                    bs.Area = "BS sans détails";
                    bs.CodeStructure = XpertHelper.CodeMagasin;
                    bs.Path = SetBonSortiePath();
                    bs.Action = "BS N° " + itemStkBonSortie.NumBonSortie + " n'as pas de détails";
                    BsList.Add(bs);
                }
            }
            return BsList;
        }
    }
}
