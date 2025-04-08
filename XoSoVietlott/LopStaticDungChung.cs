using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/*
 Class LopStatic lưu trữ các phương thức/hàm dùng chung cho toàn bài

 Tất cả các phương thức dều ở dạng static

 Chức năng chính: Lưu trữ toàn bộ các hàm dùng chung phục vụ các chứng năng cho các form cần sử dụng đến của nó!

 */

namespace XoSoVietlott
{
    internal class LopStatic
    {
        //============== Các phương thức static dùng chung toàn bài ==================/

        //Lưu họ tên, ngày tạo tài khoản, ngày chơi lần cuối ==> Sử dụng trong FormMenu
        public static void LuuNguoiDung(NguoiDung nd, string tenFile)
        {
            StreamWriter writer = null;
            try
            {
                writer = new StreamWriter(tenFile, true); //tham số true thể hiện việc ghi tiếp vào file chứ kh phải ghi đè
                writer.WriteLine(nd.HoTen);
                writer.WriteLine(nd.NgayTaoTaiKhoan.ToString("yyyy-MM-dd"));
                writer.WriteLine(nd.NgayChoiLanCuoi.ToString("yyyy-MM-dd"));
            }
            catch (Exception ex)
            {
                FormThongBao ftb = new FormThongBao(false, "Có lỗi xảy ra trong lưu người dùng!" + ex);
                ftb.Show();
            }
            finally
            {
                if (writer != null)
                    writer.Close();
            }
           
        }


        //File tạo người dùng (hoặc cập nhật người dùng)
        public static NguoiDung TaoNguoiDungTuFile(string tenFile, string temp)
        {
              StreamReader reader = null;
                try
                {
                    reader = new StreamReader(tenFile);
                    string[] lines = new string[4];

                    //Đọc dữ liệu từ file
                    int i = 0;
                    string text = "";
                    do
                    {
                        text = reader.ReadLine();
                        lines[i] = text;
                        i++;
                    } while(text != null);
   
                    //Gán dữ liệu để tạo đối tượng người dùng
                    string hoTen = lines[0];
                    DateTime ngayTao = DateTime.Parse(lines[1]);
                    DateTime ngayCuoi = DateTime.Parse(lines[2]);

                    reader.Close(); //Nhớ đóng tệp
                    return new NguoiDung(hoTen, ngayTao, ngayCuoi);

                }
                catch(FileNotFoundException ex)
                {
                    Console.WriteLine(ex);
                    //Không làm gì cả vì lúc này hệ thống mặc định lấy dữ liệu temp
                }
                catch (Exception ex)
                {
                    FormThongBao ftb = new FormThongBao(false, "Có lỗi xảy ra trong đọc file người dùng!" + ex);
                    ftb.Show();
                }

            return new NguoiDung(temp, DateTime.Now, DateTime.Now); //Trong trường hợp là lỗi do không tìm thấy file --> trả về dữ liệu temp
        }


        //Nạp dữ liệu các user đã có trong file ListUserAccount
        public static List<TaiKhoanDangNhap> DocDanhSachUser()
        {
            string listUserPath = Application.StartupPath + "\\ListUserAccount.txt";
            List<TaiKhoanDangNhap> danhSach = new List<TaiKhoanDangNhap>();

            if (File.Exists(listUserPath))
            {
                StreamReader reader = null;
                try
                {
                    reader = new StreamReader(listUserPath);
                    List<string> lines = new List<string>();

                    //Đọc dữ liệu từ file
                    string text = "";
                    while ((text = reader.ReadLine()) != null)
                    {
                        lines.Add(text); // Thêm dòng vào List
                    }

                    foreach (string line in lines)
                    {
                        //Tách 3 trường dữ liệu hoTen,Mật khẩu, tạm khoá
                        string[] data = line.Split(',');
                        danhSach.Add(new TaiKhoanDangNhap(
                                data[0].Trim(),
                                data[1].Trim(),
                                bool.Parse(data[2].Trim())
                        )); //Thêm vào danh sách một tài khoản tạo từ các dữ liệu lấy được từ file
   
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    FormThongBao ftb = new FormThongBao(false, "Có lỗi xảy ra trong file người dùng!" + ex);
                    ftb.Show();
                }
            }
            return danhSach; //Nếu file tồn tại --> Trả về danhSach xử lý, ngược lại trả về new List!
        }
    }
}
