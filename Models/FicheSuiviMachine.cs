using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevKbfSteel.Models
{
    public class FicheSuiviMachine
    {
        public int id { get; set; }
        public DateTime Datentervention { get; set; }
        public string ActionDetaile { get; set; }
        public int NumDt { get; set; }
        public bool TypeMaintenance { get; set; }
        public int NumOt { get; set; }
        public int CodeDemandeur { get; set; }
    }
}
