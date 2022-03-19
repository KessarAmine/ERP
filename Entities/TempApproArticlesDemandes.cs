using System;
using System.Collections.Generic;

namespace DevKbfSteel.Entities
{
    public partial class TempApproArticlesDemandes
    {
        public int Id { get; set; }
        public int? CodeArticle { get; set; }
        public double Qte { get; set; }
        public string ArticleNonGere { get; set; }
    }
}
