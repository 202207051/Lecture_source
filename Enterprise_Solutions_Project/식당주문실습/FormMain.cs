using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace RestaurantOrderSystem
{
    public partial class FormMain : Form
    {
        private const string ConnStr =
            "Server=localhost;Port=3306;Database=Sample;Uid=root;Pwd=1234;";

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

                    // SQL 쿼리 수정 (띄어쓰기 및 menu_id 하이픈 수정)
                    string sqlSelect = "SELECT menu_id, menu_name, category, price FROM menu ORDER BY menu_id";
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
                                btn.Text = name + "\n" + price.ToString("N0") + "원"; // Name -> name 수정
                                btn.Font = new Font("맑은 고딕", 12, FontStyle.Bold);
                                btn.Size = new Size(panelPasta.Width, 80);
                                btn.Dock = DockStyle.Top;
                                btn.Margin = new Padding(10);
                                btn.Tag = new MenuInfo(id, name, category, price);
                                btn.Click += MenuButton_Click;

                                if (category == "파스타")
                                {
                                    panelPasta.Controls.Add(btn);
                                }
                                else
                                {
                                    panelPizza.Controls.Add(btn);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("DB 연결 오류: " + ex.Message);
            }
        }

        private void MenuButton_Click(object sender, EventArgs e)
        {
            MenuInfo menu = (MenuInfo)((Button)sender).Tag;

            // Select 조건을 문자열 포맷으로 수정
            DataRow[] rows = orderTable.Select($"menu_id = {menu.MenuId}");
            if (rows.Length > 0)
            {
                int q = (int)rows[0]["quantity"] + 1;
                rows[0]["quantity"] = q;
                rows[0]["amount"] = menu.Price * q;
            }
            else
            {
                DataRow row = orderTable.NewRow();
                row["menu_id"] = menu.MenuId;
                row["menu_name"] = menu.MenuName;
                row["price"] = menu.Price;
                row["quantity"] = 1;
                row["amount"] = menu.Price;
                orderTable.Rows.Add(row); // 행 추가 누락 수정
            }

            // 주문 목록 및 합계금액 갱신
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
            // orderTable 합계 계산 추가
            object sumObj = orderTable.Compute("SUM(amount)", "");
            return sumObj == DBNull.Value ? 0 : Convert.ToInt32(sumObj);
        }

        private void UpdateTotal()
        {
            lblTotal.Text = GetTotal().ToString("N0") + "원";
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            MessageBox.Show("btnOrder_Click()을 완성하세요.");
        }

        private void LoadSales(string period = "오늘")
        {
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
    }
}