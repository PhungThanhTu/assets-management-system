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
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }
        private void LoginClicked(object sender, RoutedEventArgs e)
        {
            string username = txtboxUsername.Text;
            string password = FloatingPasswordBox.Password;
 


            Supplier cellphoneS = new Supplier
            {
                id = 8,
                name = "cellphoneS",
                address = "TPHCM",
                phone = "03561"
            };

            var data = HTTPClientHandler.PatchJsonData("https://evening-mountain-03563.herokuapp.com/supplier", cellphoneS);

            MessageBox.Show(data);


        }

        
    }
}
