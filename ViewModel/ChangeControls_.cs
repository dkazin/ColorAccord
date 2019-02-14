using System.ComponentModel;
using Windows.UI;
using System;
using Windows.UI.Xaml.Controls;
using static Color_Accord.Model.WorkingWithСolor;

namespace Color_Accord.ViewModel
{
    class ChangeControls_: INotifyPropertyChanged
    {

        private string privateHex;
        private Color privateColorRgb;
        private ColorHSV privateColorHsv;

        public string A
        {
            get => privateColorRgb.A.ToString();
            set
            {
                if (Convert.ToByte(value) == privateColorRgb.A) return;
                privateColorRgb.A = Convert.ToByte(value);
                if (PropertyChanged != null)
                {
                    OnPropertyChanged("A");
                    OnPropertyChanged("Hex");
                }
            }
        }

        public string R
        {
            get => privateColorRgb.R.ToString();
            set
            {
                if (Convert.ToByte(value) == privateColorRgb.R) return;
                privateColorRgb.R = Convert.ToByte(value);
                privateHex = RGBToHex(privateColorRgb);
                privateColorHsv = RGBToHSV(privateColorRgb);

                if (PropertyChanged != null)
                {
                    OnPropertyChanged("R");
                    OnPropertyChanged("Hex");
                    OnPropertyChanged("H");
                    OnPropertyChanged("S");
                    OnPropertyChanged("V");
                }
        }
        }

        public string G
        {
            get => privateColorRgb.G.ToString();
            set
            {
                if (Convert.ToByte(value) == privateColorRgb.G) return;
                privateColorRgb.G = Convert.ToByte(value);
                privateHex = RGBToHex(privateColorRgb);
                privateColorHsv = RGBToHSV(privateColorRgb);
                if (PropertyChanged != null)
                {
                    OnPropertyChanged("G");
                    OnPropertyChanged("Hex");
                    OnPropertyChanged("H");
                    OnPropertyChanged("S");
                    OnPropertyChanged("V");
                }    
            }
        }

        public string B
        {
            get => privateColorRgb.B.ToString();
            set
            {
                if (Convert.ToByte(value) == privateColorRgb.B) return;
                privateColorRgb.B = Convert.ToByte(value);
                privateHex = RGBToHex(privateColorRgb);
                privateColorHsv = RGBToHSV(privateColorRgb);
                if (PropertyChanged != null)
                {
                    OnPropertyChanged("B");
                    OnPropertyChanged("Hex");
                    OnPropertyChanged("H");
                    OnPropertyChanged("S");
                    OnPropertyChanged("V");
                }     
            }
        }


        public string H
        {
            get => privateColorHsv.H.ToString();
            set
            {
                if (Convert.ToInt16(value) == privateColorHsv.H) return;
                privateColorHsv.H = Convert.ToInt16(value);
                privateColorRgb = HSVToRGB(privateColorHsv);
                privateHex = RGBToHex(privateColorRgb);
                if (PropertyChanged != null)
                {
                    OnPropertyChanged("H");
                    OnPropertyChanged("R");
                    OnPropertyChanged("G");
                    OnPropertyChanged("B");
                    OnPropertyChanged("Hex");
                }
            }
        }

        public string S
        {
            get => privateColorHsv.S.ToString();
            set
            {
                if (Convert.ToByte(value) == privateColorHsv.S) return;
                privateColorHsv.S = Convert.ToByte(value);
                privateColorRgb = HSVToRGB(privateColorHsv);
                privateHex = RGBToHex(privateColorRgb);
                if (PropertyChanged != null)
                {
                    OnPropertyChanged("S");
                    OnPropertyChanged("R");
                    OnPropertyChanged("G");
                    OnPropertyChanged("B");
                    OnPropertyChanged("Hex");
                }
            }
        }

        public string V
        {
            get => privateColorHsv.V.ToString();
            set
            {
                if (Convert.ToByte(value) == privateColorHsv.V) return;
                privateColorHsv.V = Convert.ToByte(value);
                privateColorRgb = HSVToRGB(privateColorHsv);
                privateHex = RGBToHex(privateColorRgb);
                if (PropertyChanged != null)
                {
                    OnPropertyChanged("V");
                    OnPropertyChanged("R");
                    OnPropertyChanged("G");
                    OnPropertyChanged("B");
                    OnPropertyChanged("Hex");
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
                    OnPropertyChanged("R");
                    OnPropertyChanged("G");
                    OnPropertyChanged("B");
                    OnPropertyChanged("H");
                    OnPropertyChanged("S");
                    OnPropertyChanged("V");
                }
            }
        }

        public ChangeControls_(Color color)
        {
            privateColorRgb = Color.FromArgb(color.A, color.R, color.G, color.B);
            privateColorHsv = RGBToHSV(privateColorRgb);
            privateHex = RGBToHex(privateColorRgb);
        }

        public ChangeControls_(string hex)
        {
            privateHex = hex;
            privateColorRgb = HexToRGB(privateHex);
            privateColorHsv = RGBToHSV(privateColorRgb);
        }

        public ChangeControls_(ColorHSV color)
        {
            privateColorHsv = ColorHSV.FromHsv(color.A, color.H, color.S, color.V);
            privateColorRgb = HSVToRGB(privateColorHsv);
            privateHex = RGBToHex(privateColorRgb);
        }


        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string name)
        {
            //if (PropertyChanged != null)
            //{
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            //}
        }

    }
}