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
    public partial class บันทึกการเคลม : Form
    {
        public บันทึกการเคลม()
        {
            InitializeComponent();
        }
        MySqlConnection con = new MySqlConnection("host = localhost ; user=59160089;password=59160089;database=s59160089;CharSet=UTF8");
        MySqlCommand cmd;

        MySqlDataAdapter da;
        MySqlDataReader read;
        
        void clear_text()
        {
            id2.ResetText();
            cause.Clear();
            จำนวน.Clear();
           
        }
        void datagrid(String sql)
        {
            con.Close();
            con.Open();

            cmd = new MySqlCommand(sql, con);
            da = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dtg.DataSource = dt;
            con.Close();
        }
        void datagrid2(String sql)
        {
            con.Close();
            con.Open();

            cmd = new MySqlCommand(sql, con);
            da = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView2.DataSource = dt;
            con.Close();
        }
        void combobox()
        {
            id.Items.Clear();
            cmd = new MySqlCommand("SELECT * FROM recclaimvendor_id", con);
            con.Open();
            read = cmd.ExecuteReader();
            while (read.Read())
            {
                id.Items.Add(read.GetString("recClaimVendor_ID"));
            }
            con.Close();
        }
        void combobox2()
        {
            idorder.Items.Clear();
            cmd = new MySqlCommand("SELECT * FROM recOrderVendor", con);
            con.Open();
            read = cmd.ExecuteReader();
            while (read.Read())
            {
                idorder.Items.Add(read.GetString("recOrderVendor_ID"));
            }
            con.Close();
        }
        void combobox3()
        {
            id2.Items.Clear();
            cmd = new MySqlCommand("SELECT * FROM recDetailOrderVendor WHERE recOrderVendor_ID ='"+idorder.Text+"'", con);
            con.Open();
            read = cmd.ExecuteReader();
            while (read.Read())
            {
                id2.Items.Add(read.GetString("Product_ID"));
            }
            con.Close();
        }

        void update()
        {
            con.Close();
            con.Open();

            cmd = new MySqlCommand("SELECT * FROM recclaimvendor_id", con);
            da = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dtg.DataSource = dt;
            con.Close();
        }
        void update2()
        {
            con.Close();
            con.Open();

            cmd = new MySqlCommand("SELECT * FROM detailclaimvendor NATURAL JOIN recclaimvendor_id WHERE recClaimVendor_ID ='" + id2.Text + "' ", con);
            da = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView2.DataSource = dt;
            con.Close();
        }
       

        private void save_Click(object sender, EventArgs e)
        {

            if (
              datesentddd.Text != "" &&
              datereceive.Text != "" &&
              cause.Text != "" &&
              id2.Text != "" &&
              qty.Text != "" &&

              idorder.Text != "")

            {
                try {
                    con.Close();
                    cmd = new MySqlCommand("INSERT recclaimvendor_id VALUES(NULL,'" + datesent.Text + "','" + datereceive.Text + "','1','" + cause.Text + "','" + idorder.Text + "');INSERT detailclaimvendor VALUES(NULL,'" + จำนวน.Text + "',(SELECT MAX(recClaimVendor_ID) FROM recclaimvendor_id),'" + id2.Text + "');=UPDATE Product SET Qty=Qty-"+จำนวน.Text+" WHERE Product_ID="+id2.Text, con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("เรียบร้อย");
                    con.Close();
                    combobox();
                    update();
                    clear_text();
                    datagrid2("SELECT * FROM detailclaimvendor WHERE recClaimVendor_ID =(SELECT MAX(recClaimVendor_ID) FROM recclaimvendor_id)");
                }
                catch (Exception)
                {
                    MessageBox.Show("กรอกข้อมูลผิด");
                }
                }
            else
            {
                MessageBox.Show("กรุณากรอกข้อมูลให้ครบ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void search_Click_1(object sender, EventArgs e)
        {
            if (id.Text.Equals(""))
            {
                update();                               
                delete.Enabled = false;
            }
            else
            {

                datagrid("SELECT * FROM recclaimvendor_id WHERE recClaimVendor_ID ='" + id.Text + "' ");
                cmd = new MySqlCommand("SELECT * FROM recclaimvendor_id WHERE recClaimVendor_ID ='" + id.Text + "' ", con);
                con.Open();
                read = cmd.ExecuteReader();
                if (read.Read())
                {
                    delete.Enabled = true;
                    detailsearch.Enabled = true;

                }
                else
                {
                    MessageBox.Show("ไม่พบรหัสสินค้านี้", "ไม่พบ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                }

            }
            con.Close();
        }

        private void delete_Click_1(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Confrim", "DELETE", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                cmd = new MySqlCommand("DELETE FROM recclaimvendor_id WHERE recClaimVendor_ID = '" + id.Text + "'", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                update();                              
                delete.Enabled = false;
                combobox();
                detailsearch.Enabled = false;

            }

        }

        private void search2_Click(object sender, EventArgs e)
        {
           
        

                datagrid2("SELECT * FROM detailclaimvendor NATURAL JOIN recclaimvendor_id WHERE recClaimVendor_ID ='" + id2.Text + "' ");
                cmd = new MySqlCommand("SELECT * FROM detailclaimvendor NATURAL JOIN recclaimvendor_id WHERE recClaimVendor_ID ='" + id2.Text + "' ", con);
                con.Open();
                read = cmd.ExecuteReader();
                if (read.Read())
                {
                    delete.Enabled = true;
                    save.Enabled = true;
                    

                    datesentddd.Text = read.GetString("DateRequest");
                    datereceive.Text = read.GetString("DateGet");                  
                    idorder.Text = read.GetString("recOrderVendor_ID");
                  

                }
                else
                {
                    MessageBox.Show("ไม่พบรหัสสินค้านี้", "ไม่พบ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    clear_text();
                }

            
            con.Close();
        
    }

        private void บันทึกการเคลม_Load(object sender, EventArgs e)
        {
            detailsearch.Enabled = false;
            update();          
            delete.Enabled = false;
            save.Enabled = true;
            combobox();
            combobox2();
            
        }

        private void detailsearch_Click(object sender, EventArgs e)
        {
            datagrid("SELECT * FROM detailclaimvendor WHERE recClaimVendor_ID ='" + id.Text + "' ");
        }

        private void serach2_Click(object sender, EventArgs e)
        {
            combobox3();
        }

        private void idorder_TextChanged(object sender, EventArgs e)
        {
            combobox3();
        }
    }
    }
