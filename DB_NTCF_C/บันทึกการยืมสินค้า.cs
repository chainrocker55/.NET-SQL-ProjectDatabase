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
    public partial class บันทึกการยืมสินค้า : Form
    {
        public บันทึกการยืมสินค้า()
        {
            InitializeComponent();
        }
        
        MySqlConnection con = new MySqlConnection("host = localhost ; user=59160089;password=59160089;database=s59160089;CharSet=UTF8");
        MySqlCommand cmd;

        MySqlDataAdapter da;
        MySqlDataReader read;
        int num = 0;
        void clear_text()
        {
            idpro.ResetText();
            qty.Clear();
            
        }
        void clear_text2()
        {
            idpro.ResetText();
            qty.Clear();
            branch1.ResetText();
            branch2.ResetText();
            empre.Clear();
            emprend.Items.Clear();
            sum.Clear();
        }
        void datagrid(String sql)
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
        void update()
        {
            con.Close();
            con.Open();

            cmd = new MySqlCommand("SELECT * FROM reclend ORDER BY Date_Lend ", con);
            da = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;          
            con.Close();
        }

        private void add_Click(object sender, EventArgs e)
        {
            if (
            idpro.Text != "" &&
            qty.Text != "")

            {
                try {

                    con.Close();
                    cmd = new MySqlCommand("SELECT Qty FROM Product WHERE Product_ID =" + idpro.Text, con);
                    con.Open();
                    read = cmd.ExecuteReader();
                    if (read.Read())
                    {
                        try
                        {
                            int num2 = read.GetInt32("Qty");
                            int num3 = Int32.Parse(qty.Text);
                            int num4 = num2 - num3;

                            con.Close();
                            cmd = new MySqlCommand("SELECT Qty FROM detailrend WHERE Product_ID =" + idpro.Text, con);
                            con.Open();
                            read = cmd.ExecuteReader();
                            if (read.Read())
                            {
                                int num5 = read.GetInt32("Qty");
                                num4 = num4 - num5;
                            }





                            if (num4 >= 0)
                            {

                                con.Close();
                                cmd = new MySqlCommand("SELECT Product_ID FROM detailrend WHERE recLend_ID IS NULL AND Product_ID =" + idpro.Text, con);

                                con.Open();
                                read = cmd.ExecuteReader();
                                if (read.Read())
                                {
                                    con.Close();
                                    cmd = new MySqlCommand("UPDATE detailrend SET Qty=Qty+" + qty.Text + "  WHERE recLend_ID IS NULL AND Product_ID= " + idpro.Text, con);
                                    con.Open();
                                    cmd.ExecuteNonQuery();
                                    con.Close();
                                    num += Int32.Parse(qty.Text);
                                    sum.Text = "" + num;
                                    clear_text();
                                    datagrid2("SELECT * FROM detailrend WHERE reclend_ID IS NULL");
                                }
                                else
                                {
                                    con.Close();
                                    cmd = new MySqlCommand("INSERT INTO detailrend  VALUES ('NULL','" + qty.Text + "','" + idpro.Text + "',NULL,NULL)", con);//UPDATE reclend SET Sum_Qty =Sum_Qty+"+qty.Text+ " WHERE reclend_ID IS NULL"
                                    con.Open();
                                    cmd.ExecuteNonQuery();
                                    con.Close();
                                    edit.Enabled = true;
                                    del.Enabled = true;
                                    datagrid2("SELECT * FROM detailrend WHERE reclend_ID IS NULL");
                                    update();
                                    num += Int32.Parse(qty.Text);
                                    sum.Text = "" + num;
                                    clear_text();



                                }
                            }
                            else
                            {
                                MessageBox.Show("สินค้าไม่พอหรือหมด");
                            }
                        }
                        catch (Exception)
                        {

                        }







                }
                }
                catch (Exception)
                {
                    MessageBox.Show("ป้อนข้อมูลผิด");
                }
                }
            else
            {
                MessageBox.Show("กรุณากรอบข้อมูลให้ครบ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

       
        void combobox()
        {
            idbranch.Items.Clear();
            cmd = new MySqlCommand("SELECT DISTINCT Destination_Branch FROM reclend NATURAL JOIN branch", con);
            con.Open();
            read = cmd.ExecuteReader();
            while (read.Read())
            {
                idbranch.Items.Add(read.GetString("Destination_Branch"));
            }
            con.Close();
        }
        void comboboxemp()
        {
            emprend.Items.Clear();
            cmd = new MySqlCommand("SELECT Employee_ID FROM employee", con);
            con.Open();
            read = cmd.ExecuteReader();
            while (read.Read())
            {
                emprend.Items.Add(read.GetString("Employee_ID"));
            }
            con.Close();
        }
        void combobox2()
        {
            idpro.Items.Clear();
            cmd = new MySqlCommand("SELECT * FROM Product", con);
            con.Open();
            read = cmd.ExecuteReader();
            while (read.Read())
            {
                idpro.Items.Add(read.GetString("Product_ID"));
            }
            con.Close();
        }
        void combobox3()
        {
            branch1.Items.Clear();
            branch2.Items.Clear();
            cmd = new MySqlCommand("SELECT Branch_ID FROM Branch", con);
            con.Open();
            read = cmd.ExecuteReader();
            while (read.Read())
            {
                branch1.Items.Add(read.GetString("Branch_ID"));
                branch2.Items.Add(read.GetString("Branch_ID"));
            }
            con.Close();
        }
       

        private void search_Click(object sender, EventArgs e)
        {

            if (idbranch.Text.Equals(""))
            {
                update();
                delete.Enabled = false;
            }
            else
            {
                detail.Enabled = true;
                datagrid("SELECT * FROM reclend WHERE Destination_Branch='" + idbranch.Text+"'ORDER BY Date_Lend ");
                cmd = new MySqlCommand("SELECT * FROM reclend WHERE Destination_Branch='" + idbranch.Text + "'ORDER BY Date_Lend ", con);
                con.Open();
                read = cmd.ExecuteReader();
                if (read.Read())
                {
                    delete.Enabled = true;
                    edit.Enabled = true;
                   

                }
                else
                {
                    MessageBox.Show("ไม่พบรหัสสินค้านี้", "ไม่พบ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    clear_text();
                }

            }
            con.Close();
        }

        private void delete_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Confrim", "DELETE", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                cmd = new MySqlCommand("DELETE FROM reclend WHERE reclend_ID = '" + idbranch.Text + "'", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                update();
                combobox();
                delete.Enabled = false;
                detail.Enabled = false;
            }

        }

        private void edit_Click(object sender, EventArgs e)
        {
            if (
              daterequase.Text != "" &&
            datewant.Text != "" &&
           sum.Text != "" &&
           branch1.Text != "" &&
            branch2.Text != "" &&
           empre.Text != "" &&
           emprend.Text != "")

            {
                if(!branch1.Text.Equals(branch2.Text)&& !branch2.Text.Equals("3"))
                    {
                    del.Enabled = false;
                    DialogResult dialog = MessageBox.Show("Confrim", "บันทึก", MessageBoxButtons.YesNo);
                    if (dialog == DialogResult.Yes)
                    {

                        try
                        {

                            datagrid2("SELECT * FROM detailrend WHERE reclend_ID IS NULL");
                            cmd = new MySqlCommand("INSERT INTO reclend VALUES('NULL','" + daterequase.Text + "','" + datewant.Text + "','" + num + "','" + branch1.Text + "','" + branch2.Text + "','" + empre.Text + "','" + emprend.Text + "');UPDATE detailrend SET reclend_ID =(SELECT MAX(reclend_ID) FROM reclend),Destination_Branch=" + branch2.Text + " WHERE reclend_ID IS NULL;INSERT INTO copy (Qty,Product_ID) SELECT Qty,Product_ID FROM detailrend WHERE recLend_ID= (SELECT MAX(recLend_ID) FROM recLend )", con);
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();

                            edit.Enabled = false;
                            add.Enabled = true;
                            del.Enabled = false;
                            clear_text2();
                            num = 0;
                            combobox();
                            datagrid2("SELECT * FROM detailrend WHERE reclend_ID IS NULL");
                            MessageBox.Show("เรียบร้อย");

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

                                        cmd = new MySqlCommand("UPDATE Product SET Qty=Qty-(SELECT Qty FROM Copy WHERE ID=(SELECT MIN(ID) FROM Copy)) WHERE Product_ID=(SELECT Product_ID FROM Copy WHERE ID=(SELECT MIN(ID) FROM Copy));DELETE FROM Copy WHERE ID='" + r2 + "';", con);
                                        con.Open();
                                        cmd.ExecuteReader();
                                        con.Close();
                                    }
                                }
                            }


                        }
                        catch (Exception)
                        {
                            MessageBox.Show("เกิดข้อผิดพลาด");
                        }
                    }




                }
                else
                {
                    MessageBox.Show("สาขาเหมือนกันหรือป้อนสาขาปัจจุบัน กรุณาป้อนใหม่");
                }
            }
            
            else
            {
                MessageBox.Show("กรุณากรอกข้อมูลให้ครบ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void บันทึกการยืมสินค้า_Load(object sender, EventArgs e)
        {
            combobox3();
            comboboxemp();
            combobox();
            combobox2();
            update();
            delete.Enabled = false;
            edit.Enabled = false;
            del.Enabled = false;
            add.Enabled = true;
            detail.Enabled = false;
        }

        private void del_Click(object sender, EventArgs e)
        {
            if (
            idpro.Text != "")

            {

                
                cmd = new MySqlCommand("DELETE FROM detailrend WHERE reclend_ID IS NULL AND Product_ID ='" + idpro.Text+"'", con);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                datagrid2("SELECT * FROM detailrend WHERE reclend_ID IS NULL");
                update();
                clear_text();    
                
            }
            else
            {
                MessageBox.Show("กรุณากรอกรหัสสินค้า", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            con.Close();
            clear_text2();
            edit.Enabled = false;
            cmd = new MySqlCommand("DELETE FROM detailrend WHERE reclend_ID IS NULL ", con);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            datagrid2("SELECT * FROM detailrend WHERE reclend_ID IS NULL");
            update();
            

        }

        private void บันทึกการยืมสินค้า_FormClosing(object sender, FormClosingEventArgs e)
        {
            con.Close();
            clear_text2();
            edit.Enabled = false;
            cmd = new MySqlCommand("DELETE FROM detailrend WHERE reclend_ID IS NULL ", con);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            datagrid2("SELECT * FROM detailrend WHERE reclend_ID IS NULL");
            update();

        }

        private void detail4_Click(object sender, EventArgs e)
        {
            datagrid("SELECT  * FROM detailrend  WHERE Destination_Branch='" + idbranch.Text + "'");
        }

      
    }
}
