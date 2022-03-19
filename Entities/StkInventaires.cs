using System;
using System.Collections.Generic;

namespace DevKbfSteel.Entities
{
    public partial class StkInventaires
    {
        public int NumInventaire { get; set; }
        public DateTime DateDebut { get; set; }
        public DateTime? DateFin { get; set; }
    }
}
