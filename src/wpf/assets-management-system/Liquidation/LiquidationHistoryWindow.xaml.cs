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
    /// Interaction logic for LiquidationHistoryWindow.xaml
    /// </summary>
    public partial class LiquidationHistoryWindow : Window
    {
        public IList<LiquidationList> liquidationLists { get; set; }
        public LiquidationHistoryWindow()
        {
            InitializeComponent();
            string data = HTTPClientHandler.GetJsonData(API_config.enpoint_uri + "liquidation/list");

            try
            {
                liquidationLists = JsonConvert.DeserializeObject<IList<LiquidationList>>(data);
                lvLiquidation.ItemsSource = liquidationLists;
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

        private void Show_Click(object sender, RoutedEventArgs e)
        {

        }
        private void listview_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            int id = ((LiquidationList)lvLiquidation.SelectedItem).id;
            LiquidationDetailWindow liquidationDetail = new LiquidationDetailWindow(id);
            liquidationDetail.ShowDialog();
        }
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
