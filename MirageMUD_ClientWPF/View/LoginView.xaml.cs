using MirageMUD_ClientWPF.Model.Network;
using System.Windows;
using System.Windows.Input;

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

            // Create a new instance of ClientTCP for new account procedure
            clientTCP = ClientTCP.Instance;
            clientTCP.ConnectToServer();  // Connect to the server
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

            string loginName = txtUsername.Text;  // Get the login name from the text box
            string loginPass = txtPassword.Password;  // Get the login password from the text box

            if (!string.IsNullOrWhiteSpace(loginName) && !string.IsNullOrWhiteSpace(loginPass))
            {
                if (clientTCP.PlayerSocket.Connected)
                {
                    clientTCP.SendLogin(txtUsername.Text, txtPassword.Password);  // Send login data to server
                }
            }
            else
            {
                // Show error messages based on missing fields
                if (string.IsNullOrWhiteSpace(loginName) && string.IsNullOrWhiteSpace(loginPass))
                {
                    string translatedMessage = TranslationManager.Instance.GetTranslation("messages.login_prompt");
                    MessageBox.Show(translatedMessage, "Error", MessageBoxButton.OK);
                }
                else if (string.IsNullOrWhiteSpace(loginName))
                {
                    string translatedMessage = TranslationManager.Instance.GetTranslation("messages.login_name_prompt");
                    MessageBox.Show(translatedMessage, "Error", MessageBoxButton.OK);
                }
                else if (string.IsNullOrWhiteSpace(loginPass))
                {
                    string translatedMessage = TranslationManager.Instance.GetTranslation("messages.password_prompt");
                    MessageBox.Show(translatedMessage, "Error", MessageBoxButton.OK);
                }
            }
        }
        private void txtNewAccount_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            // Save window position
            SaveWindowPosition();

            // Create an instance of the new window
            App.NewAccViewInstance.Show();

            // Optionally close the current window
            this.Hide();
        }
        private void btnSettings_Click(object sender, RoutedEventArgs e)
        {
            // Save window position
            SaveWindowPosition();

            // Create an instance of the new window
            App.SettingsViewInstance.Show();

            // Optionally close the current window
            this.Hide();
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
