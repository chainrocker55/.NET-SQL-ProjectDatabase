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
    public partial class รับสินค้า : Form
    {
        public รับสินค้า()
        {
            InitializeComponent();
        }

        MySqlConnection con = new MySqlConnection("host = localhost ; user=59160089;password=59160089;database=s59160089;CharSet=UTF8");
        MySqlCommand cmd;

        MySqlDataAdapter da;
        MySqlDataReader read;
        void datagrid(String sql,DataGridView name)
        {
            con.Close();
            con.Open();

            cmd = new MySqlCommand(sql, con);
            da = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            name.DataSource = dt;
            con.Close();
        }
        void datagridshow(String sql)
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
        void datagridshow2(String sql)
        {
            con.Close();
            con.Open();

            cmd = new MySqlCommand(sql, con);
            da = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView4.DataSource = dt;
            con.Close();
        }

        void update(DataGridView name,string sql)
        {
            con.Close();
            con.Open();
            cmd = new MySqlCommand(sql, con);
            da = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            name.DataSource = dt;
            con.Close();
        }
        void combobox(string sql,string id,ComboBox s)
        {
            s.Items.Clear();          
            cmd = new MySqlCommand(sql, con);
            con.Open();
            read = cmd.ExecuteReader();
            while (read.Read())
            {
                s.Items.Add(read.GetString(id));
            }
            con.Close();
        }
       

        private void รับสินค้า_Load(object sender, EventArgs e)
        {
            deleteall.Enabled = false;
            detail.Enabled = false;
            delete.Enabled = false;
            detail4.Enabled = false;
            delete4.Enabled = false;
            add.Enabled = false;
            add2.Enabled = false;
            update(dataGridView1, "SELECT * FROM recReOrder");
            update(dataGridView4, "SELECT * FROM recreceiveclaim");
            update(dataGridView2, "SELECT * FROM recclaimvendor_id WHERE recClaimVendor_ID NOT IN (SELECT recClaimVendor_ID FROM recreceiveclaim )");
            update(dataGridView3, "SELECT * FROM recordervendor WHERE recOrderVendor_ID NOT IN(SELECT recOrderVendor_ID FROM recreorder)");
            combobox("SELECT * FROM recReOrder", "recReOrder_ID",idsearch);
            combobox("SELECT * FROM recreceiveclaim", "recReceiveClaim_ID", idsearch4);
            combobox("SELECT * FROM recordervendor WHERE recOrderVendor_ID NOT IN (SELECT recOrderVendor_ID FROM recreorder )", "recOrderVendor_ID", idsearch2);
            combobox("SELECT * FROM recclaimvendor_id WHERE recClaimVendor_ID NOT IN (SELECT recClaimVendor_ID FROM recreceiveclaim )", "recClaimVendor_ID", idclaim);
        }
        private void search_Click(object sender, EventArgs e)
        {
            if (idsearch.Text.Equals(""))
            {
                update(dataGridView1, "SELECT * FROM recReOrder");                             
                delete.Enabled = false;
                deleteall.Enabled = false;
            }
            else
            {

                datagrid("SELECT * FROM recReOrder WHERE recReOrder_ID ='" + idsearch.Text + "' ",dataGridView1);
                cmd = new MySqlCommand("SELECT * FROM recReOrder WHERE recReOrder_ID ='" + idsearch.Text + "' ", con);
                con.Open();
                read = cmd.ExecuteReader();
                if (read.Read())
                {
                    detail.Enabled = true;
                    delete.Enabled = true;
                    deleteall.Enabled = false;
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
                deleteall.Enabled = false;
                cmd = new MySqlCommand("DELETE FROM recReOrder WHERE recReOrder_ID = '" + idsearch.Text + "'", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                update(dataGridView1, "SELECT * FROM recReOrder");
                combobox("SELECT * FROM recReOrder", "recReOrder_ID",idsearch);               
                delete.Enabled = false;
                detail.Enabled = false;
                deleteall.Enabled = false;
            }

        }        
       
        //หน้าสอง
        private void seach2_Click(object sender, EventArgs e)
        {
            if (idsearch2.Text.Equals(""))
            {
                update(dataGridView3, "SELECT * FROM recordervendor WHERE recOrderVendor_ID NOT IN(SELECT recOrderVendor_ID FROM recreorder)");
                
                add.Enabled = false;
            }
            else
            {

                datagrid("SELECT * FROM recdetailordervendor WHERE recOrderVendor_ID ='" + idsearch2.Text + "' AND recOrderVendor_ID NOT IN(SELECT recOrderVendor_ID FROM recreorder) ", dataGridView3);
                cmd = new MySqlCommand("SELECT * FROM recdetailordervendor WHERE recOrderVendor_ID = '" + idsearch2.Text + "' AND recOrderVendor_ID NOT IN(SELECT recOrderVendor_ID FROM recreorder)", con);
                con.Open();
                read = cmd.ExecuteReader();
                if (read.Read())
                {
                    add.Enabled = true;
                }
                else
                {
                    MessageBox.Show("ไม่พบรหัสนี้", "ไม่พบ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                  
                }

            }
            con.Close();
        }

       

       

        private void idsearch3_Click(object sender, EventArgs e)
        {
            if (idclaim.Text.Equals(""))
            {
                update(dataGridView2, "SELECT * FROM recclaimvendor_id WHERE recClaimVendor_ID NOT IN (SELECT recClaimVendor_ID FROM recreceiveclaim )");
                add2.Enabled = false;
            }
            else
            {

                datagrid("SELECT * FROM detailclaimvendor WHERE recClaimVendor_ID ='" + idclaim.Text + "' AND  recClaimVendor_ID NOT IN (SELECT recClaimVendor_ID FROM recreceiveclaim )", dataGridView2);
                cmd = new MySqlCommand("SELECT * FROM detailclaimvendor WHERE recClaimVendor_ID ='" + idclaim.Text + "' AND  recClaimVendor_ID NOT IN (SELECT recClaimVendor_ID FROM recreceiveclaim )", con);
                con.Open();
                read = cmd.ExecuteReader();
                if (read.Read())
                {
                    add2.Enabled = true;                

                }
                else
                {
                    MessageBox.Show("ไม่พบรหัสนี้", "ไม่พบ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                }

            }
            con.Close();
        }

       

       

        private void detail_Click(object sender, EventArgs e)
        {
            datagrid("SELECT * FROM recdetailreorder WHERE recReOrder_ID ='" + idsearch.Text + "' ", dataGridView1);
        }

        private void add_Click(object sender, EventArgs e)
        {
            if (idsearch2.Text.Equals(""))
            {
                MessageBox.Show("กรุณาใส่รหัส");
            }
            else
            {
                con.Close();
                cmd = new MySqlCommand("INSERT INTO recdetailreorder (Qty,Price,Product_ID) SELECT Qty,Price,Product_ID FROM recdetailordervendor WHERE recOrderVendor_ID='"+ idsearch2.Text+ "';INSERT INTO copy (Qty,Product_ID) SELECT Qty,Product_ID FROM recdetailordervendor WHERE recOrderVendor_ID='" + idsearch2.Text + "';INSERT INTO recreorder VALUES(NULL,'" + dateRE.Text+ "',(SELECT SUM(Qty) FROM recdetailreorder WHERE recReOrder_ID IS NULL),(SELECT SUM(Qty*Price) FROM recdetailreorder WHERE recReOrder_ID IS NULL),'"+idsearch2.Text+"','"+home.empids+ "');UPDATE recdetailreorder SET recReOrder_ID=(SELECT MAX(recReOrder_ID) FROM recReOrder) WHERE recReOrder_ID IS NULL", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                add.Enabled = false;
                update(dataGridView1, "SELECT * FROM recReOrder");
                update(dataGridView3, "SELECT * FROM recordervendor WHERE recOrderVendor_ID NOT IN (SELECT recOrderVendor_ID FROM recreorder)");
                combobox("SELECT * FROM recReOrder", "recReOrder_ID", idsearch);
                combobox("SELECT * FROM recordervendor WHERE recOrderVendor_ID NOT IN (SELECT recOrderVendor_ID FROM recreorder )", "recOrderVendor_ID", idsearch2);
                combobox("SELECT * FROM recclaimvendor_id WHERE recClaimVendor_ID NOT IN (SELECT recClaimVendor_ID FROM recreceiveclaim )", "recClaimVendor_ID", idclaim);
                idsearch2.ResetText();
                
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

                             cmd = new MySqlCommand("UPDATE Product SET Qty=Qty+(SELECT Qty FROM Copy WHERE ID=(SELECT MIN(ID) FROM Copy)) WHERE Product_ID=(SELECT Product_ID FROM Copy WHERE ID=(SELECT MIN(ID) FROM Copy));DELETE FROM Copy WHERE ID='"+r2+"';", con);
                             con.Open();
                             cmd.ExecuteReader();
                             con.Close();
                        }
                    }
                }
               
               
               
            }
            con.Close();
           
        }

        private void add2_Click_1(object sender, EventArgs e)
        {
            if (idclaim.Text.Equals(""))
            {
                MessageBox.Show("กรุณาใส่รหัส");
            }
            else
            {
                con.Close();
                cmd = new MySqlCommand("INSERT INTO recdetailreclaim (Qty,price,Product_ID) SELECT  Qty,price,Product_ID FROM detailclaimvendor WHERE recClaimVendor_ID='" + idclaim.Text + "';INSERT INTO copy (Qty,Product_ID) SELECT Qty,Product_ID FROM detailclaimvendor WHERE recClaimVendor_ID='" + idclaim.Text + "';" +
                    "INSERT INTO recreceiveclaim VALUES(NULL,(SELECT SUM(Qty) FROM recdetailreclaim WHERE recReceiveClaim_ID IS NULL),'"+idclaim.Text+ "','" + home.empids + "','"+dateRE2.Text+ "',(SELECT SUM(Qty*price) FROM recdetailreclaim WHERE recReceiveClaim_ID IS NULL));" +
                    "UPDATE recdetailreclaim SET recReceiveClaim_ID=(SELECT MAX(recReceiveClaim_ID) FROM recReceiveClaim) WHERE recReceiveClaim_ID IS NULL", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                combobox("SELECT * FROM recreceiveclaim", "recReceiveClaim_ID", idsearch4);
                    update(dataGridView4, "SELECT * FROM recreceiveclaim");
                    update(dataGridView2, "SELECT * FROM recclaimvendor_id WHERE recClaimVendor_ID NOT IN (SELECT recClaimVendor_ID FROM recreceiveclaim )");
                    combobox("SELECT * FROM recReOrder", "recReOrder_ID", idsearch);
               combobox("SELECT * FROM recclaimvendor_id WHERE recClaimVendor_ID NOT IN (SELECT recClaimVendor_ID FROM recreceiveclaim )", "recClaimVendor_ID", idclaim);
                idclaim.ResetText();

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
               
        }

        private void search4_Click(object sender, EventArgs e)
        {
            if (idsearch.Text.Equals(""))
            {
                update(dataGridView4, "SELECT * FROM recreceiveclaim");
                delete4.Enabled = false;
            }
            else
            {
                con.Close();
                datagrid("SELECT * FROM recreceiveclaim WHERE recReceiveClaim_ID ='" + idsearch4.Text + "' ", dataGridView4);
                cmd = new MySqlCommand("SELECT * FROM recreceiveclaim WHERE recReceiveClaim_ID ='" + idsearch4.Text + "' ", con);
                con.Open();
                read = cmd.ExecuteReader();
                if (read.Read())
                {
                    detail4.Enabled = true;
                    deleteall2.Enabled = false;
                }
                else
                {
                    MessageBox.Show("ไม่พบรหัสสินค้านี้", "ไม่พบ", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }

            }
            con.Close();
        }

        private void delete4_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Confrim", "DELETE", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                con.Close();
                cmd = new MySqlCommand("DELETE FROM recreceiveclaim WHERE recReceiveClaim_ID = '" + idsearch4.Text + "'", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                update(dataGridView4, "SELECT * FROM recreceiveclaim");
                combobox("SELECT * FROM recreceiveclaim", "recReceiveClaim_ID", idsearch4);
                delete4.Enabled = false;
                deleteall2.Enabled = false;
            }
        }

        private void detail4_Click(object sender, EventArgs e)
        {
            datagrid("SELECT * FROM recdetailreclaim WHERE recReceiveClaim_ID ='" + idsearch4.Text + "' ", dataGridView4);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            datagridshow("SELECT * FROM recreorder  WHERE DateRe >='" + da1.Text + "' AND DateRe <='" + da2.Text + "'");
            deleteall.Enabled = true;
        }

        private void deleteall_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialog = MessageBox.Show("Confrim ลบทั้งหมดของวันที่ " + da1.Text + " ถึง " + da2.Text, "DELETE", MessageBoxButtons.YesNo);

                if (dialog == DialogResult.Yes)
                {
                    con.Close();
                    cmd = new MySqlCommand("DELETE FROM recreorder WHERE  DateRe >='" + da1.Text + "' AND DateRe <='" + da2.Text + "'", con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    detail.Enabled = false;
                    deleteall.Enabled = false;
                }
            }
            catch (Exception)
            {

            }
            
        }

        private void searchall2_Click(object sender, EventArgs e)
        {
            datagridshow2("SELECT * FROM recreceiveclaim  WHERE DateGet >='" + da11.Text + "' AND DateGet <='" + da22.Text + "'");
            deleteall2.Enabled = true;
        }

        private void deleteall2_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialog = MessageBox.Show("Confrim ลบทั้งหมดของวันที่ " + da11.Text + " ถึง " + da22.Text, "DELETE", MessageBoxButtons.YesNo);

                if (dialog == DialogResult.Yes)
                {
                    con.Close();
                    cmd = new MySqlCommand("DELETE FROM recreceiveclaim  WHERE  DateGet >='" + da11.Text + "' AND DateGet <='" + da22.Text + "'", con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    detail4.Enabled = false;
                    deleteall2.Enabled = false;
                }
            }
            catch (Exception)
            {

            }
        }
    }
}
