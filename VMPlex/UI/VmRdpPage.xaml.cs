/*
 * Copyright (c) 2022 Ira Strawser. All rights reserved.
 */

using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using System.Diagnostics;
using System.IO;
using VMPlex.WMI;
using System.ComponentModel;

namespace VMPlex.UI
{
    /// <summary>
    /// Interaction logic for VmRdpPage.xaml
    /// </summary>
    public partial class VmRdpPage : UserControl, INotifyPropertyChanged
    {
        private readonly DispatcherTimer m_timer = new DispatcherTimer();
        //private Msvm_ComputerSystem.SystemState m_vmPrevState;
        private bool m_prevVideoAvail;
        private Msvm_ComputerSystem.EnhancedSessionMode m_prevEnhancedState;
        private VirtualMachine m_vm;
        public string VmGuid {  get { return m_vm.Guid; } }
        public string ErrorMessage { get; private set; }

        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyChange(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public enum StartupEnhanceState
        {
            UserOptions,
            ForceOn,
            ForceOff
        }

        public VmRdpPage(VirtualMachine vmModel, StartupEnhanceState startupEnhanceState = StartupEnhanceState.UserOptions)
        {
            m_vm = vmModel;

            InitializeComponent();
            Connect(startupEnhanceState);
        }

        private RdpOptions MakeRdpOptions()
        {
            var options = new RdpOptions();
            var userOpts = m_vm.GetVmUserSettings().RdpSettings;
            if (userOpts == null)
            {
                return options;
            }

            if (userOpts.DefaultEnhancedSession != null)
            {
                options.EnhancedSession = (bool)userOpts.DefaultEnhancedSession;
            }

            if (userOpts.RedirectClipboard != null)
            {
                options.RedirectClipboard = (bool)userOpts.RedirectClipboard;
            }

            if (userOpts.AudioRedirectionMode != null)
            {
                options.AudioRedirectionMode = (uint)userOpts.AudioRedirectionMode;
            }

            if (userOpts.AudioCaptureRedirectionMode != null)
            {
                options.AudioCaptureRedirectionMode = (bool)userOpts.AudioCaptureRedirectionMode;
            }

            if (userOpts.RedirectDrives != null)
            {
                options.RedirectDrives = (bool)userOpts.RedirectDrives;
            }

            if (userOpts.RedirectDevices != null)
            {
                options.RedirectDevices = (bool)userOpts.RedirectDevices;
            }

            if (userOpts.RedirectSmartCards != null)
            {
                options.RedirectSmartCards = (bool)userOpts.RedirectSmartCards;
            }

            if (userOpts.DesktopWidth != null)
            {
                options.DesktopWidth = (int)userOpts.DesktopWidth;
            }

            if (userOpts.DesktopHeight != null)
            {
                options.DesktopHeight = (int)userOpts.DesktopHeight;
            }

            return options;
        }

        private void Connect(StartupEnhanceState startupEnhanceState)
        {
            m_prevVideoAvail = m_vm.IsVideoAvailable();
            m_prevEnhancedState = m_vm.EnhancedSessionModeState;

            rdpHost.Height = rdp.Height;
            rdpHost.Width = rdp.Width;
            rdpGrid.SizeChanged += OnGridSizeChanged;
            rdpHost.DpiChanged += RdpHost_DpiChanged;
            rdp.DesktopResized += OnRdpDesktopResized;

            RdpOptions options = MakeRdpOptions();

            rdp.InitializeForLocalVmConnection(m_vm, options);

            m_vm.PropertyChanged += VmModel_PropertyChanged;
            m_timer.Tick += OnResizeTimer;
            rdp.OnRdpConnecting += OnRdpConnecting;
            rdp.OnRdpConnected += OnRdpConnected;
            rdp.OnRdpDisconnected += OnRdpDisconnected;
            rdp.OnRdpError += OnRdpError;

            vmEnhancedMode.Checked -= OnEnhancedChecked;
            vmEnhancedMode.Unchecked -= OnEnhancedUnchecked;

            if (startupEnhanceState == StartupEnhanceState.UserOptions)
            {
                vmEnhancedMode.IsChecked = options.EnhancedSession;
            }
            else
            {
                options.EnhancedSession = startupEnhanceState == StartupEnhanceState.ForceOn;
                vmEnhancedMode.IsChecked = options.EnhancedSession;
            }

            offlineText.Visibility = System.Windows.Visibility.Visible;
            if (m_vm.IsVideoAvailable())
            {
                rdp.Connect();
            }
            vmEnhancedMode.Checked += OnEnhancedChecked;
            vmEnhancedMode.Unchecked += OnEnhancedUnchecked;
        }

        private void DisplayErrorMessage(string message)
        {
            ErrorMessage = message;
            errorText.Visibility = Visibility.Visible;
            rdpHost.Visibility = Visibility.Hidden;
            NotifyChange("ErrorMessage");
        }

        private void HideErrorMessage()
        {
            ErrorMessage = "";
            errorText.Visibility = Visibility.Hidden;
            NotifyChange("ErrorMessage");
        }

        private void OnEnhancedChecked(object sender, RoutedEventArgs e)
        {
            if (Parent != null)
            {
                rdp.Shutdown();
                ((TabItem)Parent).Content = new VmRdpPage(m_vm, StartupEnhanceState.ForceOn);
            }
        }

        private void OnEnhancedUnchecked(object sender, RoutedEventArgs e)
        {
            if (Parent != null)
            {
                rdp.Shutdown();
                ((TabItem)Parent).Content = new VmRdpPage(m_vm, StartupEnhanceState.ForceOff);
            }
        }

        private void OnPowerCommand(object sender, RoutedEventArgs e)
        {
            if (m_vm.State == Msvm_ComputerSystem.SystemState.Off || 
                m_vm.State == Msvm_ComputerSystem.SystemState.Saved || 
                m_vm.State == Msvm_ComputerSystem.SystemState.Paused)
            {
                m_vm.RequestStateChange(VirtualMachine.StateChange.Enabled);
            }
            else
            {
                m_vm.RequestStateChange(VirtualMachine.StateChange.Disabled);
            }
        }

        private void OnPauseCommand(object sender, RoutedEventArgs e)
        {
            if (m_vm.State != Msvm_ComputerSystem.SystemState.Off)
            {
                if (m_vm.State == Msvm_ComputerSystem.SystemState.Paused)
                {
                    m_vm.RequestStateChange(VirtualMachine.StateChange.Enabled);
                }
                else
                {
                    m_vm.RequestStateChange(VirtualMachine.StateChange.Quiesce);
                }
            }
        }

        private void OnResetCommand(object sender, RoutedEventArgs e)
        {
            if (m_vm.State != Msvm_ComputerSystem.SystemState.Off)
            {
                m_vm.RequestStateChange(VirtualMachine.StateChange.Reset);
            }
        }

        private void OnSaveCommand(object sender, RoutedEventArgs e)
        {
            m_vm.RequestStateChange(VirtualMachine.StateChange.Offline);
        }

        private void OnShutdownCommand(object sender, RoutedEventArgs e)
        {
            if (m_vm.State != Msvm_ComputerSystem.SystemState.Off)
            {
                m_vm.RequestStateChange(VirtualMachine.StateChange.Shutdown);
            }
        }

        private void OnRebootCommand(object sender, RoutedEventArgs e)
        {
            if (m_vm.State != Msvm_ComputerSystem.SystemState.Off)
            {
                m_vm.RequestStateChange(VirtualMachine.StateChange.Reboot);
            }
        }

        private void OnTypeCommand(object sender, RoutedEventArgs e)
        {
            m_vm.TypeText(Clipboard.GetText());
        }

        private void OnDebugCommand(object sender, RoutedEventArgs e)
        {
            m_vm.OpenDebugger();
        }

        private void OnSettingsCommand(object sender, RoutedEventArgs e)
        {
            m_vm.OpenSettingsDialog();
        }

        private void OnRdpConnecting(object sender)
        {
            this.Dispatcher.Invoke(() =>
            {
                offlineText.Visibility = System.Windows.Visibility.Visible;
                connectingText.Visibility = Visibility.Visible;
                rdpHost.Visibility = Visibility.Hidden;
            });
        }

        private void OnRdpConnected(object sender)
        {
            System.Diagnostics.Debug.Print("Rdp connected");
            connectingText.Visibility = Visibility.Hidden;
            offlineText.Visibility = System.Windows.Visibility.Hidden;
            rdpHost.Visibility = System.Windows.Visibility.Visible;
            if (rdp.Enhanced)
            {
                StartResizeTimer();
            }
        }

        private void OnRdpDisconnected(object sender)
        {
            System.Diagnostics.Debug.Print("Rdp disconnected");
            this.Dispatcher.Invoke(() =>
            {
                connectingText.Visibility = Visibility.Hidden;
                rdpHost.Visibility = System.Windows.Visibility.Hidden;
                offlineText.Visibility = System.Windows.Visibility.Visible;
                HideErrorMessage();
            });
            m_timer.Stop();
        }

        private void OnRdpError(object sender, RdpClient.RdpError error)
        {
            this.Dispatcher.Invoke(() =>
            {
                switch(error)
                {
                case RdpClient.RdpError.BasicSessionWithShieldedVm:
                    DisplayErrorMessage("Cannot connect to a shielded virtual machine with a basic session.\nPlease enable the Enhanced Mode option.");
                    break;
                }
            });
        }

        private void VmModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            VirtualMachine vm = (VirtualMachine)sender;
            if (m_prevEnhancedState == vm.EnhancedSessionModeState)
            {
                return;
            }

            if (m_prevEnhancedState == Msvm_ComputerSystem.EnhancedSessionMode.AllowedAndAvailable)
            {
                // moving from enhanced to normal
                m_timer.Stop();
                System.Diagnostics.Debug.Print("rdp resize timer stopped in VmModel_PropertyChanged");
            }
            else
            {
                // moving to enhanced
                System.Diagnostics.Debug.Print("OnSizeChanged: VmModel_PropertyChanged");
                StartResizeTimer();
            }
            m_prevEnhancedState = vm.EnhancedSessionModeState;
        }

