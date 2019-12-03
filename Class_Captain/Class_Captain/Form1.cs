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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        MySqlConnection conn;
        MySqlDataAdapter adapter1;
        DataSet dataSet1;

        private void button3_Click(object sender, EventArgs e)
        {
            notication form4 = new notication();
            form4.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            changeseat form3 = new changeseat();
            form3.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            manage form2 = new manage();
            form2.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string conadd = "server=localhost;port=3306;database=classstudent;uid=root;pwd=0000";
            conn = new MySqlConnection(conadd);
            adapter1 = new MySqlDataAdapter("SELECT * FROM student", conn);  // DataSet과 DB 연결(명령 수행)
            dataSet1 = new DataSet();           // 메모리상의 가상 DataTable 관리
            adapter1.Fill(dataSet1, "stduent");
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
            conn.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            dataSet1.Clear();
            adapter1.Fill(dataSet1, "student");
            dataGridView1.DataSource = dataSet1.Tables["student"];
        }

    }
}
