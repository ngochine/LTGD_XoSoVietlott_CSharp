using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using System.Globalization;

namespace XoSoVietlott
{
    public partial class FormTKTatCaVe : UserControl
    {
        string name; //Tên người dùng
        public FormTKTatCaVe()
        {
            InitializeComponent();
        }

        public FormTKTatCaVe(string name, string temp)
        {
            InitializeComponent();
            this.name = name;
        }

        public class KetQuaXoSo
        {
            public string ThoiGian { get; set; }
            public List<string> DanhSachKetQua { get; set; }

            public KetQuaXoSo(string ThoiGian)
            {
                this.ThoiGian = ThoiGian;
                DanhSachKetQua = new List<string>();
            }
        }
        public string ThoiGian { get; set; }
        public List<string> DanhSachKetQua { get; set; }

        public FormTKTatCaVe(string ThoiGian)
        {
            this.ThoiGian = ThoiGian;
            DanhSachKetQua = new List<string>();
        }

        private void FormTKTatCaVe_Load(object sender, EventArgs e)
        {
            try
            {
                List<KetQuaXoSo> danhsach = new List<KetQuaXoSo>();//mỗi đối tượng trong danhsach sẽ lưu ngày và kết quả tương ứng
                string path = "KetQuaVietlott\\KetQuaXoSo_" + name; //Lưu file theo người dùng
                 
                if (File.Exists(path))
                {
                    string[] lines = File.ReadAllLines(path);

                    KetQuaXoSo k = null; //Khởi tạo đối tượng k

                    foreach (string l in lines)
                    {
                        if (DateTime.TryParseExact(l, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime date))
                        {
                            k = new KetQuaXoSo(date.ToString("dd/MM/yyyy"));
                            danhsach.Add(k);

                        }
                        else if (k != null)//Khong phải ngày tháng, là kết quả => thêm kết quả vào dối tượng hiện tại là k
                        {
                            k.DanhSachKetQua.Add(l);
                        }
                    }
                }

                listView1.Items.Clear();
                foreach (var k in danhsach)
                {
                    ListViewItem item = new ListViewItem(k.ThoiGian);
                    if (k.DanhSachKetQua.Count > 0)
                    {
                        item.SubItems.Add(string.Join(" ", k.DanhSachKetQua));
                    }
                    else
                    {
                        item.SubItems.Add("Không có dữ liệu");
                    }

                    listView1.Items.Add(item);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi file!");
            }

        }
    }
}



