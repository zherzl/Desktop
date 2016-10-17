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
    public partial class MainContentControl_Copy : UserControl
    {
        private IView view;
        private List<VehicleViewModel> vm;
        private List<VehicleViewModel> vmOriginal;


        public MainContentControl_Copy(IView view, List<VehicleViewModel> vm, List<VehicleViewModel> vmOriginal)
        {
            InitializeComponent();
            this.view = view;

            this.vm = vm;
            this.vmOriginal = vmOriginal;

            lboxCarList.DataContext = vm.OrderBy(x => x.AVehicleIdentifier);
            lboxCarListOriginal.DataContext = vmOriginal.OrderBy(x => x.AVehicleIdentifier);

            txtSearch.TextChanged += TxtSearch_TextChanged;
            txtSearchOriginal.TextChanged += TxtSearch_TextChanged;
        }



        private void TxtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox tb = sender as TextBox;
            ListBox lb = lboxCarList;
            List<VehicleViewModel> vmTmp = vm;

            if (tb == txtSearchOriginal)
            {
                lb = lboxCarListOriginal;
                vmTmp = vmOriginal;
            }


            try
            {
                string x = lb.ItemTemplate.VisualTree.FirstChild.ToString();
                view.SetInfo(x);
            }
            catch (Exception ex)
            {
                view.SetInfo(ex.Message);
            }

            lb.ItemsSource = vmTmp.Where(x => x.AVehicleIdentifier.ToLower().Contains(tb.Text.ToLower()));
        }


 


        public VehicleViewModel GetSelectedCar()
        {
            return lboxCarList.SelectedValue as VehicleViewModel;
        }


    }
}
