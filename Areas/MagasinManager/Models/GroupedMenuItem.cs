using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevKbfSteel.Areas.MagasinManager.Models
{
    public class GroupedMenuItem 
    {
        public string Key { get; set; }
        public List<MenuItem> Items { get; set; }
    }
}
