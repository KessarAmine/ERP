using System;
using System.Collections.Generic;

namespace DevKbfSteel.Entities
{
    public partial class ApproArticlesDemandes
    {
        public int Id { get; set; }
        public int NumeroDemande { get; set; }
        public int? CodeArticle { get; set; }
        public double Qte { get; set; }
        public double? QteLivrees { get; set; }
        public double? QteReste { get; set; }
        public DateTime? DateLivraison { get; set; }
        public double? QteValable { get; set; }
        public string ArticleNonGere { get; set; }

        public virtual ApproDemandeAchats NumeroDemandeNavigation { get; set; }
    }
}
