using System;
using System.Collections.Generic;

namespace DevKbfSteel.Entities
{
    public partial class StkReintegration
    {
        public int NumBonReintegration { get; set; }
        public DateTime DateReingegration { get; set; }
        public int ServiceEmetteur { get; set; }
        public int? CodeIntervenant { get; set; }
    }
}
