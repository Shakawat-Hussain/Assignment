using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CloudDiary
{
    public partial class SignUp : Form
    {
        public SignUp()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            {
                SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["Diary"].ConnectionString);
                c.Open();
                string query = "INSERT INTO Logon(UserId,Password)" + "VALUES('" + userid.Text + "','" + password.Text + "')";
                SqlCommand command = new SqlCommand(query, c);
                command.ExecuteNonQuery();
                c.Close();
                MessageBox.Show("User created Successfully!");
                Form1 f = new Form1();
                f.Show();
                this.Hide();

            }

        }

        private void SignUp_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
            this.Hide();

        }

        private void SignUp_Load(object sender, EventArgs e)
        {

        }
    }
}
