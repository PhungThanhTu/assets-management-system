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

namespace assets_management_system.Devicelist
{
    /// <summary>
    /// Interaction logic for CheckListDetail.xaml
    /// </summary>
    public partial class CheckListDetail : Window
    {
        public int id { get; set; }
        public IList<CheckDetail> checkDetails;
        public CheckListDetail(int id)
        {
            InitializeComponent();
            this.id = id;
            string data = HTTPClientHandler.GetJsonData(API_config.enpoint_uri + "check/id/" + id);
            try
            {
                checkDetails = JsonConvert.DeserializeObject<IList<CheckDetail>>(data);
                lvCheckDetail.ItemsSource = checkDetails;

            }
            catch
            {
                if (data != null)
                {
                    //Message errorMessage = JsonConvert.DeserializeObject<Message>(data);
                    //MessageBox.Show(errorMessage.message);
                    MessageBox.Show(data);

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
