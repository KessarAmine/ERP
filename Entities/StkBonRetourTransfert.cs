using System;
using System.Collections.Generic;

namespace DevKbfSteel.Entities
{
    public partial class StkBonRetourTransfert
    {
        public int NumBonRetourTransfert { get; set; }
        public int NumBonTransfert { get; set; }
        public DateTime DateRetour { get; set; }
        public string Source { get; set; }
        public string Chauffeur { get; set; }
        public int Matricule { get; set; }
        public string Npc { get; set; }
    }
}
