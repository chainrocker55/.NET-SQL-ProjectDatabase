using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace DB_NTCF_C
{
    public partial class home : Form
    {
        string level;
        public static string empids;
        
        public home(String user)
        {
            InitializeComponent();
            cmd = new MySqlCommand("SELECT * FROM login  WHERE username = '" + user + "' ", con);
            con.Open();
            read = cmd.ExecuteReader();
            while (read.Read())
            {
                 level = read.GetString("level");
            
               
            }
            con.Close();

            cmd = new MySqlCommand("SELECT * FROM login NATURAL JOIN employee WHERE username = '"+ user +"'",con);
            con.Open();
            read = cmd.ExecuteReader();
            id.ResetText();
            while (read.Read())
            {
                empids = read.GetString("Employee_ID");
            }
            con.Close();
            empids_lable.Text = level +" : "+ empids;

         
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

        void update()
        {
            con.Close();
            con.Open();

            cmd = new MySqlCommand("SELECT * FROM product", con);
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
            type_text.Clear();
        }


        private void ขายสนคาToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            ขายสินค้า sell = new ขายสินค้า();
            sell.ShowDialog();
            this.Show();
           

        }


        private void ออกจากระบบToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            if (id.Text.Equals(""))
            {
                update();
                clear_text();
            }
            else
            {
                datagrid("SELECT * FROM product WHERE   Product_ID ='" + id.Text+"'");
                cmd = new MySqlCommand("SELECT * FROM product WHERE Product_ID ='" + id.Text + "' ", con);
                con.Open();
                read = cmd.ExecuteReader();
                if (read.Read())
                {
                    clear_text();
                    id_text.Text = read.GetString("Product_ID");
                    name_text.Text = read.GetString("nameProduct");
                    qty_text.Text = read.GetString("Qty");
                    type_text.Text = read.GetString("TypeProduct");
                    price_ปลีก.Text = read.GetString("RetailPrice");
                    price_ส่ง.Text = read.GetString("wholesaleCost");
                }
                else
                {
                    MessageBox.Show("ไม่พบรหัสสินค้านี้", "ไม่พบ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    update();
                    clear_text();
                }

            }
            con.Close();
           
        }

        private void จดการขอมลพนกงานToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            emp emp = new emp();
            emp.ShowDialog();
            this.Show();
          
        }

        private void ระบบรถขนสงToolStripMenuItem_Click(object sender, EventArgs e)
        {
            การส่งซ่อม car = new การส่งซ่อม();
            this.Hide();
            car.ShowDialog();
            this.Show();
           
        }

        private void รบสนคาToolStripMenuItem_Click(object sender, EventArgs e)
        {
            รับสินค้า รับ = new รับสินค้า();
            this.Hide();
            รับ.ShowDialog();
            this.Show();
            
        }

        private void สงซอสนคาเขาToolStripMenuItem_Click(object sender, EventArgs e)
        {
            การสั่งซื้อจาก_Vendor buy_vendor = new การสั่งซื้อจาก_Vendor();
            this.Hide();
            buy_vendor.ShowDialog();
            this.Show();
            
        }

        private void รบออเดอรToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            order order = new order();
            order.ShowDialog();
            this.Show();
            
        }

        private void vendorToolStripMenuItem_Click(object sender, EventArgs e)
        {

            จัดการ_Vendor vendor = new จัดการ_Vendor();
            this.Hide();
            vendor.ShowDialog();
            this.Show();
            
        }

        private void ระบบเบกสนคาToolStripMenuItem_Click(object sender, EventArgs e)
        {
            บันทึกการยืมสินค้า เบิก = new บันทึกการยืมสินค้า();
            this.Hide();
            เบิก.ShowDialog();
            this.Show();
          
        }

      

        private void สาขาToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            การจัดการสาขา branch = new การจัดการสาขา();
            this.Hide();
            branch.ShowDialog();
            this.Show();
           
        }

        private void จดการออเดอรToolStripMenuItem_Click(object sender, EventArgs e)
        {
            order order = new order();
            this.Hide();
            order.ShowDialog();
            this.Show();
        }

        private void customerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Customer cus = new Customer();
            this.Hide();
            cus.ShowDialog();
            this.Show();
           
        }
        
        private void home_Load(object sender, EventArgs e)
        {
            cmd = new MySqlCommand("SELECT * FROM product", con);
            con.Open();
            read = cmd.ExecuteReader();
            id.Items.Clear();
            while (read.Read())
            {
                id.Items.Add(read.GetString("Product_ID"));
            }
            
            update();
            if (!level.Equals("admin"))
            {
                จดการขอมลพนกงานToolStripMenuItem.Enabled = false;
                จดการขอมลลกคาToolStripMenuItem.Enabled = false;
                สรปยอดขายToolStripMenuItem.Enabled = false;
                สาขาToolStripMenuItem.Enabled = false;
            }
            else
            {
                สาขาToolStripMenuItem.Enabled = true;
                จดการขอมลพนกงานToolStripMenuItem.Enabled = true;
                จดการขอมลลกคาToolStripMenuItem.Enabled = true;
                สรปยอดขายToolStripMenuItem.Enabled = true;
            }
        }

        private void จดการสนคาToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            จัดการสินค้า pro_manage = new จัดการสินค้า();
            pro_manage.ShowDialog();
           
            id.ResetText();
            this.Show();
            

        }

        private void home_Leave(object sender, EventArgs e)
        {
            empids = "";

        }

        private void แผนกตำแหนงToolStripMenuItem_Click(object sender, EventArgs e)
        {
            การจัดการแผนก dep = new การจัดการแผนก();

            this.Hide();
            dep.ShowDialog();
            this.Show();
            
        }

        private void สรปยอดขายToolStripMenuItem_Click(object sender, EventArgs e)
        {
            การสรุปยอดขาย b = new การสรุปยอดขาย();
            this.Hide();
            b.ShowDialog();
            this.Show();
        
        }

        private void การเคลมลกคาToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            บันทึกการเคลมลูกค้า บันทึกการเครม = new บันทึกการเคลมลูกค้า();
            บันทึกการเครม.ShowDialog();
            this.Show();
            
        }

        private void การเคลมVendorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            บันทึกการเคลม บันทึกการเครม = new บันทึกการเคลม();
            บันทึกการเครม.ShowDialog();
            this.Show();
           
        }



        
        private void home_Layout(object sender, LayoutEventArgs e)
        {
            con.Close();
            cmd = new MySqlCommand("SELECT * FROM product", con);
            con.Open();
            read = cmd.ExecuteReader();
            
           
                id.Items.Clear();
                while (read.Read())
            {
                id.Items.Add(read.GetString("Product_ID"));
            } 
        
            update();
            con.Close();
           
        }
    }
}
