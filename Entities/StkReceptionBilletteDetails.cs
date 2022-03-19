using System;
using System.Collections.Generic;

namespace DevKbfSteel.Entities
{
    public partial class StkReceptionBilletteDetails
    {
        public int Id { get; set; }
        public int NumBon { get; set; }
        public int NumReception { get; set; }
        public int NumImTracteur { get; set; }
        public int NumImRemorque { get; set; }
        public int NbrFdx { get; set; }
        public int NbrPieces { get; set; }
        public double NetPoidTh { get; set; }
    }
}
