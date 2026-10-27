using MySql.Data.MySqlClient;
using System.Data;
namespace RestaurantOrderSystem
{
    partial class FormMain
    {
        private System.ComponentModel.IContainer components = null;
        private Panel panelPasta, panelPizza;
        private ListView listViewOrder;
        private Label lblTotal, lblSales, lblPasta, lblPizza, lblOrder, lblSalesTitle;
        private Button btnDelete, btnClear, btnOrder, btnDay, btnWeek, btnMonth, btnYear;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            panelPasta = new Panel();
            panelPizza = new Panel();
            listViewOrder = new ListView();
            lblTotal = new Label();
            lblSales = new Label();
            lblPasta = new Label();
            lblPizza = new Label();
            lblOrder = new Label();
            lblSalesTitle = new Label();
            btnDelete = new Button();
            btnClear = new Button();
            btnOrder = new Button();
            btnDay = new Button();
            btnWeek = new Button();
            btnMonth = new Button();
            btnYear = new Button();
            SuspendLayout();
            // 
            // panelPasta
            // 
            panelPasta.AutoScroll = true;
            panelPasta.BorderStyle = BorderStyle.FixedSingle;
            panelPasta.Location = new Point(15, 60);
            panelPasta.Name = "panelPasta";
            panelPasta.Padding = new Padding(5);
            panelPasta.Size = new Size(650, 250);
            panelPasta.TabIndex = 1;
            
            // 
            // panelPizza
            // 
            panelPizza.AutoScroll = true;
            panelPizza.BorderStyle = BorderStyle.FixedSingle;
            panelPizza.Location = new Point(15, 370);
            panelPizza.Name = "panelPizza";
            panelPizza.Padding = new Padding(5);
            panelPizza.Size = new Size(650, 250);
            panelPizza.TabIndex = 3;
            // 
            // listViewOrder
            // 
            listViewOrder.FullRowSelect = true;
            listViewOrder.GridLines = true;
            listViewOrder.Location = new Point(685, 60);
            listViewOrder.Name = "listViewOrder";
            listViewOrder.Size = new Size(570, 330);
            listViewOrder.TabIndex = 5;
            listViewOrder.UseCompatibleStateImageBehavior = false;
            // 
            // lblTotal
            // 
            lblTotal.Font = new Font("맑은 고딕", 24F, FontStyle.Bold);
            lblTotal.Location = new Point(900, 395);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(355, 55);
            lblTotal.TabIndex = 6;
            lblTotal.Text = "0원";
            lblTotal.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblSales
            // 
            lblSales.Font = new Font("맑은 고딕", 15F, FontStyle.Bold);
            lblSales.Location = new Point(685, 665);
            lblSales.Name = "lblSales";
            lblSales.Size = new Size(570, 80);
            lblSales.TabIndex = 15;
            lblSales.Text = "오늘 매출 : 0원\r\n주문 건수 : 0건";
            
