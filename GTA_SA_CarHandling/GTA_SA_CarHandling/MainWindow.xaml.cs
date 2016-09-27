using GTA_SA_CarHandling.CustomControls;
using GTA_SA_CarHandling.Interfaces;
using GTA_SA_CarHandling.Model;
using GTA_SA_CarHandling.ModelClass;
using GTA_SA_CarHandling.Text;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
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

namespace GTA_SA_CarHandling
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IView
    {
        StringParser sp;
        ResourceBuilder resourceRdr;
        private string HandlingString { get; set; }
        private List<string> FileRows { get; set; }
        public List<VehicleViewModel> vm { get; set; }


        public MainWindow()
        {
            InitializeComponent();
            sp = new StringParser();
            vm = new List<VehicleViewModel>();
            FileRows = new List<string>();
            resourceRdr = new ResourceBuilder(this);
            HandlingString = resourceRdr.LoadConfig();
            LoadFileRows();

            
        }

    

        private void LoadFileRows()
        {
            try
            {
                FileRows = sp.StartParsing(HandlingString);
                GetParsedViewModel();
            }
            catch (Exception ex)
            {
                SetInfo(ex.Message);
            }
        }


        void GetParsedViewModel()
        {
            List<Vehicle> vehicles = sp.ParseVehicleRows(FileRows);
            vm = VehiclesViewModel.GetVehicles(vehicles);
            
            MainContentControl vehicleControl = new MainContentControl(this);
            Grid.SetRow(vehicleControl, 0);
            Grid.SetColumnSpan(vehicleControl, 3);
            MainGrid.Children.Add(vehicleControl);
        }

        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SetInfo(null);
                HandlingString = resourceRdr.GetFileName(null);
                LoadFileRows();
            }
            catch (Exception ex)
            {
                SetInfo(ex.Message);
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            SetInfo(null);
        }



        public void SetInfo(string message)
        {
            lblInfo.Text = message;
        }

        public List<VehicleViewModel> VehiclesList()
        {
            return this.vm;
        }
    }
}
