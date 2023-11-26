using Microsoft.Reporting.WinForms;
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

namespace Quan_Ly_Thuoc.Forms.Reports
{
	public partial class FormdsNV : Form
	{
		ProcessDatabase pd  = new ProcessDatabase();
		public FormdsNV()
		{
			InitializeComponent();
		}

		private void FormdsNV_Load(object sender, EventArgs e)
		{
			rpvNV.LocalReport.ReportEmbeddedResource = "Quan_Ly_Thuoc.Reports.ReportNV.rdlc";
			ReportDataSource rpd = new ReportDataSource();
			rpd.Name = "dsNV";
			rpd.Value = pd.ReadTable("select top 2 a.MaNhanVien, TenNV, sum(TongTien) as Tien from NhanVien a inner join HoaDonBan b on a.MaNhanVien = b.MaNhanVien where TrangThai = 1 group by a.MaNhanVien, TenNV order by Tien asc");
			rpvNV.LocalReport.DataSources.Clear();
			rpvNV.LocalReport.DataSources.Add(rpd);
			this.rpvNV.RefreshReport();
		}

		private void btnTim_Click(object sender, EventArgs e)
		{
			ReportDataSource rpd = new ReportDataSource();
			rpd.Name = "dsNV";
			rpd.Value = pd.ReadTable("select top 2 a.MaNhanVien, TenNV, sum(TongTien) as Tien " +
				"from NhanVien a inner join HoaDonBan b on a.MaNhanVien = b.MaNhanVien " +
				"where TrangThai = 1 and DATEPART(QUARTER, month(NgayBan)) = " + txtSearch.Value +
				"group by a.MaNhanVien, TenNV order by Tien asc");
			rpvNV.LocalReport.DataSources.Clear();
			rpvNV.LocalReport.DataSources.Add(rpd);
			this.rpvNV.RefreshReport();
		}
	}
}
