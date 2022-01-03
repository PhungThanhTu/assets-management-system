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
using assets_management_system.data_classes;
using assets_management_system.Devicelist;
using Newtonsoft.Json;

namespace assets_management_system
{
    /// <summary>
    /// Interaction logic for CheckWindow.xaml
    /// </summary>
    public partial class CheckWindow : Window
    {
        public IList<Division> divisions { get; set; }
        public IList<Device> devices { get; set; }

        public IList<CheckDetail> nDetail { get; set; }
        
        public Division division { get; set; }
        public int idDivision { get; set; }

        public CheckWindow()
        {
            InitializeComponent();
            FetchDivision();
            cbDivision.SelectedIndex = 0;  
        }

        private void CheckList_Click(object sender, RoutedEventArgs e)
        {
            CheckListWindow checkListWindow = new CheckListWindow();
            checkListWindow.ShowDialog();
        }

        private void StartChecking_Click(object sender, RoutedEventArgs e)
        {
            idDivision = (int)cbDivision.SelectedValue;
            foreach (Device device in lvDevice_Check.SelectedItems)
            {
                CheckDetail newSelectedDevice = new CheckDetail();
                newSelectedDevice.id = device.id;
                newSelectedDevice.name = device.name.ToString();
                newSelectedDevice.current_value = device.current_value;
                newSelectedDevice.division = idDivision;
                newSelectedDevice.status = device.status.ToString();
                nDetail.Add(newSelectedDevice);
            }
            StartCheckingWindow startCheckingWindow = new StartCheckingWindow(nDetail);
            startCheckingWindow.ShowDialog();
        }
        private void Combobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            FetchDevices();
        }
        void FetchDevices()
        {
            string data = HTTPClientHandler.GetJsonData(API_config.enpoint_uri + "device/query?division=" + cbDivision.SelectedValue);

            try
            {
                devices = JsonConvert.DeserializeObject<IList<Device>>(data);
                lvDevice_Check.ItemsSource = devices;

            }
            catch
            {
                if (data != null)
                {
                    Message errorMessage = JsonConvert.DeserializeObject<Message>(data);
                    MessageBox.Show(errorMessage.message);

                }
                else
                {
                    MessageBox.Show("Unable to connect to the server");
                }
            }

        }

        void FetchDivision()
        {
            string data = HTTPClientHandler.GetJsonData(API_config.enpoint_uri + "division");

            try
            {

                divisions = JsonConvert.DeserializeObject<IList<Division>>(data);
                cbDivision.DisplayMemberPath = "name";
                cbDivision.SelectedValuePath = "id";
                cbDivision.ItemsSource = divisions;

                

            }
            catch
            {
                if (data != null)
                {
                    Message errorMessage = JsonConvert.DeserializeObject<Message>(data);
                    MessageBox.Show(errorMessage.message);

                }
                else
                {
                    MessageBox.Show("Unable to connect to the server");
                }
            }

        }
    }
}