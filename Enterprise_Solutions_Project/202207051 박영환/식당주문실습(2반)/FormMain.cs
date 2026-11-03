using MySql.Data.MySqlClient;
using System.ComponentModel;
using System.Data;
using System.Runtime.InteropServices.Marshalling;

namespace RestaurantOrderSystem
{
    public partial class FormMain : Form
    {
        private const string ConnStr =
            "Server=127.0.0.1;Port=3306;Database=Sample;Uid=root;Pwd=1234;";

        private DataTable orderTable = new DataTable();

        public FormMain()
        {
            InitializeComponent();
            MakeOrderTable();
            LoadMenu();
            UpdateTotal();
            LoadSales();
        }

        private void MakeOrderTable()
        {
            orderTable.Columns.Add("menu_id", typeof(int));
            orderTable.Columns.Add("menu_name", typeof(string));
            orderTable.Columns.Add("price", typeof(int));
            orderTable.Columns.Add("quantity", typeof(int));
            orderTable.Columns.Add("amount", typeof(int));

            listViewOrder.View = View.Details;
            listViewOrder.FullRowSelect = true;
            listViewOrder.GridLines = true;
            listViewOrder.Columns.Add("메뉴", 150);
            listViewOrder.Columns.Add("가격", 90);
            listViewOrder.Columns.Add("수량", 60);
            listViewOrder.Columns.Add("금액", 110);
        }

