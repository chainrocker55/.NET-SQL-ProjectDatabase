using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace DB_NTCF_C
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
          MySqlConnection con = new MySqlConnection("host = localhost ; user=59160089;password=59160089;database=s59160089");


        void resetuserpass()
        {
            pass_text.Text = "Password";
            pass_text.UseSystemPasswordChar = false;
            pass_text.ForeColor = System.Drawing.Color.Gray;
            username_text.Text = "Username";
            username_text.ForeColor = System.Drawing.Color.Gray;
        }

        private void LOgin_but_Click(object sender, EventArgs e)
        {
            if (username_text.Text.Equals("Username") || pass_text.Text.Equals("Password"))
            {
                MessageBox.Show("กรุณากรอกข้อมูลให้ครบ");
            }
            else
            {
                con.Close();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM login WHERE username='" + username_text.Text + "' AND password='" + pass_text.Text + "'", con);
                con.Open();
                MySqlDataReader r = cmd.ExecuteReader();
                if (r.Read())
                {
                    home.empids = "";
                   
                  
                    home h = new home(username_text.Text);
                    resetuserpass();
                    this.Hide();
                    h.ShowDialog();
                    this.Show();
                }
                else
                {
                    MessageBox.Show("กรุณากรอกข้อมูลให้ถูกต้อง", "not found");
                    resetuserpass();
                }
            }

            con.Close();

            

           
        }

        private void close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void username_text_Click(object sender, EventArgs e)
        {
            if (username_text.Text.Equals("username"))
            {
                username_text.ForeColor = System.Drawing.Color.Black;
                username_text.Clear();
            }
        }

        private void username_text_Leave(object sender, EventArgs e)
        {
            if (username_text.Text.Equals(""))
            {
                username_text.Text = "Username";
                username_text.ForeColor = System.Drawing.Color.Gray;
            }
        }

        private void pass_text_Click(object sender, EventArgs e)
        {
            pass_text.UseSystemPasswordChar = true;
            if (pass_text.Text.Equals("Password"))
            {
                pass_text.Clear();
                pass_text.ForeColor = System.Drawing.Color.Black;
            }
        }

        private void pass_text_Leave(object sender, EventArgs e)
        {
            if (pass_text.Text.Equals(""))
            {
                pass_text.Text = "Password";
                pass_text.UseSystemPasswordChar = false;
                pass_text.ForeColor = System.Drawing.Color.Gray;
            }
        }

        private void showpass_Click(object sender, EventArgs e)
        {
            try
            {
                if (pass_text.UseSystemPasswordChar == true)
                {
                    pass_text.UseSystemPasswordChar = false;
                }
                else
                {
                    pass_text.UseSystemPasswordChar = true;
                }
            }
            catch (Exception)
            {

            }
        }

        private void Login_Load(object sender, EventArgs e)
        {
            home.empids = "";
        }
    }
}
