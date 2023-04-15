using System;
using System.Diagnostics;
using System.IO;
using System.Windows;
using IWshRuntimeLibrary;

namespace VMPlex
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            HandleCommandLine();
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

        private void HandleCommandLine()
        {
            var args = Environment.GetCommandLineArgs();
            if (args.Length < 2)
            {
                return;
            }

            switch (args[1])
            {
                case "--install":
                {
                    ActAsInstaller();
                    break;
                }
                case "--upgrade":
                {
                    ActAsUpgrader();
                    break;
                }
                case "--uninstall":
                {
                    ActAsUninstaller();
                    break;
                }
            }
        }

        private const string ProgramName = "VMPlex Workstation";
        private const string ProgramNameShort = "VMPlex";
        private const string ProgramExe = ProgramNameShort + ".exe";
        private const string ProgramLnk = ProgramName + ".lnk";

        private string GetProgramDirectory()
        {
            return Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), 
                "Programs", 
                ProgramName);
        }

        private string GetStartMenuDirectory()
        {
            return Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.StartMenu),
                "Programs");
        }


        private void ActAsInstaller()
        {
            var programDir = GetProgramDirectory();
            var startMenu = GetStartMenuDirectory();
            var program = Path.Combine(programDir, ProgramExe);

            try
            {
                if (!Directory.Exists(programDir))
                    Directory.CreateDirectory(programDir);
                if (!Directory.Exists(startMenu))
                    Directory.CreateDirectory(startMenu);

                System.IO.File.Copy(Process.GetCurrentProcess().MainModule.FileName, program);

                var shell = new WshShell();
                var shortcut = (IWshShortcut)shell.CreateShortcut(Path.Combine(startMenu, ProgramLnk));
                shortcut.Description = ProgramName;
                shortcut.TargetPath = program;
                shortcut.WorkingDirectory = programDir;
                shortcut.Save();
            }
            catch (Exception e)
            {
                Debug.Print($"Failed to install: {e.Message}");
                Environment.Exit(e.HResult != 0 ? e.HResult : 1);
            }

            Environment.Exit(0);
        }

        private void ActAsUpgrader()
        {
            var programDir = GetProgramDirectory();
            var program = Path.Combine(programDir, ProgramExe);

            try
            {
                System.IO.File.Copy(Process.GetCurrentProcess().MainModule.FileName, program, true);
            }
            catch (Exception e)
            {
                Debug.Print($"Failed to upgrade: {e.Message}");
                Environment.Exit(e.HResult != 0 ? e.HResult : 1);
            }

            Environment.Exit(0);
        }

        private void ActAsUninstaller()
        {
            var programDir = GetProgramDirectory();
            var shortcut = Path.Combine(GetStartMenuDirectory(), ProgramLnk);
            try
            {
                if (Directory.Exists(programDir))
                    Directory.Delete(programDir, true);
                if (System.IO.File.Exists(shortcut))
                    System.IO.File.Delete(shortcut);
            }
            catch (Exception e)
            {
                Debug.Print($"Failed to uninstall: {e.Message}");
                Environment.Exit(e.HResult != 0 ? e.HResult : 1);
            }

            Environment.Exit(0);
        }
    }
}
