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
using System.Threading;

namespace CloudDiary
{
   
    public partial class Form1 : Form
    {
       public static string UseridText;
       
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
            
        }

        private void button1_Click(object sender, EventArgs e)//create
        {
            SignUp sg = new SignUp();
            sg.Show();
            this.Hide();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            
                SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["Diary"].ConnectionString);
                c.Open();
                string query = "Select * from Logon where UserID='" + textBox1.Text + "'and Password='" + textBox2.Text + "'";
                SqlCommand command = new SqlCommand(query, c);
                SqlDataReader reader = command.ExecuteReader();
                //SqlConnection conn = null;
                //SqlCommand cmd = null;

                /*try
                {
                    conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Diary"].ConnectionString);

                    cmd.CommandType = CommandType.StoredProcedure;


                    conn.Open(); //opens connection
                    cmd = new SqlCommand(query, conn);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (!reader.HasRows)
                    {


                        MessageBox.Show("Incorrect Credentials");

                    }
                    else
                    {

                        MessageBox.Show("Login successfull");
                        reader.Close();
                       conn.Close();
                        this.Hide();
                        MyEvents mv = new MyEvents();
                        mv.Show();


                    }




                }
                catch (Exception ex)
                {
                    MessageBox.Show("");
                    ex.ToString();
                    throw;
                }
                finally
                {
                    if (conn != null)
                        conn.Dispose();

                    if (cmd != null)
                        cmd.Dispose();
                }*/

                if (!reader.HasRows)
                {


                    MessageBox.Show("Incorrect Credentials");

                }
                else
                {

                    
                        this.Hide();
                        
                        Form1.UseridText = textBox1.Text;
                        MyEvents m = new MyEvents();
                        
                        m.Show();
                        reader.Close();
                        c.Close();
                    
                }
            }
            

            // m.Close();

        

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            MyEvents mv = new MyEvents();
            mv.Show();

        }
    }
}
