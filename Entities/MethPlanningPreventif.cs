using System;
using System.Collections.Generic;

namespace DevKbfSteel.Entities
{
    public partial class MethPlanningPreventif
    {
        public int Id { get; set; }
        public int IdOperation { get; set; }
        public DateTime DateRealisation { get; set; }
    }
}
