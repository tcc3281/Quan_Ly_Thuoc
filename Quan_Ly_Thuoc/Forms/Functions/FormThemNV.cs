using Quan_Ly_Thuoc.Data;
using System;
using System.Data;
using System.Windows.Forms;

namespace Quan_Ly_Thuoc.Forms.Functions
{
	public partial class FormThemNV : Form
	{
		ProcessDatabase pd = new ProcessDatabase();
		public FormThemNV()
		{
			InitializeComponent();
		}
		private string IDNV()
		{
			pd.CreateCMD();
			pd.cmd.CommandText = "Select top(1) MaNhanVien from NhanVien order by MaNhanVien";
			pd.Connect();
			string s = (string)pd.cmd.ExecuteScalar();
			int cnt = int.Parse(s.Substring(2)) + 1;
			pd.Disconnect();

			String result = "NV";
			for (int i = 0; i < 3 - cnt.ToString().Length; i++)
			{
				result += "0";
			}
			result += (cnt.ToString());
			return result;
		}
		private void Loadcmb()
		{
			DataTable dtTrinhDo = pd.ReadTable("Select * from TrinhDo");
			DataTable dtChuyenMon = pd.ReadTable("Select * from ChuyenMon");

			for (int i = 0; i < dtTrinhDo.Rows.Count; i++)
				this.cmbTrinhDo.Items.Add(dtTrinhDo.Rows[i]["TenTrinhDo"]);

			for (int i = 0; i < dtChuyenMon.Rows.Count; i++)
				this.cmbChuyenMon.Items.Add(dtChuyenMon.Rows[i]["TenChuyenMon"]);

			cmbGioiTinh.Items.Add("Nam");
			cmbGioiTinh.Items.Add("Nữ");
		}
		private void FromThemNV_Load(object sender, EventArgs e)
		{
			Loadcmb();
			dgvNhanVien.DataSource = pd.ReadTable("select * from NhanVien");
		}
		private bool Validate()
		{
			if (txtTenNV.Text.Trim() == "" || txtSDT.Text.Trim() == "" ||
				cmbTrinhDo.Text == "" || cmbChuyenMon.Text == "")
			{
				MessageBox.Show("Cần nhập tên, số điện thoại, trình độ và chuyên môn của nhân viên.", "Thông báo");
				return false;
			}

			if (txtDOB.Value.AddYears(18)>=DateTime.Now)
			{
				MessageBox.Show("Nhân viên phải đủ 18 tuổi");
				return false;
			}
			return true;
		}
		private void btnThem_Click(object sender, EventArgs e)
		{
			if (Validate() == true)
			{
				//Them chuyen mon
				pd.CreateCMD();
				pd.cmd.CommandText = "Select count(*) from ChuyenMon where TenChuyenMon = N'" + cmbChuyenMon.Text + "'";
				pd.Connect();
				int valCM = (int)pd.cmd.ExecuteScalar();
				pd.Disconnect();
				if (valCM == 0)
				{
					pd.cmd.CommandText = "Select count(*) from ChuyenMon";
					pd.Connect();
					int cnt = (int)pd.cmd.ExecuteScalar() + 1;
					pd.Disconnect();
					String result = "CM";
					for (int i = 0; i < 3 - cnt.ToString().Length; i++)
					{
						result += "0";
					}
					result += (cnt.ToString());
					pd.RunSQL("insert into ChuyenMon(MaChuyenMon, TenChuyenMon) values('" +
						result + "', N'" + cmbChuyenMon.Text + "')");
					//MessageBox.Show("insert into ChuyenMon(MaChuyenMon, TenChuyenMon) values('" +
					//	result + "', N'" + cmbChuyenMon.Text + "')");
				}

				//Them trinh do
				pd.cmd.CommandText = "Select count(*) from TrinhDo where TenTrinhDo = N'" + cmbTrinhDo.Text + "'";
				pd.Connect();
				int valTD = (int)pd.cmd.ExecuteScalar();
				pd.Disconnect();
				if (valTD == 0)
				{
					pd.cmd.CommandText = "Select count(*) from TrinhDo";
					pd.Connect();
					int cnt = (int)pd.cmd.ExecuteScalar() + 1;
					pd.Disconnect();
					String result = "TD";
					for (int i = 0; i < 3 - cnt.ToString().Length; i++)
					{
						result += "0";
					}
					result += (cnt.ToString());
					pd.RunSQL("insert into TrinhDo(MatrinhDo, TenTrinhDo) values('" +
						result + "', N'" + cmbTrinhDo.Text + "')");
					//MessageBox.Show("insert into TrinhDo(MatrinhDo, TenTrinhDo) values('" +
					//	result + "', N'" + cmbTrinhDo.Text + "')");
				}

				pd.cmd.CommandText = "Select MaTrinhDo from TrinhDo where TenTrinhDo = N'" + cmbTrinhDo.Text + "'";
				pd.Connect();
				string takeIdTD = (string)pd.cmd.ExecuteScalar();
				pd.Disconnect();

				pd.cmd.CommandText = "Select MaChuyenMon from ChuyenMon where TenChuyenMon = N'" + cmbChuyenMon.Text + "'";
				pd.Connect();
				string takeIdCM = (string)pd.cmd.ExecuteScalar();
				pd.Disconnect();
				//Them NhanVien
				String sql = "insert into NhanVien(MaNhanVien, TenNV, NgaySinh, GioiTinh, " +
								"DiaChi, DienThoai, MaChuyenMon, MaTrinhDo) values('" + IDNV() + "', N'" + txtTenNV.Text + "', N'" +
								txtDOB.Text + "', N'" + cmbGioiTinh.Text + "', N'" + txtDiaChi.Text + "', N'" +
								txtSDT.Text + "', N'" + takeIdCM + "', N'" + takeIdTD + "')";
				//MessageBox.Show(sql);
				pd.RunSQL(sql);
				dgvNhanVien.DataSource = pd.ReadTable("select * from NhanVien");
			}
		}
	}
}
