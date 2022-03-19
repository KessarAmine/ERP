using System;
using System.Collections.Generic;

namespace DevKbfSteel.Entities
{
    public partial class SrkBonRetour
    {
        public int NumBonRetour { get; set; }
        public DateTime DateRetour { get; set; }
        public string CodeFournisseur { get; set; }
        public int NumBonEntree { get; set; }
        public DateTime DateLivrason { get; set; }
        public int? CodeIntervenant { get; set; }
    }
}
