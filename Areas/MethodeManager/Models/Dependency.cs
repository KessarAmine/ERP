using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevKbfSteel.Areas.MethodeManager.Models
{
    public class Dependency
    {
        public int ID { get; set; }
        public int PredecessorId { get; set; }
        public int SuccessorId { get; set; }
        public int Type { get; set; }
    }
}
