using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataImporter.Repository.Source
{
    interface ISource
    {
        void StartProcessing(string pathname, string extension, DateTime dateFrom, Repo r, ref int counter);
    }
}
