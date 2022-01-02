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
using assets_management_system.Liquidation;


namespace assets_management_system.Pages
{
    /// <summary>
    /// Interaction logic for LiquidationPage.xaml
    /// </summary>
    public partial class LiquidationPage : System.Windows.Controls.Page
    {
        public LiquidationPage()
        {
            InitializeComponent();
        }

        private void ShowLiquidationHistory_Click(object sender, RoutedEventArgs e)
        {
            LiquidationHistoryWindow liquidationHistoryWindow = new LiquidationHistoryWindow();
            liquidationHistoryWindow.ShowDialog();
        }

        private void StartLiquidation_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