            // 
            // lblPasta
            // 
            lblPasta.Font = new Font("맑은 고딕", 18F, FontStyle.Bold);
            lblPasta.Location = new Point(20, 15);
            lblPasta.Name = "lblPasta";
            lblPasta.Size = new Size(400, 40);
            lblPasta.TabIndex = 0;
            lblPasta.Text = "🍝 파스타 메뉴";
            // 
            // lblPizza
            // 
            lblPizza.Font = new Font("맑은 고딕", 18F, FontStyle.Bold);
            lblPizza.Location = new Point(20, 325);
            lblPizza.Name = "lblPizza";
            lblPizza.Size = new Size(400, 40);
            lblPizza.TabIndex = 2;
            lblPizza.Text = "🍕 피자 메뉴";
            // 
            // lblOrder
            // 
            lblOrder.Font = new Font("맑은 고딕", 18F, FontStyle.Bold);
            lblOrder.Location = new Point(690, 15);
            lblOrder.Name = "lblOrder";
            lblOrder.Size = new Size(400, 40);
            lblOrder.TabIndex = 4;
            lblOrder.Text = "\U0001f6d2 현재 주문";
            // 
            // lblSalesTitle
            // 
            lblSalesTitle.Font = new Font("맑은 고딕", 18F, FontStyle.Bold);
            lblSalesTitle.Location = new Point(685, 545);
            lblSalesTitle.Name = "lblSalesTitle";
            lblSalesTitle.Size = new Size(300, 40);
            lblSalesTitle.TabIndex = 10;
            lblSalesTitle.Text = "📊 매출 조회";
            // 
            // btnDelete
            // 
            btnDelete.Font = new Font("맑은 고딕", 13F, FontStyle.Bold);
            btnDelete.Location = new Point(685, 460);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(175, 55);
            btnDelete.TabIndex = 7;
            btnDelete.Text = "선택 삭제";
            btnDelete.Click += btnDelete_Click;
            // 
            // btnClear
            // 
            btnClear.Font = new Font("맑은 고딕", 13F, FontStyle.Bold);
            btnClear.Location = new Point(875, 460);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(175, 55);
            btnClear.TabIndex = 8;
            btnClear.Text = "전체 삭제";
            btnClear.Click += btnClear_Click;
            // 
            // btnOrder
            // 
            btnOrder.Font = new Font("맑은 고딕", 15F, FontStyle.Bold);
            btnOrder.Location = new Point(1065, 460);
            btnOrder.Name = "btnOrder";
            btnOrder.Size = new Size(190, 55);
            btnOrder.TabIndex = 9;
            btnOrder.Text = "주문하기";
            btnOrder.Click += btnOrder_Click;
            // 
            // btnDay
            // 
            btnDay.Font = new Font("맑은 고딕", 12F, FontStyle.Bold);
            btnDay.Location = new Point(685, 595);
            btnDay.Name = "btnDay";
            btnDay.Size = new Size(125, 50);
            btnDay.TabIndex = 11;
            btnDay.Text = "오늘";
            btnDay.Click += btnDay_Click;
            // 
            // btnWeek
            // 
            btnWeek.Font = new Font("맑은 고딕", 12F, FontStyle.Bold);
            btnWeek.Location = new Point(825, 595);
            btnWeek.Name = "btnWeek";
            btnWeek.Size = new Size(125, 50);
            btnWeek.TabIndex = 12;
            btnWeek.Text = "이번 주";
            btnWeek.Click += btnWeek_Click;
            // 
            // btnMonth
            // 
            btnMonth.Font = new Font("맑은 고딕", 12F, FontStyle.Bold);
            btnMonth.Location = new Point(965, 595);
            btnMonth.Name = "btnMonth";
            btnMonth.Size = new Size(125, 50);
            btnMonth.TabIndex = 13;
            btnMonth.Text = "이번 달";
            btnMonth.Click += btnMonth_Click;
            // 
            // btnYear
            // 
            btnYear.Font = new Font("맑은 고딕", 12F, FontStyle.Bold);
            btnYear.Location = new Point(1105, 595);
            btnYear.Name = "btnYear";
            btnYear.Size = new Size(125, 50);
            btnYear.TabIndex = 14;
            btnYear.Text = "올해";
            btnYear.Click += btnYear_Click;
            // 
            // FormMain
            // 
            ClientSize = new Size(1280, 800);
            Controls.Add(lblPasta);
            Controls.Add(panelPasta);
            Controls.Add(lblPizza);
            Controls.Add(panelPizza);
            Controls.Add(lblOrder);
            Controls.Add(listViewOrder);
            Controls.Add(lblTotal);
            Controls.Add(btnDelete);
            Controls.Add(btnClear);
            Controls.Add(btnOrder);
            Controls.Add(lblSalesTitle);
            Controls.Add(btnDay);
            Controls.Add(btnWeek);
            Controls.Add(btnMonth);
            Controls.Add(btnYear);
            Controls.Add(lblSales);
            Font = new Font("맑은 고딕", 10F);
            MinimumSize = new Size(1100, 700);
            Name = "FormMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "🍝🍕 파스타 & 피자 키오스크";
            
            ResumeLayout(false);
        }
    }
}