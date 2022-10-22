/*
 * Copyright (c) 2022 Ira Strawser. All rights reserved.
 */

using System;
using System.Windows;
using System.Windows.Forms;
using Microsoft.Win32;

using AxMSTSCLib;
using MSTSCLib;
using ORMi;
using VMPlex.WMI;

namespace VMPlex
{
    class RdpClient : AxMsRdpClient9NotSafeForScripting
    {
        enum RdpState
        {
            Disconnected,
            Connecting,
            Connected
        }

        public class DesktopResizedArgs : EventArgs
        {
            public int Width { get; set; }
            public int Height { get; set; }
        }

        // Members
        private IMsRdpClient9 m_ocx;
        private RdpState m_state = RdpState.Disconnected;
        private bool m_enhancedSwitch = false;
        private bool m_eventsInitialized = false;
        private object m_stateLock = new object();

        private WMIWatcher m_watcher;
        private Msvm_ComputerSystem m_vm;
        private RdpOptions m_options;

        public bool Enhanced { get; private set; }

        // Events
        public delegate void OnConnectedHandler(object sender);
        public delegate void OnConnectingHandler(object sender);
        public delegate void OnDisconnectedHandler(object sender);
        public event EventHandler MouseActivate;
        public event EventHandler DesktopResized;
        public event OnConnectedHandler OnRdpConnected;
        public event OnConnectingHandler OnRdpConnecting;
        public event OnDisconnectedHandler OnRdpDisconnected;

        // Methods
        public RdpClient()
        {
            base.SetStyle(ControlStyles.EnableNotifyMessage, true);
        }

        public void InitializeForLocalVmConnection(VirtualMachine vm, RdpOptions options)
        {
            AttachInterfaces();
            m_ocx = (IMsRdpClient9)GetOcx();
            m_vm = VMManager.GetVMByGuid(vm.Guid);
            m_options = options;

            Server = options.Server;
            AdvancedSettings2.RDPPort = options.Port;
            ColorDepth = m_options.ColorDepth;
            DesktopWidth = options.DesktopWidth;
            DesktopHeight = options.DesktopHeight;

            int perfflags = 0;
            if (options.EnhancedGraphics)
            {
                perfflags |= 0x10; // TF_PERF_ENABLE_ENHANCED_GRAPHICS
            }
            if (options.FontSmoothing)
            {
                perfflags |= 0x80; // TF_PERF_ENABLE_FONT_SMOOTHING
            }
            if (options.DesktopComposition)
            {
                perfflags |= 0x100; // TF_PERF_ENABLE_DESKTOP_COMPOSITION
            }
            AdvancedSettings2.PerformanceFlags = perfflags;
            AdvancedSettings2.GrabFocusOnConnect = false;
            AdvancedSettings2.minInputSendInterval = 20; // mouse input sent every 20 ms

            AdvancedSettings3.EnableAutoReconnect = false;

            AdvancedSettings6.SmartSizing = false;
            AdvancedSettings6.RedirectClipboard = m_options.RedirectClipboard;
            AdvancedSettings6.RedirectDrives = m_options.RedirectDrives;
            AdvancedSettings6.RedirectDevices = m_options.RedirectDevices;
            AdvancedSettings6.RedirectPorts = m_options.RedirectPorts;
            AdvancedSettings6.RedirectSmartCards = m_options.RedirectSmartCards;
            AdvancedSettings6.RedirectPOSDevices = false;

            AdvancedSettings7.AuthenticationServiceClass = "Microsoft Virtual Console Service";
            AdvancedSettings7.RelativeMouseMode = true;

            SecuredSettings2.KeyboardHookMode = 1; // apply remotely (fixes windows key, alt-tab, etc)

            SetExtendedProperty("DesktopScaleFactor", GetDesktopScaleFactor());
            SetExtendedProperty("DeviceScaleFactor", 100u);

            if (options.HardwareAssist)
            {
                SetExtendedProperty("EnableHardwareMode", true);
            }

            DisableConnectionBar();
            SetMaximumNetworkThroughput();
            SetSecureModeOn();

            if (options.FrameBufferRedirection)
            {
                EnableFrameBufferRedirection();
            }

            if (options.MultiMonitor)
            {
                EnableMultiMon();
            }

            InitEvents();
        }

