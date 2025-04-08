using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Xml.Linq;

/* 
 Class LopDungChungFile là class phục vụ mục đích tạo file nhanh

 Chức năng chính: Tạo file lưu chữ nhanh, đa mục đích

 */

namespace XoSoVietlott
{
    internal class LopDungChungFile
    {

        //========= Các thuộc tính - Phương thức của LopDungChungFile =========//
        private string tenFile;
        string diaChiLuu;

        public LopDungChungFile(string tenFile)
        {
            this.tenFile = tenFile;
            Directory.CreateDirectory("KetQuaVietlott"); //Tạo thư mục (nếu thư mục chưa được tạo)
            diaChiLuu = string.Format("KetQuaVietlott\\{0}", tenFile);

            //Nếu file không tồn tại thì tạo file
            if (!File.Exists(diaChiLuu))
            {
                File.Create(diaChiLuu).Close();
            }
        }

        public void ghiKetQua(string soChon)
        {
            StreamWriter writer = null;
            try
            {
                writer = new StreamWriter(diaChiLuu, true); //tham số true thể hiện việc ghi tiếp vào file chứ kh phải ghi đè
                writer.WriteLine(DateTime.Now.ToString("dd/MM/yyyy"));
                writer.WriteLine(soChon);
            }
            catch (Exception ex)
            {
                FormThongBao ftb = new FormThongBao(false, "Có lỗi xảy ra trong ghi kết quả!" + ex);
                ftb.Show();
            }
            writer.Close();
        }
    }
}
