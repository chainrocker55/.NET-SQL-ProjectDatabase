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
    public partial class สรุปยอดรวม : Form
    {
        public สรุปยอดรวม()
        {
            InitializeComponent();
        }
        MySqlConnection con = new MySqlConnection("host = localhost ; user=59160089;password=59160089;database=s59160089;CharSet=UTF8");
        MySqlCommand cmd;

        MySqlDataAdapter da;
        MySqlDataReader read;

        private void retail_Click(object sender, EventArgs e)
        {
            con.Close();
            con.Open();

            cmd = new MySqlCommand("SELECT recdetailretailer.Product_ID AS ID,product.nameProduct AS ชื่อสินค้า,SUM(recdetailretailer.Qty) AS จำนวน FROM recdetailretailer INNER JOIN Product ON (recdetailretailer.Product_ID=product.Product_ID)  INNER JOIN recretailer ON (recretailer.recRetailer_ID=recdetailretailer.recRetailer_ID) WHERE dateofpay >= '"+date1.Text+"' AND dateofpay <= '"+date2.Text+"' GROUP BY recdetailretailer.Product_ID", con);
            da = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();


            con.Close();
            con.Open();

            cmd = new MySqlCommand("SELECT orderdetails.Product_ID AS ID,product.nameProduct AS ชื่อสินค้า,SUM(orderdetails.Qty) AS จำนวน FROM orderdetails INNER JOIN Product ON (orderdetails.Product_ID=product.Product_ID)  INNER JOIN orders ON (orders.Order_ID=orderdetails.Order_ID) WHERE Date_Order >= '" + date1.Text + "' AND Date_Order <= '" + date2.Text + "' GROUP BY orderdetails.Product_ID", con);
            da = new MySqlDataAdapter(cmd);
            DataTable dt2 = new DataTable();
            da.Fill(dt2);
            dataGridView2.DataSource = dt2;
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                try
                {
                    con.Close();
                    con.Open();

                    cmd = new MySqlCommand("SELECT recdetailretailer.Product_ID AS ID,product.nameProduct AS ชื่อสินค้า,SUM(recdetailretailer.Qty) AS จำนวน FROM recdetailretailer INNER JOIN Product ON (recdetailretailer.Product_ID=product.Product_ID)  INNER JOIN recretailer ON (recretailer.recRetailer_ID=recdetailretailer.recRetailer_ID) WHERE dateofpay >= '" + date1.Text + "' AND dateofpay <= '" + date2.Text + "' AND  recdetailretailer.Product_ID = "+textBox1.Text+" GROUP BY recdetailretailer.Product_ID", con);
                    da = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                    con.Close();


                    con.Close();
                    con.Open();

                    cmd = new MySqlCommand("SELECT orderdetails.Product_ID AS ID,product.nameProduct AS ชื่อสินค้า,SUM(orderdetails.Qty) AS จำนวน FROM orderdetails INNER JOIN Product ON (orderdetails.Product_ID=product.Product_ID)  INNER JOIN orders ON (orders.Order_ID=orderdetails.Order_ID) WHERE Date_Order >= '" + date1.Text + "' AND Date_Order <= '" + date2.Text + "' AND orderdetails.Product_ID = "+textBox1.Text+"  GROUP BY orderdetails.Product_ID", con);
                    da = new MySqlDataAdapter(cmd);
                    DataTable dt2 = new DataTable();
                    da.Fill(dt2);
                    dataGridView2.DataSource = dt2;
                    con.Close();
                }
                catch (Exception)
                {
                    MessageBox.Show("ไม่พบสินค้า");
                }
            }
        }
    }

   
    
}
