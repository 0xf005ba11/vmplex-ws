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
using System.DirectoryServices.ActiveDirectory;

namespace VMPlex.UI
{
    /// <summary>
    /// Interaction logic for RdpPage.xaml
    /// </summary>
    public partial class RdpPage : UserControl, INotifyPropertyChanged
    {
        private readonly DispatcherTimer m_timer = new DispatcherTimer();

        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyChange(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public RdpPage(RdpSettings settings)
        {
            InitializeComponent();
            connectingText.Content = $"Connecting to {settings.Server}..."; 
            Connect(settings);
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

        private RdpOptions MakeRdpOptions(RdpSettings settings)
        {
            var options = new RdpOptions();

            options.Domain = settings.Domain;
            options.Server = settings.Server;
            options.Port = 3389;
            options.EnhancedSession = settings.DefaultEnhancedSession;
            options.RedirectClipboard = settings.RedirectClipboard;
            options.AudioRedirectionMode = (uint)settings.AudioRedirectionMode;
            options.AudioCaptureRedirectionMode = settings.AudioCaptureRedirectionMode;
            options.RedirectDrives = settings.RedirectDrives;
            options.RedirectDevices = settings.RedirectDevices;
            options.RedirectSmartCards = settings.RedirectSmartCards;
            options.DesktopWidth = settings.DesktopWidth;
            options.DesktopHeight = settings.DesktopHeight;

            return options;
        }

        private void Connect(RdpSettings settings)
        {
            rdpHost.Height = rdp.Height;
            rdpHost.Width = rdp.Width;
            rdpGrid.SizeChanged += OnGridSizeChanged;
            rdpHost.DpiChanged += RdpHost_DpiChanged;
            rdp.DesktopResized += OnRdpDesktopResized;

            rdp.InitializeForRemoteDesktopConnection(MakeRdpOptions(settings));

            m_timer.Tick += OnResizeTimer;
            rdp.OnRdpConnecting += OnRdpConnecting;
            rdp.OnRdpConnected += OnRdpConnected;
            rdp.OnRdpDisconnected += OnRdpDisconnected;
            rdp.OnRdpError += OnRdpError;

            rdp.Connect();
        }

        private void OnRdpConnecting(object sender)
        {
            this.Dispatcher.Invoke(() =>
            {
                connectingText.Visibility = Visibility.Visible;
                reconnectButton.Visibility = Visibility.Hidden;
                rdpHost.Visibility = Visibility.Hidden;
            });
        }

        private void OnRdpConnected(object sender)
        {
            System.Diagnostics.Debug.Print("Rdp connected");
            connectingText.Visibility = Visibility.Hidden;
            reconnectButton.Visibility = Visibility.Hidden;
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
                reconnectButton.Visibility = Visibility.Visible;
                rdpHost.Visibility = System.Windows.Visibility.Hidden;
            });
            m_timer.Stop();
        }

        private void OnRdpError(object sender, RdpClient.RdpError error)
        {
            this.Dispatcher.Invoke(() =>
            {
                connectingText.Visibility = Visibility.Hidden;
                reconnectButton.Visibility = Visibility.Visible;
                rdpHost.Visibility = Visibility.Hidden;
            });
        }

        private void RdpConnectButton_Click(object sender, object e)
        {
            Disconnect();
            rdp.Connect();
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
