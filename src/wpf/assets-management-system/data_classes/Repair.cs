using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assets_management_system.data_classes
{
    public class RepairBill
    {
        public int id { get; set; }
        public string name { get; set; }
        public int repair_price { get; set; }
    }
    public class PostRepair
    {       
        public int device { get; set; }
        public int price { get; set; }
    }
    public class RepairDate
    {
        public string repair_date { get; set; }
    }
    public class RepairList
    {
        public int id { get; set; }
        public string repairer { get; set; }
        public string repair_date { get; set; }
        public int total_bill { get; set; }
    }
    public class RepairSpoiled
    {
        public int id { get; set; }
        public string name { get; set; }
        public string specification { get; set; }
        public string status { get; set; }
    }
    public class RepairDetail
    {
        public int bill { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public string specification { get; set; }
        public int repair_price { get; set; }
    }
}
