using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assets_management_system.data_classes
{
    public class Contract
    {   
        public int id { get; set; }
        public int supplier { get; set; }
        public DateTime import_date { get; set; }
    }
}
