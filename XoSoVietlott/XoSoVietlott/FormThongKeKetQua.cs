using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XoSoVietlott
{
    public partial class FormThongKeKetQua : Form
    {
        public FormThongKeKetQua()
        {
            InitializeComponent();
            UserControl formTatCaVe = new FormTKTatCaVe();
            tabPage1.Controls.Add(formTatCaVe);
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            TabControl tabControl = (TabControl)sender;
            int n= tabControl.SelectedIndex;
            switch (n) { 
                case 0:
                    UserControl formTatCaVe = new FormTKTatCaVe();
                    tabPage1.Controls.Add(formTatCaVe);
                    break;
                case 1:
                    UserControl formNgay= new FromTKNgay();
                    tabPage2.Controls.Add(formNgay);
                    break;
                case 2:
                    UserControl formSL = new FormTKLuotTrung();
                    tabPage3.Controls.Add(formSL);
                    break;
            }
        }

    }
}
