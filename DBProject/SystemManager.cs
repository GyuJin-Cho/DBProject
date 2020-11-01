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
    
    public partial class SystemManager : Form
    {
        OleDbConnection conn1;
        string connectionString1;
        string student ="학생";
        string professor = "교수";
        string study = "교과목";
        
        public SystemManager(string connectionString)
        {
            InitializeComponent();
            dataGridView1.Rows.Clear();
            dataGridView2.Rows.Clear();
            connectionString1 = connectionString;
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)//학생 삽입/수정/삭제
        {
            conn1 = new OleDbConnection(connectionString1);
            try
            {
                conn1.Open(); //데이터베이스 연결
                OleDbCommand cmd = new OleDbCommand();
                if (textBox13.Text==""||textBox12.Text=="")
                {
                    if (textBox13.Text == "" && textBox12.Text == "")
                    {
                        cmd.CommandText = "INSERT INTO" + " " + student + " " + "VALUES(" + "" + textBox1.Text + ",'" + textBox3.Text + "','" + textBox4.Text + "','" + textBox9.Text + "','" + textBox2.Text + "','" + textBox11.Text + "'," + textBox10.Text + ",'" + "NULL" + "','" + "NULL" + "'" + ")";
                    }
                    else if(textBox13.Text==""&&textBox12.Text!="")
                    {
                        cmd.CommandText = "INSERT INTO" + " " + student + " " + "VALUES(" + "" + textBox1.Text + ",'" + textBox3.Text + "','" + textBox4.Text + "','" + textBox9.Text + "','" + textBox2.Text + "','" + textBox11.Text + "'," + textBox10.Text + ",'" + "NULL" + "','" + textBox12.Text + "'" + ")";
                    }
                    else
                    {
                        cmd.CommandText = "INSERT INTO" + " " + student + " " + "VALUES(" + "" + textBox1.Text + ",'" + textBox3.Text + "','" + textBox4.Text + "','" + textBox9.Text + "','" + textBox2.Text + "','" + textBox11.Text + "'," + textBox10.Text + ",'" + textBox13.Text + "','" + "NULL" + "'" + ")";
                    }
                }
                else
                {
                    cmd.CommandText = "INSERT INTO" + " " + student + " " + "VALUES(" + "" + textBox1.Text + ",'" + textBox3.Text + "','" + textBox4.Text + "','" + textBox9.Text + "','" + textBox2.Text + "','" + textBox11.Text + "'," + textBox10.Text + ",'" + textBox13.Text + "','" + textBox12.Text + "'" + ")";
                }
                
                cmd.CommandType = CommandType.Text; //검색명령을 쿼리 형태로
                cmd.Connection = conn1;
                cmd.ExecuteNonQuery(); //쿼리문을 실행하고 영향받는 행의 수를 반환.
                success();
                updatedb();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" ); //에러 메세지 
            }
            finally
            {
                if (conn1 != null)
                {
                    conn1.Close(); //데이터베이스 연결 해제
                }
            }
        }

        private void updatedb()
        {
            
        }
        private void success()
        {
            MessageBox.Show("Success");
        }
        private void Label11_Click(object sender, EventArgs e)
        {

        }

        private void TextBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void Label8_Click(object sender, EventArgs e)
        {

        }

        private void Label9_Click(object sender, EventArgs e)
        {

        }

        private void Button6_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            conn1 = new OleDbConnection(connectionString1);
            try
            {
                conn1.Open(); //데이터베이스 연결
                OleDbCommand cmd = new OleDbCommand();

                cmd.CommandText = "SELECT * FROM" + " " + study + " " + "WHERE 교과목번호=" + textBox20.Text;
                cmd.CommandType = CommandType.Text; //검색명령을 쿼리 형태로
                cmd.Connection = conn1;
                cmd.ExecuteNonQuery(); //쿼리문을 실행하고 영향받는 행의 수를 반환.
                OleDbDataReader read = cmd.ExecuteReader(); //select * from emp 결과
                dataGridView1.ColumnCount = 9;
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

                success();
                updatedb();
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

        private void Label10_Click(object sender, EventArgs e)
        {

        }

        private void ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void TextBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void Label12_Click(object sender, EventArgs e)
        {

        }

        private void Label13_Click(object sender, EventArgs e)
        {

        }

        private void Button7_Click(object sender, EventArgs e)
        {
            conn1 = new OleDbConnection(connectionString1);
            try
            {
                conn1.Open(); //데이터베이스 연결
                OleDbCommand cmd = new OleDbCommand();

                cmd.CommandText = "DELETE FROM" + " " + study + " " + "WHERE 교과목번호=" + textBox14.Text;
                cmd.CommandType = CommandType.Text; //검색명령을 쿼리 형태로
                cmd.Connection = conn1;
                cmd.ExecuteNonQuery(); //쿼리문을 실행하고 영향받는 행의 수를 반환.
                success();
                updatedb();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error"); //에러 메세지 
            }
            finally
            {
                if (conn1 != null)
                {
                    conn1.Close(); //데이터베이스 연결 해제
                }
            }
        }

        private void Button8_Click(object sender, EventArgs e)
        {
            conn1 = new OleDbConnection(connectionString1);
            try
            {
                conn1.Open(); //데이터베이스 연결
                OleDbCommand cmd = new OleDbCommand();
                if(textBox8.Text=="")
                {
                    cmd.CommandText = "INSERT INTO" + " " + study + " " + "VALUES(" + "" + textBox14.Text + ",'" + textBox6.Text + "','" + textBox7.Text + "','" + comboBox2.Text + "'," + textBox5.Text + ",'" + "NULL" + "','" + comboBox1.Text+"'"+ ")";
                }
                else
                {
                    cmd.CommandText = "INSERT INTO" + " " + study + " " + "VALUES(" + "" + textBox14.Text + ",'" + textBox6.Text + "','" + textBox7.Text + "','" + comboBox2.Text + "'," + textBox5.Text + ",'" + textBox8.Text + "','" + comboBox1.Text + "'" + ")";
                }
                cmd.CommandType = CommandType.Text; //검색명령을 쿼리 형태로
                cmd.Connection = conn1;
                cmd.ExecuteNonQuery(); //쿼리문을 실행하고 영향받는 행의 수를 반환.
                success();
                updatedb();
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

        private void Button5_Click(object sender, EventArgs e)
        {
            comboBox3.Items.Clear();
            conn1 = new OleDbConnection(connectionString1);
            try
            {
                conn1.Open(); //데이터베이스 연결
                OleDbCommand cmd = new OleDbCommand();

                cmd.CommandText = "SELECT * FROM" + " " + study + " " + "WHERE 교과목번호=" + textBox20.Text;
                cmd.CommandType = CommandType.Text; //검색명령을 쿼리 형태로
                cmd.Connection = conn1;
                cmd.ExecuteNonQuery(); //쿼리문을 실행하고 영향받는 행의 수를 반환.

                OleDbDataReader read = cmd.ExecuteReader(); //select * from emp 결과

                object[] obj = new object[7]; // 필드수만큼 오브젝트 배열
                for (int i = 0; i < 7; i++)
                {
                    obj[i] = read.GetName(i);
                }
                comboBox3.Items.AddRange(obj);
                read.Close();

                success();
                updatedb();
                if (conn1 != null)
                {

                    conn1.Close(); //데이터베이스 연결 해제
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex.Message); //에러 메세지 
            }
            finally
            {

            }
        }

        private void TextBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox17_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void button21_Click(object sender, EventArgs e)
        {
            conn1 = new OleDbConnection(connectionString1);
            try
            {
                conn1.Open(); //데이터베이스 연결
                OleDbCommand cmd = new OleDbCommand();
                
                cmd.CommandText = "INSERT INTO" + " " + professor + " " + "VALUES(" + "" + textBox17.Text + ",'" + textBox16.Text + "','" + textBox15.Text+"'" + ")";
                cmd.CommandType = CommandType.Text; //검색명령을 쿼리 형태로
                cmd.Connection = conn1;
                cmd.ExecuteNonQuery(); //쿼리문을 실행하고 영향받는 행의 수를 반환.
                success();
                updatedb();
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

        private void button2_Click(object sender, EventArgs e)
        {
            conn1 = new OleDbConnection(connectionString1);
            try
            {
                conn1.Open(); //데이터베이스 연결
                OleDbCommand cmd = new OleDbCommand();

                cmd.CommandText = "DELETE FROM" + " " + student + " " + "WHERE 학번="+textBox1.Text;
                cmd.CommandType = CommandType.Text; //검색명령을 쿼리 형태로
                cmd.Connection = conn1;
                cmd.ExecuteNonQuery(); //쿼리문을 실행하고 영향받는 행의 수를 반환.
                success();
                updatedb();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error"); //에러 메세지 
            }
            finally
            {
                if (conn1 != null)
                {
                    conn1.Close(); //데이터베이스 연결 해제
                }
            }
        }

        private void textBox14_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button20_Click(object sender, EventArgs e)
        {
            conn1 = new OleDbConnection(connectionString1);
            try
            {
                conn1.Open(); //데이터베이스 연결
                OleDbCommand cmd = new OleDbCommand();

                cmd.CommandText = "DELETE FROM" + " " + professor + " " + "WHERE 교수번호=" + textBox17.Text;
                cmd.CommandType = CommandType.Text; //검색명령을 쿼리 형태로
                cmd.Connection = conn1;
                cmd.ExecuteNonQuery(); //쿼리문을 실행하고 영향받는 행의 수를 반환.
                success();
                updatedb();
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

        private void button4_Click(object sender, EventArgs e)
        {
            comboBox3.Items.Clear();
            conn1 = new OleDbConnection(connectionString1);
            try
            {
                conn1.Open(); //데이터베이스 연결
                OleDbCommand cmd = new OleDbCommand();

                cmd.CommandText = "SELECT * FROM" + " " + student + " " + "WHERE 학번=" + textBox18.Text;
                cmd.CommandType = CommandType.Text; //검색명령을 쿼리 형태로
                cmd.Connection = conn1;
                cmd.ExecuteNonQuery(); //쿼리문을 실행하고 영향받는 행의 수를 반환.
               
                OleDbDataReader read = cmd.ExecuteReader(); //select * from emp 결과

               object[] obj = new object[9]; // 필드수만큼 오브젝트 배열
                for (int i = 0; i < 9; i++)
                {
                    obj[i]= read.GetName(i);
                }
               comboBox3.Items.AddRange(obj);
               read.Close();
               
               success();
               updatedb();
                if (conn1 != null)
                {
                    
                    conn1.Close(); //데이터베이스 연결 해제
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex.Message); //에러 메세지 
            }
            finally
            {
                
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

                cmd.CommandText = "SELECT * FROM" + " " + student + " " + "WHERE 학번=" + textBox18.Text;
                cmd.CommandType = CommandType.Text; //검색명령을 쿼리 형태로
                cmd.Connection = conn1;
                cmd.ExecuteNonQuery(); //쿼리문을 실행하고 영향받는 행의 수를 반환.
                OleDbDataReader read = cmd.ExecuteReader(); //select * from emp 결과
                dataGridView1.ColumnCount = 9;
                //필드명 받아오는 반복문
                for (int i = 0; i < 9; i++)
                {
                    dataGridView1.Columns[i].Name = read.GetName(i);
                }
                while (read.Read())
                {
                    object[] obj = new object[9]; // 필드수만큼 오브젝트 배열

                    for (int i = 0; i < 9; i++) // 필드 수만큼 반복
                    {
                        obj[i] = new object();
                        obj[i] = read.GetValue(i); // 오브젝트배열에 데이터 저장
                    }

                    dataGridView1.Rows.Add(obj); //데이터그리드뷰에 오브젝트 배열 추가
                }

                read.Close();
            
                success();
                updatedb();
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button19_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            conn1 = new OleDbConnection(connectionString1);
            try
            {
                conn1.Open(); //데이터베이스 연결
                OleDbCommand cmd = new OleDbCommand();

                cmd.CommandText = "SELECT * FROM" + " " + professor + " " + "WHERE 교수번호=" + textBox19.Text;
                cmd.CommandType = CommandType.Text; //검색명령을 쿼리 형태로
                cmd.Connection = conn1;
                cmd.ExecuteNonQuery(); //쿼리문을 실행하고 영향받는 행의 수를 반환.
                OleDbDataReader read = cmd.ExecuteReader(); //select * from emp 결과
                dataGridView1.ColumnCount = 9;
                //필드명 받아오는 반복문
                for (int i = 0; i < 3; i++)
                {
                    dataGridView1.Columns[i].Name = read.GetName(i);
                }
                while (read.Read())
                {
                    object[] obj = new object[9]; // 필드수만큼 오브젝트 배열

                    for (int i = 0; i < 3; i++) // 필드 수만큼 반복
                    {
                        obj[i] = new object();
                        obj[i] = read.GetValue(i); // 오브젝트배열에 데이터 저장
                    }

                    dataGridView1.Rows.Add(obj); //데이터그리드뷰에 오브젝트 배열 추가
                }

                read.Close();

                success();
                updatedb();
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

        private void SystemManager_Load(object sender, EventArgs e)
        {

        }

         private void button22_Click(object sender, EventArgs e)
        {
           
            conn1 = new OleDbConnection(connectionString1);
            try
            {
                conn1.Open(); //데이터베이스 연결
                OleDbCommand cmd = new OleDbCommand();
                
                if (comboBox3.Text=="학번") 
                {
                    cmd.CommandText = "UPDATE" + " " + student + " " + "SET" + " " + comboBox3.Text + "=" +textBox21.Text+" "+ "WHERE" + " " + "학번"+"="+textBox18.Text;
                    cmd.CommandType = CommandType.Text; //검색명령을 쿼리 형태로
                    cmd.Connection = conn1;
                    cmd.ExecuteNonQuery(); //쿼리문을 실행하고 영향받는 행의 수를 반환.
                }
                else if(comboBox3.Text=="교수번호")
                {
                    cmd.CommandText = "UPDATE" + " " + student + " " + "SET" + " " + comboBox3.Text + "=" + textBox21.Text + " " + "WHERE" + " " + "학번" + "=" + textBox18.Text;
                    cmd.CommandType = CommandType.Text; //검색명령을 쿼리 형태로
                    cmd.Connection = conn1;
                    cmd.ExecuteNonQuery(); //쿼리문을 실행하고 영향받는 행의 수를 반환.
                }
                else
                {
                    cmd.CommandText = "UPDATE" + " " + student + " " + "SET" + " " + comboBox3.Text + "=" +"'"+ textBox21.Text+"'" + " " + "WHERE" +" "+ "학번" + "=" + textBox18.Text;
                    cmd.CommandType = CommandType.Text; //검색명령을 쿼리 형태로
                    cmd.Connection = conn1;
                    cmd.ExecuteNonQuery(); //쿼리문을 실행하고 영향받는 행의 수를 반환.
                }
                success();
                updatedb();
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

        private void label31_Click(object sender, EventArgs e)
        {

        }

        private void button24_Click(object sender, EventArgs e)
        {
            conn1 = new OleDbConnection(connectionString1);
            try
            {
                conn1.Open(); //데이터베이스 연결
                OleDbCommand cmd = new OleDbCommand();

                if (comboBox3.Text == "교과목번호")
                {
                    cmd.CommandText = "UPDATE" + " " + study + " " + "SET" + " " + comboBox3.Text + "=" + textBox21.Text + " " + "WHERE" + " " + "교과목번호" + "=" + textBox20.Text;
                    cmd.CommandType = CommandType.Text; //검색명령을 쿼리 형태로
                    cmd.Connection = conn1;
                    cmd.ExecuteNonQuery(); //쿼리문을 실행하고 영향받는 행의 수를 반환.
                }
                else if (comboBox3.Text == "대상학년")
                {
                    cmd.CommandText = "UPDATE" + " " + study + " " + "SET" + " " + comboBox3.Text + "=" + textBox21.Text + " " + "WHERE" + " " + "교과목번호" + "=" + textBox20.Text;
                    cmd.CommandType = CommandType.Text; //검색명령을 쿼리 형태로
                    cmd.Connection = conn1;
                    cmd.ExecuteNonQuery(); //쿼리문을 실행하고 영향받는 행의 수를 반환.
                }
                else
                {
                    cmd.CommandText = "UPDATE" + " " + study + " " + "SET" + " " + comboBox3.Text + "=" + "'" + textBox21.Text + "'" + " " + "WHERE" + " " + "교과목번호" + "=" + textBox20.Text;
                    cmd.CommandType = CommandType.Text; //검색명령을 쿼리 형태로
                    cmd.Connection = conn1;
                    cmd.ExecuteNonQuery(); //쿼리문을 실행하고 영향받는 행의 수를 반환.
                }
                success();
                updatedb();
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

        private void button18_Click(object sender, EventArgs e)
        {
            comboBox3.Items.Clear();
            conn1 = new OleDbConnection(connectionString1);
            try
            {
                conn1.Open(); //데이터베이스 연결
                OleDbCommand cmd = new OleDbCommand();

                cmd.CommandText = "SELECT * FROM" + " " + professor + " " + "WHERE 교수번호=" + textBox19.Text;
                cmd.CommandType = CommandType.Text; //검색명령을 쿼리 형태로
                cmd.Connection = conn1;
                cmd.ExecuteNonQuery(); //쿼리문을 실행하고 영향받는 행의 수를 반환.

                OleDbDataReader read = cmd.ExecuteReader(); //select * from emp 결과

                object[] obj = new object[3]; // 필드수만큼 오브젝트 배열
                for (int i = 0; i < 3; i++)
                {
                    obj[i] = read.GetName(i);
                }
                comboBox3.Items.AddRange(obj);
                read.Close();

                success();
                updatedb();
                if (conn1 != null)
                {

                    conn1.Close(); //데이터베이스 연결 해제
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex.Message); //에러 메세지 
            }
            finally
            {

            }
        }

        private void button23_Click(object sender, EventArgs e)
        {
            conn1 = new OleDbConnection(connectionString1);
            try
            {
                conn1.Open(); //데이터베이스 연결
                OleDbCommand cmd = new OleDbCommand();

                if (comboBox3.Text == "교수번호")
                {
                    cmd.CommandText = "UPDATE" + " " + professor + " " + "SET" + " " + comboBox3.Text + "=" + textBox21.Text + " " + "WHERE" + " " + "교수번호" + "=" + textBox19.Text;
                    cmd.CommandType = CommandType.Text; //검색명령을 쿼리 형태로
                    cmd.Connection = conn1;
                    cmd.ExecuteNonQuery(); //쿼리문을 실행하고 영향받는 행의 수를 반환.
                }
                else
                {
                    cmd.CommandText = "UPDATE" + " " + professor + " " + "SET" + " " + comboBox3.Text + "=" + "'" + textBox21.Text + "'" + " " + "WHERE" + " " + "교수번호" + "=" + textBox19.Text;
                    cmd.CommandType = CommandType.Text; //검색명령을 쿼리 형태로
                    cmd.Connection = conn1;
                    cmd.ExecuteNonQuery(); //쿼리문을 실행하고 영향받는 행의 수를 반환.
                }
                success();
                updatedb();
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
            dataGridView2.Rows.Clear();
            conn1 = new OleDbConnection(connectionString1);
            try
            {
                conn1.Open(); //데이터베이스 연결
                OleDbCommand cmd = new OleDbCommand();

                cmd.CommandText = "SELECT * FROM" + " " + "수강";
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

        private void button10_Click(object sender, EventArgs e)
        {
            conn1 = new OleDbConnection(connectionString1);
            try
            {
                conn1.Open(); //데이터베이스 연결
                OleDbCommand cmd = new OleDbCommand();

                
               cmd.CommandText = "UPDATE" + " " + "수강" + " " + "SET" + " " + "수강상태" + "=" + 1 + " " + "WHERE" + " " + "학번" + "=" + textBox22.Text;
                    cmd.CommandType = CommandType.Text; //검색명령을 쿼리 형태로
                    cmd.Connection = conn1;
                    cmd.ExecuteNonQuery(); //쿼리문을 실행하고 영향받는 행의 수를 반환.

                success();
                updatedb();
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

        private void button11_Click(object sender, EventArgs e)
        {
            conn1 = new OleDbConnection(connectionString1);
            try
            {
                conn1.Open(); //데이터베이스 연결
                OleDbCommand cmd = new OleDbCommand();


                cmd.CommandText = "UPDATE" + " " + "수강" + " " + "SET" + " " + "수강상태" + "=" + 0 + " " + "WHERE" + " " + "학번" + "=" + textBox23.Text;
                cmd.CommandType = CommandType.Text; //검색명령을 쿼리 형태로
                cmd.Connection = conn1;
                cmd.ExecuteNonQuery(); //쿼리문을 실행하고 영향받는 행의 수를 반환.

                success();
                updatedb();
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

        private void button14_Click(object sender, EventArgs e)
        {
            conn1 = new OleDbConnection(connectionString1);
            try
            {
                conn1.Open(); //데이터베이스 연결
                OleDbCommand cmd = new OleDbCommand();


                cmd.CommandText = "UPDATE" + " " + "신청확인" + " " + "SET" + " " + "성적확인" + "=" + 1;
                cmd.CommandType = CommandType.Text; //검색명령을 쿼리 형태로
                cmd.Connection = conn1;
                cmd.ExecuteNonQuery(); //쿼리문을 실행하고 영향받는 행의 수를 반환.

                success();
                updatedb();
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

        private void button16_Click(object sender, EventArgs e)
        {
            conn1 = new OleDbConnection(connectionString1);
            try
            {
                conn1.Open(); //데이터베이스 연결
                OleDbCommand cmd = new OleDbCommand();


                cmd.CommandText = "UPDATE" + " " + "신청확인" + " " + "SET" + " " + "성적확인" + "=" + 0;
                cmd.CommandType = CommandType.Text; //검색명령을 쿼리 형태로
                cmd.Connection = conn1;
                cmd.ExecuteNonQuery(); //쿼리문을 실행하고 영향받는 행의 수를 반환.

                success();
                updatedb();
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

        private void button15_Click(object sender, EventArgs e)
        {
            conn1 = new OleDbConnection(connectionString1);
            try
            {
                conn1.Open(); //데이터베이스 연결
                OleDbCommand cmd = new OleDbCommand();


                cmd.CommandText = "UPDATE" + " " + "신청확인" + " " + "SET" + " " + "성적열람확인" + "=" + 1;
                cmd.CommandType = CommandType.Text; //검색명령을 쿼리 형태로
                cmd.Connection = conn1;
                cmd.ExecuteNonQuery(); //쿼리문을 실행하고 영향받는 행의 수를 반환.

                success();
                updatedb();
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

        private void button17_Click(object sender, EventArgs e)
        {
            conn1 = new OleDbConnection(connectionString1);
            try
            {
                conn1.Open(); //데이터베이스 연결
                OleDbCommand cmd = new OleDbCommand();


                cmd.CommandText = "UPDATE" + " " + "신청확인" + " " + "SET" + " " + "성적열람확인" + "=" + 0;
                cmd.CommandType = CommandType.Text; //검색명령을 쿼리 형태로
                cmd.Connection = conn1;
                cmd.ExecuteNonQuery(); //쿼리문을 실행하고 영향받는 행의 수를 반환.

                success();
                updatedb();
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

        private void button12_Click(object sender, EventArgs e)
        {
            conn1 = new OleDbConnection(connectionString1);
            try
            {
                conn1.Open(); //데이터베이스 연결
                OleDbCommand cmd = new OleDbCommand();


                cmd.CommandText = "UPDATE" + " " + "신청확인" + " " + "SET" + " " + "수강확인" + "=" + 1;
                cmd.CommandType = CommandType.Text; //검색명령을 쿼리 형태로
                cmd.Connection = conn1;
                cmd.ExecuteNonQuery(); //쿼리문을 실행하고 영향받는 행의 수를 반환.

                success();
                updatedb();
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

        private void button13_Click(object sender, EventArgs e)
        {
            conn1 = new OleDbConnection(connectionString1);
            try
            {
                conn1.Open(); //데이터베이스 연결
                OleDbCommand cmd = new OleDbCommand();


                cmd.CommandText = "UPDATE" + " " + "신청확인" + " " + "SET" + " " + "수강확인" + "=" + 0;
                cmd.CommandType = CommandType.Text; //검색명령을 쿼리 형태로
                cmd.Connection = conn1;
                cmd.ExecuteNonQuery(); //쿼리문을 실행하고 영향받는 행의 수를 반환.

                success();
                updatedb();
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
