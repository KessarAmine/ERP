using System;
using System.Collections.Generic;

namespace DevKbfSteel.Entities
{
    public partial class ArreteProduction
    {
        public ArreteProduction()
        {
            DemandeTravail = new HashSet<DemandeTravail>();
        }

        public bool CodeArret { get; set; }
        public string DesignationArret { get; set; }

        public virtual ICollection<DemandeTravail> DemandeTravail { get; set; }
    }
}
