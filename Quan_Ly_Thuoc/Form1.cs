﻿using System;
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
			FormHoaDonBan hoaDon = new FormHoaDonBan("");
			hoaDon.FormClosed += FormHoaDonBan_FormClosed;
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
		private void nhàCungCấpToolStripMenuItem_Click(object sender, EventArgs e)
		{
			FormNhaCungCap ncc = new FormNhaCungCap();
			ncc.ShowDialog();
		}

		private void kháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
		{
			FormKhachHang kh = new FormKhachHang();
			kh.ShowDialog();
		}

		private void LoadHDB_Cat()
		{
			DataTable dtHDB = pd.ReadTable("SELECT * FROM HoaDonBan");

			for (int i = 0; i < dtHDB.Rows.Count; i++)
			{
				Panel panel = new Panel();
				panel.BorderStyle = BorderStyle.FixedSingle; // Để có viền
				panel.Width = 200; // Điều chỉnh chiều rộng của Panel
				panel.Height = 170; // Điều chỉnh chiều cao của Panel

				Label lblMaHDB = new Label() { Text = "Mã HD:" + dtHDB.Rows[i]["MaHDB"] };
				Label lblNgayLap = new Label() { Text = "Ngày lập: " + DateTime.Parse(dtHDB.Rows[i]["NgayBan"].
					ToString()).ToString("dd/MM/yyyy"),
					AutoSize = true,
					MaximumSize = new System.Drawing.Size(200, 0)
				};
				Label lblTongTien = new Label() { Text = "Tổng tiền:" + dtHDB.Rows[i]["TongTien"].ToString() };
				Label lblTrangThai = new Label();
				int ck = int.Parse(dtHDB.Rows[i]["TrangThai"].ToString());
				// Kiểm tra giá trị của cột "TrangThai"
				if (ck == 1)
				{
					lblTrangThai.Text = "Đã thanh toán.";
					lblTrangThai.ForeColor = Color.Green; // Màu xanh lá
				}
				else
				{
					lblTrangThai.Text = "Chưa thanh toán.";
					lblTrangThai.ForeColor = Color.Red; // Màu đỏ
				}
				// Điều chỉnh vị trí và kích thước của các Label
				lblMaHDB.Location = new Point(10, 10);
				lblNgayLap.Location = new Point(10, 40);
				lblTongTien.Location = new Point(10, 70);
				lblTrangThai.Location = new Point(10, 100);

				Button viewButton = new Button() { Text = "Xem hóa đơn", AutoSize = true };
				// Lưu ID vào Tag của Button để có thể lấy khi nhấp vào nó
				viewButton.Tag = dtHDB.Rows[i]["MaHDB"];
				// Thêm sự kiện Click
				viewButton.Click += ViewButton_Click;
				Button cancelButton = new Button() { Text = "Hủy", AutoSize = true };
				// Lưu ID vào Tag của Button để có thể lấy khi nhấp vào nó
				cancelButton.Tag = dtHDB.Rows[i]["MaHDB"];
				// Thêm sự kiện Click
				cancelButton.Click += CancelButton_Click;
				// Điều chỉnh vị trí của các Button
				viewButton.Location = new Point(10, 130);
				cancelButton.Location = new Point(10 + viewButton.Width + 10, 130);

				panel.Controls.Add(lblMaHDB);
				panel.Controls.Add(lblNgayLap);
				panel.Controls.Add(lblTongTien);
				panel.Controls.Add(lblTrangThai);
				panel.Controls.Add(viewButton);
				if(ck == 0)
				panel.Controls.Add(cancelButton);

				flowLayoutPanel1.Controls.Add(panel);
			}
		}

		private void CancelButton_Click(object sender, EventArgs e)
		{
			string maHDB = (string)((Button)sender).Tag;
			pd.CreateCMD();
			pd.cmd.CommandText = "Select count(*) from HoaDonBan";
			pd.Connect();
			pd.RunSQL("delete ChiTietHDB where MaHDB = '" + maHDB + "'");
			pd.RunSQL("delete HoaDonBan where MaHDB = '" + maHDB + "'");
			pd.Disconnect();

			flowLayoutPanel1.Controls.Clear();
			LoadHDB_Cat();
		}

		private void ViewButton_Click(object sender, EventArgs e)
		{
			string maHDB = (string)((Button)sender).Tag;
			FormHoaDonBan ct = new FormHoaDonBan(maHDB);
			ct.FormClosed += FormHoaDonBan_FormClosed;
			ct.ShowDialog();
		}

		private void FormHoaDonBan_FormClosed(object sender, FormClosedEventArgs e)
		{
			flowLayoutPanel1.Controls.Clear();
			LoadHDB_Cat();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			pd.CreateCMD();
			pd.cmd.CommandText = "Select count(*) from KhachHang";
			pd.Connect();
			int cnt = (int)pd.cmd.ExecuteScalar();
			pd.Disconnect();
			if(cnt == 0)
			{
				pd.RunSQL("insert into KhachHang(MaKhach, TenKhach) values('KH001', 'None')");
				pd.RunSQL("insert into NhanVien(MaNhanVien, TenNV) values('NV001', 'None')");
			}

			LoadHDB_Cat();
			
		}

        private void xóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TabPage selectedTab = tabControl.SelectedTab;

            // Xóa tabpage đó khỏi tabcontrol
            tabControl.TabPages.Remove(selectedTab);
        }

		
	}
}
