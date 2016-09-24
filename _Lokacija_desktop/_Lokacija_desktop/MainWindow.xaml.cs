using System;
using System.Collections.Generic;
using System.Device.Location;
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

namespace _Lokacija_desktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            GetKoordinejts();
        }

        GeoCoordinateWatcher watcher;   
        public void GetKoordinejts()
        {
            watcher = new GeoCoordinateWatcher();
            watcher.PositionChanged += Watcher_PositionChanged;
            bool started = watcher.TryStart(false, TimeSpan.FromMilliseconds(2000));

            if (!started)
            {
                lblLat.Content = "GeoCoordinateWatcher timed out on start.";
            }
        }

        private void Watcher_PositionChanged(object sender, GeoPositionChangedEventArgs<GeoCoordinate> e)
        {
            lblLat.Content = e.Position.Location.Longitude.ToString();
            lblLong.Content = e.Position.Location.Latitude.ToString();
        }
    }
}