        public bool IsReady()
        {
            return m_eventsInitialized;
        }

        public void InitEvents()
        {
            if (m_eventsInitialized)
            {
                return;
            }

            OnConnected += OnConnect;
            OnDisconnected += OnDisconnect;
            OnRemoteDesktopSizeChange += OnRemoteDesktopSizeChanged;
            OnEnterFullScreenMode += OnEnteredFullScreenMode;
            OnLeaveFullScreenMode += OnLeftFullScreenMode;

            m_watcher = VMManager.CreateMsvmWatcher(m_vm.Guid);
            m_watcher.WMIEventArrived += OnWmiVMInstanceChange;
            m_vm.PropertyChanged += OnVmPropertyChanged;

            m_eventsInitialized = true;
        }

        public void StopEvents()
        {
            if (!m_eventsInitialized)
            {
                return;
            }
            m_eventsInitialized = false;
            OnConnected -= OnConnect;
            OnDisconnected -= OnDisconnect;
            OnRemoteDesktopSizeChange -= OnRemoteDesktopSizeChanged;
            OnEnterFullScreenMode -= OnEnteredFullScreenMode;
            OnLeaveFullScreenMode -= OnLeftFullScreenMode;

            m_watcher.Stop();
            m_watcher.WMIEventArrived -= OnWmiVMInstanceChange;
            m_watcher = null;
            m_vm.PropertyChanged -= OnVmPropertyChanged;
        }

        public override void Connect()
        {
            ConnectInternal(m_options.EnhancedSession);
        }

        public override void Disconnect()
        {
            System.Diagnostics.Debug.Print("Explicit disconnect");
            try
            {
                base.Disconnect();
            }
            catch (Exception)
            {
            }
        }

        public void Shutdown()
        {
            System.Diagnostics.Debug.Print("Rdp shutdown");
            StopEvents();
            Disconnect();
        }

        private void ConnectInternal(bool EnableEnhancedMode)
        {
            lock(m_stateLock)
            {
                if (!IsVideoAvailable())
                {
                    return;
                }

                InitEvents();

                if (m_state != RdpState.Disconnected)
                {
                    System.Diagnostics.Debug.Print("Called Connect on rdp session not in Disconnected state. Ignoring Connect call.");
                    return;
                }

                AdvancedSettings7.PCB = m_vm.Guid;
                Enhanced = false;
                if (EnableEnhancedMode)
                {
                    if (m_vm.EnhancedSessionModeState == Msvm_ComputerSystem.EnhancedSessionMode.AllowedAndAvailable)
                    {
                        Enhanced = true;
                        AdvancedSettings7.PCB += ";EnhancedMode=1";
                        System.Diagnostics.Debug.Print("Enhanced mode set");
                    }
                    else
                    {
                        System.Diagnostics.Debug.Print("Enhanced requested but unavailable");
                    }
                }

                System.Diagnostics.Debug.Print("Connecting");
                m_state = RdpState.Connecting;
                OnRdpConnecting?.Invoke(this);
                base.Connect();
            }
        }

        public bool TryResize(int width, int height)
        {
            if (!m_eventsInitialized)
            { 
                return false; 
            }
            if (Enhanced)
            {
                if (EnhancedModeUpdateScreen() == false)
                {
                    return false;
                }
                this.Size = new System.Drawing.Size(width, height);
                return true;
            }
            return false;
        }

        private void OnVmPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
        }

