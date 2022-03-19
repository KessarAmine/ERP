using System;
using System.Collections.Generic;

namespace DevKbfSteel.Entities
{
    public partial class StkBonSortieArticles
    {
        public int Id { get; set; }
        public int NumBonSortie { get; set; }
        public int? CodeArticle { get; set; }
        public double Qte { get; set; }
        public double PrixUnitaire { get; set; }
        public double Montant { get; set; }
        public int? CodePreneur { get; set; }
        public string LieuDemandé { get; set; }
        public DateTime? DateSortie { get; set; }
        public string ArticleNonGere { get; set; }
        public int? UniteMesureArticleNonGere { get; set; }

        public virtual StkPdr CodeArticleNavigation { get; set; }
    }
}
