using System;
using System.Collections.Generic;

namespace DevKbfSteel.Areas.MagasinManager.Models
{
    public partial class LieuPdrModel
    {
        public int CodePdr { get; set; }
        public string DesignationPdr { get; set; }
        public string ReferenceModele { get; set; }
        public float Quantite { get; set; }
    }
}
