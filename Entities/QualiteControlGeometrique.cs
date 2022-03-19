using System;
using System.Collections.Generic;

namespace DevKbfSteel.Entities
{
    public partial class QualiteControlGeometrique
    {
        public QualiteControlGeometrique()
        {
            QualiteControlGeometriqueDetails = new HashSet<QualiteControlGeometriqueDetails>();
        }

        public int NumControl { get; set; }
        public DateTime DateControl { get; set; }
        public int PosteControl { get; set; }
        public int IdControleur { get; set; }
        public string Remarque { get; set; }

        public virtual ICollection<QualiteControlGeometriqueDetails> QualiteControlGeometriqueDetails { get; set; }
    }
}
