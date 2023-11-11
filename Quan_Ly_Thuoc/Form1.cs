using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Quan_Ly_Thuoc.Data;
using Quan_Ly_Thuoc.Forms.Function;
using Quan_Ly_Thuoc.Forms.Functions;
using Quan_Ly_Thuoc.Forms.Login;
using Quan_Ly_Thuoc.Forms.Search;
namespace Quan_Ly_Thuoc
{
	public partial class Form1 : Form
	{
		ProcessDatabase pd = new ProcessDatabase();
		internal static bool addThuoc = true;

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
			Search search = new Search();
			search.ShowDialog();
		}

		private void hóaĐơnBánToolStripMenuItem_Click(object sender, EventArgs e)
		{
			FormHoaDonBan hoaDon = new FormHoaDonBan();
			hoaDon.ShowDialog();
		}

		private void thuỗToolStripMenuItem_Click(object sender, EventArgs e)
		{
			FormNhapThuoc formNhapThuoc = new FormNhapThuoc();
			formNhapThuoc.ShowDialog();
		}

		private void hóaĐơnNhậpToolStripMenuItem_Click(object sender, EventArgs e)
		{
			FormHoaDonNhap hoaDon = new FormHoaDonNhap();
			hoaDon.ShowDialog();
		}
		private void nhânViênToolStripMenuItem_Click(object sender, EventArgs e)
		{
			FormThemNV nv = new FormThemNV();
			nv.ShowDialog();
		}
		private void Form1_Load(object sender, EventArgs e)
		{
			if (addThuoc == true)
			{
				addThuoc = false;
				dgvThuoc.DataSource = pd.ReadTable("select * from DanhMucThuoc");
			}
		}


	}
}
