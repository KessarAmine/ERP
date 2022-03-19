using System;
using System.Collections.Generic;

namespace DevKbfSteel.Entities
{
    public partial class ProdCylindreAnomalies
    {
        public int Id { get; set; }
        public int IdChangementCylindre { get; set; }
        public string Anomalie { get; set; }
    }
}
