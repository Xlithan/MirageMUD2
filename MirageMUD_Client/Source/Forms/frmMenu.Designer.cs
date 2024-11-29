namespace MirageMUD_Client
{
    partial class frmMenu
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMenu));
            pnlLogin = new Panel();
            btnLoginConnect = new Button();
            txtLoginPass = new TextBox();
            txtLoginName = new TextBox();
            chkRemember = new CheckBox();
            lblLoginPassword = new Label();
            lblLoginName = new Label();
            lblLoginDesc = new Label();
            lblTLogin = new Label();
            pnlCharacters = new Panel();
            button3 = new Button();
            button2 = new Button();
            button1 = new Button();
            btnCharsCancel = new Button();
            picCharsAvatar = new PictureBox();
            lstCharacters = new ListBox();
            label19 = new Label();
            pnlGameOptions = new Panel();
            comboBox1 = new ComboBox();
            lblOptLang = new Label();
            btnOptionsSave = new Button();
            cmbFonts = new ComboBox();
            chkSound = new CheckBox();
            lblOptMusic = new Label();
            lblOptSound = new Label();
            txtFont = new TextBox();
            chkMusic = new CheckBox();
            lblOptFont = new Label();
            lblTGameOptions = new Label();
            pnlCredits = new Panel();
            label32 = new Label();
            lblCreditsThanks = new Label();
            lblCreditsDesc = new Label();
            lblTCredits = new Label();
            pnlNewAccount = new Panel();
            txtConfirmPass = new TextBox();
            lblNewAccConfirm = new Label();
            btnNewAccConnect = new Button();
            txtNewAccPass = new TextBox();
            txtNewAccName = new TextBox();
            lblNewAccPass = new Label();
            lblNewAccName = new Label();
            lblNewAccDesc = new Label();
            lblTNewAcc = new Label();
            panel1 = new Panel();
            pnlNav = new Panel();
            btnExit = new Button();
            btnCredits = new Button();
            btnGameOptions = new Button();
            btnIPConfig = new Button();
            btnLogin = new Button();
            btnNewAcc = new Button();
            btnHome = new Button();
            panel2 = new Panel();
            lblAccountName = new Label();
            label2 = new Label();
            pictureBox1 = new PictureBox();
            pnlExit = new Panel();
            lblExitDesc = new Label();
            btnExitConfirm = new Button();
            lblTExitGame = new Label();
            pnlIPConfig = new Panel();
            btnIPConfSave = new Button();
            txtPort = new TextBox();
            txtHost = new TextBox();
            lblIPPort = new Label();
            lblIPHost = new Label();
            lblTIPConfig = new Label();
            lblTWelcome = new Label();
            lblWelcomeDesc = new Label();
            picBackground = new PictureBox();
            pnlLogin.SuspendLayout();
            pnlCharacters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picCharsAvatar).BeginInit();
            pnlGameOptions.SuspendLayout();
            pnlCredits.SuspendLayout();
            pnlNewAccount.SuspendLayout();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            pnlExit.SuspendLayout();
            pnlIPConfig.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picBackground).BeginInit();
            SuspendLayout();
            // 
            // pnlLogin
            // 
            pnlLogin.BackColor = Color.FromArgb(65, 65, 65);
            pnlLogin.BackgroundImageLayout = ImageLayout.None;
            pnlLogin.Controls.Add(btnLoginConnect);
            pnlLogin.Controls.Add(txtLoginPass);
            pnlLogin.Controls.Add(txtLoginName);
            pnlLogin.Controls.Add(chkRemember);
            pnlLogin.Controls.Add(lblLoginPassword);
            pnlLogin.Controls.Add(lblLoginName);
            pnlLogin.Controls.Add(lblLoginDesc);
            pnlLogin.Controls.Add(lblTLogin);
            pnlLogin.Location = new Point(184, 0);
            pnlLogin.Name = "pnlLogin";
            pnlLogin.Size = new Size(406, 384);
            pnlLogin.TabIndex = 9;
            // 
            // btnLoginConnect
            // 
            btnLoginConnect.BackColor = Color.FromArgb(45, 45, 45);
            btnLoginConnect.BackgroundImageLayout = ImageLayout.None;
            btnLoginConnect.FlatAppearance.BorderSize = 0;
            btnLoginConnect.FlatStyle = FlatStyle.Flat;
            btnLoginConnect.Font = new Font("Nirmala UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLoginConnect.ForeColor = Color.Silver;
            btnLoginConnect.ImageAlign = ContentAlignment.MiddleLeft;
            btnLoginConnect.Location = new Point(204, 338);
            btnLoginConnect.Name = "btnLoginConnect";
            btnLoginConnect.Size = new Size(190, 34);
            btnLoginConnect.TabIndex = 12;
            btnLoginConnect.Text = "Connect";
            btnLoginConnect.UseVisualStyleBackColor = false;
            btnLoginConnect.Click += btnLoginConnect_Click;
            // 
            // txtLoginPass
            // 
            txtLoginPass.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            txtLoginPass.Location = new Point(36, 173);
            txtLoginPass.Name = "txtLoginPass";
            txtLoginPass.PasswordChar = '•';
            txtLoginPass.Size = new Size(311, 23);
            txtLoginPass.TabIndex = 9;
            // 
            // txtLoginName
            // 
            txtLoginName.Location = new Point(36, 114);
            txtLoginName.Name = "txtLoginName";
            txtLoginName.Size = new Size(311, 23);
            txtLoginName.TabIndex = 8;
            // 
            // chkRemember
            // 
            chkRemember.AutoSize = true;
            chkRemember.BackColor = Color.Transparent;
            chkRemember.Font = new Font("Verdana", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            chkRemember.ForeColor = Color.White;
            chkRemember.Location = new Point(36, 211);
            chkRemember.Name = "chkRemember";
            chkRemember.Size = new Size(116, 18);
            chkRemember.TabIndex = 7;
            chkRemember.Text = "Remember me";
            chkRemember.UseVisualStyleBackColor = false;
            // 
            // lblLoginPassword
            // 
            lblLoginPassword.BackColor = Color.Transparent;
            lblLoginPassword.Font = new Font("Verdana", 9F, FontStyle.Bold);
            lblLoginPassword.ForeColor = Color.White;
            lblLoginPassword.Location = new Point(36, 156);
            lblLoginPassword.Name = "lblLoginPassword";
            lblLoginPassword.Size = new Size(81, 18);
            lblLoginPassword.TabIndex = 3;
            lblLoginPassword.Text = "Password:";
            lblLoginPassword.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblLoginName
            // 
            lblLoginName.BackColor = Color.Transparent;
            lblLoginName.Font = new Font("Verdana", 9F, FontStyle.Bold);
            lblLoginName.ForeColor = Color.White;
            lblLoginName.Location = new Point(36, 97);
            lblLoginName.Name = "lblLoginName";
            lblLoginName.Size = new Size(75, 18);
            lblLoginName.TabIndex = 2;
            lblLoginName.Text = "Name:";
            lblLoginName.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblLoginDesc
            // 
            lblLoginDesc.BackColor = Color.Transparent;
            lblLoginDesc.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblLoginDesc.ForeColor = Color.White;
            lblLoginDesc.Location = new Point(84, 49);
            lblLoginDesc.Name = "lblLoginDesc";
            lblLoginDesc.Size = new Size(263, 28);
            lblLoginDesc.TabIndex = 1;
            lblLoginDesc.Text = "Enter an account name and password.";
            // 
            // lblTLogin
            // 
            lblTLogin.BackColor = Color.Transparent;
            lblTLogin.Dock = DockStyle.Top;
            lblTLogin.Font = new Font("Verdana", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTLogin.ForeColor = Color.White;
            lblTLogin.Location = new Point(0, 0);
            lblTLogin.Name = "lblTLogin";
            lblTLogin.Size = new Size(406, 34);
            lblTLogin.TabIndex = 0;
            lblTLogin.Text = "Login";
            lblTLogin.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlCharacters
            // 
            pnlCharacters.BackColor = Color.FromArgb(65, 65, 65);
            pnlCharacters.BackgroundImageLayout = ImageLayout.None;
            pnlCharacters.Controls.Add(button3);
            pnlCharacters.Controls.Add(button2);
            pnlCharacters.Controls.Add(button1);
            pnlCharacters.Controls.Add(btnCharsCancel);
            pnlCharacters.Controls.Add(picCharsAvatar);
            pnlCharacters.Controls.Add(lstCharacters);
            pnlCharacters.Controls.Add(label19);
            pnlCharacters.Location = new Point(184, 0);
            pnlCharacters.Name = "pnlCharacters";
            pnlCharacters.Size = new Size(406, 384);
            pnlCharacters.TabIndex = 10;
            // 
            // button3
            // 
            button3.BackColor = Color.FromArgb(45, 45, 45);
            button3.BackgroundImageLayout = ImageLayout.None;
            button3.FlatAppearance.BorderSize = 0;
            button3.FlatStyle = FlatStyle.Flat;
            button3.Font = new Font("Nirmala UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button3.ForeColor = Color.Silver;
            button3.ImageAlign = ContentAlignment.MiddleLeft;
            button3.Location = new Point(107, 265);
            button3.Name = "button3";
            button3.Size = new Size(190, 34);
            button3.TabIndex = 15;
            button3.Text = "Delete Character";
            button3.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            button2.BackColor = Color.FromArgb(45, 45, 45);
            button2.BackgroundImageLayout = ImageLayout.None;
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Nirmala UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.ForeColor = Color.Silver;
            button2.ImageAlign = ContentAlignment.MiddleLeft;
            button2.Location = new Point(107, 225);
            button2.Name = "button2";
            button2.Size = new Size(190, 34);
            button2.TabIndex = 14;
            button2.Text = "New Character";
            button2.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(45, 45, 45);
            button1.BackgroundImageLayout = ImageLayout.None;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Nirmala UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.Silver;
            button1.ImageAlign = ContentAlignment.MiddleLeft;
            button1.Location = new Point(107, 185);
            button1.Name = "button1";
            button1.Size = new Size(190, 34);
            button1.TabIndex = 13;
            button1.Text = "Use Character";
            button1.UseVisualStyleBackColor = false;
            // 
            // btnCharsCancel
            // 
            btnCharsCancel.BackColor = Color.FromArgb(45, 45, 45);
            btnCharsCancel.BackgroundImageLayout = ImageLayout.None;
            btnCharsCancel.FlatAppearance.BorderSize = 0;
            btnCharsCancel.FlatStyle = FlatStyle.Flat;
            btnCharsCancel.Font = new Font("Nirmala UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCharsCancel.ForeColor = Color.Silver;
            btnCharsCancel.ImageAlign = ContentAlignment.MiddleLeft;
            btnCharsCancel.Location = new Point(204, 338);
            btnCharsCancel.Name = "btnCharsCancel";
            btnCharsCancel.Size = new Size(190, 34);
            btnCharsCancel.TabIndex = 12;
            btnCharsCancel.Text = "Cancel";
            btnCharsCancel.UseVisualStyleBackColor = false;
            btnCharsCancel.Click += btnCharsCancel_Click;
            // 
            // picCharsAvatar
            // 
            picCharsAvatar.BorderStyle = BorderStyle.FixedSingle;
            picCharsAvatar.Location = new Point(321, 185);
            picCharsAvatar.Name = "picCharsAvatar";
            picCharsAvatar.Size = new Size(48, 48);
            picCharsAvatar.TabIndex = 8;
            picCharsAvatar.TabStop = false;
            // 
            // lstCharacters
            // 
            lstCharacters.BackColor = Color.FromArgb(64, 64, 64);
            lstCharacters.BorderStyle = BorderStyle.FixedSingle;
            lstCharacters.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lstCharacters.ForeColor = Color.FromArgb(255, 255, 128);
            lstCharacters.FormattingEnabled = true;
            lstCharacters.ItemHeight = 17;
            lstCharacters.Location = new Point(36, 47);
            lstCharacters.Name = "lstCharacters";
            lstCharacters.Size = new Size(333, 121);
            lstCharacters.TabIndex = 7;
            // 
            // label19
            // 
            label19.BackColor = Color.Transparent;
            label19.Dock = DockStyle.Top;
            label19.Font = new Font("Verdana", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label19.ForeColor = Color.White;
            label19.Location = new Point(0, 0);
            label19.Name = "label19";
            label19.Size = new Size(406, 34);
            label19.TabIndex = 0;
            label19.Text = "Characters";
            label19.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlGameOptions
            // 
            pnlGameOptions.BackColor = Color.FromArgb(65, 65, 65);
            pnlGameOptions.BackgroundImageLayout = ImageLayout.None;
            pnlGameOptions.Controls.Add(comboBox1);
            pnlGameOptions.Controls.Add(lblOptLang);
            pnlGameOptions.Controls.Add(btnOptionsSave);
            pnlGameOptions.Controls.Add(cmbFonts);
            pnlGameOptions.Controls.Add(chkSound);
            pnlGameOptions.Controls.Add(lblOptMusic);
            pnlGameOptions.Controls.Add(lblOptSound);
            pnlGameOptions.Controls.Add(txtFont);
            pnlGameOptions.Controls.Add(chkMusic);
            pnlGameOptions.Controls.Add(lblOptFont);
            pnlGameOptions.Controls.Add(lblTGameOptions);
            pnlGameOptions.Location = new Point(184, 0);
            pnlGameOptions.Name = "pnlGameOptions";
            pnlGameOptions.Size = new Size(406, 384);
            pnlGameOptions.TabIndex = 14;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Welsh (Cymraeg)", "German (Deutsch)", "British English (English)", "American English (English)", "Spanish (Español)", "French (Français)", "Italian (Italiano)", "Portuguese (Português)", "Romanized Japanese (Romaji)", "Polish (Polski)", "Swedish (Svenska)" });
            comboBox1.Location = new Point(36, 236);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(311, 23);
            comboBox1.TabIndex = 18;
            // 
            // lblOptLang
            // 
            lblOptLang.BackColor = Color.Transparent;
            lblOptLang.Font = new Font("Verdana", 9F, FontStyle.Bold);
            lblOptLang.ForeColor = Color.White;
            lblOptLang.Location = new Point(36, 215);
            lblOptLang.Name = "lblOptLang";
            lblOptLang.Size = new Size(103, 18);
            lblOptLang.TabIndex = 17;
            lblOptLang.Text = "Language:";
            lblOptLang.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btnOptionsSave
            // 
            btnOptionsSave.BackColor = Color.FromArgb(45, 45, 45);
            btnOptionsSave.BackgroundImageLayout = ImageLayout.None;
            btnOptionsSave.FlatAppearance.BorderSize = 0;
            btnOptionsSave.FlatStyle = FlatStyle.Flat;
            btnOptionsSave.Font = new Font("Nirmala UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnOptionsSave.ForeColor = Color.Silver;
            btnOptionsSave.ImageAlign = ContentAlignment.MiddleLeft;
            btnOptionsSave.Location = new Point(204, 338);
            btnOptionsSave.Name = "btnOptionsSave";
            btnOptionsSave.Size = new Size(190, 34);
            btnOptionsSave.TabIndex = 16;
            btnOptionsSave.Text = "Save";
            btnOptionsSave.UseVisualStyleBackColor = false;
            // 
            // cmbFonts
            // 
            cmbFonts.FormattingEnabled = true;
            cmbFonts.Location = new Point(36, 182);
            cmbFonts.Name = "cmbFonts";
            cmbFonts.Size = new Size(311, 23);
            cmbFonts.TabIndex = 15;
            // 
            // chkSound
            // 
            chkSound.AutoSize = true;
            chkSound.BackColor = Color.Transparent;
            chkSound.ForeColor = Color.White;
            chkSound.Location = new Point(85, 90);
            chkSound.Name = "chkSound";
            chkSound.Size = new Size(15, 14);
            chkSound.TabIndex = 14;
            chkSound.UseVisualStyleBackColor = false;
            // 
            // lblOptMusic
            // 
            lblOptMusic.BackColor = Color.Transparent;
            lblOptMusic.Font = new Font("Verdana", 9F, FontStyle.Bold);
            lblOptMusic.ForeColor = Color.White;
            lblOptMusic.Location = new Point(4, 55);
            lblOptMusic.Name = "lblOptMusic";
            lblOptMusic.Size = new Size(75, 28);
            lblOptMusic.TabIndex = 13;
            lblOptMusic.Text = "Music:";
            lblOptMusic.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblOptSound
            // 
            lblOptSound.BackColor = Color.Transparent;
            lblOptSound.Font = new Font("Verdana", 9F, FontStyle.Bold);
            lblOptSound.ForeColor = Color.White;
            lblOptSound.Location = new Point(4, 83);
            lblOptSound.Name = "lblOptSound";
            lblOptSound.Size = new Size(75, 28);
            lblOptSound.TabIndex = 12;
            lblOptSound.Text = "Sound:";
            lblOptSound.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtFont
            // 
            txtFont.Location = new Point(36, 144);
            txtFont.Name = "txtFont";
            txtFont.Size = new Size(311, 23);
            txtFont.TabIndex = 9;
            // 
            // chkMusic
            // 
            chkMusic.AutoSize = true;
            chkMusic.BackColor = Color.Transparent;
            chkMusic.ForeColor = Color.White;
            chkMusic.Location = new Point(85, 63);
            chkMusic.Name = "chkMusic";
            chkMusic.Size = new Size(15, 14);
            chkMusic.TabIndex = 7;
            chkMusic.UseVisualStyleBackColor = false;
            // 
            // lblOptFont
            // 
            lblOptFont.BackColor = Color.Transparent;
            lblOptFont.Font = new Font("Verdana", 9F, FontStyle.Bold);
            lblOptFont.ForeColor = Color.White;
            lblOptFont.Location = new Point(36, 127);
            lblOptFont.Name = "lblOptFont";
            lblOptFont.Size = new Size(75, 18);
            lblOptFont.TabIndex = 3;
            lblOptFont.Text = "Font:";
            lblOptFont.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblTGameOptions
            // 
            lblTGameOptions.BackColor = Color.Transparent;
            lblTGameOptions.Dock = DockStyle.Top;
            lblTGameOptions.Font = new Font("Verdana", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTGameOptions.ForeColor = Color.White;
            lblTGameOptions.Location = new Point(0, 0);
            lblTGameOptions.Name = "lblTGameOptions";
            lblTGameOptions.Size = new Size(406, 34);
            lblTGameOptions.TabIndex = 0;
            lblTGameOptions.Text = "Game Options";
            lblTGameOptions.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlCredits
            // 
            pnlCredits.BackColor = Color.FromArgb(65, 65, 65);
            pnlCredits.BackgroundImageLayout = ImageLayout.None;
            pnlCredits.Controls.Add(label32);
            pnlCredits.Controls.Add(lblCreditsThanks);
            pnlCredits.Controls.Add(lblCreditsDesc);
            pnlCredits.Controls.Add(lblTCredits);
            pnlCredits.Location = new Point(184, 0);
            pnlCredits.Name = "pnlCredits";
            pnlCredits.Size = new Size(406, 384);
            pnlCredits.TabIndex = 17;
            // 
            // label32
            // 
            label32.BackColor = Color.Transparent;
            label32.Font = new Font("Verdana", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label32.ForeColor = Color.White;
            label32.Location = new Point(66, 156);
            label32.Name = "label32";
            label32.Size = new Size(274, 92);
            label32.TabIndex = 9;
            label32.Text = "Consty - Mirage Online source\r\nWilliam - Code contributions\r\nVerrigan - Code contributions\r\nXlithan - MirageMUD creator\r\n\r\nAny many others...";
            label32.TextAlign = ContentAlignment.TopCenter;
            // 
            // lblCreditsThanks
            // 
            lblCreditsThanks.BackColor = Color.Transparent;
            lblCreditsThanks.Font = new Font("Verdana", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCreditsThanks.ForeColor = Color.White;
            lblCreditsThanks.Location = new Point(66, 137);
            lblCreditsThanks.Name = "lblCreditsThanks";
            lblCreditsThanks.Size = new Size(274, 19);
            lblCreditsThanks.TabIndex = 8;
            lblCreditsThanks.Text = "Special Thanks:";
            lblCreditsThanks.TextAlign = ContentAlignment.TopCenter;
            // 
            // lblCreditsDesc
            // 
            lblCreditsDesc.BackColor = Color.Transparent;
            lblCreditsDesc.Font = new Font("Verdana", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCreditsDesc.ForeColor = Color.White;
            lblCreditsDesc.Location = new Point(66, 64);
            lblCreditsDesc.Name = "lblCreditsDesc";
            lblCreditsDesc.Size = new Size(274, 55);
            lblCreditsDesc.TabIndex = 7;
            lblCreditsDesc.Text = "MirageSource has and always will be a collective effort by the MirageSource community since it's conception.";
            lblCreditsDesc.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblTCredits
            // 
            lblTCredits.BackColor = Color.Transparent;
            lblTCredits.Dock = DockStyle.Top;
            lblTCredits.Font = new Font("Verdana", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTCredits.ForeColor = Color.White;
            lblTCredits.Location = new Point(0, 0);
            lblTCredits.Name = "lblTCredits";
            lblTCredits.Size = new Size(406, 34);
            lblTCredits.TabIndex = 0;
            lblTCredits.Text = "Credits";
            lblTCredits.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlNewAccount
            // 
            pnlNewAccount.BackColor = Color.FromArgb(65, 65, 65);
            pnlNewAccount.BackgroundImageLayout = ImageLayout.None;
            pnlNewAccount.Controls.Add(txtConfirmPass);
            pnlNewAccount.Controls.Add(lblNewAccConfirm);
            pnlNewAccount.Controls.Add(btnNewAccConnect);
            pnlNewAccount.Controls.Add(txtNewAccPass);
            pnlNewAccount.Controls.Add(txtNewAccName);
            pnlNewAccount.Controls.Add(lblNewAccPass);
            pnlNewAccount.Controls.Add(lblNewAccName);
            pnlNewAccount.Controls.Add(lblNewAccDesc);
            pnlNewAccount.Controls.Add(lblTNewAcc);
            pnlNewAccount.Location = new Point(184, 0);
            pnlNewAccount.Name = "pnlNewAccount";
            pnlNewAccount.Size = new Size(406, 384);
            pnlNewAccount.TabIndex = 19;
            // 
            // txtConfirmPass
            // 
            txtConfirmPass.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtConfirmPass.Location = new Point(36, 250);
            txtConfirmPass.Name = "txtConfirmPass";
            txtConfirmPass.PasswordChar = '•';
            txtConfirmPass.Size = new Size(311, 23);
            txtConfirmPass.TabIndex = 14;
            // 
            // lblNewAccConfirm
            // 
            lblNewAccConfirm.BackColor = Color.Transparent;
            lblNewAccConfirm.Font = new Font("Verdana", 9F, FontStyle.Bold);
            lblNewAccConfirm.ForeColor = Color.White;
            lblNewAccConfirm.Location = new Point(36, 233);
            lblNewAccConfirm.Name = "lblNewAccConfirm";
            lblNewAccConfirm.Size = new Size(139, 18);
            lblNewAccConfirm.TabIndex = 13;
            lblNewAccConfirm.Text = "Confirm Password:";
            lblNewAccConfirm.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btnNewAccConnect
            // 
            btnNewAccConnect.BackColor = Color.FromArgb(45, 45, 45);
            btnNewAccConnect.BackgroundImageLayout = ImageLayout.None;
            btnNewAccConnect.FlatAppearance.BorderSize = 0;
            btnNewAccConnect.FlatStyle = FlatStyle.Flat;
            btnNewAccConnect.Font = new Font("Nirmala UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnNewAccConnect.ForeColor = Color.Silver;
            btnNewAccConnect.ImageAlign = ContentAlignment.MiddleLeft;
            btnNewAccConnect.Location = new Point(204, 338);
            btnNewAccConnect.Name = "btnNewAccConnect";
            btnNewAccConnect.Size = new Size(190, 34);
            btnNewAccConnect.TabIndex = 12;
            btnNewAccConnect.Text = "Connect";
            btnNewAccConnect.UseVisualStyleBackColor = false;
            btnNewAccConnect.Click += btnNewAccConnect_Click;
            // 
            // txtNewAccPass
            // 
            txtNewAccPass.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtNewAccPass.Location = new Point(36, 199);
            txtNewAccPass.Name = "txtNewAccPass";
            txtNewAccPass.PasswordChar = '•';
            txtNewAccPass.Size = new Size(311, 23);
            txtNewAccPass.TabIndex = 9;
            // 
            // txtNewAccName
            // 
            txtNewAccName.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtNewAccName.Location = new Point(36, 148);
            txtNewAccName.Name = "txtNewAccName";
            txtNewAccName.Size = new Size(311, 23);
            txtNewAccName.TabIndex = 8;
            // 
            // lblNewAccPass
            // 
            lblNewAccPass.BackColor = Color.Transparent;
            lblNewAccPass.Font = new Font("Verdana", 9F, FontStyle.Bold);
            lblNewAccPass.ForeColor = Color.White;
            lblNewAccPass.Location = new Point(36, 182);
            lblNewAccPass.Name = "lblNewAccPass";
            lblNewAccPass.Size = new Size(81, 18);
            lblNewAccPass.TabIndex = 3;
            lblNewAccPass.Text = "Password:";
            lblNewAccPass.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblNewAccName
            // 
            lblNewAccName.BackColor = Color.Transparent;
            lblNewAccName.Font = new Font("Verdana", 9F, FontStyle.Bold);
            lblNewAccName.ForeColor = Color.White;
            lblNewAccName.Location = new Point(36, 131);
            lblNewAccName.Name = "lblNewAccName";
            lblNewAccName.Size = new Size(75, 18);
            lblNewAccName.TabIndex = 2;
            lblNewAccName.Text = "Name:";
            lblNewAccName.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblNewAccDesc
            // 
            lblNewAccDesc.BackColor = Color.Transparent;
            lblNewAccDesc.Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblNewAccDesc.ForeColor = Color.White;
            lblNewAccDesc.Location = new Point(84, 54);
            lblNewAccDesc.Name = "lblNewAccDesc";
            lblNewAccDesc.Size = new Size(263, 50);
            lblNewAccDesc.TabIndex = 1;
            lblNewAccDesc.Text = "Enter a account name and password.  You can name yourself whatever you want, we have no restrictions on names.";
            // 
            // lblTNewAcc
            // 
            lblTNewAcc.BackColor = Color.Transparent;
            lblTNewAcc.Dock = DockStyle.Top;
            lblTNewAcc.Font = new Font("Verdana", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTNewAcc.ForeColor = Color.White;
            lblTNewAcc.Location = new Point(0, 0);
            lblTNewAcc.Name = "lblTNewAcc";
            lblTNewAcc.Size = new Size(406, 34);
            lblTNewAcc.TabIndex = 0;
            lblTNewAcc.Text = "New Account";
            lblTNewAcc.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(45, 45, 45);
            panel1.Controls.Add(pnlNav);
            panel1.Controls.Add(btnExit);
            panel1.Controls.Add(btnCredits);
            panel1.Controls.Add(btnGameOptions);
            panel1.Controls.Add(btnIPConfig);
            panel1.Controls.Add(btnLogin);
            panel1.Controls.Add(btnNewAcc);
            panel1.Controls.Add(btnHome);
            panel1.Controls.Add(panel2);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(184, 384);
            panel1.TabIndex = 20;
            // 
            // pnlNav
            // 
            pnlNav.BackColor = Color.DarkGoldenrod;
            pnlNav.Location = new Point(0, 193);
            pnlNav.Name = "pnlNav";
            pnlNav.Size = new Size(3, 100);
            pnlNav.TabIndex = 2;
            // 
            // btnExit
            // 
            btnExit.BackgroundImageLayout = ImageLayout.Zoom;
            btnExit.Dock = DockStyle.Bottom;
            btnExit.FlatAppearance.BorderSize = 0;
            btnExit.FlatStyle = FlatStyle.Flat;
            btnExit.Font = new Font("Nirmala UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnExit.ForeColor = Color.Silver;
            btnExit.Image = (Image)resources.GetObject("btnExit.Image");
            btnExit.ImageAlign = ContentAlignment.MiddleRight;
            btnExit.Location = new Point(0, 350);
            btnExit.Name = "btnExit";
            btnExit.Padding = new Padding(0, 0, 12, 0);
            btnExit.Size = new Size(184, 34);
            btnExit.TabIndex = 1;
            btnExit.Text = "Exit Game";
            btnExit.TextAlign = ContentAlignment.MiddleLeft;
            btnExit.TextImageRelation = TextImageRelation.TextBeforeImage;
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            btnExit.Leave += btnExit_Leave;
            // 
            // btnCredits
            // 
            btnCredits.BackgroundImageLayout = ImageLayout.Zoom;
            btnCredits.Dock = DockStyle.Top;
            btnCredits.FlatAppearance.BorderSize = 0;
            btnCredits.FlatStyle = FlatStyle.Flat;
            btnCredits.Font = new Font("Nirmala UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCredits.ForeColor = Color.Silver;
            btnCredits.Image = (Image)resources.GetObject("btnCredits.Image");
            btnCredits.ImageAlign = ContentAlignment.MiddleRight;
            btnCredits.Location = new Point(0, 293);
            btnCredits.Name = "btnCredits";
            btnCredits.Padding = new Padding(0, 0, 15, 0);
            btnCredits.Size = new Size(184, 34);
            btnCredits.TabIndex = 1;
            btnCredits.Text = "Credits";
            btnCredits.TextAlign = ContentAlignment.MiddleLeft;
            btnCredits.TextImageRelation = TextImageRelation.TextBeforeImage;
            btnCredits.UseVisualStyleBackColor = true;
            btnCredits.Click += btnCredits_Click;
            btnCredits.Leave += btnCredits_Leave;
            // 
            // btnGameOptions
            // 
            btnGameOptions.BackgroundImageLayout = ImageLayout.Zoom;
            btnGameOptions.Dock = DockStyle.Top;
            btnGameOptions.FlatAppearance.BorderSize = 0;
            btnGameOptions.FlatStyle = FlatStyle.Flat;
            btnGameOptions.Font = new Font("Nirmala UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnGameOptions.ForeColor = Color.Silver;
            btnGameOptions.Image = (Image)resources.GetObject("btnGameOptions.Image");
            btnGameOptions.ImageAlign = ContentAlignment.MiddleRight;
            btnGameOptions.Location = new Point(0, 259);
            btnGameOptions.Name = "btnGameOptions";
            btnGameOptions.Padding = new Padding(0, 0, 14, 0);
            btnGameOptions.Size = new Size(184, 34);
            btnGameOptions.TabIndex = 1;
            btnGameOptions.Text = "Game Options";
            btnGameOptions.TextAlign = ContentAlignment.MiddleLeft;
            btnGameOptions.TextImageRelation = TextImageRelation.TextBeforeImage;
            btnGameOptions.UseVisualStyleBackColor = true;
            btnGameOptions.Click += btnGameOptions_Click;
            btnGameOptions.Leave += btnGameOptions_Leave;
            // 
            // btnIPConfig
            // 
            btnIPConfig.BackgroundImageLayout = ImageLayout.Zoom;
            btnIPConfig.Dock = DockStyle.Top;
            btnIPConfig.FlatAppearance.BorderSize = 0;
            btnIPConfig.FlatStyle = FlatStyle.Flat;
            btnIPConfig.Font = new Font("Nirmala UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnIPConfig.ForeColor = Color.Silver;
            btnIPConfig.Image = (Image)resources.GetObject("btnIPConfig.Image");
            btnIPConfig.ImageAlign = ContentAlignment.MiddleRight;
            btnIPConfig.Location = new Point(0, 225);
            btnIPConfig.Name = "btnIPConfig";
            btnIPConfig.Padding = new Padding(0, 0, 12, 0);
            btnIPConfig.Size = new Size(184, 34);
            btnIPConfig.TabIndex = 1;
            btnIPConfig.Text = "IP Config";
            btnIPConfig.TextAlign = ContentAlignment.MiddleLeft;
            btnIPConfig.TextImageRelation = TextImageRelation.TextBeforeImage;
            btnIPConfig.UseVisualStyleBackColor = true;
            btnIPConfig.Click += btnIPConfig_Click;
            btnIPConfig.Leave += btnIPConfig_Leave;
            // 
            // btnLogin
            // 
            btnLogin.BackgroundImageLayout = ImageLayout.Zoom;
            btnLogin.Dock = DockStyle.Top;
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Font = new Font("Nirmala UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogin.ForeColor = Color.Silver;
            btnLogin.Image = (Image)resources.GetObject("btnLogin.Image");
            btnLogin.ImageAlign = ContentAlignment.MiddleRight;
            btnLogin.Location = new Point(0, 191);
            btnLogin.Name = "btnLogin";
            btnLogin.Padding = new Padding(0, 0, 12, 0);
            btnLogin.Size = new Size(184, 34);
            btnLogin.TabIndex = 1;
            btnLogin.Text = "Login";
            btnLogin.TextAlign = ContentAlignment.MiddleLeft;
            btnLogin.TextImageRelation = TextImageRelation.TextBeforeImage;
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            btnLogin.Leave += btnLogin_Leave;
            // 
            // btnNewAcc
            // 
            btnNewAcc.BackgroundImageLayout = ImageLayout.Zoom;
            btnNewAcc.Dock = DockStyle.Top;
            btnNewAcc.FlatAppearance.BorderSize = 0;
            btnNewAcc.FlatStyle = FlatStyle.Flat;
            btnNewAcc.Font = new Font("Nirmala UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnNewAcc.ForeColor = Color.Silver;
            btnNewAcc.Image = (Image)resources.GetObject("btnNewAcc.Image");
            btnNewAcc.ImageAlign = ContentAlignment.MiddleRight;
            btnNewAcc.Location = new Point(0, 157);
            btnNewAcc.Name = "btnNewAcc";
            btnNewAcc.Padding = new Padding(0, 0, 12, 0);
            btnNewAcc.Size = new Size(184, 34);
            btnNewAcc.TabIndex = 1;
            btnNewAcc.Text = "New Account";
            btnNewAcc.TextAlign = ContentAlignment.MiddleLeft;
            btnNewAcc.TextImageRelation = TextImageRelation.TextBeforeImage;
            btnNewAcc.UseVisualStyleBackColor = true;
            btnNewAcc.Click += btnNewAcc_Click;
            btnNewAcc.Leave += btnNewAcc_Leave;
            // 
            // btnHome
            // 
            btnHome.BackColor = Color.FromArgb(45, 45, 45);
            btnHome.BackgroundImageLayout = ImageLayout.None;
            btnHome.Dock = DockStyle.Top;
            btnHome.FlatAppearance.BorderSize = 0;
            btnHome.FlatStyle = FlatStyle.Flat;
            btnHome.Font = new Font("Nirmala UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnHome.ForeColor = Color.Silver;
            btnHome.Image = (Image)resources.GetObject("btnHome.Image");
            btnHome.ImageAlign = ContentAlignment.MiddleRight;
            btnHome.Location = new Point(0, 123);
            btnHome.Name = "btnHome";
            btnHome.Padding = new Padding(0, 0, 12, 0);
            btnHome.Size = new Size(184, 34);
            btnHome.TabIndex = 1;
            btnHome.Text = "Home";
            btnHome.TextAlign = ContentAlignment.MiddleLeft;
            btnHome.TextImageRelation = TextImageRelation.TextBeforeImage;
            btnHome.UseVisualStyleBackColor = false;
            btnHome.Click += btnHome_Click;
            btnHome.Leave += btnHome_Leave;
            // 
            // panel2
            // 
            panel2.Controls.Add(lblAccountName);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(pictureBox1);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(184, 123);
            panel2.TabIndex = 0;
            // 
            // lblAccountName
            // 
            lblAccountName.Dock = DockStyle.Top;
            lblAccountName.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblAccountName.ForeColor = Color.DarkGoldenrod;
            lblAccountName.Location = new Point(0, 97);
            lblAccountName.Name = "lblAccountName";
            lblAccountName.Size = new Size(184, 19);
            lblAccountName.TabIndex = 3;
            lblAccountName.Text = "Not Logged In";
            lblAccountName.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.Dock = DockStyle.Top;
            label2.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(224, 224, 224);
            label2.Location = new Point(0, 77);
            label2.Name = "label2";
            label2.Size = new Size(184, 20);
            label2.TabIndex = 2;
            label2.Text = "MirageMUD 2";
            label2.TextAlign = ContentAlignment.TopCenter;
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImageLayout = ImageLayout.Center;
            pictureBox1.Dock = DockStyle.Top;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(184, 77);
            pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // pnlExit
            // 
            pnlExit.BackColor = Color.FromArgb(65, 65, 65);
            pnlExit.BackgroundImageLayout = ImageLayout.None;
            pnlExit.Controls.Add(lblExitDesc);
            pnlExit.Controls.Add(btnExitConfirm);
            pnlExit.Controls.Add(lblTExitGame);
            pnlExit.Location = new Point(184, 0);
            pnlExit.Name = "pnlExit";
            pnlExit.Size = new Size(406, 384);
            pnlExit.TabIndex = 21;
            // 
            // lblExitDesc
            // 
            lblExitDesc.BackColor = Color.Transparent;
            lblExitDesc.Font = new Font("Verdana", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblExitDesc.ForeColor = Color.White;
            lblExitDesc.Location = new Point(46, 64);
            lblExitDesc.Name = "lblExitDesc";
            lblExitDesc.Size = new Size(307, 33);
            lblExitDesc.TabIndex = 8;
            lblExitDesc.Text = "Please confirm that you wish to exit the game.";
            // 
            // btnExitConfirm
            // 
            btnExitConfirm.BackColor = Color.FromArgb(45, 45, 45);
            btnExitConfirm.BackgroundImageLayout = ImageLayout.Zoom;
            btnExitConfirm.FlatAppearance.BorderSize = 0;
            btnExitConfirm.FlatStyle = FlatStyle.Flat;
            btnExitConfirm.Font = new Font("Nirmala UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnExitConfirm.ForeColor = Color.Silver;
            btnExitConfirm.ImageAlign = ContentAlignment.MiddleRight;
            btnExitConfirm.Location = new Point(102, 108);
            btnExitConfirm.Name = "btnExitConfirm";
            btnExitConfirm.Size = new Size(184, 28);
            btnExitConfirm.TabIndex = 2;
            btnExitConfirm.Text = "Confirm";
            btnExitConfirm.TextImageRelation = TextImageRelation.TextBeforeImage;
            btnExitConfirm.UseVisualStyleBackColor = false;
            btnExitConfirm.Click += btnExitConfirm_Click;
            // 
            // lblTExitGame
            // 
            lblTExitGame.BackColor = Color.Transparent;
            lblTExitGame.Dock = DockStyle.Top;
            lblTExitGame.Font = new Font("Verdana", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTExitGame.ForeColor = Color.White;
            lblTExitGame.Location = new Point(0, 0);
            lblTExitGame.Name = "lblTExitGame";
            lblTExitGame.Size = new Size(406, 34);
            lblTExitGame.TabIndex = 0;
            lblTExitGame.Text = "Exit Game";
            lblTExitGame.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlIPConfig
            // 
            pnlIPConfig.BackColor = Color.FromArgb(65, 65, 65);
            pnlIPConfig.BackgroundImageLayout = ImageLayout.None;
            pnlIPConfig.Controls.Add(btnIPConfSave);
            pnlIPConfig.Controls.Add(txtPort);
            pnlIPConfig.Controls.Add(txtHost);
            pnlIPConfig.Controls.Add(lblIPPort);
            pnlIPConfig.Controls.Add(lblIPHost);
            pnlIPConfig.Controls.Add(lblTIPConfig);
            pnlIPConfig.Location = new Point(184, 0);
            pnlIPConfig.Name = "pnlIPConfig";
            pnlIPConfig.Size = new Size(406, 384);
            pnlIPConfig.TabIndex = 23;
            // 
            // btnIPConfSave
            // 
            btnIPConfSave.BackColor = Color.FromArgb(45, 45, 45);
            btnIPConfSave.BackgroundImageLayout = ImageLayout.None;
            btnIPConfSave.FlatAppearance.BorderSize = 0;
            btnIPConfSave.FlatStyle = FlatStyle.Flat;
            btnIPConfSave.Font = new Font("Nirmala UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnIPConfSave.ForeColor = Color.Silver;
            btnIPConfSave.ImageAlign = ContentAlignment.MiddleLeft;
            btnIPConfSave.Location = new Point(204, 338);
            btnIPConfSave.Name = "btnIPConfSave";
            btnIPConfSave.Size = new Size(190, 34);
            btnIPConfSave.TabIndex = 11;
            btnIPConfSave.Text = "Save";
            btnIPConfSave.UseVisualStyleBackColor = false;
            // 
            // txtPort
            // 
            txtPort.Location = new Point(36, 143);
            txtPort.Name = "txtPort";
            txtPort.Size = new Size(311, 23);
            txtPort.TabIndex = 9;
            // 
            // txtHost
            // 
            txtHost.Location = new Point(36, 86);
            txtHost.Name = "txtHost";
            txtHost.Size = new Size(311, 23);
            txtHost.TabIndex = 8;
            // 
            // lblIPPort
            // 
            lblIPPort.BackColor = Color.Transparent;
            lblIPPort.Font = new Font("Verdana", 9F, FontStyle.Bold);
            lblIPPort.ForeColor = Color.White;
            lblIPPort.Location = new Point(36, 126);
            lblIPPort.Name = "lblIPPort";
            lblIPPort.Size = new Size(75, 18);
            lblIPPort.TabIndex = 3;
            lblIPPort.Text = "Port:";
            lblIPPort.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblIPHost
            // 
            lblIPHost.BackColor = Color.Transparent;
            lblIPHost.Font = new Font("Verdana", 9F, FontStyle.Bold);
            lblIPHost.ForeColor = Color.White;
            lblIPHost.Location = new Point(36, 69);
            lblIPHost.Name = "lblIPHost";
            lblIPHost.Size = new Size(75, 18);
            lblIPHost.TabIndex = 2;
            lblIPHost.Text = "Host:";
            lblIPHost.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblTIPConfig
            // 
            lblTIPConfig.BackColor = Color.Transparent;
            lblTIPConfig.Dock = DockStyle.Top;
            lblTIPConfig.Font = new Font("Verdana", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTIPConfig.ForeColor = Color.White;
            lblTIPConfig.Location = new Point(0, 0);
            lblTIPConfig.Name = "lblTIPConfig";
            lblTIPConfig.Size = new Size(406, 34);
            lblTIPConfig.TabIndex = 0;
            lblTIPConfig.Text = "IP Config";
            lblTIPConfig.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblTWelcome
            // 
            lblTWelcome.BackColor = Color.Transparent;
            lblTWelcome.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTWelcome.ForeColor = Color.FromArgb(224, 224, 224);
            lblTWelcome.Location = new Point(232, 120);
            lblTWelcome.Name = "lblTWelcome";
            lblTWelcome.Size = new Size(309, 20);
            lblTWelcome.TabIndex = 24;
            lblTWelcome.Text = "Welcome";
            lblTWelcome.TextAlign = ContentAlignment.TopCenter;
            // 
            // lblWelcomeDesc
            // 
            lblWelcomeDesc.BackColor = Color.Transparent;
            lblWelcomeDesc.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblWelcomeDesc.ForeColor = Color.FromArgb(224, 224, 224);
            lblWelcomeDesc.Location = new Point(257, 143);
            lblWelcomeDesc.Name = "lblWelcomeDesc";
            lblWelcomeDesc.Size = new Size(259, 96);
            lblWelcomeDesc.TabIndex = 25;
            lblWelcomeDesc.Text = "Welcome to MirageMUD 2, the most advanced stand-alone graphical MUD engine on the planet.\r\n\r\nUse the left navigation to create a new account or log into the server.";
            lblWelcomeDesc.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // picBackground
            // 
            picBackground.BackColor = Color.Transparent;
            picBackground.Location = new Point(0, 0);
            picBackground.Name = "picBackground";
            picBackground.Size = new Size(590, 384);
            picBackground.TabIndex = 26;
            picBackground.TabStop = false;
            // 
            // frmMenu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(65, 65, 65);
            BackgroundImage = Properties.Resources.menuback;
            BackgroundImageLayout = ImageLayout.None;
            ClientSize = new Size(590, 384);
            ControlBox = false;
            Controls.Add(panel1);
            Controls.Add(pnlNewAccount);
            Controls.Add(pnlLogin);
            Controls.Add(pnlCharacters);
            Controls.Add(pnlExit);
            Controls.Add(pnlIPConfig);
            Controls.Add(pnlCredits);
            Controls.Add(pnlGameOptions);
            Controls.Add(lblTWelcome);
            Controls.Add(lblWelcomeDesc);
            Controls.Add(picBackground);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.None;
            MaximizeBox = false;
            Name = "frmMenu";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MirageMUD 2";
            Load += frmMenu_Load;
            pnlLogin.ResumeLayout(false);
            pnlLogin.PerformLayout();
            pnlCharacters.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picCharsAvatar).EndInit();
            pnlGameOptions.ResumeLayout(false);
            pnlGameOptions.PerformLayout();
            pnlCredits.ResumeLayout(false);
            pnlNewAccount.ResumeLayout(false);
            pnlNewAccount.PerformLayout();
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            pnlExit.ResumeLayout(false);
            pnlIPConfig.ResumeLayout(false);
            pnlIPConfig.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picBackground).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Panel pnlLogin;
        private TextBox txtLoginPass;
        private TextBox txtLoginName;
        private CheckBox chkRemember;
        private Label lblLoginPassword;
        private Label lblLoginName;
        private Label lblLoginDesc;
        private Label lblTLogin;
        private Panel pnlCharacters;
        private Label label19;
        private PictureBox picCharsAvatar;
        private ListBox lstCharacters;
        private Panel pnlGameOptions;
        private TextBox txtFont;
        private CheckBox chkMusic;
        private Label lblOptFont;
        private Label lblTGameOptions;
        private ComboBox cmbFonts;
        private CheckBox chkSound;
        private Label lblOptMusic;
        private Label lblOptSound;
        private Panel pnlCredits;
        private Label lblCreditsDesc;
        private Label lblTCredits;
        private Label label32;
        private Label lblCreditsThanks;
        private Panel pnlNewAccount;
        private TextBox txtNewAccPass;
        private TextBox txtNewAccName;
        private Label lblNewAccPass;
        private Label lblNewAccName;
        private Label lblNewAccDesc;
        private Label lblTNewAcc;
        private Panel panel1;
        private Panel panel2;
        private Button btnHome;
        private Button btnExit;
        private Button btnCredits;
        private Button btnGameOptions;
        private Button btnIPConfig;
        private Button btnLogin;
        private Button btnNewAcc;
        private Panel pnlNav;
        private Panel pnlExit;
        private Label lblTExitGame;
        private Button btnExitConfirm;
        private Label lblExitDesc;
        private PictureBox pictureBox1;
        private Label lblAccountName;
        private Label label2;
        private Panel pnlIPConfig;
        private TextBox txtPort;
        private TextBox txtHost;
        private Label lblIPPort;
        private Label lblIPHost;
        private Label lblTIPConfig;
        private Label lblTWelcome;
        private Label lblWelcomeDesc;
        private Button btnIPConfSave;
        private Button btnLoginConnect;
        private Button btnOptionsSave;
        private Button btnNewAccConnect;
        private Button btnCharsCancel;
        private Button button3;
        private Button button2;
        private Button button1;
        private TextBox txtConfirmPass;
        private Label lblNewAccConfirm;
        private PictureBox picBackground;
        private ComboBox comboBox1;
        private Label lblOptLang;
    }
}
