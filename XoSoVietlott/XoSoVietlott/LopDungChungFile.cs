using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
namespace XoSoVietlott
{
    internal class LopDungChungFile
    {
        DateTime now = DateTime.Now;
        private string tenFile;
        string diaChiLuu;

        public LopDungChungFile(string tenFile)
        {
            this.tenFile = tenFile;
            Directory.CreateDirectory("KetQuaVietlott");
            diaChiLuu = string.Format("KetQuaVietlott\\{0}", tenFile);
            if (!File.Exists(diaChiLuu))
            {
                File.Create(diaChiLuu).Close();
            }
        }
        public string TenFile { get { return tenFile; } private set { tenFile = value; } }

        public void ghiKetQua(string soChon)
        {
            StreamWriter sw = null;
            try
            {
                sw = new StreamWriter(diaChiLuu, true); //tham số true thể hiện việt ghi tiếp vào file chứ kh phải ghi đè
                sw.WriteLine(now.ToString("dd/MM/yyyy"));
                sw.WriteLine(soChon);
            }
            catch {}
            finally {
                sw.Close();
            }
        }

        public static void LuuNguoiDung(NguoiDung nd, string filePath)
        {
            File.WriteAllLines(filePath, new string[]
            {
                nd.HoTen,
                nd.NgayTaoTaiKhoan.ToString("yyyy-MM-dd"),
                nd.NgayChoiLanCuoi.ToString("yyyy-MM-dd"),
                nd.SoLanMuaVe.ToString(),
                nd.SoLanTrungThuong.ToString()
            });
        }


        public static NguoiDung TaoNguoiDungTuFile(string tenFile, string hoTenTam)
        {
            if (File.Exists(tenFile))
            {
                try
                {
                    string[] lines = File.ReadAllLines(tenFile);

                    if (lines.Length >= 5)
                    {
                        string hoTen = lines[0];
                        DateTime ngayTao = DateTime.Parse(lines[1]);
                        DateTime ngayCuoi = DateTime.Parse(lines[2]);
                        int soLanMua = int.Parse(lines[3]);
                        int soLanTrung = int.Parse(lines[4]);

                        return new NguoiDung(hoTen, ngayTao, ngayCuoi, soLanMua, soLanTrung);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi đọc file người dùng: " + ex.Message);
                }
            }

            return new NguoiDung(hoTenTam, DateTime.Now, DateTime.MinValue, 0, 0);
        }
    }
}
