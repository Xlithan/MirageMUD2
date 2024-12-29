using MirageMUD_ClientWPF.Model.Network;
using MirageMUD_ClientWPF.ViewModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;
using static MirageMUD_ClientWPF.App;

namespace MirageMUD_ClientWPF.View
{
    /// <summary>
    /// Interaction logic for NewCharView.xaml
    /// </summary>
    public partial class NewCharView : Window
    {
        public bool IsMaleSelected = true;
        ClientTCP clientTCP;  // Instance of ClientTCP for network communication
        public NewCharView()
        {
            InitializeComponent();
            clientTCP = ClientTCP.Instance;
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
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            // Save window position
            SaveWindowPosition();

            // Create an instance of the new window
            App.CharsViewInstance.Show();

            // Optionally close the current window
            this.Hide();
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnFinish_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnAvatar_Click(object sender, RoutedEventArgs e)
        {
            var avatarView = new AvatarView(this); // Pass 'this' as the parent
            avatarView.ShowDialog();
        }

        private void btnReroll_Click(object sender, RoutedEventArgs e)
        {
            if (clientTCP.PlayerSocket.Connected)
            {
                clientTCP.SendRerollRequest();  // Send login data to server
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

        private void optMale_Click(object sender, RoutedEventArgs e)
        {
            if(optMale.IsChecked == true)
            {
                IsMaleSelected = true;
            }
        }

        private void optFemale_Click(object sender, RoutedEventArgs e)
        {
            if (optFemale.IsChecked == true)
            {
                IsMaleSelected = false;
            }
        }
    }
}
