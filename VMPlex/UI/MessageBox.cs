/*
 * Copyright (c) 2022 Johnny Shaw. All rights reserved.
 */

using System.Windows;
using ModernWpf.Controls;
using System.Windows.Media;
using System.Windows.Forms.Design;
using System.Linq;

namespace VMPlex.UI
{

    public static class MessageBox
    {
        public static MessageBoxResult Show(string Text)
        {
            return ShowInternal(null, null, Text, null);
        }

        public static MessageBoxResult Show(string Caption, string Text)
        {
            return ShowInternal(null, Caption, Text, null);
        }

        public static MessageBoxResult Show(
            string Text, 
            MessageBoxButton Button
            )
        {
            return ShowInternal(null, null, Text, Button);
        }

        public static MessageBoxResult Show(
            MessageBoxImage Image, 
            string Caption
            )
        {
            return ShowInternal(Image, Caption, null, null);
        }

        public static MessageBoxResult Show(
            MessageBoxImage Image, 
            string Caption,
            string Text
            )
        {
            return ShowInternal(Image, Caption, Text, null);
        }

        public static MessageBoxResult Show(
            MessageBoxImage Image, 
            string Caption, 
            MessageBoxButton Button
            )
        {
            return ShowInternal(Image, Caption, null, Button);
        }

        public static MessageBoxResult Show(
            MessageBoxImage Image, 
            string Caption, 
            string Text, 
            MessageBoxButton Button
            )
        {
            return ShowInternal(Image, Caption, Text, Button);
        }

#nullable enable
        private static MessageBoxResult ShowInternal(
            MessageBoxImage? Image,
            string? Caption,
            string? Text,
            MessageBoxButton? Button
            )
#nullable restore 
        {
            string symbolFont = null;
            string symbolGlyph = null;

            if (Image != null)
            {
                switch (Image)
                {
                    case MessageBoxImage.Error:
                    {
                        symbolFont = "Segoe MDL2 Assets";
                        symbolGlyph = "\uEA39";
                        break;
                    }
                    case MessageBoxImage.Question:
                    {
                        symbolFont = "Segoe MDL2 Assets";
                        symbolGlyph = "\uF142";
                        break;
                    }
                    case MessageBoxImage.Warning:
                    {
                        symbolFont = "Segoe MDL2 Assets";
                        symbolGlyph = "\uE7BA";
                        break;
                    }
                    case MessageBoxImage.Information:
                    {
                        symbolFont = "Segoe MDL2 Assets";
                        symbolGlyph = "\uE946";
                        break;
                    }
                }
            }

            return Application.Current.Dispatcher.Invoke(() =>
            {
                var window = new MessageBoxWindow(
                    symbolFont,
                    symbolGlyph,
                    Caption,
                    Text,
                    Button ?? MessageBoxButton.OK);

                window.ShowInTaskbar = true;
                window.WindowStartupLocation = WindowStartupLocation.CenterScreen;

                foreach (Window owner in Application.Current.Windows)
                {
                    if (owner.IsActive && owner.IsMouseOver)
                    {
                        window.Owner = owner;
                        window.ShowInTaskbar = false;
                        window.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                        break;
                    }
                }

                window.ShowDialog();

                return window.Result;
            });
        }
    }
}
