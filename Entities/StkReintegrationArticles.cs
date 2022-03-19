using System;
using System.Collections.Generic;

namespace DevKbfSteel.Entities
{
    public partial class StkReintegrationArticles
    {
        public int Id { get; set; }
        public int NumBonReintegration { get; set; }
        public int CodeArticle { get; set; }
        public int Qte { get; set; }
        public int CodeIntervenant { get; set; }
        public string LieuDemande { get; set; }
        public DateTime? DateReingegration { get; set; }
        public double? PrixUnitaire { get; set; }
        public double? Montant { get; set; }

        public virtual StkPdr CodeArticleNavigation { get; set; }
    }
}
