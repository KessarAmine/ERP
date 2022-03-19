using System;
using System.Collections.Generic;

namespace DevKbfSteel.Entities
{
    public partial class StkRestitution
    {
        public int NumRestitution { get; set; }
        public DateTime DateRestitution { get; set; }
        public int ServiceEmetteur { get; set; }
        public int NumDecharge { get; set; }
        public int? CodeIntervenant { get; set; }
    }
}
