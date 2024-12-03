using MirageMUD_Client.Source.General;  // Imports general utilities
using MirageMUD_Client.Source.Network;  // Imports networking utilities
using MirageMUD_Client.Source.Utilities;  // Imports additional utilities
using System.Diagnostics;
using System.Text;  // Imports text-related functionality

namespace MirageMUD_Client
{
    // Main form class for the menu screen
    public partial class frmMenu : Form
    {
        ClientTCP clientTCP;  // Instance of ClientTCP for network communication

        // Enum for different menu states
        public enum MenuState : byte
        {
            NewAccount = 0,  // New account creation menu
            DelAccount = 1,  // Account deletion menu
            Login = 2,  // Login menu
            GetChars = 3,  // Retrieve characters menu
            NewChar = 4,  // New character creation menu
            AddChar = 5,  // Add character to account
            DelChar = 6,  // Delete character menu
            UseChar = 7,  // Use existing character
            Init = 8  // Initial state of the menu
        }

        // Constructor to initialize the form and its components
        public frmMenu()
        {
            InitializeComponent();  // Initialize form components

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
            cmbOptLang.Items.Clear();  // Clear any existing items
            foreach (var option in languageOptions.Values)  // Loop through and add languages
            {
                cmbOptLang.Items.Add(option);
            }

            // Read the current language code from config.json
            string currentLanguageCode = ConfigReader.GetLanguageCode("Data/config.json");

            // Match the current language code to the combo box item and select it
            if (languageOptions.TryGetValue(currentLanguageCode, out string selectedLanguage))
            {
                cmbOptLang.SelectedItem = selectedLanguage;
            }
            else
            {
                // If no match is found, set a default (optional)
                cmbOptLang.SelectedIndex = 0;  // Default to the first item
            }

            // Update the control text to the specified language.
            General.UpdateControlText(this);

            // Create a new instance of ClientTCP for new account procedure
            clientTCP = new ClientTCP();
            clientTCP.ConnectToServer();  // Connect to the server
        }

        // Event handler for when the form is loaded
        private void frmMenu_Load(object sender, EventArgs e)
        {
            // Set all panel visibility to false initially
            pnlCharacters.Visible = false;
            pnlCredits.Visible = false;
            pnlGameOptions.Visible = false;
            pnlIPConfig.Visible = false;
            pnlLogin.Visible = false;
            pnlNewAccount.Visible = false;
            pnlExit.Visible = false;

            // Set navigation panel height and position to match home button
            pnlNav.Height = btnHome.Height;
            pnlNav.Top = btnHome.Top;
            pnlNav.Left = btnHome.Left;
            btnHome.BackColor = Color.FromArgb(95, 95, 95);  // Highlight the home button

            // Simulate click on home button
            btnHome.PerformClick();

            // Load and set the background image (GIF) for the menu
            string gifPath = Path.Combine(Application.StartupPath, "gfx", "ui", "menuanim.gif");
            this.BackgroundImage = System.Drawing.Image.FromFile(gifPath);  // Set background image
            picBackground.Image = System.Drawing.Image.FromFile(gifPath);  // Set picture box image
        }

        // Event handler for when the "Cancel" label in characters panel is clicked
        private void lblCharsCancel_Click(object sender, EventArgs e)
        {
            // No implementation provided
        }

        // Event handler for when the "Connect" label in login panel is clicked
        private void lblLoginConnect_Click(object sender, EventArgs e)
        {
            // No implementation provided
        }

        // Event handler for when the "New Account" button is clicked
        private void btnNewAcc_Click(object sender, EventArgs e)
        {
            HidePanels();  // Hide all panels
            pnlNewAccount.Visible = true;  // Show new account panel

            // Update navigation panel height and position to match "New Account" button
            pnlNav.Height = btnNewAcc.Height;
            pnlNav.Top = btnNewAcc.Top;
            pnlNav.Left = btnNewAcc.Left;
            btnNewAcc.BackColor = Color.FromArgb(95, 95, 95);  // Highlight new account button

            // Set home button back color due to bug
            btnHome.BackColor = Color.FromArgb(45, 45, 45);  // Revert home button color
        }

        // Event handler for when the "Home" button is clicked
        private void btnHome_Click(object sender, EventArgs e)
        {
            HidePanels();  // Hide all panels
            // Set the background image from the resources
            //this.BackgroundImage = Properties.Resources.menuback;  // Set default background image

            // Update navigation panel height and position to match home button
            pnlNav.Height = btnHome.Height;
            pnlNav.Top = btnHome.Top;
            pnlNav.Left = btnHome.Left;
            btnHome.BackColor = Color.FromArgb(95, 95, 95);  // Highlight home button
        }

