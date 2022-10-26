using System.Windows;

namespace VMPlex
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            Utility.TryExtractHVIntegrate();
            base.OnStartup(e);
            Utility.CreateSelfJob();
        }
    }
}
