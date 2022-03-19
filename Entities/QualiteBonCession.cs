using System;
using System.Collections.Generic;

namespace DevKbfSteel.Entities
{
    public partial class QualiteBonCession
    {
        public QualiteBonCession()
        {
            QualiteBonCessionDetails = new HashSet<QualiteBonCessionDetails>();
        }

        public int NumBonCession { get; set; }
        public DateTime DateBonCession { get; set; }
        public int NumBonProduction { get; set; }
        public DateTime DateBonProduction { get; set; }
        public int? IdResponsableQualite { get; set; }
        public int? IdResponsableProduction { get; set; }
        public int? IdResponsableStock { get; set; }

        public virtual ICollection<QualiteBonCessionDetails> QualiteBonCessionDetails { get; set; }
    }
}
