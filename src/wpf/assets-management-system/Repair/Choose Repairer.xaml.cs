using assets_management_system.data_classes;
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
using System.Windows.Shapes;

namespace assets_management_system.Repair
{
    /// <summary>
    /// Interaction logic for Choose_Repairer.xaml
    /// </summary>
    public partial class Choose_Repairer : Window
    {
        public IList<Repairer> repairers { get; set; }
        public int repairer { get; set; }
        public IList<RepairBill> nrepairBills { get; set; }
        public Choose_Repairer(IList<RepairBill> repairBills)
        {
            InitializeComponent();
            FetchRepairer();
            this.nrepairBills = repairBills;
            
        }

        void FetchRepairer()
        {
            string data = HTTPClientHandler.GetJsonData(API_config.enpoint_uri + "repairer/");

            try
            {
                repairers = JsonConvert.DeserializeObject<IList<Repairer>>(data);
                lvRepairer.ItemsSource = repairers;
            }
            catch
            {
                if (data != null)
                {
                    Message errorMessage = JsonConvert.DeserializeObject<Message>(data);
                    MessageBox.Show(errorMessage.message);

                }
                else
                {
                    MessageBox.Show("Unable to connect to the server");
                }
            }
        }

        private void AddNewRepairer_Click(object sender, RoutedEventArgs e)
        {
            NewRepairerWindow newRepairer = new NewRepairerWindow();
            newRepairer.Closed += new EventHandler((e, args) => FetchRepairer());
            newRepairer.ShowDialog();
        }

        private void ChooseRepairer_Click(object sender, RoutedEventArgs e)
        {
            repairers = new List<Repairer>();
            foreach (Repairer repairer in lvRepairer.SelectedItems)
            {
                Repairer newSelectedRepairer = new Repairer();
                newSelectedRepairer.id = repairer.id;
                newSelectedRepairer.name = repairer.name.ToString();
                newSelectedRepairer.address = repairer.address.ToString();
                newSelectedRepairer.phone = repairer.phone.ToString();
                repairers.Add(newSelectedRepairer);
            }
            InsertRepairWindow insertRepair = new InsertRepairWindow(((Repairer)lvRepairer.SelectedItem).id,nrepairBills);
            insertRepair.Closed += new EventHandler((e, args) => this.Close());
            insertRepair.ShowDialog();
        }
    }
}
