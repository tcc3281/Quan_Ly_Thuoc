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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Quan_Ly_Thuoc
{
	public partial class FormHoaDonBan : Form
	{
		ProcessDatabase pd = new ProcessDatabase();

		private List<string> lThuoc = new List<string>();
		public FormHoaDonBan()
		{
			InitializeComponent();
		}

		private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
		{

		}


		private void FormHoaDon_Load(object sender, EventArgs e)
		{
			DataTable dtThuoc = pd.ReadTable("Select * from DanhMucThuoc");
			for (int i = 0; i < dtThuoc.Rows.Count; i++)
				lThuoc.Add(dtThuoc.Rows[i]["TenThuoc"].ToString());

			foreach (string s in lThuoc)
			{
				listThuoc.Items.Add(s);
			}

			txtSearchThuoc.TextChanged += txtSreachThuoc_TextChanged;
		}

		private void txtSreachThuoc_TextChanged(object sender, EventArgs e)
		{
			var newList = new List<string>(lThuoc.Cast<string>());
			var itemsToRemove = new List<string>();
			string searchText = txtSearchThuoc.Text;

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

			listThuoc.Items.Clear();
			listThuoc.Items.AddRange(newList.ToArray());
		}


		private void FormHoaDon_SizeChanged(object sender, EventArgs e)
		{
			setWidthColumns();
		}

		//chỉnh các component khi thu phóng
		private void setWidthColumns()
		{
			// chỉnh trong listview
			int adjust0 = panel7.Width;
			//lHDB.Columns[0].Width = (int)(adjust0 * 0.55);
			//lHDB.Columns[1].Width = (int)(adjust0 * 0.45);

			//chỉnh các textbox và button

			btnSearchThuoc.Height = txtSearchThuoc.Height;

		}

		private void listThuoc_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			String tenThuoc = listThuoc.SelectedItem.ToString();

			int index = -1;
			for (int i = 0; i < lHDB.Items.Count; i++)
			{
				if (lHDB.Items[i].SubItems[0].Text == tenThuoc)
				{
					index = i;
					break;
				}
			}

			if (index == -1)
			{
				ListViewItem item = new ListViewItem();

				item.Text = tenThuoc;
				item.SubItems.Add("1");
				item.SubItems.Add("10000");
				lHDB.Items.Add(item);
			}
			else
			{
				int sl = int.Parse(lHDB.Items[index].SubItems[1].Text) + 1;
				lHDB.Items[index].SubItems[1].Text = sl.ToString();
				lHDB.Items[index].SubItems[2].Text = (sl * 10000).ToString();
			}
		}

		private void btnSuaSL_Click(object sender, EventArgs e)
		{
			int index = lHDB.SelectedItems[0].Index;
			int sl = (int)txtSL.Value;
			lHDB.Items[index].SubItems[1].Text = sl.ToString();
			lHDB.Items[index].SubItems[2].Text = (sl * 10000).ToString();

			txtSL.ResetText();
		}

		private void lHDB_DoubleClick(object sender, EventArgs e)
		{
			int index = lHDB.SelectedItems[0].Index;
			txtSL.Value = int.Parse(lHDB.Items[index].SubItems[1].Text);
		}
	}
}
