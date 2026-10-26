using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        Form1 form1 = null;
        public Form3(Form1 f)
        {
            InitializeComponent();
            form1 = f;
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnReturnFirst_Click(object sender, EventArgs e)
        {
            // 현재 창을 숨기고 첫 첫화면이 나오도록한다.
            this.Hide();    
            form1.Show();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4(this, txtSearch);
            form4.Show();
            this.Hide();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
