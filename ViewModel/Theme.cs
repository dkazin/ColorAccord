using System.ComponentModel;
using Windows.UI.Xaml;

namespace Color_Accord.ViewModel
{
    class Theme : INotifyPropertyChanged
    {
        private ElementTheme curentTheme;
        private char pint;

        public event PropertyChangedEventHandler PropertyChanged;

        public char Pint
        {     
            get
            {
                return this.pint;
            }
        } 

        public ElementTheme CurentTheme
        {
            get
            {
                return this.curentTheme;
            }

            set
            {
                this.curentTheme = value;
            }
        }

        public void ReversTheme()
        {
            if (this.curentTheme == ElementTheme.Dark)
                this.curentTheme = ElementTheme.Light;
            else
                this.curentTheme = ElementTheme.Dark;

            SetPint();
            OnPropertyChanged("CurentTheme");
            OnPropertyChanged("Pint");
        }

        private void SetPint ()
        {
            switch ((byte)this.curentTheme)
            {
                case 2:
                    this.pint = '\xE706';
                    break;
                case 1:
                    this.pint = '\xE708';
                    break;
            }
        }

        public Theme(ElementTheme theme = ElementTheme.Dark)
        {
            this.curentTheme = theme;
            switch ((byte)this.curentTheme)
            {
                case 2:
                    this.pint = '\xE706';
                    break;
                case 1:
                    this.pint = '\xE708';
                    break;
            }
        }

        public void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }


    }
}
