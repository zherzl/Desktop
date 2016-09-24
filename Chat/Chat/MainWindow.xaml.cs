using System;
using System.Windows;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;

namespace Chat
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Form2 f = new Form2();
            f.ShowDialog();
        }



        


    }
}
