using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataImporter.Config;
using DataImporter.Models;
using DataImporter.BusinessLogic;
using System.Text.RegularExpressions;

namespace DataImporter.Repository.Source.Implementation
{
    class ReadTextFilesImpl : ISource
    {
        string _ext;
        private BackgroundWorker bw;
        int colNo = 0;
        int rowNo;
        Repo r;

        public string PathName { get; set; }
        public string Extension { get { return string.Format("*.{0}", _ext); } set { _ext = value; } }
        public DateTime DateFrom { get; set; }

        SIO2_Logs sqlModel;
        List<Channel> channels;
        List<string> headers;
        List<string> mUnits;
        List<HistoricalData> historicalDataList;
        List<SummaryData> summaryData;

        Stopwatch sw = new Stopwatch();

        public ReadTextFilesImpl(BackgroundWorker bw)
        {
            this.bw = bw;
        }

        public void StartProcessing(string pathname, string extension, DateTime dateFrom, Repo r, ref int counter)
        {
            this.PathName = pathname;
            this.Extension = extension;
            this.DateFrom = dateFrom;
            //sw.Start();
            this.r = r;
            ProcessDirectory(PathName, ref counter);

            //sw.Stop();
            //System.Windows.MessageBox.Show(sw.Elapsed.ToString());

        }



        // Process all files in the directory passed in, recurse on any directories 
        // that are found, and process the files they contain.
        public void ProcessDirectory(string targetDirectory, ref int counter)
        {

            // Process the list of files found in the directory.
            string[] fileEntries = Directory.GetFiles(targetDirectory, Extension, SearchOption.TopDirectoryOnly);

            foreach (string fileName in fileEntries)
            {
                if (File.GetCreationTime(fileName) > DateFrom)
                {
                    // Report background progress if is multithreading
                    if (bw != null)
                    {
                        bw.ReportProgress(++counter, fileName);
                    }

                    ParseLinesToRawModel(fileName);
                }
                else
                {
                    //Logger.Log("Process Dir", "File ", fileName + " is older then import checkpoint");
                }
            }

            // Recurse into subdirectories of this directory.
            foreach (string subdirectory in Directory.GetDirectories(targetDirectory).Reverse())
            {
                try
                {
                    ProcessDirectory(subdirectory, ref counter);
                }
                catch (Exception ex)
                {
                    // If folder is not accessible, it will be logged silently
                    Logger.Log("ProcessDirectory", PathName, ex.Message);
                }
            }

        }



        public void ParseLinesToRawModel(string path)
        {
            // Useful for debugging
            rowNo = 0;
            // Reset for next file
            sqlModel = new SIO2_Logs();
            channels = new List<Channel>();
            headers = new List<string>();
            mUnits = new List<string>();
            historicalDataList = new List<HistoricalData>();
            summaryData = new List<SummaryData>();

            string line;
            // Once we find HistoricalData, 
            bool isDataRow = false;
            bool isSummaryRow = false;
            // Variable used to read hist. data -> 0 = read headers, 1 = read units, 2 = data
            int n = 0;

            using (StreamReader rdr = new StreamReader(path))
            {
                while ((line = rdr.ReadLine()) != null)
                {
                    rowNo++;

                    if (line.Contains(ParseRules.HistoricalDataLogger)) ProcessFileName(line, sqlModel);
                    else if (line.Contains(ParseRules.WaferId)) ProcessWaferRecipe(line, sqlModel);
                    else if (line.Contains(ParseRules.PC)) ProcessEquipment(line, sqlModel);
                    else if (line.Contains(ParseRules.ChannelRow) && line.Contains(ParseRules.ChannelRow2)) ProcessChannels(line, channels, path);

                    // 1. Once we run into historical data marker, switch isDataRow to true, and data parsing begins
                    // 2. When we run into summary data marker, switch off data parsing, and start summary parsing
                    else if (line.Contains(ParseRules.HistoricalDataStart))
                        isDataRow = true;
                    else if (isDataRow && !line.Contains(ParseRules.Summary))
                    {
                        if (n == 0)
                        {
                            // Read headers and force reader to go to next row
                            ReadHeaders(line, ref n, headers);
                            continue;
                        }
                        else if (n == 1)
                        {
                            // Not needed, just in case
                            ReadMeasurementUnits(line, ref n, mUnits);
                            continue;
                        }
                        else
                            ReadHistoricalData(line, historicalDataList, headers, path);
                    }
                    else if (line.Contains(ParseRules.Summary))
                    {
                        // This condition cancels historical data parsing and initiates summary parsing by forcing reader to go for next row
                        isDataRow = false;
                        isSummaryRow = true;
                        continue;
                    }
                    else if (isSummaryRow)
                    {
                        ReadSummaryData(line, summaryData, path, ref isSummaryRow);
                    }
                }
            }

            if (headers.Contains(ParseRules.CurrentStepNumber))
            {
                // Prepare and insert data into sqlModel
                new GenerateSqlModel(sqlModel, channels, headers, mUnits, historicalDataList, summaryData).CalculateAverage();
                r.ImportData.Add(sqlModel);
            }

            //ReverseToRawDataForDebugging(historicalDataList);
            //sbTmp.Insert(1, string.Join("\t", headers) + Environment.NewLine);
            //System.IO.File.WriteAllText(@"D:\proba.txt", sbTmp.ToString());
        }

