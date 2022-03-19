using System;
using System.Collections.Generic;

namespace DevKbfSteel.Entities
{
    public partial class AssOtPdr
    {
        public int Id { get; set; }
        public int NumIntervention { get; set; }
        public int CodePdr { get; set; }
        public double Qte { get; set; }
        public double Montant { get; set; }
        public double PrixUnitaire { get; set; }
    }
}
