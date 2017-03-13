using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataImporter.ExtensionMethods
{
    static class Calculations
    {
        public static double Stdev(this List<double> doubleValues, double average)
        {
            double sumOfSquaresOfDifferences = doubleValues.Select(val => (val - average) * (val - average)).Sum();
            double sd = Math.Sqrt(sumOfSquaresOfDifferences / doubleValues.Count);
            return sd;
        }
    }
}
