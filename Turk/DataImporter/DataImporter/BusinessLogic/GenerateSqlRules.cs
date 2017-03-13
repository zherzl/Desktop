using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataImporter.BusinessLogic
{
    class GenerateSqlRules
    {
        static GenerateSqlRules sqlRules = new GenerateSqlRules();

        public static string CurrentStepNumberPos { get { return "CurrentStepNumber"; } }
        public static string Pcma2060_Machine_ID { get { return "13"; } }
        public static string Pcma3020_Machine_ID { get { return "18"; } }
        public static string Pcma3076_Machine_ID { get { return "19"; } }
        public static string Pcma3210_Machine_ID { get { return "91"; } }
        public static string Pcma3778_Machine_ID { get { return "93"; } }
        public static string Pcma3880_Machine_ID { get { return "94"; } }
        public static string Pcma4259_Machine_ID { get { return "95"; } }
        public static string Pcma4319_Machine_ID { get { return "123"; } }

        public static string GetMachineId(string pcma)
        {
            PropertyInfo[] propInfos = typeof(GenerateSqlRules).GetProperties();

            foreach (PropertyInfo prop in propInfos)
            {
                if (prop.Name.ToLower().Contains(pcma))
                {
                    string val = prop.GetValue(sqlRules.GetType().GetProperty(prop.Name).GetValue(sqlRules, null)).ToString();
                    return val;
                }
            }

            return "-";
        }


        
    }
}
