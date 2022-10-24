using System.Windows;

namespace VMPlex
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static SettingsManager UserSettings = new SettingsManager();

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            Utility.CreateSelfJob();
        }
    }
}
