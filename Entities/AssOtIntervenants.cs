using System;
using System.Collections.Generic;

namespace DevKbfSteel.Entities
{
    public partial class AssOtIntervenants
    {
        public int Id { get; set; }
        public int NumIntervention { get; set; }
        public int CodeIntervenant { get; set; }
        public int? CodeSpecialite { get; set; }
        public int? CodeMachine { get; set; }
        public string CodeEquipement { get; set; }
        public DateTime? DateIntervention { get; set; }
        public double? DureeInervention { get; set; }
    }
}
