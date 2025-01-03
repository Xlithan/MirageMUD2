using MirageMUD_ClientWPF.Model.Network;
using MirageMUD_ClientWPF.Model.Types;
using MirageMUD_ClientWPF.ViewModel;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace MirageMUD_ClientWPF.View
{
    /// <summary>
    /// Interaction logic for CharactersView.xaml
    /// </summary>
    public partial class CharactersView : Window
    {
        public int selectedChar { get; set; } // Stores the index of the selected character
        private ClientTCP clientTCP;  // Instance of ClientTCP for network communication

        public CharactersView()
        {
            InitializeComponent();  // Initializes the components (UI elements) of the window
            SetWindowPosition();  // Sets the window position based on saved location
            DataContext = new CharacterViewModel();  // Binds the DataContext to the ViewModel
            clientTCP = ClientTCP.Instance;  // Gets the singleton instance of ClientTCP
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();  // Allows dragging of the window by clicking on the grid
            }
        }

        private void btnMinimise_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;  // Minimizes the window
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();  // Closes the application
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            // Save window position before navigating away
            SaveWindowPosition();

            // Send logout message to the server if connected
            if (clientTCP.PlayerSocket.Connected)
            {
                clientTCP.SendLogout();  // Send logout data to server
            }
            App.LoginViewInstance.Show();  // Show the login view

            // Optionally hide the current window (keeps the app running)
            this.Hide();
        }

        private void PlayGame()
        {
            // Show the game window
            App.GameViewInstance.Show();

            // Close the current characters window
            this.Close();
        }

        private void SaveWindowPosition()
        {
            // Save the current window position to be restored later
            App.LastLeft = this.Left;
            App.LastTop = this.Top;
        }

        private void SetWindowPosition()
        {
            // Restore the window position if saved, otherwise center the window on the screen
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

        private void btnPlay_Click(object sender, RoutedEventArgs e)
        {
            // If a valid character is selected, start the game
            if (selectedChar >= 0 && !lblName.Text.Equals("Empty Slot") && !lblName.Text.Equals(string.Empty))
            {
                PlayGame();
            }
            else
            {
                // Show an error message if no character is selected
                string msg = TranslationManager.Instance.GetTranslation($"messages.char_notselected");
                string title = TranslationManager.Instance.GetTranslation($"titles.alert");
                MessageBox.Show(msg, title, MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        private void btnNewChar_Click(object sender, RoutedEventArgs e)
        {
            // Check if an empty slot is selected for creating a new character
            if (selectedChar >= 0 && lblName.Text.Equals("Empty Slot") && !lblName.Text.Equals(string.Empty))
            {
                // Save window position before opening the character creation window
                SaveWindowPosition();

                // Show the character creation window
                App.NewCharViewInstance.Show();

                // Reset the new character creation window elements
                App.NewCharViewInstance.txtCharName.Text = string.Empty;
                App.NewCharViewInstance.SelectFirstEnabledRadioButton(App.NewCharViewInstance.RaceWrapPanel);  // Select the first enabled race option
                App.NewCharViewInstance.optMale.IsChecked = true;  // Default to male character
                App.NewCharViewInstance.IsMaleSelected = true;  // Mark male as selected
                ResetAvatar();  // Reset the avatar to default

                // Pre-roll stats so they are not all zero
                App.NewCharViewInstance.Reroll();

                // Optionally hide the current window
                this.Hide();
            }
            else
            {
                // Show an error message if an empty slot is not selected
                string msg = TranslationManager.Instance.GetTranslation($"messages.select_emptyslot");
                string title = TranslationManager.Instance.GetTranslation($"titles.alert");
                MessageBox.Show(msg, title, MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        private void ResetAvatar()
        {
            // Set the default avatar path based on gender
            string defaultAvatarPath = @"gfx\avatars\Players\Male\1.bmp";

            try
            {
                // Create a new BitmapImage to set the avatar
                var bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(Path.GetFullPath(defaultAvatarPath), UriKind.Absolute);
                bitmap.CacheOption = BitmapCacheOption.OnLoad;
                bitmap.EndInit();

                // Update the avatar image in the NewCharView
                App.NewCharViewInstance.picAvatar.Source = bitmap;
                Globals.Player.Avatar = 1; // Set the avatar to default value
            }
            catch (Exception ex)
            {
                // Show an error message if there is an issue with resetting the avatar
                string msg = TranslationManager.Instance.GetTranslation($"error.resetting_avatar", ex.Message);
                string title = TranslationManager.Instance.GetTranslation($"titles.error");
                MessageBox.Show(msg, title, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Avatar_Click(object sender, MouseButtonEventArgs e)
        {
            // When an avatar is clicked, update the selected character
            if (sender is Image clickedImage && clickedImage.Tag is string tagStr && int.TryParse(tagStr, out int index))
            {
                if (DataContext is CharacterViewModel viewModel && index < viewModel.Characters.Count)
                {
                    // Get the selected character based on the clicked avatar index
                    var selectedCharacter = viewModel.Characters[index];
                    selectedChar = index;

                    // Update the visual border to highlight the selected character
                    ResetBorders();
                    GetBorderForIndex(index).BorderBrush = Brushes.Goldenrod;

                    // Update the character information displayed on the screen
                    lblName.Text = selectedCharacter.Name;
                    lblLevel.Text = selectedCharacter.Level;
                    lblClass.Text = selectedCharacter.RaceInfo + " " + selectedCharacter.ClassInfo;
                }
            }
        }

        private void ResetBorders()
        {
            // Reset the border brush for all character slots to transparent
            borderChar1.BorderBrush = Brushes.Transparent;
            borderChar2.BorderBrush = Brushes.Transparent;
            borderChar3.BorderBrush = Brushes.Transparent;
            borderChar4.BorderBrush = Brushes.Transparent;
            borderChar5.BorderBrush = Brushes.Transparent;
        }

        private Border? GetBorderForIndex(int index)
        {
            // Return the correct border element based on the character index
            return index switch
            {
                0 => borderChar1,
                1 => borderChar2,
                2 => borderChar3,
                3 => borderChar4,
                4 => borderChar5,
                _ => null
            };
        }
    }
}