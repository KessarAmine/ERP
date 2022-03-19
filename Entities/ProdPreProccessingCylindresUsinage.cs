using System;
using System.Collections.Generic;

namespace DevKbfSteel.Entities
{
    public partial class ProdPreProccessingCylindresUsinage
    {
        public int Id { get; set; }
        public DateTime DateChangement { get; set; }
        public string RefCylindre { get; set; }
        public int DiametreAtteint { get; set; }
        public DateTime? DateEntreeUsinage { get; set; }
        public DateTime? DateSortieUsinage { get; set; }
        public int? DiametreSortieCylindre { get; set; }
        public int EtatPreProcessing { get; set; }
    }
}
