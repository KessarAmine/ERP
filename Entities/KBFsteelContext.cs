using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DevKbfSteel.Entities
{
    public partial class KBFsteelContext : DbContext
    {
        public KBFsteelContext()
        {
        }

        public KBFsteelContext(DbContextOptions<KBFsteelContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ApproArticlesDemandes> ApproArticlesDemandes { get; set; }
        public virtual DbSet<ApproArticlesEntres> ApproArticlesEntres { get; set; }
        public virtual DbSet<ApproBonLivraison> ApproBonLivraison { get; set; }
        public virtual DbSet<ApproBonsEntrees> ApproBonsEntrees { get; set; }
        public virtual DbSet<ApproDemandeAchats> ApproDemandeAchats { get; set; }
        public virtual DbSet<ApproDemandeService> ApproDemandeService { get; set; }
        public virtual DbSet<ApproDemandeServiceDetail> ApproDemandeServiceDetail { get; set; }
        public virtual DbSet<ApproDemandesFourniture> ApproDemandesFourniture { get; set; }
        public virtual DbSet<ApproFabricants> ApproFabricants { get; set; }
        public virtual DbSet<ApproFournisseurs> ApproFournisseurs { get; set; }
        public virtual DbSet<ApproFournituresArticles> ApproFournituresArticles { get; set; }
        public virtual DbSet<ApproFournituresArticlesNongere> ApproFournituresArticlesNongere { get; set; }
        public virtual DbSet<ApproNatureDemandeFourniture> ApproNatureDemandeFourniture { get; set; }
        public virtual DbSet<ApproServicesDemandeurs> ApproServicesDemandeurs { get; set; }
        public virtual DbSet<ApproStatut> ApproStatut { get; set; }
        public virtual DbSet<ArretProductionJournee> ArretProductionJournee { get; set; }
        public virtual DbSet<ArreteProduction> ArreteProduction { get; set; }
        public virtual DbSet<AssOtConsommable> AssOtConsommable { get; set; }
        public virtual DbSet<AssOtIntervenants> AssOtIntervenants { get; set; }
        public virtual DbSet<AssOtOutils> AssOtOutils { get; set; }
        public virtual DbSet<AssOtPdr> AssOtPdr { get; set; }
        public virtual DbSet<AssOtTraveaux> AssOtTraveaux { get; set; }
        public virtual DbSet<AssStkPdrGisement> AssStkPdrGisement { get; set; }
        public virtual DbSet<AssStructureDerigants> AssStructureDerigants { get; set; }
        public virtual DbSet<AteliersTable> AteliersTable { get; set; }
        public virtual DbSet<BonProduction> BonProduction { get; set; }
        public virtual DbSet<CadenceProductionJournee> CadenceProductionJournee { get; set; }
        public virtual DbSet<Compositions> Compositions { get; set; }
        public virtual DbSet<ComptComptesComptable> ComptComptesComptable { get; set; }
        public virtual DbSet<ConfigElectrique> ConfigElectrique { get; set; }
        public virtual DbSet<ConfigExploitation> ConfigExploitation { get; set; }
        public virtual DbSet<ConfigMecanique> ConfigMecanique { get; set; }
        public virtual DbSet<ConfigMethode> ConfigMethode { get; set; }
        public virtual DbSet<ConfigRhManager> ConfigRhManager { get; set; }
        public virtual DbSet<ConfigSodure> ConfigSodure { get; set; }
        public virtual DbSet<ConfigUsinage> ConfigUsinage { get; set; }
        public virtual DbSet<Consignation> Consignation { get; set; }
        public virtual DbSet<ConsignationDetails> ConsignationDetails { get; set; }
        public virtual DbSet<DebugMaitenanceType> DebugMaitenanceType { get; set; }
        public virtual DbSet<Deconsignation> Deconsignation { get; set; }
        public virtual DbSet<DemandeTravail> DemandeTravail { get; set; }
        public virtual DbSet<EnumArret> EnumArret { get; set; }
        public virtual DbSet<Equipements> Equipements { get; set; }
        public virtual DbSet<GrhAgencesBancaire> GrhAgencesBancaire { get; set; }
        public virtual DbSet<GrhFormations> GrhFormations { get; set; }
        public virtual DbSet<GrhFormationsPersonnels> GrhFormationsPersonnels { get; set; }
        public virtual DbSet<GrhLookupNatureAgenceBnacaire> GrhLookupNatureAgenceBnacaire { get; set; }
        public virtual DbSet<GrhNumericVisas> GrhNumericVisas { get; set; }
        public virtual DbSet<GrhPostes> GrhPostes { get; set; }
        public virtual DbSet<GroupeMachines> GroupeMachines { get; set; }
        public virtual DbSet<Intervenant> Intervenant { get; set; }
        public virtual DbSet<JourneeProduction> JourneeProduction { get; set; }
        public virtual DbSet<LookupCivilite> LookupCivilite { get; set; }
        public virtual DbSet<LookupCloture> LookupCloture { get; set; }
        public virtual DbSet<LookupDestinationDf> LookupDestinationDf { get; set; }
        public virtual DbSet<LookupDevise> LookupDevise { get; set; }
        public virtual DbSet<LookupEquipeInventaire> LookupEquipeInventaire { get; set; }
        public virtual DbSet<LookupEquipes> LookupEquipes { get; set; }
        public virtual DbSet<LookupEtatContrat> LookupEtatContrat { get; set; }
        public virtual DbSet<LookupPays> LookupPays { get; set; }
        public virtual DbSet<LookupSexe> LookupSexe { get; set; }
        public virtual DbSet<LookupSourceBonEntree> LookupSourceBonEntree { get; set; }
        public virtual DbSet<LookupTypeArticle> LookupTypeArticle { get; set; }
        public virtual DbSet<LookupTypeBonSorie> LookupTypeBonSorie { get; set; }
        public virtual DbSet<LookupTypeContrats> LookupTypeContrats { get; set; }
        public virtual DbSet<LookupTypeTraveauxOt> LookupTypeTraveauxOt { get; set; }
        public virtual DbSet<LookupUniteRecrutement> LookupUniteRecrutement { get; set; }
        public virtual DbSet<MachineEquioement> MachineEquioement { get; set; }
        public virtual DbSet<MachineSysteme> MachineSysteme { get; set; }
        public virtual DbSet<Machines> Machines { get; set; }
        public virtual DbSet<MaintPointControlMaster> MaintPointControlMaster { get; set; }
        public virtual DbSet<MaintPointControleDetail> MaintPointControleDetail { get; set; }
        public virtual DbSet<MethAppointementsPreventifs> MethAppointementsPreventifs { get; set; }
        public virtual DbSet<MethOperations> MethOperations { get; set; }
        public virtual DbSet<MethOperationsMateriels> MethOperationsMateriels { get; set; }
        public virtual DbSet<MethOperationsUniteFrequence> MethOperationsUniteFrequence { get; set; }
        public virtual DbSet<MethPlanningEtSuiviMateriel> MethPlanningEtSuiviMateriel { get; set; }
        public virtual DbSet<MethPlanningPreventif> MethPlanningPreventif { get; set; }
        public virtual DbSet<MethStructureMachine> MethStructureMachine { get; set; }
        public virtual DbSet<OrdreProduction> OrdreProduction { get; set; }
        public virtual DbSet<OrdreTravail> OrdreTravail { get; set; }
        public virtual DbSet<PeriodeProduction> PeriodeProduction { get; set; }
        public virtual DbSet<PrjDependecies> PrjDependecies { get; set; }
        public virtual DbSet<PrjRessourceAssignements> PrjRessourceAssignements { get; set; }
        public virtual DbSet<PrjRessources> PrjRessources { get; set; }
        public virtual DbSet<PrjTasks> PrjTasks { get; set; }
        public virtual DbSet<ProdArretsProgramme> ProdArretsProgramme { get; set; }
        public virtual DbSet<ProdArretsProgrammeArrets> ProdArretsProgrammeArrets { get; set; }
        public virtual DbSet<ProdArretsPsSonalgaz> ProdArretsPsSonalgaz { get; set; }
        public virtual DbSet<ProdCylindreAnomalies> ProdCylindreAnomalies { get; set; }
        public virtual DbSet<ProdPersonnelsArretsProgrammes> ProdPersonnelsArretsProgrammes { get; set; }
        public virtual DbSet<ProdPreProccessingCylindresUsinage> ProdPreProccessingCylindresUsinage { get; set; }
        public virtual DbSet<ProdPreparationCalibre> ProdPreparationCalibre { get; set; }
        public virtual DbSet<ProdPreparationCylindre> ProdPreparationCylindre { get; set; }
        public virtual DbSet<ProdSuiviArretsServices> ProdSuiviArretsServices { get; set; }
        public virtual DbSet<ProdSuiviArretsSonalgazTrainCages> ProdSuiviArretsSonalgazTrainCages { get; set; }
        public virtual DbSet<ProdTachesArretsProgrammes> ProdTachesArretsProgrammes { get; set; }
        public virtual DbSet<ProdTonnagesCages> ProdTonnagesCages { get; set; }
        public virtual DbSet<ProdTotaux> ProdTotaux { get; set; }
        public virtual DbSet<Produits> Produits { get; set; }
        public virtual DbSet<QualiteBonCession> QualiteBonCession { get; set; }
        public virtual DbSet<QualiteBonCessionDetails> QualiteBonCessionDetails { get; set; }
        public virtual DbSet<QualiteControlGeometrique> QualiteControlGeometrique { get; set; }
        public virtual DbSet<QualiteControlGeometriqueDetails> QualiteControlGeometriqueDetails { get; set; }
        public virtual DbSet<QualiteEssaisMecanique> QualiteEssaisMecanique { get; set; }
        public virtual DbSet<QualiteEssaisMecaniqueDetails> QualiteEssaisMecaniqueDetails { get; set; }
        public virtual DbSet<QualiteProduitsFini> QualiteProduitsFini { get; set; }
        public virtual DbSet<QualiteRapports> QualiteRapports { get; set; }
        public virtual DbSet<QualiteRapportsDetails> QualiteRapportsDetails { get; set; }
        public virtual DbSet<RapportIntervention> RapportIntervention { get; set; }
        public virtual DbSet<RhContratsEmployes> RhContratsEmployes { get; set; }
        public virtual DbSet<RhListeDesEmployes> RhListeDesEmployes { get; set; }
        public virtual DbSet<SmartAssistItem> SmartAssistItem { get; set; }
        public virtual DbSet<Specialite> Specialite { get; set; }
        public virtual DbSet<SrkBonRetour> SrkBonRetour { get; set; }
        public virtual DbSet<Statut> Statut { get; set; }
        public virtual DbSet<StkAffectations> StkAffectations { get; set; }
        public virtual DbSet<StkAffectationsArticles> StkAffectationsArticles { get; set; }
        public virtual DbSet<StkArticlesZero> StkArticlesZero { get; set; }
        public virtual DbSet<StkBonEntree> StkBonEntree { get; set; }
        public virtual DbSet<StkBonEntreeArticles> StkBonEntreeArticles { get; set; }
        public virtual DbSet<StkBonRetourArticles> StkBonRetourArticles { get; set; }
        public virtual DbSet<StkBonRetourTransfert> StkBonRetourTransfert { get; set; }
        public virtual DbSet<StkBonRetourTransfertArticles> StkBonRetourTransfertArticles { get; set; }
        public virtual DbSet<StkBonSortie> StkBonSortie { get; set; }
        public virtual DbSet<StkBonSortieArticles> StkBonSortieArticles { get; set; }
        public virtual DbSet<StkBonTransfert> StkBonTransfert { get; set; }
        public virtual DbSet<StkBonTransfertArticles> StkBonTransfertArticles { get; set; }
        public virtual DbSet<StkCentreFrais> StkCentreFrais { get; set; }
        public virtual DbSet<StkDecharge> StkDecharge { get; set; }
        public virtual DbSet<StkDechargeArticles> StkDechargeArticles { get; set; }
        public virtual DbSet<StkEmplacement> StkEmplacement { get; set; }
        public virtual DbSet<StkEntreeFraisApproches> StkEntreeFraisApproches { get; set; }
        public virtual DbSet<StkEquipements> StkEquipements { get; set; }
        public virtual DbSet<StkFamillePdr> StkFamillePdr { get; set; }
        public virtual DbSet<StkFicheArticle> StkFicheArticle { get; set; }
        public virtual DbSet<StkFraisApproches> StkFraisApproches { get; set; }
        public virtual DbSet<StkGismentPdr> StkGismentPdr { get; set; }
        public virtual DbSet<StkGroupePdr> StkGroupePdr { get; set; }
        public virtual DbSet<StkInventaires> StkInventaires { get; set; }
        public virtual DbSet<StkInventairesArticles> StkInventairesArticles { get; set; }
        public virtual DbSet<StkInventairesEquipeMembres> StkInventairesEquipeMembres { get; set; }
        public virtual DbSet<StkInventairesEquipes> StkInventairesEquipes { get; set; }
        public virtual DbSet<StkInventairesLieux> StkInventairesLieux { get; set; }
        public virtual DbSet<StkLieu> StkLieu { get; set; }
        public virtual DbSet<StkMovements> StkMovements { get; set; }
        public virtual DbSet<StkPdr> StkPdr { get; set; }
        public virtual DbSet<StkPdrStockContrainte> StkPdrStockContrainte { get; set; }
        public virtual DbSet<StkPdrStockSurveillenceService> StkPdrStockSurveillenceService { get; set; }
        public virtual DbSet<StkRapportTransfertBillette> StkRapportTransfertBillette { get; set; }
        public virtual DbSet<StkRapportTransfertBillettesDetails> StkRapportTransfertBillettesDetails { get; set; }
        public virtual DbSet<StkReceptionBillette> StkReceptionBillette { get; set; }
        public virtual DbSet<StkReceptionBilletteDetails> StkReceptionBilletteDetails { get; set; }
        public virtual DbSet<StkReintegration> StkReintegration { get; set; }
        public virtual DbSet<StkReintegrationArticles> StkReintegrationArticles { get; set; }
        public virtual DbSet<StkRestitution> StkRestitution { get; set; }
        public virtual DbSet<StkRestitutionArticles> StkRestitutionArticles { get; set; }
        public virtual DbSet<StkSousFamillePdr> StkSousFamillePdr { get; set; }
        public virtual DbSet<StkStockInitial> StkStockInitial { get; set; }
        public virtual DbSet<StkTypeAchat> StkTypeAchat { get; set; }
        public virtual DbSet<StkTypeMovement> StkTypeMovement { get; set; }
        public virtual DbSet<StkTypeValorisation> StkTypeValorisation { get; set; }
        public virtual DbSet<StkUniteMesurePdr> StkUniteMesurePdr { get; set; }
        public virtual DbSet<Structure> Structure { get; set; }
        public virtual DbSet<SubMachineArret> SubMachineArret { get; set; }
        public virtual DbSet<SuiviEntretienPersonnels> SuiviEntretienPersonnels { get; set; }
        public virtual DbSet<TempApproArticlesDemandes> TempApproArticlesDemandes { get; set; }
        public virtual DbSet<TempApproDemandeServiceDetail> TempApproDemandeServiceDetail { get; set; }
        public virtual DbSet<TempAssOtConsommable> TempAssOtConsommable { get; set; }
        public virtual DbSet<TempAssOtIntervenants> TempAssOtIntervenants { get; set; }
        public virtual DbSet<TempAssOtPdr> TempAssOtPdr { get; set; }
        public virtual DbSet<TempAssOtTravaux> TempAssOtTravaux { get; set; }
        public virtual DbSet<TempMaintPointControleDetail> TempMaintPointControleDetail { get; set; }
        public virtual DbSet<TempPlanningMensuellePreventif> TempPlanningMensuellePreventif { get; set; }
        public virtual DbSet<TempStkPdrStockContrainte> TempStkPdrStockContrainte { get; set; }
        public virtual DbSet<TempStructureMachine> TempStructureMachine { get; set; }
        public virtual DbSet<TrackingOperations> TrackingOperations { get; set; }
        public virtual DbSet<TypeMaintenance> TypeMaintenance { get; set; }
        public virtual DbSet<UrgenceTravaille> UrgenceTravaille { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=KBFsteel;Trusted_Connection=True;MultipleActiveResultSets=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApproArticlesDemandes>(entity =>
            {
                entity.ToTable("APPRO_ArticlesDemandes");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.ArticleNonGere).HasMaxLength(50);

                entity.Property(e => e.DateLivraison).HasColumnType("date");

                entity.Property(e => e.Qte).HasColumnName("QTE");

                entity.HasOne(d => d.NumeroDemandeNavigation)
                    .WithMany(p => p.ApproArticlesDemandes)
                    .HasForeignKey(d => d.NumeroDemande)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_APPRO_ArticlesDemandes_APPRO_DemandeAchats");
            });

            modelBuilder.Entity<ApproArticlesEntres>(entity =>
            {
                entity.ToTable("APPRO_ArticlesEntres");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.DesignationArticle)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Qte).HasColumnName("QTE");

                entity.HasOne(d => d.NumBonNavigation)
                    .WithMany(p => p.ApproArticlesEntres)
                    .HasForeignKey(d => d.NumBon)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_APPRO_ArticlesEntres_APPRO_BonsEntrees");
            });

            modelBuilder.Entity<ApproBonLivraison>(entity =>
            {
                entity.HasKey(e => e.NumeroBonLivraison);

                entity.ToTable("Appro_Bon_Livraison");

                entity.Property(e => e.NumeroBonLivraison).ValueGeneratedNever();

                entity.Property(e => e.DateLivraison).HasColumnType("datetime");
            });

            modelBuilder.Entity<ApproBonsEntrees>(entity =>
            {
                entity.HasKey(e => e.NumBon);

                entity.ToTable("APPRO_BonsEntrees");

                entity.Property(e => e.NumBon).ValueGeneratedNever();

                entity.Property(e => e.DateEntree).HasColumnType("date");
            });

            modelBuilder.Entity<ApproDemandeAchats>(entity =>
            {
                entity.HasKey(e => e.NumDemandeAchat);

                entity.ToTable("APPRO_DemandeAchats");

                entity.Property(e => e.NumDemandeAchat).ValueGeneratedNever();

                entity.Property(e => e.DateDemandeAchat).HasColumnType("date");

                entity.Property(e => e.MotifDemandeAchat).HasMaxLength(50);

                entity.Property(e => e.StatutDemandeAchat)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.CodeServiceDemandeurNavigation)
                    .WithMany(p => p.ApproDemandeAchats)
                    .HasForeignKey(d => d.CodeServiceDemandeur)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_APPRO_DemandeAchats_APPRO_ServicesDemandeurs");

                entity.HasOne(d => d.StatutDemandeAchatNavigation)
                    .WithMany(p => p.ApproDemandeAchats)
                    .HasForeignKey(d => d.StatutDemandeAchat)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_APPRO_DemandeAchats_APPRO_Statut");
            });

            modelBuilder.Entity<ApproDemandeService>(entity =>
            {
                entity.HasKey(e => e.NumeroDemandeService);

                entity.ToTable("APPRO_DemandeService");

                entity.Property(e => e.NumeroDemandeService).ValueGeneratedNever();

                entity.Property(e => e.DateDemande).HasColumnType("date");

                entity.Property(e => e.Observation).HasMaxLength(100);
            });

            modelBuilder.Entity<ApproDemandeServiceDetail>(entity =>
            {
                entity.ToTable("APPRO_DemandeServiceDetail");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.ServiceDemande)
                    .IsRequired()
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<ApproDemandesFourniture>(entity =>
            {
                entity.HasKey(e => e.NumeroDemande)
                    .HasName("PK_APPRO_DemandesFourniture_1");

                entity.ToTable("APPRO_DemandesFourniture");

                entity.Property(e => e.NumeroDemande).ValueGeneratedNever();

                entity.Property(e => e.DateBesoin).HasColumnType("datetime");

                entity.Property(e => e.DateDemande).HasColumnType("datetime");

                entity.Property(e => e.Obeservations)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ApproFabricants>(entity =>
            {
                entity.HasKey(e => e.NumeroFabricant);

                entity.ToTable("APPRO_Fabricants");

                entity.Property(e => e.NumeroFabricant).HasMaxLength(50);

                entity.Property(e => e.Adresse).HasMaxLength(50);

                entity.Property(e => e.CodePostal).HasMaxLength(50);

                entity.Property(e => e.Fax).HasMaxLength(50);

                entity.Property(e => e.Fonction)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Gmail).HasMaxLength(50);

                entity.Property(e => e.Pays).HasMaxLength(50);

                entity.Property(e => e.SocieteFabricant)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Ville).HasMaxLength(50);
            });

            modelBuilder.Entity<ApproFournisseurs>(entity =>
            {
                entity.HasKey(e => e.NumeroFournisseur);

                entity.ToTable("APPRO_Fournisseurs");

                entity.Property(e => e.NumeroFournisseur).HasMaxLength(100);

                entity.Property(e => e.Adresse).HasMaxLength(100);

                entity.Property(e => e.Art).HasColumnName("ART");

                entity.Property(e => e.CodePostal).HasMaxLength(50);

                entity.Property(e => e.Contact).HasMaxLength(100);

                entity.Property(e => e.Fax).HasMaxLength(50);

                entity.Property(e => e.Fonction).HasMaxLength(100);

                entity.Property(e => e.Gmail).HasMaxLength(100);

                entity.Property(e => e.Mf).HasColumnName("MF");

                entity.Property(e => e.Nrc).HasColumnName("NRC");

                entity.Property(e => e.Pays).HasMaxLength(50);

                entity.Property(e => e.SocieteFournisseur)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Ville).HasMaxLength(50);
            });

            modelBuilder.Entity<ApproFournituresArticles>(entity =>
            {
                entity.ToTable("APPRO_FournituresArticles");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.DesignationArticle)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<ApproFournituresArticlesNongere>(entity =>
            {
                entity.ToTable("APPRO_FournituresArticles_Nongere");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.DesignationArticle)
                    .IsRequired()
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<ApproNatureDemandeFourniture>(entity =>
            {
                entity.HasKey(e => e.CodeNatureDemande);

                entity.ToTable("APPRO_NatureDemandeFourniture");

                entity.Property(e => e.CodeNatureDemande).ValueGeneratedNever();

                entity.Property(e => e.DesignationNatureDemande)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<ApproServicesDemandeurs>(entity =>
            {
                entity.HasKey(e => e.CodeService);

                entity.ToTable("APPRO_ServicesDemandeurs");

                entity.Property(e => e.CodeService).ValueGeneratedNever();

                entity.Property(e => e.DesignationService)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<ApproStatut>(entity =>
            {
                entity.HasKey(e => e.DesignationStatut);

                entity.ToTable("APPRO_Statut");

                entity.Property(e => e.DesignationStatut).HasMaxLength(50);
            });

            modelBuilder.Entity<ArretProductionJournee>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Cause).HasColumnType("text");

                entity.Property(e => e.CodeMachine).HasMaxLength(50);

                entity.Property(e => e.DateArret).HasColumnType("date");

                entity.Property(e => e.EnumArret)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.HeureDebut).HasColumnType("datetime");

                entity.Property(e => e.HeureFin).HasColumnType("datetime");

                entity.Property(e => e.SubMachine).HasMaxLength(50);
            });

            modelBuilder.Entity<ArreteProduction>(entity =>
            {
                entity.HasKey(e => e.CodeArret);

                entity.Property(e => e.DesignationArret)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<AssOtConsommable>(entity =>
            {
                entity.ToTable("ASS_Ot_Consommable");

                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<AssOtIntervenants>(entity =>
            {
                entity.ToTable("ASS_OT_Intervenants");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.CodeEquipement).HasMaxLength(200);

                entity.Property(e => e.DateIntervention).HasColumnType("datetime");
            });

            modelBuilder.Entity<AssOtOutils>(entity =>
            {
                entity.ToTable("ASS_OT_Outils");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();
            });

            modelBuilder.Entity<AssOtPdr>(entity =>
            {
                entity.ToTable("Ass_Ot_Pdr");

                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<AssOtTraveaux>(entity =>
            {
                entity.ToTable("ASS_OT_Traveaux");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Autres).HasMaxLength(200);

                entity.Property(e => e.CodeEquipement).HasMaxLength(200);

                entity.Property(e => e.Qte).HasColumnName("QTE");
            });

            modelBuilder.Entity<AssStkPdrGisement>(entity =>
            {
                entity.ToTable("ASS_STK_PDR_Gisement");

                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<AssStructureDerigants>(entity =>
            {
                entity.ToTable("ASS_Structure_Derigants");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CodeDerigant)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<AteliersTable>(entity =>
            {
                entity.HasKey(e => e.CodeAtelier);

                entity.Property(e => e.CodeAtelier).ValueGeneratedNever();

                entity.Property(e => e.DesignationAtelier)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<BonProduction>(entity =>
            {
                entity.HasKey(e => e.NumBon);

                entity.Property(e => e.NumBon).ValueGeneratedNever();

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.Nb)
                    .HasColumnName("NB")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Qte)
                    .HasColumnName("QTE")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UniteMesure)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.CodeReceveurNavigation)
                    .WithMany(p => p.BonProduction)
                    .HasForeignKey(d => d.CodeReceveur)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BonProduction_Intervenant");

                entity.HasOne(d => d.CodeReceveur1)
                    .WithMany(p => p.BonProduction)
                    .HasForeignKey(d => d.CodeReceveur)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BonProduction_Produits");
            });

            modelBuilder.Entity<CadenceProductionJournee>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.NumRapportNavigation)
                    .WithMany(p => p.CadenceProductionJournee)
                    .HasForeignKey(d => d.NumRapport)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CadenceProductionJournee_JourneeProduction");
            });

            modelBuilder.Entity<Compositions>(entity =>
            {
                entity.HasKey(e => e.NumComposition);

                entity.Property(e => e.NumComposition).HasMaxLength(50);

                entity.Property(e => e.NomComposition).HasMaxLength(50);
            });

            modelBuilder.Entity<ComptComptesComptable>(entity =>
            {
                entity.HasKey(e => e.NumCompte);

                entity.ToTable("COMPT_ComptesComptable");

                entity.Property(e => e.NumCompte).ValueGeneratedNever();

                entity.Property(e => e.DesignationCompte)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<ConfigElectrique>(entity =>
            {
                entity.ToTable("CONFIG_Electrique");

                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<ConfigExploitation>(entity =>
            {
                entity.ToTable("CONFIG_Exploitation");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();
            });

            modelBuilder.Entity<ConfigMecanique>(entity =>
            {
                entity.ToTable("CONFIG_Mecanique");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();
            });

            modelBuilder.Entity<ConfigMethode>(entity =>
            {
                entity.ToTable("CONFIG_Methode");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();
            });

            modelBuilder.Entity<ConfigRhManager>(entity =>
            {
                entity.ToTable("CONFIG_RhManager");

                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<ConfigSodure>(entity =>
            {
                entity.ToTable("CONFIG_Sodure");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();
            });

            modelBuilder.Entity<ConfigUsinage>(entity =>
            {
                entity.ToTable("CONFIG_Usinage");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();
            });

            modelBuilder.Entity<Consignation>(entity =>
            {
                entity.HasKey(e => e.NumConsignation)
                    .HasName("PK_Consignation_1");
            });

            modelBuilder.Entity<ConsignationDetails>(entity =>
            {
                entity.Property(e => e.AutresOperation)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.DateChangementChargeTravaux).HasColumnType("datetime");

                entity.Property(e => e.DateChargeConsignation).HasColumnType("datetime");

                entity.Property(e => e.DateChargeTravaux).HasColumnType("datetime");

                entity.Property(e => e.MesureSecurite)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<DebugMaitenanceType>(entity =>
            {
                entity.HasKey(e => e.IdMaint);

                entity.ToTable("Debug_MaitenanceType");

                entity.Property(e => e.IdMaint).ValueGeneratedNever();

                entity.Property(e => e.DesignationMaint).HasMaxLength(50);
            });

            modelBuilder.Entity<Deconsignation>(entity =>
            {
                entity.Property(e => e.DateBonDeconsgination).HasColumnType("datetime");

                entity.Property(e => e.DateDemandeDeconsignation).HasColumnType("datetime");
            });

            modelBuilder.Entity<DemandeTravail>(entity =>
            {
                entity.HasKey(e => e.NumDt);

                entity.Property(e => e.NumDt)
                    .HasColumnName("NumDT")
                    .ValueGeneratedNever();

                entity.Property(e => e.DateDt)
                    .HasColumnName("DateDT")
                    .HasColumnType("datetime");

                entity.Property(e => e.MachineOptionel).HasMaxLength(100);

                entity.Property(e => e.Note).HasMaxLength(200);

                entity.Property(e => e.RefMachine).HasMaxLength(50);

                entity.Property(e => e.TravailDemandee)
                    .IsRequired()
                    .HasMaxLength(2500)
                    .IsUnicode(false);

                entity.HasOne(d => d.CodeArretNavigation)
                    .WithMany(p => p.DemandeTravail)
                    .HasForeignKey(d => d.CodeArret)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DemandeTravail_ArreteProduction");

                entity.HasOne(d => d.CodeStatutNavigation)
                    .WithMany(p => p.DemandeTravail)
                    .HasForeignKey(d => d.CodeStatut)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DemandeTravail_Statut");

                entity.HasOne(d => d.CodeStructureNavigation)
                    .WithMany(p => p.DemandeTravail)
                    .HasForeignKey(d => d.CodeStructure)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DemandeTravail_Structure");

                entity.HasOne(d => d.CodeUrgenceNavigation)
                    .WithMany(p => p.DemandeTravail)
                    .HasForeignKey(d => d.CodeUrgence)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DemandeTravail_UrgenceTravaille");
            });

            modelBuilder.Entity<EnumArret>(entity =>
            {
                entity.HasKey(e => e.Designation);

                entity.Property(e => e.Designation)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Structure)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Equipements>(entity =>
            {
                entity.HasKey(e => e.NumEquipement);

                entity.Property(e => e.NumEquipement).ValueGeneratedNever();

                entity.Property(e => e.Designation).HasMaxLength(50);

                entity.Property(e => e.Nom)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.NumMachineNavigation)
                    .WithMany(p => p.Equipements)
                    .HasForeignKey(d => d.NumMachine)
                    .HasConstraintName("FK_Equipements_Machines");
            });

            modelBuilder.Entity<GrhAgencesBancaire>(entity =>
            {
                entity.ToTable("GRH_AgencesBancaire");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Localisation).HasMaxLength(50);

                entity.Property(e => e.NomAgence)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<GrhFormations>(entity =>
            {
                entity.ToTable("GRH_Formations");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CapitalHumain).HasDefaultValueSql("((0))");

                entity.Property(e => e.DateDebut).HasColumnType("date");

                entity.Property(e => e.DateFin).HasColumnType("date");

                entity.Property(e => e.Description).HasColumnType("text");

                entity.Property(e => e.Intitule)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<GrhFormationsPersonnels>(entity =>
            {
                entity.ToTable("GRH_Formations_Personnels");
            });

            modelBuilder.Entity<GrhLookupNatureAgenceBnacaire>(entity =>
            {
                entity.ToTable("GRH_lookupNatureAgenceBnacaire");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Designation)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<GrhNumericVisas>(entity =>
            {
                entity.HasKey(e => e.IdVisa);

                entity.ToTable("GRH_NumericVisas");

                entity.Property(e => e.Responsable)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.VisaPath)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<GrhPostes>(entity =>
            {
                entity.HasKey(e => e.CodePoste);

                entity.ToTable("GRH_Postes");

                entity.Property(e => e.Intitule)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.IntituleArabe)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<GroupeMachines>(entity =>
            {
                entity.HasKey(e => e.NumGroupe)
                    .HasName("PK_GroupeEquipement");

                entity.Property(e => e.NumGroupe).HasMaxLength(50);

                entity.Property(e => e.DesignationGroupe).HasMaxLength(50);

                entity.Property(e => e.NomGroupe)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Intervenant>(entity =>
            {
                entity.HasKey(e => e.CodeIntervenant);

                entity.Property(e => e.CodeIntervenant).ValueGeneratedNever();

                entity.Property(e => e.DesignationEquipe).HasMaxLength(50);

                entity.Property(e => e.NmPr)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.CodeSpecialiteNavigation)
                    .WithMany(p => p.Intervenant)
                    .HasForeignKey(d => d.CodeSpecialite)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Intervenant_Specialite");
            });

            modelBuilder.Entity<JourneeProduction>(entity =>
            {
                entity.HasKey(e => e.NumRapport);

                entity.Property(e => e.NumRapport).ValueGeneratedNever();

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.DimBillete)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DimProduitConforme)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DimProduitFini)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LongBillete)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Note).HasMaxLength(1000);

                entity.Property(e => e.OperateurPcp).HasColumnName("OperateurPCp");

                entity.Property(e => e.ParCm)
                    .HasColumnName("ParCM")
                    .HasMaxLength(50);

                entity.Property(e => e.ParDcl).HasColumnName("ParDCL");

                entity.Property(e => e.ParGrpFin10Dcl).HasColumnName("ParGrpFin10DCL");

                entity.Property(e => e.ParGrpFin10Mvr).HasColumnName("ParGrpFin10MVR");

                entity.Property(e => e.ParGrpFin10Vl).HasColumnName("ParGrpFin10VL");

                entity.Property(e => e.ParGrpFin11Dcl).HasColumnName("ParGrpFin11DCL");

                entity.Property(e => e.ParGrpFin11Mvr).HasColumnName("ParGrpFin11MVR");

                entity.Property(e => e.ParGrpFin11Vl).HasColumnName("ParGrpFin11VL");

                entity.Property(e => e.ParGrpFin12Dcl).HasColumnName("ParGrpFin12DCL");

                entity.Property(e => e.ParGrpFin12Mvr).HasColumnName("ParGrpFin12MVR");

                entity.Property(e => e.ParGrpFin12Vl).HasColumnName("ParGrpFin12VL");

                entity.Property(e => e.ParGrpFin13Dcl).HasColumnName("ParGrpFin13DCL");

                entity.Property(e => e.ParGrpFin13Mvr).HasColumnName("ParGrpFin13MVR");

                entity.Property(e => e.ParGrpFin13Vl).HasColumnName("ParGrpFin13VL");

                entity.Property(e => e.ParGrpFin67Dcl).HasColumnName("ParGrpFin67DCL");

                entity.Property(e => e.ParGrpFin67Mvr).HasColumnName("ParGrpFin67MVR");

                entity.Property(e => e.ParGrpFin67Vl).HasColumnName("ParGrpFin67VL");

                entity.Property(e => e.ParGrpFin8Dcl).HasColumnName("ParGrpFin8DCL");

                entity.Property(e => e.ParGrpFin8Mvr).HasColumnName("ParGrpFin8MVR");

                entity.Property(e => e.ParGrpFin8Vl).HasColumnName("ParGrpFin8VL");

                entity.Property(e => e.ParGrpFin9Dcl).HasColumnName("ParGrpFin9DCL");

                entity.Property(e => e.ParGrpFin9Mvr).HasColumnName("ParGrpFin9MVR");

                entity.Property(e => e.ParGrpFin9Vl).HasColumnName("ParGrpFin9VL");

                entity.Property(e => e.ParGrpInter2Dcl).HasColumnName("ParGrpInter2DCL");

                entity.Property(e => e.ParGrpInter2Mvr).HasColumnName("ParGrpInter2MVR");

                entity.Property(e => e.ParGrpInter2Vl).HasColumnName("ParGrpInter2VL");

                entity.Property(e => e.ParGrpInter3Dcl).HasColumnName("ParGrpInter3DCL");

                entity.Property(e => e.ParGrpInter3Mvr).HasColumnName("ParGrpInter3MVR");

                entity.Property(e => e.ParGrpInter3Vl).HasColumnName("ParGrpInter3VL");

                entity.Property(e => e.ParGrpInter4Dcl).HasColumnName("ParGrpInter4DCL");

                entity.Property(e => e.ParGrpInter4Mvr).HasColumnName("ParGrpInter4MVR");

                entity.Property(e => e.ParGrpInter4Vl).HasColumnName("ParGrpInter4VL");

                entity.Property(e => e.ParGrpInter5Dcl).HasColumnName("ParGrpInter5DCL");

                entity.Property(e => e.ParGrpInter5Mvr).HasColumnName("ParGrpInter5MVR");

                entity.Property(e => e.ParGrpInter5Vl).HasColumnName("ParGrpInter5VL");

                entity.Property(e => e.ParLbf).HasColumnName("ParLBF");

                entity.Property(e => e.ParLbn).HasColumnName("ParLBN");

                entity.Property(e => e.ParLpb).HasColumnName("ParLPB");

                entity.Property(e => e.ParLq).HasColumnName("ParLQ");

                entity.Property(e => e.ParLt).HasColumnName("ParLT");

                entity.Property(e => e.ParP1a).HasColumnName("ParP1A");

                entity.Property(e => e.ParP2a).HasColumnName("ParP2A");

                entity.Property(e => e.ParP3a).HasColumnName("ParP3A");

                entity.Property(e => e.ParP4a).HasColumnName("ParP4A");

                entity.Property(e => e.ParP5a).HasColumnName("ParP5A");

                entity.Property(e => e.ParRmp2).HasColumnName("ParRMP2");

                entity.Property(e => e.ParRmp3).HasColumnName("ParRMP3");

                entity.Property(e => e.ParRpm1).HasColumnName("ParRPM1");

                entity.Property(e => e.ParVmce5).HasColumnName("ParVMCE5");

                entity.Property(e => e.ParVmcv).HasColumnName("ParVMCV");
            });

            modelBuilder.Entity<LookupCivilite>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Lookup_Civilite");

                entity.Property(e => e.DesignationCivilite)
                    .IsRequired()
                    .HasColumnType("text");
            });

            modelBuilder.Entity<LookupCloture>(entity =>
            {
                entity.HasKey(e => e.CodeCloture);

                entity.ToTable("Lookup_Cloture");

                entity.Property(e => e.CodeCloture).ValueGeneratedNever();

                entity.Property(e => e.DesignationCloture)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<LookupDestinationDf>(entity =>
            {
                entity.ToTable("Lookup_DestinationDf");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Destination)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<LookupDevise>(entity =>
            {
                entity.HasKey(e => e.CodeDevise);

                entity.ToTable("Lookup_Devise");

                entity.Property(e => e.CodeDevise).ValueGeneratedNever();

                entity.Property(e => e.DesignationDevise).HasMaxLength(50);
            });

            modelBuilder.Entity<LookupEquipeInventaire>(entity =>
            {
                entity.ToTable("Lookup_EquipeInventaire");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.DesignationEquipe)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<LookupEquipes>(entity =>
            {
                entity.HasKey(e => e.CodeEquipe);

                entity.ToTable("Lookup_Equipes");

                entity.Property(e => e.CodeEquipe).ValueGeneratedNever();

                entity.Property(e => e.DesignationEquipe)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<LookupEtatContrat>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Lookup_EtatContrat");

                entity.Property(e => e.DesignationEtatContrat)
                    .IsRequired()
                    .HasColumnType("text");
            });

            modelBuilder.Entity<LookupPays>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Lookup_Pays");

                entity.Property(e => e.DesignationPays)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.ReferencePays)
                    .IsRequired()
                    .HasColumnType("text");
            });

            modelBuilder.Entity<LookupSexe>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Lookup_Sexe");

                entity.Property(e => e.DesignationSexe)
                    .IsRequired()
                    .HasColumnType("text");
            });

            modelBuilder.Entity<LookupSourceBonEntree>(entity =>
            {
                entity.HasKey(e => e.CodeSource);

                entity.ToTable("Lookup_SourceBonEntree");

                entity.Property(e => e.CodeSource).ValueGeneratedNever();

                entity.Property(e => e.DesignationSource).HasMaxLength(100);
            });

            modelBuilder.Entity<LookupTypeArticle>(entity =>
            {
                entity.HasKey(e => e.CodeTypeArtile);

                entity.ToTable("Lookup_TypeArticle");

                entity.Property(e => e.CodeTypeArtile).ValueGeneratedNever();

                entity.Property(e => e.DesignationTypeArticle)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<LookupTypeBonSorie>(entity =>
            {
                entity.HasKey(e => e.CodeTypeSortie);

                entity.ToTable("Lookup_TypeBonSorie");

                entity.Property(e => e.CodeTypeSortie).ValueGeneratedNever();

                entity.Property(e => e.DesignationTypeSortie)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<LookupTypeContrats>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Lookup_TypeContrats");

                entity.Property(e => e.DesignationTypeContrat)
                    .IsRequired()
                    .HasColumnType("text");
            });

            modelBuilder.Entity<LookupTypeTraveauxOt>(entity =>
            {
                entity.ToTable("Lookup_TypeTraveaux_OT");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Designation)
                    .IsRequired()
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<LookupUniteRecrutement>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Lookup_UniteRecrutement");

                entity.Property(e => e.DesignatioUniteRecrutement)
                    .IsRequired()
                    .HasColumnType("text");
            });

            modelBuilder.Entity<MachineEquioement>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.NumComposition).HasMaxLength(50);

                entity.Property(e => e.Qte).HasColumnName("QTE");

                entity.HasOne(d => d.NumCompositionNavigation)
                    .WithMany(p => p.MachineEquioement)
                    .HasForeignKey(d => d.NumComposition)
                    .HasConstraintName("FK_MachineEquioement_Compositions");

                entity.HasOne(d => d.NumEquipementNavigation)
                    .WithMany(p => p.MachineEquioement)
                    .HasForeignKey(d => d.NumEquipement)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MachineEquioement_Equipements");

                entity.HasOne(d => d.NumMachineNavigation)
                    .WithMany(p => p.MachineEquioement)
                    .HasForeignKey(d => d.NumMachine)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MachineEquioement_Machines");
            });

            modelBuilder.Entity<MachineSysteme>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasMaxLength(50);

                entity.Property(e => e.DesignationEquipement).HasMaxLength(50);

                entity.Property(e => e.NomEquipement).HasMaxLength(50);

                entity.Property(e => e.Qte).HasColumnName("QTE");

                entity.HasOne(d => d.NumEquipementNavigation)
                    .WithMany(p => p.MachineSysteme)
                    .HasForeignKey(d => d.NumEquipement)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MachineSysteme_Equipements");

                entity.HasOne(d => d.NumMachineNavigation)
                    .WithMany(p => p.MachineSysteme)
                    .HasForeignKey(d => d.NumMachine)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MachineSysteme_Machines");
            });

            modelBuilder.Entity<Machines>(entity =>
            {
                entity.HasKey(e => e.NumMachine);

                entity.Property(e => e.NumMachine).ValueGeneratedNever();

                entity.Property(e => e.NomMachine)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.NumGroupe).HasMaxLength(50);

                entity.HasOne(d => d.NumEquipementNavigation)
                    .WithMany(p => p.Machines)
                    .HasForeignKey(d => d.NumEquipement)
                    .HasConstraintName("FK_Machines_Equipements");

                entity.HasOne(d => d.NumGroupeNavigation)
                    .WithMany(p => p.Machines)
                    .HasForeignKey(d => d.NumGroupe)
                    .HasConstraintName("FK_Machines_GroupeMachines");
            });

            modelBuilder.Entity<MaintPointControlMaster>(entity =>
            {
                entity.HasKey(e => e.NumCheckList);

                entity.ToTable("MAINT_PointControlMaster");

                entity.Property(e => e.NumCheckList).ValueGeneratedNever();

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.DateDebut).HasColumnType("datetime");

                entity.Property(e => e.DateFin).HasColumnType("datetime");
            });

            modelBuilder.Entity<MaintPointControleDetail>(entity =>
            {
                entity.ToTable("Maint_PointControleDetail");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Observation).HasMaxLength(200);
            });

            modelBuilder.Entity<MethAppointementsPreventifs>(entity =>
            {
                entity.HasKey(e => e.AppointmentId);

                entity.ToTable("METH_AppointementsPreventifs");

                entity.Property(e => e.AppointmentId).ValueGeneratedNever();

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.RecurrenceException)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.RecurrenceRule)
                    .HasColumnName("recurrenceRule")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.Text)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MethOperations>(entity =>
            {
                entity.HasKey(e => e.Idoperation);

                entity.ToTable("METH_Operations");

                entity.Property(e => e.Idoperation)
                    .HasColumnName("IDOperation")
                    .ValueGeneratedNever();

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Guide).HasColumnType("text");
            });

            modelBuilder.Entity<MethOperationsMateriels>(entity =>
            {
                entity.ToTable("METH_Operations_materiels");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();
            });

            modelBuilder.Entity<MethOperationsUniteFrequence>(entity =>
            {
                entity.HasKey(e => e.CodeFrequenceUnite);

                entity.ToTable("METH_Operations_UniteFrequence");

                entity.Property(e => e.CodeFrequenceUnite).ValueGeneratedNever();

                entity.Property(e => e.DesignationFrequenceUnite)
                    .IsRequired()
                    .HasMaxLength(10);
            });

            modelBuilder.Entity<MethPlanningEtSuiviMateriel>(entity =>
            {
                entity.ToTable("Meth_PlanningEtSuiviMateriel");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Activité)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.ElementMachine)
                    .IsRequired()
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<MethPlanningPreventif>(entity =>
            {
                entity.ToTable("Meth_Planning_Preventif");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.DateRealisation).HasColumnType("date");
            });

            modelBuilder.Entity<MethStructureMachine>(entity =>
            {
                entity.ToTable("Meth_StructureMachine");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Equipement)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.ReferenceModel).HasMaxLength(50);
            });

            modelBuilder.Entity<OrdreProduction>(entity =>
            {
                entity.HasKey(e => e.NumOrdre);

                entity.Property(e => e.NumOrdre).ValueGeneratedNever();

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.DateDebut).HasColumnType("datetime");

                entity.Property(e => e.DateFin).HasColumnType("datetime");

                entity.Property(e => e.Periode)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.CodeDemandeurNavigation)
                    .WithMany(p => p.OrdreProduction)
                    .HasForeignKey(d => d.CodeDemandeur)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrdreProduction_Intervenant");

                entity.HasOne(d => d.NumBonNavigation)
                    .WithMany(p => p.OrdreProduction)
                    .HasForeignKey(d => d.NumBon)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrdreProduction_BonProduction");

                entity.HasOne(d => d.PeriodeNavigation)
                    .WithMany(p => p.OrdreProduction)
                    .HasForeignKey(d => d.Periode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrdreProduction_PeriodeProduction");
            });

            modelBuilder.Entity<OrdreTravail>(entity =>
            {
                entity.HasKey(e => e.NumOt);

                entity.Property(e => e.NumOt)
                    .HasColumnName("NumOT")
                    .ValueGeneratedNever();

                entity.Property(e => e.DateOt)
                    .HasColumnName("DateOT")
                    .HasColumnType("datetime");

                entity.Property(e => e.HeureInstallation).HasColumnType("datetime");

                entity.Property(e => e.NumDt).HasColumnName("NumDT");

                entity.HasOne(d => d.CodeDemandeurNavigation)
                    .WithMany(p => p.OrdreTravail)
                    .HasForeignKey(d => d.CodeDemandeur)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrdreTravail_Structure");

                entity.HasOne(d => d.CodeMachineNavigation)
                    .WithMany(p => p.OrdreTravail)
                    .HasForeignKey(d => d.CodeMachine)
                    .HasConstraintName("FK_OrdreTravail_Machines");

                entity.HasOne(d => d.CodeMaintenanceNavigation)
                    .WithMany(p => p.OrdreTravail)
                    .HasForeignKey(d => d.CodeMaintenance)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrdreTravail_TypeMaintenance1");

                entity.HasOne(d => d.NumDtNavigation)
                    .WithMany(p => p.OrdreTravail)
                    .HasForeignKey(d => d.NumDt)
                    .HasConstraintName("FK_OrdreTravail_DemandeTravail");
            });

            modelBuilder.Entity<PeriodeProduction>(entity =>
            {
                entity.HasKey(e => e.DesignationPeriode);

                entity.Property(e => e.DesignationPeriode)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PrjDependecies>(entity =>
            {
                entity.HasKey(e => e.IdDependecy);

                entity.ToTable("PRJ_Dependecies");

                entity.Property(e => e.IdDependecy).ValueGeneratedNever();

                entity.Property(e => e.PredId).HasColumnName("PredID");

                entity.Property(e => e.SuccId).HasColumnName("SuccID");
            });

            modelBuilder.Entity<PrjRessourceAssignements>(entity =>
            {
                entity.ToTable("PRJ_Ressource_Assignements");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.RessourceId).HasColumnName("ressourceId");
            });

            modelBuilder.Entity<PrjRessources>(entity =>
            {
                entity.HasKey(e => e.IdRessource);

                entity.ToTable("PRJ_Ressources");

                entity.Property(e => e.IdRessource).ValueGeneratedNever();

                entity.Property(e => e.Text)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<PrjTasks>(entity =>
            {
                entity.ToTable("PRJ_Tasks");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.EndDate).HasColumnType("date");

                entity.Property(e => e.Start).HasColumnType("date");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<ProdArretsProgramme>(entity =>
            {
                entity.HasKey(e => e.DateArret);

                entity.ToTable("PROD_ArretsProgramme");

                entity.Property(e => e.DateArret).HasColumnType("date");

                entity.Property(e => e.DateDebut).HasColumnType("datetime");

                entity.Property(e => e.DateFin).HasColumnType("datetime");
            });

            modelBuilder.Entity<ProdArretsProgrammeArrets>(entity =>
            {
                entity.ToTable("PROD_ArretsProgramme_Arrets");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.DateArret).HasColumnType("date");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.HeureDebut).HasColumnType("datetime");

                entity.Property(e => e.HeureFin)
                    .HasColumnName("heureFin")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<ProdArretsPsSonalgaz>(entity =>
            {
                entity.ToTable("PROD_Arrets_PS_Sonalgaz");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Cause)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.DateArret).HasColumnType("date");

                entity.Property(e => e.DateDebut).HasColumnType("datetime");

                entity.Property(e => e.DateFin).HasColumnType("datetime");
            });

            modelBuilder.Entity<ProdCylindreAnomalies>(entity =>
            {
                entity.ToTable("PROD_Cylindre_Anomalies");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Anomalie).HasMaxLength(200);
            });

            modelBuilder.Entity<ProdPersonnelsArretsProgrammes>(entity =>
            {
                entity.ToTable("PROD_PersonnelsArretsProgrammes");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.DateArret).HasColumnType("date");
            });

            modelBuilder.Entity<ProdPreProccessingCylindresUsinage>(entity =>
            {
                entity.ToTable("Prod_PreProccessing_Cylindres_Usinage");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.DateChangement).HasColumnType("date");

                entity.Property(e => e.DateEntreeUsinage).HasColumnType("date");

                entity.Property(e => e.DateSortieUsinage).HasColumnType("date");

                entity.Property(e => e.RefCylindre)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<ProdPreparationCalibre>(entity =>
            {
                entity.ToTable("PROD_PreparationCalibre");

                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<ProdPreparationCylindre>(entity =>
            {
                entity.ToTable("PROD_PreparationCylindre");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.RefAncienCylindre).HasMaxLength(50);

                entity.Property(e => e.RefNouveauCylindre).HasMaxLength(50);
            });

            modelBuilder.Entity<ProdSuiviArretsServices>(entity =>
            {
                entity.ToTable("PROD_SuiviArretsServices");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.DateArret).HasColumnType("datetime");

                entity.Property(e => e.Dg).HasColumnName("DG");

                entity.Property(e => e.Eb).HasColumnName("EB");

                entity.Property(e => e.Hh).HasColumnName("HH");

                entity.Property(e => e.Hi).HasColumnName("HI");

                entity.Property(e => e.Kk).HasColumnName("KK");

                entity.Property(e => e.Mb).HasColumnName("MB");

                entity.Property(e => e.Ps).HasColumnName("PS");

                entity.Property(e => e.Tf).HasColumnName("TF");
            });

            modelBuilder.Entity<ProdSuiviArretsSonalgazTrainCages>(entity =>
            {
                entity.ToTable("PROD_SuiviArretsSonalgaz_Train_Cages");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.DateArret).HasColumnType("datetime");

                entity.Property(e => e.EnumArret).HasMaxLength(50);

                entity.Property(e => e.HerueFin).HasColumnType("datetime");

                entity.Property(e => e.HeureDebut).HasColumnType("datetime");

                entity.Property(e => e.Installation)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<ProdTachesArretsProgrammes>(entity =>
            {
                entity.ToTable("PROD_TachesArretsProgrammes");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.DateArret).HasColumnType("date");

                entity.Property(e => e.Description).HasMaxLength(50);
            });

            modelBuilder.Entity<ProdTonnagesCages>(entity =>
            {
                entity.ToTable("PROD_TonnagesCages");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Cage01)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Cage02)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Cage03)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Cage04)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Cage05)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Cage06)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Cage07)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Cage08)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Cage09)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Cage10)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Cage11)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Cage12)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Cage13)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.DateJournee).HasColumnType("date");
            });

            modelBuilder.Entity<ProdTotaux>(entity =>
            {
                entity.HasKey(e => e.DateProduction);

                entity.ToTable("PROD_Totaux");

                entity.Property(e => e.DateProduction).HasColumnType("date");
            });

            modelBuilder.Entity<Produits>(entity =>
            {
                entity.HasKey(e => e.CodeProduit);

                entity.Property(e => e.CodeProduit).ValueGeneratedNever();

                entity.Property(e => e.Designation)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Reference)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<QualiteBonCession>(entity =>
            {
                entity.HasKey(e => e.NumBonCession);

                entity.ToTable("QUALITE_BonCession");

                entity.Property(e => e.NumBonCession).ValueGeneratedNever();

                entity.Property(e => e.DateBonCession).HasColumnType("datetime");

                entity.Property(e => e.DateBonProduction).HasColumnType("datetime");
            });

            modelBuilder.Entity<QualiteBonCessionDetails>(entity =>
            {
                entity.ToTable("QUALITE_BonCession_Details");

                entity.Property(e => e.CodeArticle)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.NumBonCessionNavigation)
                    .WithMany(p => p.QualiteBonCessionDetails)
                    .HasForeignKey(d => d.NumBonCession)
                    .HasConstraintName("FK_QUALITE_BonCession_Details_QUALITE_BonCession");
            });

            modelBuilder.Entity<QualiteControlGeometrique>(entity =>
            {
                entity.HasKey(e => e.NumControl);

                entity.ToTable("QUALITE_ControlGeometrique");

                entity.Property(e => e.NumControl).ValueGeneratedNever();

                entity.Property(e => e.DateControl).HasColumnType("datetime");

                entity.Property(e => e.Remarque).HasMaxLength(200);
            });

            modelBuilder.Entity<QualiteControlGeometriqueDetails>(entity =>
            {
                entity.ToTable("QUALITE_ControlGeometrique_Details");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.HeureMiseCotes).HasColumnType("datetime");

                entity.Property(e => e.Profile)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Remarque)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.HasOne(d => d.NumControlNavigation)
                    .WithMany(p => p.QualiteControlGeometriqueDetails)
                    .HasForeignKey(d => d.NumControl)
                    .HasConstraintName("FK_QUALITE_ControlGeometrique_Details_QUALITE_ControlGeometrique");
            });

            modelBuilder.Entity<QualiteEssaisMecanique>(entity =>
            {
                entity.HasKey(e => e.NumEssai);

                entity.ToTable("QUALITE_EssaisMecanique");

                entity.Property(e => e.NumEssai).ValueGeneratedNever();

                entity.Property(e => e.Commentaire).HasMaxLength(200);

                entity.Property(e => e.DateEssaie).HasColumnType("datetime");
            });

            modelBuilder.Entity<QualiteEssaisMecaniqueDetails>(entity =>
            {
                entity.ToTable("QUALITE_EssaisMecanique_Details");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.HorraireEssai).HasColumnType("datetime");

                entity.Property(e => e.Profile)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Remarque).HasMaxLength(50);

                entity.Property(e => e.TauxRmre).HasColumnName("TauxRMRE");

                entity.HasOne(d => d.NumControlNavigation)
                    .WithMany(p => p.QualiteEssaisMecaniqueDetails)
                    .HasForeignKey(d => d.NumControl)
                    .HasConstraintName("FK_QUALITE_EssaisMecanique_Details_QUALITE_EssaisMecanique");
            });

            modelBuilder.Entity<QualiteProduitsFini>(entity =>
            {
                entity.ToTable("QUALITE_ProduitsFini");

                entity.Property(e => e.Id).HasMaxLength(50);

                entity.Property(e => e.Designation)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.NuanceAcier).HasMaxLength(50);
            });

            modelBuilder.Entity<QualiteRapports>(entity =>
            {
                entity.ToTable("QUALITE_Rapports");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.Profile)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<QualiteRapportsDetails>(entity =>
            {
                entity.ToTable("QUALITE_Rapports_Details");

                entity.Property(e => e.Jour).HasColumnType("date");

                entity.HasOne(d => d.NumRapportNavigation)
                    .WithMany(p => p.QualiteRapportsDetails)
                    .HasForeignKey(d => d.NumRapport)
                    .HasConstraintName("FK_QUALITE_Rapports_Details_QUALITE_Rapports");
            });

            modelBuilder.Entity<RapportIntervention>(entity =>
            {
                entity.HasKey(e => e.NumIntervention);

                entity.Property(e => e.NumIntervention).ValueGeneratedNever();

                entity.Property(e => e.CompteRendu)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.DateIntervention).HasColumnType("datetime");

                entity.Property(e => e.DebutIntervention).HasColumnType("datetime");

                entity.Property(e => e.Observation)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.HasOne(d => d.NumOtNavigation)
                    .WithMany(p => p.RapportIntervention)
                    .HasForeignKey(d => d.NumOt)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RapportIntervention_OrdreTravail");
            });

            modelBuilder.Entity<RhContratsEmployes>(entity =>
            {
                entity.ToTable("RH_ContratsEmployes");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.DateAmbouche).HasColumnType("date");

                entity.Property(e => e.DateFinAmbouche).HasColumnType("date");
            });

            modelBuilder.Entity<RhListeDesEmployes>(entity =>
            {
                entity.ToTable("RH_ListeDesEmployes");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Adresse).HasMaxLength(100);

                entity.Property(e => e.AdresseLatin).HasMaxLength(100);

                entity.Property(e => e.DateAmbouche).HasColumnType("date");

                entity.Property(e => e.DateCarteId).HasColumnType("date");

                entity.Property(e => e.DateFinAmbouche).HasColumnType("date");

                entity.Property(e => e.DateNaissance).HasColumnType("date");

                entity.Property(e => e.Email).HasColumnType("text");

                entity.Property(e => e.LieuCarteId).HasMaxLength(50);

                entity.Property(e => e.LieuNiassance).HasMaxLength(50);

                entity.Property(e => e.LieuNiassanceLatin).HasMaxLength(50);

                entity.Property(e => e.Nom)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.NomLatin).HasMaxLength(100);

                entity.Property(e => e.Prenom)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.PrenomLatin).HasMaxLength(100);

                entity.Property(e => e.VilleResidence).HasColumnType("text");
            });

            modelBuilder.Entity<SmartAssistItem>(entity =>
            {
                entity.ToTable("SmartAssist_Item");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Action)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Area)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Path)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Specialite>(entity =>
            {
                entity.HasKey(e => e.CodeSpecialite);

                entity.Property(e => e.CodeSpecialite).ValueGeneratedNever();

                entity.Property(e => e.Designation)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SrkBonRetour>(entity =>
            {
                entity.HasKey(e => e.NumBonRetour);

                entity.ToTable("SRK_BonRetour");

                entity.Property(e => e.NumBonRetour).ValueGeneratedNever();

                entity.Property(e => e.CodeFournisseur)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.DateLivrason).HasColumnType("datetime");

                entity.Property(e => e.DateRetour).HasColumnType("datetime");
            });

            modelBuilder.Entity<Statut>(entity =>
            {
                entity.HasKey(e => e.CodeStatut);

                entity.Property(e => e.CodeStatut).ValueGeneratedNever();

                entity.Property(e => e.Designation)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<StkAffectations>(entity =>
            {
                entity.HasKey(e => e.NumBonAffectation);

                entity.ToTable("STK_Affectations");

                entity.Property(e => e.DateAffectation).HasColumnType("date");

                entity.Property(e => e.DateEntree).HasColumnType("date");
            });

            modelBuilder.Entity<StkAffectationsArticles>(entity =>
            {
                entity.ToTable("STK_AffectationsArticles");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.CodePdrNavigation)
                    .WithMany(p => p.StkAffectationsArticles)
                    .HasForeignKey(d => d.CodePdr)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_STK_AffectationsArticles_STK_PDR");
            });

            modelBuilder.Entity<StkArticlesZero>(entity =>
            {
                entity.ToTable("STK_Articles_Zero");

                entity.Property(e => e.DateZero).HasColumnType("datetime");
            });

            modelBuilder.Entity<StkBonEntree>(entity =>
            {
                entity.HasKey(e => e.NumBon);

                entity.ToTable("STK_BonEntree");

                entity.Property(e => e.NumBon).ValueGeneratedNever();

                entity.Property(e => e.CodeFournisseur).HasMaxLength(100);

                entity.Property(e => e.DateDa)
                    .HasColumnName("DateDA")
                    .HasColumnType("datetime");

                entity.Property(e => e.DateEntree).HasColumnType("datetime");

                entity.Property(e => e.FournisseurNonGere).HasMaxLength(100);

                entity.Property(e => e.Nda).HasColumnName("NDA");
            });

            modelBuilder.Entity<StkBonEntreeArticles>(entity =>
            {
                entity.ToTable("STK_BonEntree_Articles");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.ArticleNonGere).HasMaxLength(100);

                entity.HasOne(d => d.CodePdrNavigation)
                    .WithMany(p => p.StkBonEntreeArticles)
                    .HasForeignKey(d => d.CodePdr)
                    .HasConstraintName("FK_STK_BonEntree_Articles_STK_PDR");
            });

            modelBuilder.Entity<StkBonRetourArticles>(entity =>
            {
                entity.ToTable("STK_BonRetour_Articles");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.DateRetour).HasColumnType("datetime");

                entity.Property(e => e.MotifRetour).HasMaxLength(100);

                entity.HasOne(d => d.CodeArticleNavigation)
                    .WithMany(p => p.StkBonRetourArticles)
                    .HasForeignKey(d => d.CodeArticle)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_STK_BonRetour_Articles_STK_PDR");
            });

            modelBuilder.Entity<StkBonRetourTransfert>(entity =>
            {
                entity.HasKey(e => e.NumBonRetourTransfert);

                entity.ToTable("STK_BonRetourTransfert");

                entity.Property(e => e.NumBonRetourTransfert).ValueGeneratedNever();

                entity.Property(e => e.Chauffeur)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.DateRetour).HasColumnType("datetime");

                entity.Property(e => e.Npc)
                    .HasColumnName("NPC")
                    .HasMaxLength(50);

                entity.Property(e => e.Source)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<StkBonRetourTransfertArticles>(entity =>
            {
                entity.ToTable("STK_BonRetourTransfert_Articles");

                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<StkBonSortie>(entity =>
            {
                entity.HasKey(e => e.NumBonSortie);

                entity.ToTable("STK_BonSortie");

                entity.Property(e => e.NumBonSortie).ValueGeneratedNever();

                entity.Property(e => e.DateSortie).HasColumnType("datetime");

                entity.Property(e => e.SourceSortie).HasDefaultValueSql("((10))");
            });

            modelBuilder.Entity<StkBonSortieArticles>(entity =>
            {
                entity.ToTable("STK_BonSortie_Articles");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.ArticleNonGere).HasMaxLength(100);

                entity.Property(e => e.DateSortie).HasColumnType("datetime");

                entity.Property(e => e.LieuDemandé).HasMaxLength(100);

                entity.HasOne(d => d.CodeArticleNavigation)
                    .WithMany(p => p.StkBonSortieArticles)
                    .HasForeignKey(d => d.CodeArticle)
                    .HasConstraintName("FK_STK_BonSortie_Articles_STK_PDR");
            });

            modelBuilder.Entity<StkBonTransfert>(entity =>
            {
                entity.HasKey(e => e.NumBonTransfert);

                entity.ToTable("STK_BonTransfert");

                entity.Property(e => e.NumBonTransfert).ValueGeneratedNever();

                entity.Property(e => e.DateTransfert).HasColumnType("datetime");
            });

            modelBuilder.Entity<StkBonTransfertArticles>(entity =>
            {
                entity.ToTable("STK_BonTransfert_Articles");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.DateTransfert).HasColumnType("datetime");
            });

            modelBuilder.Entity<StkCentreFrais>(entity =>
            {
                entity.HasKey(e => e.CodeCentreFrais);

                entity.ToTable("STK_CentreFrais");

                entity.Property(e => e.CodeCentreFrais).ValueGeneratedNever();

                entity.Property(e => e.DesignationCentreFrais)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<StkDecharge>(entity =>
            {
                entity.HasKey(e => e.NumDecharge);

                entity.ToTable("STK_Decharge");

                entity.Property(e => e.NumDecharge).ValueGeneratedNever();

                entity.Property(e => e.DateDecharge).HasColumnType("datetime");
            });

            modelBuilder.Entity<StkDechargeArticles>(entity =>
            {
                entity.ToTable("STK_Decharge_Articles");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.DateDecharge).HasColumnType("datetime");

                entity.Property(e => e.Observation).HasMaxLength(50);

                entity.HasOne(d => d.CodeArticleNavigation)
                    .WithMany(p => p.StkDechargeArticles)
                    .HasForeignKey(d => d.CodeArticle)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_STK_Decharge_Articles_STK_PDR");
            });

            modelBuilder.Entity<StkEmplacement>(entity =>
            {
                entity.HasKey(e => e.NumEmplacement);

                entity.ToTable("STK_Emplacement");

                entity.Property(e => e.Qte).HasColumnName("QTE");

                entity.HasOne(d => d.CodePdrNavigation)
                    .WithMany(p => p.StkEmplacement)
                    .HasForeignKey(d => d.CodePdr)
                    .HasConstraintName("FK_STK_Emplacement_STK_PDR");
            });

            modelBuilder.Entity<StkEntreeFraisApproches>(entity =>
            {
                entity.ToTable("STK_Entree_FraisApproches");

                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<StkEquipements>(entity =>
            {
                entity.HasKey(e => e.NumEquipement);

                entity.ToTable("STK_Equipements");

                entity.Property(e => e.NumEquipement).ValueGeneratedNever();

                entity.Property(e => e.CodeEquipement)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.DateAcquisition).HasColumnType("date");

                entity.Property(e => e.DateInstallation).HasColumnType("date");

                entity.Property(e => e.Marque).HasMaxLength(50);

                entity.Property(e => e.Nom)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Type).HasMaxLength(50);
            });

            modelBuilder.Entity<StkFamillePdr>(entity =>
            {
                entity.HasKey(e => e.CodeFamillePdr);

                entity.ToTable("STK_FamillePDR");

                entity.Property(e => e.CodeFamillePdr)
                    .HasColumnName("CodeFamillePDR")
                    .HasMaxLength(50);

                entity.Property(e => e.DesignationFamillePdr)
                    .IsRequired()
                    .HasColumnName("DesignationFamillePDR")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<StkFicheArticle>(entity =>
            {
                entity.HasKey(e => e.NumFicheArticle);

                entity.ToTable("STK_FicheArticle");

                entity.Property(e => e.NumFicheArticle).ValueGeneratedNever();

                entity.Property(e => e.CodePdr).HasColumnName("CodePDR");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.HasOne(d => d.CodePdrNavigation)
                    .WithMany(p => p.StkFicheArticle)
                    .HasForeignKey(d => d.CodePdr)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_STK_FicheArticle_STK_PDR");
            });

            modelBuilder.Entity<StkFraisApproches>(entity =>
            {
                entity.ToTable("STK_FraisApproches");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.DesignationFraisApproche)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<StkGismentPdr>(entity =>
            {
                entity.HasKey(e => e.CodeGisment)
                    .HasName("PK_STK_ReperePDR");

                entity.ToTable("STK_GismentPDR");

                entity.Property(e => e.CodeGisment).ValueGeneratedNever();

                entity.Property(e => e.DesignationGisment)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<StkGroupePdr>(entity =>
            {
                entity.HasKey(e => e.CodeGroupe);

                entity.ToTable("STK_GroupePDR");

                entity.Property(e => e.CodeGroupe).ValueGeneratedNever();

                entity.Property(e => e.DesignationGroupe)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<StkInventaires>(entity =>
            {
                entity.HasKey(e => e.NumInventaire);

                entity.ToTable("STK_Inventaires");

                entity.Property(e => e.NumInventaire).ValueGeneratedNever();

                entity.Property(e => e.DateDebut).HasColumnType("date");

                entity.Property(e => e.DateFin).HasColumnType("date");
            });

            modelBuilder.Entity<StkInventairesArticles>(entity =>
            {
                entity.ToTable("STK_Inventaires_Articles");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.CodeArticleNavigation)
                    .WithMany(p => p.StkInventairesArticles)
                    .HasForeignKey(d => d.CodeArticle)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_STK_Inventaires_Articles_STK_PDR");
            });

            modelBuilder.Entity<StkInventairesEquipeMembres>(entity =>
            {
                entity.ToTable("STK_Inventaires_EquipeMembres");

                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<StkInventairesEquipes>(entity =>
            {
                entity.ToTable("STK_Inventaires_Equipes");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.NomEquipe)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<StkInventairesLieux>(entity =>
            {
                entity.ToTable("STK_Inventaires_Lieux");

                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<StkLieu>(entity =>
            {
                entity.HasKey(e => e.CodeLieu);

                entity.ToTable("STK_Lieu");

                entity.Property(e => e.CodeLieu).ValueGeneratedNever();

                entity.Property(e => e.DesignationLieu)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<StkMovements>(entity =>
            {
                entity.HasKey(e => e.IdMovement);

                entity.ToTable("STK_Movements");

                entity.Property(e => e.ArticleNonGere).HasMaxLength(100);

                entity.Property(e => e.CodePdr).HasColumnName("CodePDR");

                entity.Property(e => e.DateMovment).HasColumnType("datetime");

                entity.HasOne(d => d.CodePdrNavigation)
                    .WithMany(p => p.StkMovements)
                    .HasForeignKey(d => d.CodePdr)
                    .HasConstraintName("FK_STK_Movements_STK_PDR");
            });

            modelBuilder.Entity<StkPdr>(entity =>
            {
                entity.HasKey(e => e.CodePdr);

                entity.ToTable("STK_PDR");

                entity.Property(e => e.CodePdr)
                    .HasColumnName("CodePDR")
                    .ValueGeneratedNever();

                entity.Property(e => e.CodeFabricant).HasMaxLength(50);

                entity.Property(e => e.CodeFamillePdr)
                    .HasColumnName("CodeFamillePDR")
                    .HasMaxLength(50);

                entity.Property(e => e.CodeSousFamillePdr).HasMaxLength(50);

                entity.Property(e => e.CodeUniteMesurePdr).HasColumnName("CodeUniteMesurePDR");

                entity.Property(e => e.Conditionnement).HasMaxLength(1000);

                entity.Property(e => e.DesignationPdr)
                    .HasColumnName("DesignationPDR")
                    .HasMaxLength(1000);

                entity.Property(e => e.ReferenceModele).HasMaxLength(100);
            });

            modelBuilder.Entity<StkPdrStockContrainte>(entity =>
            {
                entity.ToTable("STK_PDR_StockContrainte");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.CodePdrNavigation)
                    .WithMany(p => p.StkPdrStockContrainte)
                    .HasForeignKey(d => d.CodePdr)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_STK_PDR_StockContrainte_STK_PDR");
            });

            modelBuilder.Entity<StkPdrStockSurveillenceService>(entity =>
            {
                entity.ToTable("STK_PDR_StockSurveillenceService");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.CodePdrNavigation)
                    .WithMany(p => p.StkPdrStockSurveillenceService)
                    .HasForeignKey(d => d.CodePdr)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_STK_PDR_StockSurveillenceService_STK_PDR");
            });

            modelBuilder.Entity<StkRapportTransfertBillette>(entity =>
            {
                entity.HasKey(e => e.NumRapportTransfert);

                entity.ToTable("STK_RapportTransfertBillette");

                entity.Property(e => e.NumRapportTransfert).ValueGeneratedNever();

                entity.Property(e => e.DateTransfert).HasColumnType("date");
            });

            modelBuilder.Entity<StkRapportTransfertBillettesDetails>(entity =>
            {
                entity.ToTable("STK_RapportTransfertBillettesDetails");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Billette)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.HeureTransfert).HasColumnType("datetime");

                entity.Property(e => e.Observation).HasMaxLength(50);
            });

            modelBuilder.Entity<StkReceptionBillette>(entity =>
            {
                entity.HasKey(e => e.NumReception);

                entity.ToTable("STK_ReceptionBillette");

                entity.Property(e => e.NumReception).ValueGeneratedNever();

                entity.Property(e => e.BilleteRecue)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.DateReception).HasColumnType("datetime");

                entity.Property(e => e.Navire)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<StkReceptionBilletteDetails>(entity =>
            {
                entity.ToTable("STK_ReceptionBilletteDetails");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();
            });

            modelBuilder.Entity<StkReintegration>(entity =>
            {
                entity.HasKey(e => e.NumBonReintegration);

                entity.ToTable("STK_Reintegration");

                entity.Property(e => e.NumBonReintegration).ValueGeneratedNever();

                entity.Property(e => e.DateReingegration).HasColumnType("datetime");
            });

            modelBuilder.Entity<StkReintegrationArticles>(entity =>
            {
                entity.ToTable("STK_Reintegration_Articles");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.DateReingegration).HasColumnType("datetime");

                entity.Property(e => e.LieuDemande).HasMaxLength(100);

                entity.HasOne(d => d.CodeArticleNavigation)
                    .WithMany(p => p.StkReintegrationArticles)
                    .HasForeignKey(d => d.CodeArticle)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_STK_Reintegration_Articles_STK_PDR");
            });

            modelBuilder.Entity<StkRestitution>(entity =>
            {
                entity.HasKey(e => e.NumRestitution);

                entity.ToTable("STK_Restitution");

                entity.Property(e => e.NumRestitution).ValueGeneratedNever();

                entity.Property(e => e.DateRestitution).HasColumnType("datetime");
            });

            modelBuilder.Entity<StkRestitutionArticles>(entity =>
            {
                entity.ToTable("STK_Restitution_Articles");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.DateRestitution).HasColumnType("datetime");

                entity.Property(e => e.Observation).HasMaxLength(50);

                entity.HasOne(d => d.CodeArticleNavigation)
                    .WithMany(p => p.StkRestitutionArticles)
                    .HasForeignKey(d => d.CodeArticle)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_STK_Restitution_Articles_STK_PDR");
            });

            modelBuilder.Entity<StkSousFamillePdr>(entity =>
            {
                entity.HasKey(e => e.CodeSousFamille);

                entity.ToTable("STK_SousFamillePDR");

                entity.Property(e => e.CodeSousFamille).HasMaxLength(50);

                entity.Property(e => e.CodeFamille)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.DesignationSousFamille)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<StkStockInitial>(entity =>
            {
                entity.ToTable("STK_StockInitial");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.CodePdrNavigation)
                    .WithMany(p => p.StkStockInitial)
                    .HasForeignKey(d => d.CodePdr)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_STK_StockInitial_STK_PDR");
            });

            modelBuilder.Entity<StkTypeAchat>(entity =>
            {
                entity.ToTable("STK_TypeAchat");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.DesignationTypeAchat)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<StkTypeMovement>(entity =>
            {
                entity.HasKey(e => e.CodeMovement);

                entity.ToTable("STK_Type_Movement");

                entity.Property(e => e.CodeMovement).ValueGeneratedNever();

                entity.Property(e => e.DesignationMovement)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<StkTypeValorisation>(entity =>
            {
                entity.HasKey(e => e.CodeValorisation);

                entity.ToTable("STK_TYPE_Valorisation");

                entity.Property(e => e.CodeValorisation).ValueGeneratedNever();

                entity.Property(e => e.DesignationValorisation)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<StkUniteMesurePdr>(entity =>
            {
                entity.HasKey(e => e.CodeUniteMesurePdr);

                entity.ToTable("STK_UniteMesurePDR");

                entity.Property(e => e.CodeUniteMesurePdr)
                    .HasColumnName("CodeUniteMesurePDR")
                    .ValueGeneratedNever();

                entity.Property(e => e.DesignationUniteMesurePdr)
                    .IsRequired()
                    .HasColumnName("DesignationUniteMesurePDR")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Structure>(entity =>
            {
                entity.HasKey(e => e.CodeStructure);

                entity.Property(e => e.CodeStructure).ValueGeneratedNever();

                entity.Property(e => e.Designation)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Responsable)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SubMachineArret>(entity =>
            {
                entity.HasKey(e => e.DesignationSub);

                entity.Property(e => e.DesignationSub)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SuiviEntretienPersonnels>(entity =>
            {
                entity.HasKey(e => e.IdEntretien);

                entity.ToTable("Suivi_EntretienPersonnels");

                entity.Property(e => e.IdEntretien).ValueGeneratedNever();

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.DateIncidant).HasColumnType("datetime");

                entity.Property(e => e.Explication)
                    .IsRequired()
                    .HasMaxLength(2000);

                entity.Property(e => e.Lieu)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Observation)
                    .IsRequired()
                    .HasMaxLength(1000);

                entity.Property(e => e.Sujet)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<TempApproArticlesDemandes>(entity =>
            {
                entity.ToTable("TEMP_APPRO_ArticlesDemandes");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.ArticleNonGere).HasMaxLength(100);

                entity.Property(e => e.Qte).HasColumnName("QTE");
            });

            modelBuilder.Entity<TempApproDemandeServiceDetail>(entity =>
            {
                entity.ToTable("TEMP_APPRO_DemandeServiceDetail");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.ServiceDemande).HasMaxLength(200);
            });

            modelBuilder.Entity<TempAssOtConsommable>(entity =>
            {
                entity.ToTable("Temp_Ass_OtConsommable");

                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<TempAssOtIntervenants>(entity =>
            {
                entity.ToTable("TEMP_ASS_OT_Intervenants");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();
            });

            modelBuilder.Entity<TempAssOtPdr>(entity =>
            {
                entity.ToTable("Temp_Ass_OtPdr");

                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<TempAssOtTravaux>(entity =>
            {
                entity.ToTable("TEMP_AssOtTravaux");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Autres).HasMaxLength(200);

                entity.Property(e => e.Qte).HasColumnName("QTE");
            });

            modelBuilder.Entity<TempMaintPointControleDetail>(entity =>
            {
                entity.ToTable("Temp_Maint_PointControleDetail");

                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<TempPlanningMensuellePreventif>(entity =>
            {
                entity.ToTable("TEMP_PlanningMensuellePreventif");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.DateAnterieure).HasColumnType("date");

                entity.Property(e => e.DateProchaine).HasColumnType("date");

                entity.Property(e => e.Equipement)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.OperationMaintenance)
                    .IsRequired()
                    .HasMaxLength(1000);

                entity.Property(e => e.Pdr)
                    .HasColumnName("PDR")
                    .HasMaxLength(100);

                entity.Property(e => e.Pdrqte)
                    .HasColumnName("PDRQte")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<TempStkPdrStockContrainte>(entity =>
            {
                entity.ToTable("TEMP_STK_PDR_StockContrainte");

                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<TempStructureMachine>(entity =>
            {
                entity.HasKey(e => e.CodeInstallation);

                entity.Property(e => e.CodeInstallation).ValueGeneratedNever();

                entity.Property(e => e.Equipement)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<TrackingOperations>(entity =>
            {
                entity.ToTable("Tracking_Operations");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.DateOperation).HasColumnType("datetime");

                entity.Property(e => e.IpAdress)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.MaccAdress)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Operation)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<TypeMaintenance>(entity =>
            {
                entity.HasKey(e => e.CodeMaintenance);

                entity.Property(e => e.DesignationMaintenance)
                    .IsRequired()
                    .HasColumnType("text");
            });

            modelBuilder.Entity<UrgenceTravaille>(entity =>
            {
                entity.HasKey(e => e.CodeUrgence);

                entity.Property(e => e.DesignationUrgence)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