        // Event handler for when the "Login" button is clicked
        private void btnLogin_Click(object sender, EventArgs e)
        {
            HidePanels();  // Hide all panels
            pnlLogin.Visible = true;  // Show login panel

            // Update navigation panel height and position to match "Login" button
            pnlNav.Height = btnLogin.Height;
            pnlNav.Top = btnLogin.Top;
            pnlNav.Left = btnLogin.Left;
            btnLogin.BackColor = Color.FromArgb(95, 95, 95);  // Highlight login button

            // Set home button back color due to bug
            btnHome.BackColor = Color.FromArgb(45, 45, 45);  // Revert home button color
        }

        // Event handler for when the "IP Configuration" button is clicked
        private void btnIPConfig_Click(object sender, EventArgs e)
        {
            HidePanels();  // Hide all panels
            pnlIPConfig.Visible = true;  // Show IP configuration panel

            // Update navigation panel height and position to match "IP Config" button
            pnlNav.Height = btnIPConfig.Height;
            pnlNav.Top = btnIPConfig.Top;
            pnlNav.Left = btnIPConfig.Left;
            btnIPConfig.BackColor = Color.FromArgb(95, 95, 95);  // Highlight IP config button

            // Set home button back color due to bug
            btnHome.BackColor = Color.FromArgb(45, 45, 45);  // Revert home button color
        }

        // Event handler for when the "Game Options" button is clicked
        private void btnGameOptions_Click(object sender, EventArgs e)
        {
            HidePanels();  // Hide all panels
            pnlGameOptions.Visible = true;  // Show game options panel

            // Update navigation panel height and position to match "Game Options" button
            pnlNav.Height = btnGameOptions.Height;
            pnlNav.Top = btnGameOptions.Top;
            pnlNav.Left = btnGameOptions.Left;
            btnGameOptions.BackColor = Color.FromArgb(95, 95, 95);  // Highlight game options button

            // Set home button back color due to bug
            btnHome.BackColor = Color.FromArgb(45, 45, 45);  // Revert home button color
        }

        // Event handler for when the "Credits" button is clicked
        private void btnCredits_Click(object sender, EventArgs e)
        {
            HidePanels();  // Hide all panels
            pnlCredits.Visible = true;  // Show credits panel

            // Update navigation panel height and position to match "Credits" button
            pnlNav.Height = btnCredits.Height;
            pnlNav.Top = btnCredits.Top;
            pnlNav.Left = btnCredits.Left;
            btnCredits.BackColor = Color.FromArgb(95, 95, 95);  // Highlight credits button

            // Set home button back color due to bug
            btnHome.BackColor = Color.FromArgb(45, 45, 45);  // Revert home button color
        }

        // Event handler for when the "Exit" button is clicked
        private void btnExit_Click(object sender, EventArgs e)
        {
            HidePanels();  // Hide all panels
            pnlExit.Visible = true;  // Show exit confirmation panel

            // Update navigation panel height and position to match "Exit" button
            pnlNav.Height = btnExit.Height;
            pnlNav.Top = btnExit.Top;
            pnlNav.Left = btnExit.Left;
            btnExit.BackColor = Color.FromArgb(95, 95, 95);  // Highlight exit button

            // Set home button back color due to bug
            btnHome.BackColor = Color.FromArgb(45, 45, 45);  // Revert home button color
        }

        // Event handler for when the mouse leaves the "Home" button
        private void btnHome_Leave(object sender, EventArgs e)
        {
            btnHome.BackColor = Color.FromArgb(45, 45, 45);  // Revert home button color
        }

        // Event handlers for when the mouse leaves each button (similar logic for all)
        private void btnNewAcc_Leave(object sender, EventArgs e)
        {
            btnNewAcc.BackColor = Color.FromArgb(45, 45, 45);  // Revert new account button color
        }

        private void btnLogin_Leave(object sender, EventArgs e)
        {
            btnLogin.BackColor = Color.FromArgb(45, 45, 45);  // Revert login button color
        }

        private void btnIPConfig_Leave(object sender, EventArgs e)
        {
            btnIPConfig.BackColor = Color.FromArgb(45, 45, 45);  // Revert IP config button color
        }

        private void btnGameOptions_Leave(object sender, EventArgs e)
        {
            btnGameOptions.BackColor = Color.FromArgb(45, 45, 45);  // Revert game options button color
        }

