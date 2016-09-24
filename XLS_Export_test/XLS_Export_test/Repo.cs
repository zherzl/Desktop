using System;
using System.Collections.Generic;
using System.Data;

namespace XLS_Export_test
{
    internal class Repo
    {
        internal static DataTable GetData()
        {
            DataTable dt = new DataTable("ppl");
            dt.Columns.Add(new DataColumn("Age", typeof(Int16)));
            dt.Columns.Add(new DataColumn("City", typeof(String)));
            dt.Columns.Add(new DataColumn("Name", typeof(String)));
            //DataColumn name = new DataColumn("Name", typeof(String));

            foreach (var item in People)
            {
                DataRow row = dt.NewRow();

                row["Age"] = item.Age;
                row["City"] = item.City;
                row["Name"] = item.Name;

                dt.Rows.Add(row);
            }

            return dt;
        }


        public static Person[] People = new Person[]
        {
            new Person { Age = 25, City = "Kutina", Name = "Sharp" },
            new Person { Age = 35, City = "Zagreb", Name = "Dada" }
        };
    }
}