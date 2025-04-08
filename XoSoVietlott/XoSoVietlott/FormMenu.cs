using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XoSoVietlott
{
    public partial class FormMenu : Form
    {
        string picFolder = Application.StartupPath + "\\assest\\Menu_assest\\";
        string usrFolder = Application.StartupPath + "\\user\\";
        int anhHienTai = 1;
        NguoiDung user;
        public FormMenu(string name)
        {
            InitializeComponent();
            picQuangCao.Image = Image.FromFile(picFolder + "1.jpg");
            this.IsMdiContainer = true;

            NguoiDung nguoi = LopDungChungFile.TaoNguoiDungTuFile(usrFolder + name + ".txt", name);

            LopDungChungFile.LuuNguoiDung(nguoi, usrFolder + name + ".txt");

            lbHoTen.Text += " " + nguoi.HoTen.ToString();
            lbNgayTao.Text += " " + nguoi.NgayTaoTaiKhoan.ToString("dd/MM/yyyy");
            lbNgayChoi.Text += nguoi.NgayChoiLanCuoi == DateTime.MinValue
                ? DateTime.Now.ToString("dd/MM/yyyy")
                : nguoi.NgayChoiLanCuoi.ToString("dd/MM/yyyy");
            lbSoLan.Text += " " + nguoi.SoLanMuaVe.ToString();
            lbTrungThuong.Text += " " + nguoi.SoLanTrungThuong.ToString();
        }

        private void menuHome_Click(object sender, EventArgs e)
        {
            FormHome home = new FormHome();
            home.Show();

            this.Hide();
            home.FormClosed += (s, args) => this.Show(); //Hiển thị lại form mdi khi đóng
        }

        private void menuLuatChoi_Click(object sender, EventArgs e)
        {

        }

        private void menuMuaVe_Click(object sender, EventArgs e)
        {

        }


        private void menuKetQua_Click(object sender, EventArgs e)
        {

        }

        private void menuThongKe_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lbTime.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private void FormMenu_Load(object sender, EventArgs e)
        {

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            anhHienTai++;
            if(anhHienTai > 3)
            {
                anhHienTai = 1;
            }

            try
            {
                picQuangCao.Image?.Dispose();
                picQuangCao.Image = Image.FromFile(picFolder + string.Format("{0}.jpg", anhHienTai));
            }catch(Exception ex)
            {
                MessageBox.Show("Có lỗi ở quảng cáo ảnh!" + ex);
            }
        }

        private void btMuaVe_Click(object sender, EventArgs e)
        {
            FormHome home = new FormHome();
            home.Show();

            this.Hide();
            home.FormClosed += (s, args) => this.Show(); //Hiển thị lại form mdi khi đóng
        }

        private void btThongKe_Click(object sender, EventArgs e)
        {
            FormThongKeKetQua ThongKeKetQua = new FormThongKeKetQua();
            ThongKeKetQua.Show();

            this.Hide();
            ThongKeKetQua.FormClosed += (s, args) => this.Show(); //Hiển thị lại form mdi khi đóng
        }

        private void btTaiKhoan_Click(object sender, EventArgs e)
        {

            MessageBox.Show("Hiện tại chưa có chức năng này!");

        }

        private void btHoTro_Click(object sender, EventArgs e)
        {
            string hoTro = "🎯 HƯỚNG DẪN VÀ HỖ TRỢ NGƯỜI CHƠI VIETLOTT 🎯\n\n" +
            "1. Truy cập website chính thức của Vietlott để xem kết quả và thông tin cập nhật:\n" +
            "   👉 https://www.vietlott.vn/\n\n" +
            "2. Liên hệ hỗ trợ kỹ thuật qua email:\n" +
            "   ✉️ hotrovietlott@gmail.com\n\n" +
            "3. Hỗ trợ sinh viên tại:\n" +
            "   🏫 DH23IT02 - Nhóm 3, Khoa Công nghệ Thông tin,\n" +
            "   Trường Đại học Mở TP.HCM\n\n" +
            "4. Mọi thắc mắc, khiếu nại hoặc hỗ trợ kỹ thuật sẽ được phản hồi trong vòng 24 giờ làm việc.\n\n" +
            "✅ Chúc bạn may mắn và chơi có trách nhiệm!";

            MessageBox.Show(hoTro,"Hỗ trợ và giải đáp", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void muaVéToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void tsBaSo_Click(object sender, EventArgs e)
        {
            FormTicket ticket = new FormTicket();
            ticket.Show();

            this.Hide();
            ticket.FormClosed += (s, args) => this.Show(); //Hiển thị lại form mdi khi đóng
        }
    }
}
