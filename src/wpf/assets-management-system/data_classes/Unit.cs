using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assets_management_system.data_classes
{
    public class DeviceUnit
    {
        public int id { get; set; }
        public string u_name { get; set; }
        public string note { get; set; }
    }
    public class DeviceType
    {
        public int id { get; set; }
        public string t_name { get; set; }
        public string note { get; set; }
    }
}
