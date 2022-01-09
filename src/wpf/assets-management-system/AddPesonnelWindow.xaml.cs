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
    /// Interaction logic for AddPesonnelWindow.xaml
    /// </summary>
    public partial class AddPesonnelWindow : Window
    {
        public IList<Personnel> personnels { get; set; }
        public delegate void ChoosePersonnelDelegate(IList<Personnel> param);
        public ChoosePersonnelDelegate ChoosePersonnel;

        public AddPesonnelWindow()
        {
            InitializeComponent();
            FetchPersonnel();
        }

        void FetchPersonnel ()
        {
            string data= HTTPClientHandler.GetJsonData(API_config.enpoint_uri + "personnel/");
            try
            {
                personnels = JsonConvert.DeserializeObject<IList<Personnel>>(data);
                lvPersonnel.ItemsSource = personnels;
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

        private void ChoosePersonnel_Click(object sender, RoutedEventArgs e)
        {
            if (lvPersonnel.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please selected personnel to continue!", "Notification", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            else
            {
                personnels = new List<Personnel>();
                foreach (Personnel personnel in lvPersonnel.SelectedItems)
                {
                    Personnel newSelectedPersonnel = new Personnel();
                    newSelectedPersonnel.id = personnel.id;
                    newSelectedPersonnel.name = personnel.name.ToString();
                    newSelectedPersonnel.position = personnel.position.ToString();
                    newSelectedPersonnel.division = personnel.division;
                    personnels.Add(newSelectedPersonnel);
                }
                ChoosePersonnel(personnels);
                this.Close();
            }      
        }

        private void AddNewPersonnel_Click(object sender, RoutedEventArgs e)
        {
            NewPersonnelWindow newPersonnelWindow = new NewPersonnelWindow();
            newPersonnelWindow.Closed += new EventHandler((e, args) => FetchPersonnel());
            newPersonnelWindow.ShowDialog();
        }
    }
}
