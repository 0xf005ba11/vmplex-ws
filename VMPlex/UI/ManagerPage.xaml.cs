using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using VMPlex.WMI;

namespace VMPlex.UI
{
    public partial class ManagerPage : UserControl
    {
        public ManagerPage()
        {
            InitializeComponent();
            vmList.DataContext = VMManager.Instance.VirtualMachines;
            vmGrid.DataContext = VMManager.Instance.VirtualMachines;
            VMManager.Instance.OnVmDeleted += VmDeleted;
            SetValue(TextOptions.TextFormattingModeProperty, TextFormattingMode.Display);
            SetValue(FontFamilyProperty, SystemFonts.MessageFontFamily);
            SetValue(FontSizeProperty, SystemFonts.MessageFontSize);
        }

        private void OpenVmTab(VirtualMachine vm, TabControl tc)
        {
            int tabIndex = GetVmTabIndex(tc, vm);
            if (tabIndex >= 0)
            {
                tc.SelectedIndex = tabIndex;
                return;
            }

            TabItem tab = new TabItem();
            CloseableHeader hdr = new CloseableHeader();
            hdr.DataContext = vm;
            hdr.Icon.Content = "\xE7F4";
            hdr.Title.SetBinding(Label.ContentProperty, new Binding("Name"));
            hdr.closeButton.Visibility = Visibility.Visible;
            hdr.closeButton.Click += new RoutedEventHandler(Tab_OnCloseClicked);
            tab.Header = hdr;
            tab.Content = new VmRdpPage(vm, false);
            tab.DataContext = vm;

            int index = tc.Items.Add(tab);
            hdr.closeButton.Tag = tab;
            Dispatcher.BeginInvoke((Action)(() => tc.SelectedIndex = index));
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
            button.Tag = null;

            TabControl tc = (TabControl)(((TabItem)this.Parent).Parent);
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

        private void OnPowerCommand(object sender, RoutedEventArgs e)
        {
            VirtualMachine vm = GetSelectedVm();
            if (vm is null)
            {
                return;
            }
            if (vm.State == Msvm_ComputerSystem.SystemState.Off || 
                vm.State == Msvm_ComputerSystem.SystemState.Saved || 
                vm.State == Msvm_ComputerSystem.SystemState.Paused)
            {
                vm.RequestStateChange(VirtualMachine.StateChange.Enabled);
            }
            else
            {
                vm.RequestStateChange(VirtualMachine.StateChange.Disabled);
            }
        }

        private void OnPauseCommand(object sender, RoutedEventArgs e)
        {
            VirtualMachine vm = GetSelectedVm();
            if (vm is null)
            {
                return;
            }
            if (vm.State != Msvm_ComputerSystem.SystemState.Off)
            {
                if (vm.State == Msvm_ComputerSystem.SystemState.Paused)
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
            if (vm.State != Msvm_ComputerSystem.SystemState.Off)
            {
                vm.RequestStateChange(VirtualMachine.StateChange.Reset);
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
            if (vm.State != Msvm_ComputerSystem.SystemState.Off)
            {
                vm.RequestStateChange(VirtualMachine.StateChange.Shutdown);
            }
        }

        private void OnRebootCommand(object sender, RoutedEventArgs e)
        {
            VirtualMachine vm = GetSelectedVm();
            if (vm is null)
            {
                return;
            }
            if (vm.State != Msvm_ComputerSystem.SystemState.Off)
            {
                vm.RequestStateChange(VirtualMachine.StateChange.Reboot);
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
            if (vm.State != WMI.Msvm_ComputerSystem.SystemState.Off)
            {
                Utility.ErrorPopup("Virtual Machine must be off.");
                return;
            }
            MessageBoxResult? res = ModernWpf.MessageBox.Show("Are you sure you want to delete " + vm.Name + "?", "Delete VM", MessageBoxButton.YesNo);
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
    }
}
