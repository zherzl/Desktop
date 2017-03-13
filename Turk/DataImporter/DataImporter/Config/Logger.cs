using log4net;
using log4net.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataImporter.Config
{
    class Logger
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static void Log(string method, string file, string text)
        {
            log.Info(string.Format("Method: {0} File: {1} Message: {2}", method, file, text));
        }
    }
}
