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

namespace assets_management_system.Inventory
{
    /// <summary>
    /// Interaction logic for InventoryDetailWindow.xaml
    /// </summary>
    public partial class InventoryDetailWindow : Window
    {
        public IList<InventoryDetail> inventoryDetails { get; set; }
        public int id { get; set; }
        public InventoryDetailWindow(int id)
        {
            InitializeComponent();
            this.id = id;
            string data = HTTPClientHandler.GetJsonData(API_config.enpoint_uri + "inventory/device/" + id);
            try
            {
                inventoryDetails = JsonConvert.DeserializeObject<IList<InventoryDetail>>(data);
                lvInventoryDetail.ItemsSource = inventoryDetails;

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

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
