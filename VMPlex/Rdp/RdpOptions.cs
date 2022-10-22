/*
 * Copyright (c) 2022 Ira Strawser. All rights reserved.
 */

using System;
using System.Collections.Generic;
using System.Text;

namespace VMPlex
{
    public class RdpOptions
    {
        public RdpOptions()
        {
            // sensible defaults

            Server = "localhost";
            Port = 2179;
            DesktopWidth = 1024;
            DesktopHeight = 768;
            FrameBufferRedirection = true;
            MultiMonitor = false;
            EnhancedSession = true;
            ColorDepth = 32;
            EnhancedGraphics = true;
            FontSmoothing = true;
            DesktopComposition = true;
            HardwareAssist = true;
            RedirectClipboard = true;
            RedirectDrives = false;
            RedirectDevices = false;
            RedirectPorts = false;
            RedirectSmartCards = false;
        }

        public string Server { get; set; }
        public int Port { get; set; }
        public int DesktopWidth { get; set; }
        public int DesktopHeight { get; set; }
        public bool FrameBufferRedirection { get; set; }
        public bool MultiMonitor { get; set; }              // causes lag when enabled on non-enhanced sessions
        public bool EnhancedSession { get; set; }
        public bool EnhancedGraphics { get; set; }
        public bool FontSmoothing { get; set; }
        public bool DesktopComposition { get; set; }
        public bool HardwareAssist { get; set; }            // hardware is used to decode rdp session

        // the following only apply to enhanced sessions
        public int ColorDepth { get; set; }
        public bool RedirectClipboard { get; set; }
        public bool RedirectDrives { get; set; }
        public bool RedirectDevices { get; set; }
        public bool RedirectPorts { get; set; }
        public bool RedirectSmartCards { get; set; }
    }
}
