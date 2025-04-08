using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XoSoVietlott
{
    internal class NguoiDung
    {
        private string hoTen;
        private DateTime ngayTaoTaiKhoan;
        private DateTime ngayChoiLanCuoi;
        private int soLanMuaVe;
        private int soLanTrungThuong;

        public NguoiDung(string hoTen)
        {
            this.hoTen = hoTen;
            this.ngayTaoTaiKhoan = DateTime.Today;
            this.ngayChoiLanCuoi = DateTime.MinValue;
            this.soLanMuaVe = 0;
            this.soLanTrungThuong = 0;
        }


        public NguoiDung(string hoTen, DateTime ngayTaoTaiKhoan, DateTime ngayChoiLanCuoi, int soLanMuaVe, int soLanTrungThuong)
        {
            this.hoTen = hoTen;
            this.ngayTaoTaiKhoan = ngayTaoTaiKhoan;
            this.ngayChoiLanCuoi = ngayChoiLanCuoi;
            this.soLanMuaVe = soLanMuaVe;
            this.soLanTrungThuong = soLanTrungThuong;
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

        public int SoLanMuaVe
        {
            get { return soLanMuaVe; }
            set { soLanMuaVe = value; }
        }

        public int SoLanTrungThuong
        {
            get { return soLanTrungThuong; }
            set { soLanTrungThuong = value; }
        }


    }
}
