using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevKbfSteel.Models
{
    public class AjouterArticleFournitureModel
    {
        public int Id { get; set; }
        public int? CodeArticle { get; set; }
        public double Qte { get; set; }
        public string ArticleNonGere { get; set; }
    }
}
