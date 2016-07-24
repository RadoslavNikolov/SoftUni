using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PluginContracts;

namespace SecondPlugin
{
    public class SecondPlugin : IPlugin
    {
        public string Name => "SecondP Plugin";
        public void Do()
        {
            System.Windows.MessageBox.Show("Do something in second plugin");
        }
    }
}
