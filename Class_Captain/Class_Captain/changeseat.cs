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
        string [] student = new string [20];
        
        
        public changeseat()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void changeseat_Load(object sender, EventArgs e)
        {
            string conadd = "server=localhost;port=3306;database=classstudent;uid=root;pwd=0000";
            int i = 1;
            conn = new MySqlConnection(conadd);
            string[]student = new string[20];
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
