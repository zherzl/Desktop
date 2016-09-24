using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
namespace Chat
{
    class Receiver
    {
        BackgroundWorker bw;
        MulticastOption socket;
        public Receiver(MulticastOption sock)
        {
            MojDataSetTableAdapters.AmountTableAdapter da = new MojDataSetTableAdapters.AmountTableAdapter();
              
            //System.Net.IPAddress adr = new System.Net.IPAddress();
            
            //socket = new MulticastOption(adr);
            
            bw = new BackgroundWorker();
            bw.DoWork += Bw_DoWork;
            bw.RunWorkerCompleted += Bw_RunWorkerCompleted;
            bw.RunWorkerAsync();
        }

        

        private void Bw_DoWork(object sender, DoWorkEventArgs e)
        {

            
        }


        private void Bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }
    }
}
