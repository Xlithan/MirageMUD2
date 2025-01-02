using MirageMUD_ClientWPF.Model.Network;
using MirageMUD_ClientWPF.Model.Types;
using MirageMUD_ClientWPF.ViewModel;
using System.Windows;
using System.IO;
using System.Windows.Media.Imaging;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Input;

namespace MirageMUD_ClientWPF.View
{
    /// <summary>
    /// Interaction logic for CharactersView.xaml
    /// </summary>
    public partial class CharactersView : Window
    {
        public int selectedChar { get; set; }
        ClientTCP clientTCP;  // Instance of ClientTCP for network communication
        public CharactersView()
        {
            InitializeComponent();
            SetWindowPosition();
            DataContext = new CharacterViewModel();
            clientTCP = ClientTCP.Instance;
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

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            // Save window position
            SaveWindowPosition();

            // Send logout
            if (clientTCP.PlayerSocket.Connected)
            {
                clientTCP.SendLogout();  // Send login data to server
            }
            App.LoginViewInstance.Show();

            // Optionally close the current window
            this.Hide();
        }

        private void PlayGame()
        {
            // Create an instance of the new window
            App.GameViewInstance.Show();

            // Optionally close the current window
            this.Close();
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

        private void btnPlay_Click(object sender, RoutedEventArgs e)
        {
            if(selectedChar >= 0 && !lblName.Text.Equals("Empty Slot") && !lblName.Text.Equals(string.Empty))
            {
                PlayGame();
            }
            else
            {
                MessageBox.Show("You must select a character.", "Alert", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            
        }
        private void btnNewChar_Click(object sender, RoutedEventArgs e)
        {
            if (selectedChar >= 0 && lblName.Text.Equals("Empty Slot") && !lblName.Text.Equals(string.Empty))
            {
                // Save window position
                SaveWindowPosition();

                // Create an instance of the new window
                App.NewCharViewInstance.Show();

                // Reset the new char window
                App.NewCharViewInstance.txtCharName.Text = string.Empty;
                App.NewCharViewInstance.SelectFirstEnabledRadioButton(App.NewCharViewInstance.RaceWrapPanel);
                App.NewCharViewInstance.optMale.IsChecked = true;
                App.NewCharViewInstance.IsMaleSelected = true;
                ResetAvatar();

                // Pre-roll the stats so they're not all zero
                App.NewCharViewInstance.Reroll();

                // Optionally close the current window
                this.Hide();
            }
            else
            {
                MessageBox.Show("You must select an empty slot.", "Alert", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }
        private void ResetAvatar()
        {
            // Set the default avatar path based on gender
            string defaultAvatarPath = @"gfx\avatars\Players\Male\1.bmp";

            // Update the picAvatar Source in NewCharView
            try
            {
                var bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(Path.GetFullPath(defaultAvatarPath), UriKind.Absolute);
                bitmap.CacheOption = BitmapCacheOption.OnLoad;
                bitmap.EndInit();

                App.NewCharViewInstance.picAvatar.Source = bitmap;
                Globals.Player.Avatar = 1; // Assuming 1 corresponds to the default avatar
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error resetting avatar: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Avatar_Click(object sender, MouseButtonEventArgs e)
        {
            if (sender is Image clickedImage && clickedImage.Tag is string tagStr && int.TryParse(tagStr, out int index))
            {
                if (DataContext is CharacterViewModel viewModel && index < viewModel.Characters.Count)
                {
                    // Get the selected character
                    var selectedCharacter = viewModel.Characters[index];
                    selectedChar = index;

                    // Update borders
                    ResetBorders();
                    GetBorderForIndex(index).BorderBrush = Brushes.Goldenrod;

                    // Update text blocks
                    lblName.Text = selectedCharacter.Name;
                    lblLevel.Text = selectedCharacter.Level;
                    lblClass.Text = selectedCharacter.RaceInfo + " " + selectedCharacter.ClassInfo;
                }
            }
        }
        private void ResetBorders()
        {
            borderChar1.BorderBrush = Brushes.Transparent;
            borderChar2.BorderBrush = Brushes.Transparent;
            borderChar3.BorderBrush = Brushes.Transparent;
            borderChar4.BorderBrush = Brushes.Transparent;
            borderChar5.BorderBrush = Brushes.Transparent;
        }

        private Border? GetBorderForIndex(int index)
        {
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
