using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
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
    /// Interaction logic for NewContractWindow.xaml
    /// </summary>
    public partial class NewContractWindow : Window
    {
        public IList<Supplier> suppliers { get; set; }
        public IList<PostDevice> devices { get; set; }

        public ContractAndDevices contract_and_devices { get; set; }

        public PostContract ncontract { get; set; }
        public DataRowView rowView;

        public NewContractWindow()
        {
            InitializeComponent();
            devices = new List<PostDevice>();
            suppliers = new List<Supplier>();

        }

        public void Window_Loaded(object sender, RoutedEventArgs e)
        {
            suppliers = JsonConvert.DeserializeObject<IList<Supplier>>(HTTPClientHandler.GetJsonData(API_config.enpoint_uri + "supplier"));
            cbSupplier.ItemsSource = suppliers;
            cbSupplier.DisplayMemberPath = "name";
            cbSupplier.SelectedValuePath = "id";
            devices.Clear();
        }

        private void AddDevice_Click(object sender, RoutedEventArgs e)
        {
            AddDevicesWindow addDevicesWindow = new AddDevicesWindow();
            addDevicesWindow.AddDevice = AddNewDevice;
            addDevicesWindow.ShowDialog();
            
        }

        private void Done_CLick(object sender, RoutedEventArgs e)
        {
            if(cbSupplier.Text.Length==0||dpContract.Text.Length==0)
            {
                MessageBox.Show("Please enter full information!", "Notification", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            else
            {
                ncontract = new PostContract();
                ncontract.supplier = (int)cbSupplier.SelectedValue;
                ncontract.import_date = dpContract.SelectedDate.Value.ToString("yyyy-MM-dd");
                contract_and_devices = new ContractAndDevices()
                {
                    contract = ncontract,
                    devices = devices
                };

                try
                {
                    string result = HTTPClientHandler.PostJsonData(API_config.enpoint_uri + "device/add", contract_and_devices);
                    MessageBox.Show(result);
                }
                catch
                {
                    MessageBox.Show("Connection Error");
                }
            }
            
        }


        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            int selectedIndex = lvDevice_Contract.SelectedIndex;
            PostDevice inputDevice = devices[selectedIndex];
            DeviceEditingWindow deviceEditingWindow = new DeviceEditingWindow(inputDevice,selectedIndex);
            deviceEditingWindow.editDelegate = EditDevice;
            deviceEditingWindow.ShowDialog();
        }
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            int deleteIndex = lvDevice_Contract.SelectedIndex;
            devices.RemoveAt(deleteIndex);
            lvDevice_Contract.ItemsSource = null;
            lvDevice_Contract.ItemsSource = devices;
        }


        private void DataGridRow_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            DataGridRow selectedRow = (DataGridRow)sender;
            selectedRow.IsSelected = true;
            rowView = lvDevice_Contract.SelectedItem as DataRowView;
        }

        public void AddNewDevice(PostDevice param)
        {

            devices.Add(param);
            lvDevice_Contract.ItemsSource = null;
            lvDevice_Contract.ItemsSource = devices;
        }

        public void EditDevice(PostDevice device, int index)
        {
            devices[index] = device;
            lvDevice_Contract.ItemsSource = null;
            lvDevice_Contract.ItemsSource = devices;
        }

        
    }
}
