using System;
using System.Collections.Generic;

namespace DevKbfSteel.Entities
{
    public partial class StkBonTransfert
    {
        public int NumBonTransfert { get; set; }
        public DateTime DateTransfert { get; set; }
        public int Destination { get; set; }
        public int Source { get; set; }
        public int? CodeIntervenant { get; set; }
    }
}
