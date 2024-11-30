using MirageMUD_Client.Source.General;
using MirageMUD_Client.Source.Network;
using MirageMUD_Client.Source.Utilities;
using System.Net.WebSockets;
using System.Text;

namespace MirageMUD_Client
{
    public partial class frmMenu : Form
    {
        ClientTCP clientTCP;
        ClientWebSock clientWebSocket;
        ClientWebSocket webSocket;
        CHandleData cHandleData;
        public enum MenuState : byte
        {
            NewAccount = 0,
            DelAccount = 1,
            Login = 2,
            GetChars = 3,
            NewChar = 4,
            AddChar = 5,
            DelChar = 6,
            UseChar = 7,
            Init = 8
        }

        public frmMenu()
        {
            InitializeComponent();

            // Initialize the WebSocket client
            clientWebSocket = new ClientWebSock();
            webSocket = new ClientWebSocket();

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
            cmbOptLang.Items.Clear();
            foreach (var option in languageOptions.Values)
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
                cmbOptLang.SelectedIndex = 0; // Default to the first item
            }

            // Update the control text to the specified language.
            General.UpdateControlText(this);

            cHandleData = new CHandleData();
            cHandleData.InitialiseMessages();
        }

        private void frmMenu_Load(object sender, EventArgs e)
        {
            pnlCharacters.Visible = false;
            pnlCredits.Visible = false;
            pnlGameOptions.Visible = false;
            pnlIPConfig.Visible = false;
            pnlLogin.Visible = false;
            pnlNewAccount.Visible = false;
            pnlExit.Visible = false;

            pnlNav.Height = btnHome.Height;
            pnlNav.Top = btnHome.Top;
            pnlNav.Left = btnHome.Left;
            btnHome.BackColor = Color.FromArgb(95, 95, 95);

            //Button btnHome = new Button();
            btnHome.PerformClick();

            // Load GIF into picture box
            string gifPath = Path.Combine(Application.StartupPath, "gfx", "ui", "menuanim.gif");
            this.BackgroundImage = System.Drawing.Image.FromFile(gifPath);
            picBackground.Image = System.Drawing.Image.FromFile(gifPath);
        }

        private void lblCharsCancel_Click(object sender, EventArgs e)
        {

        }

        private void lblLoginConnect_Click(object sender, EventArgs e)
        {

        }

        private void btnNewAcc_Click(object sender, EventArgs e)
        {
            HidePanels();
            pnlNewAccount.Visible = true;

            pnlNav.Height = btnNewAcc.Height;
            pnlNav.Top = btnNewAcc.Top;
            pnlNav.Left = btnNewAcc.Left;
            btnNewAcc.BackColor = Color.FromArgb(95, 95, 95);

            // Set home button back color due to bug
            btnHome.BackColor = Color.FromArgb(45, 45, 45);

        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            HidePanels();
            // Set the background image from the resources
            this.BackgroundImage = Properties.Resources.menuback;

            pnlNav.Height = btnHome.Height;
            pnlNav.Top = btnHome.Top;
            pnlNav.Left = btnHome.Left;
            btnHome.BackColor = Color.FromArgb(95, 95, 95);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            HidePanels();
            pnlLogin.Visible = true;

            pnlNav.Height = btnLogin.Height;
            pnlNav.Top = btnLogin.Top;
            pnlNav.Left = btnLogin.Left;
            btnLogin.BackColor = Color.FromArgb(95, 95, 95);

            // Set home button back color due to bug
            btnHome.BackColor = Color.FromArgb(45, 45, 45);
        }

        private void btnIPConfig_Click(object sender, EventArgs e)
        {
            HidePanels();
            pnlIPConfig.Visible = true;

            pnlNav.Height = btnIPConfig.Height;
            pnlNav.Top = btnIPConfig.Top;
            pnlNav.Left = btnIPConfig.Left;
            btnIPConfig.BackColor = Color.FromArgb(95, 95, 95);

            // Set home button back color due to bug
            btnHome.BackColor = Color.FromArgb(45, 45, 45);
        }

