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
    /// Interaction logic for AddDevicesWindow.xaml
    /// </summary>
    public partial class AddDevicesWindow : Window
    {
        public AddDevicesWindow()
        {
            InitializeComponent();
        }

        public static implicit operator AddDevicesWindow(DevicesWindow v)
        {
            throw new NotImplementedException();
        }
    }
}
