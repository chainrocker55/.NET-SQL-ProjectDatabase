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
    public partial class การจัดการสาขา : Form
    {
        public การจัดการสาขา()
        {
            InitializeComponent();
        }
        MySqlConnection con = new MySqlConnection("host = localhost ; user=59160089;password=59160089;database=s59160089;CharSet=UTF8");
        MySqlCommand cmd;

        MySqlDataAdapter da;
        MySqlDataReader read;
        private void การจัดการสาขา_Load(object sender, EventArgs e)
        {
            update();
            delete.Enabled = false;
            edit.Enabled = false;
            combobox("branch", "Branch_ID",id);
            
        }
        void combobox(String table, String column, ComboBox b)
        {
            b.Items.Clear();
            cmd = new MySqlCommand("SELECT * FROM " + table + " ", con);
            con.Open();
            read = cmd.ExecuteReader();

            while (read.Read())
            {
                b.Items.Add(read.GetString(column));
            }
            con.Close();


        }

        void update()
        {
            con.Close();
            con.Open();

            cmd = new MySqlCommand("SELECT * FROM Branch", con);
            da = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
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
        void clear_text()
        {
            id.ResetText();
            mail.Clear();
            tel.Clear();
            address.Clear();
            a.Clear();
            b.Clear();
            c.Clear();
            road.Clear();
            zip.Clear();
        }
        private void search_Click(object sender, EventArgs e)
        {
            if (id.Text.Equals(""))
            {
                update();
                clear_text();              
                edit.Enabled = false;
                delete.Enabled = false;
            }
            else
            {

                datagrid("SELECT * FROM Branch WHERE Branch_ID ='" + id.Text + "' ");
                cmd = new MySqlCommand("SELECT * FROM Branch WHERE Branch_ID ='" + id.Text + "' ", con);
                con.Open();
                read = cmd.ExecuteReader();
                if (read.Read())
                {
                    delete.Enabled = true;
                    edit.Enabled = true;
                    add.Enabled = false;

                    id.Text = read.GetString("Branch_ID");
                    tel.Text = read.GetString("Bra_Tal");
                    mail.Text = read.GetString("Bra_Email");
                    address.Text = read.GetString("Bra_HouseNo");
                    a.Text = read.GetString("Bra_Area");
                    b.Text = read.GetString("Bra_Subarea");
                    c.Text = read.GetString("Bra_Province");
                    road.Text = read.GetString("Bra_Road");
                    zip.Text = read.GetString("Bra_PostalCode");
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
                cmd = new MySqlCommand("DELETE FROM Branch WHERE Branch_ID = '" + id.Text + "'", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                update();
                clear_text();
                add.Enabled = true;
                delete.Enabled = false;
                edit.Enabled = false;
            }



        }
        private void add_Click(object sender, EventArgs e)
        {
            if (
            tel.Text != "" &&
            address.Text != "" &&
            mail.Text != "" &&
            a.Text != "" &&
            c.Text != "" &&
            road.Text != "" &&
            zip.Text != "" &&
            b.Text != "")
            {
                cmd = new MySqlCommand("INSERT INTO Branch VALUES ('NULL','" + tel.Text + "','" + address.Text + "','" + a.Text + "','" + b.Text + "','" + road.Text + "','"+c.Text+"','"+zip.Text+"','"+mail.Text+"')", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                update();
                clear_text();
            }
            else
            {
                MessageBox.Show("กรุณากรอบข้อมูลให้ครบ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
        private void edit_Click(object sender, EventArgs e)
        {
            if (
               tel.Text != "" &&
            address.Text != "" &&
            mail.Text != "" &&
            a.Text != "" &&
            c.Text != "" &&
            road.Text != "" &&
            zip.Text != "" &&
            b.Text != "")
            {
                DialogResult dialog = MessageBox.Show("Confrim", "EDIT", MessageBoxButtons.YesNo);
                if (dialog == DialogResult.Yes)
                {
                    cmd = new MySqlCommand("UPDATE Branch SET Branch_ID='" + id.Text + "',	Bra_Tal= '" + tel.Text + "',Bra_HouseNo=  '" + address.Text + "',Bra_Area='" + a.Text + "',Bra_Subarea=  '" + b.Text + "',Bra_Road= '" + road.Text + "',Bra_Province= '" + c.Text + "',Bra_PostalCode= '" + zip.Text + "',Bra_Email= '" + mail.Text + "' WHERE Branch_ID = '" + id.Text + "' ", con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    update();
                    clear_text();
                    edit.Enabled = false;
                    add.Enabled = true;
                    delete.Enabled = false;
                }



            }
            else
            {
                MessageBox.Show("กรุณากรอกข้อมูลให้ครบ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void id_Click(object sender, EventArgs e)
        {
            combobox("branch", "Branch_ID", id);
        }
    }
}
