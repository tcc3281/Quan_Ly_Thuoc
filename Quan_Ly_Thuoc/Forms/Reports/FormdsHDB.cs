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
	public partial class FormdsHDB : Form
	{
		ProcessDatabase pd = new ProcessDatabase();
		public FormdsHDB()
		{
			InitializeComponent();
		}

		private void FormdsHDB_Load(object sender, EventArgs e)
		{
			rpvHDB.LocalReport.ReportEmbeddedResource = "Quan_Ly_Thuoc.Reports.ReportHDB.rdlc";
			ReportDataSource rpd = new ReportDataSource();
			rpd.Name = "dsHDB";
			rpd.Value = pd.ReadTable("select top 5 * from HoaDonBan where TrangThai = 1 order by TongTien asc");
			rpvHDB.LocalReport.DataSources.Clear();
			rpvHDB.LocalReport.DataSources.Add(rpd);
			this.rpvHDB.RefreshReport();
		}

		private void btnTim_Click(object sender, EventArgs e)
		{
			ReportDataSource rpd = new ReportDataSource();
			rpd.Name = "dsHDB";
			rpd.Value = pd.ReadTable("select top 5 * from HoaDonBan where TrangThai = 1 and year(NgayBan) = " + txtSearch.Value + " order by TongTien asc");
			rpvHDB.LocalReport.DataSources.Clear();
			rpvHDB.LocalReport.DataSources.Add(rpd);
			this.rpvHDB.RefreshReport();
		}
	}
}
