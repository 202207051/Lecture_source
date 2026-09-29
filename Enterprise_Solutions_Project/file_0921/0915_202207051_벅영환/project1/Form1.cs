using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace project1
{
    public partial class Form1 : Form
    {
        // 연결 문자열을 클래스 상단 변수로 통일하여 관리
        private string connString = "Server=127.0.0.1;Port=3306;Database=sample;Uid=root;pwd=1234;";

        public Form1()
        {
            InitializeComponent();
        }

        private void groupBox2_Enter(object sender, EventArgs e) { }
        private void textBox2_TextChanged(object sender, EventArgs e) { }
        private void textBoxName_TextChanged(object sender, EventArgs e) { }
        private void groupBox1_Enter(object sender, EventArgs e) { }

        // 조회 (버튼 5번)
        private void button5_Click(object sender, EventArgs e)
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    // 매번 조회할 때마다 "Connection Successful" 팝업이 뜨면 불편하므로 제거하거나 주석 처리하는 것이 좋습니다.
                    // MessageBox.Show("Connection Successful");

                    string sqlSelect = "SELECT * FROM Info_Table";
                    using (MySqlCommand cmd = new MySqlCommand(sqlSelect, conn))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            listViewPhoneBook.Items.Clear();
                            while (reader.Read())
                            {
                                ListViewItem item = new ListViewItem();
                                item.Text = reader["id"].ToString();
                                item.SubItems.Add(reader["name"].ToString());
                                item.SubItems.Add(reader["phone"].ToString());
                                listViewPhoneBook.Items.Add(item);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        // 추가
        private void buttonInsert_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxName.Text) || string.IsNullOrWhiteSpace(textBoxPhone.Text))
            {
                MessageBox.Show("Please enter both name and phone number.");
                textBoxName.Focus();
                return;
            }

            try
            {
                string sqlInsert = "INSERT INTO Info_Table (name, phone) VALUES (@name, @phone)";

                using (MySqlConnection conn = new MySqlConnection(connString))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(sqlInsert, conn))
                    {
                        cmd.Parameters.AddWithValue("@name", textBoxName.Text);
                        cmd.Parameters.AddWithValue("@phone", textBoxPhone.Text);
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Insert Successful");

                // 입력 창 초기화 및 목록 새로고침
                textBoxName.Clear();
                textBoxPhone.Clear();
                button5_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        // 수정
        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            if (listViewPhoneBook.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select an item to update from the list.");
                return;
            }

            if (string.IsNullOrWhiteSpace(textBoxName.Text) || string.IsNullOrWhiteSpace(textBoxPhone.Text))
            {
                MessageBox.Show("Please enter both name and phone number.");
                textBoxName.Focus();
                return;
            }

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connString))
                {
                    conn.Open();
                    int index = int.Parse(listViewPhoneBook.SelectedItems[0].Text);

                    string sqlUpdate = "UPDATE Info_Table SET name=@name, phone=@phone WHERE id=@id";

                    using (MySqlCommand cmd = new MySqlCommand(sqlUpdate, conn))
                    {
                        cmd.Parameters.AddWithValue("@name", textBoxName.Text);
                        cmd.Parameters.AddWithValue("@phone", textBoxPhone.Text);
                        cmd.Parameters.AddWithValue("@id", index);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Update Successful");
                    }
                }

                // 목록 새로고침
                button5_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        // 삭제
        private void bottonDelete_Click(object sender, EventArgs e)
        {
            if (listViewPhoneBook.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select an item to delete from the list.");
                return;
            }

            try
            {
                // 하드코딩된 연결 문자열 대신 공통 변수(connString) 사용
                using (MySqlConnection conn = new MySqlConnection(connString))
                {
                    conn.Open();
                    int index = int.Parse(listViewPhoneBook.SelectedItems[0].Text);

                    string sqlDelete = "DELETE FROM Info_Table WHERE id=@id";
                    using (MySqlCommand cmd = new MySqlCommand(sqlDelete, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", index);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Delete Successful");
                    }
                }

                // 삭제 후 목록 자동 갱신 추가
                button5_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}