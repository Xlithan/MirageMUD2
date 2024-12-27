using MirageMUD_ClientWPF.Model.Network;
using MirageMUD_ClientWPF.View;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Threading;

namespace MirageMUD_ClientWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly CHandleData _cHandleData;
        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;

            _cHandleData = new CHandleData();
            _cHandleData.InitialiseMessages();
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            StartSplashAnimation();
        }

        private void StartSplashAnimation()
        {
            var duration = TimeSpan.FromSeconds(5);

            // Scale (Zoom) Animation for the Image
            var scaleTransform = new ScaleTransform(1.0, 1.0);
            SplashImage.RenderTransformOrigin = new Point(0.5, 0.5);
            SplashImage.RenderTransform = scaleTransform;

            var zoomAnimation = new DoubleAnimation
            {
                From = 0.2,
                To = 1.0,
                Duration = new Duration(duration)
            };

            // Opacity (Fade) Animation for the Image
            var fadeAnimation = new DoubleAnimation
            {
                From = 0.0,
                To = 1.0,
                Duration = new Duration(duration)
            };

            // Apply animations to the image
            SplashImage.BeginAnimation(OpacityProperty, fadeAnimation);
            scaleTransform.BeginAnimation(ScaleTransform.ScaleXProperty, zoomAnimation);
            scaleTransform.BeginAnimation(ScaleTransform.ScaleYProperty, zoomAnimation);

            // Text Zoom Animation
            var textZoomAnimation = new DoubleAnimation
            {
                From = 0.2,
                To = 1.0,
                Duration = new Duration(duration)
            };

            var textFadeAnimation = new DoubleAnimation
            {
                From = 0.0,
                To = 1.0,
                Duration = new Duration(duration)
            };

            // Apply animations to the text
            txtMadeWith.BeginAnimation(OpacityProperty, textFadeAnimation);
            TextScaleTransform.BeginAnimation(ScaleTransform.ScaleXProperty, textZoomAnimation);
            TextScaleTransform.BeginAnimation(ScaleTransform.ScaleYProperty, textZoomAnimation);

            // Transition to LoginView after 3 seconds
            var timer = new DispatcherTimer
            {
                Interval = duration
            };

            timer.Tick += (s, args) =>
            {
                timer.Stop();
                App.LoginViewInstance.Show();
                this.Close();  // Close the splash window
            };

            timer.Start();
        }
    }
}