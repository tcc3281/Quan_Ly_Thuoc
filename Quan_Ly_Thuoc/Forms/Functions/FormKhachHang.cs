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

namespace Quan_Ly_Thuoc.Forms.Functions
{
    public partial class FormKhachHang : Form
    {
        public FormKhachHang()
        {
            InitializeComponent();
        }

        private void FormKhachHang_Load(object sender, EventArgs e)
        {

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
    }
}
