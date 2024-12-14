using System.Configuration;
using System.Data;
using System.Windows;

namespace MirageMUD_ClientWPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static double LastLeft { get; set; } = double.NaN;
        public static double LastTop { get; set; } = double.NaN;
    }

}
