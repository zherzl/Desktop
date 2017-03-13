using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataImporter.Models
{
    class HistoricalData
    {
        public int CurrentStepNumberValue { get; internal set; }
        public string HeaderName { get; set; }
        public double? Value { get; set; }
        public int ColumnNumber { get; set; }
        public int RowNumber { get; set; }

        public override string ToString()
        {
            return string.Format("Step Nr: {0} Header: {1}, Value: {2}, ColNr: {3}, RowNr: {4}", CurrentStepNumberValue, HeaderName, Value.Value, ColumnNumber, RowNumber);
        }
    }
}
