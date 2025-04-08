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
    public partial class FormTKLuotTrung : UserControl
    {
        string[] loaiVearr = { "Vé 6 số", "Vé 5 số", "Vé 4 số", "Vé 3 số" };
        StreamReader sr = null;
        public FormTKLuotTrung()
        {
            InitializeComponent();
        }

        private void init_ListView()
        {
            listViewTK.Items.Clear();

            string[] arrGT = { "Jackpot", "Nhất", "Nhì", "Ba" };
            int soLan = 4;
            switch (loaiVe)
            {
                case 6: soLan = 4; break;
                case 5: soLan = 3; break;
                case 4: case 3: soLan = 2; break;
            }


            sr = new StreamReader("KetQuaVietlott\\TKSoLuong");
            string tmp= sr.ReadLine();
            List<string> list = new List<string>();
            string[] arrTmp;

            try
            {
                while (tmp != null)
                {
                    tmp = sr.ReadLine();
                    arrTmp = tmp.Split(' ');
                    if (int.Parse(arrTmp[1]) == loaiVe)
                    {
                        list.Add(arrTmp[0]);
                    }
                    tmp = sr.ReadLine();
                }
            }
            catch { }
            finally { sr.Close(); }

            for (int i = 0; i < soLan; i++)
            {
                List<string> listTmp = list.FindAll((string s) => { return s == arrGT[i]; });
                ListViewItem item = new ListViewItem("Giải "+arrGT[i]);
                item.SubItems.Add(listTmp.Count.ToString());
                listViewTK.Items.Add(item);
            }

        }
        public static int loaiVe = FormQuaySo.loaiVe;
        private void FormTKLuotTrung_Load(object sender, EventArgs e)
        {
            lbTitle.Text = String.Format("THỐNG KÊ SỐ LƯỢNG GIẢI THƯỞNG LOẠI VÉ {0}", loaiVe);
            loaiVe = 6;
            comboBox1.Items.AddRange(loaiVearr);
            comboBox1.SelectedIndex = 0;

            listViewTK.View = View.Details;
            listViewTK.Columns.Add("Giải thưởng", 200);
            listViewTK.Columns.Add("Số lượng", 200);
            init_ListView();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            loaiVe= int.Parse(comboBox1.SelectedItem.ToString().Substring(3,1));
            lbTitle.Text = String.Format("THỐNG KÊ SỐ LƯỢNG GIẢI THƯỞNG LOẠI VÉ {0}", loaiVe);
            init_ListView();
        }
    }
}
