using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XoSoVietlott
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            string name = "";
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


            using (FormWelcome welcome = new FormWelcome())
            {
                welcome.ShowDialog();
            }



            using (FormLogin login = new FormLogin())
            {
                if (login.ShowDialog() == DialogResult.OK)
                {
                   name =  login.TenDangNhap;
                }
            }


            Application.Run(new FormMenu(name));
     
        }
    }
}
