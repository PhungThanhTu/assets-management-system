using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assets_management_system.data_classes
{
    public class PostTransfer
    {
        public string sender_name { get; set; }
        public string receiver_name { get; set; }
        public string transfer_date { get; set; }
    }
    
    public class PostIDDevice
    {
        public int id;
    }
    public class TransferDetail
    {
        public int id { get; set; }
        public string name { get; set; }
        public string specification { get; set; }
        public int price { get; set; }
    }
}
