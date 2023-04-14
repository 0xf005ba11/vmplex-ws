using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Management;

using HyperV;

namespace VMPlex
{
    public class Snapshot
    {
        public Snapshot(IMsvm_VirtualSystemSettingData settingData)
        {
            SettingData = settingData;
            Children = new List<Snapshot>();
        }

        public IMsvm_VirtualSystemSettingData SettingData { get; }
        public List<Snapshot> Children { get; }
    }

    public class SnapshotHierarchy
    {
        private static void BuildChildren(Snapshot parent, IMsvm_VirtualSystemSettingData[] snapshots)
        {
            foreach(IMsvm_VirtualSystemSettingData snapshot in snapshots)
            {
                if (snapshot.Parent != null &&
                    snapshot.Parent.Contains(parent.SettingData.InstanceID, System.StringComparison.CurrentCultureIgnoreCase))
                {
                    Snapshot child = new Snapshot(snapshot);
                    parent.Children.Add(child);
                    BuildChildren(child, snapshots);
                }
            }
        }

        public static List<Snapshot> BuildFrom(IMsvm_VirtualSystemSettingData[] snapshots)
        {
            List<Snapshot> list = new List<Snapshot>();

            foreach (IMsvm_VirtualSystemSettingData snapshot in snapshots)
            {
                if (snapshot.Parent == null)
                {
                    Snapshot parent = new Snapshot(snapshot);
                    list.Add(parent);
                    BuildChildren(parent, snapshots);
                }
            }

            return list;
        }
    }
}
