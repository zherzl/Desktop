using GTA_SA_CarHandling.Interfaces;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GTA_SA_CarHandling.Text
{
    public class ReadResource
    {
        public string ConfigName { get { return "GtaSa_HandlingConfig.ini"; } }
        public string LastLoadedFile { get; set; }
        IView view;

        public ReadResource(IView view)
        {
            this.view = view;
        }

        public static string GetOriginalFileContent()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            const string name = "GTA_SA_CarHandling.Text.handling.cfg";
            
            // It's mandatory to set file property "Build action" to Embedded Resource
            using (Stream stream = assembly.GetManifestResourceStream(name))
            {
                using (StreamReader rdr = new StreamReader(stream))
                {
                    return rdr.ReadToEnd();
                }
            }
        }


        public string LoadConfig()
        {
            string file = Directory.GetCurrentDirectory() + ConfigName;
            string entireFile = null;

            if (File.Exists(file))
            {
                LastLoadedFile = File.ReadAllText(file);
                entireFile = GetTextFromFile(LastLoadedFile);
            }

            return entireFile;
        }


        private string GetTextFromFile(string fileName)
        {
            string entireFile = null;

            try
            {
                if (string.IsNullOrEmpty(fileName))
                {
                    entireFile = LoadFromDialog();
                    view.SetInfo("File loaded from dialog");
                }
                else
                {
                    entireFile = File.ReadAllText(fileName);
                    view.SetInfo("File automatically loaded from " + fileName);
                }
            }
            catch (Exception ex)
            {
                view.SetInfo(ex.Message);
            }

            return entireFile;
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
    }
}
