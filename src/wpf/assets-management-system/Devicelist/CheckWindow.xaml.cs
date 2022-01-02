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
using assets_management_system.Devicelist;
using Newtonsoft.Json;

namespace assets_management_system
{
    /// <summary>
    /// Interaction logic for CheckWindow.xaml
    /// </summary>
    public partial class CheckWindow : Window
    {
        public IList<Division> divisions { get; set; }
        public IList<Device> devices { get; set; }
        public PostCheck nCheck { get; set; }
        public IList<PostDetail> nDetail { get; set; }
        public CheckHeader check_header { get; set; }
        public Division division { get; set; }

        public CheckWindow()
        {
            InitializeComponent();
            FetchDivision();
            cbDivision.SelectedIndex = 0;
        }

        private void CheckList_Click(object sender, RoutedEventArgs e)
        {
            CheckListWindow checkListWindow = new CheckListWindow();
            checkListWindow.ShowDialog();
        }

        private void StartChecking_Click(object sender, RoutedEventArgs e)
        {
            StartCheckingWindow startCheckingWindow = new StartCheckingWindow();
            startCheckingWindow.ShowDialog();

            nDetail = new List<PostDetail>();
            nDetail.Clear();

            if ( dpTransfer.Text.Length == 0)
            {
                MessageBox.Show("Please enter full information!", "Notification", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            else
            {
                nCheck = new PostCheck()
                {                    
                    check_date = dpTransfer.SelectedDate.Value.ToString("yyyy-MM-dd")
                };

                // set up postdetail
                foreach (Device device in lvDevice_Check.SelectedItems)
                {
                    PostDetail newSelectedDevice = new PostDetail();
                    newSelectedDevice.id = device.id;
                    newSelectedDevice.division = int.Parse(cbDivision.SelectedValue.ToString());
                    newSelectedDevice.status = device.status;
                    nDetail.Add(newSelectedDevice);
                }
                // set up transfer
                check_header = new CheckHeader
                {
                    check = nCheck,
                    details = nDetail
                };

                try
                {
                    string result = HTTPClientHandler.PostJsonData(API_config.enpoint_uri + "test_api", check_header);
                    MessageBox.Show(result);                 
                }
                catch
                {
                    MessageBox.Show("Connection Error");
                }
            }
        }
        private void Combobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            FetchDevices();
        }
        void FetchDevices()
        {
            string data = HTTPClientHandler.GetJsonData(API_config.enpoint_uri + "device/query?division=" + cbDivision.SelectedValue);

            try
            {
                devices = JsonConvert.DeserializeObject<IList<Device>>(data);
                lvDevice_Check.ItemsSource = devices;

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

        void FetchDivision()
        {
            string data = HTTPClientHandler.GetJsonData(API_config.enpoint_uri + "division");

            try
            {

                divisions = JsonConvert.DeserializeObject<IList<Division>>(data);
                cbDivision.DisplayMemberPath = "name";
                cbDivision.SelectedValuePath = "id";
                cbDivision.ItemsSource = divisions;

                

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
    }
}
