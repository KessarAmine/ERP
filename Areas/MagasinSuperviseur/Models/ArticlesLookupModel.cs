using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevKbfSteel.Areas.MagasinSuperviseur.Models
{
    public class ArticlesLookupModel
    {
        public int CodePdr { get; set; }
        public int? UniteMesure { get; set; }
        public string DesignationPdr { get; set; }
        public string? Lieu { get; set; }
    }
}
