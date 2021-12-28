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
            divisions = JsonConvert.DeserializeObject<IList<Division>>(HTTPClientHandler.GetJsonData("https://evening-mountain-03563.herokuapp.com/division"));
            cbDividion.ItemsSource = divisions;
            cbDividion.DisplayMemberPath = "name";
            devices = JsonConvert.DeserializeObject<IList<Device>>(HTTPClientHandler.GetJsonData("https://evening-mountain-03563.herokuapp.com/device/query?division=1"));           
            lvDevice.ItemsSource = devices;
            
                 
        }
        private void Combobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            

        }

        private void Contract_Click(object sender, RoutedEventArgs e)
        {
            ContractWindow contractWindow = new ContractWindow();
            contractWindow.ShowDialog(); 
        }

        private void NewContract_Click(object sender, RoutedEventArgs e)
        {
            AddDevicesWindow addDevicesWindow = new AddDevicesWindow();
            addDevicesWindow.ShowDialog();
        }

        private void Transfer_Click(object sender, RoutedEventArgs e)
        {
            TransferWindow transferWindow = new TransferWindow();
            transferWindow.ShowDialog();
        }
    }
}
