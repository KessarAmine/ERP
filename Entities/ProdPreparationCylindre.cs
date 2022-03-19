using System;
using System.Collections.Generic;

namespace DevKbfSteel.Entities
{
    public partial class ProdPreparationCylindre
    {
        public int Id { get; set; }
        public int CodeMachine { get; set; }
        public int AncienDiametre { get; set; }
        public string RefAncienCylindre { get; set; }
        public int NouveauDiametre { get; set; }
        public string RefNouveauCylindre { get; set; }
        public int NumRapport { get; set; }
    }
}
