using System;
using System.Collections.Generic;

namespace DevKbfSteel.Entities
{
    public partial class ApproStatut
    {
        public ApproStatut()
        {
            ApproDemandeAchats = new HashSet<ApproDemandeAchats>();
        }

        public string DesignationStatut { get; set; }

        public virtual ICollection<ApproDemandeAchats> ApproDemandeAchats { get; set; }
    }
}
