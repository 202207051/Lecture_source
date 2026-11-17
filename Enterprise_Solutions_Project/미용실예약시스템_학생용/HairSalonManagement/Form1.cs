using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
//학생용 실습자료
namespace HairSalonManagement
{
    public class Form1 : Form
    {
        private TextBox txtName;
        private TextBox txtPhone;
        private TextBox txtPrice;
        private ComboBox cboDesigner;
        private ComboBox cboService;
        private ComboBox cboTime;
        private DateTimePicker dtpDate;
        private ListView listView1;
        private Label lblMessage;

        private int selectedId;

        public Form1()
        {
            CreateUI();//화면구성
            LoadDesigner();//cboDesigner 컨트롤에 디자이너의 이름이 출력하는 메서드
            LoadService();//cboService 컨트롤에 서비스 이름 출력하는 메서드
            LoadTime();//cboTime 컨트롤에 시간 출력(9:00 ~ 19:00)하는 메서드
            LoadReservation();//예약상태를 출력하는 메서드
        }

        private void CreateUI()
        {
            //화면 만들기
            Text = "미용실 예약 관리 시스템";
            StartPosition = FormStartPosition.CenterScreen;
            Size = new Size(1160, 790);
            MinimumSize = new Size(1160, 790);
            BackColor = Color.FromArgb(245, 247, 250);
            Font = new Font("맑은 고딕", 9F);

            Label title = new Label();
            title.Text = "HAIR SALON  |  예약 관리 시스템";
            title.Font = new Font("맑은 고딕", 21F, FontStyle.Bold);
            title.ForeColor = Color.FromArgb(48, 63, 95);
            title.Location = new Point(25, 18);
            title.Size = new Size(700, 42);
            Controls.Add(title);

            Label subTitle = new Label();
            subTitle.Text = "고객 · 디자이너 · 예약 일정 통합 관리";
            subTitle.ForeColor = Color.DimGray;
            subTitle.Location = new Point(29, 61);
            subTitle.Size = new Size(500, 24);
            Controls.Add(subTitle);

            GroupBox searchGroup = new GroupBox();
            searchGroup.Text = "예약 날짜 조회";
            searchGroup.Location = new Point(25, 95);
            searchGroup.Size = new Size(1090, 65);
            Controls.Add(searchGroup);

            AddLabel(searchGroup, "예약 날짜", 18, 25, 80);
            dtpDate = new DateTimePicker();
            dtpDate.Format = DateTimePickerFormat.Short;
            dtpDate.Location = new Point(105, 22);
            dtpDate.Size = new Size(150, 27);
            searchGroup.Controls.Add(dtpDate);

            Button btnSearch = AddButton(searchGroup, "날짜별 조회", 275, 19, 115, 32);
            btnSearch.Click += delegate { selectedId = 0; LoadReservation(); };

            Button btnAll = AddButton(searchGroup, "전체 예약", 400, 19, 105, 32);
            btnAll.Click += delegate { LoadReservation(true); };

            GroupBox inputGroup = new GroupBox();
            inputGroup.Text = "예약 정보 입력";
            inputGroup.Location = new Point(25, 175);
            inputGroup.Size = new Size(1090, 205);
            Controls.Add(inputGroup);

            AddLabel(inputGroup, "고객명", 20, 38, 75);
            txtName = AddTextBox(inputGroup, 100, 34, 185);

            AddLabel(inputGroup, "전화번호", 315, 38, 75);
            txtPhone = AddTextBox(inputGroup, 395, 34, 185);

            AddLabel(inputGroup, "디자이너", 20, 88, 75);
            cboDesigner = AddComboBox(inputGroup, 100, 84, 185);

            AddLabel(inputGroup, "시술 종류", 315, 88, 75);
            cboService = AddComboBox(inputGroup, 395, 84, 185);
            cboService.SelectedIndexChanged += CboService_SelectedIndexChanged;

            AddLabel(inputGroup, "시술 금액", 20, 138, 75);
            txtPrice = AddTextBox(inputGroup, 100, 134, 185);
            txtPrice.ReadOnly = true;
            txtPrice.BackColor = Color.WhiteSmoke;

            AddLabel(inputGroup, "예약 시간", 315, 138, 75);
            cboTime = AddComboBox(inputGroup, 395, 134, 185);

            Button btnReserve = AddButton(inputGroup, "예약 등록", 650, 32, 115, 38);
            Button btnUpdate = AddButton(inputGroup, "예약 변경", 780, 32, 115, 38);
            Button btnCancel = AddButton(inputGroup, "예약 취소", 910, 32, 115, 38);
            Button btnComplete = AddButton(inputGroup, "시술 완료", 650, 88, 115, 38);
            Button btnClear = AddButton(inputGroup, "입력 초기화", 780, 88, 115, 38);

            btnReserve.Click += BtnReserve_Click;
            btnUpdate.Click += BtnUpdate_Click;
            btnCancel.Click += BtnCancel_Click;
            btnComplete.Click += BtnComplete_Click;
            btnClear.Click += delegate { ClearInput(); };

            lblMessage = new Label();
            lblMessage.Text = "예약 목록에서 항목을 선택하면 입력란에 정보가 표시됩니다.";
            lblMessage.ForeColor = Color.DimGray;
            lblMessage.Location = new Point(650, 145);
            lblMessage.Size = new Size(390, 30);
            inputGroup.Controls.Add(lblMessage);

            GroupBox listGroup = new GroupBox();
            listGroup.Text = "예약 현황";
            listGroup.Location = new Point(25, 395);
            listGroup.Size = new Size(1090, 335);
            Controls.Add(listGroup);

            listView1 = new ListView();
            listView1.Location = new Point(15, 27);
            listView1.Size = new Size(1060, 292);
            listView1.View = View.Details;
            listView1.FullRowSelect = true;
            listView1.GridLines = true;
            listView1.MultiSelect = false;
            listView1.HideSelection = false;
            listView1.Columns.Add("예약번호", 75);
            listView1.Columns.Add("고객명", 90);
            listView1.Columns.Add("연락처", 125);
            listView1.Columns.Add("디자이너", 95);
            listView1.Columns.Add("시술명", 115);
            listView1.Columns.Add("금액", 90);
            listView1.Columns.Add("예약일", 110);
            listView1.Columns.Add("시간", 85);
            listView1.Columns.Add("상태", 85);
            listView1.SelectedIndexChanged += ListView1_SelectedIndexChanged;
            listGroup.Controls.Add(listView1);
        }

