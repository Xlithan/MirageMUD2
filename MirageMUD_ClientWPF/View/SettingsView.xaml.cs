using System.Windows;
using System.Windows.Input;

namespace MirageMUD_ClientWPF.View
{
    /// <summary>
    /// Interaction logic for SettingsView.xaml
    /// </summary>
    public partial class SettingsView : Window
    {
        public SettingsView()
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

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            // Create an instance of the new window
            var loginView = new LoginView();
            loginView.Show();

            // Optionally close the current window
            this.Close();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
