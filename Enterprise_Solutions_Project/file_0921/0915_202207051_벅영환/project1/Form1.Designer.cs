namespace project1
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBoxPhone = new System.Windows.Forms.TextBox();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.numberLavel = new System.Windows.Forms.Label();
            this.nameLavel = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.listViewPhoneBook = new System.Windows.Forms.ListView();
            this.ID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.NAME = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.PHONE = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.buttonSelect = new System.Windows.Forms.Button();
            this.bottonDelete = new System.Windows.Forms.Button();
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.buttonInsert = new System.Windows.Forms.Button();
            this.buttonReset = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBoxPhone);
            this.groupBox1.Controls.Add(this.textBoxName);
            this.groupBox1.Controls.Add(this.numberLavel);
            this.groupBox1.Controls.Add(this.nameLavel);
            this.groupBox1.Font = new System.Drawing.Font("HY헤드라인M", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupBox1.Location = new System.Drawing.Point(26, 17);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(378, 132);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "정보";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // textBoxPhone
            // 
            this.textBoxPhone.Location = new System.Drawing.Point(89, 76);
            this.textBoxPhone.Name = "textBoxPhone";
            this.textBoxPhone.Size = new System.Drawing.Size(281, 32);
            this.textBoxPhone.TabIndex = 3;
            this.textBoxPhone.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(89, 31);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(281, 32);
            this.textBoxName.TabIndex = 2;
            this.textBoxName.TextChanged += new System.EventHandler(this.textBoxName_TextChanged);
            // 
            // numberLavel
            // 
            this.numberLavel.AutoSize = true;
            this.numberLavel.Location = new System.Drawing.Point(12, 87);
            this.numberLavel.Name = "numberLavel";
            this.numberLavel.Size = new System.Drawing.Size(71, 21);
            this.numberLavel.TabIndex = 1;
            this.numberLavel.Text = "번호 : ";
            // 
            // nameLavel
            // 
            this.nameLavel.AutoSize = true;
            this.nameLavel.Location = new System.Drawing.Point(12, 34);
            this.nameLavel.Name = "nameLavel";
            this.nameLavel.Size = new System.Drawing.Size(71, 21);
            this.nameLavel.TabIndex = 0;
            this.nameLavel.Text = "이름 : ";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.listViewPhoneBook);
            this.groupBox2.Controls.Add(this.buttonSelect);
            this.groupBox2.Controls.Add(this.bottonDelete);
            this.groupBox2.Controls.Add(this.buttonUpdate);
            this.groupBox2.Controls.Add(this.buttonInsert);
            this.groupBox2.Font = new System.Drawing.Font("HY헤드라인M", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupBox2.Location = new System.Drawing.Point(12, 160);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(776, 278);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "조회및 제어";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // listViewPhoneBook
            // 
            this.listViewPhoneBook.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ID,
            this.NAME,
            this.PHONE});
            this.listViewPhoneBook.HideSelection = false;
            this.listViewPhoneBook.Location = new System.Drawing.Point(6, 84);
            this.listViewPhoneBook.Name = "listViewPhoneBook";
            this.listViewPhoneBook.Size = new System.Drawing.Size(762, 188);
            this.listViewPhoneBook.TabIndex = 4;
            this.listViewPhoneBook.UseCompatibleStateImageBehavior = false;
            this.listViewPhoneBook.View = System.Windows.Forms.View.Details;
            // 
            // ID
            // 
            this.ID.Text = "ID";
            // 
            // NAME
            // 
            this.NAME.Text = "Name";
            this.NAME.Width = 160;
            // 
            // PHONE
            // 
            this.PHONE.Text = "Phone";
            this.PHONE.Width = 220;
            // 
            // buttonSelect
            // 
            this.buttonSelect.Font = new System.Drawing.Font("HY헤드라인M", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.buttonSelect.Location = new System.Drawing.Point(582, 35);
            this.buttonSelect.Name = "buttonSelect";
            this.buttonSelect.Size = new System.Drawing.Size(186, 43);
            this.buttonSelect.TabIndex = 3;
            this.buttonSelect.Text = "전체조회";
            this.buttonSelect.UseVisualStyleBackColor = true;
            this.buttonSelect.Click += new System.EventHandler(this.button5_Click);
            // 
            // bottonDelete
            // 
            this.bottonDelete.Font = new System.Drawing.Font("HY헤드라인M", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.bottonDelete.Location = new System.Drawing.Point(390, 35);
            this.bottonDelete.Name = "bottonDelete";
            this.bottonDelete.Size = new System.Drawing.Size(186, 43);
            this.bottonDelete.TabIndex = 2;
            this.bottonDelete.Text = "삭제하기";
            this.bottonDelete.UseVisualStyleBackColor = true;
            this.bottonDelete.Click += new System.EventHandler(this.bottonDelete_Click);
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.Font = new System.Drawing.Font("HY헤드라인M", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.buttonUpdate.Location = new System.Drawing.Point(198, 35);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(186, 43);
            this.buttonUpdate.TabIndex = 1;
            this.buttonUpdate.Text = "수정하기";
            this.buttonUpdate.UseVisualStyleBackColor = true;
            this.buttonUpdate.Click += new System.EventHandler(this.buttonUpdate_Click);
            // 
            // buttonInsert
            // 
            this.buttonInsert.Font = new System.Drawing.Font("HY헤드라인M", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.buttonInsert.Location = new System.Drawing.Point(6, 35);
            this.buttonInsert.Name = "buttonInsert";
            this.buttonInsert.Size = new System.Drawing.Size(186, 43);
            this.buttonInsert.TabIndex = 0;
            this.buttonInsert.Text = "추가하기";
            this.buttonInsert.UseVisualStyleBackColor = true;
            this.buttonInsert.Click += new System.EventHandler(this.buttonInsert_Click);
            // 
            // buttonReset
            // 
            this.buttonReset.Font = new System.Drawing.Font("HY헤드라인M", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.buttonReset.Location = new System.Drawing.Point(410, 12);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(378, 142);
            this.buttonReset.TabIndex = 2;
            this.buttonReset.Text = "입력 초기화";
            this.buttonReset.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonReset);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBoxPhone;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Label numberLavel;
        private System.Windows.Forms.Label nameLavel;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListView listViewPhoneBook;
        private System.Windows.Forms.Button buttonSelect;
        private System.Windows.Forms.Button bottonDelete;
        private System.Windows.Forms.Button buttonUpdate;
        private System.Windows.Forms.Button buttonInsert;
        private System.Windows.Forms.Button buttonReset;
        private System.Windows.Forms.ColumnHeader ID;
        private System.Windows.Forms.ColumnHeader NAME;
        private System.Windows.Forms.ColumnHeader PHONE;
    }
}

