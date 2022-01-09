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
using assets_management_system.data_classes;
using Newtonsoft.Json;

namespace assets_management_system.Inventory
{
    /// <summary>
    /// Interaction logic for Establish_Inventory_CouncilWindow.xaml
    /// </summary>
    public partial class Establish_Inventory_CouncilWindow : Window
    {
        public IList<Personnel> personnels { get; set; }

        public Establish_Inventory_CouncilWindow()
        {
            InitializeComponent();
        }

        private void AddPesonnel_Click(object sender, RoutedEventArgs e)
        {
            AddPesonnelWindow addPersonnelWindow = new AddPesonnelWindow();
            addPersonnelWindow.ChoosePersonnel = ChooseNewPersonnel;
            addPersonnelWindow.ShowDialog();
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            if (lvInventory.Items.Count == 0)
            {
                MessageBox.Show("Please selected personnel to continue!", "Notification", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            else
            {
                InventoryDeviceWindow inventoryDeviceWindow = new InventoryDeviceWindow(personnels);
                inventoryDeviceWindow.Closed += new EventHandler((e, args) => this.Close());
                inventoryDeviceWindow.ShowDialog();
            }    
                
        }
        public void ChooseNewPersonnel(IList<Personnel> param)
        {
            personnels = new List<Personnel>();
            foreach( Personnel element in param)
            {
                personnels.Add(element);

            }
           
            lvInventory.ItemsSource = null;
            lvInventory.ItemsSource = personnels;
        }
    }
}
