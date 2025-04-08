using System;
using System.Windows.Forms;


/*  Form trang chờ
 
Chủ yếu dùng đề đọc luật chơi với kêu người dùng chuẩn bị tâm lý chứ cũng không có
chức năng gì!
 
 */

namespace XoSoVietlott
{
    public partial class FormHome : Form
    {

        Form menu;
        string name;
        public FormHome(Form FormCha, string tenNguoiDung)
        {
            InitializeComponent();
            menu = FormCha;
            this.name = tenNguoiDung;
        }

        private void btnLuatChoi_Click(object sender, EventArgs e)
        {
            string luatChoi = "🎯 LUẬT CHƠI VIETLOTT – Tóm Tắt Dễ Hiểu\n\n" +

            "🔹 1. Mega 6/45:\n" +
            "- Người chơi chọn 6 số từ 01 đến 45.\n" +
            "- Trúng Jackpot khi trùng 6 số với kết quả.\n" +
            "- Có các giải phụ khi trùng 3, 4, hoặc 5 số.\n\n" +

             "🎫 Bấm vào nút đỏ để bắt đầu mua vé.\n\n" +
            "✅ Lưu ý: Vui lòng đọc kĩ luật chơi trước khi chọn và mua vé!\n\n" +
            "💰 Chúc bạn may mắn!";

            MessageBox.Show(luatChoi, "Hướng Dẫn Chơi", MessageBoxButtons.OK, MessageBoxIcon.Information); //Loại messageBox là hướng dẫn chơi
        }
        
        private void btnChoi_Click(object sender, EventArgs e)
        {
            FormTicket ticket = new FormTicket(name);
            ticket.ShowDialog();
            
            this.Close();
        }

        private void FormHome_Load(object sender, EventArgs e)
        {
            FormThongBao ftb = new FormThongBao(true, "Đã thành công mở trang chờ!");
            ftb.Show();
        }

        private void FormHome_FormClosed(object sender, FormClosedEventArgs e)
        {
            menu.Show(); //Hiển thị lại Menu.Hide()
        }
    }
}
