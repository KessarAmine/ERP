using System;
using System.Collections.Generic;

namespace DevKbfSteel.Entities
{
    public partial class TrackingOperations
    {
        public int Id { get; set; }
        public string MaccAdress { get; set; }
        public string IpAdress { get; set; }
        public string Operation { get; set; }
        public DateTime DateOperation { get; set; }
    }
}
