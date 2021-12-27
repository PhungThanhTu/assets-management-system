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
using System.Windows.Navigation;
using System.Windows.Shapes;
using assets_management_system.data_classes;
using Newtonsoft.Json;

namespace assets_management_system.Pages
{
    /// <summary>
    /// Interaction logic for DevicePage.xaml
    /// </summary>
    public partial class DevicePage : System.Windows.Controls.Page
    {
        public IList<Division> divisions { get; set; }
        public DevicePage()
        {
            InitializeComponent();

            divisions = JsonConvert.DeserializeObject<IList<Division>>(HTTPClientHandler.GetJsonData("https://evening-mountain-03563.herokuapp.com/division"));

            
            
            
        }
    }
}
