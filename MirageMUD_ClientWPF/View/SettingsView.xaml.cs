using MirageMUD_ClientWPF.Model.Utilities;
using System.Windows;
using System.Windows.Input;
using static MirageMUD_ClientWPF.App;

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
            SetWindowPosition();

            string configFilePath = "Data/config.json";
            // Read settings
            string languageCode = ConfigReader.GetLanguageCode(configFilePath);
            string ipAddress = ConfigReader.GetIpAddress(configFilePath);
            string port = ConfigReader.GetPort(configFilePath);
            bool musicEnabled = ConfigReader.GetMusicEnabled(configFilePath);
            bool soundEnabled = ConfigReader.GetSoundEnabled(configFilePath);

            // Define the language options with their corresponding codes
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

            // Populate the combo box with language names
            cmbLanguage.Items.Clear();  // Clear any existing items
            foreach (var option in languageOptions.Values)  // Loop through and add languages
            {
                cmbLanguage.Items.Add(option);
            }

            // Match the current language code to the combo box item and select it
            if (languageOptions.TryGetValue(languageCode, out string selectedLanguage))
            {
                cmbLanguage.SelectedItem = selectedLanguage;
            }
            else
            {
                // If no match is found, set a default (optional)
                cmbLanguage.SelectedIndex = 0;  // Default to the first item
            }

            // Update the control text to the specified language.
            //General.UpdateControlText(this);

            txtIP.Text = ipAddress;
            txtPort.Text = port;
            chkMusic.IsChecked = musicEnabled;
            chkSound.IsChecked = soundEnabled;
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
            App.LoginViewInstance.Show();

            // Optionally close the current window
            this.Hide();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            // Define a dictionary mapping combo box items to their respective language codes
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

            // Check if the selected item exists in the dictionary
            if (languageMap.TryGetValue(selectedItem, out string newLanguageCode))
            {
                string configFilePath = "Data/config.json"; // Path to the configuration file

                // Access the singleton instance of the TranslationManager
                TranslationManager translator = TranslationManager.Instance;

                // Set the language code in the TranslationManager
                TranslationManager.LanguageCode = newLanguageCode;

                // Dynamically load the corresponding language file
                translator.LoadTranslations(newLanguageCode);

                // Update the control text to reflect the new language
                //General.UpdateControlText(this);

                ConfigReader.UpdateSetting(configFilePath, "IpAddress", txtIP.Text);
                ConfigReader.UpdateSetting(configFilePath, "Port", txtPort.Text);
                ConfigReader.UpdateSetting(configFilePath, "Music", chkMusic.IsChecked ?? false);
                ConfigReader.UpdateSetting(configFilePath, "Sound", chkSound.IsChecked ?? false);
                ConfigReader.UpdateSetting(configFilePath, "LanguageCode", newLanguageCode);

                // Get the translated message for language update
                string messageKey = "messages.settings_updated";
                string translatedMessage = TranslationManager.Instance.GetTranslation(messageKey);

                // Show a message box with the translated confirmation
                MessageBox.Show(translatedMessage);
            }
            else
            {
                // If the selected language is not found in the dictionary, show an error message
                string messageKey = "messages.invalid_language";
                string translatedMessage = TranslationManager.Instance.GetTranslation(messageKey);

                // Show the error message in a message box
                MessageBox.Show(translatedMessage);
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
    }
}
