using System;
using System.Collections.Generic;

namespace DevKbfSteel.Entities
{
    public partial class PeriodeProduction
    {
        public PeriodeProduction()
        {
            OrdreProduction = new HashSet<OrdreProduction>();
        }

        public string DesignationPeriode { get; set; }

        public virtual ICollection<OrdreProduction> OrdreProduction { get; set; }
    }
}