        private void btnGameOptions_Click(object sender, EventArgs e)
        {
            HidePanels();
            pnlGameOptions.Visible = true;

            pnlNav.Height = btnGameOptions.Height;
            pnlNav.Top = btnGameOptions.Top;
            pnlNav.Left = btnGameOptions.Left;
            btnGameOptions.BackColor = Color.FromArgb(95, 95, 95);

            // Set home button back color due to bug
            btnHome.BackColor = Color.FromArgb(45, 45, 45);
        }

        private void btnCredits_Click(object sender, EventArgs e)
        {
            HidePanels();
            pnlCredits.Visible = true;

            pnlNav.Height = btnCredits.Height;
            pnlNav.Top = btnCredits.Top;
            pnlNav.Left = btnCredits.Left;
            btnCredits.BackColor = Color.FromArgb(95, 95, 95);

            // Set home button back color due to bug
            btnHome.BackColor = Color.FromArgb(45, 45, 45);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            HidePanels();
            pnlExit.Visible = true;

            pnlNav.Height = btnExit.Height;
            pnlNav.Top = btnExit.Top;
            pnlNav.Left = btnExit.Left;
            btnExit.BackColor = Color.FromArgb(95, 95, 95);

            // Set home button back color due to bug
            btnHome.BackColor = Color.FromArgb(45, 45, 45);
        }

        private void btnHome_Leave(object sender, EventArgs e)
        {
            btnHome.BackColor = Color.FromArgb(45, 45, 45);
        }

        private void btnNewAcc_Leave(object sender, EventArgs e)
        {
            btnNewAcc.BackColor = Color.FromArgb(45, 45, 45);
        }

        private void btnLogin_Leave(object sender, EventArgs e)
        {
            btnLogin.BackColor = Color.FromArgb(45, 45, 45);
        }

        private void btnIPConfig_Leave(object sender, EventArgs e)
        {
            btnIPConfig.BackColor = Color.FromArgb(45, 45, 45);
        }

        private void btnGameOptions_Leave(object sender, EventArgs e)
        {
            btnGameOptions.BackColor = Color.FromArgb(45, 45, 45);
        }

        private void btnCredits_Leave(object sender, EventArgs e)
        {
            btnCredits.BackColor = Color.FromArgb(45, 45, 45);
        }

        private void btnExit_Leave(object sender, EventArgs e)
        {
            btnExit.BackColor = Color.FromArgb(45, 45, 45);
        }

        private void HidePanels()
        {
            // Remove the background image:
            this.BackgroundImage = null;
            pnlCharacters.Visible = false;
            pnlCredits.Visible = false;
            pnlGameOptions.Visible = false;
            pnlIPConfig.Visible = false;
            pnlLogin.Visible = false;
            pnlNewAccount.Visible = false;
            pnlExit.Visible = false;
        }

        private void btnExitConfirm_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void lblUseChar_Click(object sender, EventArgs e)
        {
            HidePanels();

            this.Hide();
            frmGame gameForm = new frmGame();
            gameForm.Closed += (s, args) => this.Close();
            gameForm.Show();
        }

