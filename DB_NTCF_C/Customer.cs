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
    public partial class Customer : Form
    {
        public Customer()
        {
            InitializeComponent();
        }
        MySqlConnection con = new MySqlConnection("host = localhost ; user=59160089;password=59160089;database=s59160089;CharSet=UTF8");
        MySqlCommand cmd;

        MySqlDataAdapter da;
        MySqlDataReader read;
        void clear_text()
        {
            id.ResetText();
            name1.Clear();
            name2.Clear();
            tel.Clear();
            mail.Clear();
            address.Clear();
            province.Clear();
            prefecture.Clear();
            zip.Clear();
            road.Clear();            
            district.Clear();
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
        void update()
        {
            con.Close();
            con.Open();

            cmd = new MySqlCommand("SELECT * FROM Customer", con);
            da = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        void combobox()
        {
            id.Items.Clear();
            cmd = new MySqlCommand("SELECT * FROM Customer", con);
            con.Open();
            read = cmd.ExecuteReader();
            while (read.Read())
            {
                id.Items.Add(read.GetString("Customer_ID"));
            }
            con.Close();
        }


        private void add_Click(object sender, EventArgs e)
        {

            if (

           name1.Text != "" &&
           name2.Text != "" &&
           tel.Text != "" &&
           mail.Text != "" &&
           address.Text != "" &&
           province.Text != "" &&
           prefecture.Text != "" &&
           zip.Text != "" &&
           road.Text != "" &&
           district.Text != "")
            {
                con.Close();
                cmd = new MySqlCommand("SELECT * FROM Customer WHERE Cus_Fname='" + name1.Text + "' AND Cus_Lname='" + name2.Text + "'", con);
                con.Open();
                read = cmd.ExecuteReader();
                if (read.Read())
                {
                    MessageBox.Show("มี ลูกค้าคนนี้แล้ว");
                    con.Close();
                }
                else
                {




                    con.Close();
                    cmd = new MySqlCommand("INSERT INTO Customer VALUES(NULL,'" + name1.Text + "','" + name2.Text + "','" + mail.Text + "','" + address.Text + "','" + road.Text + "','" + prefecture.Text + "','" + district.Text + "','" + province.Text + "','" + zip.Text + "','" + tel.Text + "')", con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    update();
                    clear_text();
                    combobox();




                }
            }
            else
            {
                MessageBox.Show("กรุณากรอบข้อมูลให้ครบ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

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

                datagrid("SELECT * FROM Customer WHERE Customer_ID ='" + id.Text + "' ");
                cmd = new MySqlCommand("SELECT * FROM Customer WHERE Customer_ID ='" + id.Text + "' ", con);
                con.Open();
                read = cmd.ExecuteReader();
                if (read.Read())
                {
                    delete.Enabled = true;
                    edit.Enabled = true;
                   

                    id.Text = read.GetString("Customer_ID");
                    name1.Text = read.GetString("Cus_Fname");
                    name2.Text = read.GetString("Cus_Lname");
                    tel.Text = read.GetString("Tel");
                    mail.Text = read.GetString("Cus_Email");
                    address.Text = read.GetString("Cus_HouseNo");
                    province.Text = read.GetString("Cus_Province");
                    prefecture.Text = read.GetString("Cus_Subarea");
                    zip.Text = read.GetString("Cus_PostalCode");
                    road.Text = read.GetString("Cus_Road");
                    district.Text = read.GetString("Cus_Area");

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
                cmd = new MySqlCommand("DELETE FROM Customer WHERE Customer_ID = '" + id.Text + "'", con);
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

        private void edit_Click(object sender, EventArgs e)
        {
            if (
           id.Text != "" &&
           name2.Text != "" &&
           name1.Text != "" &&
           tel.Text != "" &&
           mail.Text != "" &&
           address.Text != "" &&
           province.Text != "" &&
           prefecture.Text != "" &&
           zip.Text != "" &&
           road.Text != "" &&
           district.Text != "")
            {
                DialogResult dialog = MessageBox.Show("Confrim", "แก้ไข", MessageBoxButtons.YesNo);
                if (dialog == DialogResult.Yes)
                {
                    cmd = new MySqlCommand("UPDATE Customer SET Cus_Fname ='" + name1.Text + "',Cus_Lname ='" + name2.Text + "',Tel= '" + tel.Text + "',Cus_Email=  '" + mail.Text + "',Cus_HouseNo='" + address.Text + "',Cus_Area=  '" + district.Text + "',Cus_Subarea= '" + prefecture.Text + "',Cus_Road='" + road.Text + "',Cus_Province='" + province.Text + "',Cus_PostalCode='" + zip.Text + "',Customer_ID ='" + id.Text + "' WHERE Customer_ID = '" + id.Text + "' ", con);
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
            else
            {
                MessageBox.Show("กรุณากรอกข้อมูลให้ครบ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Customer_Load(object sender, EventArgs e)
        {
            combobox();
            update();
            delete.Enabled = false;
            edit.Enabled = false;
        }
    }
}
