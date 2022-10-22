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

namespace VMPlex.UI
{
    /// <summary>
    /// Interaction logic for VmInfoPanel.xaml
    /// </summary>
    public partial class VmInfoPanel : UserControl
    {
        public VmInfoPanel()
        {
            InitializeComponent();
            guidCopyButton.Click += new RoutedEventHandler(GuidCopyButton_Clicked);
        }

        void OnGuidChanged(object sender, DataTransferEventArgs e)
        {
            guidCopyButton.Visibility = guid.Text.Length != 0 ? Visibility.Visible : Visibility.Hidden;
        }

        void GuidCopyButton_Clicked(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(guid.Text);
        }
    }
}
