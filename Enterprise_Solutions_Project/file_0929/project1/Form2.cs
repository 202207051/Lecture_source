using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project1
{
    public partial class Form2 : Form
    {
        // Form1의 인스턴스를 저장할 필드 선언
        Form1 f;

        // 기본 생성자 (필요할 경우를 대비해 유지)
        public Form2()
        {
            InitializeComponent();
        }

        // Form1에서 넘겨받은 인스턴스를 초기화하는 생성자
        public Form2(Form1 loginForm)
        {
            InitializeComponent();
            f = loginForm; // 전달받은 Form1 객체를 필드에 저장
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 로그아웃 또는 뒤로가기 버튼 클릭 시
            this.Hide();
            if (f != null)
            {
                f.Show(); // 숨겨두었던 Form1(로그인 화면)을 다시 표시
            }
            this.Close(); // Form2를 완전히 닫음
        }
    }
}