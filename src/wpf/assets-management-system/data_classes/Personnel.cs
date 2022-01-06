using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assets_management_system.data_classes
{
    public class Personnel
    {
        public int id { get; set; }
        public string name { get; set; }
        public string position { get; set; }
        public string division { get; set; }
    }


    public class PostPersonnel
    {
        public string name { get; set; }
        public string position { get; set; }
        public int division { get; set; }
    }
}
