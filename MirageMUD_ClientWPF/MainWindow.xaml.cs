using MirageMUD_ClientWPF.Model.Network;
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
        private readonly CHandleData _cHandleData; // Instance of CHandleData class, used for network communication or data handling

        public MainWindow()
        {
            InitializeComponent(); // Initializes the components defined in XAML
            Loaded += MainWindow_Loaded; // Event handler when the window is loaded

            _cHandleData = new CHandleData(); // Creates a new instance of CHandleData
            //_cHandleData.InitialiseMessages(); // (Commented out) Initializes messages if needed
        }

        // Event handler for the window's Loaded event
        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            StartSplashAnimation(); // Starts the splash screen animation
        }

        // Method to handle the splash screen animations
        private void StartSplashAnimation()
        {
            var duration = TimeSpan.FromSeconds(5); // Duration of the splash screen animation

            // Scale (Zoom) Animation for the Splash Image
            var scaleTransform = new ScaleTransform(1.0, 1.0); // Scale transform to control the zoom
            SplashImage.RenderTransformOrigin = new Point(0.5, 0.5); // Set the origin for the scaling transformation
            SplashImage.RenderTransform = scaleTransform; // Apply the scale transform to the image

            var zoomAnimation = new DoubleAnimation
            {
                From = 0.2, // Initial scale (small)
                To = 1.0, // Final scale (normal size)
                Duration = new Duration(duration) // Duration of the zoom animation
            };

            // Opacity (Fade) Animation for the Splash Image
            var fadeAnimation = new DoubleAnimation
            {
                From = 0.0, // Initial opacity (invisible)
                To = 1.0, // Final opacity (fully visible)
                Duration = new Duration(duration) // Duration of the fade animation
            };

            // Apply the fade and zoom animations to the splash image
            SplashImage.BeginAnimation(OpacityProperty, fadeAnimation);
            scaleTransform.BeginAnimation(ScaleTransform.ScaleXProperty, zoomAnimation);
            scaleTransform.BeginAnimation(ScaleTransform.ScaleYProperty, zoomAnimation);

            // Text Zoom Animation
            var textZoomAnimation = new DoubleAnimation
            {
                From = 0.2, // Initial scale for the text (small)
                To = 1.0, // Final scale (normal size)
                Duration = new Duration(duration) // Duration of the zoom animation
            };

            var textFadeAnimation = new DoubleAnimation
            {
                From = 0.0, // Initial opacity (invisible)
                To = 1.0, // Final opacity (fully visible)
                Duration = new Duration(duration) // Duration of the fade animation
            };

            // Apply the text animations
            txtMadeWith.BeginAnimation(OpacityProperty, textFadeAnimation); // Fade the text in
            TextScaleTransform.BeginAnimation(ScaleTransform.ScaleXProperty, textZoomAnimation); // Zoom the text horizontally
            TextScaleTransform.BeginAnimation(ScaleTransform.ScaleYProperty, textZoomAnimation); // Zoom the text vertically

            // Transition to LoginView after the splash animation completes
            var timer = new DispatcherTimer
            {
                Interval = duration // Set the timer interval to match the animation duration
            };

            timer.Tick += (s, args) =>
            {
                timer.Stop(); // Stop the timer when it ticks
                App.LoginViewInstance.Show(); // Show the LoginView
                this.Close();  // Close the splash screen window
            };

            timer.Start(); // Start the timer
        }
    }
}