using System.Windows;
using System.Windows.Input;

namespace MirageMUD_ClientWPF.View
{
    /// <summary>
    /// Interaction logic for NewCharView.xaml
    /// </summary>
    public partial class NewCharView : Window
    {
        public NewCharView()
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
            var charactersView = new CharactersView();
            charactersView.Show();

            // Optionally close the current window
            this.Close();
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
