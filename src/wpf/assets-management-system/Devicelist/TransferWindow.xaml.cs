using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Data;
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
using assets_management_system.Devicelist;

namespace assets_management_system.Page
{
    /// <summary>
    /// Interaction logic for TransferWindow.xaml
    /// </summary>
    public partial class TransferWindow : Window
    {
        public int id { get; set; }
        public string name { get; set; }
        public Device device;
        

        public IList<Division> divisions { get; set; }
        public IList<Device> devices { get; set; }
        public PostTransfer nTransfer { get; set; }
        public IList<PostIDDevice> iDDevices { get; set; }

        public TransferHeader transfer_header { get; set; }
    
        public TransferWindow(int id)
        {
            InitializeComponent();
            divisions = JsonConvert.DeserializeObject<IList<Division>>(HTTPClientHandler.GetJsonData(API_config.enpoint_uri + "division"));
            cbDivision.ItemsSource = divisions;
            cbDivision.DisplayMemberPath = "name";
            cbDivision.SelectedValuePath = "id";
            this.id = id;
            device = new Device();
            string data = HTTPClientHandler.GetJsonData(API_config.enpoint_uri + "device/query?division=" + id);
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

        

        private void ListTransfer_Click(object sender, RoutedEventArgs e)
        {
            ListTransferWindow listTransferWindow = new ListTransferWindow();
            listTransferWindow.Show();
        }

        private void Transfer_Click(object sender, RoutedEventArgs e)
        {   
            iDDevices = new List<PostIDDevice>();
            iDDevices.Clear();

            if (cbDivision.Text.Length == 0 || dpTransfer.Text.Length == 0)
            {
                MessageBox.Show("Please enter full information!", "Notification", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            else
            {
                nTransfer = new PostTransfer()
                {
                    sender = this.id,
                    receiver = int.Parse(cbDivision.SelectedValue.ToString()),
                    transfer_date = dpTransfer.SelectedDate.Value.ToString("yyyy-MM-dd")
                };

                // set up post device id
                foreach (Device device in lvDevice.SelectedItems)
                {
                    PostIDDevice newSelectedDevice = new PostIDDevice();
                    newSelectedDevice.id = device.id;

                    iDDevices.Add(newSelectedDevice);
                }
                // set up transfer
                transfer_header = new TransferHeader
                {
                    devices = iDDevices,
                    transfer = nTransfer
                };

                try
                {
                    string result = HTTPClientHandler.PostJsonData(API_config.enpoint_uri + "transfer/add", transfer_header);
                    MessageBox.Show(result);
                }
                catch
                {
                    MessageBox.Show("Connection Error");
                }
            }
        }
    }
}
