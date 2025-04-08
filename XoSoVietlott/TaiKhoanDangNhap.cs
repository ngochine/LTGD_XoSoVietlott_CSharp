using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* Class TaiKhoanDangNhap lưu trữ các trường thông tin sau
 
 hoTen --> Tên tài khoản
 matKhau --> Mật khẩu người dùng
 biBan --> Bị khoá tài khoản
 

 Chức năng chính: Lưu trữ dữ liệu nạp vào FormLogin --> Phục vụ cho đăng nhập
 */

namespace XoSoVietlott
{
    internal class TaiKhoanDangNhap
    {
        private string hoTen;
        private string matKhau;
        private bool biBan;

        public TaiKhoanDangNhap(string HoTen, string MatKhau, bool BiBan)
        {
            hoTen = HoTen;
            matKhau = MatKhau;
            biBan = BiBan;
        }

        public string HoTen {
            get { return this.hoTen; }
            set{ this.hoTen = value; }
        }
        public string MatKhau
        {
            get { return this.matKhau; }
            set { this.matKhau = value; }
        }
        public bool BiBan
        {
            get { return this.biBan; }
            set { this.biBan = value; }
        }
    }
}
