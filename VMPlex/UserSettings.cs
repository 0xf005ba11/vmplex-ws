/*
 * Copyright (c) 2022 Johnny Shaw. All rights reserved.
 */

using System;
using System.IO;
using System.Windows;
using System.Text.Json;
using System.Threading;
using System.Diagnostics;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace VMPlex
{

    public class Settings 
    {
        [JsonInclude]
        public string Debugger = "";
        [JsonInclude]
        public List<VmConfig> VirtualMachines = new List<VmConfig>();
    }

    public class VmConfig
    {
        [JsonInclude]
        public string Guid;
        [JsonInclude]
        public string Name;
        [JsonInclude]
        public string DebuggerArguments;
    }

    public class SettingsManager
    {
        public SettingsManager()
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

        public Settings Get()
        {
            lock (Lock)
            {
                return ActiveSettings;
            }
        }

        public Settings Mutate(Func<Settings, Settings> Mutator)
        {
            lock (Lock)
            {
                var newSettings = Mutator(ActiveSettings);
                var json = JsonSerializer.Serialize(newSettings, JsonSerializeOpts);
                File.WriteAllText(UserSettingsFile, json);
                return newSettings;
            }
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

            if (exception != null)
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

        private object Lock = new object();
        private Settings ActiveSettings = new Settings();
        private FileSystemWatcher SettingsFileWatcher; 
        private string UserSettingsFile = Path.GetFullPath("vmplex-settings.json");
        private JsonSerializerOptions JsonSerializeOpts = new JsonSerializerOptions()
        {
            WriteIndented = true,
            IncludeFields = true
        };
        private DateTime LastReloadErrorTime = DateTime.Now;
    }
}
