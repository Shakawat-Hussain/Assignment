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
    
    public partial class Manage : Form
    {
        string UserId;
        public Manage()
        {
            InitializeComponent();
            UserId = Form1.UseridText;

        }

        private void Manage_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
      /*  public void AddEvent()
        {
            SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["Diary"].ConnectionString);
            c.Open();
            string q = "Insert Into MyEvents(Name,Date,Location,Pictures,EventDescription)"+ "Values('" +textBox1.Text+ "','" +date.Text+ "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "')";
            SqlCommand cm = new SqlCommand(q, c);
            
            cm.ExecuteNonQuery();
            c.Close();
            MessageBox.Show("Event Added Successfully!");
            this.Hide();
            MyEvents m = new MyEvents();
            m.Show();
            
        }*/

        private void confirm_Click(object sender, EventArgs e)
        {
            /* SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["Diary"].ConnectionString);
             c.Open();
             string query = "Select * from MyEvents where Name='" + textBox1.Text + "'";
             SqlCommand cm = new SqlCommand(query, c);
             SqlDataReader read = cm.ExecuteReader();
             Manage mn = new Manage();
             if (!read.HasRows)
             {
                 /*string q = "Insert Into MyEvents(Name,Date,Location,Pictures,EventDescription) Values('"+textBox1.Text+"','"+date.Text+"','"+textBox3.Text+"','"+textBox4.Text+"','"+textBox5.Text+"')";
                 cm=new SqlCommand(q, c);
                 cm.ExecuteNonQuery();
                 read.Close();
                 c.Close();
                 read.Close();
                 c.Close();

                 mn.AddEvent();

             }
             else
             {
                 MessageBox.Show("Such Name Already exist! Try a differemt name");
                 //read.Close();
             }*/
            SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["Diary"].ConnectionString);
            c.Open();
            string q = "Insert Into MyEvents(Name,Date,Location,Pictures,EventDescription,UserId,Importance)" + "Values('" + textBox1.Text + "','" + date.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','"+UserId+"','"+listBox1.Text+"')";
            SqlCommand cm = new SqlCommand(q, c);

            cm.ExecuteNonQuery();
            c.Close();
            MessageBox.Show("Event Added Successfully!");
            this.Hide();
            MyEvents m = new MyEvents();
            m.Show();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Field is Auto Generated");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MyEvents m = new MyEvents();
            this.Hide();
            m.Show();
        }
    }
}
