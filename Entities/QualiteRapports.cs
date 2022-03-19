using System;
using System.Collections.Generic;

namespace DevKbfSteel.Entities
{
    public partial class QualiteRapports
    {
        public QualiteRapports()
        {
            QualiteRapportsDetails = new HashSet<QualiteRapportsDetails>();
        }

        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Profile { get; set; }
        public int Controleur { get; set; }

        public virtual ICollection<QualiteRapportsDetails> QualiteRapportsDetails { get; set; }
    }
}
