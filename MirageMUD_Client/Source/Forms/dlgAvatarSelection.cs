using System.Windows.Forms;

namespace MirageMUD_WFClient.Source.Forms
{
    public partial class dlgAvatarSelection : Form
    {
        private PictureBox selectedPictureBox;
        public string SelectedImageName { get; private set; } // To store the selected image name
        public dlgAvatarSelection()
        {
            InitializeComponent();

            // Wire up the Click event for all PictureBoxes dynamically
            foreach (Control control in fpnlAvatars.Controls)
            {
                if (control is PictureBox pb)
                {
                    pb.Click += pictureBox_Click;
                }
            }
        }

        private void pictureBox_Click(object sender, EventArgs e)
        {
            if (sender is PictureBox clickedPictureBox)
            {
                // Remove highlight from previously selected PictureBox
                if (selectedPictureBox != null)
                {
                    selectedPictureBox.BorderStyle = BorderStyle.None;
                }

                // Highlight the clicked PictureBox
                clickedPictureBox.BorderStyle = BorderStyle.FixedSingle;

                // Store the reference to the clicked PictureBox
                selectedPictureBox = clickedPictureBox;

                // Store the selected image name
                SelectedImageName = clickedPictureBox.Tag.ToString();
            }
        }

        private void HighlightSelectedPictureBox(PictureBox clickedPictureBox)
        {
            // Remove highlight from previously selected PictureBox
            if (selectedPictureBox != null)
            {
                selectedPictureBox.BorderStyle = BorderStyle.None;
            }

            // Highlight the clicked PictureBox
            clickedPictureBox.BorderStyle = BorderStyle.Fixed3D;

            // Store the reference to the selected PictureBox
            selectedPictureBox = clickedPictureBox;

            // Store the selected image name
            if (clickedPictureBox.Tag != null)
            {
                SelectedImageName = clickedPictureBox.Tag.ToString();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (selectedPictureBox != null)
            {
                // Close the form and return DialogResult.OK
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Please select an image.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void picAvatar1_Click(object sender, EventArgs e)
        {
            if (sender is PictureBox clickedPictureBox)
            {
                HighlightSelectedPictureBox(clickedPictureBox);
            }
        }

        private void picAvatar2_Click(object sender, EventArgs e)
        {
            if (sender is PictureBox clickedPictureBox)
            {
                HighlightSelectedPictureBox(clickedPictureBox);
            }
        }

        private void picAvatar3_Click(object sender, EventArgs e)
        {
            if (sender is PictureBox clickedPictureBox)
            {
                HighlightSelectedPictureBox(clickedPictureBox);
            }
        }

        private void picAvatar4_Click(object sender, EventArgs e)
        {
            if (sender is PictureBox clickedPictureBox)
            {
                HighlightSelectedPictureBox(clickedPictureBox);
            }
        }

        private void picAvatar5_Click(object sender, EventArgs e)
        {
            if (sender is PictureBox clickedPictureBox)
            {
                HighlightSelectedPictureBox(clickedPictureBox);
            }
        }

        private void picAvatar6_Click(object sender, EventArgs e)
        {
            if (sender is PictureBox clickedPictureBox)
            {
                HighlightSelectedPictureBox(clickedPictureBox);
            }
        }

        private void picAvatar7_Click(object sender, EventArgs e)
        {
            if (sender is PictureBox clickedPictureBox)
            {
                HighlightSelectedPictureBox(clickedPictureBox);
            }
        }

        private void picAvatar8_Click(object sender, EventArgs e)
        {
            if (sender is PictureBox clickedPictureBox)
            {
                HighlightSelectedPictureBox(clickedPictureBox);
            }
        }
    }
}
