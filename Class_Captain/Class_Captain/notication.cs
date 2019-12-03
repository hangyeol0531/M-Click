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

        private void updatebtn_Click(object sender, EventArgs e)
        {

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
