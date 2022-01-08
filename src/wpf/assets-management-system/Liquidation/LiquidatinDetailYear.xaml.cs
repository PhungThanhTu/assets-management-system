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

namespace assets_management_system.Liquidation
{
    /// <summary>
    /// Interaction logic for LiquidatinDetailYear.xaml
    /// </summary>
    public partial class LiquidatinDetailYear : Window
    {
        public string year { get; set; }
        public IList<LiquidationDetail> liquidationDetails { get; set; }
        public LiquidatinDetailYear(string year)
        {
            InitializeComponent();
            this.year = year;
            string Data = HTTPClientHandler.GetJsonData(API_config.enpoint_uri + "liquidation/" + year);
            try
            {
                liquidationDetails = JsonConvert.DeserializeObject<IList<LiquidationDetail>>(Data);
                lvInventoryDetail.ItemsSource = liquidationDetails;

            }
            catch
            {
                if (Data != null)
                {
                    Message errorMessage = JsonConvert.DeserializeObject<Message>(Data);
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
