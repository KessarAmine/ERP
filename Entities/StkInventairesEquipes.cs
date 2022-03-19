using System;
using System.Collections.Generic;

namespace DevKbfSteel.Entities
{
    public partial class StkInventairesEquipes
    {
        public int Id { get; set; }
        public int NumInventaire { get; set; }
        public string NomEquipe { get; set; }
        public int CodeResponsable { get; set; }
    }
}
