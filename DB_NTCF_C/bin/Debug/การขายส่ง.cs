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
    public partial class order : Form
    {
        public order()
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
            dataGridView2.DataSource = dt;
            con.Close();
        }
        void datagridorder(String sql)
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
        void datagridsend(String sql)
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
        void datagrid2(String sql)
        {
            con.Close();
            con.Open();

            cmd = new MySqlCommand(sql, con);
            da = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            order_detail.DataSource = dt;
            con.Close();
        }
        private void search_Click(object sender, EventArgs e)
        {
            if (id.Text.Equals(""))
            {
                update();                             
                delete.Enabled = false;
                detail2.Enabled = false;
            }
            else
            {

                datagrid("SELECT * FROM orders WHERE Order_ID ='" + id.Text + "' ");
                cmd = new MySqlCommand("SELECT * FROM orders WHERE Order_ID ='" + id.Text + "' ", con);
                con.Open();
                read = cmd.ExecuteReader();
                if (read.Read())
                {
                    delete.Enabled = true;
                    detail2.Enabled = true;
                }
                else
                {
                    MessageBox.Show("ไม่พบรหัสสินค้านี้", "ไม่พบ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            con.Close();
        }
        void update()
        {
            con.Close();
            con.Open();

            cmd = new MySqlCommand("SELECT * FROM orders WHERE Date_Order>='"+date3.Text+"' AND Date_Order <= '"+date4.Text+"'", con);
            da = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView2.DataSource = dt;
            con.Close();
        }

        void updateorder()
        {
            con.Close();
            con.Open();

            cmd = new MySqlCommand("SELECT * FROM recpaycus", con);
            da = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }
        void updatesend()
        {
            con.Close();
            con.Open();

            cmd = new MySqlCommand("SELECT * FROM recsender", con);
            da = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView3.DataSource = dt;
            con.Close();
        }
        void combobox()
        {
            id.Items.Clear();
            idorder2.Items.Clear();
            cmd = new MySqlCommand("SELECT * FROM orders", con);
            con.Open();
            read = cmd.ExecuteReader();
            while (read.Read())
            {
                id.Items.Add(read.GetString("Order_ID"));
                

            }
            con.Close();
            idorder2.Items.Clear();
            cmd = new MySqlCommand("SELECT * FROM orders WHERE status=0", con);
            con.Open();
            read = cmd.ExecuteReader();
            while (read.Read())
            {
                
                idorder2.Items.Add(read.GetString("Order_ID"));

            }
            con.Close();
        }
        void comboboxcar()
        {
            car.Items.Clear();
           
            cmd = new MySqlCommand("SELECT * FROM Car WHERE status =0", con);
            con.Open();
            read = cmd.ExecuteReader();
            while (read.Read())
            {
                car.Items.Add(read.GetString("Car_ID"));
               

            }
            con.Close();
        }

        void comboboxemp()
        {
            emp.Items.Clear();

            cmd = new MySqlCommand("SELECT * FROM employee WHERE Department_ID = 'driver'", con);
            con.Open();
            read = cmd.ExecuteReader();
            while (read.Read())
            {
                emp.Items.Add(read.GetString("Employee_ID"));


            }
            con.Close();
        }
        void combobox2()
        {
            idpro.Items.Clear();
            cmd = new MySqlCommand("SELECT * FROM Product WHERE Qty != 0", con);
            con.Open();
            read = cmd.ExecuteReader();
            while (read.Read())
            {
                idpro.Items.Add(read.GetString("nameProduct"));

            }
            con.Close();
        }
        void combobox3()
        {
            cus.Items.Clear();
            cus2.Items.Clear();
            cmd = new MySqlCommand("SELECT * FROM Customer", con);
            con.Open();
            read = cmd.ExecuteReader();
            while (read.Read())
            {
                cus.Items.Add(read.GetString("Cus_Fname"));
                cus2.Items.Add(read.GetString("Customer_ID"));

            }
            con.Close();
        }
        void comboboxorder()
        {
            idorder.Items.Clear();
            cmd = new MySqlCommand("SELECT * FROM recpaycus WHERE Status = 0", con);
            con.Open();
            read = cmd.ExecuteReader();
            while (read.Read())
            {
                idorder.Items.Add(read.GetString("Order_ID"));

            }
            con.Close();
        }
        void comboboxsend()
        {
            idsend.Items.Clear();
            cmd = new MySqlCommand("SELECT * FROM recsender ", con);
            con.Open();
            read = cmd.ExecuteReader();
            while (read.Read())
            {
                idsend.Items.Add(read.GetString("recSender_ID"));

            }
            con.Close();
        }
        void clear_text()
        {
            idpro.ResetText();
            qty.Clear();     

        }
        private void order_Load(object sender, EventArgs e)
        {
            deleteall2.Enabled = false;
            pay.Enabled = false;
            comboboxorder();
            comboboxsend();
            save.Enabled = false;
            sumprice.Text = "0";
            sumqty.Text = "0";
            updatesend();
            updateorder();
            update();
            delete.Enabled = false;
            deleteorder.Enabled = false;
            deletesend.Enabled = false;
            savesend.Enabled = true;
            comboboxcar();
            detail2.Enabled = false;
            detail.Enabled = false;
            deleteall.Enabled = false;

            add.Enabled = true;
            combobox2();
            combobox();
            combobox3();
            datagrid2("SELECT * FROM orderdetails WHERE Order_ID IS NULL");
            comboboxemp();
        }

        private void delete_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Confrim", "DELETE", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                cmd = new MySqlCommand("DELETE FROM orders WHERE Order_ID = '" + id.Text + "'", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                update();
                delete.Enabled = false;
                detail2.Enabled = false;
                combobox();
                comboboxorder();
            }
        }
        void sum()
        {
            try
            {
                con.Close();
                cmd = new MySqlCommand("SELECT SUM(Qty),SUM(Qty*price) FROM orderdetails WHERE Order_ID IS NULL", con);
                con.Open();
                read = cmd.ExecuteReader();
                while (read.Read())
                {
                    sumprice.Text = read.GetString("SUM(Qty*price)");
                    sumqty.Text = read.GetString("SUM(Qty)");
                }
                con.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Data is null");
                sumprice.Text = "0";
                sumqty.Text = "0";
            }
        }
        private void add_Click(object sender, EventArgs e)
        {
            con.Close();
            cmd = new MySqlCommand("SELECT Qty FROM Product WHERE Product_ID =(SELECT Product_ID FROM Product WHERE nameProduct='" + idpro.Text + "')", con);
            con.Open();
            read = cmd.ExecuteReader();
            if (read.Read())
            {
                int num2 = read.GetInt32("Qty");
                int num3 = Int32.Parse(qty.Text);
                int num4 = num2 - num3;
                if (num4 >= 0)
                {
                    if (
           idpro.Text != "" &&
           date1.Text != "" &&
           date2.Text != "" &&
           cus.Text != "" &&
           idpro.Text != "" &&
           qty.Text != "")

                    {
                        try {
                            con.Close();
                            cmd = new MySqlCommand("SELECT Product_ID FROM orderdetails WHERE Order_ID IS NULL AND Product_ID =(SELECT Product_ID FROM Product WHERE nameProduct='" + idpro.Text + "')", con);

                            con.Open();
                            read = cmd.ExecuteReader();
                            if (read.Read())
                            {
                                con.Close();
                                cmd = new MySqlCommand("UPDATE orderdetails SET Qty=Qty+" + qty.Text + "  WHERE orderdetails IS NULL AND Product_ID= (SELECT Product_ID FROM Product WHERE nameProduct='" + idpro.Text + "')", con);
                                con.Open();
                                cmd.ExecuteNonQuery();
                                con.Close();
                                datagrid2("SELECT * FROM orderdetails WHERE Order_ID IS NULL");
                            }
                            else
                            {



                                con.Close();
                                save.Enabled = true;
                                del.Enabled = true;
                                cmd = new MySqlCommand("INSERT INTO orderdetails VALUES ('NULL','" + qty.Text + "',(SELECT wholesaleCost FROM Product WHERE nameProduct='" + idpro.Text + "'),(SELECT Product_ID FROM Product WHERE nameProduct='" + idpro.Text + "'),NULL)", con);

                                con.Open();
                                cmd.ExecuteNonQuery();
                                con.Close();
                                sum();
                                datagrid2("SELECT * FROM orderdetails WHERE Order_ID IS NULL");
                                update();
                                clear_text();
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

                else
                {
                    MessageBox.Show("สินค้าไม่พอหรือหมด");
                }
                }
                else
                {
                    MessageBox.Show("ไม่พบสินค้า");
                }
                con.Close();
            }

        private void del_Click(object sender, EventArgs e)
        {
            if (
            idpro.Text != "")

            {

                con.Close();
                cmd = new MySqlCommand("SELECT Product_ID FROM orderdetails WHERE Product_ID=(SELECT Product_ID FROM Product WHERE nameProduct='" + idpro.Text + "')", con);
                
                con.Open();
                read = cmd.ExecuteReader();
                if (read.Read())
                {
                
                        con.Close();
                        cmd = new MySqlCommand("UPDATE Product SET Qty=Qty+(SELECT SUM(Qty) FROM orderdetails WHERE nameProduct='" + idpro.Text + "' AND Order_ID IS NULL ) WHERE nameProduct='" + idpro.Text + "'; DELETE FROM orderdetails WHERE Order_ID IS NULL AND Product_ID =(SELECT Product_ID FROM Product WHERE nameProduct='" + idpro.Text + "');", con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();

                    sum();
                    datagrid2("SELECT * FROM orderdetails WHERE Order_ID IS NULL");
                    update();
                    clear_text();
                }
                else
                {
                    MessageBox.Show("ไม่มีรหัสใน Order", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                               
            }
            else
            {
                MessageBox.Show("กรุณากรอกรหัสสินค้า", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
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
        private void save_Click(object sender, EventArgs e)
        {
            if (
            
            date1.Text != "" &&
            date2.Text != "" &&
            cus.Text != "" 
            
            )

            {


                cmd = new MySqlCommand("INSERT INTO orders VALUES (NULL,'" + date1.Text + "','" + date2.Text + "','" + sumqty.Text + "','" + sumprice.Text + "','" + home.empids + "',(SELECT Customer_ID FROM customer WHERE Cus_Fname='" + cus.Text + "'),0);INSERT INTO copy (Qty,Product_ID) SELECT Qty,Product_ID FROM orderdetails WHERE Order_ID IS NULL;UPDATE orderdetails SET Order_ID=(SELECT MAX(Order_ID) FROM orders ) WHERE Order_ID IS NULL;INSERT INTO `recpaycus` (`recPayCus_ID`, `sumprice`, `Typeofpay`, `Status`, `Datepay`, `Employee_ID`, `Order_ID`) VALUES(NULL,NULL,NULL,'0',NULL, '" + home.empids + "',(SELECT MAX(Order_ID) FROM orders ))", con);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                set();
                sumprice.Text = "0";
                sumqty.Text = "0";
                update();
                combobox();
                del.Enabled = false;
                save.Enabled = false;
                datagrid2("SELECT * FROM orderdetails WHERE Order_ID IS NULL");
                comboboxorder();
                MessageBox.Show("เรียบร้อย");
            }
            else
            {
                MessageBox.Show("กรุณากรอบข้อมูลให้ครบ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            con.Close();
            clear_text();
            save.Enabled = false;
            del.Enabled = false;
            cmd = new MySqlCommand("DELETE FROM orderdetails WHERE Order_ID IS NULL ", con);
            sumprice.Text = "0";
            sumqty.Text = "0";
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            datagrid2("SELECT * FROM orderdetails WHERE Order_ID IS NULL");
           
        }

        private void deleteorder_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Confrim ลบการชำระเงิน Order " + idorder.Text, "DELETE", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                cmd = new MySqlCommand("DELETE FROM recpaycus WHERE Order_ID = '" + idorder.Text + "'", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                updateorder();
                deleteorder.Enabled = false;
                combobox();
                comboboxorder();
                deleteall2.Enabled = false;
            }
        }

        private void searchorder_Click(object sender, EventArgs e)
        {
            if (idorder.Text.Equals(""))
            {
                updateorder();
                deleteorder.Enabled = false;
            }
            else
            {
                pay.Enabled = true;
                datagridorder("SELECT * FROM recpaycus WHERE Order_ID ='" + idorder.Text + "' AND Status =0");
                cmd = new MySqlCommand("SELECT * FROM recpaycus WHERE Order_ID ='" + idorder.Text + "' AND Status=0", con);
                con.Open();
                read = cmd.ExecuteReader();
                if (read.Read())
                {
                    deleteorder.Enabled = true;
                }
                else
                {
                    MessageBox.Show("ไม่พบรหัสสินค้านี้", "ไม่พบ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            con.Close();
        }

        private void pay_Click(object sender, EventArgs e)
        {

            double check = 0;
            if (idorder.Text != "")
            {
                try {
                    con.Close();
                    cmd = new MySqlCommand("SELECT Total_Price FROM orders WHERE Order_ID=" + idorder.Text, con);
                    con.Open();
                    read = cmd.ExecuteReader();
                    if (read.Read())
                    {
                        check = read.GetDouble("Total_Price");
                    }

                    con.Close();




                    if (check < Int32.Parse(sump.Text))
                    {
                        MessageBox.Show("จ่ายเกินมา คืน " + (Int32.Parse(sump.Text) - check));
                       
                    } else if (check > Int32.Parse(sump.Text))
                    {
                        MessageBox.Show("จ่ายไม่ครบ ขาด " + (check - Int32.Parse(sump.Text)));
                    }
                    else {
                        DialogResult dialog = MessageBox.Show("ยืนยันการชำระเงิน" + idorder.Text, "DELETE", MessageBoxButtons.YesNo);
                        if (dialog == DialogResult.Yes)
                        {
                            

                            con.Close();
                            pay.Enabled = true;
                            cmd = new MySqlCommand("UPDATE recpaycus SET sumprice=" + sump.Text + ",Typeofpay ='" + typepay.Text + "',Status=1,Datepay='" + datepay.Text + "' WHERE Order_ID =" + idorder.Text, con); //+ ";UPDATE orders SET status =1 WHERE Order_ID =" + idorder.Text, con);
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();
                            updateorder();
                            comboboxorder();




                            pay.Enabled = false;
                            con.Close();
                            MessageBox.Show("เรียบร้อย");
                            idorder.ResetText();
                        }
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("กรอกข้อมูลผิด");
                
                }
            }
            else
            {
                MessageBox.Show("กรุณากรอกรหัส Order", "ไม่พบ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            }

        private void deletesend_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Confrim", "DELETE", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                deleteall.Enabled = false;
                cmd = new MySqlCommand("DELETE FROM recsender WHERE recSender_ID = '" + idsend.Text + "'", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                updatesend();
                deletesend.Enabled = false;
                detail.Enabled = false;
                comboboxsend();
            }
            
            
        }

        private void savesend_Click(object sender, EventArgs e)
        {
            if (
            distance.Text != "" &&
            datesend.Text != "" &&
            car.Text != "" &&
            cus2.Text != "" &&
            idorder2.Text != "")

            {
                try {

                    con.Close();
                    cmd = new MySqlCommand("INSERT INTO recsender VALUES (NULL,'" + datesend.Text + "','" + distance.Text + "','" + car.Text + "','" + emp.Text + "');INSERT INTO detailsend VALUES(NULL,(SELECT MAX(recSender_ID) FROM recSender),'" + idorder2.Text + "','" + cus2.Text + "');UPDATE orders SET status =1 WHERE Order_ID =" + idorder2.Text, con);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    updatesend();
                    comboboxemp();
                    comboboxsend();
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

        private void searchsend_Click(object sender, EventArgs e)
        {
            if (idsend.Text.Equals(""))
            {
                updatesend();
                deletesend.Enabled = false;
            }
            else
            {

                datagridsend("SELECT * FROM recsender  WHERE recSender_ID ='" + idsend.Text + "' ");
                cmd = new MySqlCommand("SELECT * FROM recsender WHERE recSender_ID ='" + idsend.Text + "' ", con);
                con.Open();
                read = cmd.ExecuteReader();
                if (read.Read())
                {
                    deletesend.Enabled = true;
                    detail.Enabled = true;
                    deleteall.Enabled = false;
                }
                else
                {
                    MessageBox.Show("ไม่พบรหัสสินค้านี้", "ไม่พบ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            con.Close();
        
    }

        private void order_FormClosing(object sender, FormClosingEventArgs e)
        {
            clear_text();
            save.Enabled = false;
            del.Enabled = false;
            con.Close();
            cmd = new MySqlCommand("DELETE FROM orderdetails WHERE Order_ID IS NULL ", con);
            sumprice.Text = "0";
            sumqty.Text = "0";
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            datagrid2("SELECT * FROM orderdetails WHERE Order_ID IS NULL");
        }

        private void fix_Click(object sender, EventArgs e)
        {
            con.Close();
            cmd = new MySqlCommand("UPDATE recpaycus SET  WHERE Order_ID IS NULL ", con);
        }

       

        private void detail_Click(object sender, EventArgs e)

        {
            try
            {
                if (idsend.Text != "")
                {
                    datagridsend("SELECT * FROM detailsend  WHERE recSender_ID ='" + idsend.Text + "' ");
                }
            }
            catch (Exception)
            {

            }
        }

        private void search2_Click_1(object sender, EventArgs e)
        {
            con.Close();
            delete.Enabled = false;
            cmd = new MySqlCommand("SELECT * FROM orders WHERE status=0 ", con);
            con.Open();
            cmd.ExecuteNonQuery();
            datagrid("SELECT * FROM orders WHERE status=0");



            con.Close();
        }

        private void detail2_Click(object sender, EventArgs e)
        {
            datagrid("SELECT * FROM orderdetails WHERE Order_ID ='" + id.Text + "' ");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            รายการขาย a = new รายการขาย();
            this.Hide();
            a.ShowDialog();
            this.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cancelorder a = new cancelorder();
            this.Enabled = false;
            a.ShowDialog();
            this.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            datagridsend("SELECT * FROM recsender  WHERE Date >='" + da1.Text + "' AND Date <='" + da2.Text + "'");
            deleteall.Enabled = true;
        }

        private void deleteall_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Confrim ลบทั้งหมดของวันที่ "+ da1.Text+" ถึง "+da2.Text, "DELETE", MessageBoxButtons.YesNo);

            if (dialog == DialogResult.Yes)
            {
                cmd = new MySqlCommand("DELETE FROM recsender WHERE  Date >='" + da1.Text + "' AND Date <='" + da2.Text + "'", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                updatesend();
                deletesend.Enabled = false;
                detail.Enabled = false;
                comboboxsend();

            }
        }

        private void searchall2_Click(object sender, EventArgs e)
        {
            datagridorder("SELECT * FROM recpaycus  WHERE Datepay >='" + da11.Text + "' AND Datepay <='" + da22.Text + "'");
            deleteall2.Enabled = true;
        }

        private void deleteall2_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Confrim ลบทั้งหมดของวันที่ " + da11.Text + " ถึง " + da22.Text, "DELETE", MessageBoxButtons.YesNo);

            if (dialog == DialogResult.Yes)
            {
                cmd = new MySqlCommand("DELETE FROM recpaycus WHERE  Datepay >='" + da11.Text + "' AND Datepay <='" + da22.Text + "'", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                updatesend();
                deletesend.Enabled = false;
                detail.Enabled = false;
                comboboxsend();
                deleteall2.Enabled = false;
                updateorder();

            }
        }
    }
}
