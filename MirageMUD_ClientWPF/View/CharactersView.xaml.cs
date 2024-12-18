using System.Windows;
using System.Windows.Input;
using static MirageMUD_ClientWPF.App;

namespace MirageMUD_ClientWPF.View
{
    /// <summary>
    /// Interaction logic for CharactersView.xaml
    /// </summary>
    public partial class CharactersView : Window
    {
        public CharactersView()
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
        private void btnPlay1_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnPlay5_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnPlay4_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnPlay3_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnPlay2_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            // Save window position
            SaveWindowPosition();

            // Create an instance of the new window
            var loginView = new LoginView();
            loginView.Show();

            // Optionally close the current window
            this.Close();
        }

        private void btnNewChar_Click(object sender, RoutedEventArgs e)
        {
            // Save window position
            SaveWindowPosition();

            // Create an instance of the new window
            var newCharView = new NewCharView();
            newCharView.Show();

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
