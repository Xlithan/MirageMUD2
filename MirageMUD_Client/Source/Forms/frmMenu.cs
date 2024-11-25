using MirageMUD_Client.Source.Network;

namespace MirageMUD_Client
{
    public partial class frmMenu : Form
    {
        ClientTCP clientTCP;
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
            clientTCP = new ClientTCP();
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
            if (!string.IsNullOrWhiteSpace(txtLoginName.Text) && !string.IsNullOrWhiteSpace(txtLoginPass.Text))
            {
                // Run login procedure
                MenuStateHandler(MenuState.Login);
            }
            else if (string.IsNullOrWhiteSpace(txtLoginName.Text) && string.IsNullOrWhiteSpace(txtLoginPass.Text))
            {
                MessageBox.Show("Please enter your login name and password!", "Error", MessageBoxButtons.OK);
            }
            else if (string.IsNullOrWhiteSpace(txtLoginName.Text))
            {
                MessageBox.Show("Please enter your login name!", "Error", MessageBoxButtons.OK);
            }
            else if (string.IsNullOrWhiteSpace(txtLoginPass.Text))
            {
                MessageBox.Show("Please enter your password!", "Error", MessageBoxButtons.OK);
            }
        }

        private void btnCharsCancel_Click(object sender, EventArgs e)
        {
            pnlCharacters.Visible = false;
            pnlLogin.Visible = true;
        }

        public void MenuStateHandler(MenuState state)
        {
            switch (state)
            {
                /*case MenuState.NewAccount:

                    if (ConnectToServer())
                    {
                        SetStatus("Connected, sending new account information...");
                        SendNewAccount(txtNewAcctName.Text, txtNewAcctPassword.Text);
                    }
                    break;
                
                case MenuState.DelAccount:
                    // Add logic here if needed for Delete Account
                    break;
                */
                case MenuState.Login:

                    clientTCP.ConnectToServer();
                    if (clientTCP.PlayerSocket.Connected)
                    {
                        btnLoginConnect.Text = "Connecting...";
                        clientTCP.SendLogin();
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
    }
}
