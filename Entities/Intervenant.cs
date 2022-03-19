using System;
using System.Collections.Generic;

namespace DevKbfSteel.Entities
{
    public partial class Intervenant
    {
        public Intervenant()
        {
            BonProduction = new HashSet<BonProduction>();
            OrdreProduction = new HashSet<OrdreProduction>();
        }

        public int CodeIntervenant { get; set; }
        public string NmPr { get; set; }
        public int CodeSpecialite { get; set; }
        public int? CodeStructure { get; set; }
        public string DesignationEquipe { get; set; }

        public virtual Specialite CodeSpecialiteNavigation { get; set; }
        public virtual ICollection<BonProduction> BonProduction { get; set; }
        public virtual ICollection<OrdreProduction> OrdreProduction { get; set; }
    }
}
