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
using assets_management_system.Pages;
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

            if (txtboxUsername.Text.Length == 0)
                MessageBox.Show("Please enter Username!");

            else if (FloatingPasswordBox.Password.Length == 0)
                MessageBox.Show("Please enter Password!");
            else
            {   
                try
                {
                    Message getMessage = JsonConvert.DeserializeObject<Message>(HTTPClientHandler.GetJsonData(API_config.enpoint_uri + "login/" + username + "/" + password));

                    if (getMessage == null)
                    {
                        MessageBox.Show("Cannot connect to the server", "Notification", MessageBoxButton.OK, MessageBoxImage.Information);
                        return;
                    }

                    if (getMessage.message == "success")
                    {
                        MainWindow newWindow = new MainWindow();
                        newWindow.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show(getMessage.message, "Notification", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
                catch
                {
                    MessageBox.Show("Cannot connect to the server, please try again");
                }
                

            }
        }

        private void CancelClicked(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
