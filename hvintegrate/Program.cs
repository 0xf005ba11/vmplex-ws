/*
 * Copyright (c) 2022 Ira Strawser. All rights reserved.
 */

using System;
using System.Windows.Forms;

namespace hvintegrate
{
    class Program
    {
        private static System.Reflection.Assembly client = null;
        private static System.Reflection.Assembly clientCommon = null;
        private static System.Reflection.Assembly clientSettings = null;
        private static System.Reflection.Assembly clientManagement = null;
        private static System.Reflection.Assembly clientWizards = null;
        private static System.Type IVMComputerSystem = null;
        private static System.Type IVMComputerSystemSetting = null;
        private static System.Type WindowsCredential = null;
        private static System.Type ConnectionHelper = null;
        private static System.Type VMSettingsDialog = null;
        private static System.Type NetworkManagerDialog = null;
        private static System.Type VirtualizationSettingsDialog = null;
        private static System.Type VMComputerSystemState = null;
        private static System.Type VMComputerSystemOperationalStatus = null;
        private static System.Type Server = null;
        private static System.Type InformationDisplayer = null;
        private static System.Type IUserPassCredential = null;
        private static System.Type VMWizardForm = null;
        private static System.Type NewVirtualMachineWizard = null;
        private static System.Type EditVirtualHardDiskWizard = null;
        private static object ServerConnection = null;
        private static object Displayer = null;

