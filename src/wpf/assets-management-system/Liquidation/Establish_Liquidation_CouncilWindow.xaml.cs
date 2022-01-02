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

namespace assets_management_system.Liquidation
{
    /// <summary>
    /// Interaction logic for Establish_Liquidation_CouncilWindow.xaml
    /// </summary>
    public partial class Establish_Liquidation_CouncilWindow : Window
    {
        public Establish_Liquidation_CouncilWindow()
        {
            InitializeComponent();
        }

        private void AddPesonnel_Click(object sender, RoutedEventArgs e)
        {
            AddPesonnelWindow addPesonnelWindow = new AddPesonnelWindow();
            addPesonnelWindow.Show();
        }

        private void Liquidate_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
