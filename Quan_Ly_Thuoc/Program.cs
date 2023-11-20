using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Quan_Ly_Thuoc.Forms.Search;
using Quan_Ly_Thuoc.Forms.Functions;
using Quan_Ly_Thuoc.Model;

namespace Quan_Ly_Thuoc
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //main
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new QL_Thuoc());
            //Application.Run(new FormSearchHDN());
        }
    }
}
