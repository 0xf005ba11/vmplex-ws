using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace VMPlex.UI
{
    /// <summary>
    /// Interaction logic for RdpConnectWindow.xaml
    /// </summary>
    public partial class RdpConnectWindow : Window
    {
        public new static RdpSettings? Show()
        {
            var connections = new List<string>();
            foreach (var s in UserSettings.Instance.Settings.RdpConnections)
            {
                connections.Add(s.Domain.Length > 0 ? s.Domain + "\\" + s.Server : s.Server);
            }

            return Application.Current.Dispatcher.Invoke(() =>
            {
                var window = new RdpConnectWindow(connections);

                window.ShowInTaskbar = true;
                window.WindowStartupLocation = WindowStartupLocation.CenterScreen;

                foreach (Window owner in Application.Current.Windows)
                {
                    if (owner.IsActive && owner.IsMouseOver)
                    {
                        window.Owner = owner;
                        window.ShowInTaskbar = false;
                        window.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                        break;
                    }
                }

                var res = window.ShowDialog();
                if (res == null || res != true)
                {
                    return null;
                }

                var strings = window.ConnectionBox.Text.Split('\\');
                string domain = strings.Length > 1 ? strings[0] : "";
                string server = strings.Length > 1 ? strings[1] : strings[0];

                return UserSettings.Instance.Settings.RdpConnections.FirstOrDefault(
                    s => (s.Domain == domain && s.Server == server),
                    new RdpSettings { Domain = domain, Server = server }
                    );
            });
        }

        private RdpConnectWindow(List<string> ConnectionList)
        {
            InitializeComponent();
            ConnectionBox.ItemsSource = ConnectionList;
            Loaded += RdpConnectWindow_Loaded;
        }

        private void RdpConnectWindow_Loaded(object sender, object e)
        {
            (ConnectionBox.Template.FindName("PART_EditableTextBox", ConnectionBox) as TextBox).Focus();
        }

        private void ConnectButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }

        protected override void OnSourceInitialized(EventArgs e)
        {
            base.OnSourceInitialized(e);
            InvalidateMeasure();
        }
    }
}
