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
    public partial class FormNhaCungCap : Form
    {
        ProcessDatabase pd = new ProcessDatabase();
        public FormNhaCungCap()
        {
            InitializeComponent();
        }

        private String IDNCC()
        {
			String id = "NCC";
			pd.CreateCMD();
			pd.cmd.CommandText = "Select top(1) MaNCC from NhaCungCap order by MaNCC desc";
			pd.Connect();
			string s = (string)pd.cmd.ExecuteScalar();
			int cnt = int.Parse(s.Substring(3)) + 1;
			pd.Disconnect();

			for (int i = 0; i < 3 - cnt.ToString().Length; i++)
			{
				id += "0";
			}
			id += cnt.ToString();
			return id;
		}

		private void FormNhaCungCap_Load(object sender, EventArgs e)
		{
			txtMaNCC.Text = IDNCC();
			dgvNCC.DataSource = pd.ReadTable("select * from NhaCungCap");
		}

		private void btnInsert_Click(object sender, EventArgs e)
		{
			string sql = "insert into NhaCungCap values(N'" + txtMaNCC.Text + "',N'" +
				txtTenNCC.Text + "',N'" +
				txtDiaChi.Text + "','" +
				txtSDT.Text + "'" + ")";
			//MessageBox.Show(sql);
			pd.RunSQL(sql);
			dgvNCC.DataSource = pd.ReadTable("select * from NhaCungCap");
		}
	}
}
