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
    public partial class emp : Form
    {
        public emp()
        {
            InitializeComponent();
        }

        MySqlConnection con = new MySqlConnection("host = localhost ; user=59160089;password=59160089;database=s59160089;CharSet=UTF8");
        MySqlCommand cmd;

        MySqlDataAdapter da;
        MySqlDataReader read;
        DataTable dt;


        void datagrid(String sql, DataGridView dataGrid)
        {
            con.Close();
            con.Open();

            cmd = new MySqlCommand(sql, con);
            da = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGrid.DataSource = dt;
            con.Close();
        }

        void update(String table, DataGridView dataGrid, string sql)
        {
            con.Close();
            con.Open();

            cmd = new MySqlCommand(sql, con);
            da = new MySqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            dataGrid.DataSource = dt;
            con.Close();
        }
        void combobox(String table, String column, ComboBox b)
        {
            con.Close();
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
            combo_idemp_6.ResetText();
            combo_id_6.ResetText();
            Paymentperiod6.Clear();
            Amount_6.Clear();
            idtext6.Clear();
            comid_6.ResetText();

            combo_id_5_search.ResetText();
            comid_5.ResetText();
            idtext_5.Clear();
            case_5.Clear();

          
            branch_2_5.ResetText();
            departid_5.ResetText();
            posi_5.ResetText();

            Detail_4.Clear();
            idค่าปรับtext.Clear();
            Amount_4.Clear();
            combo_id_4_search.ResetText();
            textid_2.Clear();
            com2_search.ResetText();
            com_workoff_3_search.ResetText();
            combo_id_3_search.Text = "";
            IDtext_3.Clear();
            id_text.Clear();
            combo_id.ResetText();
            fname.Clear();
            lname.Clear();
            ปปช.Clear();
            ลบช.Clear();
            address.Clear();
            ศึกษา.Clear();
            Tel.Clear();
            email.Clear();
            salary.Clear();
            แผนก.ResetText();
            branch.ResetText();
            ตำแหน่ง.ResetText(); com_workoff_3_search.ResetText();
            username.Clear();
            password.Clear();
            rectimework_combo_id2.ResetText();
            emp_combo_2.ResetText();
            combo_id_3.ResetText();
            type_3.ResetText();
            day_3.Clear();
            because_3.Clear();
        }

        private void emp_Load(object sender, EventArgs e)
        {
            update("employee", dataGridView1, "SELECT * FROM employee NATURAL JOIN login ");
            combobox("employee", "Employee_ID", combo_id);
            combobox("department", "Department_Name", แผนก);
            combobox("position", "Position_Name", ตำแหน่ง);
            combobox("branch", "Branch_ID", branch);
            combobox("employee", "Employee_ID", combo_id);
            delete.Enabled = false;
            edit.Enabled = false;
            delete_2.Enabled = false;
            edit_2.Enabled = false;

            //---------------PAGE 2 VVV

            combobox("recworktime", "recWorkTime_ID", rectimework_combo_id2);
            update("recworktime", dataGridView2, "SELECT * FROM recworktime ");
            combobox("typework", "TypeWork_Name", type_work);
            combobox("employee", "Employee_ID", emp_combo_2);
            combobox("employee", "Employee_ID", com2_search);

            //---------------PAGE 3 VVV

            combobox("employee", "Employee_ID", combo_id_3_search);
            combobox("employee", "Employee_ID", combo_id_3);
            combobox("typeworkoff", "Type_Name", type_3);
            combobox("workoff", "workoff_id", com_workoff_3_search);
            update("workoff", dataGridView3, "SELECT * FROM workoff ");
            add_3.Enabled = true;
            edit_3.Enabled = false;
            delete_3.Enabled = false;

            //---------------PAGE 4 VVV

            combobox("employee", "Employee_ID", com_empid_4);
            combobox("employee", "Employee_ID", combo_id_4_search);
            combobox("recfineemp", "recFineEmp_ID", com_recfineempId_search);
            update("recfineemp", dataGridView4, "SELECT * FROM recfineemp ");
            add_4.Enabled = true;
            edit_4.Enabled = false;
            delete_4.Enabled = false;

            //---------------PAGE 5 VVV
            update("recmovestore", dataGridView5, "SELECT * FROM recmovestore ");
            combobox("employee", "Employee_ID", comid_5);
            combobox("department", "Department_Name", departid_5);
            combobox("position", "Position_Name", posi_5);
     
            combobox("branch", "Branch_ID", branch_2_5);
            combobox("employee", "Employee_ID", combo_id_5_search);
            combobox("recmovestore", "recMoveStore_ID", com__search);

            add_5.Enabled = true;
            edit_5.Enabled = false;
            del_5.Enabled = false;

            //---------------PAGE 6 VVV
            update("recsalary", dataGridView6, "SELECT * FROM recsalary");
            combobox("employee", "Employee_ID", combo_idemp_6);
            combobox("employee", "Employee_ID", comid_6);
            combobox("recsalary", "recSalary_ID", combo_id_6);

            add6.Enabled = false;
            edit6.Enabled = false;
            del6.Enabled = false;
            total.Enabled = false;

        }

        private void search_Click(object sender, EventArgs e)
        {
            if (combo_id.Text.Equals(""))
            {
                update("employee", dataGridView1, "SELECT * FROM employee NATURAL JOIN login ");
                clear_text();
                add.Enabled = true;
                edit.Enabled = false;
                delete.Enabled = false;
            }
            else
            {
                cmd = new MySqlCommand("SELECT * FROM (((employee NATURAL JOIN login) NATURAL JOIN branch) NATURAL JOIN department) NATURAL JOIN position WHERE Employee_ID = '" + combo_id.Text + "'", con);
                con.Open();
                read = cmd.ExecuteReader();
                if (read.Read())
                {
                    delete.Enabled = true;
                    edit.Enabled = true;
                    add.Enabled = false;
                    fname.Text = read.GetString("EMP_FNAME");
                    lname.Text = read.GetString("EMP_LNAME");
                    id_text.Text = read.GetString("Employee_ID");
                    ปปช.Text = read.GetString("Publiccode");
                    ลบช.Text = read.GetString("Accountnumber");
                    address.Text = read.GetString("Address");
                    ศึกษา.Text = read.GetString("HisEducation");
                    Tel.Text = read.GetString("Tel");
                    email.Text = read.GetString("Email");
                    sdate.Text = read.GetString("DateStart");
                    bdate.Text = read.GetString("Brithday");
                    salary.Text = read.GetString("Salary");
                    username.Text = read.GetString("username");
                    password.Text = read.GetString("password");
                    branch.Text = read.GetString("Branch_ID");
                    แผนก.Text = read.GetString("Department_ID");
                    ตำแหน่ง.Text = read.GetString("Position_ID");
                    datagrid("SELECT * FROM employee NATURAL JOIN login WHERE Employee_ID ='" + combo_id.Text + "' ", dataGridView1);
                    con.Close();


                }
                else
                {
                    MessageBox.Show("ไม่พบรหัสพนักงานนี้", "ไม่พบ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    clear_text();
                }

            }
            con.Close();
        }

        private void add_Click(object sender, EventArgs e)
        {
            if (
           fname.Text != "" &&
           lname.Text != "" &&
           ปปช.Text != "" &&
           address.Text != "" &&
           ลบช.Text != "" &&
           email.Text != "" &&
           sdate.Text != "" &&
           bdate.Text != "" &&
           salary.Text != "" &&
           แผนก.Text != "" &&
           branch.Text != "" &&
           ตำแหน่ง.Text != "" &&
           username.Text != "" &&
           password.Text != "" &&
           Tel.Text != "")
            {
                if (ปปช.TextLength == 13)
                {
                    con.Close();
                    try {
                        cmd = new MySqlCommand("INSERT INTO employee  VALUES ('" + id_text.Text + "','" + fname.Text + "','" + lname.Text + "','" + ปปช.Text + "','" + ลบช.Text + "','" + address.Text + "','" + ศึกษา.Text + "','" + Tel.Text + "','" + email.Text + "','" + sdate.Text + "','" + bdate.Text + "','" + salary.Text + "','" + แผนก.Text + "','" + branch.Text + "','" + ตำแหน่ง.Text + "')", con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        cmd = new MySqlCommand(" SELECT * FROM employee WHERE EMP_FNAME ='" + fname.Text + "' AND EMP_LNAME = '" + lname.Text + "'", con);
                        con.Open();
                        read = cmd.ExecuteReader();
                        read.Read();
                        String ids = read.GetString("Employee_ID");
                        read.Close();
                        con.Close();
                        cmd = new MySqlCommand("INSERT INTO login  (username,password,level,Employee_ID) VALUES ('" + username.Text + "','" + password.Text + "','" + ตำแหน่ง.Text + "','" + ids + "' )", con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        update("employee", dataGridView1, "SELECT * FROM employee NATURAL JOIN login ");
                        combobox("employee", "Employee_ID", combo_id);

                        combobox("employee", "Employee_ID", com2_search);
                        combobox("employee", "Employee_ID", emp_combo_2);

                        combobox("employee", "Employee_ID", combo_id_3_search);
                        combobox("employee", "Employee_ID", combo_id_3);

                        combobox("employee", "Employee_ID", combo_id_4_search);
                        combobox("employee", "Employee_ID", com_empid_4);

                        combobox("employee", "Employee_ID", combo_id_5_search);
                        combobox("employee", "Employee_ID", comid_5);

                        combobox("employee", "Employee_ID", combo_idemp_6);
                        combobox("employee", "Employee_ID", comid_6);

                        clear_text();
                    }
                    catch(Exception E)
                    {
                        MessageBox.Show(E.ToString(), "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }




                }
                else
                {
                    MessageBox.Show("หมายเลขบัตรประชาชนต้องมี 13 หลัก ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                id_text.Text != "" &&
                fname.Text != "" &&
           lname.Text != "" &&
           ปปช.Text != "" &&
           address.Text != "" &&
           ลบช.Text != "" &&
           email.Text != "" &&
           sdate.Text != "" &&
           bdate.Text != "" &&
           salary.Text != "" &&
           แผนก.Text != "" &&
           branch.Text != "" &&
           ตำแหน่ง.Text != "" &&
           username.Text != "" &&
           password.Text != "" &&
           Tel.Text != "")
            {
                DialogResult dialog = MessageBox.Show("Confrim", "UPDATE", MessageBoxButtons.YesNo);
                if (dialog == DialogResult.Yes)
                {
                    cmd = new MySqlCommand("UPDATE employee SET Employee_ID='" + id_text.Text + "',EMP_FNAME='" + fname.Text + "',EMP_LNAME='" + lname.Text + "',Publiccode='" + ปปช.Text + "',Accountnumber='" + ลบช.Text + "',Address='" + address.Text + "',HisEducation='" + ศึกษา.Text + "',Tel='" + Tel.Text + "',Email='" + email.Text + "',DateStart='" + sdate.Text + "',Brithday='" + bdate.Text + "',Salary='" + salary.Text + "',Department_ID='" + แผนก.Text + "',Branch_ID='" + branch.Text + "',Position_ID='" + ตำแหน่ง.Text + "' WHERE Employee_ID = '" + combo_id.Text + "'", con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();

                    cmd = new MySqlCommand("UPDATE login SET username = '" + username.Text + "', password = '" + password.Text + "'  WHERE Employee_ID = '" + combo_id.Text + "' ", con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();





                    update("employee", dataGridView1, "SELECT * FROM employee NATURAL JOIN login ");
                    clear_text();
                    edit.Enabled = false;
                    add.Enabled = true;
                    delete.Enabled = false;
                    combobox("employee", "Employee_ID", combo_id);
                }



            }
            else
            {
                MessageBox.Show("กรุณากรอกข้อมูลให้ครบ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void delete_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Confrim", "DELETE", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                cmd = new MySqlCommand("DELETE FROM product WHERE Product_ID = '" + id_text.Text + "'", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                update("employee", dataGridView1, "SELECT * FROM employee NATURAL JOIN login ");
                clear_text();
                add.Enabled = true;
                delete.Enabled = false;
                edit.Enabled = false;
                combobox("employee", "Employee_ID", combo_id);
            }
        }

        private void search_2_Click(object sender, EventArgs e)
        {
            if (com2_search.Text.Equals("") && rectimework_combo_id2.Text.Equals(""))
            {
                //  MessageBox.Show("หา all", "ไม่พบ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                update("recworktime", dataGridView2, "SELECT * FROM recworktime ");
                clear_text();
                add_2.Enabled = true;
                edit_2.Enabled = false;
                delete_2.Enabled = false;
            }
            else if (com2_search.Text.Equals(""))
            {
                // MessageBox.Show("หา ไอดีลา", "ไม่พบ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmd = new MySqlCommand("SELECT * FROM recworktime WHERE recWorkTime_ID = '" + rectimework_combo_id2.Text + "'", con);
                con.Open();
                read = cmd.ExecuteReader();
                if (read.Read())
                {
                    delete_2.Enabled = true;
                    edit_2.Enabled = true;
                    add_2.Enabled = false;
                    emp_combo_2.Text = read.GetString("Employee_ID");
                    date_2.Text = read.GetString("Date");
                    time_in.Text = read.GetString("TimeIn");
                    time_out.Text = read.GetString("TimeOut");
                    type_work.Text = read.GetString("TypeWork_Name");
                    datagrid("SELECT * FROM recworktime WHERE recWorkTime_ID='" + rectimework_combo_id2.Text + "' ", dataGridView2);
                    textid_2.Text = rectimework_combo_id2.Text;
                    con.Close();
                }
                else
                {
                    MessageBox.Show("ไม่พบรหัสบันทึกเวลาทำงาน", "ไม่พบ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    clear_text();
                    update("recworktime", dataGridView2, "SELECT * FROM recworktime ");
                }


            }
            else if (rectimework_combo_id2.Text.Equals(""))
            {
                //  MessageBox.Show("หาไอดีพนักงาน", "ไม่พบ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                datagrid("SELECT * FROM recworktime WHERE Employee_ID = '" + com2_search.Text + "'", dataGridView2);
                clear_text();
                add_2.Enabled = true;
                edit_2.Enabled = false;
                delete_2.Enabled = false;

            }
            else
            {
                cmd = new MySqlCommand("SELECT * FROM recworktime WHERE recWorkTime_ID = '" + rectimework_combo_id2.Text + "' AND Employee_ID = '" + com2_search.Text + "'", con);
                con.Open();
                read = cmd.ExecuteReader();
                if (read.Read())
                {
                    delete_2.Enabled = true;
                    edit_2.Enabled = true;
                    add_2.Enabled = false; emp_combo_2.Text = read.GetString("Employee_ID");
                    date_2.Text = read.GetString("Date");
                    time_in.Text = read.GetString("TimeIn");
                    time_out.Text = read.GetString("TimeOut");
                    type_work.Text = read.GetString("TypeWork_Name");
                    datagrid("SELECT * FROM recworktime WHERE recWorkTime_ID='" + rectimework_combo_id2.Text + "' ", dataGridView2);
                    textid_2.Text = rectimework_combo_id2.Text;

                    con.Close();
                }
                else
                {
                    MessageBox.Show("ไม่พบรหัสบันทึกเวลาทำงาน", "ไม่พบ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    clear_text();
                    update("recworktime", dataGridView2, "SELECT * FROM recworktime ");


                }
                con.Close();
                //*******************----------------------------------------***********************************
                /* if (rectimework_combo_id2.Text.Equals(""))
                 {

                     update("recworktime", dataGridView2, "SELECT * FROM recworktime ");
                     clear_text();
                     add_2.Enabled = true;
                     edit_2.Enabled = false;
                     delete_2.Enabled = false;
                 }
                 else
                 {
                     cmd = new MySqlCommand("SELECT * FROM employee NATURAL JOIN recworktime WHERE recWorkTime_ID = '" + rectimework_combo_id2.Text + "'", con);
                     con.Open();
                     read = cmd.ExecuteReader();
                     if (read.Read())
                     {

                         delete_2.Enabled = true;
                         edit_2.Enabled = true;
                         add_2.Enabled = false;
                         emp_combo_2.Text = read.GetString("Employee_ID");
                         date_2.Text = read.GetString("Date");
                         time_in.Text = read.GetString("TimeIn");
                         time_out.Text = read.GetString("TimeOut");
                         type_work.Text = read.GetString("TypeWork_Name");
                         datagrid("SELECT * FROM recworktime WHERE recWorkTime_ID='" + rectimework_combo_id2.Text + "' ", dataGridView2);
                         con.Close();
                     }
                     else
                     {
                         MessageBox.Show("ไม่พบรหัสบันทึกเวลาทำงานนี้", "ไม่พบ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                         clear_text();
                     }

                 }
                 con.Close();
                 */
            }
        }

        private void add_2_Click(object sender, EventArgs e)
        {
         
            if (
          emp_combo_2.Text != "" &&
          date_2.Text != "" &&
          time_in.Text != "" &&
          time_out.Text != "" &&
          type_work.Text != ""
           )
            {
                DateTime d1 = Convert.ToDateTime(time_in.Text);
                DateTime d2 = Convert.ToDateTime(time_out.Text);
                TimeSpan dt = d2 - d1;

                
                double sumtime = (Double.Parse(dt.TotalMinutes.ToString()) / 60);

               // MessageBox.Show(sumtime+"");
            

                con.Close();
                cmd = new MySqlCommand("INSERT INTO recworktime  VALUES ('" + rectimework_combo_id2.Text + "','" + time_in.Text + "','" + time_out.Text + "','" + date_2.Text + "','" + type_work.Text + "',"+sumtime+",'" + emp_combo_2.Text + "')", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                update("recworktime", dataGridView2, "SELECT * FROM recworktime ");
                combobox("recworktime", "recWorkTime_ID", rectimework_combo_id2);
                clear_text();
            }
            else
            {
                MessageBox.Show("กรุณากรอบข้อมูลให้ครบ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void delete_2_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Confrim", "DELETE", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                cmd = new MySqlCommand("DELETE FROM recworktime WHERE recWorkTime_ID = '" + rectimework_combo_id2.Text + "'", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                update("recworktime", dataGridView2, "SELECT * FROM recworktime ");
                clear_text();
                add_2.Enabled = true;
                delete_2.Enabled = false;
                edit_2.Enabled = false;
                combobox("recworktime", "recWorkTime_ID", rectimework_combo_id2);
            }
        }

        private void edit_2_Click(object sender, EventArgs e)
        {
            DateTime d1 = Convert.ToDateTime(time_in.Text);
            DateTime d2 = Convert.ToDateTime(time_out.Text);
            TimeSpan dt = d2 - d1;


            double sumtime = (Double.Parse(dt.TotalMinutes.ToString()) / 60);
            if (emp_combo_2.Text != "" &&
          date_2.Text != "" &&
          time_in.Text != "" &&
          time_out.Text != "" &&
          type_work.Text != "")
            {
                DialogResult dialog = MessageBox.Show("Confrim", "UPDATE", MessageBoxButtons.YesNo);
                if (dialog == DialogResult.Yes)
                {
                    cmd = new MySqlCommand("UPDATE recworktime SET TimeIn='" + time_in.Text + "' , TimeOut = '" + time_out.Text + "' , Date= '" + date_2.Text + "' ,TypeWork_Name= '" + type_work.Text + "' , Employee_ID='" + emp_combo_2.Text + "', sumtime = '"+sumtime+"'  WHERE recWorkTime_ID = '" + textid_2.Text + "'", con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    update("recworktime", dataGridView2, "SELECT * FROM recworktime ");
                    clear_text();
                    edit_2.Enabled = false;
                    add_2.Enabled = true;
                    delete_2.Enabled = false;
                    combobox("recworktime", "recWorkTime_ID", rectimework_combo_id2);
                }



            }
            else
            {
                MessageBox.Show("กรุณากรอกข้อมูลให้ครบ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void search_date2_Click(object sender, EventArgs e)
        {
            update("recworktime", dataGridView2, "SELECT * FROM recworktime WHERE Date >= '" + ก่อน.Text + "' AND Date <= '" + หลัง.Text + "' ");
            clear_text();
            add_2.Enabled = true;
            edit_2.Enabled = false;
        }

        private void search_date_1_Click(object sender, EventArgs e)
        {
            update("employee", dataGridView1, "SELECT * FROM employee WHERE DateStart >= '" + ก่อน1.Text + "' AND DateStart <= '" + หลัง1.Text + "' ");
            clear_text();
            add.Enabled = true;
            edit.Enabled = false;
        }

        private void delete_3_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Confrim", "DELETE", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                cmd = new MySqlCommand("DELETE FROM workoff WHERE workoff_id = '" + IDtext_3.Text + "'", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                update("workoff", dataGridView3, "SELECT * FROM workoff WHERE Date >= '" + ก่อน3.Text + "' AND Date <= '" + หลัง3.Text + "' ");
                clear_text();
                add_3.Enabled = true;
                delete_3.Enabled = false;
                edit_3.Enabled = false;
                combobox("workoff", "workoff_id", com_workoff_3_search);
            }
        }

        private void search_date_3_Click(object sender, EventArgs e)
        {
            update("workoff", dataGridView3, "SELECT * FROM workoff WHERE Date >= '" + ก่อน3.Text + "' AND Date <= '" + หลัง3.Text + "' ");
            clear_text();
            add_3.Enabled = true;
            edit_3.Enabled = false;
            delete_3.Enabled = false;
        }

        private void add_3_Click(object sender, EventArgs e)
        {

            if (
          combo_id_3.Text != "" &&
          type_3.Text != "" &&
          day_3.Text != "" &&
          because_3.Text != "" &&
          date_text_3.Text != ""
           )
            {
                cmd = new MySqlCommand("INSERT INTO workoff  VALUES ('" + IDtext_3.Text + "','" + date_text_3.Text + "','" + because_3.Text + "','" + type_3.Text + "','" + combo_id_3.Text + "','" + day_3.Text + "')", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                update("workoff", dataGridView3, "SELECT * FROM workoff ");
                combobox("employee", "Employee_ID", combo_id_3_search);
                combobox("workoff", "workoff_id", com_workoff_3_search);

                clear_text();
            }
            else
            {
                MessageBox.Show("กรุณากรอบข้อมูลให้ครบ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


        }

        private void edit_3_Click(object sender, EventArgs e)
        {

            if (combo_id_3.Text != "" &&
          date_text_3.Text != "" &&
          type_3.Text != "" &&
          day_3.Text != "" &&
          because_3.Text != "")
            {
                DialogResult dialog = MessageBox.Show("Confrim", "UPDATE", MessageBoxButtons.YesNo);
                if (dialog == DialogResult.Yes)
                {
                    cmd = new MySqlCommand("UPDATE workoff SET  detail = '" + because_3.Text + "',date= '" + date_text_3.Text + "' ,type_name= '" + type_3.Text + "' , Employee_ID='" + combo_id_3.Text + "', How_many_days='" + day_3.Text + "' WHERE workoff_id = '" + IDtext_3.Text + "'", con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    update("workoff", dataGridView3, "SELECT * FROM workoff ");
                    clear_text();
                    edit_3.Enabled = false;
                    add_3.Enabled = true;
                    delete_3.Enabled = false;

                }

            }
            else
            {
                MessageBox.Show("กรุณากรอกข้อมูลให้ครบ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void search_3_Click(object sender, EventArgs e)
        {


            if (combo_id_3_search.Text.Equals("") && com_workoff_3_search.Text.Equals(""))
            {
                //  MessageBox.Show("หา all", "ไม่พบ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                update("workoff", dataGridView3, "SELECT * FROM workoff ");
                clear_text();
                add_3.Enabled = true;
                edit_3.Enabled = false;
                delete_3.Enabled = false;
            }
            else if (combo_id_3_search.Text.Equals(""))
            {
                // MessageBox.Show("หา ไอดีลา", "ไม่พบ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmd = new MySqlCommand("SELECT * FROM workoff WHERE WorkOff_ID = '" + com_workoff_3_search.Text + "'", con);
                con.Open();
                read = cmd.ExecuteReader();
                if (read.Read())
                {
                    delete_3.Enabled = true;
                    edit_3.Enabled = true;
                    add_3.Enabled = false;
                    combo_id_3.Text = read.GetString("Employee_ID");
                    date_text_3.Text = read.GetString("Date");
                    type_3.Text = read.GetString("type_name");
                    day_3.Text = read.GetString("How_many_days");
                    because_3.Text = read.GetString("Detail");
                    datagrid("SELECT * FROM workoff  WHERE WorkOff_ID = '" + com_workoff_3_search.Text + "'", dataGridView3);
                    IDtext_3.Text = com_workoff_3_search.Text;
                    con.Close();
                }
                else
                {
                    MessageBox.Show("ไม่พบรหัสบันทึกการลานี้", "ไม่พบ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    clear_text();
                    update("workoff", dataGridView3, "SELECT * FROM workoff ");
                }


            }
            else if (com_workoff_3_search.Text.Equals(""))
            {
                //  MessageBox.Show("หาไอดีพนักงาน", "ไม่พบ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                datagrid("SELECT * FROM workoff WHERE Employee_ID = '" + combo_id_3_search.Text + "'", dataGridView3);
                clear_text();
                add_3.Enabled = true;
                edit_3.Enabled = false;
                delete_3.Enabled = false;

            }
            else
            {
                cmd = new MySqlCommand("SELECT * FROM workoff WHERE WorkOff_ID = '" + com_workoff_3_search.Text + "' AND Employee_ID = '" + combo_id_3_search.Text + "'", con);
                con.Open();
                read = cmd.ExecuteReader();
                if (read.Read())
                {
                    delete_3.Enabled = true;
                    edit_3.Enabled = true;
                    add_3.Enabled = false;
                    combo_id_3.Text = read.GetString("Employee_ID");
                    date_text_3.Text = read.GetString("Date");
                    type_3.Text = read.GetString("type_name");
                    day_3.Text = read.GetString("How_many_days");
                    because_3.Text = read.GetString("Detail");
                    datagrid("SELECT * FROM workoff  WHERE WorkOff_ID = '" + com_workoff_3_search.Text + "'  AND Employee_ID = '" + combo_id_3_search.Text + "'", dataGridView3);
                    IDtext_3.Text = com_workoff_3_search.Text;
                    con.Close();
                }
                else
                {
                    MessageBox.Show("ไม่พบรหัสบันทึกการลานี้", "ไม่พบ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    clear_text();
                    update("workoff", dataGridView3, "SELECT * FROM workoff ");
                }

            }
            con.Close();



        }

        private void combo_id_3_search_TextChanged(object sender, EventArgs e)
        {
            if (!combo_id_3_search.Text.Equals(""))
            {
                com_workoff_3_search.Items.Clear();
                cmd = new MySqlCommand("SELECT * FROM workoff WHERE Employee_ID = '" + combo_id_3_search.Text + "'", con);
                con.Open();
                read = cmd.ExecuteReader();

                while (read.Read())
                {
                    com_workoff_3_search.Items.Add(read.GetString("workoff_id"));
                }
                con.Close();
            }
            else
            {
                combobox("workoff", "workoff_id", com_workoff_3_search);
            }


        }

        private void หาทั้งหมด_3_Click(object sender, EventArgs e)
        {
            update("workoff", dataGridView3, "SELECT * FROM workoff ");
            clear_text();
            add_3.Enabled = true;
            edit_3.Enabled = false;
            delete_3.Enabled = false;
        }

        private void หาทั้งหมด_2_Click(object sender, EventArgs e)
        {

            update("recworktime", dataGridView2, "SELECT * FROM recworktime ");
            clear_text();
            add_2.Enabled = true;
            edit_2.Enabled = false;
            delete_2.Enabled = false;
        }

        private void com2_search_TextChanged(object sender, EventArgs e)
        {
            if (!com2_search.Text.Equals(""))
            {
                rectimework_combo_id2.Items.Clear();
                cmd = new MySqlCommand("SELECT * FROM recworktime WHERE Employee_ID = '" + com2_search.Text + "'", con);
                con.Open();
                read = cmd.ExecuteReader();

                while (read.Read())
                {
                    rectimework_combo_id2.Items.Add(read.GetString("recWorkTime_ID"));
                }
                con.Close();
            }
            else
            {
                combobox("recworktime", "recWorkTime_ID", rectimework_combo_id2);
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            update("recfineemp", dataGridView4, "SELECT * FROM recfineemp WHERE Date >= '" + ก่อน4.Text + "' AND Date <= '" + หลัง4.Text + "' ");
            clear_text();
            add_3.Enabled = true;
            edit_3.Enabled = false;
            delete_3.Enabled = false;
        }

        private void search_4_Click(object sender, EventArgs e)
        {


            if (combo_id_4_search.Text.Equals("") && com_recfineempId_search.Text.Equals(""))
            {
                //  MessageBox.Show("หา all", "ไม่พบ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                update("recfineemp", dataGridView4, "SELECT * FROM recfineemp ");
                clear_text();
                add_3.Enabled = true;
                edit_3.Enabled = false;
                delete_3.Enabled = false;
            }
            else if (combo_id_4_search.Text.Equals(""))
            {
                // MessageBox.Show("หา ไอดีลา", "ไม่พบ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmd = new MySqlCommand("SELECT * FROM recfineemp WHERE recFineEmp_ID = '" + com_recfineempId_search.Text + "'", con);
                con.Open();
                read = cmd.ExecuteReader();
                if (read.Read())
                {
                    delete_4.Enabled = true;
                    edit_4.Enabled = true;
                    add_4.Enabled = false;

                    com_empid_4.Text = read.GetString("Employee_ID");
                    date4.Text = read.GetString("Date");
                    idค่าปรับtext.Text = read.GetString("recFineEmp_ID");
                    Detail_4.Text = read.GetString("Detail");
                    Amount_4.Text = read.GetString("Amount");
                    datagrid("SELECT * FROM recfineemp  WHERE recFineEmp_ID = '" + com_recfineempId_search.Text + "'", dataGridView4);

                    con.Close();
                }
                else
                {
                    MessageBox.Show("ไม่พบรหัสบันทึกการปรับนี้", "ไม่พบ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    clear_text();
                    update("workoff", dataGridView3, "SELECT * FROM workoff ");
                }


            }
            else if (com_recfineempId_search.Text.Equals(""))
            {
                //  MessageBox.Show("หาไอดีพนักงาน", "ไม่พบ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                datagrid("SELECT * FROM recfineemp WHERE Employee_ID = '" + combo_id_4_search.Text + "'", dataGridView4);
                clear_text();
                add_4.Enabled = true;
                edit_4.Enabled = false;
                delete_4.Enabled = false;

            }
            else
            {
                cmd = new MySqlCommand("SELECT * FROM recfineemp WHERE recFineEmp_ID = '" + com_recfineempId_search.Text + "' AND Employee_ID = '" + combo_id_4_search.Text + "'", con);
                con.Open();
                read = cmd.ExecuteReader();
                if (read.Read())
                {
                    delete_4.Enabled = true;
                    edit_4.Enabled = true;
                    add_4.Enabled = false;

                    com_empid_4.Text = read.GetString("Employee_ID");
                    date4.Text = read.GetString("Date");
                    idค่าปรับtext.Text = read.GetString("recFineEmp_ID");
                    Amount_4.Text = read.GetString("Amount");
                    Detail_4.Text = read.GetString("Detail");
                    datagrid("SELECT * FROM recfineemp  WHERE recFineEmp_ID = '" + com_recfineempId_search.Text + "'  AND Employee_ID = '" + combo_id_4_search.Text + "'", dataGridView4);

                    con.Close();
                }
                else
                {
                    MessageBox.Show("ไม่พบรหัสค่าปรับนี้", "ไม่พบ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    clear_text();
                    update("recfineemp", dataGridView4, "SELECT * FROM recfineemp ");
                }

            }
            con.Close();


        }

        private void หาทั้งหมด_4_Click(object sender, EventArgs e)
        {
            update("recfineemp", dataGridView4, "SELECT * FROM recfineemp ");
            clear_text();
            add_4.Enabled = true;
            edit_4.Enabled = false;
            delete_4.Enabled = false;
        }

        private void combo_id_4_search_TextChanged(object sender, EventArgs e)
        {
            if (!combo_id_4_search.Text.Equals(""))
            {
                com_recfineempId_search.Items.Clear();
                cmd = new MySqlCommand("SELECT * FROM recfineemp WHERE Employee_ID = '" + combo_id_4_search.Text + "'", con);
                con.Open();
                read = cmd.ExecuteReader();

                while (read.Read())
                {
                    com_recfineempId_search.Items.Add(read.GetString("recFineEmp_ID"));
                }
                con.Close();
            }
            else
            {
                combobox("recfineemp", "recFineEmp_ID", com_recfineempId_search);
            }

        }

        private void add_4_Click(object sender, EventArgs e)
        {

            if (
          com_empid_4.Text != "" &&
          Amount_4.Text != "" &&
          date4.Text != "" &&
          Detail_4.Text != ""
           )
            {
                cmd = new MySqlCommand("INSERT INTO recfineemp  VALUES ('" + idค่าปรับtext.Text + "','" + date4.Text + "','" + Detail_4.Text + "','" + Amount_4.Text + "','" + com_empid_4.Text + "')", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                // update("recfineemp", dataGridView3, "SELECT * FROM recfineemp ");
                combobox("employee", "Employee_ID", combo_id_4_search);
                combobox("workoff", "workoff_id", com_recfineempId_search);
                update("recfineemp", dataGridView4, "SELECT * FROM recfineemp ");
                clear_text();
            }
            else
            {
                MessageBox.Show("กรุณากรอบข้อมูลให้ครบ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void edit_4_Click(object sender, EventArgs e)
        {

            if (com_empid_4.Text != "" &&
          Amount_4.Text != "" &&
          date4.Text != "" &&
          Detail_4.Text != "")
            {
                DialogResult dialog = MessageBox.Show("Confrim", "UPDATE", MessageBoxButtons.YesNo);
                if (dialog == DialogResult.Yes)
                {
                    cmd = new MySqlCommand("UPDATE recfineemp SET Date= '" + date4.Text + "' ,Detail= '" + Detail_4.Text + "' , Amount='" + Amount_4.Text + "', Employee_ID='" + com_empid_4.Text + "' WHERE recFineEmp_ID = '" + idค่าปรับtext.Text + "'", con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    update("recfineemp", dataGridView4, "SELECT * FROM recfineemp ");
                    clear_text();
                    edit_4.Enabled = false;
                    add_4.Enabled = true;
                    delete_4.Enabled = false;

                }

            }
            else
            {
                MessageBox.Show("กรุณากรอกข้อมูลให้ครบ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void delete_4_Click(object sender, EventArgs e)
        {

            DialogResult dialog = MessageBox.Show("Confrim", "DELETE", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                cmd = new MySqlCommand("DELETE FROM recfineemp WHERE recFineEmp_ID = '" + idค่าปรับtext.Text + "'", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                update("recfineemp", dataGridView4, "SELECT * FROM recfineemp ");
                clear_text();
                add_4.Enabled = true;
                delete_4.Enabled = false;
                edit_4.Enabled = false;
                combobox("recfineemp", "recFineEmp_ID", com_recfineempId_search);
            }
        }

        private void search_date_5_Click(object sender, EventArgs e)
        {
            update("recmovestore", dataGridView5, "SELECT * FROM recmovestore WHERE Date >= '" + ก่อน5.Text + "' AND Date <= '" + หลัง5.Text + "' ");
            clear_text();
            add_5.Enabled = true;
            edit_5.Enabled = false;
            del_5.Enabled = false;
        }

        private void add_5_Click(object sender, EventArgs e)
        {


            if (
          comid_5.Text != "" &&
          dateTimePicker5.Text != "" &&
          case_5.Text != "" &&
         
          branch_2_5.Text != "" &&
          departid_5.Text != "" &&
          posi_5.Text != ""
           )
            {
                cmd = new MySqlCommand("SELECT * FROM employee WHERE Employee_ID= '" + comid_5.Text + "' ", con);
                con.Open();
                read = cmd.ExecuteReader();
                read.Read();
                String a = read.GetString("Branch_ID");
                con.Close();



                if (!a.Equals(branch_2_5.Text))
                {

                    cmd = new MySqlCommand("INSERT INTO recmovestore  VALUES ('" + idtext_5.Text + "','" + dateTimePicker5.Text + "','" + case_5.Text + "','" + a + "','" + branch_2_5.Text + "' ,'" + departid_5.Text + "' ,'" + posi_5.Text + "', '" + comid_5.Text + "' )", con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    update("recmovestore", dataGridView5, "SELECT * FROM recmovestore ");


                    combobox("employee", "Employee_ID", combo_id_5_search);
                    //combobox("workoff", "workoff_id", com__search);
                    combobox("recmovestore", "recMoveStore_ID", com__search);

                    cmd = new MySqlCommand("UPDATE employee SET Branch_ID= '" + branch_2_5.Text + "' WHERE Employee_ID = '" + comid_5.Text + "'", con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    update("employee", dataGridView1, "SELECT * FROM employee NATURAL JOIN login ");

                    clear_text();
                }
                else
                {
                    MessageBox.Show("ไม่สามารถย้ายไปยังสาขาเดิมได้", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("กรุณากรอบข้อมูลให้ครบ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


        }

        private void หาทั้งหมด_5_Click(object sender, EventArgs e)
        {
            update("recmovestore", dataGridView5, "SELECT * FROM recmovestore ");
            clear_text();
            add_5.Enabled = true;
            edit_5.Enabled = false;
            del_5.Enabled = false;
        }

        private void search_5_Click(object sender, EventArgs e)
        {


            if (combo_id_5_search.Text.Equals("") && com__search.Text.Equals(""))
            {
                //  MessageBox.Show("หา all", "ไม่พบ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                update("recmovestore", dataGridView5, "SELECT * FROM recmovestore ");
                clear_text();
                add_5.Enabled = true;
                edit_5.Enabled = false;
                del_5.Enabled = false;
            }
            else if (combo_id_5_search.Text.Equals(""))
            {
                // MessageBox.Show("หา ไอดีลา", "ไม่พบ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmd = new MySqlCommand("SELECT * FROM recmovestore WHERE recMoveStore_ID = '" + com__search.Text + "'", con);
                con.Open();
                read = cmd.ExecuteReader();
                if (read.Read())
                {
                    del_5.Enabled = true;
                    edit_5.Enabled = true;
                    add_5.Enabled = false;

                    comid_5.Text = read.GetString("Employee_ID");
                    dateTimePicker5.Text = read.GetString("Date");
                    idtext_5.Text = read.GetString("recMoveStore_ID");
                    case_5.Text = read.GetString("Cause");

                   
                    branch_2_5.Text = read.GetString("BranchRe_ID");
                    departid_5.Text = read.GetString("Department_Name");
                    posi_5.Text = read.GetString("Position_Name");


                    datagrid("SELECT * FROM recmovestore  WHERE recMoveStore_ID = '" + com__search.Text + "'", dataGridView5);

                    con.Close();
                }
                else
                {
                    MessageBox.Show("ไม่พบรหัสบันทึกการย้ายสาขานี้", "ไม่พบ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    clear_text();
                    update("recmovestore", dataGridView5, "SELECT * FROM recmovestore ");

                }


            }
            else if (com__search.Text.Equals(""))
            {
                //  MessageBox.Show("หาไอดีพนักงาน", "ไม่พบ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                datagrid("SELECT * FROM recmovestore WHERE Employee_ID = '" + combo_id_5_search.Text + "'", dataGridView5);
                clear_text();
                add_5.Enabled = true;
                edit_5.Enabled = false;
                del_5.Enabled = false;

            }
            else
            {
                cmd = new MySqlCommand("SELECT * FROM recmovestore WHERE recMoveStore_ID = '" + com__search.Text + "' AND Employee_ID = '" + combo_id_5_search.Text + "'", con);
                con.Open();
                read = cmd.ExecuteReader();
                if (read.Read())
                {
                    del_5.Enabled = true;
                    edit_5.Enabled = true;
                    add_5.Enabled = false;

                    comid_5.Text = read.GetString("Employee_ID");
                    dateTimePicker5.Text = read.GetString("Date");
                    idtext_5.Text = read.GetString("recMoveStore_ID");
                    case_5.Text = read.GetString("Cause");

                    String b = read.GetString("BranchMove_ID");
                    branch_2_5.Text = read.GetString("BranchRe_ID");
                    departid_5.Text = read.GetString("Department_Name");
                    posi_5.Text = read.GetString("Position_Name");


                    datagrid("SELECT * FROM recmovestore  WHERE recMoveStore_ID = '" + com__search.Text + "'  AND Employee_ID = '" + combo_id_5_search.Text + "'", dataGridView5);

                    con.Close();
                }
                else
                {
                    MessageBox.Show("ไม่พบรหัสบันทึกการย้ายนี้", "ไม่พบ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    clear_text();
                    update("recmovestore", dataGridView5, "SELECT * FROM recmovestore ");

                }

            }
            con.Close();

        }

        private void del_5_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Confrim", "DELETE", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                cmd = new MySqlCommand("DELETE FROM recmovestore WHERE recMoveStore_ID = '" + idtext_5.Text + "'", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                update("recmovestore", dataGridView5, "SELECT * FROM recmovestore ");
                clear_text();
                add_5.Enabled = true;
                del_5.Enabled = false;
                edit_5.Enabled = false;
                combobox("recmovestore", "recMoveStore_ID", com__search);
            }
        }

        private void edit_5_Click(object sender, EventArgs e)
        {

            if (
          comid_5.Text != "" &&
          dateTimePicker5.Text != "" &&
          case_5.Text != "" &&
         
          branch_2_5.Text != "" &&
          departid_5.Text != "" &&
          posi_5.Text != "")
            {

                cmd = new MySqlCommand("SELECT * FROM employee WHERE Employee_ID= '" + comid_5.Text + "' ", con);
                con.Open();
                read = cmd.ExecuteReader();
                read.Read();


                String a = read.GetString("Branch_ID");

                con.Close();
                


                if (!a.Equals(branch_2_5.Text))
                {
                    DialogResult dialog = MessageBox.Show("Confrim", "UPDATE", MessageBoxButtons.YesNo);
                    if (dialog == DialogResult.Yes)
                    {
                        cmd = new MySqlCommand("UPDATE recmovestore SET recMoveStore_ID= '" + idtext_5.Text + "' ,Date= '" + dateTimePicker5.Text + "' , Cause='" + case_5.Text + "', BranchMove_ID='" + a + "' , BranchRe_ID = '" + branch_2_5.Text + "', Department_Name = '" + departid_5.Text + "' , Position_Name = '" + posi_5.Text + "' , Employee_ID = '" + comid_5.Text + "' WHERE recMoveStore_ID = '" + idtext_5.Text + "'", con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        update("recmovestore", dataGridView5, "SELECT * FROM recmovestore ");
                        clear_text();
                        edit_5.Enabled = false;
                        add_5.Enabled = true;
                        del_5.Enabled = false;

                        cmd = new MySqlCommand("UPDATE employee SET Branch_ID= '" + branch_2_5.Text + "' WHERE Employee_ID = '" + comid_5.Text + "'", con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();

                        update("employee", dataGridView1, "SELECT * FROM employee NATURAL JOIN login ");

                    }
                }
                else
                {
                    MessageBox.Show("ไม่สามารถย้ายไปยังสาขาเดิมได้", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
              

            }
            else
            {
                MessageBox.Show("กรุณากรอกข้อมูลให้ครบ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


        }

        private void combo_id_5_search_TextChanged(object sender, EventArgs e)
        {
            if (!combo_id_5_search.Text.Equals(""))
            {
                com__search.Items.Clear();
                cmd = new MySqlCommand("SELECT * FROM recmovestore WHERE Employee_ID = '" + combo_id_5_search.Text + "'", con);
                con.Open();
                read = cmd.ExecuteReader();

                while (read.Read())
                {
                    com__search.Items.Add(read.GetString("recMoveStore_ID"));
                }
                con.Close();
            }
            else
            {
                combobox("recmovestore", "recMoveStore_ID", com__search);


            }
        }

        private void search_6_Click(object sender, EventArgs e)
        {

            
            if (combo_idemp_6.Text.Equals("") && combo_id_6.Text.Equals(""))
            {
                //  MessageBox.Show("หา all", "ไม่พบ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                update("recsalary", dataGridView6, "SELECT * FROM recsalary  ");
                clear_text();
                add6.Enabled = false;
                edit6.Enabled = false;
                del6.Enabled = false;
            }
            else if (combo_idemp_6.Text.Equals(""))
            {
                
             //    MessageBox.Show("หา ไอดีลา", "ไม่พบ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmd = new MySqlCommand("SELECT * FROM recsalary WHERE recSalary_ID = '" + combo_id_6.Text + "'", con);
                con.Open();
                read = cmd.ExecuteReader();
                if (read.Read())
                {
                    del6.Enabled = true;
                    add6.Enabled = false;
                    edit6.Enabled = false;

                    comid_6.Text = read.GetString("Employee_ID");
                    Amount_6.Text = read.GetString("Amount");
                    Paymentperiod6.Text = read.GetString("Period");
                    idtext6.Text = read.GetString("recSalary_ID");
                    paydate_6.Text = read.GetString("Date");


                    datagrid("SELECT * FROM recsalary  WHERE recSalary_ID = '" + combo_id_6.Text + "'", dataGridView6);

                    con.Close();
                }
                else
                {
                    MessageBox.Show("ไม่พบรหัสบันทึกเงินเดือนนี้", "ไม่พบ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    clear_text();
                    update("recsalary", dataGridView6, "SELECT * FROM recsalary  ");
                }


            }
            else if (combo_id_6.Text.Equals(""))
            {
                  //MessageBox.Show("หาไอดีพนักงาน", "ไม่พบ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                datagrid("SELECT * FROM recsalary WHERE Employee_ID = '" + combo_idemp_6.Text + "'", dataGridView6);
                clear_text();
                add6.Enabled = false;
                del6.Enabled = false;
                edit6.Enabled = false;

            }
            else
            {
                cmd = new MySqlCommand("SELECT * FROM recsalary WHERE recSalary_ID = '" + combo_id_6.Text + "' AND Employee_ID = '" + combo_idemp_6.Text + "'", con);
                con.Open();
                read = cmd.ExecuteReader();
                if (read.Read())
                {
                    del6.Enabled = true;
                    add6.Enabled = false;
                    edit6.Enabled = false ;
                    comid_6.Text = read.GetString("Employee_ID");
                    Amount_6.Text = read.GetString("Amount");
                    Paymentperiod6.Text = read.GetString("Period");
                    idtext6.Text = read.GetString("recSalary_ID");
                    paydate_6.Text = read.GetString("Date");


                    datagrid("SELECT * FROM recsalary  WHERE recSalary_ID = '" + combo_id_6.Text + "'", dataGridView6);

                    con.Close();
                }
                else
                {
                    MessageBox.Show("ไม่พบรหัสบันทึกเงินเดือนนี้", "ไม่พบ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    clear_text();
                    update("recsalary", dataGridView6, "SELECT * FROM recsalary  ");
                }

            }
            con.Close();

        }

        private void searchall_6_Click(object sender, EventArgs e)
        {
            clear_text();
            update("recsalary", dataGridView6, "SELECT * FROM recsalary");
            
            add6.Enabled = false;
            edit6.Enabled = false;
            del6.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            update("recsalary", dataGridView6, "SELECT * FROM recsalary WHERE Date >= '" + ก่อน6.Text + "' AND Date <= '" + หลัง6.Text + "' ");
            clear_text();
            add6.Enabled = false;
            del6.Enabled = false;
            del6.Enabled = false;
        }

        private void add6_Click(object sender, EventArgs e)
        {


            if (
          comid_6.Text != "" &&
          paydate_6.Text != "" &&
          Amount_6.Text != "" ){
                String f = (จ่ายก่อน.Text + " : " + จ่ายหลัง.Text);
                cmd = new MySqlCommand("INSERT INTO recsalary  VALUES ('"+ idtext6.Text + "' , '"+ Amount_6 .Text+ "' ,'"+f+"','"+ paydate_6 .Text+ "', '"+ comid_6 .Text+ "' )", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                update("recsalary", dataGridView6, "SELECT * FROM recsalary  ");


              
                combobox("employee", "Employee_ID", combo_idemp_6);
                combobox("employee", "Employee_ID", comid_6);
                combobox("recsalary", "recSalary_ID", combo_id_6);

                clear_text();
            }
            else
            {
                MessageBox.Show("กรุณากรอบข้อมูลให้ครบ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {

            int sum1 = 0; // เงินเดือนปกติ
            int sum2 = 0; // ค่าปรับ
            int sum3 = 0;// OT


            try
            {
                cmd = new MySqlCommand("SELECT SUM(sumtime) FROM recworktime WHERE Date >= '" + จ่ายก่อน.Text + "' AND Date <= '" + จ่ายหลัง.Text + "' AND Employee_ID= '" + comid_6.Text + "' AND TypeWork_Name = 'ontime'  ", con); 
                con.Open();
                read = cmd.ExecuteReader();

                while (read.Read())
                {
                    sum1 = read.GetInt32("SUM(sumtime)");
                }
                con.Close();

                try
                {

                    cmd = new MySqlCommand("SELECT SUM(sumtime) FROM recworktime WHERE Date >= '" + จ่ายก่อน.Text + "' AND Date <= '" + จ่ายหลัง.Text + "' AND Employee_ID= '" + comid_6.Text + "' AND TypeWork_Name = 'overtime'  ", con);
                    con.Open();
                    read = cmd.ExecuteReader();

                    while (read.Read())
                    {
                        sum3 = read.GetInt32("SUM(sumtime)");
                    }
                    con.Close();
                }
                catch
                {

                }





                //   MessageBox.Show(sum1+"");
                cmd = new MySqlCommand("SELECT Salary FROM employee WHERE Employee_ID= '" + comid_6.Text + "' ", con);
                
                con.Open();
                read = cmd.ExecuteReader();
                read.Read();
                sum1 *= read.GetInt32("Salary");
                sum3 *= read.GetInt32("Salary");
                con.Close();

                try
                {
                    cmd = new MySqlCommand("SELECT SUM(Amount) FROM recfineemp  WHERE Date >= '" + จ่ายก่อน.Text + "' AND Date <= '" + จ่ายหลัง.Text + "' AND Employee_ID= '" + comid_6.Text + "' ", con);
                    con.Open();
                    read = cmd.ExecuteReader();

                    while (read.Read())
                    {
                        sum2 = read.GetInt32("SUM(Amount)");
                    }
                    con.Close();


                }
                catch
                {
                 
                }



                String f = (จ่ายก่อน.Text + " : " + จ่ายหลัง.Text);
                Paymentperiod6.Text = f;

               // MessageBox.Show(sum1+"+"+sum3+"-"+sum2);
                Amount_6.Text = ((sum1+(sum3*2)) - sum2) + "";



            }
            catch
            {
                MessageBox.Show("ไม่พบข้อมูล", "Warning",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                
            }

            if (!idtext6.Text.Equals(""))
            {
                edit6.Enabled = true;
            }
            else
            {
                add6.Enabled = true;
            }
          
        
            con.Close();

        }

        private void combo_idemp_6_TextChanged(object sender, EventArgs e)
        {
            if (!combo_idemp_6.Text.Equals(""))
            {
                combo_id_6.Items.Clear();
                cmd = new MySqlCommand("SELECT * FROM recsalary WHERE Employee_ID = '" + combo_idemp_6.Text + "'", con);
                con.Open();
                read = cmd.ExecuteReader();

                while (read.Read())
                {
                    combo_id_6.Items.Add(read.GetString("recSalary_ID"));
                }
                con.Close();
            }
            else
            {
                
                combobox("recsalary", "recSalary_ID", combo_id_6);


            }
        }

        private void del6_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Confrim", "DELETE", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                cmd = new MySqlCommand("DELETE FROM recsalary WHERE recSalary_ID = '" + idtext6.Text + "'", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                update("recsalary", dataGridView6, "SELECT * FROM recsalary  ");
                clear_text();
                add6.Enabled = true;
                del6.Enabled = false;
                edit6.Enabled = false;
                combobox("recsalary", "recSalary_ID", combo_id_6);
            }
        }

        private void comid_6_TextChanged(object sender, EventArgs e)
        {
            if (comid_6.Text.Equals(""))
            {
                total.Enabled = false;
            }
            else
            {
                total.Enabled = true;
            }
        }

        private void edit6_Click(object sender, EventArgs e)
        {


            if (
          Paymentperiod6.Text != "" &&
          idtext6.Text != "" &&
          comid_6.Text != "" &&
          paydate_6.Text != "" &&
          Amount_6.Text != "" 
         )
            {
                DialogResult dialog = MessageBox.Show("Confrim", "UPDATE", MessageBoxButtons.YesNo);
                if (dialog == DialogResult.Yes)
                {
                    cmd = new MySqlCommand("UPDATE recsalary SET recSalary_ID= '" + idtext6.Text + "' ,Date= '" + paydate_6.Text + "' , Amount='" + Amount_6.Text + "', Period='" + Paymentperiod6.Text + "' , Employee_ID = '" + comid_6.Text + "' WHERE recSalary_ID = '" + idtext6.Text + "'", con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    update("recsalary", dataGridView6, "SELECT * FROM recsalary  ");
                    clear_text();
                    edit6.Enabled = false;
                    add6.Enabled = true;
                    del6.Enabled = false;

                }

            }
            else
            {
                MessageBox.Show("กรุณากรอกข้อมูลให้ครบ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


        }

     
    }
}