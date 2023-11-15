using Quan_Ly_Thuoc.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quan_Ly_Thuoc.Forms.Functions
{
	public partial class FormChiTietHDB : Form
	{
		ProcessDatabase pd = new ProcessDatabase();
		String maHDB;
		public FormChiTietHDB(String maHDB)
		{
			InitializeComponent();
			this.maHDB = maHDB;
		}

		private void FormChiTietHDB_Load(object sender, EventArgs e)
		{
			String sql = "select TenThuoc, SoLuong, GiaBan " +
				"from DanhMucThuoc a inner join ChiTietHDB b on a.MaThuoc = b.MaThuoc" +
				" where MaHDB = '" + this.maHDB + "'";
			//MessageBox.Show(sql);
			dgvCTHDB.DataSource = pd.ReadTable(sql);
		}
	}
}
