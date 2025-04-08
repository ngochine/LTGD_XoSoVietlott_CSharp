namespace XoSoVietlott
{
    partial class FormWelcome
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormWelcome));
            this.timerPanel = new System.Windows.Forms.Timer(this.components);
            this.timerClose = new System.Windows.Forms.Timer(this.components);
            this.labelBottom = new System.Windows.Forms.Label();
            this.labelTop = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // timerPanel
            // 
            this.timerPanel.Enabled = true;
            this.timerPanel.Interval = 85;
            this.timerPanel.Tick += new System.EventHandler(this.timerPanel_Tick);
            // 
            // timerClose
            // 
            this.timerClose.Enabled = true;
            this.timerClose.Interval = 7000;
            this.timerClose.Tick += new System.EventHandler(this.timerClose_Tick);
            // 
            // labelBottom
            // 
            this.labelBottom.BackColor = System.Drawing.Color.Firebrick;
            this.labelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.labelBottom.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelBottom.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.labelBottom.ForeColor = System.Drawing.Color.White;
            this.labelBottom.Location = new System.Drawing.Point(0, 200);
            this.labelBottom.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelBottom.Name = "labelBottom";
            this.labelBottom.Size = new System.Drawing.Size(532, 28);
            this.labelBottom.TabIndex = 1;
            this.labelBottom.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelTop
            // 
            this.labelTop.BackColor = System.Drawing.Color.Firebrick;
            this.labelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelTop.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.labelTop.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.labelTop.ForeColor = System.Drawing.Color.Snow;
            this.labelTop.Location = new System.Drawing.Point(0, 0);
            this.labelTop.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelTop.Name = "labelTop";
            this.labelTop.Size = new System.Drawing.Size(532, 26);
            this.labelTop.TabIndex = 0;
            this.labelTop.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FormWelcome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BackgroundImage = global::XoSoVietlott.Properties.Resources.panelCM;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(532, 228);
            this.ControlBox = false;
            this.Controls.Add(this.labelBottom);
            this.Controls.Add(this.labelTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormWelcome";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Vietlott chào bạn";
            this.Load += new System.EventHandler(this.FormWelcome_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer timerPanel;
        private System.Windows.Forms.Timer timerClose;
        private System.Windows.Forms.Label labelBottom;
        private System.Windows.Forms.Label labelTop;
    }
}