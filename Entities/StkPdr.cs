using System;
using System.Collections.Generic;

namespace DevKbfSteel.Entities
{
    public partial class StkPdr
    {
        public StkPdr()
        {
            StkAffectationsArticles = new HashSet<StkAffectationsArticles>();
            StkBonEntreeArticles = new HashSet<StkBonEntreeArticles>();
            StkBonRetourArticles = new HashSet<StkBonRetourArticles>();
            StkBonSortieArticles = new HashSet<StkBonSortieArticles>();
            StkDechargeArticles = new HashSet<StkDechargeArticles>();
            StkEmplacement = new HashSet<StkEmplacement>();
            StkFicheArticle = new HashSet<StkFicheArticle>();
            StkInventairesArticles = new HashSet<StkInventairesArticles>();
            StkMovements = new HashSet<StkMovements>();
            StkPdrStockContrainte = new HashSet<StkPdrStockContrainte>();
            StkPdrStockSurveillenceService = new HashSet<StkPdrStockSurveillenceService>();
            StkReintegrationArticles = new HashSet<StkReintegrationArticles>();
            StkRestitutionArticles = new HashSet<StkRestitutionArticles>();
            StkStockInitial = new HashSet<StkStockInitial>();
        }

        public int CodePdr { get; set; }
        public string DesignationPdr { get; set; }
        public int? CodeUniteMesurePdr { get; set; }
        public string CodeFamillePdr { get; set; }
        public string CodeSousFamillePdr { get; set; }
        public int? CompteComptable { get; set; }
        public string Conditionnement { get; set; }
        public string CodeFabricant { get; set; }
        public int? CodeGroupe { get; set; }
        public bool? ArticleCritique { get; set; }
        public int? TypeValorisation { get; set; }
        public int? TypeArticle { get; set; }
        public int? NatureArticle { get; set; }
        public string ReferenceModele { get; set; }

        public virtual ICollection<StkAffectationsArticles> StkAffectationsArticles { get; set; }
        public virtual ICollection<StkBonEntreeArticles> StkBonEntreeArticles { get; set; }
        public virtual ICollection<StkBonRetourArticles> StkBonRetourArticles { get; set; }
        public virtual ICollection<StkBonSortieArticles> StkBonSortieArticles { get; set; }
        public virtual ICollection<StkDechargeArticles> StkDechargeArticles { get; set; }
        public virtual ICollection<StkEmplacement> StkEmplacement { get; set; }
        public virtual ICollection<StkFicheArticle> StkFicheArticle { get; set; }
        public virtual ICollection<StkInventairesArticles> StkInventairesArticles { get; set; }
        public virtual ICollection<StkMovements> StkMovements { get; set; }
        public virtual ICollection<StkPdrStockContrainte> StkPdrStockContrainte { get; set; }
        public virtual ICollection<StkPdrStockSurveillenceService> StkPdrStockSurveillenceService { get; set; }
        public virtual ICollection<StkReintegrationArticles> StkReintegrationArticles { get; set; }
        public virtual ICollection<StkRestitutionArticles> StkRestitutionArticles { get; set; }
        public virtual ICollection<StkStockInitial> StkStockInitial { get; set; }
    }
}
