using System.Windows;
using System.Windows.Controls;

namespace MirageMUD_ClientWPF.View
{
    public class UIButton : Button
    {
        static UIButton()
        {
            // Overrides the default style key to look in Themes.xaml
            DefaultStyleKeyProperty.OverrideMetadata(typeof(UIButton),
                new FrameworkPropertyMetadata(typeof(UIButton)));
        }
    }
}
