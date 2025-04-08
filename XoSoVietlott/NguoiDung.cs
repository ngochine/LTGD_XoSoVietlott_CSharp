using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* Class NguoiDung lưu trữ các thông tin sau
 
 hoTen --> Tên tài khoản
 ngayTaoTaiKhoan --> Ngày vào form menu lần đầu
 ngayChoiLanCuoi --> Ngày vào form menu lần cuối
 

 Chức năng chính: Lưu trữ dữ liệu nạp vào các dòng thông tin người dùng trong FormMenu
 */

namespace XoSoVietlott
{
    internal class NguoiDung
    {
        private string hoTen;
        private DateTime ngayTaoTaiKhoan;
        private DateTime ngayChoiLanCuoi;

        public NguoiDung(string hoTen, DateTime ngayTaoTaiKhoan, DateTime ngayChoiLanCuoi)
        {
            this.hoTen = hoTen;
            this.ngayTaoTaiKhoan = ngayTaoTaiKhoan;
            this.ngayChoiLanCuoi = ngayChoiLanCuoi;
        }

        public string HoTen
        {
            get { return hoTen; }
            set { hoTen = value; }
        }

        public DateTime NgayTaoTaiKhoan
        {
            get { return ngayTaoTaiKhoan; }
            set { ngayTaoTaiKhoan = value; }
        }

        public DateTime NgayChoiLanCuoi
        {
            get { return ngayChoiLanCuoi; }
            set { ngayChoiLanCuoi = value; }
        }


    }
}
