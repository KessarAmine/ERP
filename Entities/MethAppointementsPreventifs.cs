using System;
using System.Collections.Generic;

namespace DevKbfSteel.Entities
{
    public partial class MethAppointementsPreventifs
    {
        public int AppointmentId { get; set; }
        public string Description { get; set; }
        public string Text { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int IdOperation { get; set; }
        public string RecurrenceRule { get; set; }
        public string RecurrenceException { get; set; }
        public int? Statut { get; set; }
    }
}
