using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevKbfSteel.Models
{
    public class DashboardCagesInterventionsMethodes
    {
        public string NomCage { get; set; }
        public int NombreInterventionsMecanique { get; set; }
        public int NombreInterventionsElectrique { get; set; }
        public Double DureeInterventionsMecanique { get; set; }
        public Double DureeInterventionsElectrique { get; set; }
    }
}
