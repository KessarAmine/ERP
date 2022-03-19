using System;
using System.Collections.Generic;

namespace DevKbfSteel.Entities
{
    public partial class ProdSuiviArretsSonalgazTrainCages
    {
        public int Id { get; set; }
        public DateTime DateArret { get; set; }
        public string Installation { get; set; }
        public DateTime HeureDebut { get; set; }
        public DateTime HerueFin { get; set; }
        public int Cisaillees { get; set; }
        public string EnumArret { get; set; }
    }
}
