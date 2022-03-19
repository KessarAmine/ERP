using System;
using System.Collections.Generic;

namespace DevKbfSteel.Entities
{
    public partial class Compositions
    {
        public Compositions()
        {
            MachineEquioement = new HashSet<MachineEquioement>();
        }

        public string NumComposition { get; set; }
        public string NomComposition { get; set; }

        public virtual ICollection<MachineEquioement> MachineEquioement { get; set; }
    }
}
