using MirageMUD_ClientWPF.Model.Network;
using MirageMUD_ClientWPF.Model.Types;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace MirageMUD_ClientWPF.View
{
    /// <summary>
    /// Interaction logic for NewCharView.xaml
    /// </summary>
    public partial class NewCharView : Window
    {
        public bool IsMaleSelected = true;  // Default gender selection
        private ClientTCP clientTCP;  // Instance of ClientTCP for network communication
        private int raceID;  // ID of selected race
        private int classID;  // ID of selected class

        public NewCharView()
        {
            InitializeComponent();
            clientTCP = ClientTCP.Instance;  // Initialize the network client
            SetWindowPosition();  // Restore saved window position or center

            Debug.WriteLine("CharNum: " + App.CharsViewInstance.selectedChar);

            // Example data (replace with server-loaded data)
            var races = new List<string> { "Dwarf", "Elf", "Human", "Gnome", "Halfling", "Half-Elf", "Half-Orc" };
            var classes = new List<string> { "Berserker", "Fighter", "Mage", "Cleric", "Druid", "Ranger", "Thief", "Paladin", "Pacifist" };

            // Define counters for both race and class IDs
            int raceIdCounter = 0;
            int classIdCounter = 0;

            // Populate the Race radio buttons
            PopulateRadioButtons(RaceWrapPanel, races, RaceRadioButton_Checked, ref raceIdCounter);

            // Populate the Class radio buttons
            PopulateRadioButtons(ClassWrapPanel, classes, ClassRadioButton_Checked, ref classIdCounter);

            // Select the first enabled race radio button programmatically
            SelectFirstEnabledRadioButton(RaceWrapPanel);

            // The RaceRadioButton_Checked event will automatically update the class buttons

            // Pre-roll the stats so they're not all zero
            Reroll();
        }

        // Helper function to populate the radio buttons for races/classes
        private void PopulateRadioButtons(WrapPanel panel, IEnumerable<string> items, RoutedEventHandler eventHandler, ref int idCounter)
        {
            foreach (var item in items)
            {
                var radioButton = new RadioButton
                {
                    Content = item,  // Set the text of the radio button
                    IsChecked = false,  // Initially unchecked
                    Style = (Style)FindResource("CustomRadioButtonStyle"),  // Apply custom style
                    Tag = idCounter  // Assign the current counter value as the Tag
                };

                // Increment the counter after assigning the Tag
                idCounter++;

                radioButton.Checked += eventHandler;
                panel.Children.Add(radioButton);  // Add the radio button to the panel
            }
        }

        // Select the first enabled radio button from the panel
        public void SelectFirstEnabledRadioButton(WrapPanel panel)
        {
            foreach (var child in panel.Children)
            {
                if (child is RadioButton radioButton && radioButton.IsEnabled)
                {
                    radioButton.IsChecked = true;  // Programmatically check the first enabled radio button
                    return;
                }
            }
        }

        // Dictionary to map races to their available classes
        private readonly Dictionary<string, (string[] enabledClasses, string[] disabledClasses)> raceClassMapping = new()
        {
            { "Dwarf", (new[] { "Berserker", "Fighter", "Cleric", "Thief", "Pacifist" }, new[] { "Paladin", "Mage", "Druid", "Ranger" }) },
            { "Elf", (new[] { "Fighter", "Mage", "Cleric", "Druid", "Ranger", "Pacifist" }, new[] { "Berserker", "Paladin", "Thief" }) },
            { "Human", (new[] { "Berserker", "Paladin", "Fighter", "Mage", "Cleric", "Druid", "Ranger", "Thief", "Pacifist" }, new string[] { }) },
            { "Gnome", (new[] { "Mage", "Cleric", "Thief", "Pacifist" }, new[] { "Berserker", "Paladin", "Fighter", "Druid", "Ranger" }) },
            { "Halfling", (new[] { "Paladin", "Fighter", "Cleric", "Druid", "Ranger", "Thief", "Pacifist" }, new[] { "Berserker", "Mage" }) },
            { "Half-Elf", (new[] { "Berserker", "Fighter", "Mage", "Cleric", "Druid", "Ranger", "Pacifist" }, new[] { "Paladin", "Thief" }) },
            { "Half-Orc", (new[] { "Berserker", "Fighter" }, new[] { "Pacifist", "Paladin", "Mage", "Cleric", "Druid", "Ranger", "Thief" }) }
        };

        // Handle race selection changes
        private void RaceRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            if (sender is RadioButton selected && selected.IsChecked == true)
            {
                var selectedRace = selected.Content.ToString();

                // Set race ID based on the tag value
                raceID = (int)selected.Tag;

                // Get class options for the selected race from the dictionary
                if (raceClassMapping.ContainsKey(selectedRace))
                {
                    var (enabledClasses, disabledClasses) = raceClassMapping[selectedRace];

                    // Enable or disable class options
                    SetClassEnabled(enabledClasses, true);
                    SetClassEnabled(disabledClasses, false);

                    Debug.WriteLine($"Selected Race: {selectedRace} [{raceID}]");
                }

                // Automatically select the first enabled class
                SelectFirstEnabledClass();

                // Reroll the stats
                Reroll();
            }
        }

        // Automatically select the first enabled class radio button
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

        // Handle class selection changes
        private void ClassRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            if (sender is RadioButton selected && selected.IsChecked == true)
            {
                // Set classID based on the Tag of the selected radio button
                classID = (int)selected.Tag;

                Debug.WriteLine($"Selected Class: {selected.Content} [{classID}]");
            }
        }

        // Enable or disable class radio buttons based on the class names
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

        // Allows the window to be dragged by the user
        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        // Minimize the window when the minimize button is clicked
        private void btnMinimise_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        // Close the application when the close button is clicked
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        // Navigate back to the character selection screen
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            // Save window position
            SaveWindowPosition();

            // Show the character selection screen
            App.CharsViewInstance.Show();
            this.Hide();
        }

        // Finalize the character creation and send data to the server
        private void btnFinish_Click(object sender, RoutedEventArgs e)
        {
            string charName = txtCharName.Text;  // Get character name
            int charGender = optMale.IsChecked == true ? 0 : 1;  // Gender selection

            // Check if character name is provided
            if (!string.IsNullOrWhiteSpace(charName))
            {
                clientTCP.SendNewCharacter(Globals.Player.Login, charName, charGender, raceID, classID, Globals.Player.Avatar, App.CharsViewInstance.selectedChar);  // Send character data
            }
            else
            {
                MessageBox.Show("Please enter a character name!", "Error", MessageBoxButton.OK);
            }
        }

        // Open the avatar selection dialog
        private void btnAvatar_Click(object sender, RoutedEventArgs e)
        {
            var avatarView = new AvatarView(this); // Pass 'this' as the parent
            avatarView.ShowDialog();
        }

        // Trigger reroll of stats
        private void btnReroll_Click(object sender, RoutedEventArgs e)
        {
            Reroll();
        }

        // Request reroll of stats from the server
        public void Reroll()
        {
            if (clientTCP.PlayerSocket.Connected)
            {
                clientTCP.SendRerollRequest();  // Send reroll request
            }
            else
            {
                // Handle case where not connected
            }
        }

        // Save the window's position for future sessions
        private void SaveWindowPosition()
        {
            App.LastLeft = this.Left;
            App.LastTop = this.Top;
        }

        // Set the window's position to the saved coordinates or center the window
        private void SetWindowPosition()
        {
            if (App.LastLeft == -1 || App.LastTop == -1)
            {
                this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            }
            else
            {
                this.Left = App.LastLeft;
                this.Top = App.LastTop;
            }
        }

        // Event handler for when the 'Male' option is clicked
        private void optMale_Click(object sender, RoutedEventArgs e)
        {
            // If the 'Male' option is checked, set IsMaleSelected to true
            if (optMale.IsChecked == true)
            {
                IsMaleSelected = true;
            }
        }

        // Event handler for when the 'Female' option is clicked
        private void optFemale_Click(object sender, RoutedEventArgs e)
        {
            // If the 'Female' option is checked, set IsMaleSelected to false
            if (optFemale.IsChecked == true)
            {
                IsMaleSelected = false;
            }
        }
    }
}