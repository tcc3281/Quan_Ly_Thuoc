using System;
using System.Collections.Generic;
using System.Data;
using System.DirectoryServices.ActiveDirectory;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using BTL;
using Quan_Ly_Thuoc.Data;
using Quan_Ly_Thuoc.Forms.Function;
using Quan_Ly_Thuoc.Forms.Functions;
using Quan_Ly_Thuoc.Forms.Login;
using Quan_Ly_Thuoc.Forms.Reports;
using Quan_Ly_Thuoc.Forms.Search;
using Excel = Microsoft.Office.Interop.Excel;
namespace Quan_Ly_Thuoc
{
    public partial class QL_Thuoc : Form
    {
        ProcessDatabase pd = new ProcessDatabase();
        DataGridView temp=new DataGridView();
        public QL_Thuoc()
        {
            InitializeComponent();
        }
        //show login
        private void signInToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.ShowDialog();
        }
        //show form hdb
        private void hóaĐơnBánToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormHoaDonBan hoaDon = new FormHoaDonBan("");
            hoaDon.FormClosed += FormHoaDonBan_FormClosed;
            hoaDon.ShowDialog();
        }
        //show form thuoc
        private void thuỗToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormNhapThuoc formNhapThuoc = new FormNhapThuoc();
            formNhapThuoc.setAdd();
            formNhapThuoc.ShowDialog();
        }
        //show form hdn
        private void hóaĐơnNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormHoaDonNhap hoaDon = new FormHoaDonNhap("");
            hoaDon.FormClosed += FormHoaDonNhap_FormClosed;
            hoaDon.ShowDialog();
        }
        //show form nhan vien
        private void nhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormThemNV nv = new FormThemNV();
            nv.ShowDialog();
        }
        //show form nha cung cap
        private void nhàCungCấpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormNhaCungCap ncc = new FormNhaCungCap();
            ncc.ShowDialog();
        }
        //show form khach hang
        private void kháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormKhachHang kh = new FormKhachHang();
            kh.ShowDialog();
        }
        //load tabpage hdb
        private void LoadHDB_Cat()
        {
            DataTable dtHDB = pd.ReadTable("SELECT * FROM HoaDonBan");
            FlowLayoutPanel flowLayoutPanel = new FlowLayoutPanel();
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
                Label lblNgayLap = new Label()
                {
                    Text = "Ngày lập: " + DateTime.Parse(dtHDB.Rows[i]["NgayBan"].
                    ToString()).ToString("dd/MM/yyyy"),
                    AutoSize = true,
                    MaximumSize = new System.Drawing.Size(200, 0)
                };
                Label lblTongTien = new Label() { Text = "Tổng tiền: " + dtHDB.Rows[i]["TongTien"].ToString() };
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
                viewButton.Click += ViewButtonHDB_Click;
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
                if (ck == 0)
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
        //load tabpage hdn
        private void LoadHDN(string medicine = "", string staff = "", string producer = "")
        {
            const string string_empty = "";
            string sql = "select distinct a.MaHDN,a.MaNhanVien,a.MaNCC,a.NgayNhap,a.TongTien from HoaDonNhap a join ChiTIetHDN b on a.MaHDN=b.MaHDN ";
            int res = 0;
            if (producer != string_empty)
            {
                sql += "where ";
                sql += "a.MaNCC= N'" + producer + "'";
                res++;
            }
            if (staff != string_empty)
            {
                if (res > 0) sql += " and ";
                else sql += "where ";
                sql += "a.MaNhanVien= N'" + staff + "'";
                res++;
            }
            if (medicine != string_empty)
            {
                if (res > 0) sql += " and ";
                else sql += "where ";
                sql += "b.MaThuoc= N'" + medicine + "'";
            }

            DataTable dtHDN = pd.ReadTable(sql);
            FlowLayoutPanel flowLayoutPanel = new FlowLayoutPanel();
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

            for (int i = 0; i < dtHDN.Rows.Count; i++)
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
                Label lblTongTien = new Label() { Text = "Tổng tiền: " + dtHDN.Rows[i]["TongTien"].ToString() };

                lblMaHDN.Location = new Point(10, 10);
                lblNgayLap.Location = new Point(10, 40);
                lblTongTien.Location = new Point(10, 70);

                Button viewButton = new Button() { Text = "Xem hóa đơn", AutoSize = true };
                viewButton.Location = new Point(10, 100);
                //Them su kien xem
                viewButton.Tag = dtHDN.Rows[i]["MaHDN"];
                viewButton.Click += ViewButtonHDN_Click;

                panel.Controls.Add(lblMaHDN);
                panel.Controls.Add(lblNgayLap);
                panel.Controls.Add(lblTongTien);
                panel.Controls.Add(viewButton);

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
        private void ViewButtonHDN_Click(object sender, EventArgs e)
        {
            string maHDN = (string)((Button)sender).Tag;
            FormHoaDonNhap ct = new FormHoaDonNhap(maHDN);
            ct.FormClosed += FormHoaDonNhap_FormClosed;
            ct.ShowDialog();
        }
        private void FormHoaDonNhap_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (tabControl.TabCount == 0) return;
            if (tabControl.SelectedTab.Text != "Danh sách hóa đơn nhập") return;

            foreach (Control control in tabControl.SelectedTab.Controls)
            {
                if (control is FlowLayoutPanel)
                {
                    FlowLayoutPanel flowLayoutPanel = (FlowLayoutPanel)control;
                    flowLayoutPanel.Controls.Clear();
                    break;
                }
            }
            LoadHDN();
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
        private void ViewButtonHDB_Click(object sender, EventArgs e)
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
            data.RowHeaderMouseDoubleClick+=new System.Windows.Forms.DataGridViewCellMouseEventHandler(double_click);
            string sql = "select a.MaThuoc as 'Mã Thuốc',a.TenThuoc as 'Tên Thuốc',a.ThanhPhan as 'Thành phần',a.DonGiaNhap as 'Giá nhập' ,a.GiaBan as 'Giá bán',a.SLHienCo as 'Số lượng',a.NgaySX as 'Ngày sản xuất',a.HanSD as 'Hạn sử dụng',a.ChongChiDinh as 'Chống chỉ định',b.TenNSX as 'Nước sản xuất',c.TenDangDieuChe as 'Dạng điều chế',d.TenDonViTinh as 'Đơn vị tính'\r\nfrom DanhMucThuoc a join NuocSX b on a.MaNSX=b.MaNSX\r\n\t\tjoin DangDieuChe c on a.MaDangDieuChe=c.MaDangDieuChe\r\n\t\tjoin DonViTinh d on a.MaDV=d.MaDV";
            data.DataSource = pd.ReadTable(sql);
            tabPage.Controls.Add(data);
            data.Dock = DockStyle.Fill;
            data.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            void double_click(object s, DataGridViewCellMouseEventArgs en)
            {
                var row = data.SelectedRows;

                FormNhapThuoc formNhapThuoc = new FormNhapThuoc();
                formNhapThuoc.open_medicine(row[0].Cells["Mã Thuốc"].Value.ToString());
                formNhapThuoc.setUpdate();
                formNhapThuoc.ShowDialog();

            }
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
            data.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(double_click);
            string sql = "select MaKhach as N'Mã khách', TenKhach as N'Tên khách' , DiaChi as N'Địa chỉ', DienThoai as N'Số điện thoại' from KhachHang";
            data.DataSource = pd.ReadTable(sql);
            tabPage.Controls.Add(data);
            data.Dock = DockStyle.Fill;
            data.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            void double_click(object s, DataGridViewCellMouseEventArgs en)
            {
                var row = data.SelectedRows;
               
                FormKhachHang formkhach = new FormKhachHang();
                formkhach.set_view(row[0].Cells["Mã Khách"].Value.ToString());
                formkhach.ShowDialog();

            }
        }
        private void staffToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string name = "Danh sách Nhân viên";
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
            string sql = "select a.MaNhanVien as N'Mã nhân viên',a.TenNV as N'Tên nhân viên',a.GioiTinh as N'Giới tính',a.DiaChi as N'Địa chỉ',a.DienThoai as N'Số điện thoại',b.TenTrinhDo as N'Trình độ',c.TenChuyenMon as N'Chuyên môn'\r\nfrom NhanVien a join TrinhDo b on a.MaTrinhDo=b.MaTrinhDo\r\n\t\tjoin ChuyenMon c on a.MaChuyenMon=c.MaChuyenMon";
            //them datagridview
            DataGridView data = new DataGridView();
            data.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(double_click);
            data.DataSource = pd.ReadTable(sql);
            tabPage.Controls.Add(data);
            data.Dock = DockStyle.Fill;
            data.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            void double_click(object s, DataGridViewCellMouseEventArgs en)
            {
                var row = data.SelectedRows;

                FormThemNV form = new FormThemNV();
                form.showNV(row[0].Cells["Mã nhân viên"].Value.ToString());
                form.ShowDialog();

            }
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
        public void add_tabpage_HDN(string medicine = "", string staff = "", string producer = "")
        {
            string name = "Danh sách hóa đơn nhập";
            bool flag = true;
            foreach (TabPage item in tabControl.TabPages)
            {
                if (item.Text == name)
                {
                    tabControl.SelectedTab = item;
                    flag = false;
                    break;
                }
            }
            if (flag) newTabPage(name);
            LoadHDN(medicine, staff, producer);
        }
        private void thuocToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SearchThuoc search = new SearchThuoc();
            search.ShowDialog();
        }
        private void billToolStripMenuItem_Click(object sender, EventArgs e)
        {
            add_tabpage_HDN();
        }
        private void hoaĐonBanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormSearchHDN form = new FormSearchHDN(this);
            form.ShowDialog();
        }

        private void thuốcCònHạnSửDụngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormThuocConHSD f = new FormThuocConHSD();
            f.ShowDialog();
        }

        private void danhSáchHóaĐơnNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormdsHDN f = new FormdsHDN();
            f.ShowDialog();
        }

        private void danhSáchHóaĐơnBánToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormdsHDB f = new FormdsHDB();
            f.ShowDialog();
        }
        private void danhSáchNhânViênToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormdsNV f = new FormdsNV();
            f.ShowDialog();
        }
        private void danhSachThuocToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string sql = "select a.MaThuoc as 'Mã Thuốc',a.TenThuoc as 'Tên Thuốc',a.ThanhPhan as 'Thành phần',a.DonGiaNhap as 'Giá nhập' ,a.GiaBan as 'Giá bán',a.SLHienCo as 'Số lượng',a.NgaySX as 'Ngày sản xuất',a.HanSD as 'Hạn sử dụng',a.ChongChiDinh as 'Chống chỉ định',b.TenNSX as 'Nước sản xuất',c.TenDangDieuChe as 'Dạng điều chế',d.TenDonViTinh as 'Đơn vị tính'\r\nfrom DanhMucThuoc a join NuocSX b on a.MaNSX=b.MaNSX\r\n\t\tjoin DangDieuChe c on a.MaDangDieuChe=c.MaDangDieuChe\r\n\t\tjoin DonViTinh d on a.MaDV=d.MaDV";
            DataTable dsThuoc = pd.ReadTable(sql);

            Excel.Application exapp = new Excel.Application();
            Excel.Workbook exbook = (Excel.Workbook)exapp.Workbooks.Add(Excel.XlWBATemplate.xlWBATWorksheet);
            Excel.Worksheet exsheet = (Excel.Worksheet)exapp.Worksheets[1];


            exsheet.get_Range("A2:L2").Merge(true);
            exsheet.get_Range("A2").Font.Size = 16;
            exsheet.get_Range("A2").Font.Color = Color.Red;
            exsheet.get_Range("A2").Font.Bold = true;
            exsheet.get_Range("A2").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            exsheet.get_Range("A2").Value = "Danh sách thuốc của cửa hàng";

            exsheet.Name = "Danh sách thuốc";
            exbook.Activate();

            exsheet.get_Range("A5").Font.Size = 14;
            exsheet.get_Range("A5").Font.Bold = true;
            exsheet.get_Range("A5").Value = "Mã Thuốc";


            exsheet.get_Range("B5").Font.Size = 14;
            exsheet.get_Range("B5").Font.Bold = true;
            exsheet.get_Range("B5").Value = "Tên Thuốc";

            exsheet.get_Range("C5").Font.Size = 14;
            exsheet.get_Range("C5").Font.Bold = true;
            exsheet.get_Range("C5").Value = "Thành Phần";

            exsheet.get_Range("D5").Font.Size = 14;
            exsheet.get_Range("D5").Font.Bold = true;
            exsheet.get_Range("D5").Value = "Giá nhập";

            exsheet.get_Range("E5").Font.Size = 14;
            exsheet.get_Range("E5").Font.Bold = true;
            exsheet.get_Range("E5").Value = "Giá bán";

            exsheet.get_Range("F5").Font.Size = 14;
            exsheet.get_Range("F5").Font.Bold = true;
            exsheet.get_Range("F5").Value = "Số lượng";

            exsheet.get_Range("G5").Font.Size = 14;
            exsheet.get_Range("G5").Font.Bold = true;
            exsheet.get_Range("G5").Value = "Ngày sản xuất";

            exsheet.get_Range("H5").Font.Size = 14;
            exsheet.get_Range("H5").Font.Bold = true;
            exsheet.get_Range("H5").Value = "Hạn sử dụng";

            exsheet.get_Range("I5").Font.Size = 14;
            exsheet.get_Range("I5").Font.Bold = true;
            exsheet.get_Range("I5").Value = "Chống chỉ định";

            exsheet.get_Range("J5").Font.Size = 14;
            exsheet.get_Range("J5").Font.Bold = true;
            exsheet.get_Range("J5").Value = "Nước sản xuất";

            exsheet.get_Range("K5").Font.Size = 14;
            exsheet.get_Range("K5").Font.Bold = true;
            exsheet.get_Range("K5").Value = "Dạng điều chế";

            exsheet.get_Range("L5").Font.Size = 14;
            exsheet.get_Range("L5").Font.Bold = true;
            exsheet.get_Range("L5").Value = "Đơn vị tính";

            //in dữ liệu
            for (int i = 0; i < dsThuoc.Rows.Count; i++)
            {
                exsheet.get_Range("A" + (i + 6).ToString()).Value = dsThuoc.Rows[i]["Mã Thuốc"].ToString();
                exsheet.get_Range("B" + (i + 6).ToString()).Value = dsThuoc.Rows[i]["Tên Thuốc"].ToString();
                exsheet.get_Range("C" + (i + 6).ToString()).Value = dsThuoc.Rows[i]["Thành Phần"].ToString();
                exsheet.get_Range("D" + (i + 6).ToString()).Value = dsThuoc.Rows[i]["Giá bán"].ToString();
                exsheet.get_Range("E" + (i + 6).ToString()).Value = dsThuoc.Rows[i]["Giá nhập"].ToString();
                exsheet.get_Range("F" + (i + 6).ToString()).Value = dsThuoc.Rows[i]["Số lượng"].ToString();
                exsheet.get_Range("G" + (i + 6).ToString()).Value = dsThuoc.Rows[i]["Ngày sản xuất"].ToString();
                exsheet.get_Range("H" + (i + 6).ToString()).Value = dsThuoc.Rows[i]["Hạn sử dụng"].ToString();
                exsheet.get_Range("I" + (i + 6).ToString()).Value = dsThuoc.Rows[i]["Chống chỉ định"].ToString();
                exsheet.get_Range("J" + (i + 6).ToString()).Value = dsThuoc.Rows[i]["Nước sản xuất"].ToString();
                exsheet.get_Range("K" + (i + 6).ToString()).Value = dsThuoc.Rows[i]["Dạng điều chế"].ToString();
                exsheet.get_Range("L" + (i + 6).ToString()).Value = dsThuoc.Rows[i]["Đơn vị tính"].ToString();
            }


            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "Excel Document(*.xlsx)|*.xlsx |Word Document(*.doc) | *.doc | All files(*.*) | *.* "; saveFile.FilterIndex = 1;
            saveFile.AddExtension = true;
            saveFile.DefaultExt = ".xls";
            saveFile.RestoreDirectory = true;
            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                exbook.SaveAs(saveFile.FileName.ToString());
                MessageBox.Show("Xuất file thành công");
                exapp.Quit();
            }
        }

        private void danhSáchNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string sql = "select a.MaNhanVien as N'Mã nhân viên',a.TenNV as N'Tên nhân viên',a.GioiTinh as N'Giới tính',a.DiaChi as N'Địa chỉ',a.DienThoai as N'Số điện thoại',b.TenTrinhDo as N'Trình độ',c.TenChuyenMon as N'Chuyên môn'\r\nfrom NhanVien a join TrinhDo b on a.MaTrinhDo=b.MaTrinhDo\r\n\t\tjoin ChuyenMon c on a.MaChuyenMon=c.MaChuyenMon";
            DataTable dsNhanVien = pd.ReadTable(sql);

            Excel.Application exapp = new Excel.Application();
            Excel.Workbook exbook = (Excel.Workbook)exapp.Workbooks.Add(Excel.XlWBATemplate.xlWBATWorksheet);
            Excel.Worksheet exsheet = (Excel.Worksheet)exapp.Worksheets[1];


            exsheet.get_Range("A2:G2").Merge(true);
            exsheet.get_Range("A2").Font.Size = 16;
            exsheet.get_Range("A2").Font.Color = Color.Red;
            exsheet.get_Range("A2").Font.Bold = true;
            exsheet.get_Range("A2").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            exsheet.get_Range("A2").Value = "Danh sách nhân viên";

            exsheet.Name = "Danh sách nhân viên";
            exbook.Activate();

            exsheet.get_Range("A5").Font.Size = 14;
            exsheet.get_Range("A5").Font.Bold = true;
            exsheet.get_Range("A5").Value = "Mã nhân viên";


            exsheet.get_Range("B5").Font.Size = 14;
            exsheet.get_Range("B5").Font.Bold = true;
            exsheet.get_Range("B5").Value = "Tên nhân viên";

            exsheet.get_Range("C5").Font.Size = 14;
            exsheet.get_Range("C5").Font.Bold = true;
            exsheet.get_Range("C5").Value = "Giới tính";

            exsheet.get_Range("D5").Font.Size = 14;
            exsheet.get_Range("D5").Font.Bold = true;
            exsheet.get_Range("D5").Value = "Địa chỉ";

            exsheet.get_Range("E5").Font.Size = 14;
            exsheet.get_Range("E5").Font.Bold = true;
            exsheet.get_Range("E5").Value = "Số điện thoại";

            exsheet.get_Range("F5").Font.Size = 14;
            exsheet.get_Range("F5").Font.Bold = true;
            exsheet.get_Range("F5").Value = "Trình độ";

            exsheet.get_Range("G5").Font.Size = 14;
            exsheet.get_Range("G5").Font.Bold = true;
            exsheet.get_Range("G5").Value = "Chuyên môn";

           
            //in dữ liệu
            for (int i = 0; i < dsNhanVien.Rows.Count; i++)
            {
                exsheet.get_Range("A" + (i + 6).ToString()).Value = dsNhanVien.Rows[i]["Mã nhân viên"].ToString();
                exsheet.get_Range("B" + (i + 6).ToString()).Value = dsNhanVien.Rows[i]["Tên nhân viên"].ToString();
                exsheet.get_Range("C" + (i + 6).ToString()).Value = dsNhanVien.Rows[i]["Giới tính"].ToString();
                exsheet.get_Range("D" + (i + 6).ToString()).Value = dsNhanVien.Rows[i]["Địa chỉ"].ToString();
                exsheet.get_Range("E" + (i + 6).ToString()).NumberFormat = "@";
                exsheet.get_Range("E" + (i + 6).ToString()).Value = dsNhanVien.Rows[i]["Số điện thoại"].ToString();
                exsheet.get_Range("F" + (i + 6).ToString()).Value = dsNhanVien.Rows[i]["Trình độ"].ToString();
                exsheet.get_Range("G" + (i + 6).ToString()).Value = dsNhanVien.Rows[i]["Chuyên môn"].ToString();
            }


            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "Excel Document(*.xlsx)|*.xlsx |Word Document(*.doc) | *.doc | All files(*.*) | *.* "; saveFile.FilterIndex = 1;
            saveFile.AddExtension = true;
            saveFile.DefaultExt = ".xls";
            saveFile.RestoreDirectory = true;
            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                exbook.SaveAs(saveFile.FileName.ToString());
                MessageBox.Show("Xuất file thành công");
                exapp.Quit();

            }
        }

        private void danhSáchKháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string sql = "select MaKhach as N'Mã khách', TenKhach as N'Tên khách' , DiaChi as N'Địa chỉ', DienThoai as N'Số điện thoại' from KhachHang";
            DataTable dsKhach = pd.ReadTable(sql);

            Excel.Application exapp = new Excel.Application();
            Excel.Workbook exbook = (Excel.Workbook)exapp.Workbooks.Add(Excel.XlWBATemplate.xlWBATWorksheet);
            Excel.Worksheet exsheet = (Excel.Worksheet)exapp.Worksheets[1];


            exsheet.get_Range("A2:D2").Merge(true);
            exsheet.get_Range("A2").Font.Size = 16;
            exsheet.get_Range("A2").Font.Color = Color.Red;
            exsheet.get_Range("A2").Font.Bold = true;
            exsheet.get_Range("A2").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            exsheet.get_Range("A2").Value = "Danh sách khách hàng";

            exsheet.Name = "Danh sách khách hàng";
            exbook.Activate();

            exsheet.get_Range("A5").Font.Size = 14;
            exsheet.get_Range("A5").Font.Bold = true;
            exsheet.get_Range("A5").Value = "Mã khách";


            exsheet.get_Range("B5").Font.Size = 14;
            exsheet.get_Range("B5").Font.Bold = true;
            exsheet.get_Range("B5").Value = "Tên khách";

            exsheet.get_Range("C5").Font.Size = 14;
            exsheet.get_Range("C5").Font.Bold = true;
            exsheet.get_Range("C5").Value = "Địa chỉ";

            exsheet.get_Range("D5").Font.Size = 14;
            exsheet.get_Range("D5").Font.Bold = true;
            exsheet.get_Range("D5").Value = "Số điện thoại";


            //in dữ liệu
            for (int i = 0; i < dsKhach.Rows.Count; i++)
            {
                exsheet.get_Range("A" + (i + 6).ToString()).Value = dsKhach.Rows[i]["Mã khách"].ToString();
                exsheet.get_Range("B" + (i + 6).ToString()).Value = dsKhach.Rows[i]["Tên khách"].ToString();
                exsheet.get_Range("C" + (i + 6).ToString()).Value = dsKhach.Rows[i]["Địa chỉ"].ToString();
                exsheet.get_Range("D" + (i + 6).ToString()).NumberFormat = "@";
                exsheet.get_Range("D" + (i + 6).ToString()).Value = dsKhach.Rows[i]["Số điện thoại"].ToString();
            }


            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "Excel Document(*.xlsx)|*.xlsx |Word Document(*.doc) | *.doc | All files(*.*) | *.* "; saveFile.FilterIndex = 1;
            saveFile.AddExtension = true;
            saveFile.DefaultExt = ".xls";
            saveFile.RestoreDirectory = true;
            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                exbook.SaveAs(saveFile.FileName.ToString());
                MessageBox.Show("Xuất file thành công");
                exapp.Quit();

            }
        }

        private void hóaĐơnNhậpToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string sql = "select MaHDN as N'Mã hóa đơn', NgayNhap as N'Ngày nhập', TongTien as N'Tổng tiền', MaNCC as N'Mã nhà cung cấp', MaNhanVien as N'Mã nhân viên'\r\nfrom hoadonnhap";
            DataTable dsHDB = pd.ReadTable(sql);

            Excel.Application exapp = new Excel.Application();
            Excel.Workbook exbook = (Excel.Workbook)exapp.Workbooks.Add(Excel.XlWBATemplate.xlWBATWorksheet);
            Excel.Worksheet exsheet = (Excel.Worksheet)exapp.Worksheets[1];


            exsheet.get_Range("A2:E2").Merge(true);
            exsheet.get_Range("A2").Font.Size = 16;
            exsheet.get_Range("A2").Font.Color = Color.Red;
            exsheet.get_Range("A2").Font.Bold = true;
            exsheet.get_Range("A2").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            exsheet.get_Range("A2").Value = "Danh sách hóa đơn nhập";

            exsheet.Name = "Danh sách hóa đơn nhập";
            exbook.Activate();

            exsheet.get_Range("A5").Font.Size = 14;
            exsheet.get_Range("A5").Font.Bold = true;
            exsheet.get_Range("A5").Value = "Mã hóa đơn";


            exsheet.get_Range("B5").Font.Size = 14;
            exsheet.get_Range("B5").Font.Bold = true;
            exsheet.get_Range("B5").Value = "Ngày nhập";

            exsheet.get_Range("C5").Font.Size = 14;
            exsheet.get_Range("C5").Font.Bold = true;
            exsheet.get_Range("C5").Value = "Tổng tiền";

            exsheet.get_Range("D5").Font.Size = 14;
            exsheet.get_Range("D5").Font.Bold = true;
            exsheet.get_Range("D5").Value = "Mã nhà cung cấp";

            exsheet.get_Range("E5").Font.Size = 14;
            exsheet.get_Range("E5").Font.Bold = true;
            exsheet.get_Range("E5").Value = "Mã nhân viên";


            //in dữ liệu
            for (int i = 0; i < dsHDB.Rows.Count; i++)
            {
                exsheet.get_Range("A" + (i + 6).ToString()).Value = dsHDB.Rows[i]["Mã hóa đơn"].ToString();
                exsheet.get_Range("B" + (i + 6).ToString()).Value = dsHDB.Rows[i]["Ngày nhập"].ToString();
                exsheet.get_Range("C" + (i + 6).ToString()).Value = dsHDB.Rows[i]["Tổng tiền"].ToString();
                exsheet.get_Range("D" + (i + 6).ToString()).Value = dsHDB.Rows[i]["Mã nhà cung cấp"].ToString();
                exsheet.get_Range("E" + (i + 6).ToString()).Value = dsHDB.Rows[i]["Mã nhân viên"].ToString();
            }


            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "Excel Document(*.xlsx)|*.xlsx |Word Document(*.doc) | *.doc | All files(*.*) | *.* ";
            saveFile.FilterIndex = 1;
            saveFile.AddExtension = true;
            saveFile.DefaultExt = ".xls";
            saveFile.RestoreDirectory = true;
            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                exbook.SaveAs(saveFile.FileName.ToString());
                MessageBox.Show("Xuất file thành công");
                exapp.Quit();
            }
        }

        private void hóaĐơnBánToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            string sql = "select MaHDB as N'Mã hóa đơn', NgayBan as N'Ngày bán', makhach as N'Mã khách' , maNhanvien as N'Mã nhân viên', TongTien as N'Tổng tiền'\r\nfrom  hoadonban";
            DataTable dsHDB = pd.ReadTable(sql);

            Excel.Application exapp = new Excel.Application();
            Excel.Workbook exbook = (Excel.Workbook)exapp.Workbooks.Add(Excel.XlWBATemplate.xlWBATWorksheet);
            Excel.Worksheet exsheet = (Excel.Worksheet)exapp.Worksheets[1];


            exsheet.get_Range("A2:E2").Merge(true);
            exsheet.get_Range("A2").Font.Size = 16;
            exsheet.get_Range("A2").Font.Color = Color.Red;
            exsheet.get_Range("A2").Font.Bold = true;
            exsheet.get_Range("A2").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            exsheet.get_Range("A2").Value = "Danh sách hóa đơn bán";

            exsheet.Name = "Danh sách hóa đơn bán";
            exbook.Activate();

            exsheet.get_Range("A5").Font.Size = 14;
            exsheet.get_Range("A5").Font.Bold = true;
            exsheet.get_Range("A5").Value = "Mã hóa đơn";


            exsheet.get_Range("B5").Font.Size = 14;
            exsheet.get_Range("B5").Font.Bold = true;
            exsheet.get_Range("B5").Value = "Ngày bán";

            exsheet.get_Range("C5").Font.Size = 14;
            exsheet.get_Range("C5").Font.Bold = true;
            exsheet.get_Range("C5").Value = "Mã khách";

            exsheet.get_Range("D5").Font.Size = 14;
            exsheet.get_Range("D5").Font.Bold = true;
            exsheet.get_Range("D5").Value = "Mã nhân viên";

            exsheet.get_Range("E5").Font.Size = 14;
            exsheet.get_Range("E5").Font.Bold = true;
            exsheet.get_Range("E5").Value = "Tổng tiền";


            //in dữ liệu
            for (int i = 0; i < dsHDB.Rows.Count; i++)
            {
                exsheet.get_Range("A" + (i + 6).ToString()).Value = dsHDB.Rows[i]["Mã hóa đơn"].ToString();
                exsheet.get_Range("B" + (i + 6).ToString()).Value = dsHDB.Rows[i]["Ngày bán"].ToString();
                exsheet.get_Range("C" + (i + 6).ToString()).Value = dsHDB.Rows[i]["Mã khách"].ToString();
                exsheet.get_Range("D" + (i + 6).ToString()).Value = dsHDB.Rows[i]["Mã nhân viên"].ToString();
                exsheet.get_Range("E" + (i + 6).ToString()).Value = dsHDB.Rows[i]["Tổng tiền"].ToString();
            }


            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "Excel Document(*.xlsx)|*.xlsx |Word Document(*.doc) | *.doc | All files(*.*) | *.* ";
            saveFile.FilterIndex = 1;
            saveFile.AddExtension = true;
            saveFile.DefaultExt = ".xlsx";
            saveFile.RestoreDirectory = true;
            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                exbook.SaveAs(saveFile.FileName.ToString());
                MessageBox.Show("Xuất file thành công");
                exapp.Quit();
            }
        }

        private void nhânViênToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormKhachHang form = new FormKhachHang();
            form.set_update();
            form.ShowDialog();
        }

        private void kháchHàngToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormThemNV form = new FormThemNV();
            form.ShowDialog();
        }
    }
}