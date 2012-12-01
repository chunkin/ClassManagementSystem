using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
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
            if (IsAdmin(username, password))
            {
                var mainForm = new MainForm();
                Hide();
                mainForm.Show();
            }
        }

        private bool IsAdmin(string username, string password)
        {
            var connectionString = DbConn.connString;
            var connection = new OleDbConnection(connectionString);
            connection.Open();
            string query = String.Format("select count(*) from users where username='{0}' and password='{1}'", username, password);
            var command = new OleDbCommand(query, connection);
            OleDbDataReader reader = command.ExecuteReader();
            int count = 0;
            while (reader.Read())
            {
                count = reader.GetInt32(0);
            }
            reader.Close();
            connection.Close();
            return count == 1;
        }
    }
}
