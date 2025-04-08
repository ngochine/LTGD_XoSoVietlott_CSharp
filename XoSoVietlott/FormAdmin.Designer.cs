namespace XoSoVietlott
{
    partial class FormAdmin
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAdmin));
            this.label1 = new System.Windows.Forms.Label();
            this.lbTKCount = new System.Windows.Forms.Label();
            this.lbBanCount = new System.Windows.Forms.Label();
            this.btTaoTaiKhoan = new System.Windows.Forms.Button();
            this.btXoaTaiKhoan = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.label1.Location = new System.Drawing.Point(186, 183);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(447, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "Trang quản lý dành riêng cho Admin";
            // 
            // lbTKCount
            // 
            this.lbTKCount.AutoSize = true;
            this.lbTKCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.25F);
            this.lbTKCount.Location = new System.Drawing.Point(145, 241);
            this.lbTKCount.Name = "lbTKCount";
            this.lbTKCount.Size = new System.Drawing.Size(174, 22);
            this.lbTKCount.TabIndex = 2;
            this.lbTKCount.Text = "Số tài khoản đã mở: ";
            // 
            // lbBanCount
            // 
            this.lbBanCount.AutoSize = true;
            this.lbBanCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.25F);
            this.lbBanCount.Location = new System.Drawing.Point(463, 241);
            this.lbBanCount.Name = "lbBanCount";
            this.lbBanCount.Size = new System.Drawing.Size(205, 22);
            this.lbBanCount.TabIndex = 3;
            this.lbBanCount.Text = "Số tài khoản hoạt động: ";
            // 
            // btTaoTaiKhoan
            // 
            this.btTaoTaiKhoan.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.25F);
            this.btTaoTaiKhoan.Location = new System.Drawing.Point(160, 291);
            this.btTaoTaiKhoan.Name = "btTaoTaiKhoan";
            this.btTaoTaiKhoan.Size = new System.Drawing.Size(157, 56);
            this.btTaoTaiKhoan.TabIndex = 5;
            this.btTaoTaiKhoan.Text = "Tạo tài khoản";
            this.btTaoTaiKhoan.UseVisualStyleBackColor = true;
            this.btTaoTaiKhoan.Click += new System.EventHandler(this.btTaoTaiKhoan_Click);
            // 
            // btXoaTaiKhoan
            // 
            this.btXoaTaiKhoan.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.25F);
            this.btXoaTaiKhoan.Location = new System.Drawing.Point(495, 291);
            this.btXoaTaiKhoan.Name = "btXoaTaiKhoan";
            this.btXoaTaiKhoan.Size = new System.Drawing.Size(157, 56);
            this.btXoaTaiKhoan.TabIndex = 7;
            this.btXoaTaiKhoan.Text = "Xoá tài khoản";
            this.btXoaTaiKhoan.UseVisualStyleBackColor = true;
            this.btXoaTaiKhoan.Click += new System.EventHandler(this.btXoaTaiKhoan_Click);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(44)))), ((int)(((byte)(49)))));
            this.label2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(0, 398);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(810, 23);
            this.label2.TabIndex = 8;
            this.label2.Text = "Ứng dụng được phát triển bởi DH23IT02_Vietlott_Nhom3";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(66, 367);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(643, 20);
            this.label3.TabIndex = 9;
            this.label3.Text = "Lưu ý: Mọi hành vi cố ý làm sai lệch thông tin khách hàng sẽ bị xử lý nếu bị phát" +
    " hiện!";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::XoSoVietlott.Properties.Resources.Icon;
            this.pictureBox1.Location = new System.Drawing.Point(298, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(228, 148);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // FormAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(810, 421);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btXoaTaiKhoan);
            this.Controls.Add(this.btTaoTaiKhoan);
            this.Controls.Add(this.lbBanCount);
            this.Controls.Add(this.lbTKCount);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormAdmin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý admin";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormAdmin_FormClosed);
            this.Load += new System.EventHandler(this.FormAdmin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lbTKCount;
        private System.Windows.Forms.Label lbBanCount;
        private System.Windows.Forms.Button btTaoTaiKhoan;
        private System.Windows.Forms.Button btXoaTaiKhoan;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Timer timer1;
    }
}