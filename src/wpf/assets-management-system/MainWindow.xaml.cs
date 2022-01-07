using assets_management_system.Page;
using assets_management_system.Pages;
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

namespace assets_management_system
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
            PagesNavigation.Navigate(new DevicePage());
        }
       
        private void LogOutClicked(object sender, RoutedEventArgs e)
        {
            LoginWindow newWindow = new LoginWindow();
            newWindow.Show();
            this.Close();
        }

        private void Device_Click(object sender, RoutedEventArgs e)
        {
            PagesNavigation.Navigate(new DevicePage());
        }

        private void Repair_Click(object sender, RoutedEventArgs e)
        {
            PagesNavigation.Navigate(new RepairPage());
        }

        private void Liquidation_Click(object sender, RoutedEventArgs e)
        {
            PagesNavigation.Navigate(new LiquidationPage());
        }

        private void Inventory_Click(object sender, RoutedEventArgs e)
        {
            PagesNavigation.Navigate(new InventoryPage());
        }

        private void Statistic_CLick(object sender, RoutedEventArgs e)
        {
            PagesNavigation.Navigate(new StatisticPage());
        }
    }
}
