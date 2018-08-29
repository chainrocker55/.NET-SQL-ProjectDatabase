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
    public partial class การจัดการแผนก : Form
    {
        public การจัดการแผนก()
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

        void update()
        {
            con.Close();
            con.Open();

            cmd = new MySqlCommand("SELECT 	Department_Name, ID_Head,COUNT(Employee_ID) FROM Department NATURAL JOIN Employee GROUP BY Department_Name ", con);
            da = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
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
        void clear_text()
        {
            id.ResetText();
            name2.Clear();
            name.ResetText();
           
        }

        private void การจัดการแผนก_Load(object sender, EventArgs e)
        {
            update();
            delete.Enabled = false;
            edit.Enabled = false;
            
        }
        private void search_Click(object sender, EventArgs e)
        {
            if (name.Text.Equals(""))
            {
                update();
                clear_text();
                add.Enabled = true;
                edit.Enabled = false;
                delete.Enabled = false;
            }
            else
            {
                
                datagrid("SELECT * FROM Department WHERE Department_Name ='" + name.Text + "' ");
                cmd = new MySqlCommand("SELECT * FROM Department WHERE Department_Name ='" + name.Text + "' ", con);
                con.Open();
                read = cmd.ExecuteReader();
                if (read.Read())
                {
                    try
                    {
                        delete.Enabled = true;
                        edit.Enabled = true;
                        name2.Text = read.GetString("Department_Name");
                        id.Text = read.GetString("ID_Head");
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Head ว่างอยู่");
                    }
                }
                else
                {
                    MessageBox.Show("ไม่พบชื่อแผนกนี้", "ไม่พบ", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
                cmd = new MySqlCommand("DELETE FROM Department WHERE Department_Name = '" + name.Text + "'", con);
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
            name2.Text != "")
           
            {
                try
                {
                    con.Close();
                    cmd = new MySqlCommand("INSERT INTO Department VALUES ('" + name2.Text + "','" + id.Text + "')", con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    update();
                    clear_text();
                }
                catch (Exception)
                {
                    MessageBox.Show("ข้อมูลซ้ำ");
                }
            }
            else
            {
                MessageBox.Show("กรุณากรอบข้อมูลให้ครบ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
        private void edit_Click(object sender, EventArgs e)
        {
            if (          
            name2.Text != "" &&
            id.Text != "" 
            )
            {
                DialogResult dialog = MessageBox.Show("Confrim", "Edit", MessageBoxButtons.YesNo);
                if (dialog == DialogResult.Yes)
                {
                    con.Close();
                    cmd = new MySqlCommand("UPDATE Department SET Department_Name='" + name2.Text + "',ID_Head= '" + id.Text + "' ", con);
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

        private void name_Click(object sender, EventArgs e)
        {
            combobox("department", "Department_Name",name);
        }

        private void id_Click(object sender, EventArgs e)
        {
            combobox("employee", "Employee_ID", id);
        }
    }
}