        protected void OnWmiVMInstanceChange(object sender, WMIEventArgs e)
        {
            var vm = (Msvm_ComputerSystem)ORMi.Helpers.TypeHelper.LoadObject(((ModificationEvent)e.Object).TargetInstance, typeof(Msvm_ComputerSystem));

            if (vm.State == m_vm.State && vm.EnhancedSessionModeState == m_vm.EnhancedSessionModeState)
            {
                // no change we care about here, but update the object
                m_vm = vm;
                return;
            }
            System.Diagnostics.Debug.Print("VM Event. State = {0}, EnhancedSessionModeState = {1}", vm.State, vm.EnhancedSessionModeState);

            // VM Event. State = Other, EnhancedSessionModeState = NotAllowed  <-- Pausing
            // VM Event. State = Paused, EnhancedSessionModeState = NotAllowed <-- Paused

            m_vm = vm;
            if (!IsVideoAvailable(vm))
            {
                if (vm.EnhancedSessionModeState == Msvm_ComputerSystem.EnhancedSessionMode.NotAllowed)
                {
                    if (vm.State == Msvm_ComputerSystem.SystemState.Other)
                    {
                        return;
                    }
                    else if (vm.State == Msvm_ComputerSystem.SystemState.Paused)
                    {
                        System.Diagnostics.Debug.Print("VM paused");
                        return;
                    }
                    else if (vm.State == Msvm_ComputerSystem.SystemState.Saved)
                    {
                        System.Diagnostics.Debug.Print("VM saved");
                        return;
                    }
                }
                Disconnect();
                return;
            }

            lock(m_stateLock)
            {
                if (m_state == RdpState.Disconnected)
                {
                    // vm is now available
                    ConnectInternal(m_options.EnhancedSession);
                    return;
                }

                if (m_state == RdpState.Connected &&
                    m_options.EnhancedSession &&
                    !Enhanced &&
                    m_vm.EnhancedSessionModeState == Msvm_ComputerSystem.EnhancedSessionMode.AllowedAndAvailable)
                {
                    // reconnect in enhanced
                    System.Diagnostics.Debug.Print("Should reconnect in enhanced mode now");
                    m_enhancedSwitch = true;
                    Disconnect();
                    return;
                }
            }
        }

        protected void OnConnect(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.Print("Connected");
            lock(m_stateLock)
            {
                m_state = RdpState.Connected;

                if (m_options.EnhancedSession && !Enhanced && m_vm.EnhancedSessionModeState == Msvm_ComputerSystem.EnhancedSessionMode.AllowedAndAvailable)
                {
                    // reconnect in an enhanced session
                }
                else
                {
                    EmitDesktopResized(DesktopWidth, DesktopHeight);
                    OnRdpConnected?.Invoke(this);
                }
            }
        }

        protected void OnDisconnect(object sender, IMsTscAxEvents_OnDisconnectedEvent e)
        {
            lock(m_stateLock)
            {
                m_state = RdpState.Disconnected;

                ExtendedDisconnectReasonCode code = ExtendedDisconnectReason;

                // discReason | code
                // 1          | exDiscReasonNoInfo                 | Disconnected by explicit call to Disconnect()
                // 2          | exDiscReasonNoInfo                 | Disconnected during shutdown
                // 2          | exDiscReasonLogoffByUser           | Disconnected during logout in enhanced session
                // 3          | exDiscReasonAPIInitiatedDisconnect | Disconnected during restart/shutdown (this does not happen everytime)
                // 3          | exDiscReasonNoInfo                 | Disconnected during restart after reconnecting and enhanced is unavailable and setting rdp size in error to exact same size
                //                                                 | Also happens when another RDP session starts and disconnects us
                // 4          | exDiscReasonNoInfo                 | After a period of time after VM has shutdown (also happens when paused in enhanced mode)
                // 3334       | exDiscReasonNoInfo                 | RDP is broken and the VM likely needs to be rebooted

                System.Diagnostics.Debug.Print("Disconnected. Reason = {0}, Extended = {1}", e.discReason, code, GetErrorDescription((uint)e.discReason, (uint)code));

                if (e.discReason == 1 && code == ExtendedDisconnectReasonCode.exDiscReasonNoInfo)
                {
                    if (m_enhancedSwitch)
                    {
                        m_enhancedSwitch = false;
                        ConnectInternal(m_options.EnhancedSession);
                        return;
                    }
                    //if (!Enhanced && m_options.EnhancedSession && m_vm.EnhancedSessionModeState == Msvm_ComputerSystem.EnhancedSessionMode.AllowedAndAvailable)
                    //{
                    //}
                }
                else if (e.discReason == 2 && code == ExtendedDisconnectReasonCode.exDiscReasonLogoffByUser)
                {
                    ConnectInternal(m_options.EnhancedSession);
                    return;
                }
                else if (e.discReason == 3 && code == ExtendedDisconnectReasonCode.exDiscReasonAPIInitiatedDisconnect)
                {
                    ConnectInternal(m_options.EnhancedSession);
                    return;
                }
                else if (e.discReason == 4 && code == ExtendedDisconnectReasonCode.exDiscReasonNoInfo && m_vm.State == Msvm_ComputerSystem.SystemState.Paused)
                {
                    ConnectInternal(m_options.EnhancedSession);
                    return;
                }
                //else if (e.discReason == 3 && code == ExtendedDisconnectReasonCode.exDiscReasonNoInfo)
                //{
                //    ConnectInternal(m_options.EnhancedSession);
                //    return;
                //}
                OnRdpDisconnected?.Invoke(this);
            }
        }

