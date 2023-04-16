using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Management;
using InplaceEditBoxLib.Interfaces;
using InplaceEditBoxLib.Events;
using UserNotification.Events;

using HyperV;
using System.Windows.Input;
using System.ComponentModel;

namespace VMPlex
{
    public class Snapshot : IEditBox, ICommand, INotifyPropertyChanged
    {
        public Snapshot(IMsvm_VirtualSystemSettingData settingData, bool isNow = false)
        {
            SettingData = settingData;
            Children = new List<Snapshot>();
            IsNow = isNow;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyChange(params string[] names)
        {
            if (PropertyChanged != null)
            {
                if (names == null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(null));
                    return;
                }

                foreach (string name in names)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(name));
                }
            }
        }

        // View model support for renaming via UI
        public event RequestEditEventHandler RequestEdit;
        public event ShowNotificationEventHandler ShowNotificationMessage;
        public event EventHandler CanExecuteChanged;

        public void RequestEditMode(RequestEditEvent request)
        {
            if (!IsNow)
            {
                RequestEdit?.Invoke(this, new RequestEdit(request));
            }
        }

        public void ShowNotification()
        {
            ShowNotificationMessage?.Invoke(this, new ShowNotificationEvent("", "", null));
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            if (parameter != null)
            {
                System.Tuple<string, object> args = parameter as System.Tuple<string, object>;
                if (args != null)
                {
                    Rename(args.Item1);
                }
            }
        }

        public ICommand RenameCommand { get => this; }

        public void Rename(string newName)
        {
            if (SettingData != null)
            {
                IMsvm_VirtualSystemSettingData settings = VMManager.GetVMSettingData(SettingData.InstanceID);
                if (settings == null)
                {
                    return;
                }

                settings.ElementName = newName;
                SettingData.ElementName = newName;
                VMManager.ModifySystemSettings(settings);
                NotifyChange(null);
            }
        }

        public bool IsNow { get; set; }
        public bool IsNotNow { get => !IsNow; }
        public string ConfigurationID { get => IsNow ? "now" + SettingData.ConfigurationID : SettingData.ConfigurationID; }
        public string ElementName { get => IsNow ? "Now" : SettingData.ElementName; }
        public string TextIcon { get => IsNow ? "\xF5B0" : "\xEC77"; }

        public IMsvm_VirtualSystemSettingData SettingData { get; }
        public List<Snapshot> Children { get; }
    }

    public class SnapshotHierarchy
    {
        private static void BuildChildren(
            IMsvm_VirtualSystemSettingData mostCurrent,
            Snapshot parent,
            List<Snapshot> children,
            IMsvm_VirtualSystemSettingData[] snapshots)
        {
            foreach(IMsvm_VirtualSystemSettingData snapshot in snapshots)
            {
                bool add = parent == null
                    ?  snapshot.Parent == null
                    :  snapshot.Parent != null && 
                          snapshot.Parent.Contains(parent.SettingData.InstanceID, System.StringComparison.CurrentCultureIgnoreCase);
                if (add)
                {
                    Snapshot child = new Snapshot(snapshot, false);
                    children.Add(child);
                    BuildChildren(mostCurrent, child, child.Children, snapshots);
                    child.Children.Sort((a, b) => 
                        DateTime.Compare(a.SettingData.CreationTime.GetValueOrDefault(),
                                         b.SettingData.CreationTime.GetValueOrDefault()));
                    if (mostCurrent != null && child.SettingData.ConfigurationID == mostCurrent.ConfigurationID)
                    {
                        child.Children.Insert(0, new Snapshot(mostCurrent, true));
                    }
                }
            }
        }

        public static List<Snapshot> BuildFrom(IMsvm_VirtualSystemSettingData mostCurrent, IMsvm_VirtualSystemSettingData[] snapshots)
        {
            List<Snapshot> list = new List<Snapshot>();
            BuildChildren(mostCurrent, null, list, snapshots);
            return list;
        }

        private static void GetConfigIDs(ref HashSet<string> configs, Snapshot snapshot)
        {
            configs.Add(snapshot.ConfigurationID + snapshot.ElementName);
            foreach (Snapshot s in snapshot.Children)
            {
                GetConfigIDs(ref configs, s);
            }
        }

        public static bool IsSame(List<Snapshot> a, List<Snapshot> b)
        {
            HashSet<string> configsA = new HashSet<string>();
            HashSet<string> configsB = new HashSet<string>();

            foreach (Snapshot s in a)
            {
                GetConfigIDs(ref configsA, s);
            }

            foreach (Snapshot s in b)
            {
                GetConfigIDs(ref configsB, s);
            }

            return configsA.SetEquals(configsB);
        }
    }
}
