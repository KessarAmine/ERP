using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevKbfSteel.Areas.MethodeManager.Models
{
    public class Tasks
    {
        public int ID { get; set; }
        public int ParentId { get; set; }
        public string Title { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public int Progress { get; set; }
    }
}
