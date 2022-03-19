using System;
using System.Collections.Generic;

namespace DevKbfSteel.Entities
{
    public partial class QualiteEssaisMecanique
    {
        public QualiteEssaisMecanique()
        {
            QualiteEssaisMecaniqueDetails = new HashSet<QualiteEssaisMecaniqueDetails>();
        }

        public int NumEssai { get; set; }
        public DateTime DateEssaie { get; set; }
        public int Poste { get; set; }
        public int IdControleur { get; set; }
        public string Commentaire { get; set; }

        public virtual ICollection<QualiteEssaisMecaniqueDetails> QualiteEssaisMecaniqueDetails { get; set; }
    }
}
