using Quan_Ly_Thuoc.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace Quan_Ly_Thuoc.Forms.Function
{
	public partial class FormNhapThuoc : Form
	{
		ProcessDatabase pd = new ProcessDatabase();
		DataTable dtUnit;
		DataTable dtCountry;
		DataTable dtFormMedicine;
		DataTable dtCongdung;
		List<string> listCongdungSelected = new List<string>();
		public FormNhapThuoc()
		{
			InitializeComponent();
            Loadcmb();
            IDThuoc();
        }
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
			dtUnit = pd.ReadTable("Select * from DonViTinh");
			dtCountry = pd.ReadTable("Select * from NuocSX");
			dtFormMedicine = pd.ReadTable("Select * from DangDieuChe");
			dtCongdung = pd.ReadTable("select * from CongDung");

			for (int i = 0; i < dtUnit.Rows.Count; i++)
			{
                this.cmbUnit.Items.Add(dtUnit.Rows[i]["TenDonViTinh"]);
            }

            for (int i = 0; i < dtCountry.Rows.Count; i++)
			{
                this.cmbCountry.Items.Add(dtCountry.Rows[i]["TenNSX"]);

            }

            for (int i = 0; i < dtFormMedicine.Rows.Count; i++)
			{
                this.cmbFormMedicine.Items.Add(dtFormMedicine.Rows[i]["TenDangDieuChe"]);
            }
			for(int i=0;i<dtCongdung.Rows.Count;i++)
			{
				this.cmbFunction.Items.Add(dtCongdung.Rows[i]["TenCongDung"]);
			}
        }
		private void FormNhapThuoc_Load(object sender, EventArgs e)
		{
			Loadcmb();
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
		public void setAdd()
		{
			btnUpdate.Enabled = false;
		}
        public void setUpdate()
        {
            btnAdd.Enabled = false;
			txtMedicineCode.ReadOnly=false;
        }
        private void btnAddFunction_Click(object sender, EventArgs e)
        {
			if (listCongdungSelected.Contains(dtCongdung.Rows[cmbFunction.SelectedIndex]["MaCongDung"].ToString()))
			{
				MessageBox.Show("Bạn đã thêm công dụng này!");
				return;
			}
			listBoxFunction.Items.Add(cmbFunction.SelectedItem.ToString());
			listCongdungSelected.Add(dtCongdung.Rows[cmbFunction.SelectedIndex]["MaCongDung"].ToString());
        }
        private void btnRemove_Click(object sender, EventArgs e)
        {
            int select = listBoxFunction.SelectedIndex;
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
			string sql = "update DanhMucThuoc\r\nset TenThuoc=N'" + txtMedicineName.Text
				+ "',\r\n\tThanhPhan=N'" + txtIngredient.Text
				+ "',\r\n\tChongChiDinh=N'" + txtNotRecommended.Text
				+ "',\r\n\tMaDangDieuChe='" + dtFormMedicine.Rows[cmbFormMedicine.SelectedIndex]["MaDangDieuChe"].ToString()
				+ "',\r\n\tMaDV='" + dtUnit.Rows[cmbUnit.SelectedIndex]["MaDV"]
				+ "',\r\n\tMaNSX='" + dtCountry.Rows[cmbCountry.SelectedIndex]["MaNSX"] 
				+"',\r\n\tNgaySX='"+txtDNSX.Text+"',\r\n\tHanSD='"+txtHSD.Text+"'"+
				"where MaThuoc='"+ txtMedicineCode.Text + "'";
			try
			{
                pd.RunSQL(sql);
                pd.RunSQL("delete from Thuoc_CongDung where MaThuoc='" + txtMedicineCode.Text + "'");
                insertCongDung();
				MessageBox.Show("Đã cập nhật thành công!");
			}
			catch
			{
				MessageBox.Show("Lỗi!");
			}
			Close();
        }
		public void show_medicine(string name)
		{
            DataTable table = pd.ReadTable("select a.MaThuoc,a.TenThuoc,a.ThanhPhan,a.NgaySX,a.HanSD,a.ChongChiDinh,d.TenNSX,b.TenDangDieuChe,c.TenDonViTinh,f.MaCongDung,f.TenCongDung\r\nfrom DanhMucThuoc a join DangDieuChe b on a.MaDangDieuChe=b.MaDangDieuChe\r\n\t\tjoin DonViTinh c on a.MaDV=c.MaDV\r\n\t\tjoin NuocSX d on a.MaNSX=d.MaNSX\r\n\t\tjoin Thuoc_CongDung e on a.MaThuoc=e.MaThuoc\r\n\t\tjoin CongDung f on e.MaCongDung=f.MaCongDung\r\nwhere a.TenThuoc = '"+name+"'\r\n");
			txtMedicineCode.Text = table.Rows[0]["MaThuoc"].ToString();
			txtMedicineName.Text = table.Rows[0]["TenThuoc"].ToString();
            txtIngredient.Text = table.Rows[0]["ThanhPhan"].ToString();
            txtNotRecommended.Text = table.Rows[0]["ChongChiDinh"].ToString();
			txtDNSX.Text = table.Rows[0]["NgaySX"].ToString();
			txtHSD.Text = table.Rows[0]["HanSD"].ToString();
			for(int i=0;i<dtFormMedicine.Rows.Count;i++)
			{
				if (dtFormMedicine.Rows[i]["TenDangDieuChe"].ToString() == table.Rows[0]["TenDangDieuChe"].ToString())
				{
					cmbFormMedicine.SelectedIndex = i;
					break;
				}
			}
            for (int i = 0; i < dtCountry.Rows.Count; i++)
            {
                if (dtCountry.Rows[i]["TenNSX"].ToString() == table.Rows[0]["TenNSX"].ToString())
                {
                    cmbCountry.SelectedIndex = i;
                    break;
                }
            }
            for (int i = 0; i < dtUnit.Rows.Count; i++)
            {
                if (dtUnit.Rows[i]["TenDonViTinh"].ToString() == table.Rows[0]["TenDonViTinh"].ToString())
                {
                    cmbUnit.SelectedIndex = i;
                    break;
                }
            }
			//add cong dung
			for(int i=0;i<table.Rows.Count;i++)
			{
				listBoxFunction.Items.Add(table.Rows[i]["TenCongDung"]);
				listCongdungSelected.Add(table.Rows[i]["MaCongDung"].ToString());
			}
        }
		public void setView()
		{
			btnAdd.Enabled=false;
			btnRemoveFunction.Enabled=false;
			btnClear.Enabled=false;
			btnAddFunction.Enabled=false;
			btnUpdate.Enabled=false;
		}
        private void txtMedicineCode_Leave(object sender, EventArgs e)
        {
            listBoxFunction.Items.Clear();
			try
			{
                string name = pd.ReadTable("select TenThuoc from DanhMucThuoc where MaThuoc='" + txtMedicineCode.Text + "'").Rows[0]["TenThuoc"].ToString();
				show_medicine(name);
            }
            catch (System.IndexOutOfRangeException)
			{
				MessageBox.Show("Mã thuốc không hợp lệ!");
				txtMedicineCode.Focus();
			}
			
        }
    }
}