        #region Debug only

        // This is very complex task to do, but it can help in extreme debugging situations -> return parsed data to original
        private void ReverseToRawDataForDebugging(List<HistoricalData> historicalDataList)
        {
            historicalDataList = historicalDataList.OrderBy(x => x.RowNumber).ThenBy(y => y.ColumnNumber).ToList();
            sbTmp = new StringBuilder();

            for (int i = 0; i < historicalDataList.Count; i++)
            {
                int currentRowNo = historicalDataList[i].RowNumber;
                string val = historicalDataList[i].Value.ToString();
                sbTmp.Append(string.Format("{0:0.00}", historicalDataList[i].Value));

                // Tab if going for next column, newline if new row is current value
                if (i < historicalDataList.Count - 1 && historicalDataList[i].RowNumber < historicalDataList[i + 1].RowNumber)
                {
                    sbTmp.Append(Environment.NewLine);
                    var currentRowHeaders = historicalDataList.Where(x => x.RowNumber == currentRowNo).OrderBy(o => o.ColumnNumber).Select(z => z.HeaderName).ToList();
                    string hTmp = string.Join("\t", currentRowHeaders);
                    
                    // Append headers and new line again
                    sbTmp.Append(hTmp);
                    sbTmp.Append(Environment.NewLine);
                }
                else
                {
                    sbTmp.Append("\t");
                }
            }


        }
        #endregion


        #region Header of the file etc (non data rows)
        private void ProcessFileName(string line, SIO2_Logs sqlModel)
        {
            try
            {
                // Here goes the logic: 
                // 1. We are looking for end of path (\ character) -> Filename is everything after that
                // 2. Split line by '.' separator and row is splitted in array
                // 3. Extract file type from position 0 - depending if file has std or process in filename (a bit more splitting)
                // 4. Write text from array into variables
                int indexOfPathEnd = line.LastIndexOf(ParseRules.L1_0PathEnd) + 1;
                string fileName = line.Substring(indexOfPathEnd, line.Length - indexOfPathEnd);

                string[] splitByDot = line.Split('.');
                DateTime date = GenerateDateTimeHeader(splitByDot[3], splitByDot[4]);

                sqlModel.FileName = fileName;
                sqlModel.DateAndTime = date;
                sqlModel.Lotnumber = splitByDot[1];
                sqlModel.ProcessID = ExtractText(splitByDot[2]);
                sqlModel.Slotnumber = ExtractNumbers(splitByDot[2]);

                if (line.ToLower().Contains("std"))
                {
                    string[] splitProcessAndFileType = splitByDot[0].Split('\\');
                    string[] std_pm = splitProcessAndFileType[2].Split('_');
                    sqlModel.Filetpye = std_pm[0];
                    sqlModel.Processmodul = std_pm[1];
                }
                else if (line.ToLower().Contains("process"))
                {
                    string[] splitProcessAndFileType = splitByDot[0].Split('\\');
                    sqlModel.Filetpye = splitProcessAndFileType[1];
                    sqlModel.Processmodul = splitProcessAndFileType[2];
                }
                else
                    throw new Exception("File structure not recognized:");

            }
            catch (Exception ex)
            {
                Logger.Log("ProcessFileName method", PathName, ex.Message);
            }

        }

