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

namespace Vjezbe11
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.btnPrvi.Content = "Bye";
        }

        private void btnPrvi_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Kliknuo si me", "Gum", MessageBoxButton.OK, MessageBoxImage.Warning);
        }


    }
}
