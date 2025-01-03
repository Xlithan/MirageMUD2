using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interop;

namespace MirageMUD_ClientWPF.View
{
    public partial class GameView : Window
    {
        private const int HTLEFT = 10;
        private const int HTRIGHT = 11;
        private const int HTTOP = 12;
        private const int HTTOPLEFT = 13;
        private const int HTTOPRIGHT = 14;
        private const int HTBOTTOM = 15;
        private const int HTBOTTOMLEFT = 16;
        private const int HTBOTTOMRIGHT = 17;
        private const int WM_NCHITTEST = 0x0084;

        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll")]
        private static extern IntPtr ReleaseCapture();

        protected override void OnSourceInitialized(EventArgs e)
        {
            base.OnSourceInitialized(e);
            IntPtr handle = new WindowInteropHelper(this).Handle;
            HwndSource.FromHwnd(handle).AddHook(WindowProc);
        }

        private IntPtr WindowProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            if (msg == WM_NCHITTEST)
            {
                Point mousePos = PointFromScreen(new Point((int)lParam & 0xFFFF, (int)lParam >> 16));
                int hitTestResult = GetHitTestResult(mousePos);

                if (hitTestResult != 0)
                {
                    handled = true; // Only handle resizing areas
                    return (IntPtr)hitTestResult;
                }
            }

            // Allow other mouse events to propagate
            return IntPtr.Zero;
        }

        private int GetHitTestResult(Point mousePos)
        {
            const int ResizeBorderWidth = 5;

            if (mousePos.X <= ResizeBorderWidth)
            {
                if (mousePos.Y <= ResizeBorderWidth) return HTTOPLEFT;
                if (mousePos.Y >= ActualHeight - ResizeBorderWidth) return HTBOTTOMLEFT;
                return HTLEFT;
            }

            if (mousePos.X >= ActualWidth - ResizeBorderWidth)
            {
                if (mousePos.Y <= ResizeBorderWidth) return HTTOPRIGHT;
                if (mousePos.Y >= ActualHeight - ResizeBorderWidth) return HTBOTTOMRIGHT;
                return HTRIGHT;
            }

            if (mousePos.Y <= ResizeBorderWidth) return HTTOP;
            if (mousePos.Y >= ActualHeight - ResizeBorderWidth) return HTBOTTOM;

            return 0; // Default: no resize
        }

        public GameView()
        {
            InitializeComponent();
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

        private void btnMaximise_Click(object sender, RoutedEventArgs e)
        {
            if (WindowState == WindowState.Normal)
            {
                WindowState = WindowState.Maximized;
                btnMaximise.Content = "⧉";
            }
            else
            {
                WindowState = WindowState.Normal;
                btnMaximise.Content = "🗖";
            }
        }

        private void btnLook_Click(object sender, RoutedEventArgs e)
        {
        }

        private void btnAction1_Click(object sender, RoutedEventArgs e)
        {
        }

        private void btnAction2_Click(object sender, RoutedEventArgs e)
        {
        }

        private void btnAction3_Click(object sender, RoutedEventArgs e)
        {
        }

        private void btnAction4_Click(object sender, RoutedEventArgs e)
        {
        }

        private void btnAction5_Click(object sender, RoutedEventArgs e)
        {
        }

        private void btnAction6_Click(object sender, RoutedEventArgs e)
        {
        }

        // Code for status bars
        /*private void SetHealth(double percentage)
        {
            // Ensure percentage is clamped between 0 and 100
            percentage = Math.Max(0, Math.Min(100, percentage));

            // Calculate the width based on the percentage
            double fullWidth = 240; // Match the Width of the Border in XAML
            HealthFill.Width = (fullWidth * percentage) / 100;
        }*/
    }
}