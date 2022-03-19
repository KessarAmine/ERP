using System;
using System.Collections.Generic;

namespace DevKbfSteel.Entities
{
    public partial class StkAffectationsArticles
    {
        public int Id { get; set; }
        public int NumBonAffectation { get; set; }
        public int CodePdr { get; set; }
        public double Qte { get; set; }
        public double? PrixUnitaire { get; set; }
        public double? Montant { get; set; }

        public virtual StkPdr CodePdrNavigation { get; set; }
    }
}
