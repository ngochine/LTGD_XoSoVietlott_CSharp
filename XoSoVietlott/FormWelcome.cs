using System;
using System.Drawing;
using System.Windows.Forms;

/*Quy trình hoạt động của FormWelcome

Khởi tạo --> Gọi Form_Load --> Gọi hàm giọng chào --> Kích hoạt hai timer
       --> timerPanel xử lý hiệu ứng cho labelTop (Đánh máy) và labelBottom (Truyền chữ)
       --> Thoát form welcome khi timerClose tick xong 1 lần!

*/

namespace XoSoVietlott
{
    public partial class FormWelcome : Form
    {
        string header;//Header dùng để bổ trợ hiệu ứng đánh máy cho labelTop
        public FormWelcome()
        {
            InitializeComponent();
        }

        private void FormWelcome_Load(object sender, EventArgs e)
        {
            this.Opacity = 0.0; //Khi ứng dụng mới mở thì ẩn độ rõ đi! --> Xử lý ở timerPanel
            header = "    💸 CHÀO MỪNG BẠN ĐẾN VỚI VIETLOTT 🎫    ";
            labelBottom.Text = "    Vietlott - Chơi là thắng lớn - Đổi đời ngay chỉ với 10 ngàn đồng!    ";
            GiongChao();
        }

        public void GiongChao()
        {
            //Code chạy nhạc dựa trên: https://www.daniweb.com/programming/software-development/threads/292695/playing-mp3-in-c
            try
            {
                string duongDanNhac = Application.StartupPath + @"/assest/WelcomeVoice.wav";
                System.Media.SoundPlayer welcome = new System.Media.SoundPlayer();
                welcome.SoundLocation = duongDanNhac;
                welcome.Play();
            }catch(Exception ex)
            {
                MessageBox.Show("Có vấn đề đã xảy ra với File! Mã lỗi: " + ex);
            }
        }


        //========= Xử lý labelTop ==========//
        private void timerPanel_Tick(object sender, EventArgs e)
        {
            labelBottom.Text = labelBottom.Text.Substring(1) + labelBottom.Text.Substring(0, 1);
            if (this.Opacity < 1.0)
                this.Opacity += 0.05; //Tăng dần độ rõ của FormWelcome khi mới mở ứng dụng
            taoHeader(); //Dựa trên timer mà thêm dần header vào!
        }

        private void timerClose_Tick(object sender, EventArgs e)
        {
            this.Close();
        }

        public void taoHeader()
        {
            if (labelTop.Text != header)
                labelTop.Text += header[labelTop.Text.Length]; //Tăng kích thước dần cho đến khi trùng
            else
                labelTop.ForeColor = Color.Aqua; //Khi đã xong hiệu ứng đánh máy thì gán màu Aqua cho labelTop
        }

    }
}
