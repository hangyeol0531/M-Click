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
    public partial class notication : Form
    {
        public notication()
        {
            InitializeComponent();
        }
        MySqlConnection conn;
        MySqlDataAdapter adapter1, adapter2;
        DataSet dataSet1, dataSet2;

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

        private void updatebtn_Click(object sender, EventArgs e)
        {
            if (num.Text != "" || name.Text != "" || deadline.Value.ToString("yyyy-MM-dd") != "")
            {
                if (num.Text == "")
                {
                    string sql = "UPDATE notification_name SET ";
                    int cnt = 0;
                    if (name.Text != "")
                    {
                        sql_str_check_up(ref cnt, ref sql);
                        sql += "name=@name";
                    }
                    if (deadline.Value.ToString("yyyy-MM-dd") != "")
                    {
                        sql_str_check_up(ref cnt, ref sql);
                        sql += "deadline=@deadline";
                    }
                    sql += " WHERE num=@num";
                    //MessageBox.Show(sql);
                    adapter2.UpdateCommand = new MySqlCommand(sql, conn);
                    adapter2.UpdateCommand.Parameters.AddWithValue("@num", dataGridView2.SelectedRows[0].Cells["num"].Value);
                    if (name.Text != "") adapter2.UpdateCommand.Parameters.AddWithValue("@name", name.Text);
                    if (deadline.Text != "") adapter2.UpdateCommand.Parameters.AddWithValue("@deadline", deadline.Value.ToString("yyyy-MM-dd"));
                    var selectedRows = dataGridView2.SelectedRows;
                    int id;
                    string filter;
                    for (int i = 0; i < selectedRows.Count; i++)
                    {
                        id = (int)dataGridView2.SelectedRows[i].Cells["num"].Value;
                        filter = "num =" + id;
                        DataRow[] findRows = dataSet2.Tables["notification_name"].Select(filter);
                        findRows[i]["num"] = id;
                        if (name.Text != "") findRows[i]["name"] = (string)dataGridView2.SelectedRows[i].Cells["name"].Value;
                        if (deadline.Value.ToString("yyyy-MM-dd") != "") findRows[i]["deadline"] = (DateTime)dataGridView2.SelectedRows[i].Cells["deadline"].Value;
                    }
                    adapter2.Update(dataSet2, "notification_name");
                    //MessageBox.Show("UPDATE 완료!");
                    dataSet2.Clear();
                    adapter2.Fill(dataSet2, "notification_name");
                    dataGridView2.DataSource = dataSet2.Tables["notification_name"];
                }
                else MessageBox.Show("고유ID는 변경할 수 없습니다.", "오류");
            }
            else MessageBox.Show("변경하실 값을 입력해주세요.", "오류");
        }

        private void deletebtn_Click(object sender, EventArgs e)
        {
            conn.Open();
            string sql = "DELETE FROM notification_name WHERE num = @num";
            adapter2.DeleteCommand = new MySqlCommand(sql, conn);
            adapter2.DeleteCommand.Parameters.AddWithValue("@num", dataGridView2.SelectedRows[0].Cells["num"].Value);
            int id = (int)dataGridView2.CurrentRow.Cells["num"].Value;

            string filter = "num=" + id;
            DataRow[] findRows = dataSet2.Tables["notification_name"].Select(filter);
            findRows[0].Delete();

            adapter2.Update(dataSet2, "notification_name");

            dataSet2.Clear();
            adapter2.Fill(dataSet2, "notification_name");
            dataGridView2.DataSource = dataSet2.Tables["notification_name"];
            conn.Close();
        }

        private void resetbtn_Click(object sender, EventArgs e)
        {
            num.Clear();
            name.Clear();
            //deadline.Value
        }

        private void change_Click(object sender, EventArgs e)
        {
            if (rd1.Checked)
            {
                if (num.Text != "" || name.Text != "" || deadline.Value.ToString("yyyy-MM-dd") != "")
                {
                    if (num.Text == "")
                    {
                        string sql = "UPDATE notification_name SET ";
                        int cnt = 0;
                        if (name.Text != "")
                        {
                            sql_str_check_up(ref cnt, ref sql);
                            sql += "name=@name";
                        }
                        if (deadline.Value.ToString("yyyy-MM-dd") != "")
                        {
                            sql_str_check_up(ref cnt, ref sql);
                            sql += "deadline=@deadline";
                        }
                        sql += " WHERE num=@num";
                        //MessageBox.Show(sql);
                        adapter2.UpdateCommand = new MySqlCommand(sql, conn);
                        adapter2.UpdateCommand.Parameters.AddWithValue("@num", dataGridView2.SelectedRows[0].Cells["num"].Value);
                        if (name.Text != "") adapter2.UpdateCommand.Parameters.AddWithValue("@name", name.Text);
                        if (deadline.Text != "") adapter2.UpdateCommand.Parameters.AddWithValue("@deadline", deadline.Value.ToString("yyyy-MM-dd"));
                        var selectedRows = dataGridView2.SelectedRows;
                        int id;
                        string filter;
                        for (int i = 0; i < selectedRows.Count; i++)
                        {
                            id = (int)dataGridView2.SelectedRows[i].Cells["num"].Value;
                            filter = "num =" + id;
                            DataRow[] findRows = dataSet2.Tables["notification_name"].Select(filter);
                            findRows[i]["num"] = id;
                            if (name.Text != "") findRows[i]["name"] = (string)dataGridView2.SelectedRows[i].Cells["name"].Value;
                            if (deadline.Value.ToString("yyyy-MM-dd") != "") findRows[i]["deadline"] = (DateTime)dataGridView2.SelectedRows[i].Cells["deadline"].Value;
                        }
                        adapter2.Update(dataSet2, "notification_name");
                        //MessageBox.Show("UPDATE 완료!");
                        dataSet2.Clear();
                        adapter2.Fill(dataSet2, "notification_name");
                        dataGridView2.DataSource = dataSet2.Tables["notification_name"];
                    }
                    else MessageBox.Show("고유ID는 변경할 수 없습니다.", "오류");
                }
                else MessageBox.Show("변경하실 값을 입력해주세요.", "오류");
            }
            else if (rd2.Checked)
            {

            }
            else if (rd3.Checked)
            {

            }
            else MessageBox.Show("안내장을 선택해주세요");
        }

        private void insertbtn_Click(object sender, EventArgs e)
        {
            if (num.Text != "" && name.Text != "" && deadline.Text != "")
            {
                dataSet2.Clear();
                conn.Open();
                string sql = "INSERT INTO notification_name (num, name, deadline) " +
                    "VALUES(@num, @name, @deadline)";

                adapter2.InsertCommand = new MySqlCommand(sql, conn);
                adapter2.InsertCommand.Parameters.AddWithValue("@num", num.Text);
                adapter2.InsertCommand.Parameters.AddWithValue("@name", name.Text);
                adapter2.InsertCommand.Parameters.AddWithValue("@deadline", deadline.Value);

                try
                {
                    adapter2.InsertCommand.ExecuteNonQuery();  // DB에 반영
                    dataSet2.Clear();
                    adapter2.Fill(dataSet2, "notification_name");
                    dataGridView2.DataSource = dataSet2.Tables["notification_name"];
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

        private void notication_Load(object sender, EventArgs e)
        {
            string conadd = "server=localhost;port=3306;database=classstudent;uid=root;pwd=0000";
            conn = new MySqlConnection(conadd);
            adapter1 = new MySqlDataAdapter("SELECT * FROM notification", conn);  // DataSet과 DB 연결(명령 수행)
            dataSet1 = new DataSet();           // 메모리상의 가상 DataTable 관리
            adapter2 = new MySqlDataAdapter("SELECT * FROM notification_name", conn);  // DataSet과 DB 연결(명령 수행)
            dataSet2 = new DataSet();           // 메모리상의 가상 DataTable 관리

            adapter1.Fill(dataSet1, "notification");
            dataGridView1.DataSource = dataSet1.Tables["notification"];

            adapter2.Fill(dataSet2, "notification_name");
            dataGridView2.DataSource = dataSet2.Tables["notification_name"];

            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            conn.Close();
        }
    }
}
