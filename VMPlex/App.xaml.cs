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
                UserSettings.Instance.Save();
            }
            catch (Exception exc)
            {
                UI.MessageBox.Show(
                    MessageBoxImage.Error,
                     "VMPlex Fatal Settings Error",
                     $"Failed to load settings file \"{UserSettings.Instance.UserSettingsFile}\"\n{exc.Message}");
                //
                // Unable to parse settings. Error already displayed. Quietly exit.
                //
                Environment.Exit(1);
            }
        }
    }
}
