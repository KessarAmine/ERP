using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevKbfSteel.Areas.GestionnaireMagasin.Models
{
    public class ArticlesLookupModel
    {
        public int CodePdr { get; set; }
        public string DesignationPdr { get; set; }
        public int? UniteMesure { get; set; }
        public string? Lieu { get; set; }
    }
}
