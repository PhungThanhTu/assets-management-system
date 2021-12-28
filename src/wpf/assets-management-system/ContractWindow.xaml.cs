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

namespace assets_management_system.Page
{
    /// <summary>
    /// Interaction logic for ContractWindow.xaml
    /// </summary>
    public partial class ContractWindow : Window
    {
        public IList<Contract> contract { get; set; }
        public IList<Device> devices { get; set; }

        public ContractWindow()
        {
            InitializeComponent();
        }

        public void Window_Loaded(object sender, RoutedEventArgs e)
        {
            contract = JsonConvert.DeserializeObject<IList<Contract>>(HTTPClientHandler.GetJsonData("https://evening-mountain-03563.herokuapp.com/contract"));
            cbContract.ItemsSource = contract;
            cbContract.DisplayMemberPath = "import_date";

            devices = JsonConvert.DeserializeObject<IList<Device>>(HTTPClientHandler.GetJsonData("https://evening-mountain-03563.herokuapp.com/device/query?contract=1"));
            lvDevice.ItemsSource = devices;
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