        private string ExtractNumbers(string text)
        {
            string s = "";
            int i = 0;

            foreach (char c in text)
            {
                if (Char.IsDigit(c) && i < 2)
                {
                    s += c;
                    i++;
                }
            }

            return s;
        }

        private string ExtractText(string text)
        {
            string s = "";
            int i = 0;

            foreach (char c in text)
            {
                if (Char.IsLetter(c) && i < 2)
                {
                    s += c;
                    i++;
                }
            }

            return s;
        }

        

        private DateTime GenerateDateTimeHeader(string dateString, string timeString)
        {
            string[] dateSplitted = dateString.Split('-');
            string[] timeSplitted = timeString.Split('-');

            return new DateTime(int.Parse(dateSplitted[2]), int.Parse(dateSplitted[0]), int.Parse(dateSplitted[1]),
                                int.Parse(timeSplitted[0]), int.Parse(timeSplitted[1]), int.Parse(timeSplitted[2]));
        }

        private void ProcessWaferRecipe(string line, SIO2_Logs sqlModel)
        {
            char[] delimiters = new char[] { ' ', '\t' };
            string[] splittedLine = line.Split(delimiters);
            sqlModel.HeaderWaferID = splittedLine[3];
            sqlModel.Recipe = splittedLine[5];
        }

        private void ProcessEquipment(string line, SIO2_Logs sqlModel)
        {
            //sqlModel.Machine_ID = "";
            sqlModel.PCName = "-";

            char[] delimiters = new char[] { ' ', '#' };
            string[] splittedLine = line.Split(delimiters);

            for (int i = 0; i < splittedLine.Length; i++)
            {
                if (splittedLine[i].ToLower().Contains(ParseRules.PC))
                {
                    sqlModel.PCName = splittedLine[i];
                }
            }

            sqlModel.Machine_ID = GenerateSqlRules.GetMachineId(sqlModel.PCName);
        }

        #endregion


        #region Channels
        private void ProcessChannels(string line, List<Channel> channels, string fileName)
        {
            string[] splittedRow = line.Split('\t');
            Channel ch = new Channel();

            try
            {
                ch.ChannelNumber = splittedRow[0];
                ch.DataHeaderName = splittedRow[2];
                ch.Period = splittedRow[3].Split('=')[1];

                if (line.Contains(ParseRules.ChannelUndefined))
                {
                    // Not sure what this row means, but it exists in some files, and it's skipped so far... no regular data in it
                    ch.Samples = 0;
                }
                else
                {
                    ch.Samples = int.Parse(splittedRow[4].Split(' ')[0]);
                    channels.Add(ch);
                }
            }
            catch (Exception ex)
            {
                Logger.Log("Channels", fileName, ex.Message);
            }
        }
        #endregion


        #region Historical Data
        private void ReadHeaders(string line, ref int n, List<string> headers)
        {
            // Add headers split by tab into List
            headers.AddRange(line.Split('\t'));
            n++;
        }

        private void ReadMeasurementUnits(string line, ref int n, List<string> mUnits)
        {
            mUnits.AddRange(line.Split('\t'));
            n++;
        }


        StringBuilder sbTmp = new StringBuilder();

