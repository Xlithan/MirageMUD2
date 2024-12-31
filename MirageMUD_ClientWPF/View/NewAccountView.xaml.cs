using MirageMUD_ClientWPF.Model.Network;
using System.Windows;
using System.Windows.Input;

namespace MirageMUD_ClientWPF.View
{
    public partial class NewAccountView : Window
    {
        ClientTCP clientTCP;  // Instance of ClientTCP for network communication
        public NewAccountView()
        {
            InitializeComponent();
            SetWindowPosition();
            // Create a new instance of ClientTCP for new account procedure
            clientTCP = ClientTCP.Instance;
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

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            // Save window position
            SaveWindowPosition();

            // Create an instance of the new window
            App.LoginViewInstance.Show();

            // Optionally close the current window
            this.Hide();
        }

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
                    MessageBox.Show("Passwords do not match!", "Error", MessageBoxButton.OK);
                }
            }
            else
            {
                // Show specific error messages for missing fields
                if (string.IsNullOrWhiteSpace(name))
                {
                    MessageBox.Show("Please enter a login name!", "Error", MessageBoxButton.OK);
                }
                else if (string.IsNullOrWhiteSpace(pass))
                {
                    MessageBox.Show("Please enter a password!", "Error", MessageBoxButton.OK);
                }
                else if (string.IsNullOrWhiteSpace(confirmPass))
                {
                    MessageBox.Show("Please confirm your password!", "Error", MessageBoxButton.OK);
                }
                else
                {
                    MessageBox.Show("Please enter a login name and password!", "Error", MessageBoxButton.OK);
                }
            }
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
