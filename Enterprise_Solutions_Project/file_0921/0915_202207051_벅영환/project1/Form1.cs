using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32.SafeHandles;
using MySql.Data.MySqlClient;
using Mysqlx.Connection;

namespace project1
{
    public partial class Form1 : Form
    {
        private string connString = "Server=127.0.0.1;Port=3306;Database=sample;Uid=root;pwd=1234;";

        public Form1()
        {
            InitializeComponent();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            using (MySqlConnection conn = new MySqlConnection(connString))
            {
                try
                {
                    if (textBoxName.Text == "" || textBoxPhone.Text == "")
                    {
                        MessageBox.Show("Please enter both name and phone number.");
                        textBoxName.Focus();
                        return;
                    }
                    conn.Open();
                    MessageBox.Show("Connection Successful");
                    MySqlCommand cmd = new MySqlCommand("select * from Info_Table", conn);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    listViewPhoneBook.Items.Clear();
                    while (reader.Read())
                    {
                        ListViewItem item = new ListViewItem();
                        item.Text = reader["id"].ToString();
                        item.SubItems.Add(reader["name"].ToString());
                        item.SubItems.Add(reader["phone"].ToString());
                        listViewPhoneBook.Items.Add(item);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxName_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void buttonInsert_Click(object sender, EventArgs e)
        {
            try
            {
                string sqlInsert = "INSERT INTO Info_Table (name, phone) VALUES (@name, @phone)";

                using (MySqlConnection conn = new MySqlConnection(connString))
                {
                    conn.Open();
                    MessageBox.Show("Connection Successful");

                    using (MySqlCommand cmd = new MySqlCommand(sqlInsert, conn))
                    {
                        cmd.Parameters.AddWithValue("@name", textBoxName.Text);
                        cmd.Parameters.AddWithValue("@phone", textBoxPhone.Text);
                        cmd.ExecuteNonQuery();
                    }
                }
                button5_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (listViewPhoneBook.SelectedIndices.Count == 0)
                {
                    MessageBox.Show("Please select an item to update from the list.");
                    return;
                }

                if (textBoxName.Text == "" || textBoxPhone.Text == "")
                {
                    MessageBox.Show("Please enter both name and phone number.");
                    textBoxName.Focus();
                    return;
                }

                using (MySqlConnection conn = new MySqlConnection(connString))
                {
                    conn.Open();
                    int pos = listViewPhoneBook.SelectedIndices[0];
                    int index = int.Parse(listViewPhoneBook.Items[pos].Text);

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

                button5_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void bottonDelete_Click(object sender, EventArgs e)
        {
            using (MySqlConnection conn = new MySqlConnection("Server = 127.0.0.1; Port = 3306; Database = sample; Uid = root; pwd = 1234;"))
            {
                try
                {
                    conn.Open();
                    int pos = listViewPhoneBook.SelectedItems[0].Index;
                    int index = int.Parse(listViewPhoneBook.Items[pos].Text);

                    string sqlDelete = "DELETE FROM Info_Table WHERE id=@id";
                    MySqlCommand cmd = new MySqlCommand(sqlDelete, conn);
                    cmd.Parameters.AddWithValue("@id", index);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Delete Successful");
                }

                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }

        }
    }
}