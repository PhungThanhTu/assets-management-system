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

        public DivisionAndDevices division_and_devices { get; set; }
    
        public TransferWindow(int id, string name)
        {
            InitializeComponent();
            divisions = JsonConvert.DeserializeObject<IList<Division>>(HTTPClientHandler.GetJsonData(API_config.enpoint_uri + "division"));
            cbDivision.ItemsSource = divisions;
            cbDivision.DisplayMemberPath = "name";
            this.id = id;
            this.name = name;
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

        private void Done_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(id.ToString());
            if(cbDivision.Text.Length==0||dpTransfer.Text.Length==0)
            {
                MessageBox.Show("Please enter full information!", "Notification", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            else
            {
                nTransfer = new PostTransfer();
                nTransfer.sender_name = name;
                nTransfer.receiver_name = cbDivision.Text;
                //MessageBox.Show(nTransfer.receiver_name.ToString());
                nTransfer.transfer_date = dpTransfer.SelectedDate.Value.ToString("yyyy-MM-dd");
                //MessageBox.Show(nTransfer.transfer_date);
                
                //    division_and_devices = new DivisionAndDevices()
                //    {
                //        transfer = nTransfer,
                //        iDDevices = iDDevices
                //    };
                //    try
                //    {
                //        string result = HTTPClientHandler.PostJsonData(API_config.enpoint_uri + "transfer/add", division_and_devices);
                //        MessageBox.Show(result);
                //    }
                //    catch
                //    {
                //        MessageBox.Show("Connection Error");
                //    }
            }
        }
    }
}
