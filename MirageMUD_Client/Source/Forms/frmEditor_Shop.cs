﻿using DarkModeForms;
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
    public partial class frmEditor_Shop : Form
    {
        public frmEditor_Shop()
        {
            InitializeComponent();
            _ = new DarkModeCS(this);
        }
    }
}