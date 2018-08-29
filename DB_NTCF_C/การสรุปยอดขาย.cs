using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DB_NTCF_C
{
    public partial class การสรุปยอดขาย : Form
    {
        public การสรุปยอดขาย()
        {
            InitializeComponent();
        }
        MySqlConnection con = new MySqlConnection("host = localhost ; user=59160089;password=59160089;database=s59160089;CharSet=UTF8");
        MySqlCommand cmd;

        
        MySqlDataReader read;
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                sumretailer.Text = "";
                sum2.Text = "";
                sum3.Text = "";
                cmd = new MySqlCommand("SELECT SUM(sumprice) FROM recretailer WHERE dateofpay >='" + date1.Text + "' AND dateofpay <='" + date2.Text + "'", con);
                con.Close();
                con.Open();
                read = cmd.ExecuteReader();

                if (read.Read())
                {
                    sumretailer.Text = read.GetString("SUM(sumprice)");
                }
                con.Close();

            }
            catch (Exception)
            {
                sumretailer.Text = "0";
            
        
            }
            try { 
                cmd = new MySqlCommand("SELECT SUM(Total_Price) FROM orders WHERE Date_Order >='" + date1.Text + "' AND Date_Order <= '" + date2.Text+"'", con);

                con.Open();
                read = cmd.ExecuteReader();

                if (read.Read())
                {
                    sum2.Text = read.GetString("SUM(Total_Price)");
                }
                con.Close();

               
            }
            catch (Exception)
            {
                sum2.Text = "0";             
            }
            sum3.Text = "" + (Int32.Parse(sumretailer.Text) + Int32.Parse(sum2.Text));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                con.Close();
                cmd = new MySqlCommand("SELECT SUM(SumPrice) FROM recordervendor WHERE Date >= '" + date3.Text + "' AND Date <='" + date4.Text+"'", con);
                
                con.Open();
                read = cmd.ExecuteReader();

                if (read.Read())
                {
                    sum4.Text = read.GetString("SUM(SumPrice)");
                }
                con.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Data is Null");
                sum4.Text = "0";
            }

        }

        private void seach1_Click(object sender, EventArgs e)
        {
            รายการขาย a = new รายการขาย();
            this.Hide();
            a.ShowDialog();
            this.Show();
            
        }

        private void seach2_Click(object sender, EventArgs e)
        {
            สรุปยอดรวม a = new สรุปยอดรวม();
            this.Hide();
            a.ShowDialog();
            this.Show();
        }
    }
}
