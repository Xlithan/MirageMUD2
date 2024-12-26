using MirageMUD_ClientWPF.Model.Network;
using MirageMUD_ClientWPF.Model.Utilities;
using System.Windows;
using System.Windows.Input;
using static MirageMUD_ClientWPF.App;

namespace MirageMUD_ClientWPF.View
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : Window
    {
        ClientTCP clientTCP;  // Instance of ClientTCP for network communication

        // Enum for different menu states
        public enum MenuState : byte
        {
            NewAccount = 0,  // New account creation menu
            DelAccount = 1,  // Account deletion menu
            Login = 2,  // Login menu
            GetChars = 3,  // Retrieve characters menu
            NewChar = 4,  // New character creation menu
            AddChar = 5,  // Add character to account
            DelChar = 6,  // Delete character menu
            UseChar = 7,  // Use existing character
            Init = 8  // Initial state of the menu
        }
        public LoginView()
        {
            InitializeComponent();
            SetWindowPosition();

            
        }
        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }
        private void btnMinimise_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            // Save window position
            SaveWindowPosition();

            // Create an instance of the new window
            var charactersView = new CharactersView();
            charactersView.Show();

            // Optionally close the current window
            this.Close();
        }
        private void txtNewAccount_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            // Save window position
            SaveWindowPosition();

            // Create an instance of the new window
            var newAccountView = new NewAccountView();
            newAccountView.Show();

            // Optionally close the current window
            this.Close();
        }
        private void btnSettings_Click(object sender, RoutedEventArgs e)
        {
            // Save window position
            SaveWindowPosition();

            // Create an instance of the new window
            var settingsView = new SettingsView();
            settingsView.Show();

            // Optionally close the current window
            this.Close();
        }
        private void SaveWindowPosition()
        {
            App.LastLeft = this.Left;
            App.LastTop = this.Top;
        }
        private void SetWindowPosition()
        {
            if (!double.IsNaN(App.LastLeft) && !double.IsNaN(App.LastTop))
            {
                this.Left = App.LastLeft;
                this.Top = App.LastTop;
            }
            else
            {
                // Default to center screen if no position is saved
                this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            }
        }
    }
}
