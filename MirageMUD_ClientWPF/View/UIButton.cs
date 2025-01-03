using System.Windows;
using System.Windows.Controls;

namespace MirageMUD_ClientWPF.View
{
    // Custom UIButton class that extends the Button control to apply a custom style.
    public class UIButton : Button
    {
        // Static constructor to override the default style for UIButton.
        static UIButton()
        {
            // Overrides the DefaultStyleKeyProperty to reference a custom style defined in Themes.xaml.
            DefaultStyleKeyProperty.OverrideMetadata(typeof(UIButton),
                new FrameworkPropertyMetadata(typeof(UIButton)));
        }
    }
}