using System;
using System.Collections.Generic;

namespace DevKbfSteel.Entities
{
    public partial class StkBonSortie
    {
        public int NumBonSortie { get; set; }
        public DateTime DateSortie { get; set; }
        public int? CodeServiceEmetteur { get; set; }
        public int CodeIntervenant { get; set; }
        public int? NumDemandeFourniture { get; set; }
        public int TypeSortie { get; set; }
        public int? CentreFrais { get; set; }
        public int? CodeEmetteur { get; set; }
        public int? CodeEmplacement { get; set; }
        public int? SourceSortie { get; set; }
    }
}
