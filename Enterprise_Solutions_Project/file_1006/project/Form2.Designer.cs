namespace project
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureCar = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblInTime = new System.Windows.Forms.Label();
            this.btnSerchPic = new System.Windows.Forms.Button();
            this.btnInsert = new System.Windows.Forms.Button();
            this.btnReturnFirst = new System.Windows.Forms.Button();
            this.cboCategory = new System.Windows.Forms.ComboBox();
            this.txtCarName = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.pictureCar)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureCar
            // 
            this.pictureCar.Location = new System.Drawing.Point(55, 59);
            this.pictureCar.Name = "pictureCar";
            this.pictureCar.Size = new System.Drawing.Size(302, 396);
            this.pictureCar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureCar.TabIndex = 0;
            this.pictureCar.TabStop = false;
            this.pictureCar.Click += new System.EventHandler(this.pictureCar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(406, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "차량 구분 : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(406, 116);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "차량 번호 : ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(406, 173);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 19);
            this.label3.TabIndex = 3;
            this.label3.Text = "입차 시간 : ";
            // 
            // lblInTime
            // 
            this.lblInTime.AutoSize = true;
            this.lblInTime.Location = new System.Drawing.Point(522, 173);
            this.lblInTime.Name = "lblInTime";
            this.lblInTime.Size = new System.Drawing.Size(315, 19);
            this.lblInTime.TabIndex = 4;
            this.lblInTime.Text = "사진을 선택하면 시간이 보입니다.";
            // 
            // btnSerchPic
            // 
            this.btnSerchPic.Location = new System.Drawing.Point(410, 235);
            this.btnSerchPic.Name = "btnSerchPic";
            this.btnSerchPic.Size = new System.Drawing.Size(175, 91);
            this.btnSerchPic.TabIndex = 5;
            this.btnSerchPic.Text = "사진 찾기";
            this.btnSerchPic.UseVisualStyleBackColor = true;
            this.btnSerchPic.Click += new System.EventHandler(this.btnSerchPic_Click);
            // 
            // btnInsert
            // 
            this.btnInsert.Location = new System.Drawing.Point(662, 235);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(175, 91);
            this.btnInsert.TabIndex = 6;
            this.btnInsert.Text = "입차";
            this.btnInsert.UseVisualStyleBackColor = true;
            // 
            // btnReturnFirst
            // 
            this.btnReturnFirst.Location = new System.Drawing.Point(410, 364);
            this.btnReturnFirst.Name = "btnReturnFirst";
            this.btnReturnFirst.Size = new System.Drawing.Size(427, 91);
            this.btnReturnFirst.TabIndex = 7;
            this.btnReturnFirst.Text = "첫 화면으로";
            this.btnReturnFirst.UseVisualStyleBackColor = true;
            this.btnReturnFirst.Click += new System.EventHandler(this.btnReturnFirst_Click);
            // 
            // cboCategory
            // 
            this.cboCategory.FormattingEnabled = true;
            this.cboCategory.Items.AddRange(new object[] {
            "일반",
            "경차"});
            this.cboCategory.Location = new System.Drawing.Point(522, 56);
            this.cboCategory.Name = "cboCategory";
            this.cboCategory.Size = new System.Drawing.Size(315, 27);
            this.cboCategory.TabIndex = 8;
            // 
            // txtCarName
            // 
            this.txtCarName.ImeMode = System.Windows.Forms.ImeMode.Hangul;
            this.txtCarName.Location = new System.Drawing.Point(522, 113);
            this.txtCarName.MaxLength = 7;
            this.txtCarName.Name = "txtCarName";
            this.txtCarName.Size = new System.Drawing.Size(315, 29);
            this.txtCarName.TabIndex = 9;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(904, 520);
            this.ControlBox = false;
            this.Controls.Add(this.txtCarName);
            this.Controls.Add(this.cboCategory);
            this.Controls.Add(this.btnReturnFirst);
            this.Controls.Add(this.btnInsert);
            this.Controls.Add(this.btnSerchPic);
            this.Controls.Add(this.lblInTime);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureCar);
            this.Font = new System.Drawing.Font("HY헤드라인M", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureCar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureCar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblInTime;
        private System.Windows.Forms.Button btnSerchPic;
        private System.Windows.Forms.Button btnInsert;
        private System.Windows.Forms.Button btnReturnFirst;
        private System.Windows.Forms.ComboBox cboCategory;
        private System.Windows.Forms.TextBox txtCarName;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}