using GTA_SA_CarHandling.Interfaces;
using GTA_SA_CarHandling.Text;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
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

namespace GTA_SA_CarHandling
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IView
    {
        public string Configuration { get; set; }
        ReadResource resourceRdr;

        public MainWindow()
        {
            InitializeComponent();
            resourceRdr = new ReadResource(this);
            Configuration = resourceRdr.LoadConfig();
        }

       

        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SetInfo(null);
                SetInfo(ReadResource.GetOriginalFileContent());
            } 
            catch (Exception ex)
            {
                SetInfo(ex.Message);
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            SetInfo(null);
        }

        

        public void SetInfo(string message)
        {
            lblInfo.Text = message;
        }

        
    }
}
