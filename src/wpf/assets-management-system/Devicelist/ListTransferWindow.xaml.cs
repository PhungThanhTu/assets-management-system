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
    /// Interaction logic for ListTransferWindow.xaml
    /// </summary>
    public partial class ListTransferWindow : Window
    {
        public IList<TransferList> transfers { get; set; }
        public ListTransferWindow()
        {
            InitializeComponent();
            FetchTransfer();
            
        }
        void FetchTransfer()
        {
            string data = HTTPClientHandler.GetJsonData(API_config.enpoint_uri + "transfer/list");

            try
            {
                transfers = JsonConvert.DeserializeObject<IList<TransferList>>(data);
                lvTransfer.ItemsSource = transfers;

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
        private void listview_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            int id = ((TransferList)lvTransfer.SelectedItem).id;
            TransferDetailWindow transferDetailWindow = new TransferDetailWindow(id);
            transferDetailWindow.ShowDialog();
        }
    }
}
