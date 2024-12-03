using MirageMUD_WFClient.Source.Utilities;

namespace MirageMUD_WFClient
{
    public partial class frmEditor_Item : Form
    {
        public frmEditor_Item()
        {
            InitializeComponent(); // Initializes form components.
            _ = new DarkModeCS(this); // Applies dark mode to the form.
        }

        // Updates the label to display the current scrollbar value.
        private void scrlPic_Scroll(object sender, ScrollEventArgs e)
        {
            lblPicture.Text = scrlPic.Value + ":";
        }

        // Adjusts the visibility of panels based on the selected item type.
        private void cmbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbType.SelectedIndex >= 1 && cmbType.SelectedIndex <= 4) // Equipment types.
            {
                pnlEquipData.Visible = true;
                pnlSpellData.Visible = false;
                pnlVitalsData.Visible = false;
            }
            else
            {
                pnlEquipData.Visible = false;
            }

            if (cmbType.SelectedIndex >= 5 && cmbType.SelectedIndex <= 10) // Vitals types.
            {
                pnlVitalsData.Visible = true;
            }
            else
            {
                pnlVitalsData.Visible = false;
            }

            if (cmbType.SelectedIndex == 12) // Spell types.
            {
                pnlSpellData.Visible = true;
            }
            else
            {
                pnlSpellData.Visible = false;
            }
        }

        // Sets up default values when the form loads.
        private void frmEditor_Item_Load(object sender, EventArgs e)
        {
            cmbType.SelectedIndex = 0; // Default to the first item in the combo box.
        }

        // Placeholder for button functionality.
        private void btnNewAccConnect_Click(object sender, EventArgs e)
        {
            // TODO: Implement button logic here.
        }
    }
}