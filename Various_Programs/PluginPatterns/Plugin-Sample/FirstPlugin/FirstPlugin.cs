using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PluginContracts;

namespace FirstPlugin
{
    public class FirstPlugin : IPlugin
    {
        public string Name => "First Plugin";

        public void Do()
        {
            System.Windows.MessageBox.Show("Do Something in First Plugin");
        }
    }
}
