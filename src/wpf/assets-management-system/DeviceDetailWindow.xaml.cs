using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using assets_management_system.data_classes;
using Newtonsoft.Json;

namespace assets_management_system
{
    /// <summary>
    /// Interaction logic for DeviceDetailWindow.xaml
    /// </summary>
    public partial class DeviceDetailWindow : Window
    {
        public int id { get; set; }
        public DeviceDetail detail;
        public DeviceDetailWindow(int id)
        {
            InitializeComponent();
            this.id = id;
            detail = new DeviceDetail();
            string data = HTTPClientHandler.GetJsonData(API_config.enpoint_uri + "device/detail/" + id);
            try
            {
                detail = JsonConvert.DeserializeObject<DeviceDetail>(data);

                name.Text = detail.name;
            }
            catch
            {
                MessageBox.Show(data);
            }
        }
    }
}
