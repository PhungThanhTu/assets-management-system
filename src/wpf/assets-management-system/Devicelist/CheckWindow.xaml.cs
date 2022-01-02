using assets_management_system.Devicelist;
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
    /// Interaction logic for CheckWindow.xaml
    /// </summary>
    public partial class CheckWindow : Window
    {
        public CheckWindow()
        {
            InitializeComponent();
        }

        private void CheckList_Click(object sender, RoutedEventArgs e)
        {
            CheckListWindow checkListWindow = new CheckListWindow();
            checkListWindow.ShowDialog();
        }

        private void StartChecking_Click(object sender, RoutedEventArgs e)
        {
            StartCheckingWindow startCheckingWindow = new StartCheckingWindow();
            startCheckingWindow.ShowDialog();
        }
    }
}
