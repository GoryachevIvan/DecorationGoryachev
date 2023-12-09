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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DecorSoldatov
{
    public partial class fmLogin : Form
    {
        static string connString = @"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=DecorationSoldatov;Data Source=MEPHI3-MSSQL";
        SqlConnection sqlConnect = new SqlConnection(connString);

        public fmLogin()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            checkBox1.Checked = Properties.Settings.Default.IsRemember;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sqlConnect.Open();
            SqlCommand logRequest = new SqlCommand();

            logRequest.CommandType = CommandType.StoredProcedure;
            logRequest.CommandText = "Procedurelogin";
            logRequest.Parameters.AddWithValue("@login", textBox1.Text);
            logRequest.Parameters.AddWithValue("@password", textBox2.Text);
            logRequest.Connection = sqlConnect;
            SqlDataReader sqlReader = logRequest.ExecuteReader();

            try
            {
                sqlReader.Read();
                if (sqlReader.HasRows)
                {
                    MessageBox.Show("Успешно!");

                    fmMenu Menu = new fmMenu();
                    this.Hide();
                    Menu.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Неверный логин или пароль");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Все плохо : {ex.Message}");
            }
            finally
            {
                sqlConnect.Close();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.IsRemember = checkBox1.Checked;
            Properties.Settings.Default.Save();
        }
    }
}
