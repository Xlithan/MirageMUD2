using MirageMUD_ClientWPF.Model.Utilities;
using System.Windows;
using System.Windows.Input;

namespace MirageMUD_ClientWPF.View
{
    /// <summary>
    /// Interaction logic for SettingsView.xaml
    /// </summary>
    public partial class SettingsView : Window
    {
        public SettingsView()
        {
            InitializeComponent();
            SetWindowPosition();  // Set window position based on saved coordinates

            string configFilePath = "Data/config.json";  // Path to configuration file

            // Read settings from the configuration file using ConfigReader
            string languageCode = ConfigReader.GetLanguageCode(configFilePath);
            string ipAddress = ConfigReader.GetIpAddress(configFilePath);
            string port = ConfigReader.GetPort(configFilePath);
            bool musicEnabled = ConfigReader.GetMusicEnabled(configFilePath);
            bool soundEnabled = ConfigReader.GetSoundEnabled(configFilePath);

            // Define a dictionary for language options with their respective codes
            var languageOptions = new Dictionary<string, string>
            {
                { "cy", "Welsh (Cymraeg)" },
                { "de", "German (Deutsch)" },
                { "en-gb", "British English (English)" },
                { "en-us", "American English (English)" },
                { "es", "Spanish (Español)" },
                { "fr", "French (Français)" },
                { "it", "Italian (Italiano)" },
                { "pt", "Portuguese (Português)" },
                { "ja-ro", "Romanized Japanese (Romaji)" },
                { "pl", "Polish (Polski)" },
                { "sv", "Swedish (Svenska)" }
            };

            // Populate the language selection combo box with options
            cmbLanguage.Items.Clear();  // Clear any previous items
            foreach (var option in languageOptions.Values)  // Add language options to combo box
            {
                cmbLanguage.Items.Add(option);
            }

            // Select the current language based on the configuration file setting
            if (languageOptions.TryGetValue(languageCode, out string selectedLanguage))
            {
                cmbLanguage.SelectedItem = selectedLanguage;
            }
            else
            {
                // Default to first language if no match is found
                cmbLanguage.SelectedIndex = 0;
            }

            // Update control text to match the current language (optional feature, can be added as needed)
            //General.UpdateControlText(this);

            // Set other settings values (IP, port, music, sound)
            txtIP.Text = ipAddress;
            txtPort.Text = port;
            chkMusic.IsChecked = musicEnabled;
            chkSound.IsChecked = soundEnabled;
        }

        // Allow the user to drag the window by clicking and holding the left mouse button
        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();  // Move the window as the user drags it
            }
        }

        // Minimize the window when the minimize button is clicked
        private void btnMinimise_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;  // Minimize the window to taskbar
        }

        // Close the application when the close button is clicked
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();  // Shut down the application
        }

        // Navigate back to the login view when the back button is clicked
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            SaveWindowPosition();  // Save the current window position

            // Show the login screen and hide the settings window
            App.LoginViewInstance.Show();
            this.Hide();
        }

        // Save the user's settings (language, IP, port, music, sound) when the save button is clicked
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            // Define a dictionary mapping language names to language codes
            var languageMap = new Dictionary<string, string>
            {
                { "Welsh (Cymraeg)", "cy" },
                { "German (Deutsch)", "de" },
                { "British English (English)", "en-gb" },
                { "American English (English)", "en-us" },
                { "Spanish (Español)", "es" },
                { "French (Français)", "fr" },
                { "Italian (Italiano)", "it" },
                { "Portuguese (Português)", "pt" },
                { "Romanized Japanese (Romaji)", "ja-ro" },
                { "Polish (Polski)", "pl" },
                { "Swedish (Svenska)", "sv" }
            };

            // Get the selected language from the combo box
            string selectedItem = cmbLanguage.SelectedItem.ToString();

            // Find the corresponding language code for the selected language
            if (languageMap.TryGetValue(selectedItem, out string newLanguageCode))
            {
                string configFilePath = "Data/config.json";  // Path to the configuration file

                // Update settings in the configuration file
                ConfigReader.UpdateSetting(configFilePath, "IpAddress", txtIP.Text);
                ConfigReader.UpdateSetting(configFilePath, "Port", txtPort.Text);
                ConfigReader.UpdateSetting(configFilePath, "Music", chkMusic.IsChecked ?? false);
                ConfigReader.UpdateSetting(configFilePath, "Sound", chkSound.IsChecked ?? false);
                ConfigReader.UpdateSetting(configFilePath, "LanguageCode", newLanguageCode);

                // Access the singleton instance of the TranslationManager
                TranslationManager translator = TranslationManager.Instance;

                // Set the language code and load the corresponding translations
                TranslationManager.LanguageCode = newLanguageCode;
                translator.LoadTranslations(newLanguageCode);

                // Show a message box with the translated message indicating settings were saved
                string messageKey = "messages.settings_updated";
                string translatedMessage = TranslationManager.Instance.GetTranslation(messageKey);
                MessageBox.Show(translatedMessage);
            }
            else
            {
                // If the selected language is not found, show an error message
                string messageKey = "messages.invalid_language";
                string translatedMessage = TranslationManager.Instance.GetTranslation(messageKey);
                MessageBox.Show(translatedMessage);
            }
        }

        // Save the current position of the window to the application settings
        private void SaveWindowPosition()
        {
            App.LastLeft = this.Left;  // Save the X position
            App.LastTop = this.Top;    // Save the Y position
        }

        // Set the window's position to the saved coordinates, or center it if no saved position exists
        private void SetWindowPosition()
        {
            if (!double.IsNaN(App.LastLeft) && !double.IsNaN(App.LastTop))
            {
                this.Left = App.LastLeft;  // Set the X position
                this.Top = App.LastTop;    // Set the Y position
            }
            else
            {
                // Default to center screen if no position is saved
                this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            }
        }
    }
}