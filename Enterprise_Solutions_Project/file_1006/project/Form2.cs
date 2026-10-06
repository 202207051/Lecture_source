using System;
using System.Drawing;
using System.Windows.Forms;

namespace project
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();

        }

        Form1 form1 = null;
        public Form2(Form1 f)
        {
            InitializeComponent();
            form1 = f;
        }

        private void pictureCar_Click(object sender, EventArgs e)
        {

        }

        private void btnReturnFirst_Click(object sender, EventArgs e)
        {
            this.Hide();
            form1.Show();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void btnSerchPic_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Image Files(*.jpg;*.png; *.jpeg; *.gif; *.bmp)|*.jpg; *.png; *.jpeg; *.gif; *.bmp";
            openFileDialog1.FileName = "";
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                pictureCar.Image = Image.FromFile(openFileDialog1.FileName);
                lblInTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                txtCarName.Focus();
            }

        }
    }
}
