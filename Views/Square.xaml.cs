using Color_Accord.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=234238

namespace Color_Accord.Views
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class Square : Page
    {
        Harmony vmHarmony;

        public Square()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            vmHarmony = (e.Parameter as Harmony);
        }



        protected override void OnNavigatingFrom(NavigatingCancelEventArgs e)
        {
            this.Content = null;
            this.Frame.Content = null;
            this.DataContext = null;
            base.OnNavigatingFrom(e);
            
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            this.Content = null;
            this.DataContext = null;
            this.Frame.Content = null;
            base.OnNavigatedFrom(e);
            
        }

        
    }
}
