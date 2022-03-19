using System;
using System.Collections.Generic;

namespace DevKbfSteel.Entities
{
    public partial class PrjTasks
    {
        public int Id { get; set; }
        public int ParentId { get; set; }
        public string Title { get; set; }
        public DateTime Start { get; set; }
        public DateTime EndDate { get; set; }
        public int Progress { get; set; }
    }
}
