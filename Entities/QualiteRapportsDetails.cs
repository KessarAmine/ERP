using System;
using System.Collections.Generic;

namespace DevKbfSteel.Entities
{
    public partial class QualiteRapportsDetails
    {
        public int Id { get; set; }
        public int NumRapport { get; set; }
        public DateTime Jour { get; set; }
        public int? Fardeau1 { get; set; }
        public int? Fardeau2 { get; set; }
        public int? Fardeau3 { get; set; }
        public int? Rebut1 { get; set; }
        public int? Rebut2 { get; set; }
        public int? Rebut3 { get; set; }
        public int? FardeauExpedie1 { get; set; }
        public int? FardeauExpedie2 { get; set; }
        public int? FardeauExpedie3 { get; set; }
        public int? FardeauRecupere1 { get; set; }
        public int? FardeauRecupere2 { get; set; }
        public int? FardeauRecupere3 { get; set; }
        public int? FardeauStockTheorique { get; set; }
        public int? FardeauStockReel { get; set; }

        public virtual QualiteRapports NumRapportNavigation { get; set; }
    }
}
