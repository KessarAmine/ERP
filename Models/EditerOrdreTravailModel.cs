using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevKbfSteel.Entities;
namespace DevKbfSteel.Models
{
    public class EditerOrdreTravailModel
    {
        //Ordre de travail
        public int NumOt { get; set; }
        public int? NumDt { get; set; }
        public int? CodeMaintenance { get; set; }
        public DateTime DateOt { get; set; }
        public DateTime? HeureInstallation { get; set; }
        public int? CodeMachine { get; set; }
        public int? NumEquipement { get; set; }
        public int? CodeReceveur { get; set; }

        //outils
        public List<AssOtOutils> ListOutillage { get; set; }
        public List<TempAssOtTravaux> ListTravaux { get; set; }


    }
}
