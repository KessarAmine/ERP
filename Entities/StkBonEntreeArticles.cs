using System;
using System.Collections.Generic;

namespace DevKbfSteel.Entities
{
    public partial class StkBonEntreeArticles
    {
        public int Id { get; set; }
        public int NumBonEntree { get; set; }
        public int? CodePdr { get; set; }
        public double QteRecu { get; set; }
        public double PrixUnitaire { get; set; }
        public double? CoutUnitaire { get; set; }
        public double Montant { get; set; }
        public string ArticleNonGere { get; set; }
        public int? CodeFrais { get; set; }
        public double? ValeurFrais { get; set; }
        public double? MontantDevise { get; set; }
        public int? NumFacture { get; set; }
        public bool? CodeInvesstisment { get; set; }
        public int? UniteMesureArticleNonGere { get; set; }

        public virtual StkPdr CodePdrNavigation { get; set; }
    }
}
