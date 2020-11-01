using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace DBProject
{
    public partial class Main : Form
    {
        OleDbConnection conn;
        string connectionString;
        private OleDbConnection conn1;
        string studentnum;
        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string connectionString1= "Provider=MSDAORA;Password=" + "20154111" + ";User ID=" + "S20154111";
            if (comboBox1.Text.Equals("관리자"))
            {
                connectionString = "Provider=MSDAORA;Password=" + textBox2.Text + ";User ID=" + textBox1.Text;
            }
           
            else if (comboBox1.Text.Equals("학생"))
            {
                conn1 = new OleDbConnection(connectionString1);
                try
                {
                    conn1.Open(); 
                    OleDbCommand cmd = new OleDbCommand();
                    studentnum = textBox1.Text;
                    cmd.CommandText = "SELECT * FROM" + " " + "학생" + " " + "WHERE 학번=" + textBox1.Text;
                    cmd.CommandType = CommandType.Text; 
                    cmd.Connection = conn1;
                    cmd.ExecuteNonQuery(); 
                    OleDbDataReader read = cmd.ExecuteReader();
                    if(read.Read())
                    {
                        Student student = new Student(connectionString1,studentnum);
                        student.Show();
                    }
                    else
                    {
                        MessageBox.Show("입력하신 번호가 없습니다");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error" + ex.Message);
                }
            }
            else if(comboBox1.Text.Equals("교수"))
            {
                conn1 = new OleDbConnection(connectionString1);
                try
                {
                    conn1.Open(); 
                    OleDbCommand cmd = new OleDbCommand();

                    cmd.CommandText = "SELECT * FROM" + " " + "교수" + " " + "WHERE 교수번호=" + textBox1.Text;
                    cmd.CommandType = CommandType.Text; 
                    cmd.Connection = conn1;
                    cmd.ExecuteNonQuery();
                    OleDbDataReader read = cmd.ExecuteReader();
                    if (read.Read())
                    {
                        professor Professor = new professor(connectionString1);
                        Professor.Show();
                    }
                    else
                    {
                        MessageBox.Show("입력하신 번호가 없습니다");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error" + ex.Message); 
                }
            }
            
            conn = new OleDbConnection(connectionString);
            try 
            {
                conn.Open();
                updatedb();
            }
            catch (Exception ex)
            {
                                                         
            }
            
            connectionString = " ";
        }
        private void updatedb()
        {
            try
            {
                SystemManager SystemManager = new SystemManager(connectionString);
                SystemManager.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message); 
            }
        }
    }
}
