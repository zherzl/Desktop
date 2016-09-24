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

namespace WPF_MultiThreading_test
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

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            RadiNestoUPozadini();
        }

        private delegate void OsvjeziPorukuCallback(string poruka);
        private void RadiNestoUPozadini()
        {
            ThreadPool.QueueUserWorkItem(o =>
                {
                    for (int i = 0; i < 10; i++)
                    {
                        lblPoruka.Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Normal,
                            (ThreadStart)delegate()
                            {
                                lblPoruka.Content = i.ToString();
                            });
                        Thread.Sleep(1000);
                    }
            });


        }

        private void OsvjeziPoruku(string poruka)
        {
            lblPoruka.Content = poruka;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Bla");
        }
    }
}
