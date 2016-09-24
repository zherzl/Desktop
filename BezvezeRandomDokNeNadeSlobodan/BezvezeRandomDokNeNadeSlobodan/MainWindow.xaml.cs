using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace BezvezeRandomDokNeNadeSlobodan
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

        List<int> brojevi = new List<int> { 1, 3, 5, 12, 17, 19, 4 };

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        private int NadiNoviID()
        {
            int noviID;
            Random r = new Random();
            do
            {
                noviID = r.Next(1, 20);
                
                if (brojevi.Contains(noviID))
                    lblPorukaPostoji.Content += (" " + noviID);
                else
                    lblPoruka.Content += (" " + noviID);
                Thread.Sleep(1000);

            } while (brojevi.Contains(noviID));

            return noviID;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int br = NadiNoviID();
            brojevi.Add(br);
        }


    }
}
