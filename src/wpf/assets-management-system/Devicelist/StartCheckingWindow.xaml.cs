using System;
using System.Collections.Generic;
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

namespace assets_management_system
{
    /// <summary>
    /// Interaction logic for StartCheckingWindow.xaml
    /// </summary>
    public partial class StartCheckingWindow : Window
    {
        public DataRowView rowView;
        public IList<PostDevice> devices { get; set; }
        public PostCheck nCheck { get; set; }
        public IList<PostDetail> nDetail { get; set; }
        public IList<CheckDetail> ncheckDetails { get; set; }
        public CheckHeader check_header { get; set; }

        public StartCheckingWindow(IList<CheckDetail> checkDetails)
        {
            InitializeComponent();
            this.ncheckDetails = checkDetails;
            devices = new List<PostDevice>();
            lvDevice_Check.ItemsSource = ncheckDetails;
        }

        
        private void DataGridRow_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            DataGridRow selectedRow = (DataGridRow)sender;
            selectedRow.IsSelected = true;
            rowView = lvDevice_Check.SelectedItem as DataRowView;
        }
        private void CheckStatus_Click(object sender, RoutedEventArgs e)
        {
            if(lvDevice_Check.SelectedItems.Count==0)
            {
                MessageBox.Show("Please add data to checkstatus!", "Notification", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }    
            else
            {
                int selectedIndex = lvDevice_Check.SelectedIndex;
                PostDevice inputDevice = devices[selectedIndex];
                DeviceEditingWindow deviceEditingWindow = new DeviceEditingWindow(inputDevice, selectedIndex);
                deviceEditingWindow.editDelegate = EditDevice;
                deviceEditingWindow.ShowDialog();
            }

        }
        public void EditDevice(PostDevice device, int index)
        {
            devices[index] = device;
            lvDevice_Check.ItemsSource = null;
            lvDevice_Check.ItemsSource = devices;
        }

        private void Checking_Click(object sender, RoutedEventArgs e)
        {
            if (dpCheck.Text.Length == 0)
            {
                MessageBox.Show("Please enter full information!", "Notification", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            else
            {
                nCheck = new PostCheck()
                {
                    check_date = dpCheck.SelectedDate.Value.ToString("yyyy-MM-dd")
                };

                // set up postdetail
                PostDetail nCheckDetail = new PostDetail();
                {

                };
                // set up postcheck
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
    }
}
