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
		List<TabPage> tabs = new List<TabPage>();

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
			formNhapThuoc.setAdd();
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
			FlowLayoutPanel flowLayoutPanel=new FlowLayoutPanel();
			bool flag = true;
            foreach (var item in tabControl.SelectedTab.Controls)
			{
				if (item is FlowLayoutPanel)
				{
					flowLayoutPanel = (FlowLayoutPanel)item;
					flowLayoutPanel.Controls.Clear();
					flag = false;
					break;
				}
				else break;
			}
			
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

				flowLayoutPanel.Controls.Add(panel);
			}
			var tabPage = tabControl.SelectedTab;
			if (flag == true)//chua co
			{
				flowLayoutPanel.Dock = DockStyle.Fill;
                tabPage.Controls.Add(flowLayoutPanel);
				flowLayoutPanel.AutoScroll = true;
			}
			
		}

		private void LoadHDN()
		{
			DataTable dtHDN = pd.ReadTable("SELECT * FROM HoaDonNhap");
			for(int i = 0; i < dtHDN.Rows.Count; i++)
			{
				Panel panel = new Panel();
				panel.BorderStyle = BorderStyle.FixedSingle; // Để có viền
				panel.Width = 200; // Điều chỉnh chiều rộng của Panel
				panel.Height = 150; // Điều chỉnh chiều cao của Panel

				Label lblMaHDN = new Label() { Text = "Mã HD:" + dtHDN.Rows[i]["MaHDN"] };
				Label lblNgayLap = new Label()
				{
					Text = "Ngày lập: " + DateTime.Parse(dtHDN.Rows[i]["NgayNhap"].
					ToString()).ToString("dd/MM/yyyy"),
					AutoSize = true,
					MaximumSize = new System.Drawing.Size(200, 0)
				};
				Label lblTongTien = new Label() { Text = "Tổng tiền:" + dtHDN.Rows[i]["TongTien"].ToString() };

				lblMaHDN.Location = new Point(10, 10);
				lblNgayLap.Location = new Point(10, 40);
				lblTongTien.Location = new Point(10, 70);

				Button viewButton = new Button() { Text = "Xem hóa đơn", AutoSize = true };
				Button cancelButton = new Button() { Text = "Hủy", AutoSize = true };
				viewButton.Location = new Point(10, 100);
				cancelButton.Location = new Point(10 + viewButton.Width + 10, 100);

				panel.Controls.Add(lblMaHDN);
				panel.Controls.Add(lblNgayLap);
				panel.Controls.Add(lblTongTien);
				panel.Controls.Add(viewButton);

				flowLayoutPanel2.Controls.Add(panel);
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

            foreach (Control control in tabControl.SelectedTab.Controls)
            {
                if (control is FlowLayoutPanel)
                {
                    FlowLayoutPanel flowLayoutPanel = (FlowLayoutPanel)control;
					flowLayoutPanel.Controls.Clear();
					break;
                }
            }
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
			if (tabControl.TabCount == 0) return;
			if (tabControl.SelectedTab.Text != "Danh sách hóa đơn bán") return;

            foreach (Control control in tabControl.SelectedTab.Controls)
            {
                if (control is FlowLayoutPanel)
                {
                    FlowLayoutPanel flowLayoutPanel = (FlowLayoutPanel)control;
                    flowLayoutPanel.Controls.Clear();
                    break;
                }
            }
            LoadHDB_Cat();
		}
		private void Form1_Load(object sender, EventArgs e)
		{
			pd.CreateCMD();
			pd.cmd.CommandText = "Select count(*) from KhachHang";
			pd.Connect();
			int cnt = (int)pd.cmd.ExecuteScalar();
			pd.Disconnect();

			LoadHDN();
			
		}
        private void xóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TabPage selectedTab = tabControl.SelectedTab;
            tabControl.TabPages.Remove(selectedTab);
        }
		private TabPage newTabPage(string name)
		{
            TabPage tabPage = new TabPage();
            tabPage.ContextMenuStrip = this.menuStripTabPage;
            tabPage.Text = name;
            tabPage.UseVisualStyleBackColor = true;
            tabControl.TabPages.Add(tabPage);
            tabControl.SelectedTab = tabPage;
			return tabPage;
        }
        private void medicineToolStripMenuItem_Click(object sender, EventArgs e)
        {
			string name = "Danh sách thuốc";
			foreach( TabPage item in tabControl.TabPages)
			{
				if (item.Text == name)
				{
                    tabControl.SelectedTab = item;
                    return;
				}
			}
            //tạo tabpage mới
            TabPage tabPage = newTabPage(name);
			//them datagridview
			DataGridView data= new DataGridView();
			string sql = "select a.MaThuoc,a.TenThuoc,a.ThanhPhan,a.DonGiaNhap,a.GiaBan,a.SLHienCo,a.NgaySX,a.HanSD,a.ChongChiDinh,b.TenNSX,c.TenDangDieuChe,d.TenDonViTinh\r\nfrom DanhMucThuoc a join NuocSX b on a.MaNSX=b.MaNSX\r\n\t\tjoin DangDieuChe c on a.MaDangDieuChe=c.MaDangDieuChe\r\n\t\tjoin DonViTinh d on a.MaDV=d.MaDV";

            data.DataSource = pd.ReadTable(sql);
			tabPage.Controls.Add(data);
			data.Dock= DockStyle.Fill;
        }
        private void cútomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string name = "Danh sách khách hàng";
            foreach (TabPage item in tabControl.TabPages)
            {
                if (item.Text == name)
                {
                    tabControl.SelectedTab = item;
                    return;
                }
            }
            //tạo tabpage mới
            TabPage tabPage = newTabPage(name);
            //them datagridview
            DataGridView data = new DataGridView();
            data.DataSource = pd.ReadTable("select * from KhachHang");
            tabPage.Controls.Add(data);
            data.Dock = DockStyle.Fill;
        }

        private void staffToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string name = "Danh sách NhanVien";
            foreach (TabPage item in tabControl.TabPages)
            {
                if (item.Text == name)
                {
                    tabControl.SelectedTab = item;
                    return;
                }
            }
            //tạo tabpage mới
            TabPage tabPage = newTabPage(name);
			string sql= "select a.MaNhanVien,a.TenNV,a.GioiTinh,a.GioiTinh,a.DiaChi,a.DienThoai,b.TenTrinhDo,c.TenChuyenMon\r\nfrom NhanVien a join TrinhDo b on a.MaTrinhDo=b.MaTrinhDo\r\n\t\tjoin ChuyenMon c on a.MaChuyenMon=c.MaChuyenMon";
            //them datagridview
            DataGridView data = new DataGridView();
            data.DataSource = pd.ReadTable(sql);
            tabPage.Controls.Add(data);
            data.Dock = DockStyle.Fill;
        }

        private void thuốcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormNhapThuoc formNhapThuoc = new FormNhapThuoc();
            formNhapThuoc.setUpdate();
            formNhapThuoc.ShowDialog();
        }

        private void hóaĐơnBánToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string name = "Danh sách hóa đơn bán";
            foreach (TabPage item in tabControl.TabPages)
            {
                if (item.Text == name)
                {
                    tabControl.SelectedTab = item;
                    return;
                }
            }
            //tạo tabpage mới
            TabPage tabPage = newTabPage(name);
			LoadHDB_Cat();
        }

    }
}
