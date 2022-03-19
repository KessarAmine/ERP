using System;
using System.Collections.Generic;

namespace DevKbfSteel.Entities
{
    public partial class ApproServicesDemandeurs
    {
        public ApproServicesDemandeurs()
        {
            ApproDemandeAchats = new HashSet<ApproDemandeAchats>();
        }

        public int CodeService { get; set; }
        public string DesignationService { get; set; }

        public virtual ICollection<ApproDemandeAchats> ApproDemandeAchats { get; set; }
    }
}
