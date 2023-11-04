/*
 * Copyright (c) 2022 Ira Strawser. All rights reserved.
 */

using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using System.Diagnostics;
using System.ComponentModel;

using HyperV;
using System.Threading;

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
        private IMsvm_ComputerSystem.EnhancedSessionMode m_prevEnhancedState;
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

        private void UserControl_Unloaded(object sender, RoutedEventArgs e)
        {
            //
            // Make sure all the callbacks are removed so disposal works.
            //
            rdpGrid.SizeChanged -= OnGridSizeChanged;
            rdpHost.DpiChanged -= RdpHost_DpiChanged;
            rdp.DesktopResized -= OnRdpDesktopResized;
            rdp.OnRdpConnecting -= OnRdpConnecting;
            rdp.OnRdpConnected -= OnRdpConnected;
            rdp.OnRdpDisconnected -= OnRdpDisconnected;
            rdp.OnRdpError -= OnRdpError;
            m_vm.PropertyChanged -= VmModel_PropertyChanged;

            //
            // https://social.msdn.microsoft.com/Forums/vstudio/en-US/b41a3943-1194-43d7-973b-e5bc8fbb5282/severe-memory-leaks?forum=wpf
            // When mixing Windows Forms and WPF to make sure the ElementHost
            // or WindowsFormsHost is disposed, or you could leak resources.
            // Windows Forms will dispose an ElementHost when the non-modal
            // Form it’s on closes; WPF will dispose a WindowsFormsHost if your
            // application shuts down.  (Really the interop-specific bit here
            // is that you could show a WindowsFormsHost on a Window in a
            // Windows Forms message loop and never get that your Application
            // is shutting down.)"
            //
            // But before disposing the WindowsFormsHost in several cases you
            // should clear the UIElement that contains it for example the Grid:
            //
            rdpGrid.Children.Clear();
            rdpHost.Dispose();
        }

        private RdpOptions MakeRdpOptions()
        {
            var options = new RdpOptions();
            var userOpts = m_vm.GetVmUserSettings().RdpSettings;

            options.EnhancedSession = userOpts.DefaultEnhancedSession;
            options.RedirectClipboard = userOpts.RedirectClipboard;
            options.AudioRedirectionMode = (uint)userOpts.AudioRedirectionMode;
            options.AudioCaptureRedirectionMode = userOpts.AudioCaptureRedirectionMode;
            options.RedirectDrives = userOpts.RedirectDrives;
            options.RedirectDevices = userOpts.RedirectDevices;
            options.RedirectSmartCards = userOpts.RedirectSmartCards;
            options.DesktopWidth = userOpts.DesktopWidth;
            options.DesktopHeight = userOpts.DesktopHeight;

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

            vmCtrlAltDel.IsEnabled = !(bool)vmEnhancedMode.IsChecked;
            vmTypeClipboard.IsEnabled = !(bool)vmEnhancedMode.IsChecked;
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

        private bool ConfirmToolBarAction(string Action)
        {
            if (!UserSettings.Instance.Settings.ConfirmToolBarActions)
            {
                return true;
            }

            var res = UI.MessageBox.Show(
                MessageBoxImage.Warning,
                $"{Action} {m_vm.Name}?",
                MessageBoxButton.YesNo);

            return res == MessageBoxResult.Yes;
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
            if (m_vm.State == IMsvm_ComputerSystem.SystemState.Off ||
                m_vm.State == IMsvm_ComputerSystem.SystemState.Saved ||
                m_vm.State == IMsvm_ComputerSystem.SystemState.Paused)
            {
                m_vm.RequestStateChange(VirtualMachine.StateChange.Enabled);
            }
            else
            {
                if (ConfirmToolBarAction("Turn off"))
                {
                    m_vm.RequestStateChange(VirtualMachine.StateChange.Disabled);
                }
            }
        }

        private void OnPauseCommand(object sender, RoutedEventArgs e)
        {
            if (m_vm.State != IMsvm_ComputerSystem.SystemState.Off)
            {
                if (m_vm.State == IMsvm_ComputerSystem.SystemState.Paused)
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
            if (m_vm.State != IMsvm_ComputerSystem.SystemState.Off)
            {
                if (ConfirmToolBarAction("Reset"))
                {
                    m_vm.RequestStateChange(VirtualMachine.StateChange.Reset);
                }
            }
        }

        private void OnSaveCommand(object sender, RoutedEventArgs e)
        {
            m_vm.RequestStateChange(VirtualMachine.StateChange.Offline);
        }

        private void OnShutdownCommand(object sender, RoutedEventArgs e)
        {
            if (m_vm.State != IMsvm_ComputerSystem.SystemState.Off)
            {
                if (ConfirmToolBarAction("Shut down"))
                {
                    m_vm.RequestStateChange(VirtualMachine.StateChange.Shutdown);
                }
            }
        }

        private void OnRebootCommand(object sender, RoutedEventArgs e)
        {
            if (m_vm.State != IMsvm_ComputerSystem.SystemState.Off)
            {
                if (ConfirmToolBarAction("Reboot"))
                {
                    m_vm.RequestStateChange(VirtualMachine.StateChange.Reboot);
                }
            }
        }

        private void OnCtrlAltDelCommand(object sender, RoutedEventArgs e)
        {
            m_vm.TypeCtrlAltDel();
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

        private void OnCreateCheckpoint(object sender, RoutedEventArgs e)
        {
            new Thread(CreateCheckpoint).Start(m_vm);
        }

        private void CreateCheckpoint(object data)
        {
            (data as VirtualMachine).CreateSnapshot();
        }

        private void OnRevertCheckpoint(object sender, RoutedEventArgs e)
        {
            if (Utility.ConfirmSnapshotAction(null, "Revert to previous checkpoint"))
            {
                new Thread(RevertCheckpoint).Start(m_vm);
            }
        }

        private void RevertCheckpoint(object data)
        {
            (data as VirtualMachine).RevertSnapshot();
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

            if (m_prevEnhancedState == IMsvm_ComputerSystem.EnhancedSessionMode.AllowedAndAvailable)
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
