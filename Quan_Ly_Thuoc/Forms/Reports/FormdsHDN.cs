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
	public partial class FormdsHDN : Form
	{
		ProcessDatabase pd = new ProcessDatabase();
		public FormdsHDN()
		{
			InitializeComponent();
		}

		private void FormdsHDN_Load(object sender, EventArgs e)
		{
			rpvHDN.LocalReport.ReportEmbeddedResource = "Quan_Ly_Thuoc.Reports.ReportHDN.rdlc";
			ReportDataSource rpd = new ReportDataSource();
			rpd.Name = "dsHDN";
			rpd.Value = pd.ReadTable("select * from HoaDonNhap");
			rpvHDN.LocalReport.DataSources.Clear();
			rpvHDN.LocalReport.DataSources.Add(rpd);
			this.rpvHDN.RefreshReport();
        }

		private void btnTim_Click(object sender, EventArgs e)
		{
			ReportDataSource rpd = new ReportDataSource();
			rpd.Name = "dsHDN";
			rpd.Value = pd.ReadTable("select * from HoaDonNhap where MONTH(NgayNhap) = " + txtSearch.Value);
			rpvHDN.LocalReport.DataSources.Clear();
			rpvHDN.LocalReport.DataSources.Add(rpd);
			this.rpvHDN.RefreshReport();
		}
	}
}
