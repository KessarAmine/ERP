using System;
using System.Collections.Generic;

namespace DevKbfSteel.Entities
{
    public partial class RhContratsEmployes
    {
        public int Id { get; set; }
        public int? IdEmployee { get; set; }
        public DateTime DateAmbouche { get; set; }
        public int Periode { get; set; }
        public int UniteRecrutement { get; set; }
        public int TypeContrat { get; set; }
        public int Etat { get; set; }
        public DateTime? DateFinAmbouche { get; set; }
    }
}
