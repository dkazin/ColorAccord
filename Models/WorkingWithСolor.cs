using System;
using Windows.UI;
using System.Collections.Generic;

namespace Color_Accord.Model
{
    /// <summary>
    /// Предоставляет методы работы с цветом.
    /// </summary>
    class WorkingWithСolor
    {
        /// <summary>
        /// Описывает цвет в представлении HSV.
        /// </summary>
        public struct ColorHSV
        {
            private int h;
            private int s;
            private int v;
            private byte a;

            public int H
            {
                get => h;
                set
                {
                    if (ValidateHue(value))
                        h = value;
                    else
                        throw new Exception($"Недопустимое значение Hue. [ { value } ]");
                }
            }
            public int S
            {
                get => s;
                set
                {
                    if (ValidateSV(value))
                        s = value;
                    else
                        throw new Exception($"Недопустимое значение Saturation. [ { value } ]");
                }
            }
            public int V
            {
                get => v;
                set
                {
                    if (ValidateSV(value))
                        v = value;
                    else
                        throw new Exception($"Недопустимое значение Value. [ { value } ]");
                }
            }

            public byte A
            {
                get => a;
                set
                {
                    if (ValidateSV(value))
                        a = value;
                    else
                        throw new Exception($"Недопустимое значение Alpha канала. [ { value } ]");
                }
            }

            public static ColorHSV FromHsv(byte a, int h, int s, int v)
            {
                return new ColorHSV(a, h, s, v);
            }

            public ColorHSV(byte a, int h, int s, int v)
            {
                if (ValidateHue(a) && ValidateHue(h) && ValidateSV(s) && ValidateSV(v))
                {
                    this.h = h;
                    this.s = s;
                    this.v = v;
                    this.a = a;
                }
                else
                    throw new Exception("Недопустимое значение HSV. [ A=" + a + ", H=" + h + ", S=" + s + ", V=" + v + "]");
            }

            private static bool ValidateHue(int value)
            {
                return (value >= 0 && value <= 360) ? true : false;
            }

            private static bool ValidateSV(int value)
            {
                return (value >= 0 && value <= 100) ? true : false;
            }

            public override string ToString()
            {
                return "H = " + H + "; S = " + S + "; V = " + V;
            }
        }

        /// <summary>
        /// Смешивание двух цветов.
        /// </summary>
        /// <param name="colorX">Первй цвет</param>
        /// <param name="colorY">Второй цвет</param>
        public static Color MixColors(Color colorX, Color colorY)
        {
            return Color.FromArgb(Math.Max(colorX.A, colorY.A), Math.Max(colorX.R, colorY.R), Math.Max(colorX.G, colorY.G), Math.Max(colorX.B, colorY.B));
        }

        /// <summary>
        /// Преобразует цветовое представление HSV в представление RGB.
        /// </summary>
        /// <param name="colorHSV">Цвет в представлении HSV</param>
        public static Color HSVToRGB(ColorHSV color)
        {
            var s = color.S / 100d;
            var v = color.V / 100d;
            var c = v * s;
            var h = color.H / 60d;
            var X = c * (1d - Math.Abs(h % 2d - 1d));
            var r = 0d;
            var g = 0d;
            var b = 0d;
            if (h >= 0 && h < 1)
            {
                r = c;
                g = X;
            }
            else if (h >= 1 && h < 2)
            {
                r = X;
                g = c;
            }
            else if (h >= 2 && h < 3)
            {
                g = c;
                b = X;
            }
            else if (h >= 3 && h < 4)
            {
                g = X;
                b = c;
            }
            else if (h >= 4 && h < 5)
            {
                r = X;
                b = c;
            }
            else
            {
                r = c;
                b = X;
            }
            double m = v - c;

            r = (r + m) * 255d;
            g = (g + m) * 255d;
            b = (b + m) * 255d;

            return Color.FromArgb(color.A, (byte)Math.Ceiling(r), (byte)Math.Ceiling(g), (byte)Math.Ceiling(b));
        }

        /// <summary>
        /// Преобразует цветовое представление RGB в представление HSV.
        /// </summary>
        /// <param name="color">Цвет в представлении RGB</param>
        public static ColorHSV RGBToHSV(Color color)
        {
            var r = color.R / 255d;
            var g = color.G / 255d;
            var b = color.B / 255d;

            var max = Math.Max(r, Math.Max(g, b));
            var min = Math.Min(r, Math.Min(g, b));
            var c = max - min;

            double hue = 0d;

            if (max == r && g >= b)
                hue = ((g - b) / (max - min)) * 60d;

            if (max == r && g < b)
                hue = ((g - b) / (max - min)) * 60d + 360d;

            if (max == g)
                hue = ((b - r) / (max - min)) * 60d + 120d;

            if (max == b)
                hue = ((r - g) / (max - min)) * 60d + 240d;


            double saturation = (max == 0) ? 0 : (1d - (1d * min / max)) * 100d;
            double value = max * 100d;

            return ColorHSV.FromHsv(color.A, double.IsNaN(hue) ? 0 : (int)Math.Ceiling(hue), (byte)saturation, (byte)value);
        }

