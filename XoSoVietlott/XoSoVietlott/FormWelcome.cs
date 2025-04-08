using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XoSoVietlott
{
    public partial class FormWelcome : Form
    {
        string header = "    💸 CHÀO MỪNG BẠN ĐẾN VỚI VIETLOTT 🎫    ";
        public FormWelcome()
        {
            InitializeComponent();
            this.Opacity = 0.0;
            labelBottom.Text = "    Vietlott - Chơi là thắng lớn - Đổi đời ngay chỉ với 10 ngàn đồng!    ";
            timerPanel.Enabled = true;
            GiongChao();
        }

        private void timerPanel_Tick(object sender, EventArgs e)
        {
            labelBottom.Text= labelBottom.Text.Substring(1) + labelBottom.Text.Substring(0,1);
            if(this.Opacity < 1.0)
                  this.Opacity += 0.05; //Tăng dần độ rõ của FormWelcome
            taoHeader(); //Dựa trên timer mà thêm dần header vào!
        }

        private void timerClose_Tick(object sender, EventArgs e)
        {
            this.Close();
        }

        public void taoHeader()
        {
            if(labelTop.Text != header)
            {
                labelTop.Text += header[labelTop.Text.Length]; //Tăng kích thước dần cho đến khi trùng
            }
            else
            {
                labelTop.ForeColor = Color.Aqua;
            }
        }

        public void GiongChao()
        {
            //Code chạy nhạc dựa trên: https://www.daniweb.com/programming/software-development/threads/292695/playing-mp3-in-c
            try
            {
                System.Media.SoundPlayer hello = new System.Media.SoundPlayer();
                hello.SoundLocation = Application.StartupPath + @"/assest/WelcomeVoice.wav";
                hello.Play();
            }catch(Exception ex)
            {
                MessageBox.Show("Có vấn đề đã xảy ra. Mã lỗi: " + ex);
            }
        }

        private void labelTop_Click(object sender, EventArgs e)
        {

        }
    }
}
