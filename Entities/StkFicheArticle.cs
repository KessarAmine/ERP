using System;
using System.Collections.Generic;

namespace DevKbfSteel.Entities
{
    public partial class StkFicheArticle
    {
        public int NumFicheArticle { get; set; }
        public DateTime Date { get; set; }
        public int? Emeteur { get; set; }
        public int CodePdr { get; set; }

        public virtual StkPdr CodePdrNavigation { get; set; }
    }
}
