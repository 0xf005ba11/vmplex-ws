/*
 * Copyright (c) 2022 Ira Strawser. All rights reserved.
 */

using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using System.IO;
using VMPlex.WMI;

namespace VMPlex.UI
{
    /// <summary>
    /// Interaction logic for VmRdpPage.xaml
    /// </summary>
    public partial class VmRdpPage : UserControl
    {
        private readonly DispatcherTimer m_timer = new DispatcherTimer();
        //private Msvm_ComputerSystem.SystemState m_vmPrevState;
        private bool m_prevVideoAvail;
        private Msvm_ComputerSystem.EnhancedSessionMode m_prevEnhancedState;
        private VirtualMachine m_vm;
        public string VmGuid {  get { return m_vm.Guid; } }

        public VmRdpPage(VirtualMachine vmModel, bool enhanced)
        {
            m_vm = vmModel;

            InitializeComponent();
            Connect(vmModel, enhanced);
        }

        private void Connect(VirtualMachine vmModel, bool enhanced)
        {
            m_prevVideoAvail = m_vm.IsVideoAvailable();
            m_prevEnhancedState = m_vm.EnhancedSessionModeState;

            rdpHost.Height = rdp.Height;
            rdpHost.Width = rdp.Width;
            rdpGrid.SizeChanged += OnSizeChanged;
            rdpHost.SizeChanged += RdpHost_SizeChanged;
            rdp.DesktopResized += OnRdpResized;

            RdpOptions options = new RdpOptions();
            options.EnhancedSession = enhanced;
            rdp.InitializeForLocalVmConnection(m_vm, options);

            m_vm.PropertyChanged += VmModel_PropertyChanged;
            m_timer.Tick += OnResizeTimer;
            rdp.OnRdpConnected += OnRdpConnected;
            rdp.OnRdpDisconnected += OnRdpDisconnected;

            vmEnhancedMode.Checked -= OnEnhancedChecked;
            vmEnhancedMode.Unchecked -= OnEnhancedUnchecked;
            if (vmModel.IsVideoAvailable())
            {
                rdp.Connect();
                rdpHost.Visibility = System.Windows.Visibility.Visible;
                vmEnhancedMode.IsChecked = enhanced && vmModel.EnhancedSessionModeState != Msvm_ComputerSystem.EnhancedSessionMode.NotAllowed;
            }
            else
            {
                offlineText.Visibility = System.Windows.Visibility.Visible;
                vmEnhancedMode.IsChecked = false;
            }
            vmEnhancedMode.Checked += OnEnhancedChecked;
            vmEnhancedMode.Unchecked += OnEnhancedUnchecked;
        }

        private void OnEnhancedChecked(object sender, RoutedEventArgs e)
        {
            rdp.Shutdown();
            ((TabItem)Parent).Content = new VmRdpPage(m_vm, true);
        }

        private void OnEnhancedUnchecked(object sender, RoutedEventArgs e)
        {
            rdp.Shutdown();
            ((TabItem)Parent).Content = new VmRdpPage(m_vm, false);
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

        private void OnRdpConnected(object sender)
        {
            System.Diagnostics.Debug.Print("Rdp connected");
            offlineText.Visibility = System.Windows.Visibility.Hidden;
            rdpHost.Visibility = System.Windows.Visibility.Visible;
        }

        private void OnRdpDisconnected(object sender)
        {
            System.Diagnostics.Debug.Print("Rdp disconnected");
            rdpHost.Visibility = System.Windows.Visibility.Hidden;
            offlineText.Visibility = System.Windows.Visibility.Visible;
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
                StartResizeTimer();
            }
            m_prevEnhancedState = vm.EnhancedSessionModeState;
        }

        private void RdpHost_SizeChanged(object sender, System.Windows.SizeChangedEventArgs e)
        {
            if (rdp.DesktopHeight == (int)rdpHost.ActualHeight && rdp.DesktopWidth == (int)rdpHost.ActualWidth)
            {
                return;
            }

            System.Diagnostics.Debug.Print("rdp host resized {0} {1}", (int)rdpHost.ActualHeight, (int)rdpHost.ActualWidth);

/*                if (rdp.TryResize((int)rdpHost.ActualWidth, (int)rdpHost.ActualHeight))
                {
                    rdpHost.Height = rdpGrid.ActualHeight;
                    rdpHost.Width = rdpGrid.ActualWidth;
                } */
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

        private void OnRdpResized(object sender, EventArgs e)
        {
            var args = (RdpClient.DesktopResizedArgs)e;
            System.Diagnostics.Debug.Print("Received desktop resized {0} {1}", args.Width, args.Height);

            double scaleFactor = (double)rdp.GetDesktopScaleFactor() / 100.0;
            if (rdp.Enhanced)
            {
                scaleFactor = 1.0;
            }

            if (rdpHost.Height != args.Height || rdpHost.Width != args.Width)
            {
                rdpHost.Height = Math.Min(args.Height / scaleFactor, rdpGrid.ActualHeight);
                rdpHost.Width = Math.Min(args.Width / scaleFactor, rdpGrid.ActualWidth);
            }

            if (rdp.Enhanced && (rdpHost.Width != rdpGrid.ActualWidth || rdpHost.Height != rdpGrid.ActualHeight))
            {
                StartResizeTimer();
            }
        }

        private void OnSizeChanged(object sender, EventArgs e)
        {
            if (rdp.Enhanced)
            {
                System.Diagnostics.Debug.Print("on size changed");
                if (rdp.TryResize((int)rdpHost.ActualWidth, (int)rdpHost.ActualHeight))
                {
                    return;
                }
                // start a timer to continually attempt to resize until it works while in enhanced mode (rdp activex control limitations)
                StartResizeTimer();
            }
            double scaleFactor = (double)rdp.GetDesktopScaleFactor() / 100.0;
            rdpHost.Height = Math.Min(rdp.DesktopHeight / scaleFactor, rdpGrid.ActualHeight);
            rdpHost.Width = Math.Min(rdp.DesktopWidth / scaleFactor, rdpGrid.ActualWidth);
        }

        private void OnResizeTimer(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.Print("on resize timer {0} {1}", rdpGrid.ActualWidth, rdpGrid.ActualHeight);
            if (rdp.IsVideoAvailable() == false || rdp.TryResize((int)rdpGrid.ActualWidth, (int)rdpGrid.ActualHeight))
            {
                m_timer.Stop();
                System.Diagnostics.Debug.Print("rdp resize timer stopped in OnResizeTimer");
                return;
            }
        }

        private void StartResizeTimer()
        {
            System.Diagnostics.Debug.Print("Starting rdp resize timer");
            m_timer.Stop();
            m_timer.Interval = new TimeSpan(0, 0, 0, 1, 0);
            m_timer.Start();
        }
    }
}
