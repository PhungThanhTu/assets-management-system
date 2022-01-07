using assets_management_system.Statictis;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace assets_management_system.Pages
{
    /// <summary>
    /// Interaction logic for StatisticPage.xaml
    /// </summary>
    public partial class StatisticPage : System.Windows.Controls.Page
    {
        public StatisticPage()
        {
            InitializeComponent();
        }

        private void RepairPrice_Click(object sender, RoutedEventArgs e)
        {
            StatictisRepairPrice statictisRepairPrice = new StatictisRepairPrice();
            statictisRepairPrice.ShowDialog();
        }

        private void DeviceCount_Click(object sender, RoutedEventArgs e)
        {
            StatictisDeviceCount statictisDeviceCount = new StatictisDeviceCount();
            statictisDeviceCount.ShowDialog();
        }
    }
}