        private void LoadMenu()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(ConnStr))
                {
                    conn.Open();
                    string sqlSelect = "Select menu_id, menu_name, category, price from menu order by menu_id;";
                    using (MySqlCommand cmd = new MySqlCommand(sqlSelect, conn))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int id = reader.GetInt32("menu_id");
                                string name = reader.GetString("menu_name");
                                string category = reader.GetString("category");
                                int price = reader.GetInt32("price");

                                Button btn = new Button();
                                btn.Text = name + "\n" + price.ToString("N0") + "원";
                                btn.Font = new Font("맑은 고딕", 12, FontStyle.Bold);
                                btn.Size = new Size(panelPasta.Width, 80);
                                btn.Dock = DockStyle.Top;
                                btn.Margin = new Padding(10);
                                btn.Tag = new MenuInfo(id, name, category, price);
                                btn.Click += MenuButton_Click;

                                if (category == "파스타")
                                    panelPasta.Controls.Add(btn);
                                else
                                    panelPizza.Controls.Add(btn);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void MenuButton_Click(object sender, EventArgs e)
        {
            MenuInfo menu = (MenuInfo)((Button)sender).Tag;

            DataRow[] rows = orderTable.Select("menu_id=" + menu.MenuId);
            if (rows.Length > 0)
            {
                int q = (int)rows[0]["quantity"] + 1;
                rows[0]["quantity"] = q;
                rows[0]["amount"] = q * menu.Price;
            }
            else
            {
                DataRow row = orderTable.NewRow();
                row["menu_id"] = menu.MenuId;
                row["menu_name"] = menu.MenuName;
                row["price"] = menu.Price;
                row["quantity"] = 1;
                row["amount"] = menu.Price;
                orderTable.Rows.Add(row);
            }

            RefreshOrderList();
            UpdateTotal();
        }

        private void RefreshOrderList()
        {
            listViewOrder.Items.Clear();

            foreach (DataRow row in orderTable.Rows)
            {
                ListViewItem item = new ListViewItem(row["menu_name"].ToString());
                item.SubItems.Add(((int)row["price"]).ToString("N0") + "원");
                item.SubItems.Add(row["quantity"].ToString());
                item.SubItems.Add(((int)row["amount"]).ToString("N0") + "원");
                item.Tag = row["menu_id"];
                listViewOrder.Items.Add(item);
            }
        }

        private int GetTotal()
        {
            int total = 0;
            foreach (DataRow row in orderTable.Rows)
            {
                total = total + (int)row["amount"];
            }
            return total;
        }

        private void UpdateTotal()
        {
            lblTotal.Text = GetTotal().ToString("N0") + "원";
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (listViewOrder.SelectedItems.Count == 0)
            {
                MessageBox.Show("삭제할 메뉴를 선택하세요");
                return;
            }

            int menuId = (int)listViewOrder.SelectedItems[0].Tag;
            DataRow[] rows = orderTable.Select("menu_id=" + menuId);

            if (rows.Length > 0)
            {
                orderTable.Rows.Remove(rows[0]);
            }

            RefreshOrderList();
            UpdateTotal();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            orderTable.Clear();
            RefreshOrderList();
            UpdateTotal();
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            if (orderTable.Rows.Count == 0)
            {
                MessageBox.Show("메뉴를 선택하세요");
                return;
            }

            int total = GetTotal();

            try
            {
                using (MySqlConnection conn = new MySqlConnection(ConnStr))
                {
                    conn.Open();
                    using (MySqlTransaction tran = conn.BeginTransaction())
                    {
                        try
                        {
                            string sqlInsert = "INSERT INTO orders (order_price, order_date) VALUES (@total, NOW()); SELECT LAST_INSERT_ID();";
                            int orderID;
                            using (MySqlCommand cmd = new MySqlCommand(sqlInsert, conn, tran))
                            {
                                cmd.Parameters.AddWithValue("@total", total);
                                orderID = Convert.ToInt32(cmd.ExecuteScalar());
                            }

                            string sqlInsertDetail = "INSERT INTO order_detail (order_id, menu_id, quantity, price) VALUES (@order_id, @menu_id, @quantity, @price);";
                            using (MySqlCommand cmd2 = new MySqlCommand(sqlInsertDetail, conn, tran))
                            {
                                foreach (DataRow row in orderTable.Rows)
                                {
                                    cmd2.Parameters.Clear();
                                    cmd2.Parameters.AddWithValue("@order_id", orderID);
                                    cmd2.Parameters.AddWithValue("@menu_id", row["menu_id"]);
                                    cmd2.Parameters.AddWithValue("@quantity", row["quantity"]);
                                    cmd2.Parameters.AddWithValue("@price", row["price"]);
                                    cmd2.ExecuteNonQuery();
                                }
                            }

                            tran.Commit();
                            MessageBox.Show($"주문이 완료되었습니다.\n주문번호:{orderID}\n금액:{total}원");

                            orderTable.Clear();
                            RefreshOrderList();
                            UpdateTotal();
                            LoadSales();
                        }
                        catch (Exception innerEx)
                        {
                            tran.Rollback();
                            MessageBox.Show("주문 처리 오류: " + innerEx.Message);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("DB 연결 실패: " + ex.Message);
            }
        }

        private void LoadSales(string period = "오늘")
        {
            string where = "";
            if (period == "오늘")
            {
                where = "DATE(order_date) = CURDATE()";
            }
            else if (period == "이번 주")
            {
                where = "YEARWEEK(order_date, 1) = YEARWEEK(CURDATE(), 1)";
            }
            else if (period == "이번 달")
            {
                where = "YEAR(order_date) = YEAR(CURDATE()) AND MONTH(order_date) = MONTH(CURDATE())";
            }
            else if (period == "올해")
            {
                where = "YEAR(order_date) = YEAR(CURDATE())";
            }

            try
            {
                using (MySqlConnection conn = new MySqlConnection(ConnStr))
                {
                    conn.Open();
                    string sqlSelect = $"SELECT IFNULL(SUM(order_price), 0) AS sales, COUNT(*) AS order_count FROM orders WHERE {where};";
                    using (MySqlCommand cmd = new MySqlCommand(sqlSelect, conn))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                double sales = reader.GetDouble("sales");
                                long count = reader.GetInt64("order_count");
                                lblSales.Text = $"[{period}] 매출: {sales:N0}원, 주문건수: {count}건";
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("매출 조회 오류: " + ex.Message);
            }
        }

        private void btnDay_Click(object sender, EventArgs e)
        {
            LoadSales("오늘");
        }

        private void btnWeek_Click(object sender, EventArgs e)
        {
            LoadSales("이번 주");
        }

        private void btnMonth_Click(object sender, EventArgs e)
        {
            LoadSales("이번 달");
        }

        private void btnYear_Click(object sender, EventArgs e)
        {
            LoadSales("올해");
        }

        private class MenuInfo
        {
            public int MenuId;
            public string MenuName;
            public string Category;
            public int Price;

            public MenuInfo(int id, string name, string category, int price)
            {
                MenuId = id;
                MenuName = name;
                Category = category;
                Price = price;
            }
        }

        private void FormMain_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}