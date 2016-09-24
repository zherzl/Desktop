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

namespace Vjezbe11_Zad7
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            gumbi.Add(btn1);
            gumbi.Add(btn2);
            gumbi.Add(btn3);
            gumbi.Add(btn4);
            gumbi.Add(btn5);
            gumbi.Add(btn6);
            gumbi.Add(btn7);
            gumbi.Add(btn8);
            gumbi.Add(btn9);
        }

        List<Button> gumbi = new List<Button>();


        private void RotirajGumbe()
        {
            for (int i = 0; i < gumbi.Count; i++)
            {
                int stariRedak = Grid.GetRow(gumbi[i]);
                int staraKolona = Grid.GetColumn(gumbi[i]);

                int noviRed = VratiNoviRedak(stariRedak, staraKolona);
                int novaKol = VratiNovuKolonua(staraKolona, stariRedak);

                Grid.SetRow(gumbi[i], noviRed);
                Grid.SetColumn(gumbi[i], novaKol);
            }
        }
        private int VratiNoviRedak(int stariRedak, int staraKolona)
        {
            if (stariRedak == 2 && staraKolona == 2)
                return 0;
            else if (staraKolona == 2)
                return ++stariRedak;
            else
                return stariRedak;
        }

        private int VratiNovuKolonua(int staraKolona, int stariRedak)
        {
            if (staraKolona == 2 && stariRedak == 2)
                return 0;
            else if (staraKolona == 2)
                return 0;
            else 
                return ++staraKolona;
        }

       
        private void Window_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            RotirajGumbe();

        }
    }
}
