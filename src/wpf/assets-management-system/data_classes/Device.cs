using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assets_management_system.data_classes
{
    public class Device
    {
        public int id { get; set; }
        public string name { get; set; }
		public int price { get; set; }
		public string specification { get; set; }
		public int production_year { get; set; }
		public int implement_year { get; set; }
		public string status { get; set; }
		public float annual_value_lost { get; set; }
		public int contract_id { get; set; }

		public int unit { get; set; }
		public int type { get; set; }
		public int current_value { get; set; }

		public int holding_division { get; set; }
		
    }

	public class PostDevice
	{
		public string name { get; set; }
		public int price { get; set; }
		public string specification { get; set; }
		public int production_year { get; set; }
		public int implement_year { get; set; }
		public string status { get; set; }
		public float annual_value_lost { get; set; }
		public int contract_id { get; set; }

		public int unit { get; set; }
		public int type { get; set; }
		public int current_value { get; set; }

		public int holding_division { get; set; }

	}
}
