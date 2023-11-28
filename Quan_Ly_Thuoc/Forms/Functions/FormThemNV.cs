using Quan_Ly_Thuoc.Data;
using System;
using System.Data;
using System.Windows.Forms;

namespace Quan_Ly_Thuoc.Forms.Functions
{
	public partial class FormThemNV : Form
	{
		ProcessDatabase pd = new ProcessDatabase();
		DataTable dtTrinhDo;
		DataTable dtChuyenMon;
		string mnv;
        public FormThemNV()
		{
			InitializeComponent();
		}
		private string IDNV()
		{
			pd.CreateCMD();
			pd.cmd.CommandText = "Select top(1) MaNhanVien from NhanVien order by MaNhanVien desc";
			pd.Connect();
			string s;
			int cnt = 1;
            string result = "NV";
			try
			{
				s = (string)pd.cmd.ExecuteScalar();
				cnt = int.Parse(s.Substring(2)) + 1;
			}
			catch (System.NullReferenceException)
			{
				cnt = 1;
			}
			finally
			{ 
				pd.Disconnect();
                for (int i = 0; i < 3 - cnt.ToString().Length; i++)
                {
                    result += "0";
                }
                result += (cnt.ToString());
            }
			return result;
		}
		private void Loadcmb()
		{
			dtTrinhDo = pd.ReadTable("Select * from TrinhDo");
			dtChuyenMon = pd.ReadTable("Select * from ChuyenMon");

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
			show_dvg();
		}
		private void show_dvg()
		{
            dgvNhanVien.DataSource = pd.ReadTable("select a.MaNhanVien as N'Mã nhân viên', a.TenNV as N'Tên nhân viên', a.NgaySinh as N'Ngày sinh' ,a.DiaChi as N'Địa chỉ', \r\na.DienThoai as N'Số điện thoại',\r\na.GioiTinh as N'Giới tính',b.TenTrinhDo as N'Trình độ',c.TenChuyenMon as N'Chuyên môn'\r\nfrom NhanVien a join Trinhdo b on a.MaTrinhdo= b.matrinhdo\r\n\t\t\tjoin ChuyenMon c on a.MaChuyenMon=c.MaChuyenMon");
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
				show_dvg();
			}
		}

        private void btnSua_Click(object sender, EventArgs e)
        {
			if (Validate())
			{
				string sql = "Update Nhanvien " +
					"set TenNV=N'" + txtTenNV.Text + "'," +
					"NgaySinh=N'" + txtDOB.Text + "'," +
					"Diachi=N'"+txtDiaChi.Text+"'," +
					"GioiTinh=N'"+cmbGioiTinh.Text+"'," +
					"DienThoai=N'"+txtSDT.Text+"'," +
					"MaChuyenMon=N'" + dtChuyenMon.Rows[cmbChuyenMon.SelectedIndex]["Machuyenmon"].ToString() + "'," +
					"MaTrinhdo=N'"+ dtTrinhDo.Rows[cmbTrinhDo.SelectedIndex]["MaTrinhDo"].ToString() + "' " +
					"where Manhanvien=N'" + mnv + "'";

				pd.CreateCMD();
				pd.RunSQL(sql);
				show_dvg();
			}
			else
			{
				MessageBox.Show("Chọn nhân viên muôn cập nhập!");
			}
        }


        private void btnHuy_Click(object sender, EventArgs e)
        {
			this.Close();
        }

        private void dgvNhanVien_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
			var row = dgvNhanVien.SelectedRows;

			txtTenNV.Text = row[0].Cells["Tên nhân viên"].Value.ToString();
			txtDOB.Text = row[0].Cells["Ngày sinh"].Value.ToString();
			txtDiaChi.Text = row[0].Cells["Địa chỉ"].Value.ToString();
			txtSDT.Text = row[0].Cells["Số điện thoại"].Value.ToString();
			cmbGioiTinh.Text = row[0].Cells["Giới tính"].Value.ToString();
			cmbChuyenMon.Text = row[0].Cells["Chuyên môn"].Value.ToString();
			cmbTrinhDo.Text = row[0].Cells["Trình độ"].Value.ToString();
			mnv = row[0].Cells["Mã nhân viên"].Value.ToString();
        }
		public void showNV(string s)
		{
			DataTable dt = pd.ReadTable("select a.MaNhanVien as N'Mã nhân viên', a.TenNV as N'Tên nhân viên', a.NgaySinh as N'Ngày sinh' ,a.DiaChi as N'Địa chỉ', \r\na.DienThoai as N'Số điện thoại',\r\na.GioiTinh as N'Giới tính',b.TenTrinhDo as N'Trình độ',c.TenChuyenMon as N'Chuyên môn'\r\nfrom NhanVien a join Trinhdo b on a.MaTrinhdo= b.matrinhdo\r\n\t\t\tjoin ChuyenMon c on a.MaChuyenMon=c.MaChuyenMon where manhanvien=N'" + s + "'");

            txtTenNV.Text = dt.Rows[0]["Tên nhân viên"].ToString();
            txtDOB.Text = dt.Rows[0]["Ngày sinh"].ToString();
            txtDiaChi.Text = dt.Rows[0]["Địa chỉ"].ToString();
            txtSDT.Text = dt.Rows[0]["Số điện thoại"].ToString();
            cmbGioiTinh.Text = dt.Rows[0]["Giới tính"].ToString();
            cmbChuyenMon.Text = dt.Rows[0]["Chuyên môn"].ToString();
            cmbTrinhDo.Text = dt.Rows[0]["Trình độ"].ToString();
            mnv = dt.Rows[0]["Mã nhân viên"].ToString();
        }
    }
}
