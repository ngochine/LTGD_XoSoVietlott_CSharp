using System;
using System.Windows.Forms;

namespace XoSoVietlott
{
    public partial class FormThongKeKetQua : Form
    {
        string name;
        public FormThongKeKetQua(string name)
        {
            InitializeComponent();
            UserControl formTatCaVe = new FormTKTatCaVe(name, "");
            tabPage1.Controls.Add(formTatCaVe);
            this.name = name;
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            TabControl tabControl = (TabControl)sender;
            int n= tabControl.SelectedIndex;
            switch (n) { 
                case 0:
                    UserControl formTatCaVe = new FormTKTatCaVe(name, "");
                    tabPage1.Controls.Add(formTatCaVe);
                    break;
                case 1:
                    UserControl formNgay= new FromTKNgay(name);
                    tabPage2.Controls.Add(formNgay);
                    break;
                case 2:
                    UserControl formSL = new FormTKLuotTrung(name);
                    tabPage3.Controls.Add(formSL);
                    break;
            }
        }

        private void FormThongKeKetQua_Load(object sender, EventArgs e)
        {

        }
    }
}
