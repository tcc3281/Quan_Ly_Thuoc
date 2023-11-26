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

namespace Quan_Ly_Thuoc.Forms.Functions
{
	public partial class FormThuocConHSD : Form
	{
		ProcessDatabase pd = new ProcessDatabase();
		bool btnCK = false;
		public FormThuocConHSD()
		{
			InitializeComponent();
		}

		private void FormThuocConHSD_Load(object sender, EventArgs e)
		{
			rpvThuocConHSD.LocalReport.ReportEmbeddedResource = "Quan_Ly_Thuoc.Reports.ReportThuocConHSD.rdlc";
			ReportDataSource rpd = new ReportDataSource();
			rpd.Name = "ThuocConHSD";
			rpd.Value = pd.ReadTable("select * from DanhMucThuoc where GETDATE() <= HanSD");
			rpvThuocConHSD.LocalReport.DataSources.Clear();
			rpvThuocConHSD.LocalReport.DataSources.Add(rpd);

            this.rpvThuocConHSD.RefreshReport();
			button1.Text = "Thuốc còn hạn sử dụng";
        }

		private void button1_Click(object sender, EventArgs e)
		{
			ReportDataSource rpd = new ReportDataSource();
			rpd.Name = "ThuocConHSD";
			if (btnCK == false)
			{
				rpd.Value = pd.ReadTable("select * from DanhMucThuoc where GETDATE() >= HanSD");
				btnCK = true;
				button1.Text = "Thuốc hết hạn sử dụng";
			}
			else
			{
				rpd.Value = pd.ReadTable("select * from DanhMucThuoc where GETDATE() <= HanSD");
				btnCK = false;
				button1.Text = "Thuốc còn hạn sử dụng";
			}
			rpvThuocConHSD.LocalReport.DataSources.Clear();
			rpvThuocConHSD.LocalReport.DataSources.Add(rpd);

			this.rpvThuocConHSD.RefreshReport();
		}
	}
}
