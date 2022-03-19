using System;
using System.Collections.Generic;

namespace DevKbfSteel.Entities
{
    public partial class StkPdrStockSurveillenceService
    {
        public int Id { get; set; }
        public int CodePdr { get; set; }
        public double QteAlerte { get; set; }
        public int CodeStructure { get; set; }

        public virtual StkPdr CodePdrNavigation { get; set; }
    }
}