        protected void OnRemoteDesktopSizeChanged(object sender, IMsTscAxEvents_OnRemoteDesktopSizeChangeEvent e)
        {
            if (Enhanced == false)
            {
                System.Diagnostics.Debug.Print("Desktop size changed W: {0} H: {1}", e.width, e.height);
                this.ClientSize = new System.Drawing.Size(DesktopWidth, DesktopHeight);
                EmitDesktopResized(e.width, e.height);
            }
        }

        protected void OnEnteredFullScreenMode(object sender, EventArgs e)
        {
            if (Enhanced)
            {
                EnhancedModeUpdateScreen();
            }
        }

        protected void OnLeftFullScreenMode(object sender, EventArgs e)
        {
            if (Enhanced)
            {
                EnhancedModeUpdateScreen();
            }
        }

        protected override void OnNotifyMessage(Message m)
        {
            base.OnNotifyMessage(m);
            int WM_MOUSEACTIVATE = 0x21;
            if (m.Msg == WM_MOUSEACTIVATE && MouseActivate != null)
            {
                MouseActivate(this, EventArgs.Empty);
            }
        }

        public bool IsVideoAvailable(Msvm_ComputerSystem wmivm = null)
        {
            Msvm_ComputerSystem.SystemState state = m_vm.State;
            if (wmivm != null)
            {
                state = wmivm.State;
            }
            switch (state)
            {
                case Msvm_ComputerSystem.SystemState.Running:
                case Msvm_ComputerSystem.SystemState.Paused:
                case Msvm_ComputerSystem.SystemState.Pausing:
                case Msvm_ComputerSystem.SystemState.Stopping:
                case Msvm_ComputerSystem.SystemState.Saving:
                    return true;
            }
            return false;
        }

