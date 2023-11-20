using Quan_Ly_Thuoc.Data;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Quan_Ly_Thuoc.Forms.Functions
{
    public partial class FormKhachHang : Form
    {
        ProcessDatabase pd = new ProcessDatabase();
        public FormKhachHang()
        {
            InitializeComponent();
        }
        private void FormKhachHang_Load(object sender, EventArgs e)
        {
            txtMaKH.Text = IDKH();
        }
		private string IDKH()
		{
			pd.CreateCMD();
			pd.cmd.CommandText = "Select top(1) makhach from KhachHang order by makhach desc";
			pd.Connect();
            string s=(string)pd.cmd.ExecuteScalar();
            int cnt = int.Parse(s.Substring(2)) + 1;
			pd.Disconnect();

			String result = "KH";
			for (int i = 0; i < 3 - cnt.ToString().Length; i++)
			{
				result += "0";
			}
			result += (cnt.ToString());
			return result;
		}
		private void btnImortImg_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "(*.jpg; *.png; *.gif)|*.jpg; *.png; *.gif";
            openFileDialog.ShowDialog();

            // nhân viên chọn một tệp và mở tệp
            if (openFileDialog.FileName != "")
            {
                // Tải hình ảnh từ tệp đó
                Image image = Image.FromFile(openFileDialog.FileName);

                // Đặt hình ảnh vào textbox
                ImgUser.Image = image;
            }
        }
        private bool Validate()
        {
            if (txtTenKH.Text.Trim() == "" || txtSDT.Text.Trim() == "")
            {
                return false;
            }
            return true;
        }
		private void btnLuu_Click(object sender, EventArgs e)
		{
            if (Validate())
            {
                String sql = "insert into KhachHang(MaKhach, TenKhach, DiaChi, DienThoai) " +
                    "values('" + txtMaKH.Text + "', N'" + txtTenKH.Text + "', N'" + 
                    txtDiaChi.Text + "','" + txtSDT.Text + "')";
				//MessageBox.Show(sql);
				pd.RunSQL(sql);
                this.Close();
			}
            else
            {
                MessageBox.Show("Cần điền tên và số điện thoại khách hàng.", "Thông báo");
            }
		}
		private void btnHuy_Click(object sender, EventArgs e)
		{
            this.Close();
		}
	}
}
