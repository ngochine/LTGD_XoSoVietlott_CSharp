using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

/* Quy trình (vòng đời) của ứng dụng Vietlott
 
Gọi FormWelcome --> Gọi FormLogin
            --> Nếu FormLogin không trả về DialogResult (không bấm nút đăng nhập mà bấm X thoát) --> Ngưng chương trình
            --> Nếu FormLogin trả về DialogResult (Bấm nút đăng nhập) --> Mở FormMenu với tư cách là Form vòng đời

FormMenu --> Gọi FormHome --> Gọi FormTicket --> Gọi FormQuaySo --> FormMenu
         --> Gọi FormThongKeKetQua --> Dạng show();
         --> Gọi FormTicket --> Gọi FormQuaySo --> FormMenu

Ngoài ra: FormThongBao cũng được sử dụng với tư cách là MessageBox nhỏ góc phải màn hình!

Giải thích Form vòng đời: Là nếu form này bị tắt thì toàn bộ chương trình sẽ bị tắt hoàn toàn!
Cách thức truyền dữ liệu --> Truyền qua phương thực tạo hàm
 */






/* Sơ đồ tổng thể hoá chương trình
 
Form Welcome --> FormLogin -->           FormMenu --> Gọi FormHome --> Gọi FormTicket --> Gọi FormQuaySo --> FormMenu
                                         --> Gọi FormThongKeKetQua --> Dạng show();
                                         --> Gọi FormTicket --> Gọi FormQuaySo --> FormMenu
                                         --> Bấm [X] Thoát chương trình 


                           -->            FormAdmin --> Gọi FormTaoTaiKhoan --> FormAdmin
                                                   --> Gọi FormXoaTaiKhoan --> FormAdmin
                                         --> Trở về pageLogin khi bấm [X]

                           --> Bấm [X] Thoát chương trình
 
 */





/* Giải thích Show và ShowDialog

Show --> Gọi form đó lên với tư cách là độc lập so với form gọi (tương tác hai form)

ShowDialog --> Vô hiệu hoá form gọi, chỉ tương tác được form được gọi lên (tương tác một form)

Lưu ý: Trong trường hợp có dùng thuộc tính TopMost thì ShowDialog SẼ KHÔNG ẨN form gọi!
 */


namespace XoSoVietlott
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            string name = ""; //Tạo giá trị người dùng rỗng
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            FormWelcome welcome = new FormWelcome();
            welcome.ShowDialog();

            FormLogin login = new FormLogin();
            if (login.ShowDialog() == DialogResult.OK)
            {
                name = login.TenDangNhap; //Có phương thức get tên bên form login
                Application.Run(new FormMenu(name)); //Chạy Form vòng đời với truyền tên người dùng
            }
        }
    }
}
