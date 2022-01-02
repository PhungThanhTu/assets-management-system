using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
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

namespace assets_management_system
{
    /// <summary>
    /// Interaction logic for StartCheckingWindow.xaml
    /// </summary>
    public partial class StartCheckingWindow : Window
    {
        public DataRowView rowView;
        public IList<PostDevice> devices { get; set; }
        public StartCheckingWindow()

        {
            InitializeComponent();
            devices = new List<PostDevice>();
        }
        private void DataGridRow_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            DataGridRow selectedRow = (DataGridRow)sender;
            selectedRow.IsSelected = true;
            rowView = lvDevice_Check.SelectedItem as DataRowView;
        }
        private void CheckStatus_Click(object sender, RoutedEventArgs e)
        {
            int selectedIndex = lvDevice_Check.SelectedIndex;
            PostDevice inputDevice = devices[selectedIndex];
            DeviceEditingWindow deviceEditingWindow = new DeviceEditingWindow(inputDevice, selectedIndex);
            deviceEditingWindow.editDelegate = EditDevice;
            deviceEditingWindow.ShowDialog();
        }
        public void EditDevice(PostDevice device, int index)
        {
            devices[index] = device;
            lvDevice_Check.ItemsSource = null;
            lvDevice_Check.ItemsSource = devices;
        }
    }
}
