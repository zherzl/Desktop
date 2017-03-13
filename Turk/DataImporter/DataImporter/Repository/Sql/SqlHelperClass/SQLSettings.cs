using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace DataImporter.Repository.Sql.SqlHelperClass
{
    class SQLSettings
    {
        public static string TestCS { get { return System.Configuration.ConfigurationManager.ConnectionStrings["TestSql"].ConnectionString; }  }
        public static string MachineLogCS { get { return System.Configuration.ConfigurationManager.ConnectionStrings["Machine_log"].ConnectionString; }  }
    }
}
