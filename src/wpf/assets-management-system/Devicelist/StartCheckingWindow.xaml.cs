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

        public PostCheck nCheck { get; set; }
        public IList<CheckDetail> ncheckDetails { get; set; }
        public CheckHeader check_header { get; set; }

        public StartCheckingWindow(IList<CheckDetail> checkDetails)
        {

            InitializeComponent();
            ncheckDetails = new List<CheckDetail>();
            this.ncheckDetails = checkDetails;
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
            if (lvDevice_Check.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please add data to checkstatus!", "Notification", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            else
            {
                int selectedIndex = lvDevice_Check.SelectedIndex;
                CheckDetail inputCheck = (CheckDetail)lvDevice_Check.SelectedItem;
                EditStatusWindow editStatusWindow = new EditStatusWindow(inputCheck, selectedIndex);
                editStatusWindow.editDelegate = EditCheckDevice;
                editStatusWindow.ShowDialog();
            }

        }
        public void EditCheckDevice(CheckDetail detail, int index)
        {
            ncheckDetails[index] = detail;
            lvDevice_Check.ItemsSource = null;
            lvDevice_Check.ItemsSource = ncheckDetails;
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

                // set up postcheck
                check_header = new CheckHeader
                {
                    check = nCheck,
                    detail = ncheckDetails
                };

                try
                {
                    string result = HTTPClientHandler.PostJsonData(API_config.enpoint_uri + "check/add", check_header);
                    MessageBox.Show(result);
                }
                catch
                {
                    MessageBox.Show("Connection Error");
                }
                this.Close();
            }
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}