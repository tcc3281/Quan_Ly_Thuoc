using Quan_Ly_Thuoc.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quan_Ly_Thuoc
{
    public partial class FormHoaDonNhap : Form
    {
		ProcessDatabase pd = new ProcessDatabase();
        public FormHoaDonNhap()
        {
            InitializeComponent();
        }

        private string IDHDN()
        {
			pd.CreateCMD();
			pd.cmd.CommandText = "Select count(*) from ChiTietHDN";
			pd.Connect();
			int cnt = (int)pd.cmd.ExecuteScalar() + 1;
			pd.Disconnect();

			String result = "HDN";
			for (int i = 0; i < 3 - cnt.ToString().Length; i++)
			{
				result += "0";
			}
			result += (cnt.ToString());
			return result;
		}

        private void FormHoaDonNhap_Load(object sender, EventArgs e)
        {
            txtMaHD.Text = IDHDN();
			dgvCTHDN.DataSource = pd.ReadTable("select * from ChiTietHDN");
        }
    }
}
