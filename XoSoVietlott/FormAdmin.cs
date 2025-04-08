using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

/*
 
Form admin: Một form độc lập ngoài vòng đời của chương trình --> Mục đích: tạo, xoá tài khoản user 

 */

namespace XoSoVietlott
{
    public partial class FormAdmin : Form
    {
        List<TaiKhoanDangNhap> taiKhoan;
        Form login;

        public FormAdmin(Form lg)
        {
            InitializeComponent();
            login = lg;
        }

        private void FormAdmin_Load(object sender, EventArgs e)
        {
            FormThongBao ftb = new FormThongBao(true, "Đăng nhập admin thành công!");
            ftb.Show();

            CapNhatDS();
        }

        //Cập nhật hai thông tin trên form Admin
        public void CapNhatDS()
        {
            taiKhoan = LopStatic.DocDanhSachUser();
            lbTKCount.Text = "Số tài khoản đã mở: " + taiKhoan.Count.ToString();

            int soTaiKhoanDangHoatDong = taiKhoan.Count(u => !u.BiBan); //Count từng phần từ trong taiKhoan, nếu không bị ban thì tính count
            lbBanCount.Text = "Số tài khoản đã kích hoạt: " + soTaiKhoanDangHoatDong.ToString();
        }

        private void FormAdmin_FormClosed(object sender, FormClosedEventArgs e)
        {
            login.Show(); //Khi tắt form admin mở lại form login (vì form admin không thuộc vòng đời chương trình)
        }

        private void btTaoTaiKhoan_Click(object sender, EventArgs e)
        {
            FormTaoTaiKhoan tk = new FormTaoTaiKhoan();
            tk.ShowDialog();

            CapNhatDS();
        }

        private void btXoaTaiKhoan_Click(object sender, EventArgs e)
        {
            FormXoaTaiKhoan tk = new FormXoaTaiKhoan();
            tk.ShowDialog();

            CapNhatDS();
        }

    }
}