        private void btnCredits_Leave(object sender, EventArgs e)
        {
            btnCredits.BackColor = Color.FromArgb(45, 45, 45);  // Revert credits button color
        }

        private void btnExit_Leave(object sender, EventArgs e)
        {
            btnExit.BackColor = Color.FromArgb(45, 45, 45);  // Revert exit button color
        }

        // Reset menu back to home screen
        public void ResetMenu()
        {
            HidePanels();  // Hide all panels
            // Set the background image from the resources
            this.BackgroundImage = Properties.Resources.menuback;  // Set default background image

            // Update navigation panel height and position to match home button
            pnlNav.Height = btnHome.Height;
            pnlNav.Top = btnHome.Top;
            pnlNav.Left = btnHome.Left;
            btnHome.BackColor = Color.FromArgb(95, 95, 95);  // Highlight home button
        }

        // Method to hide all panels and reset the background image
        public void HidePanels()
        {
            this.BackgroundImage = null;  // Remove background image
            pnlCharacters.Visible = false;  // Hide characters panel
            pnlCredits.Visible = false;  // Hide credits panel
            pnlGameOptions.Visible = false;  // Hide game options panel
            pnlIPConfig.Visible = false;  // Hide IP config panel
            pnlLogin.Visible = false;  // Hide login panel
            pnlNewAccount.Visible = false;  // Hide new account panel
            pnlExit.Visible = false;  // Hide exit panel
        }

        // Event handler for when the "Exit" confirmation button is clicked
        private void btnExitConfirm_Click(object sender, EventArgs e)
        {
            Application.Exit();  // Close the application
        }

        // Event handler for when the "Use Character" label is clicked
        private void lblUseChar_Click(object sender, EventArgs e)
        {
            HidePanels();  // Hide all panels

            this.Hide();  // Hide the current form
            frmGame gameForm = new frmGame();  // Create a new game form
            gameForm.Closed += (s, args) => this.Close();  // Close the current form when the game form closes
            gameForm.Show();  // Show the game form
        }

        // Event handler for when the "Login Connect" button is clicked
        private void btnLoginConnect_Click(object sender, EventArgs e)
        {
            string loginName = txtLoginName.Text;  // Get the login name from the text box
            string loginPass = txtLoginPass.Text;  // Get the login password from the text box

            if (!string.IsNullOrWhiteSpace(loginName) && !string.IsNullOrWhiteSpace(loginPass))
            {
                // Run login procedure
                MenuStateHandler(MenuState.Login);  // Change menu state to login
            }
            else
            {
                // Show error messages based on missing fields
                if (string.IsNullOrWhiteSpace(loginName) && string.IsNullOrWhiteSpace(loginPass))
                {
                    string translatedMessage = TranslationManager.Instance.GetTranslation("messages.login_prompt");
                    MessageBox.Show(translatedMessage, "Error", MessageBoxButtons.OK);
                }
                else if (string.IsNullOrWhiteSpace(loginName))
                {
                    string translatedMessage = TranslationManager.Instance.GetTranslation("messages.login_name_prompt");
                    MessageBox.Show(translatedMessage, "Error", MessageBoxButtons.OK);
                }
                else if (string.IsNullOrWhiteSpace(loginPass))
                {
                    string translatedMessage = TranslationManager.Instance.GetTranslation("messages.password_prompt");
                    MessageBox.Show(translatedMessage, "Error", MessageBoxButtons.OK);
                }
            }
        }

        // Event handler for when the "Cancel" button in characters panel is clicked
        private void btnCharsCancel_Click(object sender, EventArgs e)
        {
            pnlCharacters.Visible = false;  // Hide characters panel
            pnlLogin.Visible = true;  // Show login panel
        }

