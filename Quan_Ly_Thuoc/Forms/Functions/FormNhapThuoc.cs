using Quan_Ly_Thuoc.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quan_Ly_Thuoc.Forms.Function
{
	public partial class FormNhapThuoc : Form
	{
		ProcessDatabase pd = new ProcessDatabase();
		public FormNhapThuoc()
		{
			InitializeComponent();
		}
		//reset lại dữ liệu đã nhập trong form
		private void buttonClear_Click(object sender, EventArgs e)
		{
			clear();
		}

		private void clear()
		{
			txtMedicineName.Text = string.Empty;
			cmbFormMedicine.Text = string.Empty;
			txtNotRecommended.Text = string.Empty;
			txtIngredient.Text = string.Empty;
			cmbCountry.Text = string.Empty;
			cmbUnit.Text = string.Empty;

		}

		private void Loadcmb()
		{
			DataTable dtUnit = pd.ReadTable("Select * from DonViTinh");
			DataTable dtCountry = pd.ReadTable("Select * from NuocSX");
			DataTable dtFormMedicine = pd.ReadTable("Select * from DangDieuChe");

			for (int i = 0; i < dtUnit.Rows.Count; i++)
				this.cmbUnit.Items.Add(dtUnit.Rows[i]["TenDonViTinh"]);

			for (int i = 0; i < dtCountry.Rows.Count; i++)
				this.cmbCountry.Items.Add(dtCountry.Rows[i]["TenNSX"]);

			for (int i = 0; i < dtFormMedicine.Rows.Count; i++)
				this.cmbFormMedicine.Items.Add(dtFormMedicine.Rows[i]["TenDangDieuChe"]);
		}

		private void FormNhapThuoc_Load(object sender, EventArgs e)
		{
			Loadcmb();
		}

		private String IDThuoc()
		{
			pd.CreateCMD();
			pd.cmd.CommandText = "Select count(MaThuoc) from DanhMucThuoc";
			pd.Connect();
			int cnt = (int)pd.cmd.ExecuteScalar() + 1;
			pd.Disconnect();

			String result = "T";
			for (int i = 0; i < 3 - cnt.ToString().Length; i++)
			{
				result += "0";
			}
			result += (cnt.ToString());
			return result;
		}
		private bool Validate()
		{
			if (txtMedicineName.Text.Trim() == "" || txtNotRecommended.Text.Trim() == "" ||
				txtIngredient.Text.Trim() == "" || cmbUnit.Text == "" ||
				cmbCountry.Text == "" || cmbFormMedicine.Text == "")
			{
				return false;
			}

			return true;
		}


		private void buttonAdd_Click(object sender, EventArgs e)
		{
			String idThuoc = IDThuoc();
			if (Validate())
			{
				String sql = "insert into DanhMucThuoc(MaThuoc, TenThuoc, ThanhPhan, MaDangDieuChe, " +
						"ChongChiDinh, MaDV, MaNSX) values('" + idThuoc + "', N'" + txtMedicineName.Text + "', N'" +
						txtIngredient.Text + "', N'" + cmbFormMedicine.Text + "', N'" + txtNotRecommended.Text + "', N'" +
						cmbUnit.Text + "', N'" + cmbCountry.Text + "')";
				//MessageBox.Show(sql);
				pd.RunSQL(sql);
				this.Close();

			}
			else
			{
				MessageBox.Show("Thông báo!", "Cần điền đầy đủ.");
			}
		}
	}
}
