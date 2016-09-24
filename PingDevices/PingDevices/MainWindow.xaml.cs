using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
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

namespace PingDevices
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

        

        private ListBoxItem Item(String text)
        {
            ListBoxItem item = new ListBoxItem();
            item.Content = text;

            return item;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            LocalPing();   
        }


        public static void LocalPing()
        {
            // Ping's the local machine.
            Ping pingSender = new Ping();
            int from = 10;
            int to = 100;

            for (int i = from; i <= to; i++)
            {
                IPAddress address = IPAddress.Parse("192.168.0." + i);
                PingReply reply = pingSender.Send(address);

                if (reply.Status == IPStatus.Success)
                {
                    IPHostEntry entry = Dns.GetHostEntry(address);

                    Console.WriteLine(entry.HostName);
                    Console.WriteLine("Address: {0}", reply.Address.ToString());
                    Console.WriteLine("RoundTrip time: {0}", reply.RoundtripTime);
                    Console.WriteLine("Time to live: {0}", reply.Options.Ttl);
                    Console.WriteLine("Don't fragment: {0}", reply.Options.DontFragment);
                    Console.WriteLine("Buffer size: {0}", reply.Buffer.Length);
                }
                else
                {
                    Console.WriteLine(reply.Status);
                }
            }

            
        }




    }
}
