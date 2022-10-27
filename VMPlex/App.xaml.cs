using System;
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
            LoadUserSettings();
            Utility.TryExtractHVIntegrate();
            base.OnStartup(e);
            Utility.CreateSelfJob();
        }

        private void LoadUserSettings()
        {
            try
            {
                UserSettings.Instance.Load();
            }
            catch (Exception exc)
            {
                MessageBox.Show(
                    $"Failed to load settings file \"{UserSettings.Instance.UserSettingsFile}\"\n{exc.Message}",
                    "VMPlex Fatal Settings Error",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
                //
                // Unable to parse settings. Error already displayed. Quietly exit.
                //
                Environment.Exit(1);
            }
        }
    }
}
