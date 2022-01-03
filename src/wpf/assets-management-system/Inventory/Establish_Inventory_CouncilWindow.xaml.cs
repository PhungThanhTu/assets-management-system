﻿using System;
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

namespace assets_management_system.Inventory
{
    /// <summary>
    /// Interaction logic for Establish_Inventory_CouncilWindow.xaml
    /// </summary>
    public partial class Establish_Inventory_CouncilWindow : Window
    {
        public Establish_Inventory_CouncilWindow()
        {
            InitializeComponent();
        }

        private void AddPesonnel_Click(object sender, RoutedEventArgs e)
        {
            AddPesonnelWindow addPesonnelWindow = new AddPesonnelWindow();
            addPesonnelWindow.ShowDialog();
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            InventoryDeviceWindow inventoryDeviceWindow = new InventoryDeviceWindow();
            inventoryDeviceWindow.ShowDialog();
        }
    }
}