using System;
using System.Collections.Generic;

namespace DevKbfSteel.Entities
{
    public partial class MethodeDtEnvoyee
    {
        public string NumDt { get; set; }
        public DateTime DateDt { get; set; }
        public DateTime DateDebutOp { get; set; }
        public DateTime DateFinOp { get; set; }
        public bool CodeUrgence { get; set; }
        public string TravailDemandee { get; set; }
        public string Demandeur { get; set; }
        public string ResponsableD { get; set; }
        public string Recepteur { get; set; }
        public string ResponsableR { get; set; }
        public string Etat { get; set; }
        public string DesignationArret { get; set; }
        public string NmPr { get; set; }
        public int Journee { get; set; }
        public int Semaine { get; set; }
        public string Equipement { get; set; }
        public string Note { get; set; }
        public int? DureeInterventionH { get; set; }
    }
}
