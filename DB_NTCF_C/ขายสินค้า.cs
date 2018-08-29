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
    public partial class ขายสินค้า : Form
    {
        public ขายสินค้า()
        {
            InitializeComponent();
        }
        MySqlConnection con = new MySqlConnection("host = localhost ; user=59160089;password=59160089;database=s59160089;CharSet=UTF8");
        MySqlCommand cmd;

        MySqlDataAdapter da;
        MySqlDataReader read;
        double sumprice = 0, sumqty = 0,c=0;

        private void ขายสินค้า_Load(object sender, EventArgs e)
        {
            update();
            update2();
            pay.Enabled = false;
        
            accept.Enabled = false;
            sum1.Text = "" + sumqty;
            sum2.Text = "" + sumprice;

        }
       
        void update()
        {
            con.Close();
            con.Open();
            //
            cmd = new MySqlCommand("SELECT * FROM Product", con);
            da = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
           
            con.Close();
        }


        void update2()
        {
            con.Close();
            con.Open();
            cmd = new MySqlCommand("SELECT * FROM recDetailRetailer WHERE recRetailer_ID IS NULL", con);
            da = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }
        
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

                        cmd = new MySqlCommand("UPDATE Product SET Qty=Qty-(SELECT Qty FROM Copy WHERE ID=(SELECT MIN(ID) FROM Copy)) WHERE Product_ID=(SELECT Product_ID FROM Copy WHERE ID=(SELECT MIN(ID) FROM Copy));DELETE FROM Copy WHERE ID='" + r2 + "';", con);
                        con.Open();
                        cmd.ExecuteReader();
                        con.Close();
                    }
                }
            }
        }
        void clear_text()
        {           
            re.Clear();
            
        }

        private void pay_Click(object sender, EventArgs e)
        {
            if (re.Text != "")
            {
               



                c = Int32.Parse(re.Text) - sumprice;
                if (c < 0)
                {
                    MessageBox.Show("จ่ายไม่ครบ ขาด " + (sumprice - Int32.Parse(re.Text)) + " บาท");
                }
                else
                {
                  
                    cmd = new MySqlCommand("INSERT INTO recRetailer VALUES(NULL,'" + datepay.Text + "','" + home.empids + "','" + sumprice + "','" + sumqty + "');INSERT INTO copy (Qty,Product_ID) SELECT Qty,Product_ID FROM recdetailretailer WHERE recRetailer_ID IS NULL ;UPDATE recDetailRetailer SET recRetailer_ID=(SELECT MAX(recRetailer_ID) FROM recRetailer) WHERE recRetailer_ID IS NULL", con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();

                    se.Text = "" + c;

                    sumprice = 0;
                    sumqty = 0;
                    sum1.Text = "0";
                    sum2.Text = "0";
                    clear_text();
                    update2();
                    set();
                   

                }
            }
            else
            {
                MessageBox.Show("กรุณาป้อนเงินเข้า");
            }
        }
   
        private void search_Click(object sender, EventArgs e)
        {
            if (id.Text.Equals(""))
            {
                update();
         
            }
            else
            {
                num.Text = "";
                con.Close();
              
                cmd = new MySqlCommand("SELECT * FROM Product WHERE Product_ID ='" + id.Text + "' ", con);
                con.Open();
                read = cmd.ExecuteReader();
                if (read.Read())
                {                  
                    accept.Enabled = true;
                    name.Text = read.GetString("nameProduct");
                    price.Text = read.GetString("RetailPrice");
                    
                }
                else
                {
                    MessageBox.Show("ไม่พบรหัสนี้", "ไม่พบ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    clear_text();
                }

            }
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cancelbill a = new cancelbill();
            this.Enabled = false;
            a.ShowDialog();
            this.Enabled = true;
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            รายการขาย a = new รายการขาย();
            this.Hide();
            a.ShowDialog();
            this.Show();
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            clear_text();
            cmd = new MySqlCommand("DELETE FROM recDetailRetailer WHERE recRetailer_ID IS NULL", con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            update2();
            pay.Enabled = false;
          
            sumprice = 0;
            sumqty = 0;
            sum1.Text = "0";
            sum2.Text = "0";
        }

        private void accept_Click(object sender, EventArgs e)
        {
            se.Text = "0";

            con.Close();
            cmd = new MySqlCommand("SELECT Qty FROM Product WHERE Product_ID ="+id.Text, con);
            con.Open();
            read = cmd.ExecuteReader();
            if (read.Read())
            {
                try
                {
                    int num2 = read.GetInt32("Qty");
                    int num3 = Int32.Parse(num.Text);
                    int num4 = num2 - num3;

                    con.Close();
                    cmd = new MySqlCommand("SELECT Qty FROM recdetailretailer WHERE Product_ID =" + id.Text, con);
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
                        cmd = new MySqlCommand("SELECT Product_ID FROM recdetailretailer WHERE recRetailer_ID IS NULL AND Product_ID =" + id.Text, con);

                        con.Open();
                        read = cmd.ExecuteReader();
                        if (read.Read())
                        {
                            con.Close();
                            cmd = new MySqlCommand("UPDATE recdetailretailer SET Qty=Qty+" + num.Text + "  WHERE recRetailer_ID IS NULL AND Product_ID= " + id.Text, con);
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();
                            sumprice = sumprice + ((Int32.Parse(num.Text)) * (Int32.Parse(price.Text)));
                            sumqty = sumqty + (Int32.Parse(num.Text));
                            sum1.Text = "" + sumqty;
                            sum2.Text = "" + sumprice;
                            update2();
                        }
                        else
                        {
                            con.Close();
                            cmd = new MySqlCommand("INSERT INTO `recdetailretailer` (`recDetailRetailer_ID`, `Qty`, `price`, `recRetailer_ID`, `Product_ID`) VALUES(NULL, '" + num.Text + "', '" + price.Text + "', NULL, '" + id.Text + "');", con);
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();
                            update2();
                            pay.Enabled = true;

                            sumprice = sumprice + ((Int32.Parse(num.Text)) * (Int32.Parse(price.Text)));
                            sumqty = sumqty + (Int32.Parse(num.Text));
                            sum1.Text = "" + sumqty;
                            sum2.Text = "" + sumprice;
                        }
                    }
                    else
                    {
                        MessageBox.Show("สินค้าไม่พอหรือหมด");
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("กรอกข้อมูลผิด");
                }
                }
                
            else
            {
                MessageBox.Show("ไม่พบสินค้า");
            }
            con.Close();






           
        }
    }
    
}
