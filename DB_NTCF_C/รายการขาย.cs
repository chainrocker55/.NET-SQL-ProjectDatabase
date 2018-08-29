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
    public partial class รายการขาย : Form
    {
        public รายการขาย()
        {
            InitializeComponent();
        }
        MySqlConnection con = new MySqlConnection("host = localhost ; user=59160089;password=59160089;database=s59160089;CharSet=UTF8");
        MySqlCommand cmd;

        MySqlDataAdapter da;
        MySqlDataReader read;
        int status = 0;
        void datagrid(String sql)
        {
            try
            {
                con.Close();
                con.Open();

                cmd = new MySqlCommand(sql, con);
                da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("ไม่มีไอดีนี้");
            }
        }
        private void retail_Click(object sender, EventArgs e)
        {
            status = 1;
            datagrid("SELECT * FROM recRetailer WHERE dateofpay >='" + date1.Text + "' AND dateofpay <='" + date2.Text + "'");
        }

        private void order_Click(object sender, EventArgs e)
        {
            status = 2;
            datagrid("SELECT * FROM orders WHERE Date_Order >='" + date1.Text + "' AND Date_Order <='" + date2.Text + "'");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ID.Text != "")
            {
                datagrid("SELECT * FROM recdetailretailer WHERE recRetailer_ID=" + ID.Text);
            }
            else
            {
                MessageBox.Show("กรุณาป้อน ID ก่อน");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (ID.Text != "")
            {
                DialogResult dialog = MessageBox.Show("Confrim", "DELETE", MessageBoxButtons.YesNo);
                if (dialog == DialogResult.Yes)
                {
                    cmd = new MySqlCommand("DELETE FROM recretailer WHERE recRetailer_ID = '" + ID.Text + "'", con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("ลบ สำเร็จ");
           
                }



                datagrid("SELECT * FROM recdetailretailer WHERE recRetailer_ID=" + ID.Text);
            }
            else
            {
                MessageBox.Show("กรุณาป้อน ID ก่อน");
            }
        }

        private void de_Click(object sender, EventArgs e)
        {
            if (status == 1)
            {
                DialogResult dialog = MessageBox.Show("Confrim ลบ "+ date1.Text+" ถึง "+date2.Text, "DELETE", MessageBoxButtons.YesNo);
                if (dialog == DialogResult.Yes)
                {
                    cmd = new MySqlCommand("DELETE FROM recretailer WHERE dateofpay >='" + date1.Text + "' AND dateofpay <='" + date2.Text + "'", con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("ลบ สำเร็จ");
                    datagrid("SELECT * FROM recRetailer WHERE dateofpay >='" + date1.Text + "' AND dateofpay <='" + date2.Text + "'");

                }
            }
            else if(status==2)
            {
                DialogResult dialog = MessageBox.Show("Confrim ลบ " + date1.Text + " ถึง " + date2.Text, "DELETE", MessageBoxButtons.YesNo);
                if (dialog == DialogResult.Yes)
                {
                    cmd = new MySqlCommand("DELETE FROM orders WHERE Date_Order >='" + date1.Text + "' AND Date_Order <='" + date2.Text + "'", con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("ลบ สำเร็จ");
                    datagrid("SELECT * FROM orders WHERE Date_Order >='" + date1.Text + "' AND Date_Order <='" + date2.Text + "'");

                }
            }
            else
            {

            }
        }
    }
}
