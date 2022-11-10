/*
 * Copyright (c) 2022 Johnny Shaw. All rights reserved.
 */

using ModernWpf.Controls;
using System;
using System.Windows;
using System.Windows.Media;

namespace VMPlex.UI
{
    /// <summary>
    /// Interaction logic for MessageBoxWindow.xaml
    /// </summary>
    public partial class MessageBoxWindow : Window
    {
        public MessageBoxResult Result = MessageBoxResult.None;

#nullable enable
        public MessageBoxWindow(
            string? SymbolFont, 
            string? SymbolGlyph, 
            string? Caption,
            string? Text,
            MessageBoxButton Button)
#nullable restore
        {
            InitializeComponent();

            if (Text != null)
            {
                MessageBoxText.Visibility = Visibility.Visible;
                MessageBoxText.Text = Text;
            }

            if (Caption != null)
            {
                MessageBoxCaption.Visibility = Visibility.Visible;
                MessageBoxCaption.Text = Caption;
            }

            switch (Button)
            {
                case MessageBoxButton.OK:
                {
                    ButtonOk.Visibility = Visibility.Visible;
                    ButtonOk.Focus();
                    break;
                }
                case MessageBoxButton.OKCancel:
                {
                    ButtonOk.Visibility = Visibility.Visible;
                    ButtonCancel.Visibility = Visibility.Visible;
                    ButtonCancel.Focus();
                    break;
                }
                case MessageBoxButton.YesNo:
                {
                    ButtonYes.Visibility = Visibility.Visible;
                    ButtonNo.Visibility = Visibility.Visible;
                    ButtonNo.Focus();
                    break;
                }
                case MessageBoxButton.YesNoCancel:
                {
                    ButtonYes.Visibility = Visibility.Visible;
                    ButtonNo.Visibility = Visibility.Visible;
                    ButtonCancel.Visibility = Visibility.Visible;
                    ButtonCancel.Focus();
                    break;
                }
            }

            if ((SymbolFont != null) && (SymbolGlyph != null))
            {
                SymbolIcon.Visibility = Visibility.Visible;
                SymbolIcon.FontFamily = new FontFamily(SymbolFont);
                SymbolIcon.Glyph = SymbolGlyph;
            }
        }

        private void ButtonOk_Click(object sender, RoutedEventArgs e)
        {
            Result = MessageBoxResult.OK;
            Close();
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            Result = MessageBoxResult.Cancel;
            Close();
        }

        private void ButtonYes_Click(object sender, RoutedEventArgs e)
        {
            Result = MessageBoxResult.Yes;
            Close();
        }

        private void ButtonNo_Click(object sender, RoutedEventArgs e)
        {
            Result = MessageBoxResult.No;
            Close();
        }

        protected override void OnSourceInitialized(EventArgs e)
        {
            base.OnSourceInitialized(e);
            InvalidateMeasure();
        }
    }
}
