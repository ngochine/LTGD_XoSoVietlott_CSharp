using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

/*Form ticket
 
1. Là form chọn mua vé của người dùng
2. Là form phụ thuộc formMenu
3. Các loại vé chỉ có thể quay 1 loại ở một lượt tab
 
 */

namespace XoSoVietlott
{
    public partial class FormTicket : Form
    {
        string name;
        string s = string.Format("Giá vé: 10.000đ/vé \nCác số đã chọn: ");
        string numbersDuocChon = ""; //lấy các số được chọn ghi vào file

        List<CheckBox> checkBoxList;
        List<RadioButton> rdList;
        List<int> arrLuaChon;//dùng để lưu các lựa chọn của người dùng
        Random random = new Random(); //dùng random để làm kết quả xổ số

        int loaiVe; //loại vé

        //tạo tên file ngẫu nhiên để lưu kết quả chọn của người dùng, để public static cho ngoài form nhận được
        static public string tenFile = "KetQua_" + Guid.NewGuid().ToString();
        LopDungChungFile file;


        //lấy tất cả các checkbox có trong form
        private List<CheckBox> GetAllCheckBoxes(Control parent)
        {
            List<CheckBox> list = new List<CheckBox>();
            foreach (Control c in parent.Controls)
            {
                if (c is CheckBox cb)
                {
                    list.Add(cb);
                }
                else
                {
                    list.AddRange(GetAllCheckBoxes(c));
                }
            }
            return list;
        }

        //lấy tất cả các radioButton có trong form
        private List<RadioButton> GetRadioButtons(Control parent)
        {
           
            List<RadioButton> rdList = new List<RadioButton>();
            foreach (Control rb in parent.Controls)
            {
                if (rb is RadioButton rdb)
                {
                    rdList.Add(rdb);
                }
                else
                {
                    rdList.AddRange(GetRadioButtons(rb));
                }
            }
            return rdList;
        }
        public FormTicket(string name)
        {

            InitializeComponent();
            this.name = name; //Tên người dùng
        }

        private void FormTicket_Load(object sender, EventArgs e)
        {
            //Thông báo mở form thành công
            FormThongBao ftb = new FormThongBao(true, "Đã mở form vé thành công");
            ftb.Show();


            file = new LopDungChungFile(tenFile); //tạo file theo đường dẫn ngẫu nhiên

            checkBoxList = GetAllCheckBoxes(this);
            rdList = GetRadioButtons(this);

            arrLuaChon = new List<int>();
            lbHienThi.Text = s;

            loaiVe = 6; //cho loại vé chọn lần đầu là 6
            FormQuaySo.loaiVe = loaiVe; //lấy dữ liệu ban đầu cho form quay số

            //tìm cái radioButton loại vé 6 số, cho màu lên để thấy là đang chọn nó
            foreach (RadioButton rb in rdList)
            {
                if (rb.Text.Substring(3, 1) == "6") { rb.BackColor = Color.Tomato; }
            }
            listViewHienThiVeDaMua.Items.Clear(); //dọn listViewHienThiVeDaMua
            listViewHienThiVeDaMua.View = View.Tile;
            listViewHienThiVeDaMua.Items.AddRange(hienThiVeDaMua(6).ToArray()); //Hiển thị loại vé đã mua 6 số nếu có

            if (listViewHienThiVeDaMua.Items.Count > 0)
            {
                btnDoSo.Enabled = true; //Nếu ở cái tab đó có vé => đã mua lé loại đó => có thể cho dò
            }
            else { btnDoSo.Enabled = false; }
        }
        
        //xử lý sự kiện click của 45 checkBox
        private void checkBox24_Click(object sender, EventArgs e)
        {
            CheckBox cbox = sender as CheckBox;
            if (cbox.Checked)
            {//nếu như hàm lựa chọn chưa có và lần chọn này vẫn còn hợp lệ thì thêm vào mảng lựa chọn của người dùng
                if (!arrLuaChon.Contains(int.Parse(cbox.Text)))
                {
                    if (loaiVe > arrLuaChon.Count)
                    {
                        arrLuaChon.Add(int.Parse(cbox.Text));
                    }
                    else
                    {//không thì thông báo
                        cbox.Checked = false;
                        MessageBox.Show(string.Format("Vượt quá số lần quy định: {0}", loaiVe), "Cảnh báo");
                    }
                }
            }
            else //Trường hợp người dùng bỏ chọn checkBox đó
            {
                arrLuaChon.Remove(int.Parse(cbox.Text));
            }
            numbersDuocChon = string.Join(" ", arrLuaChon);
        }

        //Xử lý khi tự chọn được check thì mấy số khác sẽ disable
        private void disableCheckBox(bool enable)
        {
            foreach (CheckBox cb in checkBoxList)
            {
                if (cb != checkBoxTuChon && cb != checkBoxHuy)
                {
                    cb.Enabled = !enable;
                }
            }
        }

