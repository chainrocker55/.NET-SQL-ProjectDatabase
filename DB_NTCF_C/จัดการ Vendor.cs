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
    public partial class จัดการ_Vendor : Form
    {
        public จัดการ_Vendor()
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
            name_text.Clear();
             tel.Clear();
            mail.Clear();
            address.Clear();
            province.Clear();
            prefecture.Clear();
            zip.Clear();
            road.Clear();
            id_text.Clear();
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

            cmd = new MySqlCommand("SELECT * FROM vendor", con);
            da = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        void combobox()
        {
            id.Items.Clear();
            cmd = new MySqlCommand("SELECT * FROM vendor", con);
            con.Open();
            read = cmd.ExecuteReader();
            while (read.Read())
            {
                id.Items.Add(read.GetString("Vendor_ID"));
            }
            con.Close();
        }


        private void add_Click(object sender, EventArgs e)
        {
            try { 
            if (
           name_text.Text != "" &&
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
                cmd = new MySqlCommand("INSERT INTO vendor  VALUES ('" + id_text.Text + "','" + name_text.Text + "','" + tel.Text + "','" + mail.Text + "','" + address.Text + "','" + district.Text + "','" + prefecture.Text + "','" + road.Text + "','" + province.Text + "','" + zip.Text + "')", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                update();
                clear_text();
                combobox();

            }
            else
            {
                MessageBox.Show("กรุณากรอบข้อมูลให้ครบ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            } catch (Exception)
            {
                MessageBox.Show("มี ID นี้แล้ว");
            }

        }

        private void จัดการ_Vendor_Load(object sender, EventArgs e)
        {
            combobox();
            update();
            delete.Enabled = false;
            edit.Enabled = false;

            cmd = new MySqlCommand("SELECT * FROM vendor", con);
            con.Open();
          
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

                datagrid("SELECT * FROM vendor WHERE Vendor_ID ='" + id.Text + "' ");
                cmd = new MySqlCommand("SELECT * FROM vendor WHERE Vendor_ID ='" + id.Text + "' ", con);
                con.Open();
                read = cmd.ExecuteReader();
                if (read.Read())
                {
                    delete.Enabled = true;
                    edit.Enabled = true;                  

                    id_text.Text = read.GetString("Vendor_ID");
                    name_text.Text = read.GetString("Vendor_Name");
                    tel.Text = read.GetString("Tel");
                    mail.Text = read.GetString("Email");
                    address.Text = read.GetString("Address");
                    province.Text = read.GetString("Province");
                    prefecture.Text = read.GetString("prefecture");
                    zip.Text = read.GetString("Zipcode");
                    road.Text = read.GetString("Road");
                    district.Text = read.GetString("District");

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
                cmd = new MySqlCommand("DELETE FROM Vendor WHERE Vendor_ID = '" + id.Text + "'", con);
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
                id_text.Text!=""&&
              name_text.Text != "" &&
           tel.Text != "" &&
           mail.Text != "" &&
           address.Text != "" &&
           province.Text != "" &&
           prefecture.Text != "" &&
           zip.Text != "" &&
           road.Text != "" &&
           district.Text != "")
            {
                DialogResult dialog = MessageBox.Show("Confrim", "UPDATE", MessageBoxButtons.YesNo);
                if (dialog == DialogResult.Yes)
                {
                    con.Close();
                    cmd = new MySqlCommand("UPDATE Vendor SET Vendor_Name ='" + name_text.Text + "',Tel= '" + tel.Text + "',Email=  '" + mail.Text + "',Address='" + address.Text + "',District=  '" + district.Text + "',prefecture= '" + prefecture.Text + "',Road='"+road.Text+"',Province='"+province.Text+"',Zipcode='"+zip.Text+ "',Vendor_ID ='"+id_text.Text+"' WHERE Vendor_ID = '" + id.Text + "' ", con);
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
    }
}
