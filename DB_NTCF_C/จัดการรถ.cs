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
    public partial class การส่งซ่อม : Form
    {
        public การส่งซ่อม()
        {
            InitializeComponent();
        }
        MySqlConnection con = new MySqlConnection("host = localhost ; user=59160089;password=59160089;database=s59160089;CharSet=UTF8");
        MySqlCommand cmd;

        MySqlDataAdapter da;
        MySqlDataReader read;
        string s = "";
        
        private void การส่งซ่อม_Load(object sender, EventArgs e)
        {
            add2.Enabled = false;
            update2();
            update();
            delete.Enabled = false;
            delete3.Enabled = false;
            edit.Enabled = false;
            add.Enabled = true;
            combobox2();
            comboboxstatus();
            combobox();
            combobox3();
            detail.Enabled = false;
        }
        void clear_text()
        {
            idcar.ResetText();
            p.Clear();
            num.Clear();
            branch.ResetText();
            
        }
        void clear_text2()
        {
            cause.ResetText();
            price.Clear();
          

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
        void datagridcar(String sql)
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
        void combobox()
        {
            idcar.Items.Clear();
            car.Items.Clear();
            cmd = new MySqlCommand("SELECT * FROM Car", con);
            con.Open();
            read = cmd.ExecuteReader();
            while (read.Read())
            {
                idcar.Items.Add(read.GetString("Car_ID"));
                car.Items.Add(read.GetString("Car_ID"));
            }
            con.Close();
        }
        void comboboxstatus()
        {
            status.Items.Add("ว่าง");
            status.Items.Add("ไม่ว่าง");

        }
        void combobox4()
        {
            car.Items.Clear();
            cmd = new MySqlCommand("SELECT * FROM Car", con);
            con.Open();
            read = cmd.ExecuteReader();
            while (read.Read())
            {
                car.Items.Add(read.GetString("Car_ID"));
            }
            con.Close();
        }
        void combobox3()
        {
            idfix.Items.Clear();
            cmd = new MySqlCommand("SELECT * FROM Fix", con);
            con.Open();
            read = cmd.ExecuteReader();
            while (read.Read())
            {
                idfix.Items.Add(read.GetString("Fix_ID"));
            }
            con.Close();
        }
        void combobox2()
        {
            branch.Items.Clear();
            cmd = new MySqlCommand("SELECT * FROM Branch", con);
            con.Open();
            read = cmd.ExecuteReader();
            while (read.Read())
            {
                branch.Items.Add(read.GetString("Branch_ID"));
            }
            con.Close();
        }
        void update()
        {
            con.Close();
            con.Open();

            cmd = new MySqlCommand("SELECT * FROM Car", con);
            da = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView2.DataSource = dt;
            con.Close();
        }
        void setS()
        {
            con.Close();
            

            cmd = new MySqlCommand("SELECT MAX(Fix_ID) FROM Fix", con);
            con.Open();
            read = cmd.ExecuteReader();
            while (read.Read())
            {
                s = read.GetString("MAX(Fix_ID)");
            }
            
            con.Close();
        }
        /*string sumprice()
        {
            con.Close();


            cmd = new MySqlCommand("SELECT SUM(Amount) FROM DetailFix NATURAL JOIN Fix WHERE DetailFix_ID='"+s+"'", con);
            con.Open();
            read = cmd.ExecuteReader();
            while (read.Read())
            {
               return ""+read.GetInt32("SUM(Amount)");
            }

            con.Close();
            return "0";
        }*/
        private void add_Click(object sender, EventArgs e)
        {
            if (         
           p.Text != "" &&
           num.Text != "" &&
           branch.Text != "")

            {
                cmd = new MySqlCommand("INSERT INTO Car  VALUES ('NULL','" + p.Text + "','" + num.Text + "','" + branch.Text + "',0)", con);
                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Success");
                con.Close();
                update();
                combobox2();
                combobox();
              

            }
            else
            {
                MessageBox.Show("กรุณากรอบข้อมูลให้ครบ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
        private void search_Click(object sender, EventArgs e)
        {
            if (idcar.Text.Equals(""))
            {
                update();
                clear_text();
                add.Enabled = false;
                edit.Enabled = false;
                delete.Enabled = false;
            }
            else
            {

                datagrid("SELECT * FROM Car WHERE Car_ID ='" + idcar.Text + "' ");
                cmd = new MySqlCommand("SELECT * FROM Car NUTURAL JOIN Branch WHERE Car_ID ='" + idcar.Text + "' ", con);
                con.Open();
                read = cmd.ExecuteReader();
                if (read.Read())
                {
                    delete.Enabled = true;
                    edit.Enabled = true;
                    add.Enabled = false;

                    idcar.Text = read.GetString("Car_ID");
                    p.Text = read.GetString("register");
                    num.Text = read.GetString("NumberTank");
                    branch.Text = read.GetString("Branch_ID");
                    
                    int check = read.GetInt32("status");
                    if (check == 1)
                    {
                        status.Text = "ไม่ว่าง";
                    }
                    else {
                        status.Text = "ว่าง";
                    }
                  

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
                cmd = new MySqlCommand("DELETE FROM Car WHERE Car_ID = '" + idcar.Text + "'", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                update();
                clear_text();
                add.Enabled = true;
                delete.Enabled = false;
                edit.Enabled = false;
                combobox2();
                combobox();
            }

        }
        private void edit_Click(object sender, EventArgs e)
        {
            if (
              idcar.Text != "" &&
           p.Text != "" &&
           num.Text != "" &&
           branch.Text != "")
            {
                DialogResult dialog = MessageBox.Show("Confrim", "Edit", MessageBoxButtons.YesNo);
                if (dialog == DialogResult.Yes)
             
                {
                    int check;
                    if (status.Text.Equals("ว่าง"))
                    {
                        check = 0;
                    }
                    else
                    {
                        check = 1;
                    }
                    try
                    {
                        con.Close();
                        cmd = new MySqlCommand("UPDATE Car SET Car_ID ='" + idcar.Text + "',register= '" + p.Text + "',NumberTank=  '" + num.Text + "',Branch_ID='" + branch.Text + "',status=" + check + " WHERE Car_ID ='" + idcar.Text + "' ", con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        update();
                        clear_text();
                        edit.Enabled = false;
                        add.Enabled = true;
                        delete.Enabled = false;
                        combobox2();
                        combobox();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("ป้อนข้อมูลผิด");
                    }
                }



            }
            else
            {
                MessageBox.Show("กรุณากรอกข้อมูลให้ครบ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        //การส่งซ่อม
        void update2()
        {
            con.Close();
            con.Open();

            cmd = new MySqlCommand("SELECT * FROM Fix", con);
            
            da = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }
        void update3()
        {
            con.Close();
            con.Open();

            cmd = new MySqlCommand("SELECT * FROM DetailFix WHERE DetailFix_ID='" +s+"'", con);
            da = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView3.DataSource = dt;
            con.Close();
        }
       
        private void search2_Click(object sender, EventArgs e)
        {
            if (idfix.Text.Equals(""))
            {
                update2();                       
                delete3.Enabled = false;
                detail.Enabled = false;
            }
            else
            {

                datagrid("SELECT * FROM Fix WHERE Fix_ID ='" + idfix.Text + "' ");
                cmd = new MySqlCommand("SELECT * FROM Fix  WHERE Fix_ID ='" + idfix.Text + "' ", con);
                con.Open();
                read = cmd.ExecuteReader();
                if (read.Read())
                {
                   
                    delete3.Enabled = true;
                    detail.Enabled = true;
                }
                else
                {
                    MessageBox.Show("ไม่พบรหัสสินค้านี้", "ไม่พบ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                }

            }
            con.Close();
        }
        private void add2_Click(object sender, EventArgs e)
        {
            if (
           cause.Text != "" &&
           price.Text != "" &&
           car.Text != "")

            {
                try {
                    cmd = new MySqlCommand("INSERT INTO DetailFix  VALUES ('NULL','" + cause.Text + "','" + price.Text + "','" + car.Text + "','" + s + "');UPDATE fix SET sumprice=sumprice+" + price.Text + " WHERE Fix_ID ='" + s + "';UPDATE Car SET status =1 WHERE Car_ID ="+car.Text, con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    datagrid2("SELECT * FROM DetailFix NATURAL JOIN fix WHERE Fix_ID ='" + s + "' ");
                    MessageBox.Show("Success");
                    update2();
                    con.Close();
                    combobox2();
                    combobox();
                    clear_text2();

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

        private void save_Click(object sender, EventArgs e)
        {
            con.Close();
            cmd = new MySqlCommand("INSERT INTO `fix` (`Fix_ID`, `DateSent`, `DateRe`, `Employee_ID`) VALUES (NULL, '"+datefix.Text+"', '"+datere.Text+"','"+home.empids+"');", con);
                
                con.Open();
             
                cmd.ExecuteNonQuery();
                MessageBox.Show("กรุณาเพิ่มรายการ");              
                con.Close();
                setS();
                update2();
                combobox3();
            combobox4();
                add2.Enabled = true;
             
                
                datagrid2("SELECT * FROM DetailFix WHERE DetailFix_ID ='" + s + "' ");
                //sum.Text = "0";

        }

        private void delete3_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Confrim", "DELETE", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                delete3.Enabled = false;
                combobox3();
                cmd = new MySqlCommand("DELETE FROM Fix WHERE Fix_ID = '" + idfix.Text + "'", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                update2();

                
                clear_text();
                add.Enabled = true;
                delete.Enabled = false;
                edit.Enabled = false;
                detail.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            datagridcar("SELECT * FROM detailfix WHERE Fix_ID ='" + idfix.Text + "' ");
        }
    }
}
