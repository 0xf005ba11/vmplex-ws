using System;
using System.Diagnostics;
using System.IO;
using System.Windows;
using IWshRuntimeLibrary;
using Microsoft.Win32;

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
        private const string UninstallKey = @"Software\Microsoft\Windows\CurrentVersion\Uninstall\" + ProgramNameShort;

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
                SetUninstallKey(program, programDir);

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
                SetUninstallKey(program, programDir);
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
            var program = Path.Combine(programDir, ProgramExe);
            var shortcut = Path.Combine(GetStartMenuDirectory(), ProgramLnk);
            try
            {
                if (System.IO.File.Exists(program))
                    System.IO.File.Move(program, Path.GetTempFileName(), true);
                if (Directory.Exists(programDir))
                    Directory.Delete(programDir, true);
                if (System.IO.File.Exists(shortcut))
                    System.IO.File.Delete(shortcut);
                Registry.CurrentUser.DeleteSubKey(UninstallKey, false);
            }
            catch (Exception e)
            {
                Debug.Print($"Failed to uninstall: {e.Message}");
                Environment.Exit(e.HResult != 0 ? e.HResult : 1);
            }

            Environment.Exit(0);
        }

        private void SetUninstallKey(string Program, string InstallLocation)
        {
            using (RegistryKey key = Registry.CurrentUser.CreateSubKey(UninstallKey))
            {
                string ver = GetType().Assembly.GetName().Version.ToString();
                key.SetValue("DisplayName", ProgramName);
                key.SetValue("ApplicationVersion", ver);
                key.SetValue("Publisher", ProgramNameShort);
                key.SetValue("DisplayIcon", Program);
                key.SetValue("DisplayVersion", ver);
                key.SetValue("InstallDate", DateTime.Now.ToString("yyyyMMdd"));
                key.SetValue("InstallLocation", InstallLocation);
                key.SetValue("UninstallString", $"\"{Program}\" --uninstall");
                key.SetValue("QuietUninstallString", $"\"{Program}\" --uninstall");
                key.SetValue("NoModify", 1);
                key.SetValue("NoRepair", 1);
                key.SetValue("HelpLink", "https://github.com/0xf005ba11/vmplex-ws/issues");
                key.SetValue("URLInfoAbout", "https://github.com/0xf005ba11/vmplex-ws");
            }
        }
    }
}
