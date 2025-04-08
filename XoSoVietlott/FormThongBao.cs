using System;
using System.Drawing;
using System.Windows.Forms;

/*Form thông báo

1. Dùng để thay thế cho phương thức messageBox --> Cải thiện UI/UX
2. Thao tác X,Y với form
3. Được lấy cảm hứng từ: https://www.youtube.com/watch?v=vLWWShU9gKY&pp=ygUWbW9kZXJuIG5vdGlmaWNhdGlvbiBjIw%3D%3D

Thuật ngữ: X - chiều ngang, Y - Chiều dọc

Mục đích chính: Hiển thị thông báo thành công hoặc lỗi ở góc màn hình
*/
namespace XoSoVietlott
{
    public partial class FormThongBao : Form
    {
        int x, y,formChaX, formChaY;
        string picFolder;

        //Phương thức khởi tạo chọn lọc thông báo thành công - lỗi
        public FormThongBao(bool loaiThongBao, string noiDung)
        {
            InitializeComponent();

            picFolder = Application.StartupPath + "\\assest\\ThongBao_PNG\\";

            if (loaiThongBao)
                ThanhCong(noiDung);
            else
                ThatBai(noiDung);
        }

        //Nếu thông báo dạng đã thành công
        public void ThanhCong(string noiDung)
        {
            lbLoai.Text = "Đã hoàn thành!";
            lbThongBao.Text = noiDung;
            lbLoai.ForeColor = Color.Green;
            lbColor.BackColor = Color.Green;
            picLoai.Image = Image.FromFile(picFolder + "V.png");
        }

        //Nếu thông báo thất bại
        public void ThatBai(string noiDung)
        {
            lbLoai.Text = "Có lỗi phát sinh!";
            lbThongBao.Text = noiDung;
            lbLoai.ForeColor = Color.Red;
            lbColor.BackColor = Color.Red;
            picLoai.Image = Image.FromFile(picFolder + "X.png");
        }

        //TimerXuatHien luôn gọi khi phương thức khởi tạo chạy --> Hiệu ứng đi lên
        private void timerXuatHien_Tick(object sender, EventArgs e)
        {
            y -= 1;
            this.Location = new Point(x, y);
            if(y == formChaY - this.Height)
            {
                timerXuatHien.Stop();
            }

        }

        //TimerTonTai gọi TimerBienMat --> Hiệu ứng đi xuống và tắt FormThongBao
        private void timerBienMat_Tick(object sender, EventArgs e)
        {
                y += 1;
                this.Location = new Point(x, y);
                if(y > formChaY) //Cho đến khi y ra khỏi màn hình
                {
                    timerBienMat.Stop();
                    this.Close();
                }
        }

        //Khi timer tồn tại kết thúc --> Chạy timerBienMat
        private void timerTonTai_Tick(object sender, EventArgs e)
        {
            timerBienMat.Start();
        }

        private void FormThongBao_Load(object sender, EventArgs e)
        {
           formChaX = Screen.PrimaryScreen.WorkingArea.Width;
           formChaY = Screen.PrimaryScreen.WorkingArea.Height;

            x = formChaX - this.Width;
            y = formChaY - this.Height + 50; //Cộng 50 để có hiệu ứng chuyển mượt cho TimerXuatHien

            this.Location = new Point(x, y);
        }
    }
}
