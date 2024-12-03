using System.Windows;
using System.Windows.Input;

namespace MirageMUD2_WPFClient
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        // This method is called when the user clicks on the StackPanel to drag the window
        private void OnDragWindow(object sender, MouseButtonEventArgs e)
        {
            // This will allow the user to drag the window by holding the left mouse button
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }

        // Minimize the window
        private void OnMinimizeWindow(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        // Close the window
        private void OnCloseWindow(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            this.Close();
        }
    }
}
