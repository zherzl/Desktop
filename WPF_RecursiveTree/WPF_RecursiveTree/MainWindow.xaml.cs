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

namespace WPF_RecursiveTree
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

        private void btnGo_Click(object sender, RoutedEventArgs e)
        {
            List<String> path = new List<string>(Directory.EnumerateDirectories(@"D:\"));
            Go(path);
        }

        private void Go(List<String> path)
        {
            foreach (String file in path)
            {
                try
                {
                    if (File.Exists(file))
                    {
                        // It's a file 
                        ProcessFile(file);
                    }
                    else if (Directory.Exists(file))
                    {
                        // It's a directory
                        System.Diagnostics.Debug.WriteLine("D-I-R-E-C-T-O-R-Y: \t" + file);
                        GoDir(file);
                    }
                }
                catch (Exception)
                {
                }
                
            }
        }

     

        private void GoDir(String path)
        {
            String[] dirs = Directory.GetDirectories(path);


            // Process the list of files found in the directory. 
            string[] fileEntries = Directory.GetFiles(path, "*.txt");
            foreach (string fileName in fileEntries)
                ProcessFile(fileName);

            // Recurse into subdirectories of this directory. 
            string[] subdirectoryEntries = Directory.GetDirectories(path);
            foreach (string subdirectory in subdirectoryEntries)
                GoDir(subdirectory);

        }

        private void ProcessFile(string fileName)
        {
            System.Diagnostics.Debug.WriteLine(fileName);
        }
    }
}
