using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevKbfSteel.Areas.MagasinManager.Models;
namespace DevKbfSteel.Areas.MagasinAgent.Models
{
    public class SampleDataMenu
    {
        public static readonly IEnumerable<GroupedMenuItem> GroupedMenuItems = new[] {
            new GroupedMenuItem {
                Key = "Articles",
                Items =new List<MenuItem>()
                {
                    new MenuItem()
                    {
                        Text = "Liste Article",
                        Path = "MagasinManager/MagasinManager/ListePDR",
                        Icon = "message"
                    },
                    new MenuItem()
                    {
                        Text = "Stock Initial",
                        Path = "MagasinManager/MagasinManager/StockInitial",
                        Icon = "message"
                    }
                }
            }
        };
    }
}
