using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReadWriteSameFile
{
    public partial class Form1 : Form
    {
        public string PathName { get; set; }
        public Form1()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            PathName = txtPath.Text;
            if (Directory.Exists(PathName))
            {
                ProcessDirectory(PathName);
            }
        }


        // Process all files in the directory passed in, recurse on any directories 
        // that are found, and process the files they contain.
        public void ProcessDirectory(string targetDirectory)
        {
            // Process the list of files found in the directory.
            string[] fileEntries = Directory.GetFiles(targetDirectory, "*.map", SearchOption.TopDirectoryOnly);

            foreach (string fileName in fileEntries)
            {
                ProcessFile(fileName);
            }

            // Recurse into subdirectories of this directory.
            foreach (string subdirectory in Directory.GetDirectories(targetDirectory).Reverse())
            {
                try
                {
                    ProcessDirectory(subdirectory);
                }
                catch (Exception ex)
                {
                    lblError.Text = ex.Message;
                }
            }

        }

        public void ProcessFile(string path)
        {
            StreamReader rdr = new StreamReader(path);
            string line;
            List<string> splitLines = new List<string>();

            while ((line = rdr.ReadLine()) != null)
            {
                if (line.Contains("#Export"))
                {
                    line += "*";
                }
                splitLines.Add(line);
            }

            rdr.Close();
            WriteFile(path, splitLines);
        }

        private void WriteFile(string path, List<string> splitLines)
        {
            StringBuilder sb = new StringBuilder();

            foreach (var s in splitLines)
            {
                sb.Append(string.Format("{0}\n", s));
            }

            File.WriteAllText(path, sb.ToString());
        }
    }
}
