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
    public partial class MyEvents : Form
    {
        string Userid;
     
        public MyEvents()
        {
            InitializeComponent();
            Userid = Form1.UseridText;
           
            
            //button4.Click += new EventHandler(MyEvents_Load);
        }
        private void MyEvents_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
        private void MyEvents_Load(object sender, EventArgs e)
        {
            SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["Diary"].ConnectionString);
            c.Open();
            Form1 f = new Form1();

            string query = "Select COL_NAME=Name from MyEvents where UserId='" + Userid + "'";
            SqlCommand command = new SqlCommand(query, c);
            SqlDataReader reader = command.ExecuteReader();
            List<Ivents> list = new List<Ivents>();
            while (reader.Read())
            {
                Ivents p = new Ivents();
                p.Name = reader["COL_NAME"].ToString();
                /*p.Date= reader["Date"].ToString();
                p.Location= reader["Location"].ToString();
                p.Pictures= reader["Pictures"].ToString();
                p.EventDescription= reader["EventDescription"].ToString();
                p.UserId = reader["UserId"].ToString();*/
                list.Add(p);
            }
            c.Close();
            dataGridView1.DataSource = list;
            reader.Close();
            
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Manage mn = new Manage();
            this.Hide();
            mn.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["Diary"].ConnectionString);
            c.Open();
            string q = "Delete  from MyEvents where Name='"+textBox1.Text+"' ";
            SqlCommand command = new SqlCommand(q,c);
            command.ExecuteNonQuery();
            c.Close();
        }

        private void button4_Click(object sender, EventArgs e)//showall
        {

          
           
                SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["Diary"].ConnectionString);
                c.Open();
                //Form1 f = new Form1();

                string query = "Select * from MyEvents where UserId='" + Userid + "'";
                SqlCommand command = new SqlCommand(query, c);
                SqlDataReader reader = command.ExecuteReader();
                List<Ivents> list = new List<Ivents>();
                while (reader.Read())
                {
                    Ivents p = new Ivents();
                    p.Name = reader["Name"].ToString();
                    p.Date = reader["Date"].ToString();
                    p.Location = reader["Location"].ToString();
                    p.Pictures = reader["Pictures"].ToString();
                    p.EventDescription = reader["EventDescription"].ToString();
                    p.UserId = reader["UserId"].ToString();
                    p.Importance = reader["Importance"].ToString();
                    list.Add(p);
                }
                c.Close();
                dataGridView2.DataSource = list;
                reader.Close();
            
          
        }

        private void button3_Click(object sender, EventArgs e)//update
        {
           
            SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["Diary"].ConnectionString);
            c.Open();
            string query = "Update dbo.MyEvents set " + entity.Text + " ='" + textBox2.Text + "' where UserId = '" + Userid + "' and Location='"+textBox3.Text+"'";
            SqlCommand command = new SqlCommand(query, c);
            command.ExecuteNonQuery();
            c.Close();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
