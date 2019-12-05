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

namespace Class_Captain
{
    public partial class manage : Form
    {
        public manage()
        {
            InitializeComponent();
        }

        MySqlConnection conn;
        MySqlDataAdapter adapter1;
        DataSet dataSet1;
        private void manage_Load(object sender, EventArgs e)
        {
            string conadd = "server=localhost;port=3306;database=classstudent;uid=root;pwd=0000";
            conn = new MySqlConnection(conadd);
            adapter1 = new MySqlDataAdapter("SELECT * FROM student", conn);  // DataSet과 DB 연결(명령 수행)
            dataSet1 = new DataSet();           // 메모리상의 가상 DataTable 관리
            adapter1.Fill(dataSet1, "student");
            dataGridView1.DataSource = dataSet1.Tables["stduent"];
            try
            {
                // 2. DB Open
                conn.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            dataSet1.Clear();
            adapter1.Fill(dataSet1, "student");
            dataGridView1.DataSource = dataSet1.Tables["student"];
            conn.Close();
        }
        private void sql_str_check(ref int cnt, ref string sql)
        {
            if (cnt == 0)
            {
                sql += " WHERE ";
                cnt++;
            }
            else if (cnt >= 1)
            {
                sql += " AND ";
            }
        }
        private void sql_str_check_up(ref int cnt, ref string sql)
        {
            if (cnt == 0)
            {
                sql += " ";
                cnt++;
            }
            else if (cnt >= 1)
            {
                sql += ", ";
            }
        }

        private void btnselelct_Click(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM student";
            int cnt = 0;
            //////////////////////////////////////////
            ///
            if (num.Text != "")
            {
                sql_str_check(ref cnt, ref sql);
                sql += "num = @num";
            }
            if (name.Text != "")
            {
                sql_str_check(ref cnt, ref sql);
                sql += "name = @name";
            }
            if (gender.Text != "")
            {
                sql_str_check(ref cnt, ref sql);
                sql += "gender = @gender";
            }
            if (phone.Text != "")
            {
                sql_str_check(ref cnt, ref sql);
                sql += "phone = @phone";
            }
            if (birth.Text != "")
            {
                sql_str_check(ref cnt, ref sql);
                sql += "birth = @birth";
            }
            if (position.Text != "")
            {
                sql_str_check(ref cnt, ref sql);
                sql += "position= @position";
            }
            /////////////////////////////////////////////
            adapter1.SelectCommand = new MySqlCommand(sql, conn);
            ////////////////////////////////////////////
            if (num.Text != "")
            {
                adapter1.SelectCommand.Parameters.Add("@num", MySqlDbType.Int32);
                adapter1.SelectCommand.Parameters["@num"].Value = num.Text;
            }
            if (name.Text != "")
            {
                adapter1.SelectCommand.Parameters.Add("@name", MySqlDbType.VarChar);
                adapter1.SelectCommand.Parameters["@name"].Value = name.Text;
            }
            if (gender.Text != "")
            {
                adapter1.SelectCommand.Parameters.Add("@gender", MySqlDbType.VarChar);
                adapter1.SelectCommand.Parameters["@gender"].Value = gender.Text;
            }
            if (phone.Text != "")
            {
                adapter1.SelectCommand.Parameters.Add("@phone", MySqlDbType.VarChar);
                adapter1.SelectCommand.Parameters["@phone"].Value = phone.Text;
            }
            if (birth.Text != "")
            {
                adapter1.SelectCommand.Parameters.Add("@birth", MySqlDbType.DateTime);
                adapter1.SelectCommand.Parameters["@birth"].Value = birth.Text;
            }
            if (position.Text != "")
            {
                adapter1.SelectCommand.Parameters.Add("@position", MySqlDbType.VarChar);
                adapter1.SelectCommand.Parameters["@position"].Value = position.Text;
            }
            try
            {
                conn.Open();
                dataSet1.Clear();
                if (adapter1.Fill(dataSet1, "student") > 0)
                    dataGridView1.DataSource = dataSet1.Tables["student"];
                else
                    MessageBox.Show("검색된 데이터가 없습니다.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void btninsert_Click(object sender, EventArgs e)
        {
            if (num.Text != "" && name.Text != "" && gender.Text != "" && phone.Text != "" && birth.Text != "" && position.Text != "")
            {
                dataSet1.Clear();
                conn.Open();
                string sql = "INSERT INTO student (num, name, gender, phone, birth, position) " +
                    "VALUES(@num, @name, @gender, @phone, @birth, @position)";

                adapter1.InsertCommand = new MySqlCommand(sql, conn);
                adapter1.InsertCommand.Parameters.AddWithValue("@num", num.Text);
                adapter1.InsertCommand.Parameters.AddWithValue("@name", name.Text);
                adapter1.InsertCommand.Parameters.AddWithValue("@gender", gender.Text);
                adapter1.InsertCommand.Parameters.AddWithValue("@phone", phone.Text);
                adapter1.InsertCommand.Parameters.AddWithValue("@birth", birth.Text);
                adapter1.InsertCommand.Parameters.AddWithValue("@position", position.Text.ToString());

                try
                {
                    adapter1.InsertCommand.ExecuteNonQuery();  // DB에 반영
                    dataSet1.Clear();
                    adapter1.Fill(dataSet1, "student");
                    dataGridView1.DataSource = dataSet1.Tables["student"];
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
            else MessageBox.Show("삽입하실 값을 전부 입력해주세요", "오류");
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            if (num.Text != "" || name.Text != "" || gender.Text != "" || phone.Text != "" || birth.Text != "" || position.Text != "")
            {
                if (num.Text == "")
                {
                    string sql = "UPDATE student SET ";
                    int cnt = 0;
                    if (name.Text != "")
                    {
                        sql_str_check_up(ref cnt, ref sql);
                        sql += "name=@name";
                    }
                    if (gender.Text != "")
                    {
                        sql_str_check_up(ref cnt, ref sql);
                        sql += "gender=@gender";
                    }
                    if (phone.Text != "")
                    {
                        sql_str_check_up(ref cnt, ref sql);
                        sql += "phone=@phone";
                    }
                    if (birth.Text != "")
                    {
                        sql_str_check_up(ref cnt, ref sql);
                        sql += "birth=@birth";
                    }
                    if (position.Text != "")
                    {
                        sql_str_check_up(ref cnt, ref sql);
                        sql += "position=@position";
                    }

                    sql += " WHERE num=@num";
                    //MessageBox.Show(sql);
                    adapter1.UpdateCommand = new MySqlCommand(sql, conn);
                    adapter1.UpdateCommand.Parameters.AddWithValue("@num", dataGridView1.SelectedRows[0].Cells["num"].Value);
                    if (name.Text != "") adapter1.UpdateCommand.Parameters.AddWithValue("@name", name.Text);
                    if (gender.Text != "") adapter1.UpdateCommand.Parameters.AddWithValue("@gender", gender.Text);
                    if (phone.Text != "") adapter1.UpdateCommand.Parameters.AddWithValue("@phone", phone.Text);
                    if (birth.Text != "") adapter1.UpdateCommand.Parameters.AddWithValue("@birth", birth.Text);
                    if (position.Text != "") adapter1.UpdateCommand.Parameters.AddWithValue("@position", position.Text);

                    var selectedRows = dataGridView1.SelectedRows;
                    int id;
                    string filter;
                    for (int i = 0; i < selectedRows.Count; i++)
                    {
                        id = (int)dataGridView1.SelectedRows[i].Cells["num"].Value;
                        filter = "num =" + id;
                        DataRow[] findRows = dataSet1.Tables["student"].Select(filter);
                        findRows[i]["num"] = id;
                        if (name.Text != "") findRows[i]["name"] = (string)dataGridView1.SelectedRows[i].Cells["name"].Value;
                        if (gender.Text != "") findRows[i]["gender"] = (string)dataGridView1.SelectedRows[i].Cells["gender"].Value;
                        if (phone.Text != "") findRows[i]["phone"] = (string)dataGridView1.SelectedRows[i].Cells["phone"].Value;
                        if (birth.Text != "") findRows[i]["birth"] = (DateTime)dataGridView1.SelectedRows[i].Cells["birth"].Value;
                        if (position.Text.ToString() != "") findRows[i]["position"] = (string)dataGridView1.SelectedRows[i].Cells["position"].Value;
                    }
                    adapter1.Update(dataSet1, "student");
                    //MessageBox.Show("UPDATE 완료!");
                    dataSet1.Clear();
                    adapter1.Fill(dataSet1, "student");
                    dataGridView1.DataSource = dataSet1.Tables["student"];
                }
                else MessageBox.Show("고유ID는 변경할 수 없습니다.", "오류");
            }
            else MessageBox.Show("변경하실 값을 입력해주세요.", "오류");
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            conn.Open();
            string sql = "DELETE FROM student WHERE num = @num";
            adapter1.DeleteCommand = new MySqlCommand(sql, conn);
            adapter1.DeleteCommand.Parameters.AddWithValue("@num", dataGridView1.SelectedRows[0].Cells["num"].Value);
            int id = (int)dataGridView1.CurrentRow.Cells["num"].Value;

            string filter = "num=" + id;

            DataRow[] findRows = dataSet1.Tables["student"].Select(filter);
            findRows[0].Delete();
        
            adapter1.Update(dataSet1, "student");
            adapter1.DeleteCommand.ExecuteNonQuery();  // DB에 반영
            dataSet1.Clear();
            adapter1.Fill(dataSet1, "student");
            dataGridView1.DataSource = dataSet1.Tables["student"];
            conn.Close();
        }

        private void reset_Click(object sender, EventArgs e)
        {
            num.Clear();
            name.Clear();
            phone.Clear();
            position.Clear();
            birth.Clear();
            gender.SelectedIndex = -1;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            dataSet1.Clear();
            adapter1.Fill(dataSet1, "student");
            dataGridView1.DataSource = dataSet1.Tables["student"];
        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dataGridView1.Columns[0].HeaderText = "번호";
            dataGridView1.Columns[1].HeaderText = "성명";
            dataGridView1.Columns[2].HeaderText = "성별";
            dataGridView1.Columns[3].HeaderText = "연락처";
            dataGridView1.Columns[4].HeaderText = "생년월일";
            dataGridView1.Columns[5].HeaderText = "역할";
        }
    }
}

