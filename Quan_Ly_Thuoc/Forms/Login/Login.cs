using System;
using System.Windows.Forms;

namespace Quan_Ly_Thuoc.Forms.Login
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        private void Login_Load(object sender, EventArgs e)
        {
            textBoxAccount.Focus();
        }
    }
}
