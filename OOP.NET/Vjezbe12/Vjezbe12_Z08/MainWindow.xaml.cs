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

namespace Vjezbe12_Z08
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        String trenutniNaziv = "mojBrush";

        private void btnPrvi_Click_1(object sender, RoutedEventArgs e)
        {
            Button b = sender as Button;

            if (trenutniNaziv == "mojBrush")
                this.trenutniNaziv = "mojAltBrush";
            else
                this.trenutniNaziv = "mojBrush";

            RadialGradientBrush brush = (RadialGradientBrush)this.FindResource(trenutniNaziv);
            b.Background = brush;
        }
    }
}
