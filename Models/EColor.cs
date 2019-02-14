using System;
using System.Collections.Generic;
using System.ComponentModel;
using Windows.UI;
using static Color_Accord.Model.WorkingWithСolor;

namespace Color_Accord.Model
{
    class EColor : INotifyPropertyChanged
    {
        private string privateHex;
        private Color privateColorRgb;
        private ColorHSV privateColorHsv;

        public byte A
        {
            get => privateColorRgb.A;
            set
            {
                if (value == privateColorRgb.A) return;
                privateColorRgb.A = value;
                if (PropertyChanged != null)
                {
                    OnPropertyChanged("A");
                    OnPropertyChanged("Hex");
                }
            }
        }

        public byte R
        {
            get => privateColorRgb.R;
            set
            {
                if (value == privateColorRgb.R) return;
                privateColorRgb.R = value;
                privateHex = RGBToHex(privateColorRgb);
                privateColorHsv = RGBToHSV(privateColorRgb);

                if (PropertyChanged != null)
                {
                    OnPropertyChanged("");
                }
            }
        }

        public byte G
        {
            get => privateColorRgb.G;
            set
            {
                if (value == privateColorRgb.G) return;
                privateColorRgb.G = value;
                privateHex = RGBToHex(privateColorRgb);
                privateColorHsv = RGBToHSV(privateColorRgb);
                if (PropertyChanged != null)
                {
                    OnPropertyChanged("");
                }
            }
        }

        public byte B
        {
            get => privateColorRgb.B;
            set
            {
                if (value == privateColorRgb.B) return;
                privateColorRgb.B = value;
                privateHex = RGBToHex(privateColorRgb);
                privateColorHsv = RGBToHSV(privateColorRgb);
                if (PropertyChanged != null)
                {
                    OnPropertyChanged("");
                }
            }
        }


        public int H
        {
            get => privateColorHsv.H;
            set
            {
                if (value == privateColorHsv.H) return;
                privateColorHsv.H = value;
                privateColorRgb = HSVToRGB(privateColorHsv);
                privateHex = RGBToHex(privateColorRgb);
                if (PropertyChanged != null)
                {
                    OnPropertyChanged("");
                }
            }
        }

        public int S
        {
            get => privateColorHsv.S;
            set
            {
                if (value == privateColorHsv.S) return;
                privateColorHsv.S = value;
                privateColorRgb = HSVToRGB(privateColorHsv);
                privateHex = RGBToHex(privateColorRgb);
                if (PropertyChanged != null)
                {
                    OnPropertyChanged("");
                }
            }
        }

        public int V
        {
            get => privateColorHsv.V;
            set
            {
                if (value == privateColorHsv.V) return;
                privateColorHsv.V = value;
                privateColorRgb = HSVToRGB(privateColorHsv);
                privateHex = RGBToHex(privateColorRgb);
                if (PropertyChanged != null)
                {
                    OnPropertyChanged("");
                }
            }
        }

        public Color ColorRgb
        {
            get
            {
                return Color.FromArgb(privateColorRgb.A, privateColorRgb.R, privateColorRgb.G, privateColorRgb.B);
            }
        }

        public ColorHSV ColorHsv
        {
            get
            {
                return ColorHSV.FromHsv(privateColorHsv.A, privateColorHsv.H, privateColorHsv.S, privateColorHsv.V);
            }
        }

        public string Hex
        {
            get
            {
                return "#" + privateHex;
            }

            set
            {
                privateHex = value.Replace("#", "");
                privateColorRgb = HexToRGB(privateHex);
                privateColorHsv = RGBToHSV(privateColorRgb);
                if (PropertyChanged != null)
                {
                    OnPropertyChanged("");
                }
            }
        }

        public EColor(Color color)
        {
            privateColorRgb = Color.FromArgb(color.A, color.R, color.G, color.B);
            privateColorHsv = RGBToHSV(privateColorRgb);
            privateHex = RGBToHex(privateColorRgb);
        }

        public EColor(string hex)
        {
            privateHex = hex;
            privateColorRgb = HexToRGB(privateHex);
            privateColorHsv = RGBToHSV(privateColorRgb);
        }

        public EColor(ColorHSV color)
        {
            privateColorHsv = ColorHSV.FromHsv(color.A, color.H, color.S, color.V);
            privateColorRgb = HSVToRGB(privateColorHsv);
            privateHex = RGBToHex(privateColorRgb);
        }

        /// <summary>Комплементарная цветовая схема.</summary>
        /// <returns>List<EColor> Список цветовых сочитаний</returns>
        public List<EColor> GetComplementary()
        {
            List<EColor> harmony = new List<EColor> { new EColor(this.privateColorRgb) };

            int hue = this.privateColorHsv.H + 180;

            if (hue >= 360) hue -= 360;

            harmony.Add(new EColor(ColorHSV.FromHsv(this.privateColorHsv.A, hue, this.privateColorHsv.S, this.privateColorHsv.V)));

            // Заплтка в листе должно быть 4 элемента, для работы на несколькиз Frame
            harmony.Add(null);
            harmony.Add(null);

            return harmony;
        }


