using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataImporter.Config
{
    static class ParseRules
    {
        // This properties serve as markers
        // 1. Line rules
        public static string HistoricalDataLogger { get { return "HistoricalDataLogger file:"; } }
        
        public static string L1_0PathEnd { get { return @"\"; } }
        public static string WaferId { get { return "waferId"; } }
        // Equipment info
        //public static string Equipment { get { return "Equipment:"; } }
        public static string PC { get { return "pcma"; } }
        // Channel data beginning
        public static string ChannelRow { get { return "Channel "; } }
        public static string ChannelRow2 { get { return "name"; } }
        public static string ChannelUndefined { get { return "undefined"; }  }
        // Data beginning
        public static string HistoricalDataStart { get { return "HistoricalData:"; }  }

        // Process sequence summary
        public static string Summary { get { return "Process sequence summary:"; } }

        public static string CurrentStepNumber { get { return "CurrentStepNumber"; }  }

        public static List<string> IgnoredStrings = new List<string> { "---", " " };
    }
}
