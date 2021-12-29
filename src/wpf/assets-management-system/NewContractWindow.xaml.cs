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
    /// Interaction logic for NewContractWindow.xaml
    /// </summary>
    public partial class NewContractWindow : Window
    {
        public IList<Supplier> suppliers { get; set; }
        public IList<Device> devices { get; set; }
        //DataRowView rowView;

        public NewContractWindow()
        {
            InitializeComponent();
            devices = new List<Device>();
            suppliers = new List<Supplier>();

        }

        public void Window_Loaded(object sender, RoutedEventArgs e)
        {
            suppliers = JsonConvert.DeserializeObject<IList<Supplier>>(HTTPClientHandler.GetJsonData("https://evening-mountain-03563.herokuapp.com/supplier"));
            cbSupplier.ItemsSource = suppliers;
            cbSupplier.DisplayMemberPath = "name";
            devices.Clear();
            lvDevice.ItemsSource = devices;
        }

        private void AddDevice_Click(object sender, RoutedEventArgs e)
        {
            AddDevicesWindow addDevicesWindow = new AddDevicesWindow();
            this.Hide();
            addDevicesWindow.ShowDialog();
            
        }

        private void Done_CLick(object sender, RoutedEventArgs e)
        {

        }


        private void Edit_Click(object sender, RoutedEventArgs e)
        {

        }
        private void Delete_Click(object sender, RoutedEventArgs e)
        {

        }


        //private void DataGridRow_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        //{
        //    DataGridRow selectedRow = (DataGridRow)sender;
        //    selectedRow.IsSelected = true;
        //    //rowView = lvDevice.SelectedItem as DataRowView;
        //}


    }
}
