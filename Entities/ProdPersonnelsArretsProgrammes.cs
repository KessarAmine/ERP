using System;
using System.Collections.Generic;

namespace DevKbfSteel.Entities
{
    public partial class ProdPersonnelsArretsProgrammes
    {
        public int Id { get; set; }
        public DateTime DateArret { get; set; }
        public int CodeIntervenant { get; set; }
    }
}
