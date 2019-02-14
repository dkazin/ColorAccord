using Color_Accord.Model;
using Color_Accord.Views;
using System.Collections.Generic;
using System.ComponentModel;
using Windows.UI.Xaml.Controls;

namespace Color_Accord.ViewModel
{
    /// <summary>
    /// Содержит List с гормоничными сочитаниями цветов
    /// </summary>
    /// 
    class Harmony : INotifyPropertyChanged
    {
        private EColor color;
        private Frame frame;
        private int curentHarmony;
        private List<EColor> harmonyList;

        public List<EColor> HarmonyList
        {
            get
            {
                return harmonyList;
            }

            private set
            {
                harmonyList = value;
            }
        }

        public int CurentHarmony
        {
            get => this.curentHarmony;
            set
            {
                // Страница создаётся при первом переходе на неё и данные на ней обновляются постоянно при вызове события HarmonyList

                this.curentHarmony = value;
                GetHarmony(value);

                switch (value)
                {
                    case 0:
                        frame.Navigate(typeof(Complementary), this);
                        break;
                    case 1:
                        frame.Navigate(typeof(Triada), this);
                        break;
                    case 4:
                        frame.Navigate(typeof(Triada), this);
                        break;
                    default:
                        frame.Navigate(typeof(Square), this);
                        break;
                }
            }
        }

        public Harmony(EColor color, Frame frame, int indexHarmony = -1)
        {
            this.frame = frame;
            this.color = color;
            //this.curentHarmony = indexHarmony;
            this.color.PropertyChanged += OnColorChange;
            CurentHarmony = indexHarmony;
        }

        private void GetHarmony(int index)
        {
            switch (index)
            {
                case 0:
                    this.harmonyList = this.color.GetComplementary();
                    break;
                case 1:
                    this.harmonyList = this.color.GetTriad();
                    break;
                case 2:
                    this.harmonyList = this.color.GetSquare();
                    break;
                case 3:
                    this.harmonyList = this.color.GetTetrad(45);
                    break;
                case 4:
                    this.harmonyList = this.color.GetSplitComplementary(155);
                    break;
                case 5:
                    this.harmonyList = this.color.GetMonochromeSaturation();
                    break;
                case 6:
                    this.harmonyList = this.color.GetMonochromeValue();
                    break;
            }
        }

        private void OnColorChange(object sender, PropertyChangedEventArgs e)
        {
            GetHarmony(this.curentHarmony);

            if (PropertyChanged != null)
                OnPropertyChanged("HarmonyList");
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string name)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
    }
}