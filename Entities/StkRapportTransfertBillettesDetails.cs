using System;
using System.Collections.Generic;

namespace DevKbfSteel.Entities
{
    public partial class StkRapportTransfertBillettesDetails
    {
        public int Id { get; set; }
        public int NumRapportTransfert { get; set; }
        public DateTime HeureTransfert { get; set; }
        public string Billette { get; set; }
        public int NbrFdx { get; set; }
        public int NbrPieces { get; set; }
        public string Observation { get; set; }
    }
}
