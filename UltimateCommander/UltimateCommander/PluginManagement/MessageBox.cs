using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UltimateCommander.PluginManagement
{
    public class MessageBoxX
    {
        [Export()]
        public string MyMessage { get { return "This is test message"; } }
    }
}
