using assets_management_system.data_classes;
using Newtonsoft.Json;
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

namespace assets_management_system.Repair
{
    /// <summary>
    /// Interaction logic for InsertRepairWindow.xaml
    /// </summary>
    public partial class InsertRepairWindow : Window
    {
        public DataRowView rowView;
        public IList<Repairer> nrepairers { get; set; }

        public RepairDate nrepair_date { get; set; }
        public RepairHeader repair_header { get; set; }
        public IList<RepairBill> nrepairBills { get; set; }
        public IList<PostRepair> nrepair { get; set; }
        public InsertRepairWindow(IList<Repairer> repairers,IList<RepairBill> repairBills)
        {
            InitializeComponent();
            nrepairers = new List<Repairer>();
            this.nrepairers = repairers;
            this.nrepairBills = repairBills;
            lvDevice.ItemsSource = nrepairBills;
           
        }
        private void DataGridRow_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            DataGridRow selectedRow = (DataGridRow)sender;
            selectedRow.IsSelected = true;
            rowView = lvDevice.SelectedItem as DataRowView;
        }
        private void RepairConfirmBill_Click(object sender, RoutedEventArgs e)
        {
            nrepair = new List<PostRepair>();
            nrepair.Clear();
            foreach (RepairBill repair in lvDevice.Items)
            {
                PostRepair newSelectedDevice = new PostRepair();
                newSelectedDevice.device = repair.id;
                newSelectedDevice.price = repair.repair_price;             
                nrepair.Add(newSelectedDevice);
            }
            if (dpRepair.Text.Length == 0)
            {
                MessageBox.Show("Please enter full information!", "Notification", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            else
            {
                nrepair_date = new RepairDate()
                {
                    repair_date = dpRepair.SelectedDate.Value.ToString("yyyy-MM-dd")
                };

                // set up PostRepair
                repair_header = new RepairHeader
                {
                    repairer=nrepairers,
                    repair_date = nrepair_date,
                    repair_bill = nrepair
                };

                try
                {
                    string result = HTTPClientHandler.PostJsonData(API_config.enpoint_uri + "repair/add", repair_header);
                    MessageBox.Show(result);
                }
                catch
                {
                    MessageBox.Show("Connection Error");
                }
                this.Close();
            }
        }

        private void EnterRepairPrice_Click(object sender, RoutedEventArgs e)
        {
            if (lvDevice.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please add data to checkstatus!", "Notification", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            else
            {
                int selectedIndex = lvDevice.SelectedIndex;
                RepairBill inputCheck = (RepairBill)lvDevice.SelectedItem;
                EnterRepairPriceWindow enterRepairPrice = new EnterRepairPriceWindow(inputCheck, selectedIndex);
                enterRepairPrice.enterDelegate = EnterRepairPrice;
                enterRepairPrice.ShowDialog();
            }
        }
        public void EnterRepairPrice(RepairBill repair, int index)
        {
            nrepairBills[index] = repair;
            lvDevice.ItemsSource = null;
            lvDevice.ItemsSource = nrepairBills;
        }

    }
}
