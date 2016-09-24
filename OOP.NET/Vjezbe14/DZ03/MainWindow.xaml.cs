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

namespace DZ03
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


        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Space:
                    ZamijeniStil();
                    break;
                case Key.Left:
                    Canvas.SetLeft(mojGumb, Canvas.GetLeft(mojGumb) - 1);
                    break;
                case Key.Right:
                    Canvas.SetLeft(mojGumb, Canvas.GetLeft(mojGumb) + 1);
                    break;
                case Key.Down:
                    Canvas.SetTop(mojGumb, Canvas.GetTop(mojGumb) + 1);
                    break;
                case Key.Up:
                    Canvas.SetTop(mojGumb, Canvas.GetTop(mojGumb) - 1);
                    break;
                default:
                    break;
            }

        }

        private void ZamijeniStil()
        {
            if (mojGumb.Style.Equals(Resources["mojKrugStil"] as Style))
                mojGumb.Style = Resources["mojRombStil"] as Style;
            else
                mojGumb.Style = Resources["mojKrugStil"] as Style;
        }
    }
}
