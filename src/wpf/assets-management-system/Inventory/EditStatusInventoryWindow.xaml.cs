using assets_management_system.data_classes;
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

namespace assets_management_system.Inventory
{
    /// <summary>
    /// Interaction logic for EditStatusInventoryWindow.xaml
    /// </summary>
    public partial class EditStatusInventoryWindow : Window
    {
        public Device device { get; set; }
        public int index { get; set; }
        public delegate void EditDeviceDelegate(Device device, int index);
        public EditDeviceDelegate editDelegate;
        public EditStatusInventoryWindow(Device device, int index)
        {
            InitializeComponent();
            this.device = device;
            this.index = index;
        }

        private void EditStatus_Click(object sender, RoutedEventArgs e)
        {
            if (cbStatus.Text.Length == 0)
            {
                MessageBox.Show("Please enter full information!", "Notification", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            else
            {
                device.status = cbStatus.Text;
                editDelegate(this.device, this.index);
                this.Close();
            }
        }
    }
    
}
