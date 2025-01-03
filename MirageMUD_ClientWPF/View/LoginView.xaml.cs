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
        private ClientTCP clientTCP;  // Instance of ClientTCP for network communication

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
            InitializeComponent();  // Initializes the components (UI elements) of the window
            SetWindowPosition();  // Restores the saved window position or centers the window

            // Create a new instance of ClientTCP for new account procedure
            clientTCP = ClientTCP.Instance;
            clientTCP.ConnectToServer();  // Connect to the server
        }

        // Handles the mouse down event for dragging the window
        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();  // Allows the window to be dragged by clicking on the grid
            }
        }

        // Minimizes the window when the minimize button is clicked
        private void btnMinimise_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        // Closes the application when the close button is clicked
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();  // Shuts down the application
        }

        // Handles login button click, validates input, and sends login data to the server
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            // Save window position before proceeding
            SaveWindowPosition();

            string loginName = txtUsername.Text;  // Get the login name from the text box
            string loginPass = txtPassword.Password;  // Get the login password from the text box

            if (!string.IsNullOrWhiteSpace(loginName) && !string.IsNullOrWhiteSpace(loginPass))
            {
                if (clientTCP.PlayerSocket.Connected)
                {
                    clientTCP.SendLogin(txtUsername.Text, txtPassword.Password);  // Send login data to the server
                }
            }
            else
            {
                // Show error messages based on missing fields
                if (string.IsNullOrWhiteSpace(loginName) && string.IsNullOrWhiteSpace(loginPass))
                {
                    string msg = TranslationManager.Instance.GetTranslation($"messages.login_prompt");
                    string title = TranslationManager.Instance.GetTranslation($"titles.error");
                    MessageBox.Show(msg, title, MessageBoxButton.OK);
                }
                else if (string.IsNullOrWhiteSpace(loginName))
                {
                    string msg = TranslationManager.Instance.GetTranslation($"messages.login_name_prompt");
                    string title = TranslationManager.Instance.GetTranslation($"titles.error");
                    MessageBox.Show(msg, title, MessageBoxButton.OK);
                }
                else if (string.IsNullOrWhiteSpace(loginPass))
                {
                    string msg = TranslationManager.Instance.GetTranslation($"messages.password_prompt");
                    string title = TranslationManager.Instance.GetTranslation($"titles.error");
                    MessageBox.Show(msg, title, MessageBoxButton.OK);
                }
            }
        }

        // Opens the new account creation window when the "New Account" label is clicked
        private void txtNewAccount_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            // Save the window position before switching views
            SaveWindowPosition();

            // Create an instance of the new window and show it
            App.NewAccViewInstance.Show();

            // Hide the current window
            this.Hide();
        }

        // Opens the settings window when the settings button is clicked
        private void btnSettings_Click(object sender, RoutedEventArgs e)
        {
            // Save window position before opening the settings view
            SaveWindowPosition();

            // Create an instance of the settings window and show it
            App.SettingsViewInstance.Show();

            // Hide the current window
            this.Hide();
        }

        // Saves the current window position for future restoration
        private void SaveWindowPosition()
        {
            App.LastLeft = this.Left;
            App.LastTop = this.Top;
        }

        // Restores the saved window position, or centers the window if no saved position exists
        private void SetWindowPosition()
        {
            if (!double.IsNaN(App.LastLeft) && !double.IsNaN(App.LastTop))
            {
                this.Left = App.LastLeft;  // Restore the horizontal position
                this.Top = App.LastTop;  // Restore the vertical position
            }
            else
            {
                // Default to center screen if no position is saved
                this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            }
        }
    }
}