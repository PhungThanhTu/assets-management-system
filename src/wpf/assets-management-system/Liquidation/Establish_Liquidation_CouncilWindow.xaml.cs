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
        public IList<CheckDetail> nDetail { get; set; }

        public PostCheck nCheckDate { get; set; }
        public InventoryHeader inventory_header { get; set; }
        public CheckHeader ncheck_detail { get; set; }
        public Establish_Liquidation_CouncilWindow(IList<CheckDetail> checkDetails)
        {
            InitializeComponent();
            this.nDetail = checkDetails;
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
            if (dpLiquidation.Text.Length == 0)
            {
                MessageBox.Show("Please enter full information!", "Notification", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            else
            {
                nCheckDate = new PostCheck()
                {
                    check_date = dpLiquidation.SelectedDate.Value.ToString("yyyy-MM-dd"),
                };


                ncheck_detail = new CheckHeader()

                {
                    check = nCheckDate,
                    detail = nDetail

                };

                inventory_header = new InventoryHeader
                {
                    personnel = personnels,
                    check_detail = ncheck_detail

                };

                try
                {
                    string result = HTTPClientHandler.PostJsonData(API_config.enpoint_uri + "liquidation/add", inventory_header);
                    MessageBox.Show(result);
                }
                catch
                {
                    MessageBox.Show("Connection Error");
                }
                this.Close();

            }
        }
    }
}
