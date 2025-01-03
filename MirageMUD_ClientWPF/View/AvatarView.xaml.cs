using MirageMUD_ClientWPF.Model.Types;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace MirageMUD_ClientWPF.View
{
    public partial class AvatarView : Window
    {
        private const string MaleAvatarPath = @"gfx\avatars\Players\Male";  // Path to male avatars
        private const string FemaleAvatarPath = @"gfx\avatars\Players\Female";  // Path to female avatars

        private string _selectedAvatarPath;  // Holds the selected avatar path

        private NewCharView _parent;  // Reference to the parent window

        // Constructor that initializes the view and loads avatars based on gender selection
        public AvatarView(NewCharView parent)
        {
            InitializeComponent();
            SetWindowPosition();  // Set window position
            _parent = parent;  // Store reference to parent window

            // Determine the folder path based on selected gender
            string path = _parent.IsMaleSelected ? MaleAvatarPath : FemaleAvatarPath;

            LoadAvatars(path);  // Load avatars from the determined path
        }

        // Allows dragging the window by clicking and holding anywhere on the window
        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();  // Moves the window when clicked and held
            }
        }

        // Closes the AvatarView window
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        // Sets the position of the window based on saved coordinates or centers it
        private void SetWindowPosition()
        {
            if (!double.IsNaN(App.LastLeft) && !double.IsNaN(App.LastTop))
            {
                this.Left = App.LastLeft;
                this.Top = App.LastTop;
            }
            else
            {
                this.WindowStartupLocation = WindowStartupLocation.CenterScreen;  // Default to center if no position is saved
            }
        }

        // Loads avatars from the specified folder path
        private void LoadAvatars(string folderPath)
        {
            if (!Directory.Exists(folderPath))
            {
                MessageBox.Show("Folder does not exist!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            AvatarCollection.Children.Clear();  // Clears existing avatars

            var grid = new UniformGrid
            {
                Columns = 4,  // Adjust number of columns for layout
                Margin = new Thickness(5)
            };

            try
            {
                var files = Directory.GetFiles(folderPath, "*.bmp")  // Get all .bmp files
                                     .OrderBy(file => int.Parse(Path.GetFileNameWithoutExtension(file)))  // Sort by filename number
                                     .ToList();

                foreach (var file in files)
                {
                    var bitmap = new BitmapImage();
                    bitmap.BeginInit();
                    bitmap.UriSource = new Uri(Path.GetFullPath(file), UriKind.Absolute);
                    bitmap.CacheOption = BitmapCacheOption.OnLoad;
                    bitmap.EndInit();

                    // Create a grid to hold the image and its filename overlay
                    var avatarGrid = new Grid();

                    // Create the image element
                    var img = new Image
                    {
                        Source = bitmap,
                        Width = 70,
                        Height = 70,
                        Stretch = Stretch.UniformToFill,
                        Cursor = Cursors.Hand
                    };

                    // Create the text overlay displaying the file name
                    var fileNameOverlay = new TextBlock
                    {
                        Text = System.IO.Path.GetFileNameWithoutExtension(file),
                        Foreground = Brushes.White,
                        Background = new SolidColorBrush(Color.FromArgb(128, 0, 0, 0)),  // Semi-transparent black background
                        FontSize = 10,
                        FontWeight = FontWeights.Bold,
                        HorizontalAlignment = HorizontalAlignment.Right,
                        VerticalAlignment = VerticalAlignment.Bottom,
                        Margin = new Thickness(0, 0, 2, 2),
                        Padding = new Thickness(2)
                    };

                    avatarGrid.Children.Add(img);  // Add image to grid
                    avatarGrid.Children.Add(fileNameOverlay);  // Add filename overlay to grid

                    // Wrap the grid in a border to allow for highlighting
                    var border = new Border
                    {
                        Width = 75,
                        Height = 75,
                        Child = avatarGrid,
                        Background = Brushes.Transparent,
                        BorderThickness = new Thickness(0),
                        BorderBrush = null,
                        Margin = new Thickness(0),
                        CornerRadius = new CornerRadius(3)  // Smooth rounded corners
                    };

                    // Add click event to select the avatar and highlight the border
                    img.MouseLeftButtonDown += (s, e) => HighlightAvatar(grid, border, file);

                    grid.Children.Add(border);  // Add the border to the grid
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading avatars: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            AvatarCollection.Children.Add(grid);  // Add the grid of avatars to the parent container
        }

        // Highlights the selected avatar and stores the file path
        private void HighlightAvatar(UniformGrid grid, Border selectedBorder, string filePath)
        {
            // Reset all borders in the grid
            foreach (var child in grid.Children)
            {
                if (child is Border border)
                {
                    border.BorderThickness = new Thickness(0);  // Reset border thickness
                    border.BorderBrush = null;  // Reset border color
                }
            }

            // Highlight the selected border
            selectedBorder.BorderThickness = new Thickness(2);
            selectedBorder.BorderBrush = System.Windows.Media.Brushes.Goldenrod;  // Highlight with goldenrod color

            // Store the selected avatar file path
            _selectedAvatarPath = filePath;
        }

        // Saves the selected avatar and updates the parent window
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(_selectedAvatarPath))
            {
                MessageBox.Show("Please select an avatar before saving.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            try
            {
                // Create a BitmapImage from the selected avatar file
                var bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(Path.GetFullPath(_selectedAvatarPath), UriKind.Absolute);
                bitmap.CacheOption = BitmapCacheOption.OnLoad;
                bitmap.EndInit();

                // Update the Avatar image source in the parent window
                _parent.picAvatar.Source = bitmap;
                Globals.Player.Avatar = Convert.ToInt32(Path.GetFileNameWithoutExtension(_selectedAvatarPath));  // Update player avatar ID

                // Close the AvatarView window after saving
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving avatar: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}