        private void AddLabel(Control parent, string text, int x, int y, int width)
        {
            Label label = new Label();
            label.Text = text;
            label.Location = new Point(x, y);
            label.Size = new Size(width, 27);
            label.TextAlign = ContentAlignment.MiddleLeft;
            parent.Controls.Add(label);
        }

        private TextBox AddTextBox(Control parent, int x, int y, int width)
        {
            TextBox box = new TextBox();
            box.Location = new Point(x, y);
            box.Size = new Size(width, 27);
            parent.Controls.Add(box);
            return box;
        }

        private ComboBox AddComboBox(Control parent, int x, int y, int width)
        {
            ComboBox combo = new ComboBox();
            combo.Location = new Point(x, y);
            combo.Size = new Size(width, 27);
            combo.DropDownStyle = ComboBoxStyle.DropDownList;
            parent.Controls.Add(combo);
            return combo;
        }

        private Button AddButton(Control parent, string text, int x, int y, int width, int height)
        {
            Button button = new Button();
            button.Text = text;
            button.Location = new Point(x, y);
            button.Size = new Size(width, height);
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderColor = Color.FromArgb(190, 200, 215);
            button.BackColor = Color.FromArgb(225, 233, 245);
            button.ForeColor = Color.FromArgb(40, 55, 80);
            parent.Controls.Add(button);
            return button;
        }

