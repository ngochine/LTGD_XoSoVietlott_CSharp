using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

/*

Trang login: Xử lý đăng nhập của chương trình
1. Loại đăng nhập admin --> Độc lập với vòng đời chương trình
2. Loại đăng nhập vào menu người dùng --> Vào vòng đời

Lưu ý: Để mở form admin
Tên tài khoản: Admin
Mật khẩu: DH23IT02_Vietlott
 */ 

namespace XoSoVietlott
{
    public partial class FormLogin : Form
    {
        Random rand = new Random();
        int soNguoiOnline;
        string filePath,Fomo; //FilePath = điền tự động, ListUserPath = Dữ liệu đăng nhập của user

        public FormLogin()
        {
            InitializeComponent();
        }

        public string TenDangNhap
        {
            get { return txtName.Text; }
        } //Cần thiết để formMenu lấy được thông tin người đăng nhập

        //Nạp dữ liệu điền tự động vào form cho lần đăng nhập sau
        public void NapDuLieuLuu()
        {
            StreamReader reader;
            try
            {
                reader = new StreamReader(filePath);
             
                txtName.Text = reader.ReadLine();
                txtPassword.Text = reader.ReadLine();
                checkNologin.Checked = true;

                reader.Close(); //Nhớ đóng file
            }
            catch (FileNotFoundException)
            {
                //Bỏ qua vì ko có file --> Không cần nạp tự động
            }
            catch (Exception ex)
            {
                FormThongBao ftb = new FormThongBao(false, "Có lỗi trong việc nạp dữ liệu tự động" + ex);
                ftb.Show();
            }
        }

        //Nạp các dữ liệu ban đầu cho form login
        private void FormLogin_Load(object sender, EventArgs e)
        {
            String[] fomo = { "                 Quang Linh vừa trúng giải độc đắc trị giá 2 tỷ đồng!                 ",
                "                 Thuý Nga vừa trúng giải nhì trị giá 300 triệu đồng!                   ",
                "                Quang Lâm vừa trúng giải nhất trị giá 1 tỷ đồng!                 ",
                "               Tiên Hoàng vừa trúng giải ba trị giá 100 triệu đồng!                  ",
                "               Đỗ Khanh vừa trúng giải độc đắc trị giá 2 tỷ đồng!                 ",
                "              Nguyễn Kiều vừa trúng giải nhì trị giá 300 triệu đồng!                  ",
                "               Lâm Hiếu vừa trúng giải độc đắc trị giá 2 tỷ đồng!                  "
            };
            soNguoiOnline = 1000;
            filePath = Application.StartupPath + @"\userlogin.txt";
            Fomo = String.Join("", fomo); //Ghép mảng thành chuỗi
            lbFomo.Text = Fomo;


            FormThongBao ftb = new FormThongBao(true, "Đã mở trang login thành công!");
            ftb.Show();

            NapDuLieuLuu();
        }

        //============= Xử lý UI/UX cho hai ô nhập liệu =============//
        private void txtName_TextChanged(object sender, EventArgs e)
        {
            if(txtName.Text == "Tên tài khoản" || txtName.Text == "Vui lòng nhập tên!")
                txtName.Text = "";
            txtName.ForeColor = Color.SlateGray;
        }

