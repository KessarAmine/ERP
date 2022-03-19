using System;
using System.Collections.Generic;

namespace DevKbfSteel.Entities
{
    public partial class Specialite
    {
        public Specialite()
        {
            Intervenant = new HashSet<Intervenant>();
        }

        public int CodeSpecialite { get; set; }
        public string Designation { get; set; }

        public virtual ICollection<Intervenant> Intervenant { get; set; }
    }
}
