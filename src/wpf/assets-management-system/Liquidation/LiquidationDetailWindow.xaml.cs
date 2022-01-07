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
    /// Interaction logic for LiquidationDetailWindow.xaml
    /// </summary>
    public partial class LiquidationDetailWindow : Window
    {
        public IList<LiquidationDetail> liquidationDetails { get; set; }
        public int id { get; set; }
        public LiquidationDetailWindow(int id)
        {
            InitializeComponent();
            this.id = id;
            string data = HTTPClientHandler.GetJsonData(API_config.enpoint_uri + "liquidation/devices/" + id);
            try
            {
                liquidationDetails = JsonConvert.DeserializeObject<IList<LiquidationDetail>>(data);
                lvLiquidationDetail.ItemsSource = liquidationDetails;

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
