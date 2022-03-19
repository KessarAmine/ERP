using System;
using System.Collections.Generic;

namespace DevKbfSteel.Areas.MagasinAgent.Models
{
    public partial class RecapBillettesModel
    {
        public DateTime Date { get; set; }
        public string Navire { get; set; }
        public int? NbrRotations { get; set; }
        public int? NbrFdx { get; set; }
        public int? NbrPieces { get; set; }
        public double? Tonnage { get; set; }
    }
}
