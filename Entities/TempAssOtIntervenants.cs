using System;
using System.Collections.Generic;

namespace DevKbfSteel.Entities
{
    public partial class TempAssOtIntervenants
    {
        public int Id { get; set; }
        public int NumIntervention { get; set; }
        public int CodeIntervenant { get; set; }
        public int CodeMachine { get; set; }
        public int? CodeEquipement { get; set; }
        public double DureeInervention { get; set; }
    }
}
