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
    public class ResourceBuilder
    {
        private string ConfigName { get { return "GtaSa_HandlingConfig.ini"; } }
        private string LastLoadedFile { get; set; }

        IView view;

        public ResourceBuilder(IView view)
        {
            this.view = view;
        }

       


        /// <summary>
        /// If config file exists in app folder, it will also try to load last known file path written in config
        /// </summary>
        /// <returns></returns>
        public string LoadConfig()
        {
            string file = Directory.GetCurrentDirectory() + ConfigName;

            if (File.Exists(file))
            {
                LastLoadedFile = File.ReadAllText(file);
                return LastLoadedFile;
            }

            return null;
        }

        private void WriteConfig(string fileName)
        {
            File.WriteAllText(Directory.GetCurrentDirectory() + ConfigName, fileName);
        }

        /// <summary>
        /// Pass null to load from Open file dialog
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public string GetFileName(string fileName)
        {
            string handlingFile = null;

            try
            {
                if (string.IsNullOrEmpty(fileName))
                {
                    LoadFromDialog(ref handlingFile);
                    view.SetInfo("File loaded from dialog");
                }
                else
                {
                    handlingFile = File.ReadAllText(fileName);
                    view.SetInfo("File automatically loaded from " + fileName);
                }
            }
            catch (Exception ex)
            {
                view.SetInfo(ex.Message);
            }

            return handlingFile;
        }


        private void LoadFromDialog(ref string handlingFile)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "CFG files (*.cfg)|*.cfg";

            if (ofd.ShowDialog() != null)
            {
                handlingFile = ofd.FileName;
                WriteConfig(ofd.FileName);
            }
        }

        
    }
}
