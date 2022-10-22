/*
 * Copyright (c) 2022 Ira Strawser. All rights reserved.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Drawing;

namespace VMPlex.UI
{
    /// <summary>
    /// Interaction logic for AboutWindow.xaml
    /// </summary>
    public partial class AboutWindow : Window
    {
        public AboutWindow()
        {
            InitializeComponent();

            System.Windows.Resources.StreamResourceInfo info = Application.GetResourceStream(new Uri("/Resources/VMPlex.ico", UriKind.Relative));
            Icon icon = new Icon(info.Stream, 128, 128);
            AboutIcon.Source = System.Windows.Interop.Imaging.CreateBitmapSourceFromHIcon(icon.Handle, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());

            this.VersionText.Text = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }
    }
}
