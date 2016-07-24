using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using PluginContracts;

namespace SimplePlugin
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly Dictionary<string, IPlugin> _pluginsDic;
        public MainWindow()
        {
            InitializeComponent();

            if (_pluginsDic == null)
            {
                _pluginsDic = new Dictionary<string, IPlugin>();
            }

            ICollection<IPlugin> plugins = GenericPluginLoader<IPlugin>.LoadPlugins("Plugins");
            foreach (IPlugin plugin in plugins)
            {
                _pluginsDic.Add(plugin.Name, plugin);

                var btn = new Button {Content = plugin.Name};
                btn.Click += bnt_Click;
                PluginGrid.Children.Add(btn);
            }
        }

        private void bnt_Click(object sender, RoutedEventArgs e)
        {
            var btn = sender as Button;

            if (btn == null) return;

            var key = btn.Content.ToString();

            if (!_pluginsDic.ContainsKey(key)) return;

            var plugin = _pluginsDic[key] as IPlugin;
            plugin?.Do();
        }
    }
}
