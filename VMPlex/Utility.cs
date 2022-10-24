/*
 * Copyright (c) 2022 Ira Strawser. All rights reserved.
 */

using System;
using System.Windows;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;

namespace VMPlex
{
    class Utility
    {
        private static IntPtr selfJobObject = IntPtr.Zero;

        [StructLayout(LayoutKind.Sequential)]
        public struct SECURITY_ATTRIBUTES
        {
            public int nLength;
            public IntPtr lpSecurityDescriptor;
            public int bInheritHandle;
        }

        public enum JOBOBJECTINFOCLASS
        {
            AssociateCompletionPortInformation = 7,
            BasicLimitInformation = 2,
            BasicUIRestrictions = 4,
            EndOfJobTimeInformation = 6,
            ExtendedLimitInformation = 9,
            SecurityLimitInformation = 5,
            GroupInformation = 11
        }

        [Flags]
        public enum JOBOBJECTLIMIT : uint
        {
            // Basic Limits
            Workingset = 0x00000001,
            ProcessTime = 0x00000002,
            JobTime = 0x00000004,
            ActiveProcess = 0x00000008,
            Affinity = 0x00000010,
            PriorityClass = 0x00000020,
            PreserveJobTime = 0x00000040,
            SchedulingClass = 0x00000080,

            // Extended Limits
            ProcessMemory = 0x00000100,
            JobMemory = 0x00000200,
            DieOnUnhandledException = 0x00000400,
            BreakawayOk = 0x00000800,
            SilentBreakawayOk = 0x00001000,
            KillOnJobClose = 0x00002000,
            SubsetAffinity = 0x00004000,

            // Notification Limits
            JobReadBytes = 0x00010000,
            JobWriteBytes = 0x00020000,
            RateControl = 0x00040000,
        }

        [StructLayout(LayoutKind.Sequential)]
        struct JOBOBJECT_BASIC_LIMIT_INFORMATION
        {
            public Int64 PerProcessUserTimeLimit;
            public Int64 PerJobUserTimeLimit;
            public JOBOBJECTLIMIT LimitFlags;
            public UIntPtr MinimumWorkingSetSize;
            public UIntPtr MaximumWorkingSetSize;
            public UInt32 ActiveProcessLimit;
            public Int64 Affinity;
            public UInt32 PriorityClass;
            public UInt32 SchedulingClass;
        }

        [StructLayout(LayoutKind.Sequential)]
        struct IO_COUNTERS
        {
            public UInt64 ReadOperationCount;
            public UInt64 WriteOperationCount;
            public UInt64 OtherOperationCount;
            public UInt64 ReadTransferCount;
            public UInt64 WriteTransferCount;
            public UInt64 OtherTransferCount;
        }

        [StructLayout(LayoutKind.Sequential)]
        struct JOBOBJECT_EXTENDED_LIMIT_INFORMATION
        {
            public JOBOBJECT_BASIC_LIMIT_INFORMATION BasicLimitInformation;
            public IO_COUNTERS IoInfo;
            public UIntPtr ProcessMemoryLimit;
            public UIntPtr JobMemoryLimit;
            public UIntPtr PeakProcessMemoryUsed;
            public UIntPtr PeakJobMemoryUsed;
        }

        [DllImport("kernel32.dll", CharSet = CharSet.Unicode)]
        static public extern IntPtr CreateJobObject([In] ref SECURITY_ATTRIBUTES lpJobAttributes, IntPtr name);

        [DllImport("kernel32.dll", CharSet = CharSet.Unicode)]
        static public extern bool AssignProcessToJobObject(IntPtr hJob, IntPtr hProcess);

        [DllImport("kernel32.dll", CharSet = CharSet.Unicode)]
        static public extern bool SetInformationJobObject(IntPtr hJob, JOBOBJECTINFOCLASS infoClass, IntPtr jobObjectInfo, uint size);

        static public void ErrorPopup(string message)
        {
            ModernWpf.MessageBox.Show(message, "Error", MessageBoxButton.OK, ModernWpf.SymbolGlyph.Error);
        }

        static public void CreateSelfJob()
        {
            SECURITY_ATTRIBUTES sa = new SECURITY_ATTRIBUTES();
            sa.nLength = Marshal.SizeOf(sa);
            sa.lpSecurityDescriptor = IntPtr.Zero;
            sa.bInheritHandle = 0;

            JOBOBJECT_EXTENDED_LIMIT_INFORMATION jobInfo = new JOBOBJECT_EXTENDED_LIMIT_INFORMATION();
            jobInfo.BasicLimitInformation.LimitFlags = JOBOBJECTLIMIT.KillOnJobClose;

            selfJobObject = CreateJobObject(ref sa, IntPtr.Zero);
            AssignProcessToJobObject(selfJobObject, System.Diagnostics.Process.GetCurrentProcess().Handle);

            IntPtr jobInfoPtr = Marshal.AllocHGlobal(Marshal.SizeOf(jobInfo));
            Marshal.StructureToPtr(jobInfo, jobInfoPtr, false);
            SetInformationJobObject(selfJobObject, JOBOBJECTINFOCLASS.ExtendedLimitInformation, jobInfoPtr, (uint)Marshal.SizeOf(jobInfo));
        }

        static public void LaunchHvintegrateInJob(string[] args)
        {
            string path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);

            Process hvintegrate = new Process();
            hvintegrate.StartInfo.FileName = path + "\\hvintegrate.exe";
            hvintegrate.StartInfo.Arguments = String.Join(" ", args);
            hvintegrate.Start();
            bool f = AssignProcessToJobObject(selfJobObject, hvintegrate.Handle);
        }
    }
}
