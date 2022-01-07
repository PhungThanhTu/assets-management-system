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
using assets_management_system.data_classes;
using Newtonsoft.Json;

namespace assets_management_system.Pages
{
    /// <summary>
    /// Interaction logic for InventoryPage.xaml
    /// </summary>
    public partial class InventoryPage : System.Windows.Controls.Page
    {
        public IList<InventoryList> inventories { get; set; }
        public InventoryPage()
        {
            InitializeComponent();
            FetchInventory();
        }
        void FetchInventory()
        {
            string data = HTTPClientHandler.GetJsonData(API_config.enpoint_uri + "inventory/list");

            try
            {
                inventories = JsonConvert.DeserializeObject<IList<InventoryList>>(data);
                lv_Inventory.ItemsSource = inventories;
            }
            catch
            {
                if (data != null)
                {
                    Message errorMessage = JsonConvert.DeserializeObject<Message>(data);
                    MessageBox.Show(errorMessage.message);

                }
                else
                {
                    MessageBox.Show("Unable to connect to the server");
                }
            }
        }
        private void StartInventory_Click(object sender, RoutedEventArgs e)
        {
            Establish_Inventory_CouncilWindow establish_Inventory_CouncilWindow = new Establish_Inventory_CouncilWindow();
            establish_Inventory_CouncilWindow.Closed += new EventHandler((e, args) => FetchInventory());
            establish_Inventory_CouncilWindow.Show();
        }
        private void listview_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            int id = ((InventoryList)lv_Inventory.SelectedItem).id;
            InventoryDetailWindow inventoryDetailWindow = new InventoryDetailWindow(id);
            inventoryDetailWindow.ShowDialog();
        }
    }
}
