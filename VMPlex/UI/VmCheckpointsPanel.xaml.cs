/*
 * Copyright (c) 2022 Ira Strawser. All rights reserved.
 */

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
using System.Threading;
using System.Windows.Forms.Design;
using InplaceEditBoxLib;
using System.Windows.Forms;
using InplaceEditBoxLib.Events;

namespace VMPlex.UI
{
    /// <summary>
    /// Interaction logic for VmCheckpointsPanel.xaml
    /// </summary>
    public partial class VmCheckpointsPanel : System.Windows.Controls.UserControl
    {
        public VmCheckpointsPanel()
        {
            InitializeComponent();
        }

        private Snapshot GetSnapshot(object sender)
        {
            MenuItem item = sender as MenuItem;
            if (item == null)
            {
                return null;
            }

            return item.DataContext as Snapshot;
        }

        private void OnApply(object sender, RoutedEventArgs e)
        {
            Snapshot snapshot = GetSnapshot(sender);
            if (snapshot == null ||
                !Utility.ConfirmSnapshotAction(snapshot, "Apply checkpoint"))
            {
                return;
            }

            new Thread(ApplySnapshot).Start(snapshot);
        }

        private void OnRename(object sender, RoutedEventArgs e)
        {
            Snapshot snapshot = GetSnapshot(sender);
            if (snapshot == null)
            {
                return;
            }
            snapshot.RequestEditMode(RequestEditEvent.StartEditMode);
        }

        private void OnDelete(object sender, RoutedEventArgs e)
        {
            Snapshot snapshot = GetSnapshot(sender);
            if (snapshot == null ||
                !Utility.ConfirmSnapshotAction(snapshot, "Delete checkpoint"))
            {
                return;
            }

            new Thread(DeleteSnapshot).Start(snapshot);
        }

        private void OnDeleteTree(object sender, RoutedEventArgs e)
        {
            Snapshot snapshot = GetSnapshot(sender);
            if (snapshot == null ||
                !Utility.ConfirmSnapshotAction(snapshot, "Delete checkpoint tree"))
            {
                return;
            }

            new Thread(DeleteSnapshotTree).Start(snapshot);
        }

        private void ApplySnapshot(object data)
        {
            Snapshot snapshot = (Snapshot)data;
            VMManager.ApplySnapshot(snapshot);
        }

        private void DeleteSnapshot(object data)
        {
            Snapshot snapshot = (Snapshot)data;
            VMManager.DeleteSnapshot(snapshot);
        }

        private void DeleteSnapshotTree(object data)
        {
            Snapshot snapshot = (Snapshot)data;
            VMManager.DeleteSnapshotTree(snapshot);
        }
    }
}
