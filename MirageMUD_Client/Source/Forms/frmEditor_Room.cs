using MirageMUD_WFClient.Source.Utilities;
using System;
using System.Windows.Forms;

namespace MirageMUD_WFClient
{
    public partial class frmEditor_Room : Form
    {
        public frmEditor_Room()
        {
            InitializeComponent(); // Initializes the form components.
            _ = new DarkModeCS(this); // Applies dark mode to the form.
        }

        // Shows the room description group and hides all other groups.
        private void btnRoomDesc_Click(object sender, EventArgs e)
        {
            HideGroups(); // Ensure all groups are hidden before showing the desired group.
            grpRoomDesc.Visible = true; // Display the room description group.
        }

        // Hides all group panels, ensuring only one is visible at a time.
        private void HideGroups()
        {
            grpRoomDesc.Visible = false;
            grpRoomLinks.Visible = false;
            grpBootRoom.Visible = false;
            grpRoomSettings.Visible = false;
            grpRoomNPCs.Visible = false;
            grpRoomItems.Visible = false;
        }

        // Shows the room links group and hides all other groups.
        private void btnRoomLinks_Click(object sender, EventArgs e)
        {
            HideGroups();
            grpRoomLinks.Visible = true;
        }

        // Shows the boot room group and hides all other groups.
        private void btnBootRoom_Click(object sender, EventArgs e)
        {
            HideGroups();
            grpBootRoom.Visible = true;
        }

        // Shows the room settings group and hides all other groups.
        private void btnRoomSettings_Click(object sender, EventArgs e)
        {
            HideGroups();
            grpRoomSettings.Visible = true;
        }

        // Shows the room NPCs group and hides all other groups.
        private void btnRoomNPCs_Click(object sender, EventArgs e)
        {
            HideGroups();
            grpRoomNPCs.Visible = true;
        }

        // Shows the room items group and hides all other groups.
        private void btnRoomItems_Click(object sender, EventArgs e)
        {
            HideGroups();
            grpRoomItems.Visible = true;
        }

        // Placeholder for cancel button logic.
        private void btnRoomCancel_Click(object sender, EventArgs e)
        {
            // TODO: Add functionality for the cancel button.
        }

        // Placeholder for save button logic.
        private void btnRoomSave_Click(object sender, EventArgs e)
        {
            // TODO: Add functionality for the save button.
        }
    }
}