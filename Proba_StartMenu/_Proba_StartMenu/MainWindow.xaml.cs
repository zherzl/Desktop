using Microsoft.Win32;
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
using System.Runtime.InteropServices;

namespace _Proba_StartMenu
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            GetSomeWindow("XYplorer");
            DoSomething();
        }

        #region Win API 
        [DllImport("user32.dll")]
        public static extern IntPtr FindWindow(String sClassName, String sAppName);

        [DllImport("user32.dll", EntryPoint = "GetDesktopWindow")]
        public static extern int GetDesktopWindow();

        [DllImport("User32.dll")]
        public static extern Boolean EnumChildWindows(int hWndParent, Delegate lpEnumFunc, int lParam);
        #endregion

        private void GetSomeWindow(string v)
        {
            int desktopId = GetDesktopWindow();
            IntPtr window = FindWindow(v, null);
        }

        

        void DoSomething()
        {
            List<string> popisAplikacija = new List<string>();
            string registry_key = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall";

            using (Microsoft.Win32.RegistryKey key = Registry.LocalMachine.OpenSubKey(registry_key))
            {
                List<string> aplikacije = new List<string>();
                aplikacije.AddRange(key.GetSubKeyNames());
                

                foreach (string subkey_name in aplikacije)
                {
                    using (RegistryKey subkey = key.OpenSubKey(subkey_name))
                    {
                        string[] imena = subkey.GetValueNames();
                        var naziv = subkey.GetValue("DisplayName");

                        if (naziv != null)
                            popisAplikacija.Add(naziv.ToString());
                    }
                }
            }

            lista.Items.Clear();
            lista.ItemsSource = popisAplikacija.OrderBy(x => x);
        }
    }


}
