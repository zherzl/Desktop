using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataImporter.Repository.Factory;
using System.ComponentModel;

namespace DataImporter.Repository.Source
{
    class ReadFiles
    {
        ISource repo;
        
        public ReadFiles(BackgroundWorker bw)
        {
            this.repo = FactoryRepo.SourceRepo(bw);
        }

        public void StartProcessing(string pathname, string extension, DateTime dateFrom, Repo r, ref int counter)
        {
            repo.StartProcessing(pathname, extension, dateFrom, r, ref counter);
        }


    }
}
