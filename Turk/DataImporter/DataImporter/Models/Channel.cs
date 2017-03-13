using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataImporter.Models
{
    class Channel
    {
        public string ChannelNumber { get; set; }
        public string DataHeaderName { get; set; }
        public string Period { get; set; }
        public int Samples { get; set; }
    }
}
