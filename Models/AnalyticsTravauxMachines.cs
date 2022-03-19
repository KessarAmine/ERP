using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevKbfSteel.Models
{
    public class AnalyticsTravauxMachines
    {
        public int id { get; set; }
        public string NomMachine { get; set; }
        public int NombreInterventionsElectrique { get; set; }
        public Double DureeInterventionsPréventif { get; set; }
        public Double DureeInterventionsCorrectif{ get; set; }
        public Double PourcentageDureeInterventionsPréventif { get; set; }
        public Double PourcentageDureeInterventionsCorrectif { get; set; }
        public Double PourcentageCumuleDureeInterventionsPréventif { get; set; }
        public Double PourcentageCumuleDureeInterventionsCorrectif { get; set; }
    }
}
