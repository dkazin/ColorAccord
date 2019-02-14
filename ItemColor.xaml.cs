using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

// Документацию по шаблону элемента "Пользовательский элемент управления" см. по адресу https://go.microsoft.com/fwlink/?LinkId=234236

namespace Color_Accord
{
    public sealed partial class ItemColor : UserControl
    {
        public ItemColor(Brush color, string hex, byte r, byte g, byte b, int h, int s, int v)
        {
            this.InitializeComponent();
            this.color.Fill = color;
            this.hex.Text = hex;
            this.r.Text = r.ToString();
            this.g.Text = g.ToString();
            this.b.Text = b.ToString();

            this.h.Text = h.ToString();
            this.s.Text = s.ToString();
            this.v.Text = v.ToString();
        }
    }
}
