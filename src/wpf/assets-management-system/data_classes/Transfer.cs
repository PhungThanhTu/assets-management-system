using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assets_management_system.data_classes
{
    public class PostTransfer
    {
        public int sender{ get; set; }
        public int receiver { get; set; }
        public string transfer_date { get; set; }
    }
    
    public class PostIDDevice
    {
        public int id;
    }
    public class TransferList
    {
        public int id { get; set; }
        public string sender_name { get; set; }
        public string receiver_name { get; set; }
        public string transfer_date { get; set; }
    }
}
