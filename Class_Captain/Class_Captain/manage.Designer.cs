namespace Class_Captain
{
    partial class manage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(manage));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btninsert = new System.Windows.Forms.Button();
            this.btnupdate = new System.Windows.Forms.Button();
            this.btndelete = new System.Windows.Forms.Button();
            this.btnselelct = new System.Windows.Forms.Button();
            this.num = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.name = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.phone = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.position = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.reset = new System.Windows.Forms.Button();
            this.gender = new System.Windows.Forms.ComboBox();
            this.birth = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(100, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 27;
            this.dataGridView1.Size = new System.Drawing.Size(770, 563);
            this.dataGridView1.TabIndex = 1;
            // 
            // btninsert
            // 
            this.btninsert.Font = new System.Drawing.Font("배달의민족 을지로체 TTF", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btninsert.Location = new System.Drawing.Point(305, 722);
            this.btninsert.Name = "btninsert";
            this.btninsert.Size = new System.Drawing.Size(143, 50);
            this.btninsert.TabIndex = 2;
            this.btninsert.Text = "추가";
            this.btninsert.UseVisualStyleBackColor = true;
            this.btninsert.Click += new System.EventHandler(this.btninsert_Click);
            // 
            // btnupdate
            // 
            this.btnupdate.Font = new System.Drawing.Font("배달의민족 을지로체 TTF", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnupdate.Location = new System.Drawing.Point(496, 722);
            this.btnupdate.Name = "btnupdate";
            this.btnupdate.Size = new System.Drawing.Size(143, 50);
            this.btnupdate.TabIndex = 3;
            this.btnupdate.Text = "수정";
            this.btnupdate.UseVisualStyleBackColor = true;
            this.btnupdate.Click += new System.EventHandler(this.btnupdate_Click);
            // 
            // btndelete
            // 
            this.btndelete.Font = new System.Drawing.Font("배달의민족 을지로체 TTF", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btndelete.Location = new System.Drawing.Point(696, 722);
            this.btndelete.Name = "btndelete";
            this.btndelete.Size = new System.Drawing.Size(143, 50);
            this.btndelete.TabIndex = 4;
            this.btndelete.Text = "삭제";
            this.btndelete.UseVisualStyleBackColor = true;
            this.btndelete.Click += new System.EventHandler(this.btndelete_Click);
            // 
            // btnselelct
            // 
            this.btnselelct.Font = new System.Drawing.Font("배달의민족 을지로체 TTF", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnselelct.Location = new System.Drawing.Point(112, 722);
            this.btnselelct.Name = "btnselelct";
            this.btnselelct.Size = new System.Drawing.Size(143, 50);
            this.btnselelct.TabIndex = 5;
            this.btnselelct.Text = "검색";
            this.btnselelct.UseVisualStyleBackColor = true;
            this.btnselelct.Click += new System.EventHandler(this.btnselelct_Click);
            // 
            // num
            // 
            this.num.Location = new System.Drawing.Point(20, 636);
            this.num.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.num.Name = "num";
            this.num.Size = new System.Drawing.Size(143, 25);
            this.num.TabIndex = 8;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("배달의민족 한나는 열한살", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label21.Location = new System.Drawing.Point(61, 605);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(74, 31);
            this.label21.TabIndex = 7;
            this.label21.Text = "번호 ";
            // 
            // name
            // 
            this.name.Location = new System.Drawing.Point(186, 636);
            this.name.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(143, 25);
            this.name.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("배달의민족 한나는 열한살", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(226, 605);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 31);
            this.label1.TabIndex = 9;
            this.label1.Text = "이름";
            // 
            // phone
            // 
            this.phone.Location = new System.Drawing.Point(499, 634);
            this.phone.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.phone.Name = "phone";
            this.phone.Size = new System.Drawing.Size(143, 25);
            this.phone.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("배달의민족 한나는 열한살", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(519, 603);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 31);
            this.label2.TabIndex = 11;
            this.label2.Text = "Phone";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("배달의민족 한나는 열한살", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.Location = new System.Drawing.Point(680, 605);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 31);
            this.label3.TabIndex = 13;
            this.label3.Text = "Birth";
            // 
            // position
            // 
            this.position.Location = new System.Drawing.Point(810, 636);
            this.position.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.position.Name = "position";
            this.position.Size = new System.Drawing.Size(143, 25);
            this.position.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("배달의민족 한나는 열한살", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label4.Location = new System.Drawing.Point(821, 605);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(118, 31);
            this.label4.TabIndex = 15;
            this.label4.Text = "Position";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("배달의민족 한나는 열한살", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label5.Location = new System.Drawing.Point(360, 605);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(107, 31);
            this.label5.TabIndex = 17;
            this.label5.Text = "Gender";
            // 
            // reset
            // 
            this.reset.Font = new System.Drawing.Font("배달의민족 을지로체 TTF", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.reset.Location = new System.Drawing.Point(225, 675);
            this.reset.Name = "reset";
            this.reset.Size = new System.Drawing.Size(531, 30);
            this.reset.TabIndex = 19;
            this.reset.Text = "Reset";
            this.reset.UseVisualStyleBackColor = true;
            this.reset.Click += new System.EventHandler(this.reset_Click);
            // 
            // gender
            // 
            this.gender.Items.AddRange(new object[] {
            "",
            "남",
            "여"});
            this.gender.Location = new System.Drawing.Point(346, 634);
            this.gender.Name = "gender";
            this.gender.Size = new System.Drawing.Size(137, 23);
            this.gender.TabIndex = 20;
            // 
            // birth
            // 
            this.birth.Location = new System.Drawing.Point(654, 634);
            this.birth.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.birth.Name = "birth";
            this.birth.Size = new System.Drawing.Size(143, 25);
            this.birth.TabIndex = 12;
            // 
            // manage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(962, 780);
            this.Controls.Add(this.birth);
            this.Controls.Add(this.gender);
            this.Controls.Add(this.reset);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.position);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.phone);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.name);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.num);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.btnselelct);
            this.Controls.Add(this.btndelete);
            this.Controls.Add(this.btnupdate);
            this.Controls.Add(this.btninsert);
            this.Controls.Add(this.dataGridView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "manage";
            this.Text = "manage";
            this.Load += new System.EventHandler(this.manage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btninsert;
        private System.Windows.Forms.Button btnupdate;
        private System.Windows.Forms.Button btndelete;
        private System.Windows.Forms.Button btnselelct;
        private System.Windows.Forms.TextBox num;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox name;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox phone;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox position;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button reset;
        private System.Windows.Forms.ComboBox gender;
        private System.Windows.Forms.TextBox birth;
    }
}