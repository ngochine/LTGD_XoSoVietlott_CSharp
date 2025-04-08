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

namespace XoSoVietlott
{
    public partial class FromTKNgay : UserControl
    {
        public FromTKNgay()
        {
            InitializeComponent();
        }
        string[] arrLoaiVe = { "Vé 3 số", "Vé 4 số", "Vé 5 số", "Vé 6 số" };
        int loaiVe; //loại vé

        //hàm init cho lable, listView, panel, listBox
        private void init_lable()
        {
            lbTitle.Text = String.Format("KẾT QUẢ SỔ SỐ VÉ {0} SỐ - NGÀY: {1}",
                loaiVe, dtPickerNgay.Value.ToString("dd/MM/yyyy"));
            lbNgayQuay.Text = String.Format("Kỳ vé: #2005 | Ngày quay thưởng: {0}", dtPickerNgay.Value.ToString("dd/MM/yyyy"));
            lbThu.Text = dtPickerNgay.Value.ToString("dddd");
        }
        private void init_listView()
        {
            listViewTK.Items.Clear();
            string[] arrGT = { "Jackpot", "Giải nhất", "Giải nhì", "Giải ba" };
            int soLan = 4;
            switch (loaiVe)
            {
                case 6: soLan = 4; break;
                case 5: soLan = 3; break;
                case 4: case 3: soLan = 2; break;
            }
            for (int i = 0; i < soLan; i++)
            {
                ListViewItem item = new ListViewItem("");
                item.ImageIndex = 6-loaiVe+i;

                item.SubItems.Add(arrGT[i]); //6=>0,1,2,3; 5=> 1,2,3; 4=> 2,3; 3=>3,4 
                listViewTK.Items.Add(item);
            }
        }
        private void init_panel()
        {
            panelContainer.Invalidate();
        }
        private void init_listBox()
        {
            listBox1.Items.Clear();
            StreamReader sr = null;
            try
            {
                sr = new StreamReader("KetQuaVietlott\\KetQuaXoSo");
                string ngayLay = dtPickerNgay.Value.ToString("dd/MM/yyyy");

                string tmp = sr.ReadLine();
                string[] arrTmp;

                while (tmp != null)
                {
                    if (ngayLay == tmp)
                    {
                        tmp = sr.ReadLine();
                        arrTmp = tmp.Split(' ');

                        if (arrTmp.Length == loaiVe)
                        {
                            listBox1.Items.Add(tmp);
                        }
                    }
                    else
                    {
                        tmp = sr.ReadLine();
                    }
                }
            }
            catch { }
            finally { sr.Close(); }
            if (listBox1.Items.Count > 0)
            {
                listBox1.SelectedIndex = 0; //chọn item listbox đầu tiên
            }
        }

        private void FromTKNgay_Load(object sender, EventArgs e)
        {
            loaiVe = 6; //chọn loại vé ban đầu là 6

            init_listBox();
            init_lable();
            init_panel();

            //xử lý comboBox
            cbLoaiVe.Items.AddRange(arrLoaiVe);
            cbLoaiVe.SelectedIndex = 3;


            //xử lý listView
            listViewTK.View = View.Details;
            listViewTK.Columns.Add("Trùng khớp", 100);
            listViewTK.Columns.Add("Giải thưởng", 150);
            listViewTK.SmallImageList = imageList1;
            init_listView();
        }
        //Lấy item đc chọn ở listBox để bỏ vào circle
        private List<string> getArrKQXS()
        {
            List<string> list = new List<string>();
            if (listBox1.SelectedItem != null)
            {
                string[] tmp = listBox1.SelectedItem.ToString().Split(' ');
                list.AddRange(tmp);
            }
            return list;
        }

        //Đc gọi khi hàm init_panel thực hiện
        private void panelContainer_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            int x = 10; //vị trí ban đầu là 10
            List<string> listStatic = getArrKQXS(); //Lấy item đc chọn ở listBox

            for (int i = 0; i < listStatic.Count; i++)
            {
                SolidBrush brush = new SolidBrush(Color.Red);    // Màu nền
                SolidBrush brush2 = new SolidBrush(Color.White); // Màu chữ
                Font font = new Font("Arial", 12, FontStyle.Bold); // font chữ

                g.FillEllipse(brush, x, 7, 55, 55);
                g.DrawString(listStatic[i], font, brush2, x + 15, 20);

                x += 85; // hình tiếp theo cách 80
            }
        }
        //xử lý khi chọn loại vé khác ở comboBox: thay đổi hết
        private void cbLoaiVe_SelectedIndexChanged(object sender, EventArgs e)
        {
            //cập nhật lại loại vé
            string tmp = cbLoaiVe.SelectedItem.ToString();
            loaiVe = int.Parse(tmp.Substring(3, 1));

            init_listView();
            init_listBox();
            init_lable();
            init_panel();
        }

        //Xử lý khi thay đổi ngày: chỉ có lable, panel, listbox thay đổi
        private void dtPickerNgay_ValueChanged(object sender, EventArgs e)
        {
            init_listBox();
            init_lable();
            init_panel();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            init_panel();
        }

    }
}
