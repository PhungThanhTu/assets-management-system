using assets_management_system.data_classes;
using assets_management_system.Repair;
using Newtonsoft.Json;
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
    /// Interaction logic for RepairPage.xaml
    /// </summary>
    public partial class RepairPage : System.Windows.Controls.Page
    {
        public IList<RepairSpoiled> repairSpoileds { get; set; }
        public IList<RepairBill> repairBills { get; set; }
        public RepairPage()
        {
            InitializeComponent();
            FetchDevice();          
        }

        private void Repair_Click(object sender, RoutedEventArgs e)
        {
            if (lvDevice.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please selected the device to continue!", "Notification", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            else
            {
                repairBills = new List<RepairBill>();
                foreach (RepairSpoiled repair in lvDevice.SelectedItems)
                {
                    RepairBill newSelectedRepair = new RepairBill();
                    newSelectedRepair.id = repair.id;
                    newSelectedRepair.name = repair.name.ToString();
                    repairBills.Add(newSelectedRepair);
                }
                Choose_Repairer chooseRepairer = new Choose_Repairer(repairBills);
                chooseRepairer.Closed += new EventHandler((o, args) => FetchDevice());
                chooseRepairer.Show();
            }    
                
        }

        private void ShowRepair_Click(object sender, RoutedEventArgs e)
        {
            RepairListWindow repairList = new RepairListWindow();
            repairList.Closed += new EventHandler((o, args) => FetchDevice());
            repairList.ShowDialog();
        }
        
        void FetchDevice()
        {
            string data = HTTPClientHandler.GetJsonData(API_config.enpoint_uri + "repair/spoiled");

            try
            {
                repairSpoileds = JsonConvert.DeserializeObject<IList<RepairSpoiled>>(data);
                lvDevice.ItemsSource = repairSpoileds;

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
