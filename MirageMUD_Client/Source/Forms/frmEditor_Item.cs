using MirageMUD_Client.Source.Utilities;

namespace MirageMUD_Client
{
    public partial class frmEditor_Item : Form
    {
        public frmEditor_Item()
        {
            InitializeComponent();
            _ = new DarkModeCS(this);
        }

        private void scrlPic_Scroll(object sender, ScrollEventArgs e)
        {
            lblPicture.Text = scrlPic.Value + ":";
        }

        private void cmbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbType.SelectedIndex >= 1 && cmbType.SelectedIndex <= 4)
            {
                pnlEquipData.Visible = true;
                pnlSpellData.Visible = false;
                pnlVitalsData.Visible = false;
            }
            else
            {
                pnlEquipData.Visible = false;
            }

            if (cmbType.SelectedIndex >= 5 && cmbType.SelectedIndex <= 10)
            {
                pnlEquipData.Visible = false;
                pnlSpellData.Visible = false;
                pnlVitalsData.Visible = true;
            }
            else
            {
                pnlVitalsData.Visible = false;
            }

            if (cmbType.SelectedIndex == 12)
            {
                pnlEquipData.Visible = false;
                pnlSpellData.Visible = true;
                pnlVitalsData.Visible = false;
            }
            else
            {
                pnlSpellData.Visible = false;
            }
        }

        private void frmEditor_Item_Load(object sender, EventArgs e)
        {
            // Set the selected item by index
            cmbType.SelectedIndex = 0; // This selects the first item
        }

        private void btnNewAccConnect_Click(object sender, EventArgs e)
        {

        }
    }
}
