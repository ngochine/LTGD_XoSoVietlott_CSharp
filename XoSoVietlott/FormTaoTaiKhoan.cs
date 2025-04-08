using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

/* From tạo tài khoản
 
Bổ trợ cho form admin với mục đích chính là tạo tài khoản cho người dùng
 
 */

namespace XoSoVietlott
{
    public partial class FormTaoTaiKhoan : Form
    {
        List<TaiKhoanDangNhap> taiKhoan;
        public FormTaoTaiKhoan()
        {
            InitializeComponent();
        }

        //Đọc danh sách để xử lý ngoại lệ
        private void FormTaoTaiKhoan_Load(object sender, EventArgs e)
        {
            taiKhoan = LopStatic.DocDanhSachUser();
        }

        private void btTaoTaiKhoan_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "" || txtPassword.Text == "" || txtRePass.Text == "")
            {
                FormThongBao ftb = new FormThongBao(false, "Vui lòng nhập đầy đủ thông tin!");
                ftb.Show();
            }else if(txtPassword.Text != txtRePass.Text)
            {
                FormThongBao ftb = new FormThongBao(false, "Vui lòng nhập đúng lại mật khẩu!");
                ftb.Show();
            }
            else
            {
                //Kiểm tra tài khoản có tồn tại hay không
                foreach (TaiKhoanDangNhap i in taiKhoan)
                {
                    if (i.HoTen == txtName.Text)
                    {
                        FormThongBao ftb = new FormThongBao(false, "Tài khoản này đã tồn tại!");
                        ftb.Show();
                        return;
                    }
                }

                //Ghi ba trường txtName.Text,txtPassword.Text,biBan vào file ListUserAccount
                bool biBan = false;
                if (cbBiBan.Checked)
                    biBan = true;

                try
                {
                    string diaChi = Application.StartupPath + "\\ListUserAccount.txt";
                    string newAccount = txtName.Text + txtPassword.Text + biBan.ToString();

                    //Ghi thông tin các user vào file list
                    StreamWriter writer = new StreamWriter(diaChi,true);
                    writer.WriteLine(txtName.Text + "," + txtPassword.Text + "," + biBan.ToString());

                    writer.Close();

                    FormThongBao ftb = new FormThongBao(true, "Đã ghi thông tin thành công");
                    ftb.Show();

                    this.Close();
                }
                catch (Exception ex)
                {
                    FormThongBao ftb = new FormThongBao(false, "Có lỗi đã phát sinh!" + ex);
                    ftb.Show();
                }
            }
        }

        private void btExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
