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
        [JsonInclude, JsonPropertyOrder(-1), JsonPropertyName("$schema")]
        public string _schema = "https://raw.githubusercontent.com/0xf005ba11/vmplex-ws/main/VMPlex/UserSettingsSchema.json";

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
        /// When starting VMPlex will remember and reopen previously opened tabs.
        /// </summary>
        [JsonInclude]
        public bool RememberTabs { get; set; } = true;

        /// <summary>
        /// When true certain tool bar actions will prompt for confirmation
        /// before executing. Like rebooting, shutting down, resetting virtual
        /// machines.
        /// </summary>
        [JsonInclude]
        public bool ConfirmToolBarActions { get; set; } = true;

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

        /// <summary>
        /// Window settings, generally users don't need to edit this. Used to
        /// persist state of the window.
        /// </summary>
        [JsonInclude]
        public WindowSettings MainWindow { get; set; } = new WindowSettings();
    }

    /// <summary>
    /// User settings for a given virtual machine.
    /// </summary>
    public class VmConfig
    {
        /// <summary>
        /// The GUID of the virtual machine as reported by Hyper-V. VMPlex will
        /// populate this on the user's behalf.
        /// </summary>
        [JsonInclude]
        public string Guid { get; set; } = "";

        /// <summary>
        /// The friendly name of the virtual machine as reported by Hyper-V.
        /// VMPlex will populate this on this user's behalf.
        /// </summary>
        [JsonInclude]
        public string Name { get; set; } = "";

        /// <summary>
        /// Arguments passed to the debugger when launching one for this 
        /// virtual machine. As an example, when using windbg and debugging
        /// the target virtual machine over the network this would be in a
        /// form similar to "-k net:port=50000,key=1.2.3.4 -T WIN11X64".
        /// References the documentation for your debugger. 
        /// </summary>
        [JsonInclude]
        public string DebuggerArguments { get; set; } = "";


        /// <summary>
        /// Indicates if the virtual machine tab is open and at what index.
        /// Used in conjunction with RememberTabs.
        /// </summary>
        [JsonInclude]
        public int TabIndex { get; set; } = -1;

        /// <summary>
        /// Optional RDP settings used when connecting to this virtual machine.
        /// </summary>
        [JsonInclude]
        public RdpSettings RdpSettings { get; set; } = new RdpSettings();
    }

    /// <summary>
    /// User settings for a RDP connections. 
    /// </summary>
    public class RdpSettings
    {
        /// <summary>
        /// The default enhanced session state when connecting to a virtual machine.
        /// </summary>
        [JsonInclude]
        public bool DefaultEnhancedSession { get; set; } = true;

        /// <summary>
        /// Specifies if redirection of the clipboard is allowed.
        /// </summary>
        [JsonInclude]
        public bool RedirectClipboard { get; set; } = true;

        /// <summary>
        /// Values for the audio redirection mode.
        /// </summary>
        public enum AudioRedirectionModeSetting
        {
            /// <summary>
            /// Audio redirection is enabled and the option for redirection is
            /// "Bring to this computer". This is the default mode.
            /// </summary>
            Redirect = 0,

            /// <summary>
            /// Audio redirection is enabled and the option is "Leave at
            /// remote computer". The "Leave at remote computer" option is
            /// supported only when connecting remotely to a host computer
            /// that is running Windows Vista. If the connection is to a host
            /// computer that is running Windows Server 2008, the option 
            /// "Leave at remote computer" is changed to "Do not play".
            /// </summary>
            PlayOnServer = 1,

            /// <summary>
            /// Audio redirection is enabled and the mode is "Do not play".
            /// </summary>
            None = 2
        }

        /// <summary>
        /// Sets different values for the audio redirection mode. 
        /// </summary>
        [JsonInclude]
        public AudioRedirectionModeSetting AudioRedirectionMode { get; set; } = AudioRedirectionModeSetting.Redirect;

        /// <summary>
        /// Specifies if the default audio input device is captured.
        /// </summary>
        [JsonInclude]
        public bool AudioCaptureRedirectionMode { get; set; } = false;

        /// <summary>
        /// Specifies if redirection of disk drives is allowed.
        /// </summary>
        [JsonInclude]
        public bool RedirectDrives { get; set; } = false;

        /// <summary>
        /// Specifies if redirection of devices is allowed.
        /// This defaults to false.
        /// </summary>
        [JsonInclude]
        public bool RedirectDevices { get; set; } = false;

        /// <summary>
        /// Specifies if redirection of smart cards is allowed.
        /// </summary>
        [JsonInclude]
        public bool RedirectSmartCards { get; set; } = false;

        /// <summary>
        /// Specifies the initial remote desktop width, in pixels.
        /// </summary>
        [JsonInclude]
        public int DesktopWidth { get; set; } = 1024;

        /// <summary>
        /// Specifies the initial remote desktop height, in pixels.
        /// </summary>
        [JsonInclude]
        public int DesktopHeight { get; set; } = 768;
    }

    /// <summary>
    /// Window settings. 
    /// </summary>
    public class WindowSettings
    {
        [JsonInclude]
        public double Width { get; set; } = 1200;

        [JsonInclude]
        public double Height { get; set; } = 900;

        [JsonInclude]
        public double Top { get; set; } = -1;

        [JsonInclude]
        public double Left { get; set; } = -1;

        [JsonInclude]
        public WindowState State { get; set; } = WindowState.Normal;
    }

    public class UserSettings : INotifyPropertyChanged
    {
        public Settings Settings { get { lock (Lock) { return ActiveSettings; } } }
        public string UserSettingsFile { get; private set; } = Path.GetFullPath("vmplex-settings.json");

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
                UI.MessageBox.Show(
                    MessageBoxImage.Error,
                    "VMPlex Settings Error",
                    $"Failed to open settings file \"{UserSettingsFile}\"\n{exc.Message}");
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

        public void Load()
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
                    ActiveSettings = JsonSerializer.Deserialize<Settings>(json, JsonSerializeOpts);
                    ActiveSettings._schema = (new Settings())._schema;
                }
            }
        }

        public void Save()
        {
            lock (Lock)
            {
                var json = JsonSerializer.Serialize(ActiveSettings, JsonSerializeOpts);
                File.WriteAllText(UserSettingsFile, json);
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
                    UI.MessageBox.Show(
                         MessageBoxImage.Error,
                         "VMPlex Settings Error",
                         $"Failed to load settings file \"{UserSettingsFile}\"\n{exception.Message}");
                    LastReloadErrorTime = DateTime.Now;
                }
            }
        }

        private static UserSettings _instance;
        private static object _instanceLock = new object();

        private object Lock = new object();
        private Settings ActiveSettings = new Settings();
        private FileSystemWatcher SettingsFileWatcher; 
        private JsonSerializerOptions JsonSerializeOpts = new JsonSerializerOptions
        {
            WriteIndented = true,
            IncludeFields = true,
            Converters =
            {
                new JsonStringEnumConverter()
            }
        };
        private DateTime LastReloadErrorTime = DateTime.Now;
    }
}
