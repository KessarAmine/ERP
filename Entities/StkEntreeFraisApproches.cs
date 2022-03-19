using System;
using System.Collections.Generic;

namespace DevKbfSteel.Entities
{
    public partial class StkEntreeFraisApproches
    {
        public int Id { get; set; }
        public int NumBonEntree { get; set; }
        public int CodeFrais { get; set; }
        public double ValeurFrais { get; set; }
        public int? CodeArticle { get; set; }
        public int? NumFacture { get; set; }
        public double? MontantDevise { get; set; }
    }
}
