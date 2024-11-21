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
            button3 = new Button();
            button4 = new Button();
            button2 = new Button();
            lstShops = new ListBox();
            SuspendLayout();
            // 
            // txtItemName
            // 
            txtItemName.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtItemName.Location = new Point(254, 8);
            txtItemName.Name = "txtItemName";
            txtItemName.Size = new Size(311, 23);
            txtItemName.TabIndex = 12;
            // 
            // label38
            // 
            label38.BackColor = Color.Transparent;
            label38.Font = new Font("Verdana", 9F, FontStyle.Bold);
            label38.ForeColor = Color.Black;
            label38.Location = new Point(162, 9);
            label38.Name = "label38";
            label38.Size = new Size(86, 18);
            label38.TabIndex = 11;
            label38.Text = "Name:";
            label38.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox1.Location = new Point(254, 37);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(311, 23);
            textBox1.TabIndex = 14;
            // 
            // label1
            // 
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Verdana", 9F, FontStyle.Bold);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(162, 38);
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
            label2.Location = new Point(162, 67);
            label2.Name = "label2";
            label2.Size = new Size(86, 18);
            label2.TabIndex = 15;
            label2.Text = "Leave Msg:";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // textBox2
            // 
            textBox2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox2.Location = new Point(254, 66);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(311, 23);
            textBox2.TabIndex = 16;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Font = new Font("Verdana", 9F, FontStyle.Bold);
            checkBox1.Location = new Point(254, 95);
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
            label3.Location = new Point(162, 120);
            label3.Name = "label3";
            label3.Size = new Size(86, 18);
            label3.TabIndex = 18;
            label3.Text = "Give Item:";
            label3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // textBox3
            // 
            textBox3.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox3.Location = new Point(254, 206);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(110, 23);
            textBox3.TabIndex = 19;
            // 
            // label4
            // 
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Verdana", 9F, FontStyle.Bold);
            label4.ForeColor = Color.Black;
            label4.Location = new Point(162, 149);
            label4.Name = "label4";
            label4.Size = new Size(86, 18);
            label4.TabIndex = 20;
            label4.Text = "Value:";
            label4.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // textBox4
            // 
            textBox4.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox4.Location = new Point(254, 148);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(110, 23);
            textBox4.TabIndex = 21;
            // 
            // cmbType
            // 
            cmbType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbType.FormattingEnabled = true;
            cmbType.Items.AddRange(new object[] { "None", "Weapon", "Armor", "Helmet", "Shield", "Potion Add HP", "Potion Add MP", "Potion Add SP", "Potion Sub HP", "Potion Sub MP", "Potion Sub SP", "Currency", "Spell" });
            cmbType.Location = new Point(254, 119);
            cmbType.Name = "cmbType";
            cmbType.Size = new Size(311, 23);
            cmbType.TabIndex = 36;
            // 
            // comboBox1
            // 
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "None", "Weapon", "Armor", "Helmet", "Shield", "Potion Add HP", "Potion Add MP", "Potion Add SP", "Potion Sub HP", "Potion Sub MP", "Potion Sub SP", "Currency", "Spell" });
            comboBox1.Location = new Point(254, 177);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(311, 23);
            comboBox1.TabIndex = 37;
            // 
            // label5
            // 
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Verdana", 9F, FontStyle.Bold);
            label5.ForeColor = Color.Black;
            label5.Location = new Point(162, 178);
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
            label6.Location = new Point(162, 207);
            label6.Name = "label6";
            label6.Size = new Size(86, 18);
            label6.TabIndex = 39;
            label6.Text = "Value:";
            label6.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // listBox1
            // 
            listBox1.BorderStyle = BorderStyle.FixedSingle;
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 15;
            listBox1.Location = new Point(162, 235);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(403, 137);
            listBox1.TabIndex = 40;
            // 
            // button3
            // 
            button3.FlatStyle = FlatStyle.Flat;
            button3.Location = new Point(427, 380);
            button3.Name = "button3";
            button3.Size = new Size(138, 27);
            button3.TabIndex = 46;
            button3.Text = "Cancel";
            button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.FlatStyle = FlatStyle.Flat;
            button4.Location = new Point(162, 380);
            button4.Name = "button4";
            button4.Size = new Size(138, 27);
            button4.TabIndex = 45;
            button4.Text = "Save";
            button4.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.FlatStyle = FlatStyle.Flat;
            button2.Location = new Point(426, 205);
            button2.Name = "button2";
            button2.Size = new Size(138, 27);
            button2.TabIndex = 47;
            button2.Text = "Update";
            button2.UseVisualStyleBackColor = true;
            // 
            // lstShops
            // 
            lstShops.BorderStyle = BorderStyle.FixedSingle;
            lstShops.Dock = DockStyle.Left;
            lstShops.FormattingEnabled = true;
            lstShops.ItemHeight = 15;
            lstShops.Location = new Point(0, 0);
            lstShops.Name = "lstShops";
            lstShops.Size = new Size(156, 412);
            lstShops.TabIndex = 48;
            // 
            // frmEditor_Shop
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(571, 412);
            ControlBox = false;
            Controls.Add(lstShops);
            Controls.Add(button2);
            Controls.Add(button3);
            Controls.Add(button4);
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
        private Button button3;
        private Button button4;
        private Button button2;
        private ListBox lstShops;
    }
}