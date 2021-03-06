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
using assets_management_system.data_classes;
using assets_management_system.Liquidation;
using Newtonsoft.Json;

namespace assets_management_system.Pages
{
    /// <summary>
    /// Interaction logic for LiquidationPage.xaml
    /// </summary>
    public partial class LiquidationPage : System.Windows.Controls.Page
    {
        public IList<Division> divisions { get; set; }
        public IList<Device> devices { get; set; }
        public IList<CheckDetail> nDetail { get; set; }
        public LiquidationPage()
        {
            InitializeComponent();
            FetchDivision();
            cbDivision.SelectedIndex = 0;
        }

        private void ShowLiquidationHistory_Click(object sender, RoutedEventArgs e)
        {
            LiquidationHistoryWindow liquidationHistoryWindow = new LiquidationHistoryWindow();
            liquidationHistoryWindow.ShowDialog();
        }

        private void StartLiquidation_Click(object sender, RoutedEventArgs e)
        {
            
            if(lvLiquidation.SelectedItems.Count==0)
            {
                MessageBox.Show("Please selected the device to continue!", "Notification", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            else
            {
                nDetail = new List<CheckDetail>();
                nDetail.Clear();
                foreach (Device device in lvLiquidation.SelectedItems)
                {
                    CheckDetail newSelectedDevice = new CheckDetail();
                    newSelectedDevice.id = device.id;
                    newSelectedDevice.name = device.name.ToString();
                    newSelectedDevice.current_value = device.current_value;
                    newSelectedDevice.status = "Liquidated";
                    newSelectedDevice.division = int.Parse(cbDivision.SelectedValue.ToString());
                    nDetail.Add(newSelectedDevice);
                }
                Establish_Liquidation_CouncilWindow establish_Liquidation_Council = new Establish_Liquidation_CouncilWindow(nDetail);
                establish_Liquidation_Council.Closed += new EventHandler((e, args) => this.FetchDevices());
                establish_Liquidation_Council.ShowDialog();
            }    
            
        }
        private void Combobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            FetchDevices();
        }
        void FetchDevices()
        {
            string data = HTTPClientHandler.GetJsonData(API_config.enpoint_uri + "liquidation/query?division=" + cbDivision.SelectedValue);

            try
            {
                devices = JsonConvert.DeserializeObject<IList<Device>>(data);
                lvLiquidation.ItemsSource = devices;

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

        void FetchDivision()
        {
            string data = HTTPClientHandler.GetJsonData(API_config.enpoint_uri + "division");

            try
            {

                divisions = JsonConvert.DeserializeObject<IList<Division>>(data);
                cbDivision.DisplayMemberPath = "name";
                cbDivision.SelectedValuePath = "id";
                cbDivision.ItemsSource = divisions;



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
