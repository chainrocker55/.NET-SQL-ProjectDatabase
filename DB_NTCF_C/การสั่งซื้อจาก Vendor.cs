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
    public partial class การสั่งซื้อจาก_Vendor : Form
    {
        public การสั่งซื้อจาก_Vendor()
        {
            InitializeComponent();
        }
        MySqlConnection con = new MySqlConnection("host = localhost ; user=59160089;password=59160089;database=s59160089;CharSet=UTF8");
        MySqlCommand cmd;

        MySqlDataAdapter da;
        MySqlDataReader read;
        int num = 0, sum = 0;
        private void การสั่งซื้อจาก_Vendor_Load(object sender, EventArgs e)
        {
            combobox();
            comboboxpro();
            comboboxvendor();
            update();
            delete.Enabled = false;
            del.Enabled = false;
            del2.Enabled = false;
            add.Enabled = true;
            save.Enabled = false;
            edit.Enabled = false;
            update2();
            update3();
            comboboxtype();
            comboboxbill();
            detail.Enabled = false;


        }
        void datagrid(String sql)
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
        void datagrid2(String sql)
        {
            con.Close();
            con.Open();

            cmd = new MySqlCommand(sql, con);
            da = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView3.DataSource = dt;
            con.Close();
        }

        void update()
        {
            con.Close();
            con.Open();

            cmd = new MySqlCommand("SELECT * FROM recDetailOrderVendor WHERE recOrderVendor_ID IS NULL", con);
            da = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }
        
        void update2()
        {
            con.Close();
            con.Open();

            cmd = new MySqlCommand("SELECT * FROM recOrderVendor", con);
            da = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            
            da.Fill(dt);
            dataGridView2.DataSource = dt;
            con.Close();
        }
        void update3()
        {
            con.Close();
            con.Open();

            cmd = new MySqlCommand("SELECT * FROM BillOrder", con);
            da = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView3.DataSource = dt;
            con.Close();
        }

        void clear_text()
        {
            idpro.ResetText();
            //vendor.ResetText();
            qtyPro.Clear();
            price.Clear();
            /* sumprice.Clear();
             sumqty.Clear();*/

        }

        void comboboxpro()
        {
            idpro.Items.Clear();
            cmd = new MySqlCommand("SELECT * FROM product", con);
            con.Open();
            read = cmd.ExecuteReader();
            while (read.Read())
            {
                idpro.Items.Add(read.GetString("Product_ID"));
            }
            con.Close();
        }
        void comboboxvendor()
        {
            vendor.Items.Clear();
            cmd = new MySqlCommand("SELECT * FROM Vendor", con);
            con.Open();
            read = cmd.ExecuteReader();
            while (read.Read())
            {
                vendor.Items.Add(read.GetString("Vendor_ID"));
            }
            con.Close();
        }
        void combobox()
        {
            id.Items.Clear();
            id2.Items.Clear();
            cmd = new MySqlCommand("SELECT * FROM recOrderVendor", con);
            con.Open();
            read = cmd.ExecuteReader();
            while (read.Read())
            {
                id.Items.Add(read.GetString("recOrderVendor_ID"));
                id2.Items.Add(read.GetString("recOrderVendor_ID"));
            }
            con.Close();
        }
        void comboboxbill()
        {
           
            idbill.Items.Clear();
            cmd = new MySqlCommand("SELECT * FROM BillOrder", con);
            con.Open();
            read = cmd.ExecuteReader();
            while (read.Read())
            {
                idbill.Items.Add(read.GetString("BillOrder_ID"));

            }
            con.Close();
        }
        void comboboxtype()
        {
            type.Items.Clear();
            cmd = new MySqlCommand("SELECT * FROM TypePay", con);
            con.Open();
            read = cmd.ExecuteReader();
            while (read.Read())
            {
                type.Items.Add(read.GetString("NameType"));
            }
            con.Close();
        }

        private void add_Click(object sender, EventArgs e)
        {
            if (
           idpro.Text != "" &&
           qtyPro.Text != "")

            {
                try
                {
                    con.Close();
                    cmd = new MySqlCommand("SELECT Product_ID FROM recdetailordervendor WHERE recOrderVendor_ID IS NULL AND Product_ID =" + idpro.Text, con);

                    con.Open();
                    read = cmd.ExecuteReader();
                    if (read.Read())
                    {
                        /*String a = read.GetString("Product_ID");
                        if (a.Equals(idpro.Text))
                        {*/
                        con.Close();
                        cmd = new MySqlCommand("UPDATE recdetailordervendor SET Qty=Qty+" + qtyPro.Text + "  WHERE recOrderVendor_ID IS NULL AND Product_ID= " + idpro.Text, con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        num += Int32.Parse(qtyPro.Text);
                        sum += (Int32.Parse(price.Text) * Int32.Parse(qtyPro.Text));
                        clear_text();
                        sumprice.Text = "" + sum;
                        sumqty.Text = "" + num;
                        update();
                    }
                    else
                    {
                        con.Close();





                        delete.Enabled = true;
                        save.Enabled = true;
                        cmd = new MySqlCommand("INSERT INTO recDetailOrderVendor  VALUES('NULL','" + qtyPro.Text + "','" + price.Text + "',NULL,'" + idpro.Text + "')", con);//UPDATE reclend SET Sum_Qty =Sum_Qty+"+qty.Text+ " WHERE reclend_ID IS NULL"

                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();

                        update();

                        num += Int32.Parse(qtyPro.Text);
                        sum += (Int32.Parse(price.Text) * Int32.Parse(qtyPro.Text));
                        clear_text();
                        sumprice.Text = "" + sum;
                        sumqty.Text = "" + num;


                        // }
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

        private void delete_Click(object sender, EventArgs e)
        {
            if (
            idpro.Text != "")

            {

                save.Enabled = true;
                cmd = new MySqlCommand("DELETE FROM recDetailOrderVendor WHERE recOrderVendor_ID IS NULL AND Product_ID ='" + idpro.Text + "'", con);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                datagrid("SELECT * FROM recDetailOrderVendor WHERE recOrderVendor_ID IS NULL");
                update();

            }
            else
            {
                MessageBox.Show("กรุณากรอกรหัสสินค้า", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void save_Click(object sender, EventArgs e)
        {
            if (
             dateorder.Text != "" &&
           datere.Text != "" &&
          vendor.Text != "" &&
          sumqty.Text != "" &&
           sumprice.Text != ""
     )

            {
                try {
                    delete.Enabled = false;
                    DialogResult dialog = MessageBox.Show("Confrim", "บันทึก", MessageBoxButtons.YesNo);
                    if (dialog == DialogResult.Yes)
                    {
                        cmd = new MySqlCommand("INSERT INTO recOrderVendor VALUES('NULL','" + dateorder.Text + "','" + sumqty.Text + "','" + sumprice.Text + "','" + datere.Text + "','" + vendor.Text + "','" + home.empids + "');UPDATE recDetailOrderVendor SET recOrderVendor_ID=(SELECT MAX(recOrderVendor_ID) FROM recOrderVendor) WHERE recOrderVendor_ID IS NULL;", con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        update();
                        update2();
                        save.Enabled = false;
                        add.Enabled = true;
                        del.Enabled = true;
                        combobox();
                        vendor.ResetText();
                        num = 0;
                        sum = 0;

                        sumprice.Clear();
                        sumqty.Clear();
                    }



                }
                catch (Exception)
                {
                    MessageBox.Show("ป้อนข้อมูลผิด");
                }
                }
            else
            {
                MessageBox.Show("กรุณากรอกข้อมูลให้ครบ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void searchbill_Click(object sender, EventArgs e)
        {
            if (idbill.Text.Equals(""))
            {
                update3();
                del2.Enabled = false;
            }
            else
            {
                con.Close();
                datagrid2("SELECT * FROM BillOrder WHERE BillOrder_ID ='" + idbill.Text + "'");
                cmd = new MySqlCommand("SELECT * FROM BillOrder WHERE BillOrder_ID ='" + idbill.Text + "'", con);
                con.Open();
                read = cmd.ExecuteReader();
                if (read.Read())
                {
                    del2.Enabled = true;
                    edit.Enabled = true;
                    datepay.Text = read.GetString("datePay");
                    status.Text = read.GetString("statut");
                    pricepay.Text = read.GetString("amount");
                                    
                    id2.Text = read.GetString("recOrderVendor_ID");
                    con.Close();
                }
                
                else
                {
                    MessageBox.Show("ไม่พบรหัสสินค้านี้", "ไม่พบ", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }

            }
            
        }
        void clear()
        {
            idbill.ResetText();
            pricepay.Clear();
            type.ResetText();
            id2.ResetText();
            status.ResetText();
          
            }
        private void edit_Click(object sender, EventArgs e)
        {
            con.Close();
            cmd = new MySqlCommand("UPDATE BillOrder SET BillOrder_ID='"+idbill.Text+ "',datePay='"+datepay.Text+ "',statut='"+status.Text+ "',amount="+pricepay.Text+ ",TypePay_ID=(SELECT TypePay_ID FROM typepay WHERE NameType ='" + type.Text+ "'),recOrderVendor_ID="+id2.Text+" WHERE BillOrder_ID =" + idbill.Text, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            datagrid("SELECT * FROM BillOrder WHERE BillOrder_ID ='" + idbill.Text + "'");
            clear();
            comboboxbill();
            update3();
        }

        private void savebill_Click(object sender, EventArgs e)
        {
            if (
             datepay.Text != "" &&
           status.Text != "" &&
          pricepay.Text != "" &&

          id2.Text != "" &&
           type.Text != ""
     )

            {
                try {
                    edit.Enabled = false;
                    DialogResult dialog = MessageBox.Show("Confrim", "บันทึก", MessageBoxButtons.YesNo);
                    if (dialog == DialogResult.Yes)
                    {
                        int t = 2;
                        if (type.Text.Equals("transfer"))
                        {
                            t = 1;
                        }
                        con.Close();
                        cmd = new MySqlCommand("INSERT INTO BillOrder VALUES(NULL,'" + datepay.Text + "','" + status.Text + "','" + pricepay.Text + "','" + t + "','" + id2.Text + "');", con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        clear();
                        comboboxbill();
                        update3();
                    }



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

        private void cancel_Click(object sender, EventArgs e)
        {
            num = 0;
            sum = 0;
                
                save.Enabled = false;
                delete.Enabled = false;
                cmd = new MySqlCommand("DELETE FROM recDetailOrderVendor WHERE recOrderVendor_ID IS NULL ", con);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
           
                 update();




        }

        private void del_Click(object sender, EventArgs e)
        {
            if (
           id.Text != "")

            {

                
                cmd = new MySqlCommand("DELETE FROM recOrderVendor WHERE recOrderVendor_ID ='" + id.Text + "'", con);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                combobox();
                update2();
                del.Enabled = false;


            }
            
        }

        private void detail_Click(object sender, EventArgs e)
        {
            con.Close();
            con.Open();

            cmd = new MySqlCommand("SELECT * FROM recDetailOrderVendor WHERE recOrderVendor_ID ="+id.Text+"", con);
            da = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView2.DataSource = dt;
            con.Close();
        }

 

        private void การสั่งซื้อจาก_Vendor_FormClosing(object sender, FormClosingEventArgs e)
        {
            num = 0;
            sum = 0;

            save.Enabled = false;
            delete.Enabled = false;
            con.Close();
            cmd = new MySqlCommand("DELETE FROM recDetailOrderVendor WHERE recOrderVendor_ID IS NULL ", con);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            update();
        }

        private void search_Click_1(object sender, EventArgs e)
        {
            if (id.Text.Equals(""))
            {
                update2();
                delete.Enabled = false;
            }
            else
            {

                
                cmd = new MySqlCommand("SELECT * FROM recOrderVendor WHERE recOrderVendor_ID ='" + id.Text + "'", con);
                con.Open();
                read = cmd.ExecuteReader();
                if (read.Read())
                {
                    detail.Enabled = true;
                    del.Enabled = true;
                    datagrid("SELECT * FROM recOrderVendor WHERE recOrderVendor_ID ='" + id.Text + "'");

                }
                else
                {
                    MessageBox.Show("ไม่พบรหัสสินค้านี้", "ไม่พบ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    clear_text();
                }

            }
            con.Close();
        }
      
    }
}
