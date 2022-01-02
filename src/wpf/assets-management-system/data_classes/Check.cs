using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assets_management_system.data_classes
{
    public class CheckList
    {
        public int id { get; set; }
        public string check_date { get; set; }
    }
    public class CheckDetail
    {
        public int device { get;set; }
        public int division { get; set; }
        public string status { get; set; }
        public int current_value { get; set; }
    }
    public class PostCheck
    {
        public string check_date { get; set; }
    }
    public class PostDetail
    {
        public int id { get; set; }
        public int division { get; set; }
        public string status { get; set; }
    }
}