        public uint GetDesktopScaleFactor()
        {
            using (var graphics = System.Drawing.Graphics.FromHwnd(this.Handle))
            {
                return (uint)(graphics.DpiX / 96.0 * 100.0);
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            if (m_ocx == null || Connected != 1 || Enhanced == false)
            {
                return;
            }

            //if (Enhanced)
            //{
            //    // This can happen during logon or during logoff

            //    // User logged out or did something that resized the screen which shouldn't happen in normal enhanced
            //    System.Diagnostics.Debug.Print("User logged out. Resize in enhanced mode");
            //    Disconnect();
            //    return;
            //}

            EnhancedModeUpdateScreen();
        }

        private bool EnhancedModeUpdateScreen()
        {
            if (FullScreen)
            {
                try
                {
                    SyncSessionDisplaySettings();
                    return true;
                }
                catch(Exception)
                {
                    return false;
                }
            }

            uint desktopScaleFactor = GetDesktopScaleFactor();
            uint width = (uint)ClientRectangle.Width;
            uint height = (uint)ClientRectangle.Height;
            double physW = (double)width / desktopScaleFactor * 25.4;
            double physH = (double)height / desktopScaleFactor * 25.4;

            System.Diagnostics.Debug.WriteLine("EnhancedModeUpdateScreen {0} {1} {2} {3}", width, height, physW, physH);

            try
            {
                // Only works in enhanced mode (EnhancedMode=1) and when logged in
                m_ocx.UpdateSessionDisplaySettings(
                    width,
                    height,
                    (uint)physW,
                    (uint)physH,
                    0,
                    desktopScaleFactor,
                    100);
                EmitDesktopResized((int)width, (int)height);
                return true;
            }
            catch(Exception)
            {
                //System.Diagnostics.Debug.WriteLine("Exception when UpdateSessionDisplaySettings");
            }
            return false;
        }

        private void EmitDesktopResized(int width, int height)
        {
            DesktopResizedArgs args = new DesktopResizedArgs();
            args.Width = width;
            args.Height = height;
            DesktopResized(this, args);
        }

        private void SetExtendedProperty<T>(string property, T value)
        {
            var extendedSettings = (IMsRdpExtendedSettings)GetOcx();
            if (extendedSettings == null)
            {
                return;
            }
            object oVal = value;
            try
            {
                extendedSettings.set_Property(property, ref oVal);
            }
            catch(Exception)
            {
                System.Diagnostics.Debug.WriteLine("Exception while setting extended property");
            }
        }

        public void EnableMultiMon()
        {
            ((IMsRdpClientNonScriptable5)GetOcx()).UseMultimon = true;
        }

        public void DisableMultiMon()
        {
            ((IMsRdpClientNonScriptable5)GetOcx()).UseMultimon = false;
        }

        public void DisableConnectionBar()
        {
            ((IMsRdpClientNonScriptable5)GetOcx()).DisableConnectionBar = true;
        }

        public void SetMaximumNetworkThroughput()
        {
            AdvancedSettings8.NetworkConnectionType = 6; // CONNECTION_TYPE_LAN
        }

        private void SetSecureModeOn()
        {
            AdvancedSettings6.AuthenticationLevel = 0; // no auth
            var ocx = (IMsRdpClientNonScriptable3)GetOcx();
            ocx.EnableCredSspSupport = true;
            ocx.NegotiateSecurityLayer = false;

            try
            {
                var extendedSettings = (IMsRdpExtendedSettings)ocx;
                object pValue = true;
                extendedSettings.set_Property("DisableCredentialsDelegation", ref pValue);
                //extendedSettings.set_Property("EnableHardwareMode", ref True);
            }
            catch (Exception)
            {
                System.Diagnostics.Debug.WriteLine("Ignoring failure to set the DisableCredentialsDelegation property on the RDP control.");
            }
        }

        public void EnableFrameBufferRedirection()
        {
            bool enabled = true;
            try
            {
                using (RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion\Virtualization"))
                {
                    if (key != null)
                    {
                        object val = key.GetValue("DisableFrameBufferRedirection");
                        if (val != null && val is int)
                        {
                            enabled = (int)val == 0;
                        }
                    }
                }
            }
            catch (Exception)
            {
            }
            try
            {
                if (enabled)
                {
                    //System.Diagnostics.Debug.Print("Enabling frame buffer redirection");
                    object pValue = true;
                    ((IMsRdpExtendedSettings)GetOcx()).set_Property("EnableFrameBufferRedirection", ref pValue);
                }
                else
                {
                    //System.Diagnostics.Debug.Print("Frame buffer redirection disabled by system setting");
                }
            }
            catch (Exception)
            {
                //System.Diagnostics.Debug.Print("Exception while enabling frame buffer redirection");
            }

        }
    }
}
