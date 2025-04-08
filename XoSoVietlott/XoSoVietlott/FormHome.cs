using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XoSoVietlott
{
    public partial class FormHome : Form
    {

        public FormHome()
        {
            InitializeComponent();
        }

        private void btnLuatChoi_Click(object sender, EventArgs e)
        {
            string luatChoi = "🎯 LUẬT CHƠI VIETLOTT – Tóm Tắt Dễ Hiểu\n\n" +

        "🔹 1. Mega 6/45:\n" +
        "- Người chơi chọn 6 số từ 01 đến 45.\n" +
        "- Trúng Jackpot khi trùng 6 số với kết quả.\n" +
        "- Có các giải phụ khi trùng 3, 4, hoặc 5 số.\n\n" +

         "🎫 Bấm vào nút đỏ để bắt đầu mua vé.\n\n" +
        "✅ Lưu ý: Người chơi phải đủ 18 tuổi, có quyền công dân tại Việt Nam.\n\n" +
        "💰 Chúc bạn may mắn và chơi có trách nhiệm!";

            MessageBox.Show(luatChoi, "Hướng Dẫn Chơi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        
        private void btnChoi_Click(object sender, EventArgs e)
        {
            FormTicket ticket = new FormTicket();
            ticket.ShowDialog();
            
            this.Close();
        }

        private void FormHome_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Application.Exit();
        }
    }
}
