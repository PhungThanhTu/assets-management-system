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

namespace assets_management_system
{
    /// <summary>
    /// Interaction logic for NewPersonnelWindow.xaml
    /// </summary>
    public partial class NewPersonnelWindow : Window
    {
        public IList<Division> divisions { get; set; }
        public Personnel personnel { get; set; }
        public delegate void AddPersonnelDelegate(Personnel param);

        public AddPersonnelDelegate AddPersonnel;

        public NewPersonnelWindow()
        {
            InitializeComponent();
            string DivisionData = HTTPClientHandler.GetJsonData(API_config.enpoint_uri + "division");
            try
            {
                divisions = new List<Division>();
                divisions = JsonConvert.DeserializeObject<IList<Division>>(DivisionData);
                cbDivision.ItemsSource = divisions;
                cbDivision.DisplayMemberPath = "name";
                cbDivision.SelectedValuePath = "id";
            }
            catch
            {
                MessageBox.Show("Connection Error");
            }
        }

        private void AddNewPersonnel_Click(object sender, RoutedEventArgs e)
        {
            if (txtboxName.Text.Length==0||txtboxPosition.Text.Length==0||cbDivision.Text.Length==0)
            {
                MessageBox.Show("Please enter full information!", "Notification", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            else
            {
                personnel = new Personnel();
                personnel.name = txtboxName.Text.ToString();
                personnel.position = txtboxPosition.Text.ToString();
                //personnel.division = int.Parse(cbDivision.SelectedValue.ToString());
                AddPersonnel(personnel);
                try
                {
                    string result = HTTPClientHandler.PostJsonData(API_config.enpoint_uri + "personnel/", personnel);
                    MessageBox.Show(result);
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
