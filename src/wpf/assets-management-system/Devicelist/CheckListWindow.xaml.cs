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
    /// Interaction logic for CheckListWindow.xaml
    /// </summary>
    public partial class CheckListWindow : Window
    {
        public IList<CheckList> checkLists { get; set; }
        public CheckListWindow()
        {
            InitializeComponent();
            FetchCheck();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        void FetchCheck()
        {
            string data = HTTPClientHandler.GetJsonData(API_config.enpoint_uri + "check/list");

            try
            {
                checkLists = JsonConvert.DeserializeObject<IList<CheckList>>(data);
                lvCheckList.ItemsSource = checkLists;

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
            int id = ((CheckList)lvCheckList.SelectedItem).id;
            CheckListDetail checkListDetail = new CheckListDetail(id);
            checkListDetail.ShowDialog();
        }
    }
}
