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
    public partial class cancelorder : Form
    {
        public cancelorder()
        {
            InitializeComponent();
        }
        MySqlConnection con = new MySqlConnection("host = localhost ; user=59160089;password=59160089;database=s59160089;CharSet=UTF8");
        MySqlCommand cmd;

        MySqlDataAdapter da;
        MySqlDataReader read;
        void set()
        {
            con.Close();
            cmd = new MySqlCommand("SELECT COUNT(ID) FROM Copy", con);
            con.Open();
            read = cmd.ExecuteReader();
            if (read.Read())
            {
                int r = read.GetInt32("COUNT(ID)");
                for (int i = 0; i < r; i++)
                {
                    con.Close();
                    cmd = new MySqlCommand("SELECT MIN(ID) FROM Copy", con);
                    con.Open();
                    read = cmd.ExecuteReader();
                    if (read.Read())
                    {
                        int r2 = read.GetInt32("MIN(ID)");
                        con.Close();

                        cmd = new MySqlCommand("UPDATE Product SET Qty=Qty+(SELECT Qty FROM Copy WHERE ID=(SELECT MIN(ID) FROM Copy)) WHERE Product_ID=(SELECT Product_ID FROM Copy WHERE ID=(SELECT MIN(ID) FROM Copy));DELETE FROM Copy WHERE ID='" + r2 + "';", con);
                        con.Open();
                        cmd.ExecuteReader();
                        con.Close();
                    }
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("กรุณาป้อนรหัสก่อน");

            }
            else
            {
                DialogResult dialog = MessageBox.Show("Confrim", "DELETE", MessageBoxButtons.YesNo);
                if (dialog == DialogResult.Yes)
                {
                    con.Close();
                    cmd = new MySqlCommand("SELECT * FROM orderdetails WHERE Order_ID = '" + textBox1.Text + "'", con);
                    con.Open();
                    read = cmd.ExecuteReader();
                    if (read.Read())
                    {
                        con.Close();
                        cmd = new MySqlCommand("INSERT INTO copy (Qty,Product_ID) SELECT Qty,Product_ID FROM orderdetails WHERE Order_ID =" + textBox1.Text + " ;DELETE FROM orders WHERE Order_ID = '" + textBox1.Text + "'", con);

                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        set();

                        MessageBox.Show("เรียบร้อย");
                    }
                    else
                    {
                        MessageBox.Show("ไม่พบบิลนี้");
                    }


                }
            }
        }
    }
}