        public void Shutdown()
        {
            rdp.Shutdown();
        }

        public void Disconnect()
        {
            System.Diagnostics.Debug.Print("rdp resize timer stopped in Disconnect");
            m_timer.Stop();
            try
            {
                rdp.Disconnect();
            }
            catch (Exception)
            {
            }
        }

        // Resize the WindowsFormsHost that contains the RDP ActiveX control taking into account available space
        // and DPI scaling. This uses the current DesktopSize from the ActiveX control.
        private void ResizeRdpHost(Size gridSize)
        {
            System.Windows.Size rdpSize = rdp.ScaledRdpDesktopSize();
            double targetWidth = rdpSize.Width;
            double targetHeight = rdpSize.Height;
            targetWidth = Math.Min(targetWidth, gridSize.Width);
            targetHeight = Math.Min(targetHeight, gridSize.Height);
            if (rdp.EnhancedReady)
            {
            }
            System.Diagnostics.Debug.Print("Resizing rdpHost to {0}, {1}", targetWidth, targetHeight);
            rdpHost.Width = targetWidth;
            rdpHost.Height = targetHeight;
        }

        // Fired when moving between monitors with different DPI scaling or if the monitor/system DPI scaling
        // settings are changed
        private void RdpHost_DpiChanged(object sender, DpiChangedEventArgs e)
        {
            DpiScale dpi = e.NewDpi;

            Debug.Print("RdpHost_DpiChanged: DpiScaleX: {0} DpiScaleY: {1}",
                dpi.DpiScaleX, dpi.DpiScaleY);

            System.Diagnostics.Debug.Print("OnSizeChanged: RdpHost_DpiChanged");
            ResizeRdpHost(new Size(rdpGrid.ActualWidth, rdpGrid.ActualHeight));
        }

