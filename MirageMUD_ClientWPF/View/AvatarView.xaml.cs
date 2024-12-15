using System.IO;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows.Controls;

namespace MirageMUD_ClientWPF.View
{
    public partial class AvatarView : Window
    {
        private const string MaleAvatarPath = @"gfx\avatars\Players\Male";
        private const string FemaleAvatarPath = @"gfx\avatars\Players\Female";

        private NewCharView _parent;
        public AvatarView(NewCharView parent)
        {
            InitializeComponent();
            SetWindowPosition();
            LoadAvatars(MaleAvatarPath); // Default to Male avatars on load
            _parent = parent; // Store a reference to the parent window
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Determine which avatar path to load based on the selected gender
            string path = _parent.IsMaleSelected ? MaleAvatarPath : FemaleAvatarPath;

            LoadAvatars(path);
        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
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
        private void LoadAvatars(string folderPath)
        {
            // Debug: Verify folder path
            MessageBox.Show($"Loading avatars from: {Path.GetFullPath(folderPath)}");

            if (!Directory.Exists(folderPath))
            {
                MessageBox.Show("Folder does not exist!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            AvatarCollection.Children.Clear(); // Clear existing avatars

            var grid = new UniformGrid
            {
                Columns = 4, // Adjust columns based on layout needs
                Margin = new Thickness(5)
            };

            // Iterate through all PNG files in the folder
            foreach (var file in Directory.GetFiles(folderPath, "*.png"))
            {
                // Debug: Log each file found
                MessageBox.Show($"Found image: {file}");

                try
                {
                    var bitmap = new BitmapImage();
                    bitmap.BeginInit();
                    bitmap.UriSource = new Uri(Path.GetFullPath(file), UriKind.Absolute);
                    bitmap.CacheOption = BitmapCacheOption.OnLoad;
                    bitmap.EndInit();

                    var img = new Image
                    {
                        Source = bitmap,
                        Width = 70,
                        Height = 70,
                        Margin = new Thickness(5),
                        Cursor = System.Windows.Input.Cursors.Hand,
                    };

                    grid.Children.Add(img);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading image {file}: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

            AvatarCollection.Children.Add(grid); // Add the grid to the parent container
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
