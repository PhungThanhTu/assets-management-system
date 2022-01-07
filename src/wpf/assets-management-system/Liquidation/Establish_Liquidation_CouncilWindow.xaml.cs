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

namespace assets_management_system.Liquidation
{
    /// <summary>
    /// Interaction logic for Establish_Liquidation_CouncilWindow.xaml
    /// </summary>
    public partial class Establish_Liquidation_CouncilWindow : Window
    {
        public IList<Personnel> personnels { get; set; }
        public Establish_Liquidation_CouncilWindow()
        {
            InitializeComponent();
        }

        private void AddPesonnel_Click(object sender, RoutedEventArgs e)
        {
            AddPesonnelWindow addPersonnelWindow = new AddPesonnelWindow();
            addPersonnelWindow.ChoosePersonnel = ChooseNewPersonnel;
            addPersonnelWindow.ShowDialog();
        }
        public void ChooseNewPersonnel(IList<Personnel> param)
        {
            personnels = new List<Personnel>();
            foreach (Personnel element in param)
            {
                personnels.Add(element);

            }

            lvLiquidation.ItemsSource = null;
            lvLiquidation.ItemsSource = personnels;
        }
        private void Liquidate_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
