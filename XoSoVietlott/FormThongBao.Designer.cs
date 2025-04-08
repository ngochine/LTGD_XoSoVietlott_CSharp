namespace XoSoVietlott
{
    partial class FormThongBao
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
            this.lbLoai = new System.Windows.Forms.Label();
            this.lbThongBao = new System.Windows.Forms.Label();
            this.lbColor = new System.Windows.Forms.Label();
            this.timerXuatHien = new System.Windows.Forms.Timer(this.components);
            this.timerBienMat = new System.Windows.Forms.Timer(this.components);
            this.timerTonTai = new System.Windows.Forms.Timer(this.components);
            this.picLoai = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picLoai)).BeginInit();
            this.SuspendLayout();
            // 
            // lbLoai
            // 
            this.lbLoai.Location = new System.Drawing.Point(63, 7);
            this.lbLoai.Name = "lbLoai";
            this.lbLoai.Size = new System.Drawing.Size(150, 22);
            this.lbLoai.TabIndex = 2;
            this.lbLoai.Text = "Loại thông báo";
            this.lbLoai.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbThongBao
            // 
            this.lbThongBao.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.lbThongBao.Location = new System.Drawing.Point(64, 34);
            this.lbThongBao.Name = "lbThongBao";
            this.lbThongBao.Size = new System.Drawing.Size(212, 22);
            this.lbThongBao.TabIndex = 3;
            this.lbThongBao.Text = "Thông báo";
            this.lbThongBao.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbColor
            // 
            this.lbColor.Location = new System.Drawing.Point(-6, -7);
            this.lbColor.Name = "lbColor";
            this.lbColor.Size = new System.Drawing.Size(12, 68);
            this.lbColor.TabIndex = 4;
            // 
            // timerXuatHien
            // 
            this.timerXuatHien.Enabled = true;
            this.timerXuatHien.Interval = 15;
            this.timerXuatHien.Tick += new System.EventHandler(this.timerXuatHien_Tick);
            // 
            // timerBienMat
            // 
            this.timerBienMat.Interval = 15;
            this.timerBienMat.Tick += new System.EventHandler(this.timerBienMat_Tick);
            // 
            // timerTonTai
            // 
            this.timerTonTai.Enabled = true;
            this.timerTonTai.Interval = 1000;
            this.timerTonTai.Tick += new System.EventHandler(this.timerTonTai_Tick);
            // 
            // picLoai
            // 
            this.picLoai.Location = new System.Drawing.Point(11, 9);
            this.picLoai.Name = "picLoai";
            this.picLoai.Size = new System.Drawing.Size(45, 40);
            this.picLoai.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLoai.TabIndex = 1;
            this.picLoai.TabStop = false;
            // 
            // FormThongBao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(281, 59);
            this.Controls.Add(this.lbColor);
            this.Controls.Add(this.lbThongBao);
            this.Controls.Add(this.picLoai);
            this.Controls.Add(this.lbLoai);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "FormThongBao";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "FormThongBao";
            this.Load += new System.EventHandler(this.FormThongBao_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picLoai)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lbLoai;
        private System.Windows.Forms.Label lbThongBao;
        private System.Windows.Forms.Label lbColor;
        private System.Windows.Forms.Timer timerXuatHien;
        private System.Windows.Forms.PictureBox picLoai;
        private System.Windows.Forms.Timer timerBienMat;
        private System.Windows.Forms.Timer timerTonTai;
    }
}