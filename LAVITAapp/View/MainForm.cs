using LAVITAapp.Models;
using LAVITAapp.View.QuanLyKhachHang;
using LAVITAapp.View.QuanLyTaiKhoan;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LAVITAapp.View
{
    public partial class MainForm : Form
    {
        TaiKhoan tk = null;
        public MainForm()
        {
            this.Size = new Size(1500, 800);
            InitializeComponent();
        }

        public MainForm(TaiKhoan _tk)
        {
            this.Size = new Size(1500, 800);
            InitializeComponent();
            tk = _tk;
            //quản lý tài khoản
            if (!tk.Quyen.Equals("Admin"))
            {
                btnqltk.Visible = false;
            }
        }

        public void ShowUserControl(UserControl uc)
        {
            panelMain.Controls.Clear();           // Xóa nội dung cũ
            uc.Dock = DockStyle.Fill;             // Đổ đầy panel
            panelMain.Controls.Add(uc);           // Thêm vào
        }

        private void btnhskh_Click(object sender, EventArgs e)
        {
            ShowUserControl(new UC_QuanLyKhachHang());
        }

        private void btnqltk_Click(object sender, EventArgs e)
        {
            ShowUserControl(new UC_QuanLyTaiKhoan());
        }
    }
}
