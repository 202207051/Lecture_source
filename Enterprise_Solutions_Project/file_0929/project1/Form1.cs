using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Google.Protobuf;
using MySql.Data.MySqlClient;

namespace project1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // DB 연결 객체
        MySqlConnection conn = null;
        // 질의 객체   
        MySqlCommand cmd = null;
        // 레코드 리더 객체
        MySqlDataReader reader = null;

        // DB 연결 문자열
        string constring = "Server=127.0.0.1;Port=3306;Database=Sample;Uid=root;Pwd=1234;";

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtID.Text) || string.IsNullOrEmpty(txtpw.Text))
            {
                MessageBox.Show("Please enter both ID and Password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtID.Text = "";
                txtpw.Text = "";
                return;
            }

            try
            {
                conn = new MySqlConnection(constring);
                conn.Open();

                // ID와 패스워드가 일치하는 행만 조회하도록 쿼리 개선 (파라미터 사용 권장)
                string sqlSelect = "SELECT COUNT(*) FROM yuhan_user WHERE yuhan_id = @id AND yuhan_pw = @pw;";
                cmd = new MySqlCommand(sqlSelect, conn);

                // SQL Injection 방지를 위한 파라미터 추가
                cmd.Parameters.AddWithValue("@id", txtID.Text);
                cmd.Parameters.AddWithValue("@pw", txtpw.Text);

                // COUNT(*) 결과를 가져오기 위해 ExecuteScalar 사용
                long count = (long)cmd.ExecuteScalar();

                if (count > 0)
                {
                    MessageBox.Show("로그인 성공!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                    Form2 form2 = new Form2(this);
                    form2.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("로그인 실패: ID 또는 비밀번호가 올바르지 않습니다.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtID.Text = "";
                    txtpw.Text = "";
                    txtID.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("DB 연결 실패: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (conn != null && conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}