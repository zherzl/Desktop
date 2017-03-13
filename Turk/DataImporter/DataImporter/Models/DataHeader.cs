using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataImporter.Models
{
    class DataHeader
    {
        public string HeaderName { get; set; }
        public string MeasurementUnit { get; set; }
        public double Value { get; set; }
    }
}