        /// <summary>
        /// Преобразует цветовое представление RGB в Hex.
        /// </summary>
        /// <param name="color">Цвет в представлении RGB</param>
        public static string RGBToHex(Color color)
        {
            return color.A.ToString("X2") + color.R.ToString("X2") + color.G.ToString("X2") + color.B.ToString("X2");
        }

        /// <summary>
        /// Преобразует цветовое представление Hex в RGB.
        /// </summary>
        /// <param name="value">Цвет в представлении Hex</param>
        public static Color HexToRGB(string value)
        {
            int length = value.Length - 1;
            byte a = byte.Parse(value[length - 7].ToString() + value[length - 6].ToString(), System.Globalization.NumberStyles.AllowHexSpecifier);
            byte r = byte.Parse(value[length - 5].ToString() + value[length - 4].ToString(), System.Globalization.NumberStyles.AllowHexSpecifier);
            byte g = byte.Parse(value[length - 3].ToString() + value[length - 2].ToString(), System.Globalization.NumberStyles.AllowHexSpecifier);
            byte b = byte.Parse(value[length - 1].ToString() + value[length].ToString(), System.Globalization.NumberStyles.AllowHexSpecifier);
            return Color.FromArgb(a, r, g, b);
        }

        /// <summary>
        /// Возвращает оттенок из цветового пространства RGB.
        /// </summary>
        /// <param name="color">Цвет в представлении RGB</param>
        public static int GetHue(Color color)
        {
            var r = color.R / 255d;
            var g = color.G / 255d;
            var b = color.B / 255d;

            var max = Math.Max(r, Math.Max(g, b));
            var min = Math.Min(r, Math.Min(g, b));
            var c = max - min;

            double hue = 0d;

            if (max == r && g >= b)
                hue = ((g - b) / (max - min)) * 60d;

            if (max == r && g < b)
                hue = ((g - b) / (max - min)) * 60d + 360d;

            if (max == g)
                hue = ((b - r) / (max - min)) * 60d + 120d;

            if (max == b)
                hue = ((r - g) / (max - min)) * 60d + 240d;

            return (int)Math.Ceiling(hue);
        }

        /// <summary>Комплементарная цветовая схема.</summary>
        /// <param name="color">Цвет в представлении HSV</param>
        /// <returns>List гармоничных сцветов в представлении HSV</returns>
        public static List<ColorHSV> GetComplementary(ColorHSV color)
        {
            List<ColorHSV> harmony = new List<ColorHSV> { color };

            int ComplementaryHue = color.H + 180;

            if (ComplementaryHue >= 360)
                harmony.Add(ColorHSV.FromHsv(color.A, ComplementaryHue - 360, color.S, color.V));
            else
                harmony.Add(ColorHSV.FromHsv(color.A, ComplementaryHue, color.S, color.V));

            return harmony;
        }

        /// <summary>Цветовая схема Триада.</summary>
        /// <param name="color">Цвет в представлении HSV</param>
        /// <returns>List гармоничных сцветов в представлении HSV</returns>
        public static List<ColorHSV> GetTriada(ColorHSV color)
        {
            List<ColorHSV> harmony = new List<ColorHSV>() { color };
            int hue = color.H;

            for (byte i = 0; i < 2; i++)
            {
                hue += 120;
                if (hue >= 360) hue -= 360;
                harmony.Add(ColorHSV.FromHsv(color.A, hue, color.S, color.V));
            }

            return harmony;
        }

        /// <summary>Цветовая схема Квадрат.</summary>
        /// <param name="color">Цвет в представлении HSV</param>
        /// <returns>List гармоничных сцветов в представлении HSV</returns>
        public static List<ColorHSV> GetSquare(ColorHSV color)
        {
            List<ColorHSV> harmony = new List<ColorHSV>() { color };
            int hue = color.H;

            for (byte i = 0; i < 3; i++)
            {
                hue += 60;
                if (hue >= 360) hue -= 360;
                harmony.Add(ColorHSV.FromHsv(color.A, hue, color.S, color.V));
            }

            return harmony;
        }
    }
}
