﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ClassManagementSystem
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void addUserMenuItem_Click(object sender, EventArgs e)
        {
           
            Form childForm = new UMForm();

            childForm.MdiParent = this;
            childForm.Show();
            childForm.Activate();
        }
    }
}
