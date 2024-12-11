namespace MirageMUD_Client.Source.Forms
{
    partial class frmAccount
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAccount));
            pnlNewChar = new Panel();
            pnlClass = new FlowLayoutPanel();
            optClassBerserker = new RadioButton();
            optClassPacifist = new RadioButton();
            optClassPaladin = new RadioButton();
            optClassFighter = new RadioButton();
            optClassMage = new RadioButton();
            optClassCleric = new RadioButton();
            optClassDruid = new RadioButton();
            optClassRanger = new RadioButton();
            optClassThief = new RadioButton();
            pnlRace = new FlowLayoutPanel();
            optRaceDwarf = new RadioButton();
            optRaceElf = new RadioButton();
            optRaceHuman = new RadioButton();
            optRaceGnome = new RadioButton();
            optRaceHalfling = new RadioButton();
            optRaceHalfElf = new RadioButton();
            optRaceHalfOrc = new RadioButton();
            pnlRoller = new Panel();
            btnReroll = new Button();
            lblstat_Cha = new Label();
            lblstat_Wis = new Label();
            lblstat_Con = new Label();
            lblstat_Dex = new Label();
            lblstat_Int = new Label();
            lblstat_Str = new Label();
            label12 = new Label();
            label11 = new Label();
            label10 = new Label();
            label9 = new Label();
            label8 = new Label();
            label7 = new Label();
            label4 = new Label();
            btnNewCharCreate = new Button();
            label3 = new Label();
            picNewCharAvatar = new PictureBox();
            optFemale = new RadioButton();
            optMale = new RadioButton();
            label1 = new Label();
            btnNewCharCancel = new Button();
            txtNewCharName = new TextBox();
            label5 = new Label();
            label6 = new Label();
            pnlCharacters = new Panel();
            btnDeleteChar = new Button();
            btnNewChar = new Button();
            btnUseChar = new Button();
            btnCharsCancel = new Button();
            picCharsAvatar = new PictureBox();
            lstCharacters = new ListBox();
            label19 = new Label();
            pnlNewChar.SuspendLayout();
            pnlClass.SuspendLayout();
            pnlRace.SuspendLayout();
            pnlRoller.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picNewCharAvatar).BeginInit();
            pnlCharacters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picCharsAvatar).BeginInit();
            SuspendLayout();
            // 
            // pnlNewChar
            // 
            pnlNewChar.BackColor = Color.FromArgb(65, 65, 65);
            pnlNewChar.BackgroundImageLayout = ImageLayout.None;
            pnlNewChar.Controls.Add(pnlClass);
            pnlNewChar.Controls.Add(pnlRace);
            pnlNewChar.Controls.Add(pnlRoller);
            pnlNewChar.Controls.Add(btnNewCharCreate);
            pnlNewChar.Controls.Add(label3);
            pnlNewChar.Controls.Add(picNewCharAvatar);
            pnlNewChar.Controls.Add(optFemale);
            pnlNewChar.Controls.Add(optMale);
            pnlNewChar.Controls.Add(label1);
            pnlNewChar.Controls.Add(btnNewCharCancel);
            pnlNewChar.Controls.Add(txtNewCharName);
            pnlNewChar.Controls.Add(label5);
            pnlNewChar.Controls.Add(label6);
            pnlNewChar.Location = new Point(424, 9);
            pnlNewChar.Name = "pnlNewChar";
            pnlNewChar.Size = new Size(406, 384);
            pnlNewChar.TabIndex = 28;
            // 
            // pnlClass
            // 
            pnlClass.BackColor = Color.FromArgb(55, 55, 55);
            pnlClass.Controls.Add(optClassBerserker);
            pnlClass.Controls.Add(optClassPacifist);
            pnlClass.Controls.Add(optClassPaladin);
            pnlClass.Controls.Add(optClassFighter);
            pnlClass.Controls.Add(optClassMage);
            pnlClass.Controls.Add(optClassCleric);
            pnlClass.Controls.Add(optClassDruid);
            pnlClass.Controls.Add(optClassRanger);
            pnlClass.Controls.Add(optClassThief);
            pnlClass.Location = new Point(36, 226);
            pnlClass.Name = "pnlClass";
            pnlClass.Size = new Size(198, 118);
            pnlClass.TabIndex = 41;
            // 
            // optClassBerserker
            // 
            optClassBerserker.AutoSize = true;
            optClassBerserker.Checked = true;
            optClassBerserker.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            optClassBerserker.ForeColor = Color.White;
            optClassBerserker.Location = new Point(3, 3);
            optClassBerserker.Name = "optClassBerserker";
            optClassBerserker.Size = new Size(83, 21);
            optClassBerserker.TabIndex = 20;
            optClassBerserker.TabStop = true;
            optClassBerserker.Text = "Berserker";
            optClassBerserker.UseVisualStyleBackColor = true;
            // 
            // optClassPacifist
            // 
            optClassPacifist.AutoSize = true;
            optClassPacifist.Enabled = false;
            optClassPacifist.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            optClassPacifist.ForeColor = Color.White;
            optClassPacifist.Location = new Point(92, 3);
            optClassPacifist.Name = "optClassPacifist";
            optClassPacifist.Size = new Size(68, 21);
            optClassPacifist.TabIndex = 21;
            optClassPacifist.Text = "Pacifist";
            optClassPacifist.UseVisualStyleBackColor = true;
            // 
            // optClassPaladin
            // 
            optClassPaladin.AutoSize = true;
            optClassPaladin.Enabled = false;
            optClassPaladin.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            optClassPaladin.ForeColor = Color.White;
            optClassPaladin.Location = new Point(3, 30);
            optClassPaladin.Name = "optClassPaladin";
            optClassPaladin.Size = new Size(70, 21);
            optClassPaladin.TabIndex = 22;
            optClassPaladin.Text = "Paladin";
            optClassPaladin.UseVisualStyleBackColor = true;
            // 
            // optClassFighter
            // 
            optClassFighter.AutoSize = true;
            optClassFighter.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            optClassFighter.ForeColor = Color.White;
            optClassFighter.Location = new Point(79, 30);
            optClassFighter.Name = "optClassFighter";
            optClassFighter.Size = new Size(69, 21);
            optClassFighter.TabIndex = 23;
            optClassFighter.Text = "Fighter";
            optClassFighter.UseVisualStyleBackColor = true;
            // 
            // optClassMage
            // 
            optClassMage.AutoSize = true;
            optClassMage.Enabled = false;
            optClassMage.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            optClassMage.ForeColor = Color.White;
            optClassMage.Location = new Point(3, 57);
            optClassMage.Name = "optClassMage";
            optClassMage.Size = new Size(60, 21);
            optClassMage.TabIndex = 24;
            optClassMage.Text = "Mage";
            optClassMage.UseVisualStyleBackColor = true;
            // 
            // optClassCleric
            // 
            optClassCleric.AutoSize = true;
            optClassCleric.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            optClassCleric.ForeColor = Color.White;
            optClassCleric.Location = new Point(69, 57);
            optClassCleric.Name = "optClassCleric";
            optClassCleric.Size = new Size(58, 21);
            optClassCleric.TabIndex = 25;
            optClassCleric.Text = "Cleric";
            optClassCleric.UseVisualStyleBackColor = true;
            // 
            // optClassDruid
            // 
            optClassDruid.AutoSize = true;
            optClassDruid.Enabled = false;
            optClassDruid.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            optClassDruid.ForeColor = Color.White;
            optClassDruid.Location = new Point(133, 57);
            optClassDruid.Name = "optClassDruid";
            optClassDruid.Size = new Size(59, 21);
            optClassDruid.TabIndex = 26;
            optClassDruid.Text = "Druid";
            optClassDruid.UseVisualStyleBackColor = true;
            // 
            // optClassRanger
            // 
            optClassRanger.AutoSize = true;
            optClassRanger.Enabled = false;
            optClassRanger.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            optClassRanger.ForeColor = Color.White;
            optClassRanger.Location = new Point(3, 84);
            optClassRanger.Name = "optClassRanger";
            optClassRanger.Size = new Size(69, 21);
            optClassRanger.TabIndex = 27;
            optClassRanger.Text = "Ranger";
            optClassRanger.UseVisualStyleBackColor = true;
            // 
            // optClassThief
            // 
            optClassThief.AutoSize = true;
            optClassThief.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            optClassThief.ForeColor = Color.White;
            optClassThief.Location = new Point(78, 84);
            optClassThief.Name = "optClassThief";
            optClassThief.Size = new Size(55, 21);
            optClassThief.TabIndex = 28;
            optClassThief.Text = "Thief";
            optClassThief.UseVisualStyleBackColor = true;
            // 
            // pnlRace
            // 
            pnlRace.BackColor = Color.FromArgb(55, 55, 55);
            pnlRace.Controls.Add(optRaceDwarf);
            pnlRace.Controls.Add(optRaceElf);
            pnlRace.Controls.Add(optRaceHuman);
            pnlRace.Controls.Add(optRaceGnome);
            pnlRace.Controls.Add(optRaceHalfling);
            pnlRace.Controls.Add(optRaceHalfElf);
            pnlRace.Controls.Add(optRaceHalfOrc);
            pnlRace.Location = new Point(36, 114);
            pnlRace.Name = "pnlRace";
            pnlRace.Size = new Size(198, 88);
            pnlRace.TabIndex = 40;
            // 
            // optRaceDwarf
            // 
            optRaceDwarf.AutoSize = true;
            optRaceDwarf.Checked = true;
            optRaceDwarf.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            optRaceDwarf.ForeColor = Color.White;
            optRaceDwarf.Location = new Point(3, 3);
            optRaceDwarf.Name = "optRaceDwarf";
            optRaceDwarf.Size = new Size(61, 21);
            optRaceDwarf.TabIndex = 20;
            optRaceDwarf.TabStop = true;
            optRaceDwarf.Text = "Dwarf";
            optRaceDwarf.UseVisualStyleBackColor = true;
            // 
            // optRaceElf
            // 
            optRaceElf.AutoSize = true;
            optRaceElf.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            optRaceElf.ForeColor = Color.White;
            optRaceElf.Location = new Point(70, 3);
            optRaceElf.Name = "optRaceElf";
            optRaceElf.Size = new Size(40, 21);
            optRaceElf.TabIndex = 21;
            optRaceElf.Text = "Elf";
            optRaceElf.UseVisualStyleBackColor = true;
            // 
            // optRaceHuman
            // 
            optRaceHuman.AutoSize = true;
            optRaceHuman.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            optRaceHuman.ForeColor = Color.White;
            optRaceHuman.Location = new Point(116, 3);
            optRaceHuman.Name = "optRaceHuman";
            optRaceHuman.Size = new Size(71, 21);
            optRaceHuman.TabIndex = 22;
            optRaceHuman.Text = "Human";
            optRaceHuman.UseVisualStyleBackColor = true;
            // 
            // optRaceGnome
            // 
            optRaceGnome.AutoSize = true;
            optRaceGnome.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            optRaceGnome.ForeColor = Color.White;
            optRaceGnome.Location = new Point(3, 30);
            optRaceGnome.Name = "optRaceGnome";
            optRaceGnome.Size = new Size(70, 21);
            optRaceGnome.TabIndex = 23;
            optRaceGnome.Text = "Gnome";
            optRaceGnome.UseVisualStyleBackColor = true;
            // 
            // optRaceHalfling
            // 
            optRaceHalfling.AutoSize = true;
            optRaceHalfling.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            optRaceHalfling.ForeColor = Color.White;
            optRaceHalfling.Location = new Point(79, 30);
            optRaceHalfling.Name = "optRaceHalfling";
            optRaceHalfling.Size = new Size(72, 21);
            optRaceHalfling.TabIndex = 24;
            optRaceHalfling.Text = "Halfling";
            optRaceHalfling.UseVisualStyleBackColor = true;
            // 
            // optRaceHalfElf
            // 
            optRaceHalfElf.AutoSize = true;
            optRaceHalfElf.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            optRaceHalfElf.ForeColor = Color.White;
            optRaceHalfElf.Location = new Point(3, 57);
            optRaceHalfElf.Name = "optRaceHalfElf";
            optRaceHalfElf.Size = new Size(68, 21);
            optRaceHalfElf.TabIndex = 25;
            optRaceHalfElf.Text = "Half-Elf";
            optRaceHalfElf.UseVisualStyleBackColor = true;
            // 
            // optRaceHalfOrc
            // 
            optRaceHalfOrc.AutoSize = true;
            optRaceHalfOrc.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            optRaceHalfOrc.ForeColor = Color.White;
            optRaceHalfOrc.Location = new Point(77, 57);
            optRaceHalfOrc.Name = "optRaceHalfOrc";
            optRaceHalfOrc.Size = new Size(75, 21);
            optRaceHalfOrc.TabIndex = 26;
            optRaceHalfOrc.Text = "Half-Orc";
            optRaceHalfOrc.UseVisualStyleBackColor = true;
            // 
            // pnlRoller
            // 
            pnlRoller.BackColor = Color.FromArgb(55, 55, 55);
            pnlRoller.Controls.Add(btnReroll);
            pnlRoller.Controls.Add(lblstat_Cha);
            pnlRoller.Controls.Add(lblstat_Wis);
            pnlRoller.Controls.Add(lblstat_Con);
            pnlRoller.Controls.Add(lblstat_Dex);
            pnlRoller.Controls.Add(lblstat_Int);
            pnlRoller.Controls.Add(lblstat_Str);
            pnlRoller.Controls.Add(label12);
            pnlRoller.Controls.Add(label11);
            pnlRoller.Controls.Add(label10);
            pnlRoller.Controls.Add(label9);
            pnlRoller.Controls.Add(label8);
            pnlRoller.Controls.Add(label7);
            pnlRoller.Controls.Add(label4);
            pnlRoller.Location = new Point(240, 114);
            pnlRoller.Name = "pnlRoller";
            pnlRoller.Size = new Size(154, 170);
            pnlRoller.TabIndex = 39;
            // 
            // btnReroll
            // 
            btnReroll.BackColor = Color.FromArgb(45, 45, 45);
            btnReroll.BackgroundImageLayout = ImageLayout.None;
            btnReroll.FlatAppearance.BorderSize = 0;
            btnReroll.FlatStyle = FlatStyle.Flat;
            btnReroll.Font = new Font("Nirmala UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnReroll.ForeColor = Color.Silver;
            btnReroll.ImageAlign = ContentAlignment.MiddleLeft;
            btnReroll.Location = new Point(7, 138);
            btnReroll.Name = "btnReroll";
            btnReroll.Size = new Size(139, 25);
            btnReroll.TabIndex = 51;
            btnReroll.Text = "Reroll";
            btnReroll.UseVisualStyleBackColor = false;
            btnReroll.Click += btnReroll_Click;
            // 
            // lblstat_Cha
            // 
            lblstat_Cha.BackColor = Color.Transparent;
            lblstat_Cha.Font = new Font("Verdana", 9F, FontStyle.Bold);
            lblstat_Cha.ForeColor = Color.Goldenrod;
            lblstat_Cha.Location = new Point(108, 114);
            lblstat_Cha.Name = "lblstat_Cha";
            lblstat_Cha.Size = new Size(38, 18);
            lblstat_Cha.TabIndex = 50;
            lblstat_Cha.Text = "2";
            lblstat_Cha.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblstat_Wis
            // 
            lblstat_Wis.BackColor = Color.Transparent;
            lblstat_Wis.Font = new Font("Verdana", 9F, FontStyle.Bold);
            lblstat_Wis.ForeColor = Color.Goldenrod;
            lblstat_Wis.Location = new Point(108, 96);
            lblstat_Wis.Name = "lblstat_Wis";
            lblstat_Wis.Size = new Size(38, 18);
            lblstat_Wis.TabIndex = 49;
            lblstat_Wis.Text = "2";
            lblstat_Wis.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblstat_Con
            // 
            lblstat_Con.BackColor = Color.Transparent;
            lblstat_Con.Font = new Font("Verdana", 9F, FontStyle.Bold);
            lblstat_Con.ForeColor = Color.Goldenrod;
            lblstat_Con.Location = new Point(108, 78);
            lblstat_Con.Name = "lblstat_Con";
            lblstat_Con.Size = new Size(38, 18);
            lblstat_Con.TabIndex = 48;
            lblstat_Con.Text = "2";
            lblstat_Con.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblstat_Dex
            // 
            lblstat_Dex.BackColor = Color.Transparent;
            lblstat_Dex.Font = new Font("Verdana", 9F, FontStyle.Bold);
            lblstat_Dex.ForeColor = Color.Goldenrod;
            lblstat_Dex.Location = new Point(108, 60);
            lblstat_Dex.Name = "lblstat_Dex";
            lblstat_Dex.Size = new Size(38, 18);
            lblstat_Dex.TabIndex = 47;
            lblstat_Dex.Text = "2";
            lblstat_Dex.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblstat_Int
            // 
            lblstat_Int.BackColor = Color.Transparent;
            lblstat_Int.Font = new Font("Verdana", 9F, FontStyle.Bold);
            lblstat_Int.ForeColor = Color.Goldenrod;
            lblstat_Int.Location = new Point(108, 44);
            lblstat_Int.Name = "lblstat_Int";
            lblstat_Int.Size = new Size(38, 18);
            lblstat_Int.TabIndex = 46;
            lblstat_Int.Text = "2";
            lblstat_Int.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblstat_Str
            // 
            lblstat_Str.BackColor = Color.Transparent;
            lblstat_Str.Font = new Font("Verdana", 9F, FontStyle.Bold);
            lblstat_Str.ForeColor = Color.Goldenrod;
            lblstat_Str.Location = new Point(108, 26);
            lblstat_Str.Name = "lblstat_Str";
            lblstat_Str.Size = new Size(38, 18);
            lblstat_Str.TabIndex = 45;
            lblstat_Str.Text = "2";
            lblstat_Str.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label12
            // 
            label12.BackColor = Color.Transparent;
            label12.Font = new Font("Verdana", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label12.ForeColor = Color.White;
            label12.Location = new Point(7, 114);
            label12.Name = "label12";
            label12.Size = new Size(95, 18);
            label12.TabIndex = 44;
            label12.Text = "Charisma";
            label12.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label11
            // 
            label11.BackColor = Color.Transparent;
            label11.Font = new Font("Verdana", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label11.ForeColor = Color.White;
            label11.Location = new Point(7, 96);
            label11.Name = "label11";
            label11.Size = new Size(95, 18);
            label11.TabIndex = 43;
            label11.Text = "Wisdom:";
            label11.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label10
            // 
            label10.BackColor = Color.Transparent;
            label10.Font = new Font("Verdana", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label10.ForeColor = Color.White;
            label10.Location = new Point(7, 78);
            label10.Name = "label10";
            label10.Size = new Size(95, 18);
            label10.TabIndex = 42;
            label10.Text = "Constitution:";
            label10.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            label9.BackColor = Color.Transparent;
            label9.Font = new Font("Verdana", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label9.ForeColor = Color.White;
            label9.Location = new Point(7, 60);
            label9.Name = "label9";
            label9.Size = new Size(95, 18);
            label9.TabIndex = 41;
            label9.Text = "Dexterity:";
            label9.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            label8.BackColor = Color.Transparent;
            label8.Font = new Font("Verdana", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.ForeColor = Color.White;
            label8.Location = new Point(7, 44);
            label8.Name = "label8";
            label8.Size = new Size(95, 18);
            label8.TabIndex = 40;
            label8.Text = "Intelligence:";
            label8.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            label7.BackColor = Color.Transparent;
            label7.Font = new Font("Verdana", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.ForeColor = Color.White;
            label7.Location = new Point(7, 26);
            label7.Name = "label7";
            label7.Size = new Size(95, 18);
            label7.TabIndex = 39;
            label7.Text = "Strength:";
            label7.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Verdana", 9F, FontStyle.Bold);
            label4.ForeColor = Color.White;
            label4.Location = new Point(7, 6);
            label4.Name = "label4";
            label4.Size = new Size(130, 18);
            label4.TabIndex = 38;
            label4.Text = "Base Stat Roller";
            label4.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btnNewCharCreate
            // 
            btnNewCharCreate.BackColor = Color.FromArgb(45, 45, 45);
            btnNewCharCreate.BackgroundImageLayout = ImageLayout.None;
            btnNewCharCreate.FlatAppearance.BorderSize = 0;
            btnNewCharCreate.FlatStyle = FlatStyle.Flat;
            btnNewCharCreate.Font = new Font("Nirmala UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnNewCharCreate.ForeColor = Color.Silver;
            btnNewCharCreate.ImageAlign = ContentAlignment.MiddleLeft;
            btnNewCharCreate.Location = new Point(239, 298);
            btnNewCharCreate.Name = "btnNewCharCreate";
            btnNewCharCreate.Size = new Size(155, 34);
            btnNewCharCreate.TabIndex = 38;
            btnNewCharCreate.Text = "Create";
            btnNewCharCreate.UseVisualStyleBackColor = false;
            btnNewCharCreate.Click += btnNewCharCreate_Click;
            // 
            // label3
            // 
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Verdana", 9F, FontStyle.Bold);
            label3.ForeColor = Color.White;
            label3.Location = new Point(36, 205);
            label3.Name = "label3";
            label3.Size = new Size(103, 18);
            label3.TabIndex = 22;
            label3.Text = "Class:";
            label3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // picNewCharAvatar
            // 
            picNewCharAvatar.BackgroundImageLayout = ImageLayout.Stretch;
            picNewCharAvatar.BorderStyle = BorderStyle.FixedSingle;
            picNewCharAvatar.Image = (Image)resources.GetObject("picNewCharAvatar.Image");
            picNewCharAvatar.Location = new Point(322, 18);
            picNewCharAvatar.Name = "picNewCharAvatar";
            picNewCharAvatar.Size = new Size(72, 72);
            picNewCharAvatar.SizeMode = PictureBoxSizeMode.StretchImage;
            picNewCharAvatar.TabIndex = 21;
            picNewCharAvatar.TabStop = false;
            // 
            // optFemale
            // 
            optFemale.AutoSize = true;
            optFemale.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            optFemale.ForeColor = Color.White;
            optFemale.Location = new Point(97, 350);
            optFemale.Name = "optFemale";
            optFemale.Size = new Size(69, 21);
            optFemale.TabIndex = 20;
            optFemale.TabStop = true;
            optFemale.Text = "Female";
            optFemale.UseVisualStyleBackColor = true;
            // 
            // optMale
            // 
            optMale.AutoSize = true;
            optMale.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            optMale.ForeColor = Color.White;
            optMale.Location = new Point(36, 350);
            optMale.Name = "optMale";
            optMale.Size = new Size(55, 21);
            optMale.TabIndex = 19;
            optMale.TabStop = true;
            optMale.Text = "Male";
            optMale.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Verdana", 9F, FontStyle.Bold);
            label1.ForeColor = Color.White;
            label1.Location = new Point(36, 93);
            label1.Name = "label1";
            label1.Size = new Size(103, 18);
            label1.TabIndex = 17;
            label1.Text = "Race:";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btnNewCharCancel
            // 
            btnNewCharCancel.BackColor = Color.FromArgb(45, 45, 45);
            btnNewCharCancel.BackgroundImageLayout = ImageLayout.None;
            btnNewCharCancel.FlatAppearance.BorderSize = 0;
            btnNewCharCancel.FlatStyle = FlatStyle.Flat;
            btnNewCharCancel.Font = new Font("Nirmala UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnNewCharCancel.ForeColor = Color.Silver;
            btnNewCharCancel.ImageAlign = ContentAlignment.MiddleLeft;
            btnNewCharCancel.Location = new Point(239, 338);
            btnNewCharCancel.Name = "btnNewCharCancel";
            btnNewCharCancel.Size = new Size(155, 34);
            btnNewCharCancel.TabIndex = 16;
            btnNewCharCancel.Text = "Cancel";
            btnNewCharCancel.UseVisualStyleBackColor = false;
            btnNewCharCancel.Click += btnNewCharCancel_Click;
            // 
            // txtNewCharName
            // 
            txtNewCharName.Location = new Point(36, 67);
            txtNewCharName.Name = "txtNewCharName";
            txtNewCharName.Size = new Size(276, 23);
            txtNewCharName.TabIndex = 9;
            // 
            // label5
            // 
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Verdana", 9F, FontStyle.Bold);
            label5.ForeColor = Color.White;
            label5.Location = new Point(36, 46);
            label5.Name = "label5";
            label5.Size = new Size(75, 18);
            label5.TabIndex = 3;
            label5.Text = "Name:";
            label5.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            label6.BackColor = Color.Transparent;
            label6.Dock = DockStyle.Top;
            label6.Font = new Font("Verdana", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.White;
            label6.Location = new Point(0, 0);
            label6.Name = "label6";
            label6.Size = new Size(406, 34);
            label6.TabIndex = 0;
            label6.Text = "New Character";
            label6.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlCharacters
            // 
            pnlCharacters.BackColor = Color.FromArgb(65, 65, 65);
            pnlCharacters.BackgroundImageLayout = ImageLayout.None;
            pnlCharacters.Controls.Add(btnDeleteChar);
            pnlCharacters.Controls.Add(btnNewChar);
            pnlCharacters.Controls.Add(btnUseChar);
            pnlCharacters.Controls.Add(btnCharsCancel);
            pnlCharacters.Controls.Add(picCharsAvatar);
            pnlCharacters.Controls.Add(lstCharacters);
            pnlCharacters.Controls.Add(label19);
            pnlCharacters.Location = new Point(12, 9);
            pnlCharacters.Name = "pnlCharacters";
            pnlCharacters.Size = new Size(406, 384);
            pnlCharacters.TabIndex = 29;
            // 
            // btnDeleteChar
            // 
            btnDeleteChar.BackColor = Color.FromArgb(45, 45, 45);
            btnDeleteChar.BackgroundImageLayout = ImageLayout.None;
            btnDeleteChar.FlatAppearance.BorderSize = 0;
            btnDeleteChar.FlatStyle = FlatStyle.Flat;
            btnDeleteChar.Font = new Font("Nirmala UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDeleteChar.ForeColor = Color.Silver;
            btnDeleteChar.ImageAlign = ContentAlignment.MiddleLeft;
            btnDeleteChar.Location = new Point(107, 265);
            btnDeleteChar.Name = "btnDeleteChar";
            btnDeleteChar.Size = new Size(190, 34);
            btnDeleteChar.TabIndex = 15;
            btnDeleteChar.Text = "Delete Character";
            btnDeleteChar.UseVisualStyleBackColor = false;
            btnDeleteChar.Click += btnDeleteChar_Click;
            // 
            // btnNewChar
            // 
            btnNewChar.BackColor = Color.FromArgb(45, 45, 45);
            btnNewChar.BackgroundImageLayout = ImageLayout.None;
            btnNewChar.FlatAppearance.BorderSize = 0;
            btnNewChar.FlatStyle = FlatStyle.Flat;
            btnNewChar.Font = new Font("Nirmala UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnNewChar.ForeColor = Color.Silver;
            btnNewChar.ImageAlign = ContentAlignment.MiddleLeft;
            btnNewChar.Location = new Point(107, 225);
            btnNewChar.Name = "btnNewChar";
            btnNewChar.Size = new Size(190, 34);
            btnNewChar.TabIndex = 14;
            btnNewChar.Text = "New Character";
            btnNewChar.UseVisualStyleBackColor = false;
            btnNewChar.Click += btnNewChar_Click;
            // 
            // btnUseChar
            // 
            btnUseChar.BackColor = Color.FromArgb(45, 45, 45);
            btnUseChar.BackgroundImageLayout = ImageLayout.None;
            btnUseChar.FlatAppearance.BorderSize = 0;
            btnUseChar.FlatStyle = FlatStyle.Flat;
            btnUseChar.Font = new Font("Nirmala UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnUseChar.ForeColor = Color.Silver;
            btnUseChar.ImageAlign = ContentAlignment.MiddleLeft;
            btnUseChar.Location = new Point(107, 185);
            btnUseChar.Name = "btnUseChar";
            btnUseChar.Size = new Size(190, 34);
            btnUseChar.TabIndex = 13;
            btnUseChar.Text = "Use Character";
            btnUseChar.UseVisualStyleBackColor = false;
            btnUseChar.Click += btnUseChar_Click;
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
            // frmAccount
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(837, 409);
            Controls.Add(pnlCharacters);
            Controls.Add(pnlNewChar);
            Name = "frmAccount";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmAccount";
            pnlNewChar.ResumeLayout(false);
            pnlNewChar.PerformLayout();
            pnlClass.ResumeLayout(false);
            pnlClass.PerformLayout();
            pnlRace.ResumeLayout(false);
            pnlRace.PerformLayout();
            pnlRoller.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picNewCharAvatar).EndInit();
            pnlCharacters.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picCharsAvatar).EndInit();
            ResumeLayout(false);
        }

        #endregion

        public Panel pnlNewChar;
        private FlowLayoutPanel pnlClass;
        public RadioButton optClassBerserker;
        public RadioButton optClassPacifist;
        public RadioButton optClassPaladin;
        public RadioButton optClassFighter;
        public RadioButton optClassMage;
        public RadioButton optClassCleric;
        public RadioButton optClassDruid;
        public RadioButton optClassRanger;
        public RadioButton optClassThief;
        private FlowLayoutPanel pnlRace;
        public RadioButton optRaceDwarf;
        public RadioButton optRaceElf;
        public RadioButton optRaceHuman;
        public RadioButton optRaceGnome;
        public RadioButton optRaceHalfling;
        public RadioButton optRaceHalfElf;
        public RadioButton optRaceHalfOrc;
        private Panel pnlRoller;
        private Button btnReroll;
        public Label lblstat_Cha;
        public Label lblstat_Wis;
        public Label lblstat_Con;
        public Label lblstat_Dex;
        public Label lblstat_Int;
        public Label lblstat_Str;
        private Label label12;
        private Label label11;
        private Label label10;
        private Label label9;
        private Label label8;
        private Label label7;
        private Label label4;
        private Button btnNewCharCreate;
        private Label label3;
        private PictureBox picNewCharAvatar;
        public RadioButton optFemale;
        public RadioButton optMale;
        private Label label1;
        private Button btnNewCharCancel;
        public TextBox txtNewCharName;
        private Label label5;
        private Label label6;
        public Panel pnlCharacters;
        private Button btnDeleteChar;
        private Button btnNewChar;
        private Button btnUseChar;
        private Button btnCharsCancel;
        private PictureBox picCharsAvatar;
        public ListBox lstCharacters;
        private Label label19;
    }
}