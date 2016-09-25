using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace GTA_SA_CarHandling
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string ConfigName { get { return "GtaSa_HandlingConfig.ini"; }  }
        public string LastLoadedFile { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            LoadConfig();
        }

        private void LoadConfig()
        {
            string file = Directory.GetCurrentDirectory() + ConfigName;

            if (File.Exists(file))
            {
                LastLoadedFile = File.ReadAllText(file);
                LoadData(LastLoadedFile);
            }
        }

        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            SetInfo(null);
            LoadData(null);
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            SetInfo(null);
        }

        private void LoadData(string fileName)
        {
            try
            {
                string entireFile = null;

                if (string.IsNullOrEmpty(fileName))
                {
                    entireFile = LoadFromDialog();
                    SetInfo("File loaded from dialog");
                }
                else
                {
                    entireFile = File.ReadAllText(fileName);
                    SetInfo("File loaded from " + fileName);
                }
                
            }
            catch (Exception ex)
            {
                SetInfo(ex.Message);
            }
        }

        private string LoadFromDialog()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "CFG files (*.cfg)|*.cfg";
            string entireFile = null;

            if (ofd.ShowDialog() != null)
            {
                entireFile = File.ReadAllText(ofd.FileName);
                WriteConfig(ofd.FileName);
            }

            return entireFile;
        }

        private void WriteConfig(string fileName)
        {
            File.WriteAllText(Directory.GetCurrentDirectory() + ConfigName, fileName);
        }

        


        private void SetInfo(string message)
        {
            if (string.IsNullOrEmpty(message))
            {
                lblInfo.Text = "";
            }
            else
            {
                lblInfo.Text = message;
            }
        }

        
    }
}
