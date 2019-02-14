using System.ComponentModel;
using Windows.UI;
using System;
using Windows.UI.Xaml.Controls;
using static Color_Accord.Model.WorkingWithСolor;
using Color_Accord.Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Color_Accord.ViewModel
{
    class ChangeColor : EColor
    {
        //private int privateNameHarmony = 2;
        //public int NameHarmony
        //{
        //    get => privateNameHarmony;
        //    set
        //    {
        //        privateNameHarmony = value;
        //        OnPropertyChanged("NameHarmony");
        //        switch (privateNameHarmony)
        //        {
        //            case 0:
        //                privateHarmony = this.GetComplementary();
        //                break;
        //            case 1:
        //                privateHarmony = this.GetTriada();
        //                break;
        //            case 2:
        //                privateHarmony = this.GetSquare();
        //                break;
        //        }
        //        OnPropertyChanged("Harmony");
        //    }
        //}


        //private List<EColor> privateHarmony;
        //public List<EColor> Harmony
        //{
        //    get => privateHarmony;
        //    private set
        //    {
        //        privateHarmony = value;
        //        OnPropertyChanged("Harmony");
        //    }
        //}

        public ChangeColor(Color color) : base(color)
        {
        }
    }
}