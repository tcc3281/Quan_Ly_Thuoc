using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quan_Ly_Thuoc.Forms.Function
{
    public partial class FormNhapThuoc : Form
    {
        public FormNhapThuoc()
        {
            InitializeComponent();
        }
        //reset lại dữ liệu đã nhập trong form
        private void buttonClear_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void clear()
        {
            textBoxMedicineName.Text= string.Empty;
            textBoxFormMedicine.Text= string.Empty;
            textBoxNotRecommended.Text= string.Empty;
            richTextBoxIngredient.Text= string.Empty;
            comboBoxCountry.Text= string.Empty;
            comboBoxProducer.Text= string.Empty;
            comboBoxUnit.Text= string.Empty;
        }
    }
}
