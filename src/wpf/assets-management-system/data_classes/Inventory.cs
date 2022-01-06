using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assets_management_system.data_classes
{
    public class InventoryList
    {
        public int id { get; set; }
        public string inventory_date { get; set; }
    }
    public class InventoryDetail
    {
        public int id { get; set; }
        public string name { get; set; }
        public string division { get; set; }
        public string status { get; set; }
        public int current_value { get; set; }
    }
}