        /// <summary>Цветовая схема Триада.</summary>
        /// <returns>List<EColor> Список цветовых сочитаний</returns>
        public List<EColor> GetTriad()
        {
            List<EColor> harmony = new List<EColor>() { new EColor(this.privateColorRgb) };
            int hue = this.privateColorHsv.H;

            for (byte i = 0; i < 2; i++)
            {
                hue += 120;
                if (hue >= 360) hue -= 360;
                harmony.Add(new EColor(ColorHSV.FromHsv(this.privateColorHsv.A, hue, this.privateColorHsv.S, this.privateColorHsv.V)));
            }

            // Заплтка в листе должно быть 4 элемента, для работы на несколькиз Frame
            harmony.Add(null);

            return harmony;
        }

        /// <summary>Цветовая схема Квадрат. Частный случай четырехугольной</summary>
        /// <returns>List<EColor> Список цветовых сочитаний</returns>
        public List<EColor> GetSquare()
        {
            List<EColor> harmony = new List<EColor>() { new EColor(this.privateColorRgb) };
            int hue = this.privateColorHsv.H;

            for (byte i = 0; i < 3; i++)
            {
                hue += 90;
                if (hue >= 360) hue -= 360;
                harmony.Add(new EColor(ColorHSV.FromHsv(this.privateColorHsv.A, hue, this.privateColorHsv.S, this.privateColorHsv.V)));
            }

            return harmony;
        }

        /// <summary>Четырехугольная цветова схема. Общий случай квадратной</summary>
        /// <param name="angle">Угол от 0 до 90 градусов от исходного цвета</param>
        /// <returns>List<EColor> Список цветовых сочитаний</returns>
        public List<EColor> GetTetrad(int angle = 90)
        {
            List<EColor> harmony = new List<EColor>() { new EColor(this.privateColorRgb) };

            int hue = this.privateColorHsv.H + angle;
            if (hue >= 360) hue -= 360;
            harmony.Add(new EColor(ColorHSV.FromHsv(this.privateColorHsv.A, hue, this.privateColorHsv.S, this.privateColorHsv.V)));

            hue = this.privateColorHsv.H + 180;
            if (hue >= 360) hue -= 360;
            harmony.Add(new EColor(ColorHSV.FromHsv(this.privateColorHsv.A, hue, this.privateColorHsv.S, this.privateColorHsv.V)));

            hue += angle;
            if (hue >= 360) hue -= 360;
            harmony.Add(new EColor(ColorHSV.FromHsv(this.privateColorHsv.A, hue, this.privateColorHsv.S, this.privateColorHsv.V)));

            return harmony;
        }


        /// <summary>Раздельно-комплементарная цветовая схема. Общий случай Треугольной схемы</summary>
        /// <returns>List<EColor>Список цветовых сочитаний</returns>
        public List<EColor> GetSplitComplementary(int angle = 120)
        {
            List<EColor> harmony = new List<EColor>() { new EColor(this.privateColorRgb) };

            int hue = this.privateColorHsv.H + angle;
            if (hue >= 360) hue -= 360;
            harmony.Add(new EColor(ColorHSV.FromHsv(this.privateColorHsv.A, hue, this.privateColorHsv.S, this.privateColorHsv.V)));

            hue = this.privateColorHsv.H - angle;
            if (hue < 0) hue += 360;
            harmony.Add(new EColor(ColorHSV.FromHsv(this.privateColorHsv.A, hue, this.privateColorHsv.S, this.privateColorHsv.V)));

            // Заплтка в листе должно быть 4 элемента, для работы на несколькиз Frame
            harmony.Add(null);

            return harmony;
        }

        public List<EColor> GetMonochromeSaturation()
        {
            List<EColor> harmony = new List<EColor>() { new EColor(this.privateColorRgb) };

            int saturation = this.privateColorHsv.S;
            for (byte i = 0; i < 3; i++)
            {
                saturation += 25;
                if (saturation > 100) saturation -= 100;
                harmony.Add(new EColor(ColorHSV.FromHsv(this.privateColorHsv.A, this.privateColorHsv.H, saturation, this.privateColorHsv.V)));
            }

            return harmony;
        }


        public List<EColor> GetMonochromeValue()
        {
            List<EColor> harmony = new List<EColor>() { new EColor(this.privateColorRgb) };

            int value = this.privateColorHsv.V;
            for (byte i = 0; i < 3; i++)
            {
                value += 25;
                if (value > 100) value -= 100;
                harmony.Add(new EColor(ColorHSV.FromHsv(this.privateColorHsv.A, this.privateColorHsv.H, this.privateColorHsv.S, value)));
            }

            return harmony;
        }
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string name)
        {
            //if (PropertyChanged != null)
            PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
    }
}