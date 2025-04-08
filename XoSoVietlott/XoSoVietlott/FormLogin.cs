using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace XoSoVietlott
{
    public partial class FormLogin : Form
    {
        Random rand = new Random();
        int soNguoiOnline = 1000;
        int doDaiText = 0;
        string TextHienTai = "";
        string filePath = Application.StartupPath + @"\userlogin.txt";

        string Fomo = "                 Quang Linh vừa trúng giải độc đắc trị giá 2 tỷ đồng!                 " +
            "                 Thuý Nga vừa trúng giải nhì trị giá 300 triệu đồng!                   " +
            "                Quang Lâm vừa trúng giải nhất trị giá 1 tỷ đồng!                 " +
            "               Tiên Hoàng vừa trúng giải ba trị giá 100 triệu đồng!                  " +
            "               Đỗ Khanh vừa trúng giải độc đắc trị giá 2 tỷ đồng!                 " +
            "              Nguyễn Kiều vừa trúng giải nhì trị giá 300 triệu đồng!                  " +
            "               Lâm Hiếu vừa trúng giải độc đắc trị giá 2 tỷ đồng!                  ";

        public FormLogin()
        {
            InitializeComponent();
            lbFomo.Text = Fomo;

            if (File.Exists(filePath))
            {
                string[] lines = File.ReadAllLines(filePath);
                if (lines.Length >= 2)
                {
                    txtName.Text = lines[0];
                    txtPassword.Text = lines[1];
                    checkNologin.Checked = true;
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            if(txtName.Text == "Tên tài khoản" || txtName.Text == "Vui lòng nhập tên!")
                txtName.Text = "";
            txtName.ForeColor = Color.SlateGray;
        }

        private void txtPassword_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text == "Mật khẩu" || txtPassword.Text == "Vui lòng nhập pass!")
                txtPassword.Text = "";
            txtPassword.ForeColor = Color.SlateGray;
        }

        private void txtName_Leave(object sender, EventArgs e)
        {
            if (txtName.Text == "")
            {
                txtName.Text = "Tên tài khoản";
            }
        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            if (txtPassword.Text == "")
            {
                txtPassword.Text = "Mật khẩu";
            }
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            int randomOnline = (soNguoiOnline + rand.Next(1, 25));
            lbOnline.Text = "Số người đang chơi: " + randomOnline.ToString();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            lbFomo.Text = lbFomo.Text.Substring(1) + lbFomo.Text.Substring(0, 1);
            
        }

        public string TenDangNhap
        {
            get { return txtName.Text; }
        }

        private void btLogin_Click(object sender, EventArgs e)
        {
            if(txtName.Text == "Tên tài khoản" || txtName.Text == "Vui lòng nhập tên!")
            {
                txtName.Text = "Vui lòng nhập tên!";
                txtName.ForeColor = Color.Red;
                return;
            }

            if(txtPassword.Text == "Mật khẩu" || txtPassword.Text == "Vui lòng nhập pass!")
            {
                txtPassword.Text = "Vui lòng nhập pass!";
                txtPassword.ForeColor = Color.Red;
                return;
            }

            if (checkNologin.Checked)
            {
                File.WriteAllText(filePath, $"{txtName.Text}\n{txtPassword.Text}");
            }
            else
            {
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
         
        }

        private void label3_Click(object sender, EventArgs e)
        {
            string dieuKhoan = "Sau đây là các hướng dẫn sử dụng app Vietlott:\n" +
                "\n1. Nhập tên và mật khẩu do nhà phát hành cung cấp cho bạn sau khi bạn đăng kí dịch vụ tại trang chủ Vietlott\n" +
                "\n2. Chọn nhớ tài khoản này thì chương trình sẽ tài khoản và mật khẩu cho lần sau đăng nhập của bạn không cần nhập lại!\n" + 
                "\n3. Hành vi để lộ tài khoản và mật khẩu thì sẽ không được giải quyết nếu có bất trắc xảy ra!\n" +
                "\n3. Hotline: 1900.55.88.99\n" +
                "\n4. Mọi thắc mắc vui lòng liên hệ {IT2303_Vietlott_Team3} để được giải quyết!\n";

            MessageBox.Show(dieuKhoan, "Hướng Dẫn Sử Dụng", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void label4_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://vietlott.vn/");
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void txtName_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void checkNologin_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
