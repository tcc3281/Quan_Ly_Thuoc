using Quan_Ly_Thuoc.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace Quan_Ly_Thuoc
{
	public partial class FormHoaDonNhap : Form
	{
		ProcessDatabase pd = new ProcessDatabase();
		List<string> listMNV = new List<string>();
		List<string> listMNCC = new List<string>();
		List<string> listThuoc = new List<string>();
		List<ChiTietHDN> dsCTHD = new List<ChiTietHDN>();
		public FormHoaDonNhap()
		{
			InitializeComponent();
		}

		private string IDHDN()
		{
			pd.CreateCMD();
			pd.cmd.CommandText = "Select count(*) from ChiTietHDN";
			pd.Connect();
			int cnt = (int)pd.cmd.ExecuteScalar() + 1;
			pd.Disconnect();

			String result = "HDN";
			for (int i = 0; i < 3 - cnt.ToString().Length; i++)
			{
				result += "0";
			}
			result += (cnt.ToString());
			return result;
		}

		private void FormHoaDonNhap_Load(object sender, EventArgs e)
		{
			// 
			// mathuoc
			// 
			this.mathuoc.Text = "Mã Thuốc";
			this.mathuoc.Width = (int)(tableLayoutPanel1.Width * 0.1);
			// 
			// tenthuoc
			// 
			this.tenthuoc.Text = "Tên Thuốc";
			this.tenthuoc.Width = (int)(tableLayoutPanel1.Width * 0.5);
			// 
			// sl
			// 
			this.sl.Text = "Số Lượng";
			this.sl.Width = (int)(tableLayoutPanel1.Width * 0.1);
			// 
			// dg
			// 
			this.dg.Text = "Đơn giá";
			this.dg.Width = (int)(tableLayoutPanel1.Width * 0.1);
			// 
			// km
			// 
			this.km.Text = "Khuyến mãi";
			this.km.Width = (int)(tableLayoutPanel1.Width * 0.15);
			txtMaHD.Text = IDHDN();
			dgvCTHDN.DataSource = pd.ReadTable("select * from ChiTietHDN");

			DataTable dtNV = pd.ReadTable("select * from NhanVien");
			DataTable dtNCC = pd.ReadTable("select * from NhaCungCap");
			DataTable dtThuoc = pd.ReadTable("select * from DanhMucTHuoc");

			for (int i = 0; i < dtNV.Rows.Count; i++)
			{
				this.cmbNVThucHien.Items.Add(dtNV.Rows[i]["TenNV"]);
				listMNV.Add(dtNV.Rows[i]["MaNhanVien"].ToString());
			}
			for (int i = 0; i < dtNCC.Rows.Count; i++)
			{
				this.cmbNCC.Items.Add(dtNCC.Rows[i]["TenNCC"]);
				listMNCC.Add(dtNCC.Rows[i]["MaNCC"].ToString());
			}
			for (int i = 0; i < dtThuoc.Rows.Count; i++)
			{
				this.cmbThuoc.Items.Add(dtThuoc.Rows[i]["TenThuoc"]);
				listThuoc.Add(dtThuoc.Rows[i]["MaThuoc"].ToString());
			}

		}
		private void TongTien()
		{
			float sum = 0;
			for(int i=0;i<listViewThuoc.Items.Count;i++)
			{
				int sl = int.Parse(listViewThuoc.Items[i].SubItems[2].Text);
				float gia = float.Parse(listViewThuoc.Items[i].SubItems[3].Text);
				float khuyenmai = float.Parse(listViewThuoc.Items[i].SubItems[4].Text);
				sum += sl * gia * (100 - khuyenmai) / 100;
			}
			txtThanhTienHDN.Text = sum.ToString();
		}


		private void txtDonGia_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
			{
				e.Handled = true;
			}
		}


		private void btnIn_Click(object sender, EventArgs e)
		{
			//them hoa don nhap
			string sql = "insert into HoaDonNhap(MaHDN,MaNhanVien,MaNCC,NgayNhap,TongTien) " +
				"values ('" + txtMaHD.Text + "','" + listMNV[cmbNVThucHien.SelectedIndex] + "','"
				+ listMNCC[cmbNCC.SelectedIndex] + "'" +
				",'" + txtNgayNhap.Text + "'," + txtThanhTienHDN.Text + ")";
			pd.RunSQL(sql);
			foreach (var item in dsCTHD)
			{
				item.fomulate_thanhtien();
				pd.RunSQL(add_CTHDN(item));
			}

			//update database
			for(int i = 0; i < listViewThuoc.Items.Count; i++)
			{
				int sl = int.Parse(listViewThuoc.Items[i].SubItems[2].Text);
				float gia = float.Parse(listViewThuoc.Items[i].SubItems[3].Text);
				sql = "update DanhMucThuoc set SLHienCo = isnull(SLHienCo,0) + " + sl +
					", DonGiaNhap = " + gia + ", GiaBan = " + (gia*1.1);
				pd.RunSQL(sql);
			}
			
			Close();
		}
		private string add_CTHDN(ChiTietHDN ct)
		{
			string sql;
			sql = "insert into ChiTietHDN(MaHDN,MaThuoc,SLNhap,DonGia,KhuyenMai,ThanhTien) values" +
				"('" + ct.mahd + "','" + ct.mathuoc + "'," + ct.sl + "," +
				 ct.dongia + "," + ct.khuyenmai + "," + ct.thanhtien + ")";
			return sql;
		}
		private void btnAddTHuoc_Click(object sender, EventArgs e)
		{
			//them thong tin vao list
			ChiTietHDN chiTietHDN = new ChiTietHDN();
			chiTietHDN.mahd = txtMaHD.Text;
			chiTietHDN.mathuoc = listThuoc[cmbThuoc.SelectedIndex];
			chiTietHDN.sl = (int)txtSL.Value;
			chiTietHDN.dongia = float.Parse(txtDonGia.Text);
			chiTietHDN.khuyenmai = float.Parse(txtKhuyenMai.Text);

			bool ck = false;
			int index = 0;
			for (int i = 0; i < listViewThuoc.Items.Count; i++)
			{
				if (listViewThuoc.Items[i].SubItems[1].Text.Equals(cmbThuoc.Text))
				{
					ck = true; index = i; break;
				}
			}

			// hien thi tren list view
			if (ck)
			{
				int sl = int.Parse(listViewThuoc.Items[index].SubItems[2].Text) + chiTietHDN.sl;
				listViewThuoc.Items[index].SubItems[2].Text = sl.ToString();
				listViewThuoc.Items[index].SubItems[3].Text = chiTietHDN.dongia.ToString();
				listViewThuoc.Items[index].SubItems[4].Text = chiTietHDN.khuyenmai.ToString();
			}
			else
			{
				ListViewItem item = new ListViewItem();
				item.Text = chiTietHDN.mathuoc;
				item.SubItems.Add(cmbThuoc.Text);
				item.SubItems.Add(chiTietHDN.sl.ToString());
				item.SubItems.Add(chiTietHDN.dongia.ToString());
				item.SubItems.Add(chiTietHDN.khuyenmai.ToString());
				chiTietHDN.fomulate_thanhtien();
				listViewThuoc.Items.Add(item);
				dsCTHD.Add(chiTietHDN);
			}

			TongTien();
		}

		private void btnSua_Click(object sender, EventArgs e)
		{
			int index = listViewThuoc.SelectedItems[0].Index;
			listViewThuoc.Items[index].SubItems[2].Text = txtSL.Text;
			listViewThuoc.Items[index].SubItems[3].Text = txtDonGia.Text;
			TongTien();
		}
	}
	class ChiTietHDN
	{
		public string mahd { get; set; }
		public string mathuoc { get; set; }
		public int sl { get; set; }
		public float dongia { get; set; }
		public float khuyenmai { get; set; }
		public float thanhtien { get; set; }
		public ChiTietHDN() { }
		public void fomulate_thanhtien()
		{
			thanhtien = sl * dongia;
			thanhtien = thanhtien * (float)((100 - khuyenmai) * 1.0 / 100);
		}


	}
}
