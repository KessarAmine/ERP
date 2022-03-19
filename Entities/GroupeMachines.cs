using System;
using System.Collections.Generic;

namespace DevKbfSteel.Entities
{
    public partial class GroupeMachines
    {
        public GroupeMachines()
        {
            Machines = new HashSet<Machines>();
        }

        public string NumGroupe { get; set; }
        public string NomGroupe { get; set; }
        public string DesignationGroupe { get; set; }

        public virtual ICollection<Machines> Machines { get; set; }
    }
}
