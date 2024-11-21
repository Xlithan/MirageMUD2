using DarkModeForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MirageMUD_Client
{
    public partial class frmEditor_Room : Form
    {
        public frmEditor_Room()
        {
            InitializeComponent();
            _ = new DarkModeCS(this);
        }

        private void btnRoomDesc_Click(object sender, EventArgs e)
        {
            HideGroups();
            grpRoomDesc.Visible = true;
        }

        private void HideGroups()
        {
            grpRoomDesc.Visible = false;
            grpRoomLinks.Visible = false;
            grpBootRoom.Visible = false;
            grpRoomSettings.Visible = false;
            grpRoomNPCs.Visible = false;
            grpRoomItems.Visible = false;
        }

        private void btnRoomLinks_Click(object sender, EventArgs e)
        {
            HideGroups();
            grpRoomLinks.Visible = true;
        }

        private void btnBootRoom_Click(object sender, EventArgs e)
        {
            HideGroups();
            grpBootRoom.Visible = true;
        }

        private void btnRoomSettings_Click(object sender, EventArgs e)
        {
            HideGroups();
            grpRoomSettings.Visible = true;
        }

        private void btnRoomNPCs_Click(object sender, EventArgs e)
        {
            HideGroups();
            grpRoomNPCs.Visible = true;
        }

        private void btnRoomItems_Click(object sender, EventArgs e)
        {
            HideGroups();
            grpRoomItems.Visible = true;
        }

        private void btnRoomCancel_Click(object sender, EventArgs e)
        {

        }

        private void btnRoomSave_Click(object sender, EventArgs e)
        {

        }
    }
}
