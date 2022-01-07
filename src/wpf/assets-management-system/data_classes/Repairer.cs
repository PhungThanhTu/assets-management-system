using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assets_management_system.data_classes
{
    public class Repairer
    {
        public int id { get; set; }
        public string name { get; set; }
        public string phone { get; set; }
        public string address { get; set; }
    }
    public class PostRepairer
    {
        public string name { get; set; }
        public string phone { get; set; }
        public string address { get; set; }
    }
    public class RepairBill
    {
        public int device { get; set; }
        public int price { get; set; }
    }
    public class RepairDate
    {
        public string repair_date { get; set; }
    }
}