        private void LoadDesigner()
        {
            using (MySqlConnection conn = DBManager.GetConnection())
            {
                conn.Open();
                string sql = "SELECT designer_id, designer_name FROM Designer " +
                             "ORDER BY designer_id";
                //select문의 결과 전체를 관리하는MySqlDataAdapter 객체 생성
                //DataTable 객체를 만들고 MySqlDataAdaper 객체 정보를 저장
                //cboDesigner 컨트롤에 디자이너들의 아이디와 이름이 출력하도록 함                
            }
        }

        private void LoadService()
        {
            //cboService 컨트롤에 서비스 이름 출력하는 메서드
            
        }

        private void LoadTime()
        {
            //cboTime 컨트롤에 시간 출력하는 메서드(09:00~19:00)
        }

        private void CboService_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cboService.Text)
            {
                case "남성 커트": 
                    txtPrice.Text = "20000"; 
                    break;
                case "여성 커트": 
                    txtPrice.Text = "25000"; 
                    break;
                case "일반 펌": 
                    txtPrice.Text = "80000"; 
                    break;
                case "디지털 펌": 
                    txtPrice.Text = "120000"; 
                    break;
                case "전체 염색": 
                    txtPrice.Text = "70000"; 
                    break;
                case "뿌리 염색": 
                    txtPrice.Text = "40000"; 
                    break;
                case "클리닉": 
                    txtPrice.Text = "50000"; 
                    break;
                default: 
                    txtPrice.Clear();
                    break;
            }
        }

        private bool CheckInput()
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("고객명을 입력하세요.");
                txtName.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                MessageBox.Show("전화번호를 입력하세요.");
                txtPhone.Focus();
                return false;
            }

            if (cboDesigner.SelectedValue == null ||
                cboService.SelectedItem == null ||
                cboTime.SelectedItem == null)
            {
                MessageBox.Show("디자이너, 시술, 예약 시간을 선택하세요.");
                return false;
            }

            return true;
        }

        private int GetCustomerId(MySqlConnection conn)
        {
            return 1;
        }

        private bool IsDuplicate(MySqlConnection conn, int designerId, DateTime date, TimeSpan time, int exceptReservationId)
        {
            return true;
        }

        private void BtnReserve_Click(object sender, EventArgs e)
        {
            if (!CheckInput())//고객명과 전화번호를 입력 안하면 진행 안함
                return;

            try
            {
                using (MySqlConnection conn = DBManager.GetConnection())
                {
                    conn.Open();
                    int customerId = GetCustomerId(conn);
                    int designerId = Convert.ToInt32(cboDesigner.SelectedValue);
                    DateTime date = dtpDate.Value.Date;
                    TimeSpan time = TimeSpan.Parse(cboTime.Text);

                    if (IsDuplicate(conn, designerId, date, time, 0))
                    {
                        MessageBox.Show("해당 디자이너는 이미 예약된 시간입니다.");
                        return;
                    }

                    string sql = @"
                        INSERT INTO Reservation
                        (customer_id, designer_id, service_name, price,
                         reservation_date, reservation_time, status)
                        VALUES
                        (@customer, @designer, @service, @price,
                         @date, @time, '예약')";

                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@customer", customerId);
                        cmd.Parameters.AddWithValue("@designer", designerId);
                        cmd.Parameters.AddWithValue("@service", cboService.Text);
                        cmd.Parameters.AddWithValue("@price", Convert.ToInt32(txtPrice.Text));
                        cmd.Parameters.AddWithValue("@date", date);
                        cmd.Parameters.AddWithValue("@time", time);
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("예약이 등록되었습니다.");
                LoadReservation();
                ClearInput();
            }
            catch (Exception ex)
            {
                MessageBox.Show("예약 등록 오류: " + ex.Message);
            }
        }

        private void LoadReservation(bool showAll = false)
        {
            //예약상태를 불러오는 메서드
            listView1.Items.Clear();

            try
            {
                using (MySqlConnection conn = DBManager.GetConnection())
                {
                    conn.Open();
                    //예약 테이블을 중심으로 고객 테이블과 디자이너 테이블을 INNER JOIN하여
                    //예약번호, 고객정보, 담당 디자이너, 시술내용, 가격, 예약일시 및 예약상태를
                    //한 번에 조회하는 select문
                    string sql = @"
                        SELECT r.reservation_id, c.customer_name, c.phone,
                               d.designer_name, r.service_name, r.price,
                               r.reservation_date, r.reservation_time, r.status
                        FROM Reservation r
                        INNER JOIN Customer c ON r.customer_id = c.customer_id
                        INNER JOIN Designer d ON r.designer_id = d.designer_id";

                    if (!showAll)//전체예약보기가 아니면 날짜별로 조회하기 위한 where절
                        sql += " WHERE r.reservation_date = @date";
                    //예약날짜로 1차 정렬, 같은 날짜는 예약시간으로 2차 정렬
                    sql += " ORDER BY r.reservation_date, r.reservation_time";

                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        //select문의 결과를 listView에 출력
                    }
                }

                lblMessage.Text = showAll
                    ? "전체 예약을 조회했습니다."
                    : dtpDate.Value.ToString("yyyy-MM-dd") + " 예약을 조회했습니다.";
            }
            catch (Exception ex)
            {
                MessageBox.Show("예약 조회 오류: " + ex.Message);
            }
        }

        private void ListView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
                return;

            ListViewItem item = listView1.SelectedItems[0];
            selectedId = Convert.ToInt32(item.Text);

            txtName.Text = item.SubItems[1].Text;
            txtPhone.Text = item.SubItems[2].Text;
            cboDesigner.Text = item.SubItems[3].Text;
            cboService.Text = item.SubItems[4].Text;
            dtpDate.Value = DateTime.Parse(item.SubItems[6].Text);
            cboTime.Text = item.SubItems[7].Text;
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedId == 0)
            {
                MessageBox.Show("변경할 예약을 목록에서 선택하세요.");
                return;
            }

            if (!CheckInput())
                return;

            try
            {
                using (MySqlConnection conn = DBManager.GetConnection())
                {
                    conn.Open();

                    int designerId = Convert.ToInt32(cboDesigner.SelectedValue);
                    DateTime date = dtpDate.Value.Date;
                    TimeSpan time = TimeSpan.Parse(cboTime.Text);

                    if (IsDuplicate(conn, designerId, date, time, selectedId))
                    {
                        MessageBox.Show("해당 디자이너는 이미 예약된 시간입니다.");
                        return;
                    }

                    int customerId = GetCustomerId(conn);
                    string sql = @"
                        UPDATE Reservation
                        SET customer_id = @customer,
                            designer_id = @designer,
                            service_name = @service,
                            price = @price,
                            reservation_date = @date,
                            reservation_time = @time
                        WHERE reservation_id = @id AND status = '예약'";

                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        //질의문의 매개변수를 연결하고 update문 실행
                    }
                }

                MessageBox.Show("예약이 변경되었습니다.");
                LoadReservation();
                ClearInput();
            }
            catch (Exception ex)
            {
                MessageBox.Show("예약 변경 오류: " + ex.Message);
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            //취소버튼
        }

        private void BtnComplete_Click(object sender, EventArgs e)
        {
            //시술완료 버튼
        }

        private void UpdateStatus(string status)
        {
            try
            {
                using (MySqlConnection conn = DBManager.GetConnection())
                {
                    conn.Open();
                    string sql = "UPDATE Reservation SET status = @status WHERE reservation_id = @id AND status = '예약'";

                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        //매개변수연결하고 update문 실행
                    }
                }

                MessageBox.Show("예약 상태가 '" + status + "'로 변경되었습니다.");
                LoadReservation();
                ClearInput();
            }
            catch (Exception ex)
            {
                MessageBox.Show("상태 변경 오류: " + ex.Message);
            }
        }

        private void ClearInput()
        {
            txtName.Clear();
            txtPhone.Clear();

            if (cboDesigner.Items.Count > 0)
                cboDesigner.SelectedIndex = 0;
            if (cboService.Items.Count > 0)
                cboService.SelectedIndex = 0;
            if (cboTime.Items.Count > 0)
                cboTime.SelectedIndex = 0;

            selectedId = 0;
            listView1.SelectedItems.Clear();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(282, 253);
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
