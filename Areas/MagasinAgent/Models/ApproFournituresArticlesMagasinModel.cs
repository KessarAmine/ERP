using System;
using System.Collections.Generic;

namespace DevKbfSteel.Areas.MagasinAgent.Models
{
    public partial class ApproFournituresArticlesMagasinModel
    {
        public int Id { get; set; }
        public int NumeroDemandeFourniture { get; set; }
        public int? CodeArticle { get; set; }
        public string DesignationArticle { get; set; }
        public double QteValable{ get; set; }
        public double QteDemande { get; set; }
        public int? CodeUniteMesure { get; set; }
    }
}
