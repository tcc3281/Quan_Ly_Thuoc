using Quan_Ly_Thuoc.Data;
using System;
using System.Data;
using System.Windows.Forms;

namespace Quan_Ly_Thuoc.Forms.Search
{
    public partial class FormSearchHDN : Form
    {
        ProcessDatabase pd=new ProcessDatabase();
        DataTable tableThuoc;
        DataTable tableNhanVien;
        DataTable tableNCC;
        QL_Thuoc form;
        public FormSearchHDN(QL_Thuoc form)
        {
            InitializeComponent();
            loadData();
            this.form = form;
        }
        private void FormSearchHDN_Load(object sender, EventArgs e)
        {
        }
        private void loadData()
        {
            tableThuoc = pd.ReadTable("select * from DanhMucThuoc");
            tableNhanVien = pd.ReadTable("select * from NhanVien");
            tableNCC = pd.ReadTable("select * from NhaCungCap");
            for(int i=0;i<tableThuoc.Rows.Count;i++)
            {
                cmb_Medicine.Items.Add(tableThuoc.Rows[i]["TenThuoc"].ToString());
            }
            for (int i = 0; i < tableNhanVien.Rows.Count; i++)
            {
                cmb_staff.Items.Add(tableNhanVien.Rows[i]["TenNV"].ToString());
            }
            for (int i = 0; i < tableNCC.Rows.Count; i++)
            {
                cmb_producer.Items.Add(tableNCC.Rows[i]["TenNCC"].ToString());
            }
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            search(
                cmb_Medicine.SelectedIndex >= 0 ? tableThuoc.Rows[cmb_Medicine.SelectedIndex]["MaTHuoc"].ToString() : "",
                cmb_staff.SelectedIndex>=0?tableNhanVien.Rows[cmb_staff.SelectedIndex]["MaNhanVien"].ToString():"",
                cmb_producer.SelectedIndex>=0? tableNCC.Rows[cmb_producer.SelectedIndex]["MaNCC"].ToString():"");
        }
        private void search(string medicine="",string staff="",string produser="")
        {
            form.add_tabpage_HDN(medicine,staff,produser);
        }
    }
}
