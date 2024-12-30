using MirageMUD_ClientWPF.Model.Network;
using MirageMUD_ClientWPF.ViewModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using static MirageMUD_ClientWPF.App;

namespace MirageMUD_ClientWPF.View
{
    /// <summary>
    /// Interaction logic for NewCharView.xaml
    /// </summary>
    public partial class NewCharView : Window
    {
        public bool IsMaleSelected = true;
        ClientTCP clientTCP;  // Instance of ClientTCP for network communication
        public NewCharView()
        {
            InitializeComponent();
            clientTCP = ClientTCP.Instance;
            SetWindowPosition();

            // Example data (replace with server-loaded data)
            var races = new List<string> { "Dwarf", "Elf", "Human", "Gnome", "Halfling", "Half-Elf", "Half-Orc" };
            var classes = new List<string> { "Berserker", "Fighter", "Mage", "Cleric", "Druid", "Ranger", "Thief", "Paladin", "Pacifist" };

            PopulateRadioButtons(RaceWrapPanel, races, RaceRadioButton_Checked);
            PopulateRadioButtons(ClassWrapPanel, classes, ClassRadioButton_Checked);

            // Select the first race radio button programmatically
            SelectFirstEnabledRadioButton(RaceWrapPanel);

            // The RaceRadioButton_Checked event will automatically update the class buttons
        }
        private void PopulateRadioButtons(WrapPanel panel, IEnumerable<string> items, RoutedEventHandler eventHandler)
        {
            foreach (var item in items)
            {
                var radioButton = new RadioButton
                {
                    Content = item, // Set the text of the radio button
                    IsChecked = false, // Initially unchecked
                    Style = (Style)FindResource("CustomRadioButtonStyle") // Apply the custom style
                };
                radioButton.Checked += eventHandler;
                panel.Children.Add(radioButton);
            }
        }
        private void SelectFirstEnabledRadioButton(WrapPanel panel)
        {
            foreach (var child in panel.Children)
            {
                if (child is RadioButton radioButton && radioButton.IsEnabled)
                {
                    // Programmatically check the first enabled radio button
                    radioButton.IsChecked = true;
                    return;
                }
            }
        }
        private void RaceRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            if (sender is RadioButton selected && selected.IsChecked == true)
            {
                var selectedRace = selected.Content.ToString();
                Console.WriteLine($"Selected Race: {selectedRace}");

                // Example logic: Enable or disable class options
                if (selectedRace == "Dwarf")
                {
                    SetClassEnabled(new[] { "Berserker", "Fighter", "Cleric", "Thief", "Pacifist" }, true); // Enable certain classes
                    SetClassEnabled(new[] { "Paladin", "Mage", "Druid", "Ranger" }, false); // Disable others
                }
                else if (selectedRace == "Elf")
                {
                    SetClassEnabled(new[] { "Fighter", "Mage", "Cleric", "Druid", "Ranger", "Pacifist" }, true);
                    SetClassEnabled(new[] { "Berserker", "Paladin", "Thief" }, false);
                }
                else if (selectedRace == "Human")
                {
                    SetClassEnabled(new[] { "Berserker", "Paladin", "Fighter", "Mage", "Cleric", "Druid", "Ranger", "Thief", "Pacifist" }, true);
                    SetClassEnabled(new[] { "" }, false);
                }
                else if (selectedRace == "Gnome")
                {
                    SetClassEnabled(new[] { "Mage", "Cleric", "Thief", "Pacifist" }, true);
                    SetClassEnabled(new[] { "Berserker", "Paladin", "Fighter", "Druid", "Ranger" }, false);
                }
                else if (selectedRace == "Halfling")
                {
                    SetClassEnabled(new[] { "Paladin", "Fighter", "Cleric", "Druid", "Ranger", "Thief", "Pacifist" }, true);
                    SetClassEnabled(new[] { "Berserker", "Mage" }, false);
                }
                else if (selectedRace == "Half-Elf")
                {
                    SetClassEnabled(new[] { "Berserker", "Fighter", "Mage", "Cleric", "Druid", "Ranger", "Pacifist" }, true);
                    SetClassEnabled(new[] { "Paladin", "Thief" }, false);
                }
                else if (selectedRace == "Half-Orc")
                {
                    SetClassEnabled(new[] { "Berserker", "Fighter" }, true);
                    SetClassEnabled(new[] { "Pacifist", "Paladin", "Mage", "Cleric", "Druid", "Ranger", "Thief" }, false);
                }

                // Automatically select the first enabled class
                SelectFirstEnabledClass();
            }
        }
        private void SelectFirstEnabledClass()
        {
            foreach (var child in ClassWrapPanel.Children)
            {
                if (child is RadioButton radioButton && radioButton.IsEnabled)
                {
                    radioButton.IsChecked = true;
                    return; // Stop after selecting the first enabled button
                }
            }
        }
        private void ClassRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            if (sender is RadioButton selected && selected.IsChecked == true)
            {
                Console.WriteLine($"Selected Class: {selected.Content}");
            }
        }

        private void SetClassEnabled(IEnumerable<string> classNames, bool enabled)
        {
            foreach (var child in ClassWrapPanel.Children)
            {
                if (child is RadioButton radioButton && classNames.Contains(radioButton.Content.ToString()))
                {
                    radioButton.IsEnabled = enabled;
                }
            }
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

            // Create an instance of the new window
            App.CharsViewInstance.Show();

            // Optionally close the current window
            this.Hide();
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnFinish_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnAvatar_Click(object sender, RoutedEventArgs e)
        {
            var avatarView = new AvatarView(this); // Pass 'this' as the parent
            avatarView.ShowDialog();
        }

        private void btnReroll_Click(object sender, RoutedEventArgs e)
        {
            if (clientTCP.PlayerSocket.Connected)
            {
                clientTCP.SendRerollRequest();  // Send login data to server
            }
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

        private void optMale_Click(object sender, RoutedEventArgs e)
        {
            if(optMale.IsChecked == true)
            {
                IsMaleSelected = true;
            }
        }

        private void optFemale_Click(object sender, RoutedEventArgs e)
        {
            if (optFemale.IsChecked == true)
            {
                IsMaleSelected = false;
            }
        }
    }
}
