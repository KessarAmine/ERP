using System;
using System.Collections.Generic;

namespace DevKbfSteel.Entities
{
    public partial class TypeMaintenance
    {
        public TypeMaintenance()
        {
            OrdreTravail = new HashSet<OrdreTravail>();
        }

        public bool CodeMaintenance { get; set; }
        public string DesignationMaintenance { get; set; }

        public virtual ICollection<OrdreTravail> OrdreTravail { get; set; }
    }
}