        //Xử lý sự kiện người dùng để mình tự chọn số
        private void checkBoxTuChon_CheckedChanged(object sender, EventArgs e)
        {
            List<int> list = new List<int>(); //dùng này để kiểm tra các số bị trùng, để check hết cb được chọn
            if (checkBoxTuChon.Checked)
            {
                for (int i = 0; i < loaiVe; i++)
                {
                    int tmp = random.Next(1, 46);
                    if (!list.Contains(tmp)) //số random chưa tồn tại thì thêm
                    {
                        list.Add(tmp);
                    }
                    else //không thì bắt đầu lại lượt đó
                        i--;
                }
                foreach (CheckBox cb in checkBoxList)
                {//duyệt hết cb, bỏ qua cb tự chọn và cb huỷ, nếu cb nào có text giống list thì bật checked
                    if (cb != checkBoxTuChon && cb != checkBoxHuy)
                    {
                        if (list.Contains(int.Parse(cb.Text)))
                        {
                            cb.Checked = true;
                        }
                        else
                        {
                            cb.Checked = false;
                        }
                    }
                }
                disableCheckBox(true);
            }
            else // Xử lý người dùng bỏ nút tự chọn
            {
                disableCheckBox(false);
                foreach (CheckBox cb in checkBoxList)
                {
                    cb.Checked = false;
                }
            }
            numbersDuocChon = string.Join(" ", list);
        }

        //Xử lý người dùng bấm nút huỷ vé
        void huyCheckBox()
        {
            lbHienThi.Text = s;
            foreach (CheckBox cb in checkBoxList)
            {
                cb.Checked = false;
            }
            numbersDuocChon = "";
        }
        private void checkBoxHuy_Click(object sender, EventArgs e)
        {
            huyCheckBox();
            disableCheckBox(false);
        }


        //Xử lý listViewHienThiVeDaMua hiển thị theo từng tab
        private List<ListViewItem> hienThiVeDaMua(int loaiVe)
        {
            listViewHienThiVeDaMua.Items.Clear(); //dọn listViewHienThiVeDaMua
            List<ListViewItem> list = new List<ListViewItem>();
            StreamReader sr = null;
            try
            {
                sr = new StreamReader("KetQuaVietlott\\"+ tenFile); //Lưu file kết quả theo người dùng
                string tmp = sr.ReadLine();
                while (tmp != null)
                {
                    if (tmp.Split(' ').Count() == loaiVe) { 
                        ListViewItem item = new ListViewItem(tmp);
                        list.Add(item);
                    }
                    tmp = sr.ReadLine();
                }
            }
            catch { }
            finally { sr.Close(); }

            return list;
        }

        //Xử lý người dùng bấm nút tiếp tục mua
        private void btnTiepTucMuaVe_Click(object sender, EventArgs e)
        {
            int n = numbersDuocChon.Split(' ').Count();
            if (n == loaiVe)
            {
                arrLuaChon.Clear();
                if (numbersDuocChon != "")
                {
                    file.ghiKetQua(numbersDuocChon);
                }
                huyCheckBox();

                checkBoxTuChon.Checked = false; //để checkbox tự chọn về false để enable các số ra cho lần tiếp theo
                listViewHienThiVeDaMua.Items.AddRange(hienThiVeDaMua(loaiVe).ToArray());
                if (listViewHienThiVeDaMua.Items.Count > 0)
                {
                    btnDoSo.Enabled = true; //Nếu ở cái tab đó có vé => đã mua lé loại đó => có thể cho dò
                }
                else { btnDoSo.Enabled = false; }
            }
            else
            {
                MessageBox.Show(string.Format("Vui lòng chọn đủ số lượng số: {0}", loaiVe), "Cảnh báo");
                return;
            }
        }

        //Xử lý người dùng bấm nút dò vé số
        private void btnDoSo_Click(object sender, EventArgs e)
        {
            using (FormQuaySo quaySo= new FormQuaySo(name))
            {
                quaySo.GanDanhSachVe(listViewHienThiVeDaMua.Items.Cast<ListViewItem>().ToArray());
                quaySo.ShowDialog();
            }
            listViewHienThiVeDaMua.Items.Clear();

            this.Close();
        }

        //xử lý sự kiện bấm các nút chọn vé
        private void rb6So_Click(object sender, EventArgs e)
        { 

            disableCheckBox(false);
            huyCheckBox();
            RadioButton rb = sender as RadioButton;
            lbTrangTri.Text = "Các " + rb.Text.ToLower() + " đã mua";


             loaiVe = int.Parse(rb.Text.Substring(3, 1)); //cập nhật loại vé
            listViewHienThiVeDaMua.Items.AddRange(hienThiVeDaMua(loaiVe).ToArray());

            if (listViewHienThiVeDaMua.Items.Count > 0)
            {
                btnDoSo.Enabled = true; //Nếu ở cái tab đó có vé => đã mua lé loại đó => có thể cho dò
            }
            else { btnDoSo.Enabled = false; }

            //chỉnh màu cho radio đc chọn
            foreach (RadioButton r in rdList)
            {
                if (r != rb)
                {
                    r.Checked = false;
                    r.BackColor = Color.White;
                }
                else
                {
                    r.BackColor = Color.Tomato;
                }
            }

            //lấy dữ liệu cho Form quay số
            FormQuaySo.loaiVe = loaiVe;
        }
    }
}