        private void btnLoginConnect_Click(object sender, EventArgs e)
        {
            /*pnlLogin.Visible = false;
            pnlCharacters.Visible = true;

            lblAccountName.Text = txtLoginName.Text;*/
            string loginName = txtLoginName.Text;
            string loginPass = txtLoginPass.Text;

            if (!string.IsNullOrWhiteSpace(loginName) && !string.IsNullOrWhiteSpace(loginPass))
            {
                // Run login procedure
                MenuStateHandler(MenuState.Login);
            }
            else
            {
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

        private void btnCharsCancel_Click(object sender, EventArgs e)
        {
            pnlCharacters.Visible = false;
            pnlLogin.Visible = true;
        }

        private void btnNewAccConnect_Click(object sender, EventArgs e)
        {
            string name = txtNewAccName.Text;
            string pass = txtNewAccPass.Text;
            string confirmPass = txtConfirmPass.Text;

            if (!string.IsNullOrWhiteSpace(name) && !string.IsNullOrWhiteSpace(pass) && !string.IsNullOrWhiteSpace(confirmPass))
            {
                if (string.Equals(pass, confirmPass))
                {
                    // Run new account procedure
                    MenuStateHandler(MenuState.NewAccount);
                }
                else
                {
                    MessageBox.Show("Passwords do not match!", "Error", MessageBoxButtons.OK);
                }
            }
            else
            {
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

        public async Task MenuStateHandler(MenuState state)
        {
            switch (state)
            {
                case MenuState.NewAccount:
                    /*clientTCP = new ClientTCP();
                    clientTCP.ConnectToServer();
                    if (clientTCP.PlayerSocket.Connected)
                    {
                        btnNewAccConnect.Text = "Connecting...";
                        clientTCP.SendNewAccount(txtNewAccName.Text, txtNewAccPass.Text);
                    }*/
                    clientWebSocket = new ClientWebSock();

                    try
                    {
                        // Set your WebSocket server URI here
                        Uri serverUri = new Uri("ws://127.0.0.1:7777"); // Example URI, change as needed
                        await webSocket.ConnectAsync(serverUri, CancellationToken.None); // Asynchronous connection

                        if (webSocket.State == WebSocketState.Open)
                        {
                            btnNewAccConnect.Text = "Connecting..."; // Button text change to indicate connecting
                                                                     // Call the SendNewAccountAsync method directly from ClientWebSocket class
                            await clientWebSocket.SendNewAccountAsync(txtNewAccName.Text, txtNewAccPass.Text); // Send the new account data asynchronously
                        }
                        else
                        {
                            btnNewAccConnect.Text = "Failed to Connect"; // If connection failed
                        }
                    }
                    catch (Exception ex)
                    {
                        btnNewAccConnect.Text = "Connection Error"; // Show error message
                        MessageBox.Show($"Error connecting to server: {ex.Message}", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;

                case MenuState.DelAccount:
                    // Add logic here if needed for Delete Account
                    break;

                case MenuState.Login:
                /*clientTCP = new ClientTCP();
                clientTCP.ConnectToServer();
                if (clientTCP.PlayerSocket.Connected)
                {
                    btnLoginConnect.Text = "Connecting...";
                    clientTCP.SendLogin(txtLoginName.Text, txtLoginPass.Text);
                }*/
                string loginName = txtLoginName.Text;
                string loginPass = txtLoginPass.Text;

                if (!string.IsNullOrWhiteSpace(loginName) && !string.IsNullOrWhiteSpace(loginPass))
                {
                    // Call the method to handle login
                    await clientWebSocket.SendLoginAsync(loginName, loginPass);
                }
                else
                {
                    MessageBox.Show("Please enter a valid name and password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void btnOptionsSave_Click(object sender, EventArgs e)
        {
            // Combo box items and their respective language codes
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

            string selectedItem = cmbOptLang.SelectedItem.ToString();
            if (languageMap.TryGetValue(selectedItem, out string newLanguageCode))
            {
                string configFilePath = "Data/config.json"; // Update with actual path
                ConfigReader.UpdateLanguageCode(configFilePath, newLanguageCode);

                // Access the singleton instance of TranslationManager
                TranslationManager translator = TranslationManager.Instance;

                // Set the language code in the TranslationManager
                TranslationManager.LanguageCode = newLanguageCode;

                // Dynamically load the corresponding language file
                translator.LoadTranslations(newLanguageCode); // Load translations for the new language

                General.UpdateControlText(this);

                string messageKey = "messages.language_updated";
                string translatedMessage = TranslationManager.Instance.GetTranslation(messageKey);

                // Show the message box with the translated text
                MessageBox.Show(translatedMessage);
            }
            else
            {
                string messageKey = "messages.invalid_language";
                string translatedMessage = TranslationManager.Instance.GetTranslation(messageKey);

                // Show the message box with the translated text
                MessageBox.Show(translatedMessage);
            }
        }
    }
}