        // Fired when the ActiveX RDP control notifies us the remote desktop size has changed
        private void OnRdpDesktopResized(object sender, EventArgs e)
        {
            ResizeRdpHost(new Size(rdpGrid.ActualWidth, rdpGrid.ActualHeight));
        }

        // Fired when the grid containing the WindowsFormsHost (which then hosts the RDP ActiveX control) is resized.
        // We need to check if the WindowsFormsHost needs to be resized to fit within the new available space.
        private void OnGridSizeChanged(object sender, SizeChangedEventArgs e)
        {
            System.Diagnostics.Debug.Print("Rdp grid resized {0}, {1}", e.NewSize.Width, e.NewSize.Height);
            if (!rdp.EnhancedReady)
            {
                ResizeRdpHost(new Size(e.NewSize.Width, e.NewSize.Height));
            }
            else
            {
                StartResizeTimer();
            }
        }

        private void OnResizeTimer(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.Print("Rdp resize timer {0} {1}", rdpGrid.ActualWidth, rdpGrid.ActualHeight);
            if (rdp.IsVideoAvailable() == false || rdp.TryResize(rdpGrid.ActualWidth, rdpGrid.ActualHeight))
            {
                rdpHost.Width = rdpGrid.ActualWidth;
                rdpHost.Height = rdpGrid.ActualHeight;
                m_timer.Stop();
                System.Diagnostics.Debug.Print("rdp resize timer stopped in OnResizeTimer");
                return;
            }
        }

        private void StartResizeTimer()
        {
            int seconds = 1;
            int milliseconds = 0;
            if (rdp.EnhancedReady)
            {
                seconds = 0;
                milliseconds = 200;
            }
            System.Diagnostics.Debug.Print("Starting rdp resize timer");
            m_timer.Stop();
            m_timer.Interval = new TimeSpan(0, 0, 0, seconds, milliseconds);
            m_timer.Start();
        }
    }
}
