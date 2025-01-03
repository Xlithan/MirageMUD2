using MirageMUD_ClientWPF.Model.Network;
using System.Windows;
using System.Windows.Input;

namespace MirageMUD_ClientWPF.View
{
    public partial class NewAccountView : Window
    {
        private ClientTCP clientTCP;  // Instance of ClientTCP for network communication

        public NewAccountView()
        {
            InitializeComponent();  // Initializes the components (UI elements) of the window
            SetWindowPosition();  // Restores the saved window position or centers the window

            // Create a new instance of ClientTCP for new account procedure
            clientTCP = ClientTCP.Instance;
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

        // Navigates back to the login screen
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            // Save the current window position before switching views
            SaveWindowPosition();

            // Show the LoginView instance and hide the current window
            App.LoginViewInstance.Show();
            this.Hide();
        }

        // Handles the new account creation button click
        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            string name = txtUsername.Text;  // Get the new account name from the text box
            string pass = txtPassword.Password;  // Get the new account password from the text box
            string confirmPass = txtPasswordConfirm.Password;  // Get the password confirmation from the text box

            // Check if all fields are filled
            if (!string.IsNullOrWhiteSpace(name) && !string.IsNullOrWhiteSpace(pass) && !string.IsNullOrWhiteSpace(confirmPass))
            {
                // Ensure passwords match
                if (string.Equals(pass, confirmPass))
                {
                    if (clientTCP.PlayerSocket.Connected)
                    {
                        clientTCP.SendNewAccount(txtUsername.Text, txtPassword.Password);  // Send new account data to server
                    }
                }
                else
                {
                    // Show error if passwords do not match
                    string msg = TranslationManager.Instance.GetTranslation($"messages.password_match");
                    string title = TranslationManager.Instance.GetTranslation($"titles.error");
                    MessageBox.Show(msg, title, MessageBoxButton.OK);
                }
            }
            else
            {
                // Show specific error messages for missing fields
                if (string.IsNullOrWhiteSpace(name))
                {
                    string msg = TranslationManager.Instance.GetTranslation($"messages.no_loginname");
                    string title = TranslationManager.Instance.GetTranslation($"titles.error");
                    MessageBox.Show(msg, title, MessageBoxButton.OK);
                }
                else if (string.IsNullOrWhiteSpace(pass))
                {
                    string msg = TranslationManager.Instance.GetTranslation($"messages.no_password");
                    string title = TranslationManager.Instance.GetTranslation($"titles.error");
                    MessageBox.Show(msg, title, MessageBoxButton.OK);
                }
                else if (string.IsNullOrWhiteSpace(confirmPass))
                {
                    string msg = TranslationManager.Instance.GetTranslation($"messages.no_passwordconfirm");
                    string title = TranslationManager.Instance.GetTranslation($"titles.error");
                    MessageBox.Show(msg, title, MessageBoxButton.OK);
                }
                else
                {
                    MessageBox.Show("Please enter a login name and password!", "Error", MessageBoxButton.OK);
                }
            }
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