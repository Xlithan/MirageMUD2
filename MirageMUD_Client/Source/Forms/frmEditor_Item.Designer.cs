namespace MirageMUD_Client
{
    partial class frmEditor_Item
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEditor_Item));
            lstItems = new ListBox();
            scrlPic = new HScrollBar();
            txtItemName = new TextBox();
            label38 = new Label();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            lblPicture = new Label();
            cmbType = new ComboBox();
            label2 = new Label();
            pnlSpellData = new Panel();
            lblSpellID = new Label();
            scrlSpellID = new HScrollBar();
            label6 = new Label();
            lblSpellName = new Label();
            label4 = new Label();
            label3 = new Label();
            pnlVitalsData = new Panel();
            lblVitalMod = new Label();
            scrlVitalMod = new HScrollBar();
            label11 = new Label();
            label12 = new Label();
            pnlEquipData = new Panel();
            scrlDurability = new HScrollBar();
            scrlStrength = new HScrollBar();
            lblDurability = new Label();
            lblStrength = new Label();
            label10 = new Label();
            label14 = new Label();
            label15 = new Label();
            button2 = new Button();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            pnlSpellData.SuspendLayout();
            pnlVitalsData.SuspendLayout();
            pnlEquipData.SuspendLayout();
            SuspendLayout();
            // 
            // lstItems
            // 
            lstItems.BorderStyle = BorderStyle.FixedSingle;
            lstItems.Dock = DockStyle.Left;
            lstItems.FormattingEnabled = true;
            lstItems.ItemHeight = 15;
            lstItems.Location = new Point(0, 0);
            lstItems.Name = "lstItems";
            lstItems.Size = new Size(156, 300);
            lstItems.TabIndex = 0;
            // 
            // scrlPic
            // 
            scrlPic.LargeChange = 1;
            scrlPic.Location = new Point(162, 75);
            scrlPic.Maximum = 20;
            scrlPic.Name = "scrlPic";
            scrlPic.Size = new Size(208, 18);
            scrlPic.TabIndex = 1;
            scrlPic.Scroll += scrlPic_Scroll;
            // 
            // txtItemName
            // 
            txtItemName.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtItemName.Location = new Point(165, 31);
            txtItemName.Name = "txtItemName";
            txtItemName.Size = new Size(303, 23);
            txtItemName.TabIndex = 10;
            // 
            // label38
            // 
            label38.BackColor = Color.Transparent;
            label38.Font = new Font("Verdana", 9F, FontStyle.Bold);
            label38.ForeColor = Color.Black;
            label38.Location = new Point(162, 10);
            label38.Name = "label38";
            label38.Size = new Size(61, 18);
            label38.TabIndex = 9;
            label38.Text = "Name:";
            label38.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Verdana", 9F, FontStyle.Bold);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(162, 57);
            label1.Name = "label1";
            label1.Size = new Size(75, 18);
            label1.TabIndex = 11;
            label1.Text = "Picture:";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = (Image)resources.GetObject("pictureBox1.BackgroundImage");
            pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox1.Location = new Point(422, 75);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(48, 48);
            pictureBox1.TabIndex = 12;
            pictureBox1.TabStop = false;
            // 
            // lblPicture
            // 
            lblPicture.BackColor = Color.Transparent;
            lblPicture.Font = new Font("Verdana", 9F, FontStyle.Bold);
            lblPicture.ForeColor = Color.Black;
            lblPicture.Location = new Point(373, 75);
            lblPicture.Name = "lblPicture";
            lblPicture.Size = new Size(46, 18);
            lblPicture.TabIndex = 13;
            lblPicture.Text = "0:";
            lblPicture.TextAlign = ContentAlignment.MiddleRight;
            // 
            // cmbType
            // 
            cmbType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbType.FormattingEnabled = true;
            cmbType.Items.AddRange(new object[] { "None", "Weapon", "Armor", "Helmet", "Shield", "Potion Add HP", "Potion Add MP", "Potion Add SP", "Potion Sub HP", "Potion Sub MP", "Potion Sub SP", "Currency", "Spell" });
            cmbType.Location = new Point(229, 129);
            cmbType.Name = "cmbType";
            cmbType.Size = new Size(241, 23);
            cmbType.TabIndex = 14;
            cmbType.SelectedIndexChanged += cmbType_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Verdana", 9F, FontStyle.Bold);
            label2.ForeColor = Color.Black;
            label2.Location = new Point(162, 130);
            label2.Name = "label2";
            label2.Size = new Size(64, 18);
            label2.TabIndex = 15;
            label2.Text = "Type:";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pnlSpellData
            // 
            pnlSpellData.BackColor = SystemColors.ControlLight;
            pnlSpellData.Controls.Add(lblSpellID);
            pnlSpellData.Controls.Add(scrlSpellID);
            pnlSpellData.Controls.Add(label6);
            pnlSpellData.Controls.Add(lblSpellName);
            pnlSpellData.Controls.Add(label4);
            pnlSpellData.Controls.Add(label3);
            pnlSpellData.Controls.Add(pnlVitalsData);
            pnlSpellData.Location = new Point(162, 158);
            pnlSpellData.Name = "pnlSpellData";
            pnlSpellData.Size = new Size(311, 100);
            pnlSpellData.TabIndex = 16;
            pnlSpellData.Visible = false;
            // 
            // lblSpellID
            // 
            lblSpellID.BackColor = Color.Transparent;
            lblSpellID.Font = new Font("Verdana", 9F, FontStyle.Bold);
            lblSpellID.ForeColor = Color.Black;
            lblSpellID.Location = new Point(260, 58);
            lblSpellID.Name = "lblSpellID";
            lblSpellID.Size = new Size(46, 18);
            lblSpellID.TabIndex = 21;
            lblSpellID.Text = "0";
            lblSpellID.TextAlign = ContentAlignment.MiddleRight;
            // 
            // scrlSpellID
            // 
            scrlSpellID.LargeChange = 1;
            scrlSpellID.Location = new Point(70, 58);
            scrlSpellID.Maximum = 20;
            scrlSpellID.Name = "scrlSpellID";
            scrlSpellID.Size = new Size(187, 18);
            scrlSpellID.TabIndex = 20;
            // 
            // label6
            // 
            label6.BackColor = Color.Transparent;
            label6.Font = new Font("Verdana", 9F, FontStyle.Bold);
            label6.ForeColor = Color.Black;
            label6.Location = new Point(3, 58);
            label6.Name = "label6";
            label6.Size = new Size(61, 18);
            label6.TabIndex = 19;
            label6.Text = "ID:";
            label6.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblSpellName
            // 
            lblSpellName.BackColor = Color.Transparent;
            lblSpellName.Font = new Font("Verdana", 9F);
            lblSpellName.ForeColor = Color.Black;
            lblSpellName.Location = new Point(70, 28);
            lblSpellName.Name = "lblSpellName";
            lblSpellName.Size = new Size(187, 18);
            lblSpellName.TabIndex = 18;
            lblSpellName.Text = "Spell name";
            lblSpellName.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Verdana", 9F, FontStyle.Bold);
            label4.ForeColor = Color.Black;
            label4.Location = new Point(3, 28);
            label4.Name = "label4";
            label4.Size = new Size(61, 18);
            label4.TabIndex = 17;
            label4.Text = "Name:";
            label4.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Verdana", 9F, FontStyle.Bold);
            label3.ForeColor = Color.Teal;
            label3.Location = new Point(3, 0);
            label3.Name = "label3";
            label3.Size = new Size(75, 18);
            label3.TabIndex = 16;
            label3.Text = "Spell Data";
            label3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pnlVitalsData
            // 
            pnlVitalsData.BackColor = SystemColors.ControlLight;
            pnlVitalsData.Controls.Add(lblVitalMod);
            pnlVitalsData.Controls.Add(scrlVitalMod);
            pnlVitalsData.Controls.Add(label11);
            pnlVitalsData.Controls.Add(label12);
            pnlVitalsData.Location = new Point(0, 0);
            pnlVitalsData.Name = "pnlVitalsData";
            pnlVitalsData.Size = new Size(311, 100);
            pnlVitalsData.TabIndex = 17;
            pnlVitalsData.Visible = false;
            // 
            // lblVitalMod
            // 
            lblVitalMod.BackColor = Color.Transparent;
            lblVitalMod.Font = new Font("Verdana", 9F, FontStyle.Bold);
            lblVitalMod.ForeColor = Color.Black;
            lblVitalMod.Location = new Point(260, 28);
            lblVitalMod.Name = "lblVitalMod";
            lblVitalMod.Size = new Size(46, 18);
            lblVitalMod.TabIndex = 21;
            lblVitalMod.Text = "0";
            lblVitalMod.TextAlign = ContentAlignment.MiddleRight;
            // 
            // scrlVitalMod
            // 
            scrlVitalMod.LargeChange = 1;
            scrlVitalMod.Location = new Point(67, 28);
            scrlVitalMod.Maximum = 20;
            scrlVitalMod.Name = "scrlVitalMod";
            scrlVitalMod.Size = new Size(187, 18);
            scrlVitalMod.TabIndex = 20;
            // 
            // label11
            // 
            label11.BackColor = Color.Transparent;
            label11.Font = new Font("Verdana", 9F, FontStyle.Bold);
            label11.ForeColor = Color.Black;
            label11.Location = new Point(3, 28);
            label11.Name = "label11";
            label11.Size = new Size(61, 18);
            label11.TabIndex = 17;
            label11.Text = "Mod:";
            label11.TextAlign = ContentAlignment.MiddleLeft;
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
            label12.Text = "Vitals Data";
            label12.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pnlEquipData
            // 
            pnlEquipData.BackColor = SystemColors.ControlLight;
            pnlEquipData.Controls.Add(scrlDurability);
            pnlEquipData.Controls.Add(scrlStrength);
            pnlEquipData.Controls.Add(lblDurability);
            pnlEquipData.Controls.Add(lblStrength);
            pnlEquipData.Controls.Add(label10);
            pnlEquipData.Controls.Add(label14);
            pnlEquipData.Controls.Add(label15);
            pnlEquipData.Location = new Point(162, 158);
            pnlEquipData.Name = "pnlEquipData";
            pnlEquipData.Size = new Size(311, 100);
            pnlEquipData.TabIndex = 18;
            pnlEquipData.Visible = false;
            // 
            // scrlDurability
            // 
            scrlDurability.LargeChange = 1;
            scrlDurability.Location = new Point(81, 28);
            scrlDurability.Maximum = 20;
            scrlDurability.Name = "scrlDurability";
            scrlDurability.Size = new Size(176, 18);
            scrlDurability.TabIndex = 25;
            // 
            // scrlStrength
            // 
            scrlStrength.LargeChange = 1;
            scrlStrength.Location = new Point(81, 58);
            scrlStrength.Maximum = 20;
            scrlStrength.Name = "scrlStrength";
            scrlStrength.Size = new Size(176, 18);
            scrlStrength.TabIndex = 24;
            // 
            // lblDurability
            // 
            lblDurability.BackColor = Color.Transparent;
            lblDurability.Font = new Font("Verdana", 9F, FontStyle.Bold);
            lblDurability.ForeColor = Color.Black;
            lblDurability.Location = new Point(272, 28);
            lblDurability.Name = "lblDurability";
            lblDurability.Size = new Size(34, 18);
            lblDurability.TabIndex = 23;
            lblDurability.Text = "0";
            lblDurability.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblStrength
            // 
            lblStrength.BackColor = Color.Transparent;
            lblStrength.Font = new Font("Verdana", 9F, FontStyle.Bold);
            lblStrength.ForeColor = Color.Black;
            lblStrength.Location = new Point(272, 58);
            lblStrength.Name = "lblStrength";
            lblStrength.Size = new Size(34, 18);
            lblStrength.TabIndex = 21;
            lblStrength.Text = "0";
            lblStrength.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label10
            // 
            label10.BackColor = Color.Transparent;
            label10.Font = new Font("Verdana", 9F, FontStyle.Bold);
            label10.ForeColor = Color.Black;
            label10.Location = new Point(3, 58);
            label10.Name = "label10";
            label10.Size = new Size(87, 18);
            label10.TabIndex = 19;
            label10.Text = "Strength:";
            label10.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label14
            // 
            label14.BackColor = Color.Transparent;
            label14.Font = new Font("Verdana", 9F, FontStyle.Bold);
            label14.ForeColor = Color.Black;
            label14.Location = new Point(3, 28);
            label14.Name = "label14";
            label14.Size = new Size(87, 18);
            label14.TabIndex = 17;
            label14.Text = "Durability:";
            label14.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label15
            // 
            label15.BackColor = Color.Transparent;
            label15.Font = new Font("Verdana", 9F, FontStyle.Bold);
            label15.ForeColor = Color.Teal;
            label15.Location = new Point(3, 0);
            label15.Name = "label15";
            label15.Size = new Size(114, 18);
            label15.TabIndex = 16;
            label15.Text = "Equipment Data";
            label15.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // button2
            // 
            button2.FlatStyle = FlatStyle.Flat;
            button2.Location = new Point(162, 264);
            button2.Name = "button2";
            button2.Size = new Size(138, 27);
            button2.TabIndex = 21;
            button2.Text = "Save";
            button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.FlatStyle = FlatStyle.Flat;
            button1.Location = new Point(335, 264);
            button1.Name = "button1";
            button1.Size = new Size(138, 27);
            button1.TabIndex = 22;
            button1.Text = "Cancel";
            button1.UseVisualStyleBackColor = true;
            // 
            // frmEditor_Item
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(483, 300);
            ControlBox = false;
            Controls.Add(button1);
            Controls.Add(button2);
            Controls.Add(label2);
            Controls.Add(cmbType);
            Controls.Add(lblPicture);
            Controls.Add(pictureBox1);
            Controls.Add(label1);
            Controls.Add(txtItemName);
            Controls.Add(label38);
            Controls.Add(scrlPic);
            Controls.Add(lstItems);
            Controls.Add(pnlSpellData);
            Controls.Add(pnlEquipData);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "frmEditor_Item";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Item Editor";
            Load += frmEditor_Item_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            pnlSpellData.ResumeLayout(false);
            pnlVitalsData.ResumeLayout(false);
            pnlEquipData.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox lstItems;
        private HScrollBar scrlPic;
        private TextBox txtItemName;
        private Label label38;
        private Label label1;
        private PictureBox pictureBox1;
        private Label lblPicture;
        private ComboBox cmbType;
        private Label label2;
        private Panel pnlSpellData;
        private Label lblSpellName;
        private Label label4;
        private Label label3;
        private Label lblSpellID;
        private HScrollBar scrlSpellID;
        private Label label6;
        private Panel pnlVitalsData;
        private Label lblVitalMod;
        private HScrollBar scrlVitalMod;
        private Label label12;
        private Label label11;
        private Panel pnlEquipData;
        private Label lblDurability;
        private Label lblStrength;
        private Label label10;
        private Label label14;
        private Label label15;
        private HScrollBar scrlDurability;
        private HScrollBar scrlStrength;
        private Button button2;
        private Button button1;
    }
}