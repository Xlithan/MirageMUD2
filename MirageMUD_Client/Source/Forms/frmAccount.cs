using MirageMUD_Client.Source.Utilities;
using MirageMUD_WFClient;
using MirageMUD_WFClient.Source.Forms;
using MirageMUD_WFClient.Source.Network;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MirageMUD_Client.Source.Forms
{
    public partial class frmAccount : Form
    {
        ClientTCP clientTCP;  // Instance of ClientTCP for network communication
        private RadioButtonManager _raceManager; // For new character race selection
        private RadioButtonManager _classManager; // For new character class selection
        public frmAccount()
        {
            InitializeComponent();
            Debug.WriteLine("frmAccount initialised.");

            if (defaultInstance == null)
                defaultInstance = this;

            // Initialize managers for the panels
            _raceManager = new RadioButtonManager(pnlRace);
            _classManager = new RadioButtonManager(pnlClass);

            // Subscribe to the CheckedChanged event for race radio buttons
            foreach (var radioButton in _raceManager.RadioButtons)
            {
                radioButton.CheckedChanged += RaceRadioButton_CheckedChanged;
            }
        }
        public void RunOnUIThread(Action action)
        {
            try
            {
                if (InvokeRequired)
                    BeginInvoke(action);
                else
                    action();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Exception on UI thread: {ex.Message}");
            }
        }

        private static frmAccount defaultInstance;
        public static frmAccount Default
        {
            get
            {
                if (defaultInstance == null)
                {
                    defaultInstance = new frmAccount();
                    defaultInstance.FormClosed += new System.Windows.Forms.FormClosedEventHandler(defaultInstance_FormClosed);
                }
                return defaultInstance;
            }
            set
            {
                defaultInstance = value;
            }
        }

        static void defaultInstance_FormClosed(object sender, System.Windows.Forms.FormClosedEventArgs e)
        {
            defaultInstance = null;
        }
        private void picNewCharAvatar_Click(object sender, EventArgs e)
        {
            // Open the dialog form
            using (var imageSelectorForm = new dlgAvatarSelection())
            {
                if (imageSelectorForm.ShowDialog() == DialogResult.OK)
                {
                    // Get the selected image name
                    string selectedImageName = imageSelectorForm.SelectedImageName;

                    if (!string.IsNullOrEmpty(selectedImageName))
                    {
                        // Construct the full path to the image
                        string imagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "gfx", "avatars", "players", selectedImageName);

                        if (File.Exists(imagePath))
                        {
                            // Set the image in the PictureBox
                            picNewCharAvatar.Image = Image.FromFile(imagePath);
                            picNewCharAvatar.SizeMode = PictureBoxSizeMode.StretchImage;
                        }
                        else
                        {
                            MessageBox.Show($"Image not found: {imagePath}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }
        private void btnNewChar_Click(object sender, EventArgs e)
        {
            pnlNewChar.Visible = true;

            clientTCP.SendRerollRequest();  // Send login data to server
            NewCharReset();
        }

        private void btnReroll_Click(object sender, EventArgs e)
        {
            if (clientTCP.PlayerSocket.Connected && pnlNewChar.Visible == true)
            {
                clientTCP.SendRerollRequest();  // Send login data to server
            }
        }

        private void btnNewCharCancel_Click(object sender, EventArgs e)
        {
            NewCharReset();
            pnlCharacters.Visible = true;
        }

        private void btnUseChar_Click(object sender, EventArgs e)
        {

        }
        private void btnDeleteChar_Click(object sender, EventArgs e)
        {

        }
        private void btnCharsCancel_Click(object sender, EventArgs e)
        {
            pnlCharacters.Visible = false;  // Hide characters panel
        }

        private void btnNewCharCreate_Click(object sender, EventArgs e)
        {

        }

        // Functions
        public void NewCharReset()
        {
            this.SuspendLayout();  // Prevent updates until changes are done

            // Construct the full path to the image
            string imagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "gfx", "avatars", "players", "1.bmp");

            if (File.Exists(imagePath))
            {
                // Set the image in the PictureBox
                picNewCharAvatar.Image = Image.FromFile(imagePath);
                picNewCharAvatar.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            else
            {
                picNewCharAvatar.Image = null;
            }

            txtNewCharName.Text = string.Empty;
            optRaceDwarf.Checked = true;
            optClassBerserker.Checked = true;
            optMale.Checked = true;

            this.ResumeLayout();  // Redraw the form after changes
        }
        private void RaceRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (sender is RadioButton selected && selected.Checked)
            {
                // Disable certain class options based on the selected race
                if (selected.Text == "Dwarf")
                {
                    _classManager.SetEnabled(new[] { "Berserker", "Fighter", "Cleric", "Thief", "Pacifist" }, true); // Enable certain classes
                    _classManager.SetEnabled(new[] { "Paladin", "Mage", "Druid", "Ranger" }, false); // Disable others
                    optClassBerserker.Checked = true;
                }
                else if (selected.Text == "Elf")
                {
                    _classManager.SetEnabled(new[] { "Fighter", "Mage", "Cleric", "Druid", "Ranger", "Pacifist" }, true);
                    _classManager.SetEnabled(new[] { "Berserker", "Paladin", "Thief" }, false);
                    optClassFighter.Checked = true;
                }
                else if (selected.Text == "Human")
                {
                    _classManager.SetEnabled(new[] { "Berserker", "Paladin", "Fighter", "Mage", "Cleric", "Druid", "Ranger", "Thief", "Pacifist" }, true);
                    _classManager.SetEnabled(new[] { "" }, false);
                    optClassBerserker.Checked = true;
                }
                else if (selected.Text == "Gnome")
                {
                    _classManager.SetEnabled(new[] { "Mage", "Cleric", "Thief", "Pacifist" }, true);
                    _classManager.SetEnabled(new[] { "Berserker", "Paladin", "Fighter", "Druid", "Ranger" }, false);
                    optClassMage.Checked = true;
                }
                else if (selected.Text == "Halfling")
                {
                    _classManager.SetEnabled(new[] { "Paladin", "Fighter", "Cleric", "Druid", "Ranger", "Thief", "Pacifist" }, true);
                    _classManager.SetEnabled(new[] { "Berserker", "Mage" }, false);
                    optClassPaladin.Checked = true;
                }
                else if (selected.Text == "Half-Elf")
                {
                    _classManager.SetEnabled(new[] { "Berserker", "Fighter", "Mage", "Cleric", "Druid", "Ranger", "Pacifist" }, true);
                    _classManager.SetEnabled(new[] { "Paladin", "Thief" }, false);
                    optClassBerserker.Checked = true;
                }
                else if (selected.Text == "Half-Orc")
                {
                    _classManager.SetEnabled(new[] { "Berserker", "Fighter" }, true);
                    _classManager.SetEnabled(new[] { "Pacifist", "Paladin", "Mage", "Cleric", "Druid", "Ranger", "Thief" }, false);
                    optClassBerserker.Checked = true;
                }
                else
                {
                    // Disable all class options if no specific race is selected
                    _classManager.SetEnabled(_classManager.RadioButtons.Select(rb => rb.Text).ToArray(), false);
                }
            }
        }
    }
}
