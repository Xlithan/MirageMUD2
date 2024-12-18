using System.IO;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows.Controls;
using System.Windows.Media;

namespace MirageMUD_ClientWPF.View
{
    public partial class AvatarView : Window
    {
        private const string MaleAvatarPath = @"gfx\avatars\Players\Male";
        private const string FemaleAvatarPath = @"gfx\avatars\Players\Female";

        private string _selectedAvatarPath;

        private NewCharView _parent;
        public AvatarView(NewCharView parent)
        {
            InitializeComponent();
            SetWindowPosition();
            _parent = parent; // Store a reference to the parent window

            // Determine which avatar path to load based on the selected gender
            string path = _parent.IsMaleSelected ? MaleAvatarPath : FemaleAvatarPath;

            LoadAvatars(path);
        }
        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
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

            try
            {
                var files = Directory.GetFiles(folderPath, "*.bmp")
                                     .OrderBy(file => int.Parse(Path.GetFileNameWithoutExtension(file)))
                                     .ToList();

                foreach (var file in files)
                {
                    var bitmap = new BitmapImage();
                    bitmap.BeginInit();
                    bitmap.UriSource = new Uri(Path.GetFullPath(file), UriKind.Absolute);
                    bitmap.CacheOption = BitmapCacheOption.OnLoad;
                    bitmap.EndInit();

                    // Create a Grid to stack image and filename
                    var avatarGrid = new Grid();

                    // The Image
                    var img = new Image
                    {
                        Source = bitmap,
                        Width = 70,
                        Height = 70,
                        Stretch = Stretch.UniformToFill,
                        Cursor = Cursors.Hand
                    };

                    // The filename text overlay
                    var fileNameOverlay = new TextBlock
                    {
                        Text = System.IO.Path.GetFileNameWithoutExtension(file),
                        Foreground = Brushes.White,
                        Background = new SolidColorBrush(Color.FromArgb(128, 0, 0, 0)), // Semi-transparent black
                        FontSize = 10,
                        FontWeight = FontWeights.Bold,
                        HorizontalAlignment = HorizontalAlignment.Right,
                        VerticalAlignment = VerticalAlignment.Bottom,
                        Margin = new Thickness(0, 0, 2, 2),
                        Padding = new Thickness(2)
                    };

                    avatarGrid.Children.Add(img);          // Add the image to the grid
                    avatarGrid.Children.Add(fileNameOverlay); // Add the overlay on top of the image

                    // Wrap the grid in a border to allow highlighting
                    var border = new Border
                    {
                        Width = 75,
                        Height = 75,
                        Child = avatarGrid,
                        Background = Brushes.Transparent,
                        BorderThickness = new Thickness(0),
                        BorderBrush = null,
                        Margin = new Thickness(0),
                        CornerRadius = new CornerRadius(3) // Smooth rounded edges
                    };

                    // Add click event to highlight the border and select the avatar
                    img.MouseLeftButtonDown += (s, e) => HighlightAvatar(grid, border, file);

                    grid.Children.Add(border);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading avatars: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            AvatarCollection.Children.Add(grid); // Add the grid to the parent container
        }
        private void HighlightAvatar(UniformGrid grid, Border selectedBorder, string filePath)
        {
            // Reset all borders in the grid to remove highlight
            foreach (var child in grid.Children)
            {
                if (child is Border border)
                {
                    border.BorderThickness = new Thickness(0);
                    border.BorderBrush = null;
                }
            }

            // Highlight the selected border
            selectedBorder.BorderThickness = new Thickness(2);
            selectedBorder.BorderBrush = System.Windows.Media.Brushes.Goldenrod;

            // Store the selected avatar path
            _selectedAvatarPath = filePath;
        }
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(_selectedAvatarPath))
            {
                MessageBox.Show("Please select an avatar before saving.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            try
            {
                // Update the picAvatar Source in NewCharView
                var bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(Path.GetFullPath(_selectedAvatarPath), UriKind.Absolute);
                bitmap.CacheOption = BitmapCacheOption.OnLoad;
                bitmap.EndInit();

                _parent.picAvatar.Source = bitmap;

                // Close the AvatarView window
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving avatar: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
