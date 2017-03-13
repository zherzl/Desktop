using DataImporter.Repository.Source;
using DataImporter.Repository.Source.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using DataImporter.Repository.Sql;
using DataImporter.Repository.Txt;

namespace DataImporter.Repository.Factory
{
    static class FactoryRepo
    {
        enum RepoType
        {
            Sql, Txt
        }

        internal static ISource SourceRepo(BackgroundWorker bw)
        {
            return new ReadTextFilesImpl(bw);
        }

        public static IRepo SqlRepo()
        {
            // This should be moved to ini file and red from there
            RepoType rType = RepoType.Txt;

            switch (rType)
            {
                case RepoType.Sql:
                    return new SqlRepo();
                case RepoType.Txt:
                    return new TxtRepo();
                default:
                    break;
            }
            return null;
        }
    }
}
