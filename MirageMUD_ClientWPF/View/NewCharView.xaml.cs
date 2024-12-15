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
        public bool IsMaleSelected => optMale.IsChecked == true;
        public NewCharView()
        {
            InitializeComponent();
            SetWindowPosition();
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
            // Save window position
            SaveWindowPosition();

            // Create an instance of the new window
            var charactersView = new CharactersView();
            charactersView.Show();

            // Optionally close the current window
            this.Close();
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
