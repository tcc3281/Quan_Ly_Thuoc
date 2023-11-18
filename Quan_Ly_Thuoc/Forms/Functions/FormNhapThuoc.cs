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
		List<string> listMDC= new List<string>();
		List<string> listMNSX= new List<string>();
		List<string> listMDV= new List<string>();
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
			{
                this.cmbUnit.Items.Add(dtUnit.Rows[i]["TenDonViTinh"]);
				listMDV.Add(dtUnit.Rows[i]["MaDV"].ToString());
            }

            for (int i = 0; i < dtCountry.Rows.Count; i++)
			{
                this.cmbCountry.Items.Add(dtCountry.Rows[i]["TenNSX"]);
				listMNSX.Add(dtCountry.Rows[i]["MaNSX"].ToString());

            }

            for (int i = 0; i < dtFormMedicine.Rows.Count; i++)
			{
                this.cmbFormMedicine.Items.Add(dtFormMedicine.Rows[i]["TenDangDieuChe"]);
				listMDC.Add(dtFormMedicine.Rows[i]["MaDangDieuChe"].ToString());
            }
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
				//Them Dang dieu che
				pd.CreateCMD();
				pd.cmd.CommandText = "Select count(*) from DangDieuChe where TenDangDieuChe = N'" + cmbFormMedicine.Text + "'";
				pd.Connect();
				int valDDC = (int)pd.cmd.ExecuteScalar();
				pd.Disconnect();
				if (valDDC == 0)
				{
					pd.cmd.CommandText = "Select count(*) from DangDieuChe";
					pd.Connect();
					int cnt = (int)pd.cmd.ExecuteScalar() + 1;
					pd.Disconnect();
					String result = "DDC";
					for (int i = 0; i < 3 - cnt.ToString().Length; i++)
					{
						result += "0";
					}
					result += (cnt.ToString());
					pd.RunSQL("insert into DangDieuChe(MaDangDieuChe, TenDangDieuChe) values('" +
						result + "', N'" + cmbFormMedicine.Text + "')");
				}
				//Them don vi tinh
				pd.CreateCMD();
				pd.cmd.CommandText = "Select count(*) from DonViTinh where TenDonViTinh = N'" + cmbUnit.Text + "'";
				pd.Connect();
				int valDV = (int)pd.cmd.ExecuteScalar();
				pd.Disconnect();
				if (valDV == 0)
				{
					pd.cmd.CommandText = "Select count(*) from DonViTinh";
					pd.Connect();
					int cnt = (int)pd.cmd.ExecuteScalar() + 1;
					pd.Disconnect();
					String result = "DV";
					for (int i = 0; i < 3 - cnt.ToString().Length; i++)
					{
						result += "0";
					}
					result += (cnt.ToString());
					pd.RunSQL("insert into DonViTinh(MaDV, TenDonViTinh) values('" +
						result + "', N'" + cmbUnit.Text + "')");
				}
				//Them nuoc san xuat
				pd.CreateCMD();
				pd.cmd.CommandText = "Select count(*) from NuocSX where TenNSX = N'" + cmbCountry.Text + "'";
				pd.Connect();
				int valNSX = (int)pd.cmd.ExecuteScalar();
				pd.Disconnect();
				if (valNSX == 0)
				{
					pd.cmd.CommandText = "Select count(*) from NuocSX";
					pd.Connect();
					int cnt = (int)pd.cmd.ExecuteScalar() + 1;
					pd.Disconnect();
					String result = "NC";
					for (int i = 0; i < 3 - cnt.ToString().Length; i++)
					{
						result += "0";
					}
					result += (cnt.ToString());
					pd.RunSQL("insert into NuocSX(MaNSX, TenNSX) values('" +
						result + "', N'" + cmbCountry.Text + "')");
				}

				String sql = "insert into DanhMucThuoc(MaThuoc, TenThuoc, ThanhPhan, ChongChiDinh, " +
						"MaDangDieuChe, MaDV, MaNSX) values('" + idThuoc + "', N'" + txtMedicineName.Text + "', N'" +
						txtIngredient.Text + "', N'" + txtNotRecommended.Text + "'," +
						"(select MaDangDieuChe from DangDieuChe where TenDangDieuChe = N'" + cmbFormMedicine.Text + "'), " +
						"(select MaDV from DonViTinh where TenDonViTinh = N'" + cmbUnit.Text + "'), " +
						"(select MaNSX from NuocSX where TenNSX = N'" + cmbCountry.Text + "'))";
				//MessageBox.Show(sql);
				pd.RunSQL(sql);
				this.Close();
			}
			else
			{
				MessageBox.Show("Thông báo!", "Cần điền đầy đủ.");
			}
		}

        private void cmbFormMedicine_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
		public void setAdd()
		{
			btnUpdate.Enabled = false;
		}
        public void setUpdate()
        {
            btnAdd.Enabled = false;
        }
    }
}
