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

namespace assets_management_system
{
    /// <summary>
    /// Interaction logic for DevicesWindow.xaml
    /// </summary>
    public partial class DevicesWindow : Window
    {
        public DevicesWindow()
        {
            InitializeComponent();
        }
        private void AddDeviceClicked(object sender, RoutedEventArgs e)
        {
            AddDevicesWindow addDevicesWindow = new AddDevicesWindow();
            addDevicesWindow.ShowDialog();
        }
    }
}
