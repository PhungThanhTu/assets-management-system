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

namespace assets_management_system.Repair
{
    /// <summary>
    /// Interaction logic for NewRepairerWindow.xaml
    /// </summary>
    public partial class NewRepairerWindow : Window
    {
        public PostRepairer repairer { get; set; }
        public delegate void AddRepairerDelegate(Repairer param);
        public AddRepairerDelegate AddRepairer;
        public NewRepairerWindow()
        {
            InitializeComponent();
        }

        private void AddNewRepairer_Click(object sender, RoutedEventArgs e)
        {
            if (txtboxName.Text.Length == 0 || txtboxAddress.Text.Length == 0 || txtboxPhone.Text.Length == 0)
            {
                MessageBox.Show("Please enter full information!", "Notification", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            else
            {
                repairer = new PostRepairer();
                repairer.name = txtboxName.Text.ToString();
                repairer.address = txtboxAddress.Text.ToString();
                repairer.phone = txtboxPhone.Text.ToString();

                try
                {
                    string result = HTTPClientHandler.PostJsonData(API_config.enpoint_uri + "repairer/", repairer);
                    //MessageBox.Show(result);
                }
                catch
                {
                    MessageBox.Show("Connection Error");
                }
                this.Close();
            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
