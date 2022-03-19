using System;
using System.Collections.Generic;

namespace DevKbfSteel.Entities
{
    public partial class ArretProductionJournee
    {
        public int Id { get; set; }
        public int NumRapport { get; set; }
        public int? NumIncident { get; set; }
        public string CodeMachine { get; set; }
        public string SubMachine { get; set; }
        public string Cause { get; set; }
        public DateTime? HeureDebut { get; set; }
        public DateTime? HeureFin { get; set; }
        public string EnumArret { get; set; }
        public int? NbrBilleteDefournees { get; set; }
        public int? NbrBilleteRejetees { get; set; }
        public int? NbrBilleteCisalleTrio { get; set; }
        public int? NbrBilleteCisalleFinisseuse { get; set; }
        public DateTime? DateArret { get; set; }
        public int? NbrBilleteRealisees { get; set; }
    }
}
