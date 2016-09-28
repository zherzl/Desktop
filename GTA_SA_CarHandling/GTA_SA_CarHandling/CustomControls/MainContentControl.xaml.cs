using GTA_SA_CarHandling.Interfaces;
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
using GTA_SA_CarHandling.Model;

namespace GTA_SA_CarHandling.CustomControls
{
    /// <summary>
    /// Interaction logic for MainContent.xaml
    /// </summary>
    public partial class MainContentControl : UserControl
    {
        private IView view;
        private List<VehicleViewModel> vm;

        public MainContentControl(IView view)
        {
            InitializeComponent();
            this.view = view;
            this.vm = view.VehiclesList().OrderBy(x => x.AVehicleIdentifier).ToList();
            MainGrid.DataContext = vm;
            txtSearch.TextChanged += TxtSearch_TextChanged;
        }
        
        

        private void TxtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            //lboxCarList.SelectedItem = vm.FirstOrDefault(x => x.AVehicleIdentifier.ToLower().StartsWith(txtSearch.Text.ToLower()));
            lboxCarList.ItemsSource = vm.Where(x => x.AVehicleIdentifier.ToLower().StartsWith(txtSearch.Text.ToLower()));
        }

        

        
    }
}
