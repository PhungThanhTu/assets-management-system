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

namespace assets_management_system.Repair
{
    /// <summary>
    /// Interaction logic for RepairListWindow.xaml
    /// </summary>
    public partial class RepairListWindow : Window
    {
        public IList<RepairList> repairLists { get; set; }
        public RepairListWindow()
        {
            InitializeComponent();
            FetchRepairBill();
        }
        void FetchRepairBill()
        {
            string data = HTTPClientHandler.GetJsonData(API_config.enpoint_uri + "repair/bill");

            try
            {
                repairLists = JsonConvert.DeserializeObject<IList<RepairList>>(data);
                lvRepairList.ItemsSource = repairLists;

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

        private void listview_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            int id = ((RepairList)lvRepairList.SelectedItem).id;
            RepairListDetail repairListDetail = new RepairListDetail(id);
            repairListDetail.ShowDialog();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
