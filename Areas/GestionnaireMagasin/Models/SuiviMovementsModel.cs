using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevKbfSteel.Areas.GestionnaireMagasin.Models
{
    public class SuiviMovementsModel : Entities.StkMovements
    {
        public int NumBon { get; set; }
        public int? CompteComptable { get; set; }
        public String Gisement { get; set; }
        public String? UniteMesure { get; set; }

    }
}
