using assets_management_system.data_classes;
using Newtonsoft.Json;
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

namespace assets_management_system.Statictis
{
    /// <summary>
    /// Interaction logic for StatictisRepairPrice.xaml
    /// </summary>
    public partial class StatictisRepairPrice : Window
    {
        public IList<RepairPrice> repairPrices { get; set; }
        public StatictisRepairPrice()
        {
            InitializeComponent();
            string data = HTTPClientHandler.GetJsonData(API_config.enpoint_uri + "statistic/year_price");
            try
            {
                repairPrices = JsonConvert.DeserializeObject<IList<RepairPrice>>(data);
                chartRepair.ItemsSource = repairPrices;

            }
            catch
            {
                if (data != null)
                {
                    Message errorMessage = JsonConvert.DeserializeObject<Message>(data);
                    //MessageBox.Show(errorMessage.message);

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
