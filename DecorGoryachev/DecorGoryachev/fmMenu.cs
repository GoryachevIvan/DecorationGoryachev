using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DecorSoldatov
{
    public partial class fmMenu : Form
    {
        static string connString = @"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=DecorationSoldatov;Data Source=MEPHI3-MSSQL";
        SqlConnection sqlConnect = new SqlConnection(connString);

        public fmMenu()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*if (sqlConnect.State == ConnectionState.Open)
            {
                sqlConnect.Close();
            }

            sqlConnect.Open();
            SqlCommand logRequest = new SqlCommand();
            logRequest.CommandType = CommandType.StoredProcedure;
            logRequest.CommandText = "AddProduct";
            logRequest.Connection = sqlConnect;

            logRequest.Parameters.AddWithValue("");
            logRequest.Parameters.AddWithValue("");
            logRequest.Parameters.AddWithValue("");
            logRequest.Parameters.AddWithValue("");
            logRequest.Parameters.AddWithValue("");
            logRequest.Parameters.AddWithValue("");
            logRequest.Parameters.AddWithValue("");

            logRequest.Parameters.AddWithValue("");
            try
            {

            }*/
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = $"ProductName LIKE '%{textBox1.Text}%'";
        }
    }
}
