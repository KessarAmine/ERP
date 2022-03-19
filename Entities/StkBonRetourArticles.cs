using System;
using System.Collections.Generic;

namespace DevKbfSteel.Entities
{
    public partial class StkBonRetourArticles
    {
        public int Id { get; set; }
        public int NumBonRetour { get; set; }
        public int CodeArticle { get; set; }
        public double Qte { get; set; }
        public double PrixUnitaire { get; set; }
        public string MotifRetour { get; set; }
        public DateTime? DateRetour { get; set; }
        public double? Montant { get; set; }

        public virtual StkPdr CodeArticleNavigation { get; set; }
    }
}
