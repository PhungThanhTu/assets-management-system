using assets_management_system.Pages;
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
    /// Interaction logic for AddDevicesWindow.xaml
    /// </summary>
    public partial class AddDevicesWindow : Window
    {
        public PostDevice device { get; set; }

        public IList<DeviceType> types { get; set; }
        public IList<DeviceUnit> units { get; set; }

        // delegate
        public delegate void AddDeviceDelegate(PostDevice param);

        public AddDeviceDelegate AddDevice;

        public AddDevicesWindow()
        {
            InitializeComponent();

            string TypeData = HTTPClientHandler.GetJsonData(API_config.enpoint_uri + "type");
            string UnitData = HTTPClientHandler.GetJsonData(API_config.enpoint_uri + "unit");
            try
            {
                types = new List<DeviceType>();
                units = new List<DeviceUnit>();
                // 
                types = JsonConvert.DeserializeObject<IList<DeviceType>>(TypeData);
                units = JsonConvert.DeserializeObject<IList<DeviceUnit>>(UnitData);
                //
                cbType.ItemsSource = types;
                cbType.DisplayMemberPath = "t_name";
                cbType.SelectedValuePath = "id";
                //
                cbUnit.ItemsSource = units;
                cbUnit.DisplayMemberPath = "u_name";
                cbUnit.SelectedValuePath = "id";


            }
            catch
            {
                MessageBox.Show("Connection Error");
            }

            
        }
        
        public void Window_Loaded(object sender, RoutedEventArgs e)
        {
        //    suppliers = JsonConvert.DeserializeObject<IList<Supplier>>(HTTPClientHandler.GetJsonData("https://evening-mountain-03563.herokuapp.com/supplier"));
        //    cbSupplier.ItemsSource = suppliers;
        //    cbSupplier.DisplayMemberPath = "name";
        //    devices.Clear();
        //    lvDevice.ItemsSource = devices;
        }

        private void Done_Button_Click(object sender, RoutedEventArgs e)
        {
            device = new PostDevice();
            device.name = txtboxName.Text.ToString();
            device.price = int.Parse(txtboxPrice.Text.ToString());
            device.specification = txtboxSpecification.Text.ToString();
            device.production_year = int.Parse(txtboxProcYear.Text.ToString());
            device.implement_year = int.Parse(txtboxImpYear.Text.ToString());
            device.status = cbStatus.Text;
            device.annual_value_lost = float.Parse(txtboxAnnualValueLost.Text.ToString());
            device.current_value = int.Parse(txtboxCurentValue.Text.ToString());
            device.unit = int.Parse(cbUnit.SelectedValue.ToString());
            device.type = int.Parse(cbType.SelectedValue.ToString());
            device.holding_division = 1;


            AddDevice(device);
            this.Close();
        }
    }
}
