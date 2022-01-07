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
    /// Interaction logic for RepairListDetail.xaml
    /// </summary>
    public partial class RepairListDetail : Window
    {
        public int id { get; set; }
        public IList<RepairDetail> repairDetails { get; set; }
        public RepairListDetail(int id)
        {
            InitializeComponent();
            this.id = id;
            string data = HTTPClientHandler.GetJsonData(API_config.enpoint_uri + "repair/detail/" + id);
            try
            {
                repairDetails = JsonConvert.DeserializeObject<IList<RepairDetail>>(data);
                lvCheckDetail.ItemsSource = repairDetails;

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
