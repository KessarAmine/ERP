using System;
using System.Collections.Generic;

namespace DevKbfSteel.Entities
{
    public partial class TempAssOtTravaux
    {
        public int Id { get; set; }
        public int? TypeTraveaux { get; set; }
        public int? CodeEquipement { get; set; }
        public int CodeMachine { get; set; }
        public int? Qte { get; set; }
        public string Autres { get; set; }
    }
}
