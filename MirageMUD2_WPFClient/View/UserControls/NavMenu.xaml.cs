using System.Windows;
using System.Windows.Controls;

namespace MirageMUD2_WPFClient.View.UserControls
{
    public partial class NavMenu : UserControl
    {
        public NavMenu()
        {
            InitializeComponent();
        }

        // This event is used to notify the parent window when the button is clicked.
        public event RoutedEventHandler HomePageRequested;
        public event RoutedEventHandler NewAccPageRequested;

        private void HomePage(object sender, RoutedEventArgs e)
        {
            // Fire the event to notify the parent window that navigation is needed
            HomePageRequested?.Invoke(this, e);
        }

        private void NewAccountPage(object sender, RoutedEventArgs e)
        {
            // Fire the event to notify the parent window that navigation is needed
            NewAccPageRequested?.Invoke(this, e);
        }
    }
}
