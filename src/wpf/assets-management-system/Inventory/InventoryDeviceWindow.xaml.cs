using System;
using System.Collections.Generic;
using System.Data;
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

namespace assets_management_system.Inventory
{
    /// <summary>
    /// Interaction logic for InventoryDeviceWindow.xaml
    /// </summary>
    public partial class InventoryDeviceWindow : Window
    {
        private DataRowView rowView;
        public IList<Personnel> personnels;
        public IList<Device> devices { get; set; }
        public IList<Personnel> npersonnels { get; set; }
        public IList<CheckDetail> nDetail { get; set; }

        public PostCheck nCheckDate { get; set; }
        public InventoryHeader inventory_header { get; set; }
        public CheckHeader ncheck_detail { get; set; }
       
        public InventoryDeviceWindow(IList<Personnel> personnels )
        {
            InitializeComponent();
            FetchDevices();
            this.personnels = personnels;
        }

        private void CheckStatus_Click(object sender, RoutedEventArgs e)
        {
            if (lvInventory.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please add data to checkstatus!", "Notification", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            else
            {
                int selectedIndex = lvInventory.SelectedIndex;
                Device inputCheck = (Device)lvInventory.SelectedItem;
                EditStatusInventoryWindow editStatusInventoryWindow = new EditStatusInventoryWindow(inputCheck, selectedIndex);
                editStatusInventoryWindow.editDelegate = EditInventoryDevice;
                editStatusInventoryWindow.ShowDialog();
            }
        }
        public void EditInventoryDevice(Device device, int index)
        {
            devices[index] = device;
            lvInventory.ItemsSource = null;
            lvInventory.ItemsSource = devices;
        }

        private void FinishInventory_Click(object sender, RoutedEventArgs e)
        {
            nDetail = new List<CheckDetail>();
            nDetail.Clear();
            foreach (Device device in lvInventory.Items)
            {
                CheckDetail newSelectedDevice = new CheckDetail();
                newSelectedDevice.id = device.id;
                newSelectedDevice.name = device.name.ToString();
                newSelectedDevice.current_value = device.current_value;
                newSelectedDevice.status = device.status.ToString();
                newSelectedDevice.division = device.holding_division;
                nDetail.Add(newSelectedDevice);
            }
            if (dpInventory.Text.Length == 0)
            {
                MessageBox.Show("Please enter full information!", "Notification", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            else
            {
                nCheckDate = new PostCheck()
                {
                    check_date = dpInventory.SelectedDate.Value.ToString("yyyy-MM-dd"),
                };


                ncheck_detail = new CheckHeader()

                {
                    check = nCheckDate,
                    detail = nDetail

                };

                inventory_header = new InventoryHeader
                {
                    personnel = personnels,
                    check_detail = ncheck_detail

                };

                try
                {
                    string result = HTTPClientHandler.PostJsonData(API_config.enpoint_uri + "inventory/add", inventory_header);
                    //MessageBox.Show(result);
                }
                catch
                {
                    MessageBox.Show("Connection Error");
                }
                this.Close();

            }
        }

        private void DataGridRow_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            DataGridRow selectedRow = (DataGridRow)sender;
            selectedRow.IsSelected = true;
            rowView = lvInventory.SelectedItem as DataRowView;
        }

        void FetchDevices()
        {
            string data = HTTPClientHandler.GetJsonData(API_config.enpoint_uri + "device/list");

            try
            {
                devices = JsonConvert.DeserializeObject<IList<Device>>(data);
                lvInventory.ItemsSource = devices;

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

    }
}
