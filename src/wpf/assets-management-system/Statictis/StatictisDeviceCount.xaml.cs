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

namespace assets_management_system.Statictis
{
    /// <summary>
    /// Interaction logic for StatictisDeviceCount.xaml
    /// </summary>
    public partial class StatictisDeviceCount : Window
    {
        public IList<Division> divisions { get; set; }
        public IList<DeviceCount> device_count { get; set; }
        public StatictisDeviceCount()
        {
            InitializeComponent();
            FetchDivision();
            cbDividion.SelectedIndex = 0;
        }
        private void Combobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            StatictisDevice();
        }
        void StatictisDevice()
        {
            string data = HTTPClientHandler.GetJsonData(API_config.enpoint_uri + "statistic/device_count/" + cbDividion.SelectedValue);

            try
            {
                device_count = JsonConvert.DeserializeObject<IList<DeviceCount>>(data);
                chartDevice.ItemsSource = device_count;

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
        void FetchDivision()
        {
            string data = HTTPClientHandler.GetJsonData(API_config.enpoint_uri + "division");

            try
            {

                divisions = JsonConvert.DeserializeObject<IList<Division>>(data);
                cbDividion.DisplayMemberPath = "name";
                cbDividion.SelectedValuePath = "id";
                cbDividion.ItemsSource = divisions;

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
