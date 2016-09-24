using System;
using System.Collections.Generic;
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

namespace UltimateCommander
{
    /// <summary>
    /// Interaction logic for btnMaxControl.xaml
    /// </summary>
    public partial class btnMaxControl : UserControl
    {
        private Window wind;
        public btnMaxControl(Window wind)
        {
            this.InitializeComponent();
            this.wind = wind;
        }

        private void btnMax_Click(object sender, RoutedEventArgs e)
        {
            Button b = sender as Button;
            if (wind.WindowState == System.Windows.WindowState.Maximized)
                wind.WindowState = System.Windows.WindowState.Normal;
            else
                wind.WindowState = System.Windows.WindowState.Maximized;
        }


    }
}