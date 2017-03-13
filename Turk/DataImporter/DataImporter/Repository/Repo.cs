using DataImporter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataImporter.Repository
{
    class Repo
    {
        IRepo repo;
        DateTime dt = DateTime.MinValue;

        public List<SIO2_Logs> ImportData { get; set; }
        public Repo()
        {
            this.ImportData = new List<SIO2_Logs>();
            this.repo = Factory.FactoryRepo.SqlRepo();
        }

        public DateTime GetLatestImportTime()
        {
            if (dt == DateTime.MinValue)
            {
                dt = repo.GetLatestImportTime();
            }
            return dt;
        }

        public void SaveDataToDatabase()
        {
            

            if (ImportData.Count > 0)
            {
                repo.SaveDataToDatabase(ImportData);
            }
        }


    }
}
