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
        public IList<Supplier> suppliers { get; set; }
        public IList<Device> devices { get; set; }

        public AddDevicesWindow()
        {
            InitializeComponent();
            devices = new List<Device>();
            suppliers = new List<Supplier>();
            
        }
        
        public void Window_Loaded(object sender, RoutedEventArgs e)
        {
        //    suppliers = JsonConvert.DeserializeObject<IList<Supplier>>(HTTPClientHandler.GetJsonData("https://evening-mountain-03563.herokuapp.com/supplier"));
        //    cbSupplier.ItemsSource = suppliers;
        //    cbSupplier.DisplayMemberPath = "name";
        //    devices.Clear();
        //    lvDevice.ItemsSource = devices;
        }

    }
}
