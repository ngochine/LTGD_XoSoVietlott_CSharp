using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;

/*
 
 Form xoá tài khoản: bổ trợ cho form admin dùng để xoá tài khoản
 
 */

namespace XoSoVietlott
{
    public partial class FormXoaTaiKhoan : Form
    {
        List<TaiKhoanDangNhap> taiKhoan;
        public FormXoaTaiKhoan()
        {
            InitializeComponent();
        }


        private void FormXoaTaiKhoan_Load(object sender, EventArgs e)
        {
            taiKhoan = LopStatic.DocDanhSachUser();
            NapDanhSachVaoListView();
        }

        private void btExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Chỉ khi nạp danh sách vào thì mới xoá được
        private void NapDanhSachVaoListView()
        {
            lsUser.Items.Clear(); //Clear trong trường hợp có dư thừa lúc design

            foreach (TaiKhoanDangNhap user in taiKhoan)
            {
                string BiBan = "Không";
                if (user.BiBan)
                    BiBan = "Có";

                //Tạo một item mới và thêm vào list
                ListViewItem item = new ListViewItem(user.HoTen);
                item.SubItems.Add(BiBan);
                lsUser.Items.Add(item);
            }
        }

        //Sau khi xoá thì cập nhật lại file danh sách
        public void CapNhatDanhSachFile()
        {
            string duongDan = Application.StartupPath + "ListUserAccount.txt";
            StreamWriter writer = new StreamWriter(duongDan);
            try
            {
                foreach (TaiKhoanDangNhap tk in taiKhoan)
                {
                    // Ghi từng dòng với định dạng: HoTen,MatKhau,BiBan
                    String line = string.Format("{0},{1},{2}", tk.HoTen, tk.MatKhau, tk.BiBan);
                    writer.WriteLine(line);
                }
            }
            catch(Exception ex)
            {
                FormThongBao ftb = new FormThongBao(false, "Có lỗi đã phát sinh!" + ex);
                ftb.Show();
            }
        }

        private void btXoaTaiKhoan_Click(object sender, EventArgs e)
        {
            //Trong trường hợp người dùng không chọn cái nào để xoá
            if (lsUser.SelectedItems.Count == 0)
            {
                FormThongBao ftb = new FormThongBao(false, "Vui lòng chọn ít nhất 1 để xoá");
                ftb.Show();
                return;
            }

            //Duyệt danh sách trong listView
            foreach (ListViewItem item in lsUser.SelectedItems)
            {
                string hoTen = item.Text;
                TaiKhoanDangNhap taiKhoanCanXoa = null;

                //Tìm tài khoản trong list view tương ứng với trong list tài khoản
                foreach (TaiKhoanDangNhap tk in taiKhoan)
                {
                    if (tk.HoTen == hoTen)
                    {
                        taiKhoanCanXoa = tk;
                        break; 
                    }
                }

                if (taiKhoanCanXoa != null)
                {
                    taiKhoan.Remove(taiKhoanCanXoa);
                }
            }

            CapNhatDanhSachFile();

            // Cập nhật lại ListView
            NapDanhSachVaoListView();

            FormThongBao ft = new FormThongBao(true, "Xoá tài khoản thành công");
            ft.Show();

        }
    }
}