        // Event handler for when the "New Account Connect" button is clicked
        private void btnNewAccConnect_Click(object sender, EventArgs e)
        {
            string name = txtNewAccName.Text;  // Get the new account name from the text box
            string pass = txtNewAccPass.Text;  // Get the new account password from the text box
            string confirmPass = txtConfirmPass.Text;  // Get the password confirmation from the text box

            // Check if all fields are filled
            if (!string.IsNullOrWhiteSpace(name) && !string.IsNullOrWhiteSpace(pass) && !string.IsNullOrWhiteSpace(confirmPass))
            {
                // Ensure passwords match
                if (string.Equals(pass, confirmPass))
                {
                    // Run new account procedure if passwords match
                    MenuStateHandler(MenuState.NewAccount);
                }
                else
                {
                    // Show error if passwords do not match
                    MessageBox.Show("Passwords do not match!", "Error", MessageBoxButtons.OK);
                }
            }
            else
            {
                // Show specific error messages for missing fields
                if (string.IsNullOrWhiteSpace(name))
                {
                    MessageBox.Show("Please enter a login name!", "Error", MessageBoxButtons.OK);
                }
                else if (string.IsNullOrWhiteSpace(pass))
                {
                    MessageBox.Show("Please enter a password!", "Error", MessageBoxButtons.OK);
                }
                else if (string.IsNullOrWhiteSpace(confirmPass))
                {
                    MessageBox.Show("Please confirm your password!", "Error", MessageBoxButtons.OK);
                }
                else
                {
                    MessageBox.Show("Please enter a login name and password!", "Error", MessageBoxButtons.OK);
                }
            }
        }

        // Asynchronous method to handle menu state changes, like account creation or login
        public async Task MenuStateHandler(MenuState state)
        {
            switch (state)
            {
                case MenuState.NewAccount:
                    if (clientTCP.PlayerSocket.Connected)
                    {
                        btnNewAccConnect.Text = "Connecting...";  // Update button text to indicate connection
                        clientTCP.SendNewAccount(txtNewAccName.Text, txtNewAccPass.Text);  // Send new account data to server
                    }
                    break;

                case MenuState.DelAccount:
                    // Add logic here if needed for deleting account
                    break;

                case MenuState.Login:
                    if (clientTCP.PlayerSocket.Connected)
                    {
                        btnLoginConnect.Text = "Connecting...";  // Update button text to indicate connection
                        clientTCP.SendLogin(txtLoginName.Text, txtLoginPass.Text);  // Send login data to server
                    }
                    break;

                /*case MenuState.GetChars:
                    SetStatus("Connected, retrieving character list...");
                    SendGetClasses();
                    break;

                case MenuState.NewChar:
                    SetStatus("Connected, getting available classes...");
                    SendGetClasses();
                    break;

                case MenuState.AddChar:

                    if (ConnectToServer())
                    {
                        SetStatus("Connected, sending character addition data...");
                        int gender = optMale.Checked ? 0 : 1;

                        SendAddChar(
                            txtNewCharName.Text,
                            gender,
                            cmbClass.SelectedIndex,
                            lstChars.SelectedIndex + 1,
                            NewCharAvatar
                        );
                    }
                    break;

                case MenuState.DelChar:
                    if (ConnectToServer())
                    {
                        SetStatus("Connected, sending character deletion request...");
                        SendDelChar(lstChars.SelectedIndex + 1);
                        mnuChars.Visible = false;
                    }
                    break;

                case MenuState.UseChar:
                    this.Visible = false;

                    if (ConnectToServer())
                    {
                        SetStatus("Connected, sending character data...");
                        SendUseChar(lstChars.SelectedIndex + 1);
                        this.Dispose(); // Equivalent to Unload in VB6
                    }
                    break;
                */
                case MenuState.Init:
                    // Add logic here for initialization, if required
                    break;

                default:
                    MessageBox.Show("Unknown menu state!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }

            // Handle the case when the server is not connected
            /*if (!IsConnected())
            {
                this.Visible = true;
                frmSendGetData.Visible = false;
                MessageBox.Show(
                    $"Sorry, the server seems to be down. Please try to reconnect in a few minutes or visit {GAME_WEBSITE}",
                    GAME_NAME,
                    MessageBoxButtons.OK
                );
            }*/
        }

        // Event handler for the "Save Options" button click
        private void btnOptionsSave_Click(object sender, EventArgs e)
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
            string selectedItem = cmbOptLang.SelectedItem.ToString();

            // Check if the selected item exists in the dictionary
            if (languageMap.TryGetValue(selectedItem, out string newLanguageCode))
            {
                string configFilePath = "Data/config.json"; // Path to the configuration file

                // Update the language code in the config file
                ConfigReader.UpdateLanguageCode(configFilePath, newLanguageCode);

                // Access the singleton instance of the TranslationManager
                TranslationManager translator = TranslationManager.Instance;

                // Set the language code in the TranslationManager
                TranslationManager.LanguageCode = newLanguageCode;

                // Dynamically load the corresponding language file
                translator.LoadTranslations(newLanguageCode);

                // Update the control text to reflect the new language
                General.UpdateControlText(this);

                // Get the translated message for language update
                string messageKey = "messages.language_updated";
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
    }
}
