using System.Windows;
using System.Windows.Navigation;
using MirageMUD2_WPFClient.View.Pages;
using MirageMUD2_WPFClient.View.UserControls;

namespace MirageMUD2_WPFClient
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // Hide the navigation UI (back/forward buttons)
            MainFrame.NavigationUIVisibility = NavigationUIVisibility.Hidden;

            // Load the Home Page into the MainFrame when the application starts
            MainFrame.Navigate(new Page_Home());

            // Subscribe to the Page Requested event from the instance of NavMenu
            navMenu.HomePageRequested += NavigateToHomePage;
            navMenu.NewAccPageRequested += NavigateToNewAccPage;
        }

        // Navigation handler
        private void NavigateToHomePage(object sender, RoutedEventArgs e)
        {
            // Navigate to Page_Home
            MainFrame.Navigate(new Page_Home());
        }
        private void NavigateToNewAccPage(object sender, RoutedEventArgs e)
        {
            // Navigate to Page_Home
            MainFrame.Navigate(new Page_NewAcc());
        }
    }
}
