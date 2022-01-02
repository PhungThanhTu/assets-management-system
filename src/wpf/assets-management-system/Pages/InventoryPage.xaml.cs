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
using assets_management_system.Inventory;
using assets_management_system.Page;

namespace assets_management_system.Pages
{
    /// <summary>
    /// Interaction logic for InventoryPage.xaml
    /// </summary>
    public partial class InventoryPage : System.Windows.Controls.Page
    {
        public InventoryPage()
        {
            InitializeComponent();
        }

        private void StartInventory_Click(object sender, RoutedEventArgs e)
        {
            Establish_Inventory_CouncilWindow establish_Inventory_CouncilWindow = new Establish_Inventory_CouncilWindow();
            establish_Inventory_CouncilWindow.Show();
        }
    }
}
