using BTL;
using Quan_Ly_Thuoc.Data;
using Quan_Ly_Thuoc.Forms.Function;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace Quan_Ly_Thuoc.Forms.Search
{
    public partial class SearchThuoc : Form
    {
        ProcessDatabase pd=new ProcessDatabase();
        DataTable tableThuoc;

        List<String> lName = new List<string>();
        public SearchThuoc()
        {
            InitializeComponent();
        }

        private void btn_search_name_Click(object sender, EventArgs e)
        {
            listBoxName.Items.Clear();
            Search_Name(txt_search_name.Text);
        }
        private void Search_Name(string text)
        {
            string sql = "select distinct a.TenThuoc from DanhMucThuoc a where a.TenThuoc like N'%" + text+ "%' order by a.TenThuoc asc";
            tableThuoc = pd.ReadTable(sql);
            for (int i = 0; i < tableThuoc.Rows.Count; i++)
            {
                listBoxName.Items.Add(tableThuoc.Rows[i]["TenThuoc"].ToString());
                lName.Add(tableThuoc.Rows[i]["TenThuoc"].ToString().ToLower());
            }
        }

        private void listBoxName_DoubleClick(object sender, EventArgs e)
        {
            FormNhapThuoc form = new FormNhapThuoc();
            form.show_medicine(listBoxName.SelectedItem.ToString());
            form.setView();
            form.ShowDialog();
        }

        private void btn_search_function_Click(object sender, EventArgs e)
        {
            listBoxFunction.Items.Clear();
            Search_Function(txt_search_function.Text);
        }
        private void Search_Function(string function)
        {
            string sql = "select distinct a.MaThuoc,a.TenThuoc,c.TenCongDung\r\nfrom DanhMucThuoc a join Thuoc_CongDung b on a.MaThuoc=b.MaThuoc\r\n\t\tjoin CongDung c on b.MaCongDung=c.MaCongDung\r\nwhere c.TenCongDung like N'%" + function+ "%' order by a.TenThuoc asc";
            tableThuoc = pd.ReadTable(sql);
            for (int i = 0; i < tableThuoc.Rows.Count; i++)
            {
                listBoxFunction.Items.Add(tableThuoc.Rows[i]["TenThuoc"].ToString());
            }
        }

        private void listBoxFunction_DoubleClick(object sender, EventArgs e)
        {
            FormNhapThuoc form = new FormNhapThuoc();
            form.show_medicine(listBoxFunction.SelectedItem.ToString());
            form.setView();
            form.ShowDialog();
        }

        private void btn_search_ingredient_Click(object sender, EventArgs e)
        {
            listBoxIngredient.Items.Clear();
            Search_Ingredient(txt_search_ingredient.Text);
        }
        public void Search_Ingredient(string ingredient)
        {
            string sql = "select distinct a.MaThuoc,a.TenThuoc\r\nfrom DanhMucThuoc a\r\nwhere a.ThanhPhan like N'%"+ingredient+ "%' order by a.TenThuoc asc";
            tableThuoc = pd.ReadTable(sql);
            for (int i = 0; i < tableThuoc.Rows.Count; i++)
            {
                listBoxIngredient.Items.Add(tableThuoc.Rows[i]["TenThuoc"].ToString());
            }
        }

        private void listBoxIngredient_DoubleClick(object sender, EventArgs e)
        {
            FormNhapThuoc form = new FormNhapThuoc();
            form.show_medicine(listBoxIngredient.SelectedItem.ToString());
            form.setView();
            form.ShowDialog();
        }

        private void Search_Load(object sender, EventArgs e)
        {
            Search_Name("");
            Search_Function("");
            Search_Ingredient("");
			txt_search_name.TextChanged += txt_search_name_TextChanged;
        }

		private void txt_search_name_TextChanged(object sender, EventArgs e)
		{
			var newList = new List<string>(lName.Cast<string>());
			var itemsToRemove = new List<string>();
			string searchText = txt_search_name.Text.ToLower();

			foreach (string s in newList)
			{
				if (!s.Contains(searchText))
				{
					itemsToRemove.Add(s);
				}
			}

			foreach (string item in itemsToRemove)
			{
				newList.Remove(item);
			}

			listBoxName.Items.Clear();
			listBoxName.Items.AddRange(newList.ToArray());
		}
	}
}
