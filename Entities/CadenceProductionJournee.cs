using System;
using System.Collections.Generic;

namespace DevKbfSteel.Entities
{
    public partial class CadenceProductionJournee
    {
        public int Id { get; set; }
        public int NumRapport { get; set; }
        public int H1 { get; set; }
        public int H2 { get; set; }
        public int H3 { get; set; }
        public int H4 { get; set; }
        public int H5 { get; set; }
        public int H6 { get; set; }
        public int H7 { get; set; }
        public int H8 { get; set; }
        public int H9 { get; set; }
        public int H10 { get; set; }
        public int H11 { get; set; }
        public int? H12 { get; set; }

        public virtual JourneeProduction NumRapportNavigation { get; set; }
    }
}
