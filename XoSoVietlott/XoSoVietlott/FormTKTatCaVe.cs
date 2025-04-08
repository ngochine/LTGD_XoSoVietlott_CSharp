using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Globalization;

namespace XoSoVietlott
{
    public partial class FormTKTatCaVe : UserControl
    {
        public FormTKTatCaVe()
        {
            InitializeComponent();
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

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void FormTKTatCaVe_Load(object sender, EventArgs e)
        {
            try
            {
                List<KetQuaXoSo> danhsach = new List<KetQuaXoSo>();//mỗi đối tượng trong danhsach sẽ lưu ngày và kết quả tương ứng
                string path = "KetQuaVietlott\\KetQuaXoSo";

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



