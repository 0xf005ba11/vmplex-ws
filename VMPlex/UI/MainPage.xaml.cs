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


// Icon codes:
// &#xE80F; = Home icon
// &#xE7F4; = Single monitor
// &#xE977; = Monitor with computer
// &#xE72E; = Lock
// &#xE711; = Closing X
//
// More at: http://modernicons.io/segoe-mdl2/cheatsheet/

namespace VMPlex.UI
{

    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        private TabItem draggedTab = null;

        public MainPage()
        {

            InitializeComponent();
            SetValue(TextOptions.TextFormattingModeProperty, TextFormattingMode.Display);
            SetValue(FontFamilyProperty, SystemFonts.MessageFontFamily);
            SetValue(FontSizeProperty, SystemFonts.MessageFontSize);

            CloseableHeader manager = new CloseableHeader();
            manager.Icon.Content = "\xE912";
            manager.Title.Content = "Manager";
            Tab(0).Header = manager;

        }

        public TabItem Tab(int index)
        {
            return (TabItem)vmTabs.Items[index];
        }

        private void OnAbout(object sender, RoutedEventArgs e)
        {
            Window about = new AboutWindow();
            about.Owner = Application.Current.MainWindow;
            about.ShowDialog();
        }

        private void OnUserSettings(object sender, RoutedEventArgs e)
        {
            UserSettings.Instance.OpenInEditor();
        }

        private void TabItem_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            if (!(e.Source is TabItem tabItem))
            {
                return;
            }

            if (Mouse.PrimaryDevice.LeftButton == MouseButtonState.Pressed)
            {
                draggedTab = tabItem;
                DragDrop.DoDragDrop(tabItem, tabItem, DragDropEffects.All);
            }
        }

        private void TabItem_PreviewDragEnter(object sender, DragEventArgs e)
        {
            if (e.Source is TabItem tabItemTarget &&
                e.Data.GetData(typeof(TabItem)) is TabItem tabItemSource &&
                !tabItemTarget.Equals(tabItemSource) &&
                tabItemTarget.Parent is TabControl tabControl &&
                tabItemTarget.Parent.Equals(tabItemSource.Parent))
            {
                int targetIndex = tabControl.Items.IndexOf(tabItemTarget);
                tabControl.Items.Remove(tabItemSource);
                tabControl.Items.Insert(targetIndex, tabItemSource);
                tabItemSource.IsSelected = true;
            }
        }

        private void TabItem_Drop(object sender, DragEventArgs e)
        {
            //
            // Update the indexes after drag and drop.
            //
            if (draggedTab != null && draggedTab.Parent is TabControl tabControl)
            {
                for (int i = 0; i < tabControl.Items.Count; i++)
                {
                    if (tabControl.Items[i] is TabItem tab &&
                        tab.DataContext is VirtualMachine vm)
                    {
                        vm.MutateVmUserSettings(s =>
                        {
                            s.TabIndex = i;
                            return s;
                        });
                    }
                }
            }

            draggedTab = null;
        }
    }
}
