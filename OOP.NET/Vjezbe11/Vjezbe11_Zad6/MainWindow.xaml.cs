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

namespace Vjezbe11_Zad6
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

        private void btnDodaj_Click(object sender, RoutedEventArgs e)
        {
            NoviPanel();
        }

        private void btnUkloni_Click(object sender, RoutedEventArgs e)
        {
            gridContainer.Children.Clear();
        }


        private StackPanel NoviPanel()
        {
            Random r = new Random();

            StackPanel p = new StackPanel();
            Grid.SetRow(p, 1);
            p.Width = 20;
            p.Height = 20;
            
            RotateTransform rt = new RotateTransform(r.Next(10, 90), 0, 0);

            p.LayoutTransform = rt;
            p.Background = new SolidColorBrush(Color.FromArgb(166, (byte)r.Next(0, 256), (byte)r.Next(0, 256), (byte)r.Next(0, 256)));
            gridContainer.Children.Add(p);
            return p;
        }
    }
}
