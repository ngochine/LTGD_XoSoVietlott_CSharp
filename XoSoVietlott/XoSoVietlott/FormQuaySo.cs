using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace XoSoVietlott
{
    public partial class FormQuaySo : Form
    {
        Random Random = new Random();
        static public int loaiVe;

        LopDungChungFile file = new LopDungChungFile("KetQuaXoSo");
        public FormQuaySo()
        {
            InitializeComponent();
        }
        private void FormQuaySo_Load_1(object sender, EventArgs e)
        {
            //khởi động timer
            timer1.Enabled = true;
            timer1.Start();

            panels = Getpanels(this); //lấy tất cả panel gán vào list
            hienThiPanel(); //hiển thị
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            List<int> list = new List<int>();
            for (int i = 0; i < loaiVe; i++)
            {
                int tmp = Random.Next(1, 46);
                if (!list.Contains(tmp)) //số random chưa tồn tại thì thêm
                {
                    list.Add(tmp);
                }
                else //không thì bắt đầu lại lượt đó
                    i--;
            }
            lbKetQuaQuay.Text = String.Join(" ", list);
        }

        //Xử lý có mấy số trùng với kết quả xổ số?
        private int soLanTrung(string chuoiSoNguoiDungChon, string chuoiSoThangGiai)
        {
            try
            {
                List<string> tmp = new List<string>();
                List<string> tmp2 = new List<string>();
                tmp.AddRange(chuoiSoThangGiai.Split(' '));
                tmp2.AddRange(chuoiSoNguoiDungChon.Split(' '));

                List<string> kq = new List<string>(tmp.Intersect(tmp2));
                return kq.Count();
            }
            catch(Exception) {}
            return 0;
        }
        
        //Xử lý thắng giải gì?
        public string tmpLuuGiai;
        private string loaiGiaiThang(int soLanTrung, int loaiVe)
        {
            string[] loaiGiai = { "JackPot", "Nhất", "Nhì", "Ba" };
            tmpLuuGiai = loaiGiai[loaiVe - soLanTrung];
            return string.Format("Chúc mừng bạn đã trúng giải {0} với số trùng là: {1}", loaiGiai[loaiVe-soLanTrung],soLanTrung);
        }

        LopDungChungFile fileSL = new LopDungChungFile("TKSoLuong");

        //Xử lý khi nhấp vào cb xổ số
        private void cbXoSo_Click_1(object sender, EventArgs e)
        {
            if (cbXoSo.Checked)
            {
                timer1.Stop(); // dừng timer
                file.ghiKetQua(lbKetQuaQuay.Text); // ghi kết quả ở lb vào file
                cbXoSo.Checked = false; 
                cbXoSo.Enabled = false; //kh cho bấm nữa
                string tmp;
                bool isTrung = false; //biến cờ để kiểm tra có trúng hay chưa

                //lấy tên file bên formticket (tên tạo bằng guid)
                StreamReader srFileChonSo = new StreamReader("KetQuaVietlott\\" + FormTicket.tenFile);
                //đọc file
                StringBuilder sb = new StringBuilder();
                string luuTmp="";
                string giaiTmp = null;
                do
                {
                    tmp = srFileChonSo.ReadLine();
                    if (tmp == null) break;
                    luuTmp = tmp;
                    if ((soLanTrung(luuTmp, "1 2 3 4 5 6") >=2 && loaiVe<5) ||
                        (soLanTrung(luuTmp, "1 2 3 4 5 6") > 3 && loaiVe >=5)) // nếu kết quả trong file trùng thì thông báo trúng
                    {
                        isTrung = true;
                        giaiTmp= loaiGiaiThang(soLanTrung(luuTmp, "1 2 3 4 5 6"), loaiVe);
                    }
                    else isTrung= false;
                    if (isTrung)
                    {
                        sb.Append(giaiTmp + '\n');
                        fileSL.ghiKetQua(tmpLuuGiai + " " + loaiVe);
                    }
                }
                while (tmp != null);
                giaiTmp= sb.ToString();
                lbResult.Text = giaiTmp==""? "Chúc bạn may mắn lần sau!" :giaiTmp;
            }
        }
        private void FormQuaySo_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Application.Exit();
        }

        //Lấy tất cả các control là panel
        private List<Panel> Getpanels(Control parent)
        {
            List<Panel> panels = new List<Panel>();
            foreach (Control c in parent.Controls)
            {
                if (c is Panel panel)
                {
                    panels.Add(panel);
                }
                else
                {
                    panels.AddRange(Getpanels(c));
                }
            }
            return panels;
        }

        public void GanDanhSachVe(ListViewItem[] danhSachVe)
        {
            listViewHienThiVeTrungThuong.Items.Clear(); // listView trong FormQuaySo
            foreach (var item in danhSachVe)
            {
                listViewHienThiVeTrungThuong.Items.Add((ListViewItem)item.Clone());
            }
        }

        //Hiển thị panel theo rb tương ứng
        List<Panel> panels = new List<Panel>();
        private void hienThiPanel()
        {
            int num;
            foreach (Panel p in panels) //duyệt qua tất cả các panel và xem thử panel nào trùng với vé mua thì cho visible = true
            {
                num = int.Parse(p.Name.Substring(5, 1));
                if (num == loaiVe)
                {
                    p.Visible = true;
                    return;
                }
            }
        }

        private void lbGiaTri_Click(object sender, EventArgs e)
        {

        }

        private void lbKetQuaQuay_Click(object sender, EventArgs e)
        {

        }
    }
}