        static bool Initialize()
        {
            AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(Utility.ResolveAssembly);

            try
            {
                client = Utility.LoadGACAssembly("Microsoft.Virtualization.Client");
                clientCommon = Utility.LoadGACAssembly("Microsoft.Virtualization.Client.Common");
                clientSettings = Utility.LoadGACAssembly("Microsoft.Virtualization.Client.Settings");
                clientManagement = Utility.LoadGACAssembly("Microsoft.Virtualization.Client.Management");
                clientWizards = Utility.LoadGACAssembly("Microsoft.Virtualization.Client.Wizards");
                WindowsCredential = clientCommon.GetType("Microsoft.Virtualization.Client.Common.WindowsCredential", true);
                IUserPassCredential = WindowsCredential.GetInterface("IUserPassCredential");
                IVMComputerSystem = clientManagement.GetType("Microsoft.Virtualization.Client.Management.IVMComputerSystem", true);
                IVMComputerSystemSetting = clientManagement.GetType("Microsoft.Virtualization.Client.Management.IVMComputerSystemSetting", true);
                VMComputerSystemState = clientManagement.GetType("Microsoft.Virtualization.Client.Management.VMComputerSystemState", true);
                VMComputerSystemOperationalStatus = clientManagement.GetType("Microsoft.Virtualization.Client.Management.VMComputerSystemOperationalStatus", true);
                Server = clientManagement.GetType("Microsoft.Virtualization.Client.Management.Server", true);
                ConnectionHelper = client.GetType("Microsoft.Virtualization.Client.ConnectionHelper", true);
                InformationDisplayer = client.GetType("Microsoft.Virtualization.Client.InformationDisplayer", true);
                VMSettingsDialog = clientSettings.GetType("Microsoft.Virtualization.Client.Settings.VMSettingsDialog", true);
                NetworkManagerDialog = clientSettings.GetType("Microsoft.Virtualization.Client.Settings.NetworkManagerDialog", true);
                VirtualizationSettingsDialog = clientSettings.GetType("Microsoft.Virtualization.Client.Settings.VirtualizationSettingsDialog", true);
                VMWizardForm = clientWizards.GetType("Microsoft.Virtualization.Client.Wizards.VMWizardForm", true);
                NewVirtualMachineWizard = clientWizards.GetType("Microsoft.Virtualization.Client.Wizards.NewVM.NewVirtualMachineWizard", true);
                EditVirtualHardDiskWizard = clientWizards.GetType("Microsoft.Virtualization.Client.Wizards.EditVhd.EditVirtualHardDiskWizard", true);

                Displayer = Activator.CreateInstance(InformationDisplayer);
                Type[] types = new Type[] { InformationDisplayer, typeof(string), typeof(bool), IUserPassCredential };
                ServerConnection = Utility.InvokeStaticMethod(ConnectionHelper, "ConnectServer", types, new object[] { Displayer, System.Environment.MachineName, false, null });
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }
        private static object GetVMComputerSystem(Guid vmGuid)
        {
            try
            {
                Type[] types = new Type[] { typeof(string), WindowsCredential, typeof(Guid), typeof(string), IVMComputerSystem.MakeByRefType(), typeof(Exception).MakeByRefType() };
                object[] parameters = new object[] { System.Environment.MachineName, null, vmGuid, "Unable to locate virtual machine", null, null };
                object ret = Utility.InvokeStaticMethod(ConnectionHelper, "TryGetVirtualMachine", types, parameters);
                if ((bool)ret)
                {
                    return parameters[4];
                }
            }
            catch(Exception)
            {
            }
            return null;
        }

        private static int OpenVmSettings(Guid vmGuid)
        {
            object vm = GetVMComputerSystem(vmGuid);
            if (vm == null)
            {
                return 1;
            }

            Utility.InvokeMethod(vm, "UpdateAssociationCache", new object[] { });

            object server = Utility.GetProperty(vm, "Server");
            object vmSetting = Utility.GetProperty(vm, "Setting");
            string instanceId = (string)Utility.GetProperty(vmSetting, "InstanceId");
            object state = Utility.GetProperty(vm, "State");
            var operationStatus = Utility.InvokeMethod(vm, "GetOperationalStatus", new object[] { });

            object[] parameters = new object[] { server, instanceId, false, true, state, operationStatus, false  };
            Form settingsDialog = (Form)Activator.CreateInstance(VMSettingsDialog, parameters);
            settingsDialog.ShowDialog();
            return 0;
        }
        public static int OpenHyperVSettingsDialog()
        {
            Form dialog = (Form)Activator.CreateInstance(VirtualizationSettingsDialog, new object[] { ServerConnection });
            dialog.ShowDialog();
            return 0;
        }
        public static int OpenSwitchManagerDialog()
        {
            Form dialog = (Form)Activator.CreateInstance(NetworkManagerDialog, new object[] { ServerConnection });
            dialog.ShowDialog();
            return 0;
        }

        public static int OpenEditDiskWizard()
        {
            object wizard = Activator.CreateInstance(EditVirtualHardDiskWizard, new object[] { ServerConnection });
            ((Form)wizard).Activate();
            ((Form)wizard).WindowState = FormWindowState.Normal;
            ((Form)wizard).ShowInTaskbar = true;
            Utility.InvokeMethod(wizard, "Start", new Type[] { typeof(IWin32Window) }, new object[] { null });
            return 0;
        }

        private static int OpenNewVmWizard()
        {
            object wizard = Activator.CreateInstance(NewVirtualMachineWizard, new object[] { ServerConnection });
            ((Form)wizard).Activate();
            ((Form)wizard).WindowState = FormWindowState.Normal;
            ((Form)wizard).ShowInTaskbar = true;
            Utility.InvokeMethod(wizard, "Start", new Type[] { typeof(IWin32Window) }, new object[] { null });
            return 0;
        }

        private static int DeleteFromServer(Guid vmGuid)
        {
            object vm = GetVMComputerSystem(vmGuid);
            if (vm == null)
            {
                return 1;
            }

            Utility.InvokeMethod(vm, "BeginDelete", new object[] { });
            return 0;
        }

        [STAThread]
        static void Main(string[] args)
        {
            if (Initialize() == false)
            {
                Environment.Exit(1);
            }

            int exitCode = 1;
            if (args.Length == 1)
            {
                switch (args[0])
                {
                    case "hv": exitCode = OpenHyperVSettingsDialog(); break;
                    case "vs": exitCode = OpenSwitchManagerDialog(); break;
                    case "ed": exitCode = OpenEditDiskWizard(); break;
                    case "av": exitCode = OpenNewVmWizard(); break;
                }
            }
            else if (args.Length == 2)
            {
                try
                {
                    switch (args[0])
                    {
                        case "vm": exitCode = OpenVmSettings(new Guid(args[1])); break;
                        case "dv": exitCode = DeleteFromServer(new Guid(args[1])); break;
                    }
                }
                catch (Exception)
                {
                }
            }
            Environment.Exit(exitCode);
        }
    }
}
