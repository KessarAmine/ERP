using System;
using System.Collections.Generic;

namespace DevKbfSteel.Entities
{
    public partial class AssOtTraveaux
    {
        public int Id { get; set; }
        public int NumOt { get; set; }
        public int? TypeTraveaux { get; set; }
        public string CodeEquipement { get; set; }
        public int? CodeMachine { get; set; }
        public int? Qte { get; set; }
        public string Autres { get; set; }
    }
}
