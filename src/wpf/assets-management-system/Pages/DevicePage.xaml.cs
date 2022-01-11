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
       
        private void NewContract_Click(object sender, RoutedEventArgs e)
        {
            NewContractWindow newContractWindow = new NewContractWindow();
            newContractWindow.Closed += new EventHandler((e, args) => FetchDevices());
            newContractWindow.ShowDialog();
        }

        private void Transfer_Click(object sender, RoutedEventArgs e)
        {
            int id = ((Division)cbDividion.SelectedItem).id;
            TransferWindow transferWindow = new TransferWindow(id);
            transferWindow.Closed += new EventHandler((e, args) => FetchDevices());
            transferWindow.ShowDialog();
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
                    //MessageBox.Show(errorMessage.message);

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
                    //MessageBox.Show(errorMessage.message);

                }
                else
                {
                    MessageBox.Show("Unable to connect to the server");
                }
            }
           
        }

        private void listview_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {   
            if(lvDevice.SelectedItems.Count != 0)
            {
                int id = ((Device)lvDevice.SelectedItem).id;
                DeviceDetailWindow deviceDetailWindow = new DeviceDetailWindow(id);
                deviceDetailWindow.ShowDialog();
            }
            
        }

        private void Check_Click(object sender, RoutedEventArgs e)
        {
            CheckWindow checkWindow = new CheckWindow();
            checkWindow.Closed += new EventHandler((e, args) => FetchDevices());
            checkWindow.ShowDialog();
        }
    }
}
