using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Windows.Media;

namespace VMPlex.UI
{
    public class UXThemeAccess
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct IMMERSIVE_COLOR_PREFERENCE
        {
            readonly uint crStartColor;
            readonly uint crAccentColor;
        }

        public enum IMMERSIVE_HC_CACHE_MODE
        {
            IHCM_USE_CACHED_VALUE = 0,
            IHCM_REFRESH = 1
        }

        public enum IMMERSIVE_COLOR_TYPE
        {
            IMCLR_ApplicationText = 0,
            IMCLR_SystemAccentLight3 = 1,
            IMCLR_SystemAccentLight2 = 2,
            IMCLR_SystemAccentLight1 = 3,
            IMCLR_SystemAccent = 4,
            IMCLR_SystemAccentDark1 = 5,
            IMCLR_SystemAccentDark2 = 6,
            IMCLR_SystemAccentDark3 = 7,
            IMCLR_SystemText = 8,
            IMCLR_ApplicationBackground = 0xd2,

            IMCLR_DarkListAccentLow = 0x3e,
            IMCLR_DarkListAccentMedium = 0x3f,
            IMCLR_DarkListAccentHigh = 0x40,
            IMCLR_DarkListLow = 298,
            IMCLR_DarkListMedium = 299,

            IMCLR_LightListAccentLow = 0x41,
            IMCLR_LightListAccentMedium = 0x42,
            IMCLR_LightListAccentHigh = 0x43,
            IMCLR_LightListLow = 327,
            IMCLR_LightListMedium = 328,

            IMCLR_DarkAcrylicWindowBackdropFallback = 314,
            IMCLR_DarkActiveBorder = 315,
            IMCLR_DarkAltHigh = 297,
            IMCLR_DarkAltLow = 293,
            IMCLR_DarkAltMedium = 295,
            IMCLR_DarkAltMediumHigh = 296,
            IMCLR_DarkAltMediumLow = 294,
            IMCLR_DarkBaseHigh = 292,
            IMCLR_DarkBaseLow = 288,
            IMCLR_DarkBaseMedium = 290,
            IMCLR_DarkBaseMediumHigh = 291,
            IMCLR_DarkBaseMediumLow = 289,
            IMCLR_DarkChromeAltLow = 306,
            IMCLR_DarkChromeBlackHigh = 312,
            IMCLR_DarkChromeBlackLow = 309,
            IMCLR_DarkChromeBlackMedium = 311,
            IMCLR_DarkChromeBlackMediumLow = 310,
            IMCLR_DarkChromeDisabledHigh = 308,
            IMCLR_DarkChromeDisabledLow = 307,
            IMCLR_DarkChromeHigh = 305,
            IMCLR_DarkChromeLow = 302,
            IMCLR_DarkChromeMedium = 304,
            IMCLR_DarkChromeMediumLow = 303,
            IMCLR_DarkChromeTaskbarAcrylic = 301,
            IMCLR_DarkChromeTaskbarBase = 300,
            IMCLR_DarkChromeWhite = 313,

            IMCLR_LightAcrylicWindowBackdropFallback = 403,
            IMCLR_LightAltHigh = 326,
            IMCLR_LightAltLow = 322,
            IMCLR_LightAltMedium = 324,
            IMCLR_LightAltMediumHigh = 325,
            IMCLR_LightAltMediumLow = 323,
            IMCLR_LightBackground = 345,
            IMCLR_LightBackgroundDisabled = 346,
            IMCLR_LightBaseHigh = 321,
            IMCLR_LightBaseLow = 317,
            IMCLR_LightBaseMedium = 319,
            IMCLR_LightBaseMediumHigh = 320,
            IMCLR_LightBaseMediumLow = 318,
            IMCLR_LightBorder = 369,
            IMCLR_LightChromeAltLow = 336,
            IMCLR_LightChromeBlackHigh = 342,
            IMCLR_LightChromeBlackLow = 339,
            IMCLR_LightChromeBlackMedium = 341,
            IMCLR_LightChromeBlackMediumLow = 340,
            IMCLR_LightChromeDisabledHigh = 338,
            IMCLR_LightChromeDisabledLow = 337,
            IMCLR_LightChromeHigh = 335,
            IMCLR_LightChromeLow = 332,
            IMCLR_LightChromeMedium = 334,
            IMCLR_LightChromeMediumLow = 333,
            IMCLR_LightChromeTaskbarAcrylic = 330,
            IMCLR_LightChromeTaskbarBase = 329,
            IMCLR_LightChromeTaskbarGlomDivider = 331,
            IMCLR_LightChromeWhite = 343,

            IMCLR_LightDesktopToastBackground = 368,
            IMCLR_LightDisabledText = 349,
            IMCLR_LightDivider = 370,

            IMCLR_LightFocusRect = 344,
            IMCLR_LightHighlight = 74,
            IMCLR_LightHoverBackground = 354,
            IMCLR_LightHoverBackgroundTransparent = 355,
            IMCLR_LightHoverPrimaryText = 356,
            IMCLR_LightHoverSecondaryText = 357,
            IMCLR_LightIconBorder = 393,
            IMCLR_LightInlineErrorText = 75,

            IMCLR_ControlHighContrastHIGHLIGHTTEXT = 222
        }

        public static Color GetThemeColorValue(IMMERSIVE_COLOR_TYPE colorType)
        {
            IMMERSIVE_COLOR_PREFERENCE colorPreference = new IMMERSIVE_COLOR_PREFERENCE();

            int err = GetUserColorPreference(ref colorPreference, false);
            if (err != 0)
            {
                throw new System.Exception("UXTheme failed to get user color preference");
            }

            uint color = GetColorFromPreference(ref colorPreference, colorType, false, IMMERSIVE_HC_CACHE_MODE.IHCM_REFRESH);

            return Color.FromArgb(0xff, (byte)color, (byte)(color >> 8), (byte)(color >> 16));
        }

        [DllImport("UXTheme.dll")]
        private static extern int GetUserColorPreference(ref IMMERSIVE_COLOR_PREFERENCE colorPreference, bool alwaysFalse);

        [DllImport("UXTheme.dll")]
        private static extern uint GetColorFromPreference(ref IMMERSIVE_COLOR_PREFERENCE colorPreference, IMMERSIVE_COLOR_TYPE colorType, bool alwaysFalse, IMMERSIVE_HC_CACHE_MODE cacheMode);
    }
 }
