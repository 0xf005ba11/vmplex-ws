/*
 * Copyright (c) 2022 Johnny Shaw. All rights reserved.
 */

using System;
using System.IO;
using System.Windows;
using System.Text.Json;
using System.Threading;
using System.Diagnostics;
using System.ComponentModel;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace VMPlex
{

    /// <summary>
    /// Root of the user settings. Configured via vmplex-settings.json.
    /// </summary>
    public class Settings
    {
        /// <summary>
        /// If true portions of the interface are styled in a compact style. 
        /// </summary>
        [JsonInclude]
        public bool CompactMode { get; set; } = false;

        /// <summary>
        /// Optionally sets the font size for certain elements in the UI. 
        /// </summary>
        [JsonInclude]
        public double FontSize { get; set; } = 14;

        /// <summary>
        /// Defines the debugger to use when launching one for a given virtual
        /// machine. This is supplied as the file name starting the debugger
        /// process.
        /// </summary>
        [JsonInclude]
        public string Debugger { get; set; } = "windbgx";

        /// <summary>
        /// A list of virtual machines. VMPlex will populate this with known
        /// virtual machines on the user's behalf.
        /// </summary>
        [JsonInclude]
        public List<VmConfig> VirtualMachines { get; set; } = new List<VmConfig>();
    }

    /// <summary>
    /// User settings for a given virtual machine.
    /// </summary>
    public class VmConfig
    {
        /// <summary>
        /// The GUID of the virtual machine at reported by Hyper-V. VMPlex will
        /// populate this on the user's behalf.
        /// </summary>
        [JsonInclude]
        public string Guid { get; set; }

        /// <summary>
        /// The friendly name of the virtual machine as reported by Hyper-V.
        /// VMPlex will populate this on this user's behalf.
        /// </summary>
        [JsonInclude]
        public string Name { get; set; }

        /// <summary>
        /// Arguments passed to the debugger when launching one for a given
        /// virtual machine. As an example, when using windbg and debugging
        /// the target virtual machine over the network this would be in a
        /// form similar to "-k net:port=50000,key=1.2.3.4 -T WIN11X64".
        /// References the documentation for your debugger. 
        /// </summary>
        [JsonInclude]
        public string DebuggerArguments { get; set; }
    }

    public class UserSettings : INotifyPropertyChanged
    {
        public Settings Settings { get { lock (Lock) { return ActiveSettings; } } }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyChange(string Name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(Name));
        }

        public static UserSettings Instance
        {
            get
            {
                if (_instance is null)
                {
                    lock (_instanceLock)
                    {
                        if (_instance is null)
                        {
                            _instance = new UserSettings();
                        }
                    }
                }

                return _instance;
            }
        }

        public UserSettings()
        {
            SettingsFileWatcher = new FileSystemWatcher()
            {
                Path = Path.GetDirectoryName(UserSettingsFile),
                Filter = Path.GetFileName(UserSettingsFile),
                EnableRaisingEvents = true
            };
            SettingsFileWatcher.Changed += OnChanged;
            SettingsFileWatcher.Deleted += OnChanged;
            SettingsFileWatcher.Created += OnChanged;
            SettingsFileWatcher.Renamed += OnRenamed;

            try
            {
                Load();
            }
            catch (Exception exc)
            {
                MessageBox.Show(
                    $"Failed to load settings file \"{UserSettingsFile}\"\n{exc.Message}",
                    "VMPlex Fatal Settings Error",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
                throw exc;
            }
        }

        public void OpenInEditor()
        {
            var process = new Process();
            process.StartInfo = new ProcessStartInfo()
            {
                FileName = UserSettingsFile,
                UseShellExecute = true
            };
            try
            {
                process.Start();
            }
            catch (Exception exc)
            {
                MessageBox.Show(
                    $"Failed to open settings file \"{UserSettingsFile}\"\n{exc.Message}",
                    "VMPlex Settings Error",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
        }

        public Settings Mutate(Func<Settings, Settings> Mutator)
        {
            Settings settings;

            lock (Lock)
            {
                settings = Mutator(ActiveSettings);
                var json = JsonSerializer.Serialize(settings, JsonSerializeOpts);
                File.WriteAllText(UserSettingsFile, json);
            }

            NotifyChange();

            return settings;
        }

        private void Load()
        {
            lock (Lock)
            {
                if (!File.Exists(UserSettingsFile))
                {
                    ActiveSettings = new Settings();
                }
                else
                {
                    var json = File.ReadAllText(UserSettingsFile);
                    ActiveSettings = JsonSerializer.Deserialize<Settings>(json);
                }
            }
        }

        private void OnChanged(object sender, FileSystemEventArgs e)
        {
            ReloadOnChange();
        }

        private void OnRenamed(object sender, RenamedEventArgs e)
        {
            ReloadOnChange();
        }

        private void ReloadOnChange()
        {
            //
            // This is disgusting... but the editor could be contending with
            // us trying to reload settings... keep trying for a short period.
            //
            Exception exception = null;
            for (int i = 0; i < 5; i++, Thread.Sleep(100))
            {
                try
                {
                    Load();
                    exception = null;
                    break;
                }
                catch (Exception exc)
                {
                    exception = exc;
                    continue;
                }
            }

            if (exception == null)
            {
                NotifyChange();
            }
            else
            {
                //
                // Don't nag too often since the change notification can fire
                // back-to-back depending on the file writing method and
                // changes. Also, we don't have access to the modern WFP here
                // so show an old school message box.
                //
                if ((DateTime.Now - LastReloadErrorTime).Seconds > 3)
                {
                    MessageBox.Show(
                        $"Failed to load settings file \"{UserSettingsFile}\"\n{exception.Message}",
                        "VMPlex Settings Error",
                        MessageBoxButton.OK,
                        MessageBoxImage.Warning);
                    LastReloadErrorTime = DateTime.Now;
                }
            }
        }

        private static UserSettings _instance;
        private static object _instanceLock = new object();

        private object Lock = new object();
        private Settings ActiveSettings = new Settings();
        private FileSystemWatcher SettingsFileWatcher; 
        private string UserSettingsFile = Path.GetFullPath("vmplex-settings.json");
        private JsonSerializerOptions JsonSerializeOpts = new JsonSerializerOptions
        {
            WriteIndented = true,
            IncludeFields = true
        };
        private DateTime LastReloadErrorTime = DateTime.Now;
    }
}
