using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
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
    /// Interaction logic for StartCheckingWindow.xaml
    /// </summary>
    public partial class StartCheckingWindow : Window
    {
        public DataRowView rowView;
        public StartCheckingWindow()
        {
            InitializeComponent();
        }
        private void DataGridRow_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            DataGridRow selectedRow = (DataGridRow)sender;
            selectedRow.IsSelected = true;
            rowView = lvDevice.SelectedItem as DataRowView;
        }
        private void CheckStatus_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
