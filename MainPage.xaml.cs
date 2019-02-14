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
using Color_Accord.ViewModel;
using Windows.UI;
using System.ComponentModel;
using Color_Accord.Views;
using Windows.UI.ViewManagement;
using Windows.ApplicationModel.Core;

// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x419

namespace Color_Accord
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        // Цвет задаваемый при изменении контролов.
        ChangeColor userColor;

        // Текущая схма
        Harmony vmHarmony;

        Theme managerTheme;

        ElementTheme f;

        public MainPage()
        {
            this.InitializeComponent();
            f = this.RequestedTheme;

            //Разрешить использовать собственный заголовок (как следствие убрать стандартный)
            CoreApplication.GetCurrentView().TitleBar.ExtendViewIntoTitleBar = true;



            //CoreApplication.GetCurrentView().TitleBar.ExtendViewIntoTitleBar = true;

            ApplicationViewTitleBar titleBar = ApplicationView.GetForCurrentView().TitleBar;
            titleBar.ButtonBackgroundColor = Colors.Transparent;
            titleBar.ButtonInactiveBackgroundColor = Colors.Transparent;

            // Инициализация начальными значениями контролов.
            userColor = new ChangeColor(Color.FromArgb(255, 255, 70, 0));

            // Текущая схема
            vmHarmony = new Harmony(userColor, frame, 0);


            managerTheme = new Theme();


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            managerTheme.ReversTheme();
        }
    }
}
