using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

/* Form menu - Vòng đời của toàn chương trình 
   
 1. Form Menu quản lý thông tin tài khoản người dùng qua việc lưu trữ tên [Name hoặc ten]
 2. Thuộc loại Menu mdi
 3. Tắt Form Menu bằng bấm [X] --> tắt hết chương trình
 
  Lưu ý: các form mà FormMenu sẽ gọi lên bao gồm (FormHome,FormQuaySo,FormTicket,FormThongKet)
 */

namespace XoSoVietlott
{
    public partial class FormMenu : Form
    {
        string picFolder;
        string usrFolder;
        string ten;
        int anhHienTai;

        public FormMenu(string name)
        {
            InitializeComponent();
            ten = name;
            this.IsMdiContainer = true;
        }

        //Mở form chờ
        private void menuHome_Click(object sender, EventArgs e)
        {
            FormHome home = new FormHome(this, ten);
            home.Show();

            this.Hide();
            home.FormClosed += (s, args) => this.Show(); //Hiển thị lại form mdi khi đóng
        }

        //Cập nhật giờ tự động
        private void timer1_Tick(object sender, EventArgs e)
        {
            lbTime.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        //Gọi gữ liệu trúng thưởng từ file xổ số
        public void CapNhatDuLieuTT()
        {
            string filePath = Application.StartupPath + "\\KetQuaVietlott\\KetQuaXoSo_" + ten;
            int soLan = 0;
            StreamReader reader;

            try
            {
                reader = new StreamReader(filePath);
                int count = 0;

                //Đếm dòng
                while (!reader.EndOfStream)
                {
                    reader.ReadLine();
                    count++;
                }
                reader.Close();
                soLan = count / 2; //Vì 2 dòng mới thành 1 vé
            }
            catch (Exception)
            {
                //Lười viết thông báo lỗi
            }
            lbSoLan.Text = "Số vé đã mua: " + soLan.ToString();


            string filePathGiai = Application.StartupPath + "\\KetQuaVietlott\\TKSoLuong_" + ten;
            int soLanTG = 0;
            try
            { 
                reader = new StreamReader(filePathGiai);
                int count = 0;

                while (!reader.EndOfStream)
                {
                    reader.ReadLine();
                    count++;
                }
                reader.Close();
                soLanTG = count/2;
            }
            catch (Exception)
            {
                //Lười viết thông báo lỗi
            }
            lbTrungThuong.Text = "Số lần trúng giải: " + soLanTG.ToString();
        }

        /***********/
        private void FormMenu_Load(object sender, EventArgs e)
        {
            //Nạp dữ liệu ban đầu của form
            picFolder = Application.StartupPath + "\\assest\\Menu_assest\\";
            usrFolder = Application.StartupPath + "\\userData\\";
            anhHienTai = 1;
            picQuangCao.Image = Image.FromFile(picFolder + "1.jpg");

            //Thông báo đăng nhập thành công
            FormThongBao ftb = new FormThongBao(true, "Đăng nhập thành công!");
            ftb.Show();

            //Lấy dữ liệu của người đăng nhập hiện tại --> Gán vào thông tin người dùng
            NguoiDung nd = LopStatic.TaoNguoiDungTuFile(usrFolder + ten + ".txt",ten);
            lbHoTen.Text += String.Format(" " + nd.HoTen.ToString());
            lbNgayTao.Text += String.Format(" " + nd.NgayTaoTaiKhoan.ToString("dd/MM/yyyy"));
            lbNgayChoi.Text += String.Format(" " + nd.NgayChoiLanCuoi.ToString("dd/MM/yyyy"));

            CapNhatDuLieuTT(); //Nạp dữ liệu mua vé và trúng thưởng của user đăng nhập
            LopStatic.LuuNguoiDung(nd, usrFolder + ten + ".txt"); //Tạo file lưu riêng trong trường hợp file người đó chưa tồn tại
        }

        //Đổi ảnh ở formMenu mỗi 10 giây
        private void timer2_Tick(object sender, EventArgs e)
        {
            anhHienTai++;
            if(anhHienTai > 3)
            {
                anhHienTai = 1;
            }
            try
            {
                picQuangCao.Image?.Dispose(); //Loại bỏ ảnh hiện tại (nếu ảnh hiện tại khác null)
                picQuangCao.Image = Image.FromFile(picFolder + string.Format("{0}.jpg", anhHienTai));
            }catch(Exception ex)
            {
                MessageBox.Show("Có lỗi ở quảng cáo ảnh!" + ex);
            }
        }
    
        //Mua vé thì mở FormHome
        private void btMuaVe_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormHome home = new FormHome(this, ten);
            home.ShowDialog();

            CapNhatDuLieuTT();
        }

        //Thống kê thì mở FormThongKeKetQua
        private void btThongKe_Click(object sender, EventArgs e)
        {
            FormThongKeKetQua ThongKeKetQua = new FormThongKeKetQua(ten);
            ThongKeKetQua.Show(); //Không đóng FormMenu
        }


        private void btTaiKhoan_Click(object sender, EventArgs e)
        {
            FormThongBao ftb = new FormThongBao(false, "Chức năng còn đang bảo trì!");
            ftb.Show();
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
            "Ngoài ra, truy cập trang FAQ để tìm những vấn đề và giải pháp chung nhất mà mọi người gặp phải [YES = Mở FAQ]";

            DialogResult result = MessageBox.Show(hoTro, "Hỗ trợ và giải đáp", MessageBoxButtons.YesNo, MessageBoxIcon.Information); //MessageBox loại Yes/No


            //Chuyển tới trang FAQ trên trình duyệt
            if (result == DialogResult.Yes)
            {
                System.Diagnostics.Process.Start("https://info.vietlott-sms.vn/faq.html");
                FormThongBao ftb = new FormThongBao(true,"Đã yêu cầu trình duyệt mở trang web!");
                ftb.Show();
            }
        
        }
        //Mở form ticket
        private void tsBaSo_Click(object sender, EventArgs e)
        {
            FormTicket ticket = new FormTicket(ten);
            ticket.ShowDialog();

            CapNhatDuLieuTT();
        }

 
    }
}
