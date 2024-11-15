namespace MirageMUD_Client
{
    partial class frmEditor_Shop
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
            txtItemName = new TextBox();
            label38 = new Label();
            textBox1 = new TextBox();
            label1 = new Label();
            label2 = new Label();
            textBox2 = new TextBox();
            checkBox1 = new CheckBox();
            label3 = new Label();
            textBox3 = new TextBox();
            label4 = new Label();
            textBox4 = new TextBox();
            cmbType = new ComboBox();
            comboBox1 = new ComboBox();
            label5 = new Label();
            label6 = new Label();
            listBox1 = new ListBox();
            btnNewAccConnect = new Button();
            button1 = new Button();
            button2 = new Button();
            SuspendLayout();
            // 
            // txtItemName
            // 
            txtItemName.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtItemName.Location = new Point(104, 3);
            txtItemName.Name = "txtItemName";
            txtItemName.Size = new Size(311, 23);
            txtItemName.TabIndex = 12;
            // 
            // label38
            // 
            label38.BackColor = Color.Transparent;
            label38.Font = new Font("Verdana", 9F, FontStyle.Bold);
            label38.ForeColor = Color.Black;
            label38.Location = new Point(12, 4);
            label38.Name = "label38";
            label38.Size = new Size(86, 18);
            label38.TabIndex = 11;
            label38.Text = "Name:";
            label38.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox1.Location = new Point(104, 32);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(311, 23);
            textBox1.TabIndex = 14;
            // 
            // label1
            // 
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Verdana", 9F, FontStyle.Bold);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(12, 33);
            label1.Name = "label1";
            label1.Size = new Size(86, 18);
            label1.TabIndex = 13;
            label1.Text = "Enter Msg:";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Verdana", 9F, FontStyle.Bold);
            label2.ForeColor = Color.Black;
            label2.Location = new Point(12, 62);
            label2.Name = "label2";
            label2.Size = new Size(86, 18);
            label2.TabIndex = 15;
            label2.Text = "Leave Msg:";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // textBox2
            // 
            textBox2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox2.Location = new Point(104, 61);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(311, 23);
            textBox2.TabIndex = 16;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Font = new Font("Verdana", 9F, FontStyle.Bold);
            checkBox1.Location = new Point(104, 90);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(110, 18);
            checkBox1.TabIndex = 17;
            checkBox1.Text = "Fixes Items?";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Verdana", 9F, FontStyle.Bold);
            label3.ForeColor = Color.Black;
            label3.Location = new Point(12, 115);
            label3.Name = "label3";
            label3.Size = new Size(86, 18);
            label3.TabIndex = 18;
            label3.Text = "Give Item:";
            label3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // textBox3
            // 
            textBox3.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox3.Location = new Point(104, 201);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(110, 23);
            textBox3.TabIndex = 19;
            // 
            // label4
            // 
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Verdana", 9F, FontStyle.Bold);
            label4.ForeColor = Color.Black;
            label4.Location = new Point(12, 144);
            label4.Name = "label4";
            label4.Size = new Size(86, 18);
            label4.TabIndex = 20;
            label4.Text = "Value:";
            label4.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // textBox4
            // 
            textBox4.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox4.Location = new Point(104, 143);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(110, 23);
            textBox4.TabIndex = 21;
            // 
            // cmbType
            // 
            cmbType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbType.FormattingEnabled = true;
            cmbType.Items.AddRange(new object[] { "None", "Weapon", "Armor", "Helmet", "Shield", "Potion Add HP", "Potion Add MP", "Potion Add SP", "Potion Sub HP", "Potion Sub MP", "Potion Sub SP", "Currency", "Spell" });
            cmbType.Location = new Point(104, 114);
            cmbType.Name = "cmbType";
            cmbType.Size = new Size(311, 23);
            cmbType.TabIndex = 36;
            // 
            // comboBox1
            // 
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "None", "Weapon", "Armor", "Helmet", "Shield", "Potion Add HP", "Potion Add MP", "Potion Add SP", "Potion Sub HP", "Potion Sub MP", "Potion Sub SP", "Currency", "Spell" });
            comboBox1.Location = new Point(104, 172);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(311, 23);
            comboBox1.TabIndex = 37;
            // 
            // label5
            // 
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Verdana", 9F, FontStyle.Bold);
            label5.ForeColor = Color.Black;
            label5.Location = new Point(12, 173);
            label5.Name = "label5";
            label5.Size = new Size(86, 18);
            label5.TabIndex = 38;
            label5.Text = "Get Item:";
            label5.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            label6.BackColor = Color.Transparent;
            label6.Font = new Font("Verdana", 9F, FontStyle.Bold);
            label6.ForeColor = Color.Black;
            label6.Location = new Point(12, 202);
            label6.Name = "label6";
            label6.Size = new Size(86, 18);
            label6.TabIndex = 39;
            label6.Text = "Value:";
            label6.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 15;
            listBox1.Location = new Point(12, 230);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(403, 139);
            listBox1.TabIndex = 40;
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
            btnNewAccConnect.Location = new Point(277, 199);
            btnNewAccConnect.Name = "btnNewAccConnect";
            btnNewAccConnect.Size = new Size(138, 27);
            btnNewAccConnect.TabIndex = 42;
            btnNewAccConnect.Text = "Update";
            btnNewAccConnect.UseVisualStyleBackColor = false;
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
            button1.Location = new Point(12, 375);
            button1.Name = "button1";
            button1.Size = new Size(138, 27);
            button1.TabIndex = 43;
            button1.Text = "Save";
            button1.UseVisualStyleBackColor = false;
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
            button2.Location = new Point(277, 375);
            button2.Name = "button2";
            button2.Size = new Size(138, 27);
            button2.TabIndex = 44;
            button2.Text = "Cancel";
            button2.UseVisualStyleBackColor = false;
            // 
            // frmEditor_Shop
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(426, 412);
            ControlBox = false;
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(btnNewAccConnect);
            Controls.Add(listBox1);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(comboBox1);
            Controls.Add(cmbType);
            Controls.Add(textBox4);
            Controls.Add(label4);
            Controls.Add(textBox3);
            Controls.Add(label3);
            Controls.Add(checkBox1);
            Controls.Add(textBox2);
            Controls.Add(label2);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Controls.Add(txtItemName);
            Controls.Add(label38);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "frmEditor_Shop";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Shop Editor";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtItemName;
        private Label label38;
        private TextBox textBox1;
        private Label label1;
        private Label label2;
        private TextBox textBox2;
        private CheckBox checkBox1;
        private Label label3;
        private TextBox textBox3;
        private Label label4;
        private TextBox textBox4;
        private ComboBox cmbType;
        private ComboBox comboBox1;
        private Label label5;
        private Label label6;
        private ListBox listBox1;
        private Button btnNewAccConnect;
        private Button button1;
        private Button button2;
    }
}