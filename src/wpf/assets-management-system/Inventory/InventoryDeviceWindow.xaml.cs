using System;
using System.Collections.Generic;
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

namespace assets_management_system.Inventory
{
    /// <summary>
    /// Interaction logic for InventoryDeviceWindow.xaml
    /// </summary>
    public partial class InventoryDeviceWindow : Window
    {
        private DataRowView rowView;

        public InventoryDeviceWindow()
        {
            InitializeComponent();
        }

        private void CheckStatus_Click(object sender, RoutedEventArgs e)
        {
            EditStatusWindow editStatusWindow = new EditStatusWindow();
            editStatusWindow.ShowDialog();
        }

        private void FinishInventory_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DataGridRow_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            DataGridRow selectedRow = (DataGridRow)sender;
            selectedRow.IsSelected = true;
            rowView = lvInventory.SelectedItem as DataRowView;
        }
    }
}
