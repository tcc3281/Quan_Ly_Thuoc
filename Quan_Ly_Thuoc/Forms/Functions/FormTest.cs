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
	public partial class FormTest : Form
	{
		public FormTest()
		{
			InitializeComponent();
		}

		private void LoadData()
		{
			for (int i = 0; i < 10; i++)
			{
				Panel panel = new Panel();
				panel.BorderStyle = BorderStyle.FixedSingle; // Để có viền
				panel.Width = 200; // Điều chỉnh chiều rộng của Panel
				panel.Height = 150; // Điều chỉnh chiều cao của Panel

				Label nameLabel = new Label() { Text = "Tên:" };
				Label ageLabel = new Label() { Text = "Tuổi:" };
				Label addressLabel = new Label() { Text = "Địa chỉ:" };

				// Điều chỉnh vị trí và kích thước của các Label
				nameLabel.Location = new Point(10, 10);
				ageLabel.Location = new Point(10, 40);
				addressLabel.Location = new Point(10, 70);

				Button viewButton = new Button() { Text = "Xem hóa đơn", AutoSize = true };
				viewButton.Click += ViewButton_Click; // Thêm sự kiện Click
				Button cancelButton = new Button() { Text = "Hủy", AutoSize = true };

				// Điều chỉnh vị trí của các Button
				viewButton.Location = new Point(10, 100);
				cancelButton.Location = new Point(10 + viewButton.Width + 10, 100);

				panel.Controls.Add(nameLabel);
				panel.Controls.Add(ageLabel);
				panel.Controls.Add(addressLabel);
				panel.Controls.Add(viewButton);
				panel.Controls.Add(cancelButton);

				flowLayoutPanel1.Controls.Add(panel);
			}
		}
		private void FormTest_Load(object sender, EventArgs e)
		{
			LoadData();
		}

		private void ViewButton_Click(object sender, EventArgs e)
		{
			// Lấy thông tin từ các Label trong Panel
			Panel panel = (Panel)((Button)sender).Parent;
			Label nameLabel = (Label)panel.Controls[0]; // Label "Tên"
			Label ageLabel = (Label)panel.Controls[1]; // Label "Tuổi"
			Label addressLabel = (Label)panel.Controls[2]; // Label "Địa chỉ"

			// Hiển thị thông tin trong một dialog chi tiết
			string details = $"Tên: {nameLabel.Text}\nTuổi: {ageLabel.Text}\nĐịa chỉ: {addressLabel.Text}";
			MessageBox.Show(details, "Chi tiết dữ liệu");
		}
	}
}
