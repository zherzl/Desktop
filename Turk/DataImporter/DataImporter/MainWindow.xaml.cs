using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
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
using System.Windows.Threading;
using System.Diagnostics;
using DataImporter.Config;
using log4net;
using log4net.Config;
using DataImporter.Repository.Source;
using DataImporter.Repository;

namespace DataImporter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public List<string> PathNames
        {
            get; set;
        }
        public string Extension { get; set; }
        

        BackgroundWorker bw = new System.ComponentModel.BackgroundWorker();

        public MainWindow()
        {
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            InitializeComponent();
            this.Extension = txtExtension.Text;
            this.bw.DoWork += Bw_DoWork;
            this.bw.RunWorkerCompleted += Bw_RunWorkerCompleted;
            this.bw.ProgressChanged += Bw_ProgressChanged;
            this.bw.WorkerReportsProgress = true;
            this.PathNames = GetPathNames();
        }

        private List<string> GetPathNames()
        {
            List<string> _pathNames = new List<string>();

            foreach (ListBoxItem item in lbFilePaths.Items)
                _pathNames.Add(item.Content.ToString());

            return _pathNames;
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            //ReadFiles();
            btnStart.IsEnabled = false;
            bw.WorkerSupportsCancellation = true;
            bw.RunWorkerAsync();
        }   
                

        private void btnStop_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Send,
              new Action(() => stopThreads()));
        }

        private void stopThreads()
        {
            Dispatcher.InvokeShutdown();
        }

        private void Bw_DoWork(object sender, DoWorkEventArgs e)
        {
            //LoopInfinite();
            ReadFiles();
        }

        private void Bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            string result = e.UserState.ToString();
            int files = e.ProgressPercentage;
            this.lboxInfo.Items.Insert(0, new ListBoxItem { Content = string.Format("{0}. {1}",  files, result) });
        }

        private void Bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.lboxInfo.Items.Insert(0, new ListBoxItem { Content = "Import done" });
        }

        private void ReadFiles()
        {
            // Don't forget to change this
            // Repository can be only one instance per import -> calculated data is sent to list within repo class
            Repo r = new Repo();
            int counter = 0;

            //new ReadFiles(bw).StartProcessing(@"E:\Turk", Extension, r.GetLatestImportTime(), r, ref counter);
            foreach (var path in PathNames)
            {
                string tmpPath = path;
                if (Directory.Exists(tmpPath))
                {
                    // Working mode
                    new ReadFiles(bw).StartProcessing(tmpPath, Extension,  r.GetLatestImportTime(), r, ref counter);
                }
            }

            r.SaveDataToDatabase();
        }

        


        #region Just for testing
        int i = 1;
        private void LoopInfinite()
        {
            while (true)
            {
                Dispatcher.BeginInvoke(DispatcherPriority.Background, GenerateNewItem());
            }
        }

        private Action GenerateNewItem()
        {
            return new Action(() => this.lboxInfo.Items.Insert(0, new ListBoxItem { Content = "New item" + (++i) }));
        }
        #endregion



    }
}
