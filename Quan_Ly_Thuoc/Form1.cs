using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Quan_Ly_Thuoc.Forms.Function;
using Quan_Ly_Thuoc.Forms.Login;
using Quan_Ly_Thuoc.Forms.Search;
namespace Quan_Ly_Thuoc
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void signInToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.ShowDialog();
        }

        private void searchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Search search=new Search();
            search.ShowDialog();
        }

        private void hóaĐơnBánToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormHoaDonBan hoaDon = new FormHoaDonBan();
            hoaDon.Show();
        }

        private void thuỗToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormNhapThuoc formNhapThuoc = new FormNhapThuoc();
            formNhapThuoc.ShowDialog();
        }
    }
}
