using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

/*

 FormQuaySo là form con của formTicket với mục đích quay số sau khi người dùng mua vé
 
 */

namespace XoSoVietlott
{
    public partial class FormQuaySo : Form
    {
        Random Random = new Random();
        static public int loaiVe;
        String name; //Name là tên của người dùng
        LopDungChungFile file;
        LopDungChungFile fileSL;

        public FormQuaySo(string name)
        {
            InitializeComponent();
            this.name = name;
            file = new LopDungChungFile("KetQuaXoSo_" + name); //Lưu theo file của người dùng
            fileSL = new LopDungChungFile("TKSoLuong_" + name);
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

        //Xử lý xoá những vé đã dò 
        private void deleteFileLoaiVe()
        {
            string filePath = "KetQuaVietlott\\" + FormTicket.tenFile;
            if (!File.Exists(filePath)) return;

            string tmpNgay = null;
            string tmpVe = null;
            StreamReader sr = null;
            StreamWriter sw = null;
            List<string> list = new List<string>();

            try
            {
                sr = new StreamReader(filePath);
                tmpNgay = sr.ReadLine();
                while (tmpNgay!=null)
                {
                    tmpVe = sr.ReadLine();
                    if (tmpVe != null && tmpVe.Split(' ').Length != loaiVe)
                    {
                        list.Add(tmpNgay);
                        list.Add(tmpVe);
                    }
                    tmpNgay = sr.ReadLine();
                }
            }
            catch { }
            finally
            {
                if (sr != null)
                    sr.Close();
            }

            try
            {
                sw = new StreamWriter(filePath, false);
                foreach (string line in list)
                {
                    sw.WriteLine(line);
                }
            }
            catch { }
            finally
            {
                if (sw != null)
                    sw.Close();
            }
        }

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
                StringBuilder sbGiai = new StringBuilder();
                StringBuilder sbFile = new StringBuilder();
                string luuTmp = "";
                string giaiTmp = null;
                do
                {
                    tmp = srFileChonSo.ReadLine();
                    if (tmp == null) break;
                    luuTmp = tmp;
                    if ((soLanTrung(luuTmp, lbKetQuaQuay.Text) >= 2 && loaiVe ==3 ) ||
                        (soLanTrung(luuTmp, lbKetQuaQuay.Text) >= 3 && loaiVe >= 4)) // nếu kết quả trong file trùng thì thông báo trúng
                    {
                        isTrung = true;
                        giaiTmp = loaiGiaiThang(soLanTrung(luuTmp, lbKetQuaQuay.Text), loaiVe);
                    }
                    else isTrung = false;
                    if (isTrung)
                    {
                        sbGiai.Append(giaiTmp + '\n');
                        fileSL.ghiKetQua(tmpLuuGiai + " " + loaiVe);
                    }
                }
                while (tmp != null);
                giaiTmp = sbGiai.ToString();
                lbResult.Text = giaiTmp == "" ? "Chúc bạn may mắn lần sau!" : giaiTmp;

                srFileChonSo.Close();

                deleteFileLoaiVe();
                FormThongBao ftb = new FormThongBao(true, "Tắt [X] để quay về trang chủ!");
                ftb.Show();
            }
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
    }
}
