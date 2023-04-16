/*
 * Copyright (c) 2022 Ira Strawser. All rights reserved.
 */

using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Collections.Generic;

using HyperV;
using System.Linq;
using System.Threading;

namespace VMPlex.UI
{
    public partial class ManagerPage : UserControl
    {
        private bool m_InitialLoad = false;

        public ManagerPage()
        {
            InitializeComponent();
            vmList.DataContext = VMManager.Instance.VirtualMachines;
            vmGrid.DataContext = VMManager.Instance.VirtualMachines;
            VMManager.Instance.OnVmDeleted += VmDeleted;
            SetValue(TextOptions.TextFormattingModeProperty, TextFormattingMode.Display);
            SetValue(FontFamilyProperty, SystemFonts.MessageFontFamily);
            SetValue(FontSizeProperty, SystemFonts.MessageFontSize);
            Loaded += ManagerPage_Loaded;
        }

        private void ManagerPage_Loaded(object sender, RoutedEventArgs e)
        {
            if (m_InitialLoad)
            {
                return;
            }

            m_InitialLoad = true;

            //
            // Restore any previously opened virtual machine tabs.
            //
            if (UserSettings.Instance.Settings.RememberTabs)
            {
                var tabs = new List<TabItem>();
                foreach (var vm in VMManager.Instance.VirtualMachines)
                {
                    int index = vm.GetVmUserSettings().TabIndex;

                    if (index < 0)
                    {
                        continue;
                    }

                    while (tabs.Count <= index)
                    {
                        tabs.Add(null);
                    }

                    tabs[index] = CreateVmTab(vm);
                }

                TabControl tc = (TabControl)(((TabItem)this.Parent).Parent);

                foreach (TabItem tab in tabs)
                {
                    if (tab != null)
                    {
                        tc.Items.Add(tab);
                    }
                }
            }
        }

        private void OpenVmTab(VirtualMachine vm, TabControl tc)
        {
            int tabIndex = GetVmTabIndex(tc, vm);
            if (tabIndex >= 0)
            {
                tc.SelectedIndex = tabIndex;
                return;
            }

            int index = tc.Items.Add(CreateVmTab(vm));

            vm.MutateVmUserSettings(s =>
            {
                s.TabIndex = index;
                return s;
            });

            Dispatcher.BeginInvoke((Action)(() => tc.SelectedIndex = index));
        }

        private TabItem CreateVmTab(VirtualMachine vm)
        {
            TabItem tab = new TabItem();
            CloseableHeader hdr = new CloseableHeader();
            hdr.DataContext = vm;
            hdr.Icon.Content = "\xE7F4";
            hdr.Title.SetBinding(Label.ContentProperty, new Binding("Name"));
            hdr.closeButton.Visibility = Visibility.Visible;
            hdr.closeButton.Click += new RoutedEventHandler(Tab_OnCloseClicked);
            hdr.closeButton.Tag = tab;
            tab.Header = hdr;
            tab.Content = new VmRdpPage(vm);
            tab.DataContext = vm;

            return tab;
        }

        private TabItem CreateRdpTab(RdpSettings settings)
        {
            TabItem tab = new TabItem();
            CloseableHeader hdr = new CloseableHeader();
            hdr.Icon.Content = "\xE8AF";
            hdr.Title.SetValue(Label.ContentProperty, settings.Server);
            hdr.closeButton.Visibility = Visibility.Visible;
            hdr.closeButton.Click += new RoutedEventHandler(Tab_OnCloseClicked);
            hdr.closeButton.Tag = tab;
            tab.Header = hdr;
            tab.Content = new RdpPage(settings);

            return tab;
        }

        private void VmListItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            VirtualMachine vm = (VirtualMachine)((e.Source as ListViewItem).DataContext);
            //if (vm.State == WMI.Msvm_ComputerSystem.SystemState.Off)
            //{
            //    return;
            //}

            TabControl tc = (TabControl)(((TabItem)this.Parent).Parent);

            OpenVmTab(vm, tc);
        }

