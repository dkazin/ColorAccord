using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Color_Accord.ViewModel
{
    class SelectColorHarmony : INotifyPropertyChanged
    {
        public enum ColorHarmonyValues : byte
        {
            Complementary,
            Triada,
            Square
        }

        private List<string> privateListHormony = new List<string>();

        private void InitListHarmony()
        {
            foreach (var item in Enum.GetValues(typeof(ColorHarmonyValues)))
                privateListHormony.Add(item.ToString());
        }

        private ColorHarmonyValues privateColorHarmony;

        public List<string> ListHormony
        {
            get
            {
                return new List<string>(privateListHormony);
            }
        }

        public ColorHarmonyValues ColorHarmony
        {
            get => privateColorHarmony;
            set
            {
                privateColorHarmony = value;
                if (PropertyChanged != null) OnPropertyChanged("ColorHarmony");
            }
        }      

        public SelectColorHarmony()
        {
            privateColorHarmony = ColorHarmonyValues.Complementary;
            InitListHarmony();
        }

        public SelectColorHarmony(ColorHarmonyValues value)
        {
            ColorHarmony = value;
            InitListHarmony();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string name)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
    }
}
