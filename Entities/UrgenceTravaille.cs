using System;
using System.Collections.Generic;

namespace DevKbfSteel.Entities
{
    public partial class UrgenceTravaille
    {
        public UrgenceTravaille()
        {
            DemandeTravail = new HashSet<DemandeTravail>();
        }

        public bool CodeUrgence { get; set; }
        public string DesignationUrgence { get; set; }

        public virtual ICollection<DemandeTravail> DemandeTravail { get; set; }
    }
}
