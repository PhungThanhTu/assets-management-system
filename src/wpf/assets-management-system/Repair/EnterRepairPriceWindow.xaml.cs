using assets_management_system.data_classes;
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

namespace assets_management_system.Repair
{
    /// <summary>
    /// Interaction logic for EnterRepairPriceWindow.xaml
    /// </summary>
    public partial class EnterRepairPriceWindow : Window
    {
        public RepairBill repair { get; set; }
        public int index { get; set; }
        public delegate void EnterRepairPriceDelegate(RepairBill repairBill, int index);
        public EnterRepairPriceDelegate enterDelegate;
        public EnterRepairPriceWindow(RepairBill repairBill, int index)
        {
            InitializeComponent();
            this.repair = repairBill;
            this.index = index;
        }

        private void Done_Click(object sender, RoutedEventArgs e)
        {
            if (txtboxPrice.Text.Length == 0)
            {
                MessageBox.Show("Please enter full information!", "Notification", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            else
            {
                repair.repair_price = int.Parse(txtboxPrice.Text);
                enterDelegate(this.repair, this.index);
                this.Close();
            }
        }
    }
}
