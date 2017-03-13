using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataImporter.Models;
using System.Data;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using System.Data.Entity.Validation;
using DataImporter.Config;

namespace DataImporter.Repository.Sql
{
    class SqlRepo : IRepo
    {
        DateTime dtLast = DateTime.MinValue;

        public DateTime GetLatestImportTime()
        {
            using (ImportDataContext db = new ImportDataContext())
            {
                if (db.SIO2_Logs != null && db.SIO2_Logs.Count() > 0)
                {
                    dtLast = db.SIO2_Logs.OrderBy(x => x.ImportDate).FirstOrDefault().ImportDate;
                }
            }

            if (dtLast == DateTime.MinValue)
            {
                dtLast = DateTime.Today.AddDays(-14);
            }

            return dtLast;
        }

        public void SaveDataToDatabase(List<SIO2_Logs> importData)
        {
            ImportDataContext db = new ImportDataContext();
            DateTime dtImport = DateTime.Now;
            List<SIO2_Logs> lastLogs = db.SIO2_Logs.ToList();

            foreach (SIO2_Logs sl in importData)
            {
                try
                {
                    // Check if file is already imported
                    if (lastLogs != null && lastLogs.Count(x => x.FileName.Equals(sl.FileName)) == 0)
                    {
                        sl.ImportDate = dtImport;
                        db.SIO2_Logs.Add(sl);
                    }
                    db.SaveChanges();
                }
                catch (DbEntityValidationException e)
                {
                    foreach (var eve in e.EntityValidationErrors)
                    {
                        Logger.Log("Save context", "", string.Format("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:", eve.Entry.Entity.GetType().Name, eve.Entry.State));
                        foreach (var ve in eve.ValidationErrors)
                        {
                            Logger.Log("- Property: \"{0}\", Error: \"{1}\"", ve.PropertyName, ve.ErrorMessage);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Logger.Log("Save context file skipped: ", sl.FileName, ex.Message);
                }

                

                //catch (Exception ex)
                //{
                //    if (ex.InnerException != null)
                //    {
                //        Logger.Log("Save context", "", ex.InnerException.InnerException.Message);
                //    }
                //    else
                //    {
                //        Logger.Log("Save context", "", ex.Message);
                //    }
                //}
            }
            db.Dispose();
        }


    }



}
