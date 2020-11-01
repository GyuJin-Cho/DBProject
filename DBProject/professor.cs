using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBProject
{
    public partial class professor : Form
    {
        private OleDbConnection conn1;
        private string connectionString;

        public professor(string connectionString1)
        {
            InitializeComponent();
            connectionString = connectionString1;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            dataGridView2.Rows.Clear();
            conn1 = new OleDbConnection(connectionString);
            try
            {
                conn1.Open(); //데이터베이스 연결
                OleDbCommand cmd = new OleDbCommand();

                cmd.CommandText = "SELECT 성적확인 FROM" + " " + "신청확인"+" "+"WHERE 성적확인=1";
                cmd.CommandType = CommandType.Text; //검색명령을 쿼리 형태로
                cmd.Connection = conn1;
                cmd.ExecuteNonQuery(); //쿼리문을 실행하고 영향받는 행의 수를 반환.
                OleDbDataReader read = cmd.ExecuteReader(); //select * from emp 결과
                if(!read.Read())
                {
                    MessageBox.Show("성적입력기간이 아닙니다.");
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

                cmd.CommandText = "SELECT * FROM" + " " + "수강" + " " + "WHERE 교과목번호=" + textBox5.Text;
                cmd.CommandType = CommandType.Text; //검색명령을 쿼리 형태로
                cmd.Connection = conn1;
                cmd.ExecuteNonQuery(); //쿼리문을 실행하고 영향받는 행의 수를 반환.
                OleDbDataReader read = cmd.ExecuteReader(); //select * from emp 결과
                dataGridView2.ColumnCount = 4;
                //필드명 받아오는 반복문
                for (int i = 0; i < 4; i++)
                {
                    dataGridView2.Columns[i].Name = read.GetName(i);
                }
                while (read.Read())
                {
                    object[] obj = new object[4]; // 필드수만큼 오브젝트 배열

                    for (int i = 0; i < 4; i++) // 필드 수만큼 반복
                    {
                        obj[i] = new object();
                        obj[i] = read.GetValue(i); // 오브젝트배열에 데이터 저장
                    }

                    dataGridView2.Rows.Add(obj); //데이터그리드뷰에 오브젝트 배열 추가
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

        private void button9_Click(object sender, EventArgs e)
        {
            conn1 = new OleDbConnection(connectionString);
            try
            {
                conn1.Open(); //데이터베이스 연결
                OleDbCommand cmd = new OleDbCommand();

                cmd.CommandText = "UPDATE" + " " + "수강" + " " + "SET" + " " + "성적" +"=" + "'"+textBox6.Text+"'" + " " + "WHERE" + " " + "학번" + "=" + textBox7.Text;
                cmd.CommandType = CommandType.Text; //검색명령을 쿼리 형태로
                cmd.Connection = conn1;
                cmd.ExecuteNonQuery(); //쿼리문을 실행하고 영향받는 행의 수를 반환.

                
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

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void professor_Load(object sender, EventArgs e)
        {

        }
    }
}
