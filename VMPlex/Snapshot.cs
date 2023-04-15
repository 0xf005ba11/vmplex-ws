using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Management;

using HyperV;

namespace VMPlex
{
    public class Snapshot
    {
        public Snapshot(IMsvm_VirtualSystemSettingData settingData, bool isNow)
        {
            SettingData = settingData;
            Children = new List<Snapshot>();
            IsNow = isNow;
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
                    if (mostCurrent != null && child.SettingData.ConfigurationID == mostCurrent.ConfigurationID)
                    {
                        child.Children.Add(new Snapshot(mostCurrent, true));
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
            configs.Add(snapshot.ConfigurationID);
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
