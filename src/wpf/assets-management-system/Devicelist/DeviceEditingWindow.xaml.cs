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
    /// Interaction logic for DeviceEditingWindow.xaml
    /// </summary>
    public partial class DeviceEditingWindow : Window
    {
        public PostDevice device { get; set; }
        public int index { get; set; }

        public IList<DeviceType> types { get; set; }
        public IList<DeviceUnit> units { get; set; }

        public delegate void EditDeviceDelegate(PostDevice device, int index);
        public EditDeviceDelegate editDelegate;
        

        public DeviceEditingWindow(PostDevice device,int index)
        {
            InitializeComponent();
            this.device = device;
            this.index = index;

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

            #region display data
            txtboxName.Text = device.name;
            txtboxSpecification.Text = device.specification;
            txtboxPrice.Text = device.price.ToString();
            txtboxProcYear.Text = device.production_year.ToString();
            txtboxImpYear.Text = device.implement_year.ToString();
            txtboxAnnualValueLost.Text = device.annual_value_lost.ToString();
            txtboxCurentValue.Text = device.current_value.ToString();
            // bugs need to be fixed
            cbStatus.SelectedItem = cbStatus.Items.OfType<Label>().Any(item => item.Content.ToString() == device.status);

            cbType.SelectedItem = ((List<DeviceType>)types).Find(item => item.id == device.type);
            cbUnit.SelectedItem = ((List<DeviceUnit>)units).Find(item => item.id == device.unit);

            cbType.SelectedValue = device.type;
            cbUnit.SelectedValue = device.unit;
            #endregion
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            if (txtboxName.Text.Length == 0 || txtboxSpecification.Text.Length == 0 || txtboxPrice.Text.Length == 0
               || txtboxAnnualValueLost.Text.Length == 0 || txtboxCurentValue.Text.Length == 0 || txtboxImpYear.Text.Length == 0
               || txtboxProcYear.Text.Length == 0 || cbStatus.Text.Length == 0 || cbType.Text.Length == 0 || cbUnit.Text.Length == 0)
            {
                MessageBox.Show("Please enter full information!", "Notification", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            else
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

                editDelegate(this.device, this.index);
                this.Close();
            }

        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
