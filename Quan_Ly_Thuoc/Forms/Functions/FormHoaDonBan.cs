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
			cmbKH.Text = "None";
			cmbNV.Text = "None";
		}

		private void CreateHDB(int TrangThai)
		{
			float tien = ThanhTien();

			pd.RunSQL("insert into HoaDonBan(MaHDB, NgayBan, TongTien, MaKhach, MaNhanVien, TrangThai) values('" + maHDB + "', " +
				"CONVERT(date, '" + DateTime.Today.ToString("dd/MM/yyyy") + "', 103), " + tien.ToString() + ", " +
				"(select MaKhach from KhachHang where TenKhach = N'" + cmbKH.Text + "'), " +
				"(select MaNhanVien from NhanVien where TenNV = N'" + cmbNV.Text + "')," + TrangThai + ")");
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

			//Khi goi lai hoa don:
			if (maHDB != "")
			{
				DataTable dtHDB = pd.ReadTable("select * from HoaDonBan where MaHDB = '" + maHDB + "'");
				if (dtHDB.Rows[0]["MaNhanVien"].ToString() != "")
				{
					DataTable dtNV = pd.ReadTable("select * from NhanVien where MaNhanVien = '" + dtHDB.Rows[0]["MaNhanVien"] + "'");
					this.cmbNV.Text = dtNV.Rows[0]["TenNV"].ToString();
				}
				if (dtHDB.Rows[0]["MaKhach"].ToString() != "")
				{
					DataTable dtKH = pd.ReadTable("select * from KhachHang where MaKhach = N'" + dtHDB.Rows[0]["MaKhach"] + "'");
					this.cmbKH.Text = dtKH.Rows[0]["TenKhach"].ToString();
				}
				DataTable dtCTHDB = pd.ReadTable("select * from ChiTietHDB where MaHDB = '" + maHDB + "'");

				for (int i = 0; i < dtCTHDB.Rows.Count; i++)
				{
					ListViewItem item = new ListViewItem();
					dtThuoc = pd.ReadTable("select * from DanhMucThuoc where MaThuoc = '" + dtCTHDB.Rows[i]["MaThuoc"] + "'");
					item.Text = dtThuoc.Rows[0]["TenThuoc"].ToString();
					item.SubItems.Add(dtCTHDB.Rows[i]["SoLuong"].ToString());
					item.SubItems.Add(dtCTHDB.Rows[i]["ThanhTien"].ToString());
					lHDB.Items.Add(item);
				}
			}
			else
			{
				maHDB = "HDB";
				pd.CreateCMD();
				pd.cmd.CommandText = "Select top(1) MaHDB from HoaDonBan order by MaHDB desc";
				pd.Connect();
				int cnt = 0;
				string ma = (string)pd.cmd.ExecuteScalar();
				if (ma == null) cnt = 1;
				else cnt = int.Parse(ma.Substring(3)) + 1;
				
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

		private float UpdateGia(String tenThuoc)
		{
			pd.CreateCMD();
			pd.cmd.CommandText = "select GiaBan from DanhMucThuoc where TenThuoc = N'" + tenThuoc + "'";
			pd.Connect();
			float gia = 0;
			try
			{
				gia = Convert.ToSingle(pd.cmd.ExecuteScalar());
			}
			catch
			{
				gia = 0;
			}
			pd.Disconnect();
			return gia;
		}

		private void listThuoc_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			String tenThuoc = listThuoc.SelectedItem.ToString();
			//cap nhat gia:
			float gia = UpdateGia(tenThuoc);
			//Them thuoc vao list mua
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
				item.SubItems.Add(gia.ToString());
				lHDB.Items.Add(item);
			}
			else
			{
				int sl = int.Parse(lHDB.Items[index].SubItems[1].Text) + 1;
				lHDB.Items[index].SubItems[1].Text = sl.ToString();
				lHDB.Items[index].SubItems[2].Text = (sl * gia).ToString();
			}
		}

		private void btnSuaSL_Click(object sender, EventArgs e)
		{
			int index = lHDB.SelectedItems[0].Index;
			int sl = (int)txtSL.Value;
			lHDB.Items[index].SubItems[1].Text = sl.ToString();
			lHDB.Items[index].SubItems[2].Text = (sl * UpdateGia(lHDB.Items[index].SubItems[0].Text)).ToString();

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
			pd.CreateCMD();
			pd.cmd.CommandText = "Select count(*) from HoaDonBan where MaHDB = '" + maHDB + "'";
			pd.Connect();
			int cnt = (int)pd.cmd.ExecuteScalar();
			pd.Disconnect();
			if (cnt == 1)
			{
				string maNV = "", maKH = "";
				if (cmbNV.Text != "")
				{
					DataTable dtNV = pd.ReadTable("select * from NhanVien where TenNV = N'" + cmbNV.Text + "'");
					maNV = dtNV.Rows[0]["MaNhanVien"].ToString();
				}
				if (cmbKH.Text != "")
				{
					DataTable dtKH = pd.ReadTable("select * from KhachHang where TenKhach = N'" + cmbKH.Text + "'");
					maKH = dtKH.Rows[0]["MaKhach"].ToString();
				}
				pd.RunSQL("update HoaDonBan set TrangThai = 1, " +
					"MaNhanVien = '" + maNV + "', " +
					"MaKhach = '" + maKH + "' " +
					"where MaHDB = '" + maHDB + "'");
			}
			else CreateHDB(1);
			SaveData();
			for (int i = 0; i < lHDB.Items.Count; i++)
			{
				int sl = int.Parse(lHDB.Items[i].SubItems[1].Text);
				string ten = lHDB.Items[i].SubItems[0].Text;
				pd.RunSQL("update DanhMucThuoc set SLHienCo = SLHienCo - " + sl.ToString() + " where TenThuoc = N'" + ten + "'");
			}
			MessageBox.Show("Số tiền thanh toán là: " + ThanhTien());
			this.Close();
		}

		private void btnCatHD_Click(object sender, EventArgs e)
		{
			pd.CreateCMD();
			pd.cmd.CommandText = "Select count(*) from HoaDonBan where MaHDB = '" + maHDB + "'";
			pd.Connect();
			int cnt = (int)pd.cmd.ExecuteScalar();
			pd.Disconnect();
			if (cnt == 1)
			{
				string maNV = "", maKH = "";
				if (cmbNV.Text != "")
				{
					DataTable dtNV = pd.ReadTable("select * from NhanVien where TenNV = N'" + cmbNV.Text + "'");
					maNV = dtNV.Rows[0]["MaNhanVien"].ToString();
				}
				if (cmbKH.Text != "")
				{
					DataTable dtKH = pd.ReadTable("select * from KhachHang where TenKhach = N'" + cmbKH.Text + "'");
					maKH = dtKH.Rows[0]["MaKhach"].ToString();
				}
				MessageBox.Show("update HoaDonBan set TrangThai = 0, " +
					"MaNhanVien = '" + maNV + "', " +
					"MaKhach = '" + maKH + "', " +
					"TongTien = " + ThanhTien() +
					" where MaHDB = '" + maHDB + "'");
			}
			else CreateHDB(0);
			SaveData();
			this.Close();
		}

		private float ThanhTien()
		{
			float tien = 0;
			for (int i = 0; i < lHDB.Items.Count; i++)
			{
				tien += float.Parse(lHDB.Items[i].SubItems[2].Text);
			}

			return tien;
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
