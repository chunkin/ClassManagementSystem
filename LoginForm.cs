using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ClassManagementSystem
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var username = this.username.Text;
            var password = this.password.Text;
            if (username == "admin" && password == "admin")
            {
                MessageBox.Show("login successfully!");
            }
        }
    }
}
