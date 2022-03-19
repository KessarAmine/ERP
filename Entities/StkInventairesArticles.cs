using System;
using System.Collections.Generic;

namespace DevKbfSteel.Entities
{
    public partial class StkInventairesArticles
    {
        public int Id { get; set; }
        public int NumInventaire { get; set; }
        public int CodeArticle { get; set; }
        public int? Qte { get; set; }
        public int? CodeEquipe { get; set; }

        public virtual StkPdr CodeArticleNavigation { get; set; }
    }
}
