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

namespace assets_management_system
{
    /// <summary>
    /// Interaction logic for EditStatusWindow.xaml
    /// </summary>
    public partial class EditStatusWindow : Window
    {
        public CheckDetail detail { get; set; }
        public int index { get; set; }
        public delegate void EditDeviceDelegate(CheckDetail detail, int index);
        public EditDeviceDelegate editDelegate;
        public EditStatusWindow(CheckDetail detail, int index)
        {
            InitializeComponent();
            this.detail = detail;
            this.index = index;
        }

        private void EditStatus_Click(object sender, RoutedEventArgs e)
        {
            if(cbStatus.Text.Length==0)
            {
                MessageBox.Show("Please enter full information!", "Notification", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            else
            {
                detail.status = cbStatus.Text;
                editDelegate(this.detail, this.index);
                this.Close();
            }
        }
    }
}
