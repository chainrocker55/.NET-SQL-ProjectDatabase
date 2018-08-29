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
    public partial class จัดการสินค้า : Form
    {
        public จัดการสินค้า()
        {
            InitializeComponent();
        }
        MySqlConnection con = new MySqlConnection("host = localhost ; user=59160089;password=59160089;database=s59160089;CharSet=UTF8");
        MySqlCommand cmd;

        MySqlDataAdapter da;
        MySqlDataReader read;

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
        public void up()
        {
            comboboxtype();
            comboboxtypeproduct();
        }
        void update()
        {
            
            con.Close();
            con.Open();
            if (idtype.Text.Equals("ทั้งหมด")|| idtype.Text.Equals("")) {
                cmd = new MySqlCommand("SELECT * FROM product ", con);
            } else{
                cmd = new MySqlCommand("SELECT * FROM product WHERE TypeProduct='" + idtype.Text + "'", con);
            }
            da = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        void clear_text()
        {
            id.ResetText();
            name_text.Clear();
            price_ปลีก.Clear();
            price_ส่ง.Clear();
            qty_text.Clear();
            id_text.Clear();
            type.ResetText();
            idtype.ResetText();
            textBox1.Clear();
        }

        void combobox()
        {
            id.Items.Clear();
            cmd = new MySqlCommand("SELECT * FROM product", con);
            con.Open();
            read = cmd.ExecuteReader();
            while (read.Read())
            {
                id.Items.Add(read.GetString("Product_ID"));
            }
            con.Close();
        }

        void comboboxtypeproduct()
        {
            
            idtype.Items.Clear();
          
            cmd = new MySqlCommand("SELECT * FROM typeproduct", con);
            con.Open();
            read = cmd.ExecuteReader();
            while (read.Read())
            {
                idtype.Items.Add(read.GetString("name"));
               
            }
            con.Close();
        }

        void comboboxtype()
        {

           
            type.Items.Clear();
            cmd = new MySqlCommand("SELECT name FROM typeproduct WHERE name != 'ทั้งหมด'", con);
            con.Open();
            read = cmd.ExecuteReader();
            while (read.Read())
            {
               
                type.Items.Add(read.GetString("name"));
            }
            con.Close();
        }
        private void จัดการสินค้า_Load(object sender, EventArgs e)
        {
            combobox();
            update();
            delete.Enabled = false;
            edit.Enabled = false;
            comboboxtypeproduct();
            comboboxtype();

        }

        private void search_Click(object sender, EventArgs e)
        {
            
            if (id.Text.Equals(""))
            {
                update();
                clear_text();
                add.Enabled = true;
                edit.Enabled = false;
                delete.Enabled = false;
            }
            else
            {
           
                datagrid("SELECT * FROM product WHERE Product_ID ='" + id.Text + "' ");
                cmd = new MySqlCommand("SELECT * FROM product WHERE Product_ID ='" + id.Text + "' ", con);
                con.Open();
                read = cmd.ExecuteReader();
                if (read.Read())
                {
                    delete.Enabled = true;
                    edit.Enabled = true;
                    add.Enabled = false;
                    id_text.Text = read.GetString("Product_ID");
                    name_text.Text = read.GetString("nameProduct");
                    qty_text.Text = read.GetString("Qty");
                   
                    price_ปลีก.Text = read.GetString("RetailPrice");
                    price_ส่ง.Text = read.GetString("wholesaleCost");
                    type.Text = read.GetString("TypeProduct");
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
            
            DialogResult dialog = MessageBox.Show("Confrim","DELETE",MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes) {
                cmd = new MySqlCommand("DELETE FROM product WHERE Product_ID = '" + id_text.Text + "'", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                update();
                clear_text();
                add.Enabled = true;
                delete.Enabled = false;
                edit.Enabled = false;
                combobox();
            }
           

           
        }

      
        private void add_Click(object sender, EventArgs e)
        {
      
            if (
            name_text.Text != "" && 
            qty_text.Text !="" &&
            type.Text != "" &&
            price_ปลีก.Text != ""&&
            price_ส่ง.Text != "")
            {
                try
                {
                    cmd = new MySqlCommand("INSERT INTO product (Product_ID,nameProduct,TypeProduct,Qty,wholesaleCost,RetailPrice) VALUES ('" + id_text.Text + "','" + name_text.Text + "','" + type.Text + "','" + qty_text.Text + "','" + price_ส่ง.Text + "','" + price_ปลีก.Text + "')", con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    update();
                    clear_text();
                    combobox();
                }
                catch (Exception)
                {
                    MessageBox.Show("ID ซ้ำกันหรือ ป้อนข้อมูลผิด");
                }
            }
            else
            {
                MessageBox.Show("กรุณากรอบข้อมูลให้ครบ","Warning" ,MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
       
        }

        private void edit_Click(object sender, EventArgs e)
        {
         
            if (
                id_text.Text!=""&&
            name_text.Text != "" &&
            qty_text.Text != "" &&
            type.Text != "" &&
            price_ปลีก.Text != "" &&
            price_ส่ง.Text != "")
            {
                try
                {
                    DialogResult dialog = MessageBox.Show("Confrim", "UPDATE", MessageBoxButtons.YesNo);
                    if (dialog == DialogResult.Yes)
                    {
                        cmd = new MySqlCommand("UPDATE product SET Product_ID='" + id_text.Text + "',nameProduct= '" + name_text.Text + "',TypeProduct=  '" + type.Text + "',Qty='" + qty_text.Text + "',wholesaleCost=  '" + price_ส่ง.Text + "',RetailPrice= '" + price_ปลีก.Text + "' WHERE Product_ID = '" + id_text.Text + "' ", con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        update();
                        clear_text();
                        edit.Enabled = false;
                        add.Enabled = true;
                        delete.Enabled = false;
                        combobox();
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Equals(""))
            {
                
                clear_text();
                add.Enabled = true;
                edit.Enabled = false;
                delete.Enabled = false;
            }
            else
            {

                datagrid("SELECT * FROM product WHERE nameProduct ='" + textBox1.Text + "' ");
                cmd = new MySqlCommand("SELECT * FROM product WHERE nameProduct ='" + textBox1.Text + "' ", con);
                con.Open();
                read = cmd.ExecuteReader();
                if (read.Read())
                {
                    delete.Enabled = true;
                    edit.Enabled = true;
                    add.Enabled = false;
                    try
                    {
                        id_text.Text = read.GetString("Product_ID");
                        name_text.Text = read.GetString("nameProduct");
                        qty_text.Text = read.GetString("Qty");

                        price_ปลีก.Text = read.GetString("RetailPrice");
                        price_ส่ง.Text = read.GetString("wholesaleCost");
                        type.Text = read.GetString("TypeProduct");
                    }
                    catch (Exception)
                    {

                    }
                }
                else
                {
                    MessageBox.Show("ไม่พบสินค้านี้", "ไม่พบ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    clear_text();
                }

            }
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (idtype.Text.Equals(""))
            {
                update();
                clear_text();
                add.Enabled = true;
                edit.Enabled = false;
                delete.Enabled = false;
            }
            else
            {

                datagrid("SELECT * FROM product WHERE TypeProduct ='" + idtype.Text + "' ");
                cmd = new MySqlCommand("SELECT * FROM product WHERE TypeProduct ='" + idtype.Text + "' ", con);
                con.Open();
                read = cmd.ExecuteReader();
                if (read.Read())
                {
                    delete.Enabled = false;
                    edit.Enabled = false;
                    add.Enabled = true;
                    clear_text();

                }
                else
                {
                    update();
                    clear_text();
                }

            }
            con.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            จัดการประเภท a = new จัดการประเภท();
            a.ShowDialog();
            this.Enabled = true;
            up();

        }

        private void จัดการสินค้า_Layout(object sender, LayoutEventArgs e)
        {
            up();
        }
    }
}
