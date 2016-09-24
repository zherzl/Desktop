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

namespace BindingTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Kupac k = new Kupac { IDKupac = 1, Ime = "Pero" };
            lbox.Items.Add(k);
            Kupac k2 = new Kupac { IDKupac = 2, Ime = "Ivo" };
            lbox.Items.Add(k2);
        }

        private void slid_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (lbox != null)
            {

                Brush b = (Brush) mojBorder.GetValue(Border.BackgroundProperty);
                lbox.Background = b;
            }

        }
    }




    public class Kupac
    {
        public int IDKupac { get; set; }
        public String Ime { get; set; }

        public override string ToString()
        {
            return String.Format("ID: {0} Ime: {1}", IDKupac, Ime);
        }
    }

}
