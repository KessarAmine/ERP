using System;
using System.Collections.Generic;

namespace DevKbfSteel.Entities
{
    public partial class ApproDemandeAchats
    {
        public ApproDemandeAchats()
        {
            ApproArticlesDemandes = new HashSet<ApproArticlesDemandes>();
        }

        public int NumDemandeAchat { get; set; }
        public int CodeServiceDemandeur { get; set; }
        public DateTime DateDemandeAchat { get; set; }
        public string StatutDemandeAchat { get; set; }
        public int? CodeNatureDemandeAchat { get; set; }
        public string MotifDemandeAchat { get; set; }
        public int? NumDemandeFourniture { get; set; }
        public bool? UrgenceDemande { get; set; }

        public virtual ApproServicesDemandeurs CodeServiceDemandeurNavigation { get; set; }
        public virtual ApproStatut StatutDemandeAchatNavigation { get; set; }
        public virtual ICollection<ApproArticlesDemandes> ApproArticlesDemandes { get; set; }
    }
}
