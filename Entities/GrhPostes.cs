using System;
using System.Collections.Generic;

namespace DevKbfSteel.Entities
{
    public partial class GrhPostes
    {
        public int CodePoste { get; set; }
        public string Intitule { get; set; }
        public string IntituleArabe { get; set; }
        public int? EffectifRequis { get; set; }
        public double? SalaireBase { get; set; }
        public int? CodeDepartement { get; set; }
    }
}
