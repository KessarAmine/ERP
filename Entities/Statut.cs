using System;
using System.Collections.Generic;

namespace DevKbfSteel.Entities
{
    public partial class Statut
    {
        public Statut()
        {
            DemandeTravail = new HashSet<DemandeTravail>();
        }

        public int CodeStatut { get; set; }
        public string Designation { get; set; }

        public virtual ICollection<DemandeTravail> DemandeTravail { get; set; }
    }
}
