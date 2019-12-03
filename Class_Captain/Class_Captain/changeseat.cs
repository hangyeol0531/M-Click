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
    public partial class changeseat : Form
    {
        MySqlConnection conn;
        MySqlDataAdapter adapter1;
        DataSet dataSet1;
        int i = 1;
        string[] comstudent = new string[20];
        string[] student = new string[20];
        List<int>randlist = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19};
        int bFound = 0;
        public changeseat()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            set_seat();
            label1.Text = comstudent[0];
            label2.Text = comstudent[1];
            label3.Text = comstudent[2];
            label4.Text = comstudent[3];
            label5.Text = comstudent[4];
            label6.Text = comstudent[5];
            label7.Text = comstudent[6];
            label8.Text = comstudent[7];
            label9.Text = comstudent[8];
            label10.Text = comstudent[9];
            label11.Text = comstudent[10];
            label12.Text = comstudent[11];
            label13.Text = comstudent[12];
            label14.Text = comstudent[13];
            label15.Text = comstudent[14];
            label16.Text = comstudent[15];
            label17.Text = comstudent[16];
            label18.Text = comstudent[17];
            label19.Text = comstudent[18];
            label20.Text = comstudent[19];
        }

        private void set_seat()
        {
            List<int> randlist = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19 };
            for (i = 0; i < 20; ++i)
            {
                Random rand = new Random();
                    int r = rand.Next(20 - i);
                    //MessageBox.Show(r+"  "+randlist[r] + "  " + student[randlist[r]]);
                    //comstudent[i] = student[randlist[r]];
                    comstudent[i] = student[randlist[r]];
                    randlist.RemoveAt(r);
            }
        }

        private void changeseat_Load(object sender, EventArgs e)
        {
            string conadd = "server=localhost;port=3306;database=classstudent;uid=root;pwd=0000";
            int i = 1;
            conn = new MySqlConnection(conadd);
            string sql = $"SELECT name FROM student";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            try
            {
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                    
                while (reader.Read())  // 다음 레코드가 있으면 true
                {
                    sql = $"SELECT name FROM student WHERE num = {i}";
                    string s = reader["name"].ToString();
                    student[i - 1] = s;
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
