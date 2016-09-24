using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Controls;
using System.IO;
using System.Windows;

namespace UltimateCommander.Settings
{
    public class SettingsVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private AppSettings sett;

        public SettingsVM(AppSettings settings)
        {
            this.sett = settings;
            PropertyChanged += SettingsVM_PropertyChanged;
        }

        void SettingsVM_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            SaveData();
        }



        public double ColDefLeftListValue
        {
            get { return sett.ColDefLeftListValue; }
            set 
            {
                sett.ColDefLeftListValue = value; 
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("ColDefLeftListValue"));
                }
            }
        }

        public ColumnDefinition ColDefLeftList
        {
            // Setter is never called as it is read-only property
            get { return sett.ColDefLeftList; }
        }

        


        /// <summary>
        /// File name to preserve settings
        /// </summary>
        public String FileName
        {
            get { return sett.FileName; }
        }


        /// <summary>
        /// Save settings in Settings subfolder
        /// </summary>
        public void SaveData()
        {
            if (!Directory.Exists(sett.CurrDir))
                Directory.CreateDirectory(sett.CurrDir);

            using (StreamWriter writer = new StreamWriter(FileName))
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(String.Format("{0}={1}", SettingType.ColDefLeftList, ColDefLeftListValue));

                writer.Write(sb.ToString()); // testing writing only 1 setting
            }
        }



        internal void ResetSetting(SettingType settingPropertyType, object value)
        {
            // Change to Enum not string
            if (settingPropertyType.Equals(SettingType.ColDefLeftList))
            {
                ColDefLeftListValue = (double)value;
                ColDefLeftList.Width = new System.Windows.GridLength(ColDefLeftListValue, System.Windows.GridUnitType.Star);
            }
        }


    }
}
