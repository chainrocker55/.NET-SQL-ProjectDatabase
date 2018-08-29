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
    public partial class จัดการประเภท : Form
    {
        public จัดการประเภท()
        {
            InitializeComponent();
        }
        MySqlConnection con = new MySqlConnection("host = localhost ; user=59160089;password=59160089;database=s59160089;CharSet=UTF8");
        MySqlCommand cmd;

        MySqlDataAdapter da;
        MySqlDataReader read;
        String s = "";
        void comboboxtypeproduct()
        {
            name.Items.Clear();
            cmd = new MySqlCommand("SELECT name FROM typeproduct WHERE name != 'ทั้งหมด'", con);
            con.Open();
            read = cmd.ExecuteReader();
            while (read.Read())
            {
               name.Items.Add(read.GetString("name"));
            }
            con.Close();
        }
        private void จัดการประเภท_Load(object sender, EventArgs e)
        {
            delete.Enabled = false;
            fix.Enabled = false;
            add.Enabled = true;
            comboboxtypeproduct();

        }

        private void add_Click(object sender, EventArgs e)
        {


            try
            {
                if (
                name.Text != "" 
               
              )
                {
                    con.Close();
                    cmd = new MySqlCommand("INSERT INTO typeproduct VALUES ('" + name.Text + "')", con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    name.ResetText();
                    comboboxtypeproduct();
                    MessageBox.Show("เรียบร้อย");
                   
                }
               
                else
                {
                    MessageBox.Show("กรุณากรอบข้อมูลให้ครบ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }catch(Exception)
            {
                MessageBox.Show("ข้อมูลซ้ำ");
            }
        }

        private void search_Click(object sender, EventArgs e)
        {
            if (name.Text != "")
            {
                try
                {
                    con.Close();
                    cmd = new MySqlCommand("SELECT * FROM typeproduct WHERE name='" + name.Text+"'", con);
                    con.Open();
                    read = cmd.ExecuteReader();
                    if (read.Read())
                    {
                        name.Text = read.GetString("name");
                        delete.Enabled = true;
                        fix.Enabled = true;
                        s = read.GetString("name");
                    }
                    else
                    {
                        MessageBox.Show("ไม่พบ");
                    }
                    con.Close();
                }
                catch (Exception)
                {
                    MessageBox.Show("ไม่พบ");
                }
            }
        }

        private void delete_Click(object sender, EventArgs e)
        {
            try
            {
                if (name.Text != "")
                {
                    con.Close();
                    cmd = new MySqlCommand("DELETE FROM typeproduct WHERE name='" + name.Text + "'", con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("เรียบร้อย");
                   
                }
                comboboxtypeproduct();
                delete.Enabled = false;
                fix.Enabled = false;

                name.ResetText();
            }
            catch (Exception)
            {
                MessageBox.Show("ไม่พบรหัสนี้");

            }
        }

        private void fix_Click(object sender, EventArgs e)
        {
            if (name.Text != "")
            {
                con.Close();
                cmd = new MySqlCommand("UPDATE typeproduct SET name='"+name.Text+ "' WHERE name='"+s+"'", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("เรียบร้อย");
              

            }
            comboboxtypeproduct();
            delete.Enabled = false;
            fix.Enabled = false;

            name.ResetText();
        }

        private void จัดการประเภท_FormClosing(object sender, FormClosingEventArgs e)
        {
            จัดการสินค้า aa = new จัดการสินค้า();

            aa.up();
            aa.Update();
   
        }

        private void จัดการประเภท_FormClosed(object sender, FormClosedEventArgs e)
        {
            จัดการสินค้า aa = new จัดการสินค้า();

           
        }
    }
}
