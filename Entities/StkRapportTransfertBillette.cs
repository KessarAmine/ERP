using System;
using System.Collections.Generic;

namespace DevKbfSteel.Entities
{
    public partial class StkRapportTransfertBillette
    {
        public int NumRapportTransfert { get; set; }
        public DateTime DateTransfert { get; set; }
        public int? ChauffeurClarck { get; set; }
        public int? ChauffeutGrue { get; set; }
    }
}
