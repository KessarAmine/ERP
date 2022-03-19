using System;
using System.Collections.Generic;

namespace DevKbfSteel.Entities
{
    public partial class Structure
    {
        public Structure()
        {
            DemandeTravail = new HashSet<DemandeTravail>();
            OrdreTravail = new HashSet<OrdreTravail>();
        }

        public int CodeStructure { get; set; }
        public string Designation { get; set; }
        public string Responsable { get; set; }
        public int? CodeAtelier { get; set; }

        public virtual ICollection<DemandeTravail> DemandeTravail { get; set; }
        public virtual ICollection<OrdreTravail> OrdreTravail { get; set; }
    }
}
