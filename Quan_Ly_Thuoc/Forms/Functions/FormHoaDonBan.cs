using Quan_Ly_Thuoc.Data;
using Quan_Ly_Thuoc.Forms.Functions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Quan_Ly_Thuoc
{
	public partial class FormHoaDonBan : Form
	{
		ProcessDatabase pd = new ProcessDatabase();
		String maHDB = "";

		private List<string> lThuoc = new List<string>();
		public FormHoaDonBan(String maHDB)
		{
			if (maHDB != null)
			{
				this.maHDB = maHDB;
			}

			InitializeComponent();
		}

		public void LoadCmb()
		{
			DataTable dtNV = pd.ReadTable("Select * from NhanVien");
			DataTable dtKH = pd.ReadTable("Select * from KhachHang");

			for (int i = 0; i < dtNV.Rows.Count; i++)
				this.cmbNV.Items.Add(dtNV.Rows[i]["TenNV"]);

			for (int i = 0; i < dtKH.Rows.Count; i++)
				this.cmbKH.Items.Add(dtKH.Rows[i]["TenKhach"]);
		}

		private void CreateHDB()
		{
			int tien = 0;
			for (int i = 0; i < lHDB.Items.Count; i++)
			{
				tien += int.Parse(lHDB.Items[i].SubItems[2].Text);
			}

			pd.RunSQL("insert into HoaDonBan values('" + maHDB + "', " +
				"CONVERT(date, '" + DateTime.Today.ToString("dd/MM/yyyy") + "', 103), " + tien.ToString() + ", " +
				"(select MaKhach from KhachHang where TenKhach = '" + cmbKH.Text + "'), " +
				"(select MaNhanVien from NhanVien where TenNV = '" + cmbNV.Text + "'))");
			//	MessageBox.Show("HoaDonBan (MaHDB, NgayBan, TongTien, MaKhach, MaNhanVien) values('" + maHDB + "', " +
			//		"CONVERT(date, '" + DateTime.Today.ToString("dd/MM/yyyy") + "', 103), 0, " +
			//		"(select MaKhach from KhachHang where TenKhach = N'" + cmbKH.Text + "'), " +
			//		"(select MaNhanVien from NhanVien where TenNV = N'" + cmbNV.Text + "'))");
		}

		private void FormHoaDon_Load(object sender, EventArgs e)
		{
			LoadCmb();
			DataTable dtThuoc = pd.ReadTable("Select * from DanhMucThuoc");
			for (int i = 0; i < dtThuoc.Rows.Count; i++)
				lThuoc.Add(dtThuoc.Rows[i]["TenThuoc"].ToString());

			foreach (string s in lThuoc)
			{
				listThuoc.Items.Add(s);
			}

			txtSearchThuoc.TextChanged += txtSreachThuoc_TextChanged;

			if (maHDB.Length != 7)
			{
				maHDB = "HDB";
				pd.CreateCMD();
				pd.cmd.CommandText = "Select count(*) from HoaDonBan";
				pd.Connect();
				int cnt = (int)pd.cmd.ExecuteScalar() + 1;
				pd.Disconnect();

				for (int i = 0; i < 3 - cnt.ToString().Length; i++)
				{
					maHDB += "0";
				}
				maHDB += cnt.ToString();
			}

			lblMa.Text += maHDB;
		}

		private void txtSreachThuoc_TextChanged(object sender, EventArgs e)
		{
			var newList = new List<string>(lThuoc.Cast<string>());
			var itemsToRemove = new List<string>();
			string searchText = txtSearchThuoc.Text;

			foreach (string s in newList)
			{
				if (!s.Contains(searchText))
				{
					itemsToRemove.Add(s);
				}
			}

			foreach (string item in itemsToRemove)
			{
				newList.Remove(item);
			}

			listThuoc.Items.Clear();
			listThuoc.Items.AddRange(newList.ToArray());
		}


		private void FormHoaDon_SizeChanged(object sender, EventArgs e)
		{
			setWidthColumns();
		}

		//chỉnh các component khi thu phóng
		private void setWidthColumns()
		{
			// chỉnh trong listview
			int adjust0 = panel7.Width;
			lHDB.Columns[0].Width = (int)(adjust0 * 0.45);
			lHDB.Columns[1].Width = (int)(adjust0 * 0.25);
			lHDB.Columns[2].Width = (int)(adjust0 * 0.30);

			//chỉnh các textbox và button

			btnSearchThuoc.Height = txtSearchThuoc.Height;

		}

		private void listThuoc_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			String tenThuoc = listThuoc.SelectedItem.ToString();

			int index = -1;
			for (int i = 0; i < lHDB.Items.Count; i++)
			{
				if (lHDB.Items[i].SubItems[0].Text == tenThuoc)
				{
					index = i;
					break;
				}
			}

			if (index == -1)
			{
				ListViewItem item = new ListViewItem();

				item.Text = tenThuoc;
				item.SubItems.Add("1");
				item.SubItems.Add("10000");
				lHDB.Items.Add(item);
			}
			else
			{
				int sl = int.Parse(lHDB.Items[index].SubItems[1].Text) + 1;
				lHDB.Items[index].SubItems[1].Text = sl.ToString();
				lHDB.Items[index].SubItems[2].Text = (sl * 10000).ToString();
			}
		}

		private void btnSuaSL_Click(object sender, EventArgs e)
		{
			int index = lHDB.SelectedItems[0].Index;
			int sl = (int)txtSL.Value;
			lHDB.Items[index].SubItems[1].Text = sl.ToString();
			lHDB.Items[index].SubItems[2].Text = (sl * 10000).ToString();

			txtSL.ResetText();
		}

		private void lHDB_DoubleClick(object sender, EventArgs e)
		{
			int index = lHDB.SelectedItems[0].Index;
			txtSL.Value = int.Parse(lHDB.Items[index].SubItems[1].Text);
		}

		private void btnRemove_Click(object sender, EventArgs e)
		{
			int index = lHDB.SelectedItems[0].Index;
			lHDB.Items.RemoveAt(index);
		}
		private void btnThanhToan_Click(object sender, EventArgs e)
		{
			CreateHDB();
			SaveData();
			FormChiTietHDB CTHDB = new FormChiTietHDB(maHDB);
			CTHDB.ShowDialog();
		}

		private void btnCatHD_Click(object sender, EventArgs e)
		{
			maHDB += 'C';
			CreateHDB();
			SaveData();
			this.Close();
		}

		private void SaveData()
		{
			pd.RunSQL("delete from ChiTietHDB where MaHDB = '" + maHDB + "'");
			for (int i = 0; i < lHDB.Items.Count; i++)
			{
				string sql = "insert into ChiTietHDB values( " + lHDB.Items[i].SubItems[1].Text +
					", 0, " + lHDB.Items[i].SubItems[2].Text + ", '" + maHDB + "', " +
					"(select MaThuoc from DanhMucThuoc where TenThuoc = '" +
					lHDB.Items[i].SubItems[0].Text + "'))";
				pd.RunSQL(sql);
			}
		}
	}
}
