using System;
using System.Collections.Generic;

namespace DevKbfSteel.Entities
{
    public partial class ProdArretsProgrammeArrets
    {
        public int Id { get; set; }
        public DateTime DateArret { get; set; }
        public DateTime HeureDebut { get; set; }
        public DateTime HeureFin { get; set; }
        public string Description { get; set; }
    }
}
