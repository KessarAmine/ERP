using System;
using System.Collections.Generic;

namespace DevKbfSteel.Entities
{
    public partial class ProdTachesArretsProgrammes
    {
        public int Id { get; set; }
        public DateTime DateArret { get; set; }
        public string Description { get; set; }
        public int? Etat { get; set; }
    }
}
