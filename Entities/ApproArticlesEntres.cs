using System;
using System.Collections.Generic;

namespace DevKbfSteel.Entities
{
    public partial class ApproArticlesEntres
    {
        public int Id { get; set; }
        public int NumBon { get; set; }
        public string DesignationArticle { get; set; }
        public double Qte { get; set; }

        public virtual ApproBonsEntrees NumBonNavigation { get; set; }
    }
}
