using System;
using System.Collections.Generic;

namespace DevKbfSteel.Entities
{
    public partial class StkAffectations
    {
        public int NumBonAffectation { get; set; }
        public DateTime DateAffectation { get; set; }
        public int SericeEmetteur { get; set; }
        public int ServiceReceveur { get; set; }
        public int NumBonEntree { get; set; }
        public DateTime DateEntree { get; set; }
        public int? CodeCloture { get; set; }
        public int CodeIntervenant { get; set; }
    }
}
