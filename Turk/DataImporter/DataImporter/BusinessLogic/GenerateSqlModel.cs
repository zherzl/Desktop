using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataImporter.Models;
using System.Reflection;
using DataImporter.ExtensionMethods;

namespace DataImporter.BusinessLogic
{
    class GenerateSqlModel
    {
        private List<Channel> channels;
        private List<string> headers;
        private List<HistoricalData> historicalData;
        private List<string> mUnits;
        //private SqlModel sqlModel;
        SIO2_Logs sqlModel;
        private List<SummaryData> summaryData;

        public GenerateSqlModel(SIO2_Logs sqlModel, List<Channel> channels, List<string> headers, List<string> mUnits, List<HistoricalData> historicalData, List<SummaryData> summaryData)
        {
            this.sqlModel = sqlModel;
            this.channels = channels;
            this.headers = headers;
            this.mUnits = mUnits;
            this.historicalData = historicalData;
            this.summaryData = summaryData;
        }

        string currentProp = "";
        decimal currentVal = 0.0m;

        internal void CalculateAverage()
        {
            // Loop all channels and find values from HistoricalData
            //for (int i = 0; i < channels.Count; i++)
            //{
            //    string channelName = channels[i].DataHeaderName;
            //}

            // Limit properties only to values
            PropertyInfo[] propInfos = typeof(SIO2_Logs).GetProperties().Where(pi => pi.GetCustomAttributes(typeof(SkipPropertyAttribute), true).Length == 0).ToArray();
            List<double> tmpValues;
            List<decimal> tmpValuesFinal;

            foreach (PropertyInfo prop in propInfos)
            {
                try
                {
                    currentProp = prop.Name;

                    // Checking is not needed because the data will either exist or not for the same file...so channels are actually just in case
                    if (channels.Select(x => x.DataHeaderName).Contains(prop.Name))
                    {
                        tmpValues = ListOfValuesForCurrentColumn(prop.Name);

                        double avg = tmpValues.Average();
                        decimal stDev = (decimal)tmpValues.Stdev(avg);

                        decimal lowerLimit = (decimal)avg - 3 * stDev;
                        decimal upperLimit = (decimal)avg + 3 * stDev;

                        // Copy to new collection rather then removing because elements can't be checked and removed in one go
                       tmpValuesFinal = new List<decimal>();

                        foreach (decimal val in tmpValues)
                        {
                            if (val >= lowerLimit && val <= upperLimit)
                            {
                                tmpValuesFinal.Add(val);
                            }
                        }

                        decimal avgFin = tmpValuesFinal.Average();

                        currentVal = avgFin;

                        if (prop.PropertyType.FullName == typeof(decimal).ToString())
                            prop.SetValue(sqlModel, avgFin);
                        else
                            prop.SetValue(sqlModel, avgFin.ToString());
                    }
                    else
                    {
                        if (prop.PropertyType.FullName == typeof(decimal).ToString())
                            prop.SetValue(sqlModel, 0.0m);
                        else prop.SetValue(sqlModel, "");
                    }
                }
                catch (Exception ex)
                {
                    string m = "prop: " + currentProp + " val: " + currentVal + " " + ex.Message;
                }
                
            }
        }



        private List<double> ListOfValuesForCurrentColumn(string colName)
        {
            List<double> tmp = new List<double>();

            foreach (HistoricalData item in historicalData)
            {
                if (item.HeaderName.Equals(colName) && item.Value.HasValue && item.CurrentStepNumberValue == 3)
                {
                    tmp.Add(Math.Abs(item.Value.Value));
                }
            }

            return tmp;
        }



        //private decimal CalculateAverage(List<decimal> propertyValues)
        //{
        //    decimal result = 0.0;
        //    int count = 0;

        //    foreach (decimal val in propertyValues)
        //    {
        //        result += val;
        //        count++;
        //    }

        //    return result / count;
        //}




    }
}
