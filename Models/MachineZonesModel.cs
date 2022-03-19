using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevKbfSteel.Entities;
namespace DevKbfSteel.Models
{
    public class MachineZonesModel
    {
        public string name { get; set; }
        public IEnumerable<MachineModel> items { get; set; }
    }
}
