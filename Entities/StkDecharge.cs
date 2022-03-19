using System;
using System.Collections.Generic;

namespace DevKbfSteel.Entities
{
    public partial class StkDecharge
    {
        public int NumDecharge { get; set; }
        public DateTime DateDecharge { get; set; }
        public int ServiceReceveur { get; set; }
        public int? CodeIntervenant { get; set; }
    }
}
