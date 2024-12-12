using System.Windows;
using System.Windows.Input;

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
        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
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
            // Create an instance of the new window
            var loginView = new LoginView();
            loginView.Show();

            // Optionally close the current window
            this.Close();
        }

        private void btnNewChar_Click(object sender, RoutedEventArgs e)
        {
            // Create an instance of the new window
            var newCharView = new NewCharView();
            newCharView.Show();

            // Optionally close the current window
            this.Close();
        }
    }
}