        private void txtPassword_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text == "Mật khẩu" || txtPassword.Text == "Vui lòng nhập pass!")
                txtPassword.Text = "";
            txtPassword.ForeColor = Color.SlateGray;
        }

        private void txtName_Leave(object sender, EventArgs e)
        {
            if (txtName.Text == "")
            {
                txtName.Text = "Tên tài khoản";
            }
        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            if (txtPassword.Text == "")
            {
                txtPassword.Text = "Mật khẩu";
            }
        }
        //=============================================================//


        //Tiền xử lý login --> Bổ trợ nút đăng nhập
        public bool tienXuLy()
        {
            FormThongBao ftb;
            if (txtName.Text == "Tên tài khoản" || txtName.Text == "Vui lòng nhập tên!")
            {
                txtName.Text = "Vui lòng nhập tên!";
                txtName.ForeColor = Color.Red;

                ftb = new FormThongBao(false, "Vui lòng nhập tên tài khoản!");
                ftb.Show();
                return false;
            }

            if (txtPassword.Text == "Mật khẩu" || txtPassword.Text == "Vui lòng nhập pass!")
            {
                txtPassword.Text = "Vui lòng nhập pass!";
                txtPassword.ForeColor = Color.Red;

                ftb = new FormThongBao(false, "Vui lòng nhập mật khẩu!");
                ftb.Show();
                return false;
            }
            return true;
        }

        //Nếu loại đăng nhập là admin --> Bổ trợ nút đăng nhập
        public bool xuLyMoTKAdmin()
        {
            FormThongBao ftb;
            if (txtName.Text == "Admin" && txtPassword.Text == "DH23IT02_Vietlott")
            {

                this.Hide(); //Giấu tạm thời form đăng nhập

                FormAdmin admin = new FormAdmin(this);
                admin.ShowDialog();

                return false;
            }
            else if (txtName.Text == "Admin" && txtPassword.Text != "DH23IT02_Vietlott")
            {
                ftb = new FormThongBao(false, "Vui lòng đăng nhập tên khác!");
                ftb.Show();
                return false;
            }
            return true;
        }

        //Xử lý tài khoản đăng nhập --> Bổ trợ nút đăng nhập
        public bool xuLyTKNguoiDung()
        {
            FormThongBao ftb;
            // Đọc danh sách tài khoản
            List<TaiKhoanDangNhap> danhSach = LopStatic.DocDanhSachUser();

            //Tìm kiếm tài khoản phù hợp điều kiện
            TaiKhoanDangNhap nguoiDungHopLe = null;
            foreach (TaiKhoanDangNhap taiKhoan in danhSach)
            {
                if (taiKhoan.HoTen == txtName.Text && taiKhoan.MatKhau == txtPassword.Text)
                {
                    nguoiDungHopLe = taiKhoan;
                    break;
                }
            }

            if (nguoiDungHopLe == null)
            {
                ftb = new FormThongBao(false, "Sai tài khoản hoặc mật khẩu!");
                ftb.Show();
                return false;
            }

            if (nguoiDungHopLe.BiBan)
            {
                ftb = new FormThongBao(false, "Tài khoản đã bị khóa!");
                ftb.Show();
                return false;
            }
            return true;
        }

        //========= Xử lý nút login ========//
        private void btLogin_Click(object sender, EventArgs e)
        {
            FormThongBao ftb;
            if (!tienXuLy())
                return;
            if (!xuLyMoTKAdmin())
                return;
            if (!xuLyTKNguoiDung())
                return;


            //Nếu ô lưu tài khoản được check --> Lưu file userlogin
            if (checkNologin.Checked)
            {
                StreamWriter writer;
                try {
                    writer = new StreamWriter(filePath);

                    writer.WriteLine(txtName.Text);
                    writer.WriteLine(txtPassword.Text);

                    writer.Close();
                }
                catch (Exception ex)
                {
                    ftb = new FormThongBao(false, "Có lỗi đã xảy ra!" + ex);
                    ftb.Show();
                }
            }
            else
            {
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }
            }

            this.DialogResult = DialogResult.OK; //Nếu đi từ đầu đến cuối mà không bị lỗi --> Có thể vào formMenu qua điêu kiện này
            this.Close();
        }

        //Nút hướng dẫn
        private void label3_Click(object sender, EventArgs e)
        {
            string[] dieuKhoan = {"Sau đây là các hướng dẫn sử dụng app Vietlott:\n",
                "1. Nhập tên và mật khẩu do nhà phát hành cung cấp cho bạn sau khi bạn đăng kí dịch vụ tại trang chủ Vietlott\n",
                "2. Chọn nhớ tài khoản này thì chương trình sẽ tài khoản và mật khẩu cho lần sau đăng nhập của bạn không cần nhập lại!\n",
                "3. Hành vi để lộ tài khoản và mật khẩu thì sẽ không được giải quyết nếu có bất trắc xảy ra!\n",
                "4. Trong trường hợp chưa đăng kí tài khoản. Vui lòng liên hệ đại lý Vietlott để được hỗ trợ!\n",
                "5. Hotline: 1900.55.88.99\n",
                "6. Mọi thắc mắc vui lòng liên hệ {IT2303_Vietlott_Team3} để được giải quyết!\n"};

            MessageBox.Show(string.Join("\n",dieuKhoan), "Hướng Dẫn Sử Dụng", MessageBoxButtons.OK, MessageBoxIcon.Information); //Loại MessageBox okie
        }

        //Nút trang chủ
        private void label4_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://vietlott.vn/");
        }

        //Timer này dùng để tạo hiệu ứng online
        private void timer1_Tick(object sender, EventArgs e)
        {
            int randomOnline = (soNguoiOnline + rand.Next(1, 25));
            lbOnline.Text = "Số người đang chơi: " + randomOnline.ToString();
        }

        //Tạo hiệu ứng fomo chữ đi ngang
        private void timer2_Tick(object sender, EventArgs e)
        {
            lbFomo.Text = lbFomo.Text.Substring(1) + lbFomo.Text.Substring(0, 1);

        }

    }
}
