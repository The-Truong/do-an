using LAVITAapp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LAVITAapp.View.ThongTin
{
    public partial class UC_ThongTin : UserControl
    {
        MainForm mainForm;
        public UC_ThongTin(MainForm _mainForm, TaiKhoan tk)
        {
            InitializeComponent();
            mainForm = _mainForm;
            lbtk.Text = tk.TenDangNhap;
            lbpq.Text = tk.Quyen;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
            "Bạn có chắc chắn muốn đăng xuất không?",
            "Xác nhận",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question
            );
            if (result == DialogResult.Yes)
            {
                mainForm.Close();

                var loginForm = new LoginForm();
                loginForm.ShowDialog();

            }
        }
    }
}
