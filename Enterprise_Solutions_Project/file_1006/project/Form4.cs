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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        Form3 form3= null;
        TextBox txtSerch = null;
        public Form4(Form3 f, TextBox t)
        {
            InitializeComponent();
            form3 = f;
            txtSerch = t;
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            form3.Show();
            this.Close();
        }
    }
}
