using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevKbfSteel.Areas.MethodeManager.Models
{
    public class SuiviTravauxMachine
    {
        public DateTime DateOt { get; set; }
        public int TypeTravaux { get; set; }
        public int CodeEquipement { get; set; }
        public int NumOt { get; set; }
        public string CompteRendu { get; set; }
        public int DureeIntervention { get; set; }
        public string Autres { get; set; }
    }
}