        private void VmTemplate_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            VirtualMachine vm = (VirtualMachine)((e.Source as FrameworkElement).DataContext);
            TabControl tc = (TabControl)(((TabItem)this.Parent).Parent);
            OpenVmTab(vm, tc);
        }

        private void VmContextMenu_Connect(object sender, EventArgs e)
        {
            var vm = GetSelectedVm();
            TabControl tc = (TabControl)(((TabItem)this.Parent).Parent);
            OpenVmTab(vm, tc);
        }

        private void VmDeleted(object sender, VirtualMachine vm)
        {
            Dispatcher.Invoke(() =>
            {
                TabControl tc = (TabControl)(((TabItem)this.Parent).Parent);
                int index = GetVmTabIndex(tc, vm);
                if (index >= 0)
                {
                    tc.Items.Remove((TabItem)tc.Items[index]);
                }
            });
        }

        private void Tab_OnCloseClicked(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            TabItem tab = (TabItem)button.Tag;
            TabControl tc = (TabControl)(((TabItem)this.Parent).Parent);

            if (tab.Content is RdpPage)
            {
                RdpPage rdp = (RdpPage)tab.Content;
                rdp.Shutdown();
                tc.Items.Remove(tab);
                return;
            }

            VirtualMachine vm = (VirtualMachine)tab.DataContext;
            button.Tag = null;

            vm.MutateVmUserSettings(s =>
            {
                s.TabIndex = -1;
                return s;
            });

            if (tab.Content != null && tab.Content is VmRdpPage)
            {
                VmRdpPage rdp = (VmRdpPage)tab.Content;
                rdp.Shutdown();
                tc.Items.Remove(tab);
            }
        }

        private int GetVmTabIndex(TabControl tc, VirtualMachine vm)
        {
            for (int i = 0; i < tc.Items.Count; ++i)
            {
                TabItem tab = (TabItem)tc.Items[i];
                if (tab.Content is VmRdpPage)
                {
                    VmRdpPage rdp = (VmRdpPage)tab.Content;
                    if (rdp.VmGuid == vm.Guid)
                    {
                        return i;
                    }
                }
            }
            return -1;
        }

        private VirtualMachine GetSelectedVm()
        {
            return (VirtualMachine)vmList.SelectedItem;
        }

        private bool ConfirmToolBarAction(object Sender, VirtualMachine VM,  string Action)
        {
            if (Sender.GetType() != typeof(ModernWpf.Controls.AppBarButton))
            {
                return true;
            }

            if (!UserSettings.Instance.Settings.ConfirmToolBarActions)
            {
                return true;
            }

            var res = UI.MessageBox.Show(
                MessageBoxImage.Warning,
                $"{Action} {VM.Name}?",
                MessageBoxButton.YesNo);

            return res == MessageBoxResult.Yes;
        }

        private void OnPowerCommand(object sender, RoutedEventArgs e)
        {
            VirtualMachine vm = GetSelectedVm();
            if (vm is null)
            {
                return;
            }
            if (vm.State == IMsvm_ComputerSystem.SystemState.Off || 
                vm.State == IMsvm_ComputerSystem.SystemState.Saved || 
                vm.State == IMsvm_ComputerSystem.SystemState.Paused)
            {
                vm.RequestStateChange(VirtualMachine.StateChange.Enabled);
            }
            else
            {
                if (ConfirmToolBarAction(sender, vm, "Turn off"))
                {
                    vm.RequestStateChange(VirtualMachine.StateChange.Disabled);
                }
            }
        }

        private void OnPauseCommand(object sender, RoutedEventArgs e)
        {
            VirtualMachine vm = GetSelectedVm();
            if (vm is null)
            {
                return;
            }
            if (vm.State != IMsvm_ComputerSystem.SystemState.Off)
            {
                if (vm.State == IMsvm_ComputerSystem.SystemState.Paused)
                {
                    vm.RequestStateChange(VirtualMachine.StateChange.Enabled);
                }
                else
                {
                    vm.RequestStateChange(VirtualMachine.StateChange.Quiesce);
                }
            }
        }

        private void OnResetCommand(object sender, RoutedEventArgs e)
        {
            VirtualMachine vm = GetSelectedVm();
            if (vm is null)
            {
                return;
            }
            if (vm.State != IMsvm_ComputerSystem.SystemState.Off)
            {
                if (ConfirmToolBarAction(sender, vm, "Reset"))
                {
                    vm.RequestStateChange(VirtualMachine.StateChange.Reset);
                }
            }
        }

        private void OnSaveCommand(object sender, RoutedEventArgs e)
        {
            VirtualMachine vm = GetSelectedVm();
            if (vm is null)
            {
                return;
            }
            vm.RequestStateChange(VirtualMachine.StateChange.Offline);
        }

        private void OnShutdownCommand(object sender, RoutedEventArgs e)
        {
            VirtualMachine vm = GetSelectedVm();
            if (vm is null)
            {
                return;
            }
            if (vm.State != IMsvm_ComputerSystem.SystemState.Off)
            {
                if (ConfirmToolBarAction(sender, vm, "Shut down"))
                {
                    vm.RequestStateChange(VirtualMachine.StateChange.Shutdown);
                }
            }
        }

        private void OnRebootCommand(object sender, RoutedEventArgs e)
        {
            VirtualMachine vm = GetSelectedVm();
            if (vm is null)
            {
                return;
            }
            if (vm.State != IMsvm_ComputerSystem.SystemState.Off)
            {
                if (ConfirmToolBarAction(sender, vm, "Reboot"))
                {
                    vm.RequestStateChange(VirtualMachine.StateChange.Reboot);
                }
            }
        }

        private void OnDebugCommand(object sender, RoutedEventArgs e)
        {
            VirtualMachine vm = GetSelectedVm();
            if (vm is null)
            {
                return;
            }
            vm.OpenDebugger();
        }

        private void OnSettingsCommand(object sender, RoutedEventArgs e)
        {
            VirtualMachine vm = GetSelectedVm();
            if (vm is null)
            {
                return;
            }
            vm.OpenSettingsDialog();
        }
        private void OnVirtualSwitchManagerCommand(object sender, RoutedEventArgs e)
        {
            VirtualMachine.OpenSwitchManagerDialog();
        }
        private void OnEditDiskCommand(object sender, RoutedEventArgs e)
        {
            VirtualMachine.OpenEditDiskWizard();
        }

        private void OnHyperVSettingsCommand(object sender, RoutedEventArgs e)
        {
            VirtualMachine.OpenHyperVSettingsDialog();
        }

        private void OnAddCommand(object sender, RoutedEventArgs e)
        {
            VirtualMachine.OpenNewVmWizard();
        }

        private void OnDeleteCommand(object sender, RoutedEventArgs e)
        {
            VirtualMachine vm = GetSelectedVm();
            if (vm is null)
            {
                return;
            }
            if (vm.State != IMsvm_ComputerSystem.SystemState.Off)
            {
                UI.MessageBox.Show(
                    MessageBoxImage.Information,
                    "Virtual Machine must be off.");
                return;
            }
            var res = UI.MessageBox.Show(
                MessageBoxImage.Question,
                $"Are you sure you want to delete {vm.Name}?", 
                "Deleting the virtual machine will remove it from the server. " +
                "This can not be undone.", 
                MessageBoxButton.YesNo);
            if (res == MessageBoxResult.Yes)
            {
                TabControl tc = (TabControl)(((TabItem)this.Parent).Parent);
                int index = GetVmTabIndex(tc, vm);
                if (index >= 0)
                {
                    tc.Items.Remove((TabItem)tc.Items[index]);
                }
                vm.DeleteFromServer();
            }
        }

        private void OnCreateCheckpoint(object sender, RoutedEventArgs e)
        {
            VirtualMachine vm = GetSelectedVm();
            if (vm is null)
            {
                return;
            }

            new Thread(CreateCheckpoint).Start(vm);
        }

        private void CreateCheckpoint(object data)
        {
            VMManager.CreateSnapshot((VirtualMachine)data, VMManager.SnapshotType.Full);
        }

        private void OnRevertCheckpoint(object sender, RoutedEventArgs e)
        {
            VirtualMachine vm = GetSelectedVm();
            if (vm is null ||
                !Utility.ConfirmSnapshotAction(null, "Revert to previous checkpoint"))
            {
                return;
            }

            new Thread(RevertCheckpoint).Start(vm);
        }

        private void RevertCheckpoint(object data)
        {
            VMManager.RevertSnapshot((VirtualMachine)data);
        }

        private void RdpConnectButton_Click(object sender, RoutedEventArgs e)
        {
            rdpDropDown.Flyout.Hide();

            var strings = rdpConnectionBox.Text.Split('\\');
            string domain = strings.Length > 1 ? strings[0] : "";
            string server = strings.Length > 1 ? strings[1] : strings[0];

            if (server.Length == 0)
            {
                MessageBox.Show(
                    MessageBoxImage.Error,
                    "Remote Desktop Connection Failed",
                    "Please provide server to connect to.",
                    MessageBoxButton.OK);
                return;
            }

            var settings = UserSettings.Instance.Settings.RdpConnections.FirstOrDefault(
                c => c.Domain == domain && c.Server == server,
                new RdpSettings { Domain = domain, Server = server });

            TabItem tab;
            try
            {
                tab = CreateRdpTab(settings);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    MessageBoxImage.Error,
                    "Remote Desktop Connection Failed",
                    ex.Message,
                    MessageBoxButton.OK);
                return;
            }

            TabControl tc = (TabControl)(((TabItem)this.Parent).Parent);
            int index = tc.Items.Add(tab);
            Dispatcher.BeginInvoke((Action)(() => tc.SelectedIndex = index));

            //
            // Store the RDP connection for later.
            //
            UserSettings.Instance.Mutate(s =>
            {
                if (s.RdpConnections.Find(
                    c => (c.Domain == settings.Domain && c.Server == settings.Server)
                    ) == null)
                {
                    s.RdpConnections.Add(settings);
                }
                return s;
            });
        }
    }

    public class VMPidConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value != null && (uint)value != 0)
            {
                return ((uint)value).ToString();
            }
            return String.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class VMMemoryConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value != null && ((VirtualMachine)value).IsRunning)
            {
                return String.Format("{0} MB", ((VirtualMachine)value).MemoryUsage);
            }
            return String.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class VMCpuUsageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value != null && ((VirtualMachine)value).IsRunning)
            {
                return String.Format("{0}%", ((VirtualMachine)value).ProcessorLoad);
            }
            return String.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class VMUptimeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value != null && ((VirtualMachine)value).IsRunning)
            {
                return ((VirtualMachine)value).UpTime.ToString();
            }
            return String.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
