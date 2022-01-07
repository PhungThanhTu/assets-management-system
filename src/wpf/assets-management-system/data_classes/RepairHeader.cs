using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assets_management_system.data_classes
{
    public class RepairHeader
    {
        public int repairer;
        public string repair_date;
        public IList<PostRepair> repair_bill;
    }
}
