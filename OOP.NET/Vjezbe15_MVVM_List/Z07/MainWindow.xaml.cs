using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Z07
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += MainWindow_Loaded;
        }

        void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            List<AutomobilViewModel> a = AutomobiliViewModel.GetAuti();
            //this.lbAutomobili.ItemsSource = a;
            grid.DataContext = a;
            //AutomobilViewModel automobilVM = new AutomobilViewModel(a[0]);

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AutomobilViewModel autic = (AutomobilViewModel)this.lbAutomobili.SelectedItem;
            autic.Marka = txtNovaMarka.Text;
        }
    }
}
