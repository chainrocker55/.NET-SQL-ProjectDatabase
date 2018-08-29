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
    public partial class บันทึกการเคลมลูกค้า : Form
    {
        public บันทึกการเคลมลูกค้า()
        {
            InitializeComponent();
        }
        MySqlConnection con = new MySqlConnection("host = localhost ; user=59160089;password=59160089;database=s59160089;CharSet=UTF8");
        MySqlCommand cmd;

        MySqlDataAdapter da;
        MySqlDataReader read;
        private void บันทึกการเคลมลูกค้า_Load(object sender, EventArgs e)
        {
            detailsearch.Enabled = false;
            update();
            delete.Enabled = false;
            save.Enabled = true;
            save2.Enabled = false;
            combobox();
           // combobox2();
            combobox3();
            deleteall2.Enabled = false;
            comboboxsend();
        }
        void combobox()
        {
            id.Items.Clear();
            cmd = new MySqlCommand("SELECT * FROM recClaimCustomer", con);
            con.Open();
            read = cmd.ExecuteReader();
            while (read.Read())
            {
                id.Items.Add(read.GetString("recClaimCustomer_ID"));
            }
            con.Close();
        }
        void comboboxsend()
        {
            idsend.Items.Clear();
            cmd = new MySqlCommand("SELECT * FROM recsender", con);
            con.Open();
            read = cmd.ExecuteReader();
            while (read.Read())
            {
                idsend.Items.Add(read.GetString("recSender_ID"));
            }
            con.Close();
        }
        void update()
        {
            con.Close();
            con.Open();

            cmd = new MySqlCommand("SELECT * FROM recclaimcustomer", con);
            da = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dtg.DataSource = dt;
            con.Close();
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
        void combobox3()
        {
            id2.Items.Clear();
            cmd = new MySqlCommand("SELECT Product_ID FROM product", con);
            con.Open();
            read = cmd.ExecuteReader();
            while (read.Read())
            {
                id2.Items.Add(read.GetString("Product_ID"));
            }
            con.Close();
        }       

        private void search_Click(object sender, EventArgs e)
        {
            if (id.Text.Equals(""))
            {
                update();
                delete.Enabled = false;
                deleteall2.Enabled = false;
            }
            else
            {

                datagrid("SELECT * FROM recclaimcustomer WHERE recClaimCustomer_ID ='" + id.Text + "' ");
                cmd = new MySqlCommand("SELECT * FROM recclaimcustomer WHERE recClaimCustomer_ID ='" + id.Text + "' ", con);
                con.Open();
                read = cmd.ExecuteReader();
                if (read.Read())
                {
                    delete.Enabled = true;
                    detailsearch.Enabled = true;
                    deleteall2.Enabled = false;

                }
                else
                {
                    MessageBox.Show("ไม่พบรหัสสินค้านี้", "ไม่พบ", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }

            }
            con.Close();
        }

        private void delete_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Confrim", "DELETE", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                cmd = new MySqlCommand("DELETE FROM recClaimCustomer WHERE recClaimCustomer_ID = '" + id.Text + "'", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                update();
                delete.Enabled = false;
                combobox();
                detailsearch.Enabled = false;
                deleteall2.Enabled = false;
                id.ResetText();

            }
        }

        private void detailsearch_Click(object sender, EventArgs e)
        {
            datagrid("SELECT * FROM recdetailclaimcus WHERE recDetailClaimCus_ID ='" + id.Text + "' ");
            detailsearch.Enabled = false;
        }

        private void save_Click_1(object sender, EventArgs e)
        {
            if (
           id2.Text != "" &&
           qty1.Text != "" &&
          
           cause.Text != "")

            {
                try {
                    con.Close();
                    save2.Enabled = true;
                    cmd = new MySqlCommand("INSERT INTO recdetailclaimcus  VALUES('NULL','" + qty1.Text + "',1,NULL,'" + id2.Text + "')", con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    datagrid2("SELECT * FROM recdetailclaimcus WHERE recClaimCustomer_ID IS NULL");

                }
                catch (Exception)
                {
                    MessageBox.Show("กรอกข้อมูลผิด");
                }
                }
            else
            {
                MessageBox.Show("กรุณากรอบข้อมูลให้ครบ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void save2_Click(object sender, EventArgs e)
        {
            if (
                datesent.Text != "" &&
                datereceive.Text != "" &&
                cause.Text != "" &&
                idsend.Text!=""
           )

            {
                try {
                    con.Close();

                    cmd = new MySqlCommand("INSERT INTO `recclaimcustomer` (`recClaimCustomer_ID`, `Date_Cus_Claim`, `Date_Product_Cus`, `Cause`, `Sum_Qty`, `status`, `recSender_ID`) VALUES(NULL, '" + datesent.Text + "', '" + datereceive.Text + "', '" + cause.Text + "',(SELECT SUM(Qty) FROM recdetailclaimcus WHERE recClaimCustomer_ID IS NULL), '0',"+idsend.Text+"); UPDATE recdetailclaimcus SET recClaimCustomer_ID=(SELECT MAX(recClaimCustomer_ID) FROM recClaimCustomer) WHERE recClaimCustomer_ID IS NULL", con);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    datagrid("SELECT * FROM recclaimcustomer");
                    combobox();
                    datagrid2("SELECT * FROM recdetailclaimcus WHERE recClaimCustomer_ID IS NULL");
                    save2.Enabled = false;
                    MessageBox.Show("เรียบร้อย");

                }
                catch (Exception)
                {
                    MessageBox.Show("กรอกข้อมูลผิด");
                }
                }
            else
            {
                MessageBox.Show("กรุณากรอบข้อมูลให้ครบ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void บันทึกการเคลมลูกค้า_FormClosing(object sender, FormClosingEventArgs e)
        {
            con.Close();
            cmd = new MySqlCommand("DELETE FROM recDetailClaimCus WHERE recClaimCustomer_ID IS NULL", con);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        private void searchall2_Click(object sender, EventArgs e)
        {
            datagrid("SELECT * FROM recclaimcustomer WHERE Date_Cus_Claim >='" + da11.Text + "' AND Date_Cus_Claim <='" + da22.Text + "'");
            id.ResetText();
            deleteall2.Enabled = true;
        }

        private void deleteall2_Click(object sender, EventArgs e)
        {

            id.ResetText();
            DialogResult dialog = MessageBox.Show("Confrim ลบทั้งหมดของวันที่ " + da11.Text + " ถึง " + da22.Text, "DELETE", MessageBoxButtons.YesNo);
            try
            {
                if (dialog == DialogResult.Yes)
                {
                    
                    cmd = new MySqlCommand("DELETE FROM recclaimcustomer WHERE  Date_Cus_Claim >='" + da11.Text + "' AND Date_Cus_Claim <='" + da22.Text + "'", con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    datagrid("SELECT * FROM recclaimcustomer WHERE Date_Cus_Claim >='" + da11.Text + "' AND Date_Cus_Claim <='" + da22.Text + "'");
                    detailsearch.Enabled = false;
                    id.ResetText();


                    deleteall2.Enabled = false;
                }
            }
            catch (Exception)
            {

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            datagrid("SELECT * FROM recclaimcustomer WHERE Status=0");
            detailsearch.Enabled = false;
            id.ResetText();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (id.Text.Equals(""))
            {
                update();
                delete.Enabled = false;
                deleteall2.Enabled = false;
            }
            else
            {

                con.Close();
                cmd = new MySqlCommand("SELECT * FROM recclaimcustomer WHERE recClaimCustomer_ID ='" + id.Text + "' ", con);
                con.Open();
                read = cmd.ExecuteReader();
                if (read.Read())
                {

                    con.Close();
                    cmd = new MySqlCommand("UPDATE recclaimcustomer SET status=1 WHERE recClaimCustomer_ID ='" + id.Text + "' ", con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();




                    delete.Enabled = true;
                    detailsearch.Enabled = true;
                    deleteall2.Enabled = false;
                    datagrid("SELECT * FROM recclaimcustomer WHERE recClaimCustomer_ID ='" + id.Text + "' ");
                    MessageBox.Show("เรียบร้อย");

                }
                else
                {
                    MessageBox.Show("ไม่พบรหัสสินค้านี้", "ไม่พบ", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }

            }
            con.Close();
        }
    }
    
}
   
     

 