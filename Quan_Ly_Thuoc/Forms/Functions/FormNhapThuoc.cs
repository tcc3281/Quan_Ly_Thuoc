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
		List<string> listCongdungShow = new List<string>();
		List<string> listCongdungSelected = new List<string>();
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
			cmbFunction.Text=string.Empty;
		}

		private void Loadcmb()
		{
			DataTable dtUnit = pd.ReadTable("Select * from DonViTinh");
			DataTable dtCountry = pd.ReadTable("Select * from NuocSX");
			DataTable dtFormMedicine = pd.ReadTable("Select * from DangDieuChe");
			DataTable dtCongdung = pd.ReadTable("select * from CongDung");

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
			for(int i=0;i<dtCongdung.Rows.Count;i++)
			{
				this.cmbFunction.Items.Add(dtCongdung.Rows[i]["TenCongDung"]);
				listCongdungShow.Add(dtCongdung.Rows[i]["MaCongDung"].ToString());
			}
        }

		private void FormNhapThuoc_Load(object sender, EventArgs e)
		{
			Loadcmb();
			IDThuoc();
		}

		private string IDThuoc()
		{
			pd.CreateCMD();
			pd.cmd.CommandText = "Select top(1) Mathuoc from DanhMucThuoc order by Mathuoc desc";
			pd.Connect();
			string s=(string)pd.cmd.ExecuteScalar();
			int cnt = int.Parse(s.Substring(1))+1;
			pd.Disconnect();

			string result = "T";
			for (int i = 0; i < 3 - cnt.ToString().Length; i++)
			{
				result += "0";
			}
			result += (cnt.ToString());
			txtMedicineCode.Text = result.ToString();
			return result;
		}
		private bool Validate()
		{
			if (txtMedicineName.Text.Trim() == "" || txtNotRecommended.Text.Trim() == "" ||
				txtIngredient.Text.Trim() == "" || cmbUnit.Text == "" ||
				cmbCountry.Text == "" || cmbFormMedicine.Text == "")
			{
                MessageBox.Show("Cần điền đầy đủ.","Thông báo!");
                return false;
			}
			if (txtHSD.Value < txtDNSX.Value)
			{
				MessageBox.Show("Hạn sử dụng không được trước ngày sản xuất");
				return false;
			}
			if(listBoxFunction.Items.Count == 0) 
			{
				MessageBox.Show("Hãy chọn các công dụng");
				return false;
			}

			return true;
		}

		private void insertCongDung()
		{
			string sql = "insert Thuoc_CongDung (MaThuoc,MaCongDung) values ";

            foreach ( var item in listCongdungSelected)
			{
				string s = "('"+txtMedicineCode.Text+"','";
				s += item + "'),";
				sql+= s;
			}
			sql=sql.Remove(sql.Length - 1, 1);
			txtIngredient.Text = sql;
			pd.RunSQL(sql);
		}
		private void buttonAdd_Click(object sender, EventArgs e)
		{
			string idThuoc = txtMedicineCode.Text;
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

				string sql = "insert into DanhMucThuoc(MaThuoc, TenThuoc, ThanhPhan, ChongChiDinh, " +
						"MaDangDieuChe, MaDV, MaNSX,NgaySX,HanSD) values('" + idThuoc + "', N'" + txtMedicineName.Text + "', N'" +
						txtIngredient.Text + "', N'" + txtNotRecommended.Text + "'," +
						"(select MaDangDieuChe from DangDieuChe where TenDangDieuChe = N'" + cmbFormMedicine.Text + "'), " +
						"(select MaDV from DonViTinh where TenDonViTinh = N'" + cmbUnit.Text + "'), " +
						"(select MaNSX from NuocSX where TenNSX = N'" + cmbCountry.Text + "'),'"+
						 txtDNSX.Text+"','"+txtHSD.Text+"')";
				//MessageBox.Show(sql);
				pd.RunSQL(sql);
				insertCongDung();
				this.Close();
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
			txtMedicineCode.ReadOnly = false;
        }

        private void btnAddFunction_Click(object sender, EventArgs e)
        {
			if (listCongdungSelected.Contains(listCongdungShow[cmbFunction.SelectedIndex]))
			{
				MessageBox.Show("Bạn đã thêm chức năng này!");
				return;
			}
			listBoxFunction.Items.Add(cmbFunction.SelectedItem.ToString());
			listCongdungSelected.Add(listCongdungShow[cmbFunction.SelectedIndex].ToString());
        }

        private void button1_Click(object sender, EventArgs e)
        {
			int select=listBoxFunction.SelectedIndex;
			MessageBox.Show(select.ToString());
			if (select < 0)
			{
				MessageBox.Show("Hãy chọn công dụng muốn xóa");
			}
			else
			{
				listBoxFunction.Items.RemoveAt(select);
				listCongdungSelected.RemoveAt(select);
			}
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

        }

        private void txtMedicineCode_Leave(object sender, EventArgs e)
        {
			string code = txtMedicineCode.Text;
			DataTable table = pd.ReadTable("select * from danhmucthuoc where MaThuoc='" + code+"'");
			txtMedicineName.Text = table.Rows[0]["TenThuoc"].ToString();
			txtIngredient.Text = table.Rows[0]["ThanhPhan"].ToString();
			txtNotRecommended.Text = table.Rows[0]["ChongChiDinh"].ToString();
        }
    }
}
