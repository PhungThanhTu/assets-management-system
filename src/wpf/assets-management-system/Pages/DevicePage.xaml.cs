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
using System.Windows.Navigation;
using System.Windows.Shapes;
using assets_management_system.data_classes;
using assets_management_system.Page;
using Newtonsoft.Json;

namespace assets_management_system.Pages
{
    /// <summary>
    /// Interaction logic for DevicePage.xaml
    /// </summary>
    public partial class DevicePage : System.Windows.Controls.Page
    {
        
        public IList<Division> divisions { get; set; }
        public IList<Device> devices { get; set; }
        public DevicePage()
        {
            InitializeComponent();
            FetchDivision();
            cbDividion.SelectedIndex = 0;

        }
        private void Combobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            FetchDevices();
        }
        private void Contract_Click(object sender, RoutedEventArgs e)
        {
            ContractWindow contractWindow = new ContractWindow();
            contractWindow.ShowDialog(); 
        }

        private void NewContract_Click(object sender, RoutedEventArgs e)
        {
            NewContractWindow newContractWindow = new NewContractWindow();
            newContractWindow.ShowDialog();
        }

        private void Transfer_Click(object sender, RoutedEventArgs e)
        {
            TransferWindow transferWindow = new TransferWindow();
            transferWindow.ShowDialog();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        void FetchDevices()
        {
            string data = HTTPClientHandler.GetJsonData(API_config.enpoint_uri + "device/query?division=" + cbDividion.SelectedValue);

            try
            {
                devices = JsonConvert.DeserializeObject<IList<Device>>(data);
                lvDevice.ItemsSource = devices;

            }
            catch
            {
                if (data != null)
                {
                    Message errorMessage = JsonConvert.DeserializeObject<Message>(data);
                    MessageBox.Show(errorMessage.message);

                }
                else
                {
                    MessageBox.Show("Unable to connect to the server");
                }
            }

        }

        void FetchDivision()
        {
            string data = HTTPClientHandler.GetJsonData(API_config.enpoint_uri + "division");

            try
            {
  
                divisions = JsonConvert.DeserializeObject<IList<Division>>(data); 
                cbDividion.DisplayMemberPath = "name";
                cbDividion.SelectedValuePath = "id";
                cbDividion.ItemsSource = divisions;

            }
            catch
            {
                if (data != null)
                {
                    Message errorMessage = JsonConvert.DeserializeObject<Message>(data);
                    MessageBox.Show(errorMessage.message);

                }
                else
                {
                    MessageBox.Show("Unable to connect to the server");
                }
            }
           
        }

        private void listview_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            int id = ((Device)lvDevice.SelectedItem).id;
            MessageBox.Show(id.ToString());
            
            DeviceDetailWindow deviceDetailWindow = new DeviceDetailWindow(id);
            deviceDetailWindow.ShowDialog();
            
        }
    }
}
