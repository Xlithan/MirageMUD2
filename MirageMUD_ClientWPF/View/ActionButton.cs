using System.Windows;
using System.Windows.Controls;

namespace MirageMUD_ClientWPF.View
{
    public class ActionButton : Button
    {
        static ActionButton()
        {
            // Overrides the default style key to look in Themes.xaml
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ActionButton),
                new FrameworkPropertyMetadata(typeof(ActionButton)));
        }
    }
}
