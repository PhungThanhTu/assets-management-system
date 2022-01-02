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

namespace assets_management_system.Page
{
    /// <summary>
    /// Interaction logic for ContractWindow.xaml
    /// </summary>
    public partial class ContractWindow : Window
    {
        public IList<Contract> contract { get; set; }
        public IList<Device> devices { get; set; }

        public ContractWindow()
        {
            InitializeComponent();
            FetchContract();
            cbContract.SelectedIndex = 0;
        }

        public void Window_Loaded(object sender, RoutedEventArgs e)
        {
            

           
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        void FetchContract()
        {
            string data = HTTPClientHandler.GetJsonData(API_config.enpoint_uri + "contract");

            try
            {
                contract = JsonConvert.DeserializeObject<IList<Contract>>(data);
                cbContract.ItemsSource = contract;
                cbContract.DisplayMemberPath = "import_date";
                cbContract.SelectedValuePath = "id";
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

        void FetchDevices()
        {
            string data = HTTPClientHandler.GetJsonData(API_config.enpoint_uri + "device/query?contract=" + cbContract.SelectedValue);

            try
            {
                devices = JsonConvert.DeserializeObject<IList<Device>>(data);
                lvDevice.ItemsSource = devices;

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

        private void cbContract_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            FetchDevices();
        }
    }
}
