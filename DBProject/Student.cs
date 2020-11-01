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
    public partial class Student : Form
    {
        private OleDbConnection conn1;
        string connectionString1;
        string studentnum1;
        public Student(string connectionString, string studentnum)
        {
            InitializeComponent();
            connectionString1= connectionString;
            studentnum1 = studentnum;
    }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            conn1 = new OleDbConnection(connectionString1);
            try
            {
                conn1.Open(); //데이터베이스 연결
                OleDbCommand cmd = new OleDbCommand();

                cmd.CommandText = "SELECT 성적확인 FROM" + " " + "신청확인" + " " + "WHERE 수강확인=1";
                cmd.CommandType = CommandType.Text; //검색명령을 쿼리 형태로
                cmd.Connection = conn1;
                cmd.ExecuteNonQuery(); //쿼리문을 실행하고 영향받는 행의 수를 반환.
                OleDbDataReader read = cmd.ExecuteReader(); //select * from emp 결과
                if (!read.Read())
                {
                    MessageBox.Show("수강신청기간이 아닙니다.");
                    return;
                }
                read.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex.Message); //에러 메세지 
            }
            finally
            {
                if (conn1 != null)
                {
                    conn1.Close(); //데이터베이스 연결 해제
                }
            }
            try
            {
                conn1.Open(); //데이터베이스 연결
                OleDbCommand cmd = new OleDbCommand();

                cmd.CommandText = "SELECT * FROM" + " " + "교과목";
                cmd.CommandType = CommandType.Text; //검색명령을 쿼리 형태로
                cmd.Connection = conn1;
                cmd.ExecuteNonQuery(); //쿼리문을 실행하고 영향받는 행의 수를 반환.
                OleDbDataReader read = cmd.ExecuteReader(); //select * from emp 결과
                dataGridView1.ColumnCount = 7;
                //필드명 받아오는 반복문
                for (int i = 0; i < 7; i++)
                {
                    dataGridView1.Columns[i].Name = read.GetName(i);
                }
                while (read.Read())
                {
                    object[] obj = new object[7]; // 필드수만큼 오브젝트 배열

                    for (int i = 0; i < 7; i++) // 필드 수만큼 반복
                    {
                        obj[i] = new object();
                        obj[i] = read.GetValue(i); // 오브젝트배열에 데이터 저장
                    }

                    dataGridView1.Rows.Add(obj); //데이터그리드뷰에 오브젝트 배열 추가
                }

                read.Close();

               
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex.Message); //에러 메세지 
            }
            finally
            {
                if (conn1 != null)
                {
                    conn1.Close(); //데이터베이스 연결 해제
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn1 = new OleDbConnection(connectionString1);
            try
            {
                conn1.Open(); //데이터베이스 연결
                OleDbCommand cmd = new OleDbCommand();
                
                   
                cmd.CommandText = "INSERT INTO" + " " + "수강" + " " + "VALUES(" + studentnum1 + "," + textBox1.Text + "," + 0 +",'"+ "NULL"+"'"+")";
                cmd.CommandType = CommandType.Text; //검색명령을 쿼리 형태로
                cmd.Connection = conn1;
                cmd.ExecuteNonQuery(); //쿼리문을 실행하고 영향받는 행의 수를 반환.
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error"+ex.Message); //에러 메세지 
            }
            finally
            {
                if (conn1 != null)
                {
                    conn1.Close(); //데이터베이스 연결 해제
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            conn1 = new OleDbConnection(connectionString1);
            try
            {
                conn1.Open(); //데이터베이스 연결
                OleDbCommand cmd = new OleDbCommand();

                cmd.CommandText = "SELECT 성적확인 FROM" + " " + "신청확인" + " " + "WHERE 성적열람확인=1";
                cmd.CommandType = CommandType.Text; //검색명령을 쿼리 형태로
                cmd.Connection = conn1;
                cmd.ExecuteNonQuery(); //쿼리문을 실행하고 영향받는 행의 수를 반환.
                OleDbDataReader read = cmd.ExecuteReader(); //select * from emp 결과
                if (!read.Read())
                {
                    MessageBox.Show("성적열람기간이 아닙니다.");
                    return;
                }
                read.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex.Message); //에러 메세지 
            }
            finally
            {
                if (conn1 != null)
                {
                    conn1.Close(); //데이터베이스 연결 해제
                }
            }
            try
            {
                conn1.Open(); //데이터베이스 연결
                OleDbCommand cmd = new OleDbCommand();

                cmd.CommandText = "SELECT * FROM" + " " + "수강";
                cmd.CommandType = CommandType.Text; //검색명령을 쿼리 형태로
                cmd.Connection = conn1;
                cmd.ExecuteNonQuery(); //쿼리문을 실행하고 영향받는 행의 수를 반환.
                OleDbDataReader read = cmd.ExecuteReader(); //select * from emp 결과
                dataGridView1.ColumnCount = 4;
                //필드명 받아오는 반복문
                for (int i = 0; i < 4; i++)
                {
                    dataGridView1.Columns[i].Name = read.GetName(i);
                }
                while (read.Read())
                {
                    object[] obj = new object[4]; // 필드수만큼 오브젝트 배열

                    for (int i = 0; i < 4; i++) // 필드 수만큼 반복
                    {
                        obj[i] = new object();
                        obj[i] = read.GetValue(i); // 오브젝트배열에 데이터 저장
                    }

                    dataGridView1.Rows.Add(obj); //데이터그리드뷰에 오브젝트 배열 추가
                }

                read.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex.Message); //에러 메세지 
            }
            finally
            {
                if (conn1 != null)
                {
                    conn1.Close(); //데이터베이스 연결 해제
                }
            }
        }
    }
}

