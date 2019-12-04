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
using Excel = Microsoft.Office.Interop.Excel;


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
        string[] title = new string[3];

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
            string sql = "UPDATE notification SET check1 = @check1 WHERE id = @id";
            adapter1.UpdateCommand = new MySqlCommand(sql, conn);
            adapter1.UpdateCommand.Parameters.AddWithValue("@id", dataGridView1.SelectedRows[0].Cells["id"].Value);
            adapter1.UpdateCommand.Parameters.AddWithValue("@check1", statebox.Text);
            var selectedRows = dataGridView1.SelectedRows;
            int id;
            string filter;
            for (int i = 0; i < selectedRows.Count; i++)
            {
                id = (int)dataGridView1.SelectedRows[i].Cells["id"].Value;
                filter = "id =" + id;
                DataRow[] findRows = dataSet1.Tables["notification"].Select(filter);
                findRows[i]["id"] = id;
                if (statebox.Text != "") findRows[i]["check1"] = dataGridView1.SelectedRows[i].Cells["check1"].Value;

            }
            adapter1.Update(dataSet1, "notification");
            dataSet1.Clear();
            adapter1.Fill(dataSet1, "notification");
            dataGridView1.DataSource = dataSet1.Tables["notification"];
            }
            else if (rd2.Checked)
            {
                string sql = "UPDATE notification SET check2 = @check2 WHERE id = @id";
                adapter1.UpdateCommand = new MySqlCommand(sql, conn);
                adapter1.UpdateCommand.Parameters.AddWithValue("@id", dataGridView1.SelectedRows[0].Cells["id"].Value);
                adapter1.UpdateCommand.Parameters.AddWithValue("@check2", statebox.Text);
                var selectedRows = dataGridView1.SelectedRows;
                int id;
                string filter;
                for (int i = 0; i < selectedRows.Count; i++)
                {
                    id = (int)dataGridView1.SelectedRows[i].Cells["id"].Value;
                    filter = "id =" + id;
                    DataRow[] findRows = dataSet1.Tables["notification"].Select(filter);
                    findRows[i]["id"] = id;
                    if (statebox.Text != "") findRows[i]["check2"] = dataGridView1.SelectedRows[i].Cells["check2"].Value;

                }
                adapter1.Update(dataSet1, "notification");
                dataSet1.Clear();
                adapter1.Fill(dataSet1, "notification");
                dataGridView1.DataSource = dataSet1.Tables["notification"];
            }
            else if (rd3.Checked)
            {
                string sql = "UPDATE notification SET check3 = @check3 WHERE id = @id";
                adapter1.UpdateCommand = new MySqlCommand(sql, conn);
                adapter1.UpdateCommand.Parameters.AddWithValue("@id", dataGridView1.SelectedRows[0].Cells["id"].Value);
                adapter1.UpdateCommand.Parameters.AddWithValue("@check3", statebox.Text);
                var selectedRows = dataGridView1.SelectedRows;
                int id;
                string filter;
                for (int i = 0; i < selectedRows.Count; i++)
                {
                    id = (int)dataGridView1.SelectedRows[i].Cells["id"].Value;
                    filter = "id =" + id;
                    DataRow[] findRows = dataSet1.Tables["notification"].Select(filter);
                    findRows[i]["id"] = id;
                    if (statebox.Text != "") findRows[i]["check3"] = dataGridView1.SelectedRows[i].Cells["check3"].Value;

                }
                adapter1.Update(dataSet1, "notification");
                dataSet1.Clear();
                adapter1.Fill(dataSet1, "notification");
                dataGridView1.DataSource = dataSet1.Tables["notification"];
            }
            else MessageBox.Show("안내장을 선택해주세요");
        }

        private void check1_Click(object sender, EventArgs e)
        {
            string sql = "UPDATE notification SET check1 = NULL WHERE check1 is not null;";
            adapter1.UpdateCommand = new MySqlCommand(sql, conn);
            adapter1.Update(dataSet1, "notification");

            try
            {
                conn.Open();
                SaveExcelFile(1);
                adapter1.UpdateCommand.ExecuteNonQuery();
                dataSet1.Clear();  // 이전 데이터 지우기
                adapter1.Fill(dataSet1, "notification");
                dataGridView1.DataSource = dataSet1.Tables["notification"];
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

        private void SaveExcelFile(int num)
        {
            if (excelbtn.Checked)
            {
                saveFileDialog1.Filter = "엑셀 파일(*.xlsx)|*.xlsx";
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    SaveTextExcel(saveFileDialog1.FileName, num);
                }
            }
        }

        private void SaveTextExcel(string filePath, int num)
        {
            //1.엑셀 사용에 필요한 객체 생성
            num = num - 1;
            int jump = 0;
            Excel.Application eApp; //엑셀 프로그램
            Excel.Workbook eWorkbook; // 엑셀 시트를 여러개 포함하는 단위
            Excel.Worksheet eWorksheet; //엑셀 워크시트
            eApp = new Excel.Application();
            eWorkbook = eApp.Workbooks.Add();  // eApp에 워크북 추가
            eWorksheet = eWorkbook.Sheets[1];  // 엑셀 워크시트는 Index가 1부터 시작한다.
            //2. 엑셀에 저장할 데이터를 2차원 배열 형태로 준비
            string[,] dataArr;
            int colCount = dataSet1.Tables["notification"].Columns.Count + 1;
            int rowCount = dataSet1.Tables["notification"].Rows.Count + 1;
            dataArr = new string[rowCount, colCount];

            // 2-1 Column 이름 저장
            for (int i = 0; i < dataSet1.Tables["notification"].Columns.Count; i++)
            {
                if (i == num + 2 || i <= 1)
                {
                    dataArr[0, i - jump] = dataSet1.Tables["notification"].Columns[i].ColumnName;//이름
                }
                else
                {
                    jump++;
                    continue;
                }
            }
            // 2-2 행 데이터 저장 
            Boolean flag = true;
            for (int i = 0; i < dataSet1.Tables["notification"].Rows.Count; i++)
            {
                flag = true;
                jump = 0;
                for (int j = 0; j < dataSet1.Tables["notification"].Columns.Count; j++)
                {
                    if (j == 0 || j == 1 || j - 2 == num)//j == 2 num = 1 j == 3 num2
                    {
                        dataArr[i + 1, j - jump] = dataSet1.Tables["notification"].Rows[i].ItemArray[j].ToString();
                    }
                    else
                    {
                        jump++;
                    }
                }
            }
            // 3. 주입된 데이터를 엑셀파일에 저장
            string endCell = $"E{rowCount}";
            eWorksheet.get_Range("A1:" + endCell).Value = dataArr;

            eWorkbook.SaveAs(filePath, Excel.XlFileFormat.xlWorkbookDefault, Type.Missing, Type.Missing,
                false, false, Excel.XlSaveAsAccessMode.xlShared, false, false, Type.Missing, Type.Missing);
            eWorkbook.Close(false, Type.Missing, Type.Missing);
            eApp.Quit();
        }

        private void check2_Click(object sender, EventArgs e)
        {
            string sql = "UPDATE notification SET check1 = NULL WHERE check1 is not null;";
            adapter1.UpdateCommand = new MySqlCommand(sql, conn);
            adapter1.Update(dataSet1, "notification");

            try
            {
                conn.Open();
                SaveExcelFile(2);
                adapter1.UpdateCommand.ExecuteNonQuery();
                dataSet1.Clear();  // 이전 데이터 지우기
                adapter1.Fill(dataSet1, "notification");
                dataGridView1.DataSource = dataSet1.Tables["notification"];
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

        private void check3_Click(object sender, EventArgs e)
        {
            string sql = "UPDATE notification SET check1 = NULL WHERE check1 is not null;";
            adapter1.UpdateCommand = new MySqlCommand(sql, conn);
            adapter1.Update(dataSet1, "notification");

            try
            {
                conn.Open();
                SaveExcelFile(3);
                adapter1.UpdateCommand.ExecuteNonQuery();
                dataSet1.Clear();  // 이전 데이터 지우기
                adapter1.Fill(dataSet1, "notification");
                dataGridView1.DataSource = dataSet1.Tables["notification"];
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

            inputtitle();
            rd1.Text = title[0];
            rd2.Text = title[1];
            rd3.Text = title[2];

            check1.Text = title[0];
            check2.Text = title[1];
            check3.Text = title[2];
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

        private void inputtitle()
        {
            string conadd = "server=localhost;port=3306;database=classstudent;uid=root;pwd=0000";
            int i = 0;
            conn = new MySqlConnection(conadd);
            string sql = $"SELECT name FROM notification_name";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            try
            {
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())  // 다음 레코드가 있으면 true
                {
                    sql = $"SELECT name FROM student WHERE num = {i}";
                    string s = reader["name"].ToString();
                    title[i] = s;
                    i++;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            conn.Close();
        }

    }
}
