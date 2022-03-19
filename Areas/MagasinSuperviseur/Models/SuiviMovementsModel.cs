using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevKbfSteel.Areas.MagasinSuperviseur.Models
{
    public class SuiviMovementsModel : Entities.StkMovements
    {
        public int NumBon { get; set; }
        public String Gisement { get; set; }
        public String? UniteMesure { get; set; }
    }
}
