using MirageMUD_ClientWPF.Model.Network;
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
        public bool IsMaleSelected = true;
        ClientTCP clientTCP;  // Instance of ClientTCP for network communication
        int raceID; // ID of selected race
        int classID; // ID of selected class
        public NewCharView()
        {
            InitializeComponent();
            clientTCP = ClientTCP.Instance;
            SetWindowPosition();

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

            // Select the first race radio button programmatically
            SelectFirstEnabledRadioButton(RaceWrapPanel);

            // The RaceRadioButton_Checked event will automatically update the class buttons

            // Pre-roll the stats so they're not all zero
            Reroll();
        }
        private void PopulateRadioButtons(WrapPanel panel, IEnumerable<string> items, RoutedEventHandler eventHandler, ref int idCounter)
        {
            foreach (var item in items)
            {
                var radioButton = new RadioButton
                {
                    Content = item, // Set the text of the radio button
                    IsChecked = false, // Initially unchecked
                    Style = (Style)FindResource("CustomRadioButtonStyle"), // Apply the custom style
                    Tag = idCounter // Assign the current counter value as the Tag
                };

                // Increment the counter after assigning the Tag
                idCounter++;

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
        // Dictionary to hold the class options for each race
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
        private void RaceRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            if (sender is RadioButton selected && selected.IsChecked == true)
            {
                var selectedRace = selected.Content.ToString();

                // Set race ID based on the tag value (incremented ID)
                raceID = (int)selected.Tag;

                // Get the class options for the selected race from the dictionary
                if (raceClassMapping.ContainsKey(selectedRace))
                {
                    var (enabledClasses, disabledClasses) = raceClassMapping[selectedRace];

                    // Enable or disable the class options
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
                // Set classID dynamically based on the Tag of the selected radio button
                classID = (int)selected.Tag;

                Debug.WriteLine($"Selected Class: {selected.Content} [{classID}]");
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
            Reroll();
        }
        private void Reroll()
        {
            if (clientTCP.PlayerSocket.Connected)
            {
                clientTCP.SendRerollRequest();  // Send login data to server
            }
            else
            {
                // Not connected so send alert message
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
