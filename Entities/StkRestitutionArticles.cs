using System;
using System.Collections.Generic;

namespace DevKbfSteel.Entities
{
    public partial class StkRestitutionArticles
    {
        public int Id { get; set; }
        public int NumRestitution { get; set; }
        public int CodeArticle { get; set; }
        public double Qte { get; set; }
        public string Observation { get; set; }
        public DateTime? DateRestitution { get; set; }
        public double? PrixUnitaire { get; set; }
        public double? Montant { get; set; }

        public virtual StkPdr CodeArticleNavigation { get; set; }
    }
}
