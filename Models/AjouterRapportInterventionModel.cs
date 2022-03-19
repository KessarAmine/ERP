using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevKbfSteel.Entities;
namespace DevKbfSteel.Models
{
    public class AjouterRapportInterventionModel
    {
        //Ordre de travail
        public int NumOt { get; set; }
        public int? NumIntervention { get; set; }
        public DateTime DateIntervention { get; set; }
        public DateTime DebutIntervention { get; set; }
        public int DureeIntervention { get; set; }
        public string Observation { get; set; }
        public string CompteRendu { get; set; }

        //outils
        public List<int> ListCodeIntervenant { get; set; }


    }
}