        // Read 1 row of data, split row by tabs, loop all values from array
        // If value is OK insert a value, otherwise insert null to preserve column order
        private void ReadHistoricalData(string line, List<HistoricalData> historicalData, List<string> headers, string fileName)
        {
            try
            {
                string[] splittedLine = line.Split('\t');
                //sbTmp.Append(string.Join("\t", splittedLine) + Environment.NewLine);

                double value;
                int stepPos = FindStepNumberPosition();
                HistoricalData hd = null;

                // Approximatelly -> not smartest way to test. Mr. Turk, please find a solution :-)
                // Provjeravam je li broj naslova jednak broju ćelija s vrijednostima. Jako često nije isti, ali to je ok jer naslova može biti manje, 
                // ali reci s vrijednostima mogu imati jako malo, tj. ništa podataka. Za sada preskačem ovako glupoom usporedbom ako redak nema dobre podatke
                //if (headers.Count > splittedLine.Count() || line.Contains(ParseRules.IgnoredStrings[0]))
                //{
                //    return;
                //}

                // Loop using headers count rather then data column count (sometimes there is crappy data that doesn't have column headers)
                for (int i = 0; i < headers.Count - 1; i += 2)
                {
                    // Each column is new object "transformed" into row and added to collection
                    hd = new HistoricalData();
                    hd.CurrentStepNumberValue = -1;
                    hd.HeaderName = headers[i];

                    // Check if current value is something strange (whitespace, dashes etc.) 
                    if (!ParseRules.IgnoredStrings.Contains(splittedLine[i + 1]))
                    {
                        // Check if CurrentStepNumber column exists and header name is not empty
                        if (stepPos > -1 && !string.IsNullOrEmpty(headers[i]))
                        {
                            int stepValue = -1;
                            bool parsedStepValue = int.TryParse(splittedLine[stepPos], out stepValue);
                            hd.CurrentStepNumberValue = stepValue;

                            bool parsed = double.TryParse(splittedLine[i + 1].Replace('.', ','), out value);
                            // If value is missing, tab separator will give some shitty text which we consider empty value
                            if (parsed)
                            {
                                hd.Value = value;
                            }
                            else
                            {
                                hd.Value = null;
                            }
                            // Col number useful for debugging..so keep it
                            hd.ColumnNumber = i + 1;
                            hd.RowNumber = rowNo;
                            historicalData.Add(hd);
                        }
                    }

                }

                sbTmp.Append(hd + Environment.NewLine);
            }
            catch (IndexOutOfRangeException ex)
            {
                // Just ignore this exception for data because empty rows can come. Might come handy while debugging
                Logger.Log("ReadHistoricalData Line: " + rowNo + " column: " + colNo + 1, fileName, ex.Message);
            }
            catch (Exception ex)
            {
                Logger.Log("ReadHistoricalData Line: " + rowNo, fileName, ex.Message);
            }
        }

        private int FindStepNumberPosition()
        {
            for (int i = 0; i < headers.Count; i++)
            {
                if (headers[i] == GenerateSqlRules.CurrentStepNumberPos)
                {
                    return i + 1; // Always 2 columns of same name, take data from 2nd column
                }
            }

            return -1;
        }

        #endregion


        #region Process sequence summary
        private void ReadSummaryData(string line, List<SummaryData> summaryData, string fileName, ref bool isSummaryRow)
        {
            try
            {
                string[] splittedRow = line.Split('\t');
                SummaryData sd = new SummaryData();
                sd.Type = splittedRow[0];
                sd.Time = splittedRow[1];
                sd.Value = double.Parse(splittedRow[2]);
                sd.Condition = int.Parse(splittedRow[3]);
            }
            catch (IndexOutOfRangeException)
            {
                // Just ignore this exception for data because empty rows can come. Might come handy while debugging
                // Reading is done when this exception occurs
                isSummaryRow = false;
            }
            catch (Exception ex)
            {
                Logger.Log("ReadSummaryData Line no: " + rowNo, fileName, ex.Message);
            }
        }
        #endregion
    }
}
