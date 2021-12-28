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
    /// Interaction logic for TransferWindow.xaml
    /// </summary>
    public partial class TransferWindow : Window
    {
        public IList<Division> divisions { get; set; }
        public IList<Device> devices { get; set; }
        public TransferWindow()
        {
            InitializeComponent();
        }
        public void Window_Loaded(object sender, RoutedEventArgs e)
        {
            divisions = JsonConvert.DeserializeObject<IList<Division>>(HTTPClientHandler.GetJsonData("https://evening-mountain-03563.herokuapp.com/division"));
            cbDivision.ItemsSource = divisions;
            cbDivision.DisplayMemberPath = "name";
            devices = JsonConvert.DeserializeObject<IList<Device>>(HTTPClientHandler.GetJsonData("https://evening-mountain-03563.herokuapp.com/device/query?division=1"));
            lvDevice.ItemsSource = devices;
        }
    }
}
