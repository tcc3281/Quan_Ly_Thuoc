using Quan_Ly_Thuoc.Data;
using System;
using System.Data;
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
            txtMaKH.Text = IDKH();
        }
        private void FormKhachHang_Load(object sender, EventArgs e)
        {
            
        }
		private string IDKH()
		{
			pd.CreateCMD();
			pd.cmd.CommandText = "Select top(1) makhach from KhachHang order by makhach desc";
			pd.Connect();
            string s=(string)pd.cmd.ExecuteScalar();
            int cnt = 0;
            string result = "KH";
            try
            {
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
            bool check_update()
            {
                DataTable dt = pd.ReadTable("select * from KhachHang where Makhach = '" + txtMaKH.Text + "'");
                if (dt.Rows.Count > 0) return false;
                else return true;

            }
            if (Validate())
            {
                if (check_update())
                {
                    string sql = "insert into KhachHang(MaKhach, TenKhach, DiaChi, DienThoai) " +
                        "values('" + txtMaKH.Text + "', N'" + txtTenKH.Text + "', N'" + 
                        txtDiaChi.Text + "','" + txtSDT.Text + "')";
				    //MessageBox.Show(sql);
				    pd.RunSQL(sql);
                    this.Close();
                }
                else
                {
                    string sql = "update KhachHang set TenKhach=N'"+txtTenKH.Text+"',DiaChi=N'"+txtDiaChi.Text+"',DienThoai=N'"+txtSDT.Text+"' where MaKhach= N'"+txtMaKH.Text+"'";
                    //MessageBox.Show(sql);
                    pd.RunSQL(sql);
                    this.Close();
                }
                
			}
            else
            {
                MessageBox.Show("Cần điền tên và số điện thoại khách hàng.", "Thông báo");
            }
		}
        public void set_view(string ma)
        {
            DataTable dt = pd.ReadTable("select * from khachhang where makhach=N'"+ma+"'");
            txtMaKH.Text = dt.Rows[0]["Makhach"].ToString();
            txtTenKH.Text = dt.Rows[0]["tenkhach"].ToString();
            txtDiaChi.Text = dt.Rows[0]["Diachi"].ToString();
            txtSDT.Text = dt.Rows[0]["DienThoai"].ToString();
        }
        public void set_update()
        {
            txtMaKH.ReadOnly = false;
        }

        private void txtMaKH_Leave(object sender, EventArgs e)
        {
            try
            {
                set_view(txtMaKH.Text);
            }
            catch (IndexOutOfRangeException)
            {
                MessageBox.Show("Mã nhân viên không hợp lệ!");
                txtMaKH.Focus();
            }
            
        }
    }
}
