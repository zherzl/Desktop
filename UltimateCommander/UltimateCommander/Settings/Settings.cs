using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace UltimateCommander.Settings
{
    public enum SettingType
    {
        ColDefLeftList
    }
    public class AppSettings
    {
        public string CurrDir
        {
            get { return Directory.GetCurrentDirectory() + @"\Settings"; }
        }
        private string fileName;

        /// <summary>
        /// Constructor gets current directory so it knows where to save settings
        /// </summary>
        public AppSettings()
        {
            fileName = CurrDir + @"\Settings.txt";
        }

        /// <summary>
        /// File name to preserve settings
        /// </summary>
        public String FileName
        {
            get { return this.fileName; }
        }


        private double colDefLeftListValue;
        private ColumnDefinition colDefLeftList;
        
        /// <summary>
        /// Storing ratio between File list panes (value applies only to left pane -> right pane size adjusts automatically)
        /// Two properties are used. double type is for storing and ColumnDefinition type for loading as it contains * as parameter but is read-only
        /// </summary>
        public double ColDefLeftListValue
        {
            get { return colDefLeftListValue; }
            set { colDefLeftListValue = value; }
        }
        public ColumnDefinition ColDefLeftList
        {
            get 
            {
                if (colDefLeftList == null)
                    colDefLeftList = new ColumnDefinition();
                return colDefLeftList; 
            }
        }

        public double GridRowBottRatio { get { throw new NotImplementedException(); } }   // Presents size of bottom row 


        
    }

    
    /// <summary>
    /// Class is used only to retrieve Data for View-Model and create an instance
    /// </summary>
    public static class SettingsLoader
    {
        public static AppSettings LoadData()
        {
            AppSettings set = new AppSettings();

            if (System.IO.File.Exists(set.FileName))
            {
                System.IO.StreamReader reader = new System.IO.StreamReader(set.FileName);
                String line = "";

                while ((line = reader.ReadLine()) != null)
                {
                    String splitterSetting = line; // For testing only
                    
                    String type = line.Split('=')[0];
                    if (type.Equals(SettingType.ColDefLeftList.ToString()))
                    {
                        set.ColDefLeftListValue = Double.Parse(line.Split('=')[1]); // First write double type then object type
                        set.ColDefLeftList.Width = new GridLength(set.ColDefLeftListValue, GridUnitType.Star);
                    }
                    
                    

                }
                reader.Close();
            }

            return set;
        }
    }
}
