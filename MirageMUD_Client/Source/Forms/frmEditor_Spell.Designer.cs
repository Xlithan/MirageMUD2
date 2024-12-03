namespace MirageMUD_WFClient
{
    partial class frmEditor_Spell
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEditor_Spell));
            lstSpells = new ListBox();
            txtItemName = new TextBox();
            label38 = new Label();
            cmbClassReq = new ComboBox();
            label1 = new Label();
            pnlVitalsData = new Panel();
            hScrollBar1 = new HScrollBar();
            label4 = new Label();
            lblVitalMod = new Label();
            lblSpellID = new Label();
            scrlSpellID = new HScrollBar();
            label6 = new Label();
            label12 = new Label();
            panel1 = new Panel();
            hScrollBar2 = new HScrollBar();
            label2 = new Label();
            label3 = new Label();
            label5 = new Label();
            hScrollBar3 = new HScrollBar();
            label7 = new Label();
            label8 = new Label();
            pictureBox1 = new PictureBox();
            cmbType = new ComboBox();
            panel2 = new Panel();
            hScrollBar4 = new HScrollBar();
            label9 = new Label();
            label10 = new Label();
            label11 = new Label();
            hScrollBar5 = new HScrollBar();
            label13 = new Label();
            label14 = new Label();
            panel3 = new Panel();
            hScrollBar6 = new HScrollBar();
            label15 = new Label();
            label16 = new Label();
            label19 = new Label();
            button1 = new Button();
            button2 = new Button();
            pnlVitalsData.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // lstSpells
            // 
            lstSpells.BorderStyle = BorderStyle.FixedSingle;
            lstSpells.Dock = DockStyle.Left;
            lstSpells.FormattingEnabled = true;
            lstSpells.ItemHeight = 15;
            lstSpells.Location = new Point(0, 0);
            lstSpells.Name = "lstSpells";
            lstSpells.Size = new Size(156, 487);
            lstSpells.TabIndex = 2;
            // 
            // txtItemName
            // 
            txtItemName.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtItemName.Location = new Point(162, 30);
            txtItemName.Name = "txtItemName";
            txtItemName.Size = new Size(249, 23);
            txtItemName.TabIndex = 14;
            // 
            // label38
            // 
            label38.BackColor = Color.Transparent;
            label38.Font = new Font("Verdana", 9F, FontStyle.Bold);
            label38.ForeColor = Color.Black;
            label38.Location = new Point(162, 9);
            label38.Name = "label38";
            label38.Size = new Size(75, 18);
            label38.TabIndex = 13;
            label38.Text = "Name:";
            label38.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // cmbClassReq
            // 
            cmbClassReq.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbClassReq.FormattingEnabled = true;
            cmbClassReq.Items.AddRange(new object[] { "None", "Weapon", "Armor", "Helmet", "Shield", "Potion Add HP", "Potion Add MP", "Potion Add SP", "Potion Sub HP", "Potion Sub MP", "Potion Sub SP", "Currency", "Spell" });
            cmbClassReq.Location = new Point(162, 77);
            cmbClassReq.Name = "cmbClassReq";
            cmbClassReq.Size = new Size(303, 23);
            cmbClassReq.TabIndex = 15;
            // 
            // label1
            // 
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Verdana", 9F, FontStyle.Bold);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(162, 56);
            label1.Name = "label1";
            label1.Size = new Size(85, 18);
            label1.TabIndex = 16;
            label1.Text = "Class Req:";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pnlVitalsData
            // 
            pnlVitalsData.BackColor = SystemColors.ControlLight;
            pnlVitalsData.Controls.Add(hScrollBar1);
            pnlVitalsData.Controls.Add(label4);
            pnlVitalsData.Controls.Add(lblVitalMod);
            pnlVitalsData.Controls.Add(lblSpellID);
            pnlVitalsData.Controls.Add(scrlSpellID);
            pnlVitalsData.Controls.Add(label6);
            pnlVitalsData.Controls.Add(label12);
            pnlVitalsData.Location = new Point(162, 106);
            pnlVitalsData.Name = "pnlVitalsData";
            pnlVitalsData.Size = new Size(311, 100);
            pnlVitalsData.TabIndex = 18;
            pnlVitalsData.Visible = false;
            // 
            // hScrollBar1
            // 
            hScrollBar1.LargeChange = 1;
            hScrollBar1.Location = new Point(71, 26);
            hScrollBar1.Maximum = 20;
            hScrollBar1.Minimum = 1;
            hScrollBar1.Name = "hScrollBar1";
            hScrollBar1.Size = new Size(187, 18);
            hScrollBar1.TabIndex = 28;
            hScrollBar1.Value = 1;
            // 
            // label4
            // 
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Verdana", 9F, FontStyle.Bold);
            label4.ForeColor = Color.Black;
            label4.Location = new Point(4, 26);
            label4.Name = "label4";
            label4.Size = new Size(61, 18);
            label4.TabIndex = 22;
            label4.Text = "Level:";
            label4.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblVitalMod
            // 
            lblVitalMod.BackColor = Color.Transparent;
            lblVitalMod.Font = new Font("Verdana", 9F, FontStyle.Bold);
            lblVitalMod.ForeColor = Color.Black;
            lblVitalMod.Location = new Point(261, 26);
            lblVitalMod.Name = "lblVitalMod";
            lblVitalMod.Size = new Size(46, 18);
            lblVitalMod.TabIndex = 26;
            lblVitalMod.Text = "1";
            lblVitalMod.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblSpellID
            // 
            lblSpellID.BackColor = Color.Transparent;
            lblSpellID.Font = new Font("Verdana", 9F, FontStyle.Bold);
            lblSpellID.ForeColor = Color.Black;
            lblSpellID.Location = new Point(261, 56);
            lblSpellID.Name = "lblSpellID";
            lblSpellID.Size = new Size(46, 18);
            lblSpellID.TabIndex = 27;
            lblSpellID.Text = "0";
            lblSpellID.TextAlign = ContentAlignment.MiddleRight;
            // 
            // scrlSpellID
            // 
            scrlSpellID.LargeChange = 1;
            scrlSpellID.Location = new Point(71, 56);
            scrlSpellID.Maximum = 20;
            scrlSpellID.Name = "scrlSpellID";
            scrlSpellID.Size = new Size(187, 18);
            scrlSpellID.TabIndex = 25;
            // 
            // label6
            // 
            label6.BackColor = Color.Transparent;
            label6.Font = new Font("Verdana", 9F, FontStyle.Bold);
            label6.ForeColor = Color.Black;
            label6.Location = new Point(4, 56);
            label6.Name = "label6";
            label6.Size = new Size(61, 18);
            label6.TabIndex = 24;
            label6.Text = "MP:";
            label6.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label12
            // 
            label12.BackColor = Color.Transparent;
            label12.Font = new Font("Verdana", 9F, FontStyle.Bold);
            label12.ForeColor = Color.Teal;
            label12.Location = new Point(3, 0);
            label12.Name = "label12";
            label12.Size = new Size(87, 18);
            label12.TabIndex = 16;
            label12.Text = "Data";
            label12.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ControlLight;
            panel1.Controls.Add(hScrollBar2);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(hScrollBar3);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(label8);
            panel1.Location = new Point(162, 212);
            panel1.Name = "panel1";
            panel1.Size = new Size(311, 100);
            panel1.TabIndex = 19;
            panel1.Visible = false;
            // 
            // hScrollBar2
            // 
            hScrollBar2.LargeChange = 1;
            hScrollBar2.Location = new Point(71, 26);
            hScrollBar2.Maximum = 20;
            hScrollBar2.Name = "hScrollBar2";
            hScrollBar2.Size = new Size(187, 18);
            hScrollBar2.TabIndex = 28;
            hScrollBar2.Value = 1;
            // 
            // label2
            // 
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Verdana", 9F, FontStyle.Bold);
            label2.ForeColor = Color.Black;
            label2.Location = new Point(4, 26);
            label2.Name = "label2";
            label2.Size = new Size(61, 18);
            label2.TabIndex = 22;
            label2.Text = "Spell:";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Verdana", 9F, FontStyle.Bold);
            label3.ForeColor = Color.Black;
            label3.Location = new Point(261, 26);
            label3.Name = "label3";
            label3.Size = new Size(46, 18);
            label3.TabIndex = 26;
            label3.Text = "0";
            label3.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Verdana", 9F, FontStyle.Bold);
            label5.ForeColor = Color.Black;
            label5.Location = new Point(261, 56);
            label5.Name = "label5";
            label5.Size = new Size(46, 18);
            label5.TabIndex = 27;
            label5.Text = "0";
            label5.TextAlign = ContentAlignment.MiddleRight;
            // 
            // hScrollBar3
            // 
            hScrollBar3.LargeChange = 1;
            hScrollBar3.Location = new Point(71, 56);
            hScrollBar3.Maximum = 20;
            hScrollBar3.Name = "hScrollBar3";
            hScrollBar3.Size = new Size(187, 18);
            hScrollBar3.TabIndex = 25;
            // 
            // label7
            // 
            label7.BackColor = Color.Transparent;
            label7.Font = new Font("Verdana", 9F, FontStyle.Bold);
            label7.ForeColor = Color.Black;
            label7.Location = new Point(4, 56);
            label7.Name = "label7";
            label7.Size = new Size(61, 18);
            label7.TabIndex = 24;
            label7.Text = "Frame:";
            label7.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            label8.BackColor = Color.Transparent;
            label8.Font = new Font("Verdana", 9F, FontStyle.Bold);
            label8.ForeColor = Color.Teal;
            label8.Location = new Point(3, 0);
            label8.Name = "label8";
            label8.Size = new Size(119, 18);
            label8.TabIndex = 16;
            label8.Text = "Spell Animation";
            label8.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = (Image)resources.GetObject("pictureBox1.BackgroundImage");
            pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox1.Location = new Point(417, 18);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(48, 48);
            pictureBox1.TabIndex = 20;
            pictureBox1.TabStop = false;
            // 
            // cmbType
            // 
            cmbType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbType.FormattingEnabled = true;
            cmbType.Items.AddRange(new object[] { "None", "Weapon", "Armor", "Helmet", "Shield", "Potion Add HP", "Potion Add MP", "Potion Add SP", "Potion Sub HP", "Potion Sub MP", "Potion Sub SP", "Currency", "Spell" });
            cmbType.Location = new Point(162, 318);
            cmbType.Name = "cmbType";
            cmbType.Size = new Size(311, 23);
            cmbType.TabIndex = 21;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.ControlLight;
            panel2.Controls.Add(hScrollBar4);
            panel2.Controls.Add(label9);
            panel2.Controls.Add(label10);
            panel2.Controls.Add(label11);
            panel2.Controls.Add(hScrollBar5);
            panel2.Controls.Add(label13);
            panel2.Controls.Add(label14);
            panel2.Location = new Point(162, 347);
            panel2.Name = "panel2";
            panel2.Size = new Size(311, 100);
            panel2.TabIndex = 22;
            panel2.Visible = false;
            // 
            // hScrollBar4
            // 
            hScrollBar4.LargeChange = 1;
            hScrollBar4.Location = new Point(71, 26);
            hScrollBar4.Maximum = 20;
            hScrollBar4.Minimum = 1;
            hScrollBar4.Name = "hScrollBar4";
            hScrollBar4.Size = new Size(187, 18);
            hScrollBar4.TabIndex = 28;
            hScrollBar4.Value = 1;
            // 
            // label9
            // 
            label9.BackColor = Color.Transparent;
            label9.Font = new Font("Verdana", 9F, FontStyle.Bold);
            label9.ForeColor = Color.Black;
            label9.Location = new Point(4, 26);
            label9.Name = "label9";
            label9.Size = new Size(61, 18);
            label9.TabIndex = 22;
            label9.Text = "Item:";
            label9.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label10
            // 
            label10.BackColor = Color.Transparent;
            label10.Font = new Font("Verdana", 9F, FontStyle.Bold);
            label10.ForeColor = Color.Black;
            label10.Location = new Point(261, 26);
            label10.Name = "label10";
            label10.Size = new Size(46, 18);
            label10.TabIndex = 26;
            label10.Text = "1";
            label10.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label11
            // 
            label11.BackColor = Color.Transparent;
            label11.Font = new Font("Verdana", 9F, FontStyle.Bold);
            label11.ForeColor = Color.Black;
            label11.Location = new Point(261, 56);
            label11.Name = "label11";
            label11.Size = new Size(46, 18);
            label11.TabIndex = 27;
            label11.Text = "0";
            label11.TextAlign = ContentAlignment.MiddleRight;
            // 
            // hScrollBar5
            // 
            hScrollBar5.LargeChange = 1;
            hScrollBar5.Location = new Point(71, 56);
            hScrollBar5.Maximum = 20;
            hScrollBar5.Name = "hScrollBar5";
            hScrollBar5.Size = new Size(187, 18);
            hScrollBar5.TabIndex = 25;
            // 
            // label13
            // 
            label13.BackColor = Color.Transparent;
            label13.Font = new Font("Verdana", 9F, FontStyle.Bold);
            label13.ForeColor = Color.Black;
            label13.Location = new Point(4, 56);
            label13.Name = "label13";
            label13.Size = new Size(61, 18);
            label13.TabIndex = 24;
            label13.Text = "Value:";
            label13.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label14
            // 
            label14.BackColor = Color.Transparent;
            label14.Font = new Font("Verdana", 9F, FontStyle.Bold);
            label14.ForeColor = Color.Teal;
            label14.Location = new Point(3, 0);
            label14.Name = "label14";
            label14.Size = new Size(119, 18);
            label14.TabIndex = 16;
            label14.Text = "Give Item";
            label14.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // panel3
            // 
            panel3.BackColor = SystemColors.ControlLight;
            panel3.Controls.Add(hScrollBar6);
            panel3.Controls.Add(label15);
            panel3.Controls.Add(label16);
            panel3.Controls.Add(label19);
            panel3.Location = new Point(162, 347);
            panel3.Name = "panel3";
            panel3.Size = new Size(311, 100);
            panel3.TabIndex = 23;
            panel3.Visible = false;
            // 
            // hScrollBar6
            // 
            hScrollBar6.LargeChange = 1;
            hScrollBar6.Location = new Point(71, 26);
            hScrollBar6.Maximum = 20;
            hScrollBar6.Minimum = 1;
            hScrollBar6.Name = "hScrollBar6";
            hScrollBar6.Size = new Size(187, 18);
            hScrollBar6.TabIndex = 28;
            hScrollBar6.Value = 1;
            // 
            // label15
            // 
            label15.BackColor = Color.Transparent;
            label15.Font = new Font("Verdana", 9F, FontStyle.Bold);
            label15.ForeColor = Color.Black;
            label15.Location = new Point(4, 26);
            label15.Name = "label15";
            label15.Size = new Size(64, 18);
            label15.TabIndex = 22;
            label15.Text = "Mod:";
            label15.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label16
            // 
            label16.BackColor = Color.Transparent;
            label16.Font = new Font("Verdana", 9F, FontStyle.Bold);
            label16.ForeColor = Color.Black;
            label16.Location = new Point(261, 26);
            label16.Name = "label16";
            label16.Size = new Size(46, 18);
            label16.TabIndex = 26;
            label16.Text = "1";
            label16.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label19
            // 
            label19.BackColor = Color.Transparent;
            label19.Font = new Font("Verdana", 9F, FontStyle.Bold);
            label19.ForeColor = Color.Teal;
            label19.Location = new Point(3, 0);
            label19.Name = "label19";
            label19.Size = new Size(119, 18);
            label19.TabIndex = 16;
            label19.Text = "Vitals Data";
            label19.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // button1
            // 
            button1.FlatStyle = FlatStyle.Flat;
            button1.Location = new Point(335, 453);
            button1.Name = "button1";
            button1.Size = new Size(138, 27);
            button1.TabIndex = 25;
            button1.Text = "Cancel";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.FlatStyle = FlatStyle.Flat;
            button2.Location = new Point(162, 453);
            button2.Name = "button2";
            button2.Size = new Size(138, 27);
            button2.TabIndex = 24;
            button2.Text = "Save";
            button2.UseVisualStyleBackColor = true;
            // 
            // frmEditor_Spell
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(483, 487);
            ControlBox = false;
            Controls.Add(button1);
            Controls.Add(button2);
            Controls.Add(cmbType);
            Controls.Add(pictureBox1);
            Controls.Add(panel1);
            Controls.Add(pnlVitalsData);
            Controls.Add(label1);
            Controls.Add(cmbClassReq);
            Controls.Add(txtItemName);
            Controls.Add(label38);
            Controls.Add(lstSpells);
            Controls.Add(panel3);
            Controls.Add(panel2);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "frmEditor_Spell";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Spell Editor";
            pnlVitalsData.ResumeLayout(false);
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel2.ResumeLayout(false);
            panel3.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox lstSpells;
        private TextBox txtItemName;
        private Label label38;
        private ComboBox cmbClassReq;
        private Label label1;
        private Panel pnlVitalsData;
        private Label label12;
        private HScrollBar hScrollBar1;
        private Label label4;
        private Label lblVitalMod;
        private Label lblSpellID;
        private HScrollBar scrlSpellID;
        private Label label6;
        private Panel panel1;
        private HScrollBar hScrollBar2;
        private Label label2;
        private Label label3;
        private Label label5;
        private HScrollBar hScrollBar3;
        private Label label7;
        private Label label8;
        private PictureBox pictureBox1;
        private ComboBox cmbType;
        private Panel panel2;
        private HScrollBar hScrollBar4;
        private Label label9;
        private Label label10;
        private Label label11;
        private HScrollBar hScrollBar5;
        private Label label13;
        private Label label14;
        private Panel panel3;
        private HScrollBar hScrollBar6;
        private Label label15;
        private Label label16;
        private Label label19;
        private Button button1;
        private Button button2;
    }
}