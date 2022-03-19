using System;
using System.Collections.Generic;

namespace DevKbfSteel.Entities
{
    public partial class GrhAgencesBancaire
    {
        public int Id { get; set; }
        public string NomAgence { get; set; }
        public int NatureAgence { get; set; }
        public string Localisation { get; set; }
        public int RibEntreprise { get; set; }
    }
}
