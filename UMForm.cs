using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ClassManagementSystem
{
    public partial class UMForm : Form
    {

        private OleDbDataAdapter dataAdapter ;

        private DataSet users;



        public UMForm()
        {
            InitializeComponent();
        }

        private void getData(string sqlCommand)
        {
            try
            {
                users = new DataSet();
                dataAdapter = new OleDbDataAdapter(sqlCommand, DbConn.connString);
                dataAdapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
                
                OleDbCommandBuilder commandBuilder = new OleDbCommandBuilder(dataAdapter);
                commandBuilder.QuotePrefix = "[";
                commandBuilder.QuoteSuffix = "]";

                dataAdapter.Fill(users,"users");

                dataGridView.DataSource = users.Tables["users"];
                dataGridView.AutoGenerateColumns = true;
//                dataGridView.Columns[0].ReadOnly = true;

            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message);
            }
        }

        private void dataGridView_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            e.Row.Cells["uid"].Value = getMaxNo();
        }

        private void umForm_Load(object sender, EventArgs e)
        {
           
            getData("select uid, username as 姓名,password as 密码, is_admin as 管理员, is_valid  as 是否有效,created_time as 创建时间 from users");
           

        }
       
        private void safeButton_Click(object sender, EventArgs e)
        {
            //使current cell失去焦点，dataset刷新
            dataGridView.CurrentCell = null;
            Console.WriteLine(users.Tables[0].Select().Count());
            

            if(dataAdapter.Update(users,"users")>0)
               MessageBox.Show("保存成功！");
            
            dataGridView.Refresh();
      
        }

        private int getMaxNo()
        {
            OleDbConnection conn = new OleDbConnection(DbConn.connString);
            conn.Open();
            string sqlText = @"select max(uid) from users";
            OleDbCommand sqlCommand = new OleDbCommand(sqlText,conn);
           
            int r = (Int32)sqlCommand.ExecuteScalar();
            Console.WriteLine(r);
            conn.Close();
            return r + 1;
        }




    }
}