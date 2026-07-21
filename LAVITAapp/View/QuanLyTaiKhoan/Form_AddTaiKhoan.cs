using Guna.UI2.WinForms;
using LAVITAapp.Data;
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

namespace LAVITAapp.View.QuanLyTaiKhoan
{
    public partial class Form_AddTaiKhoan : Form
    {
        AppDbContext db = new AppDbContext();
        public Form_AddTaiKhoan()
        {
            InitializeComponent();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btadd_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbrole.SelectedValue == null)
                {
                    MessageBox.Show("Vui lòng chọn phân quyền.");
                    return;
                }
                if (string.IsNullOrWhiteSpace(txtuser.Text) ||
                    string.IsNullOrWhiteSpace(txtrepass.Text) ||
                    string.IsNullOrWhiteSpace(txtpass.Text))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin tài khoản");
                    return;
                }
                if (!txtrepass.Text.Equals(txtpass.Text))
                {
                    MessageBox.Show("Mật khẩu nhập lại không trùng khớp");
                    return;
                }
                TaiKhoan kh = new TaiKhoan()
                {
                    TenDangNhap = txtuser.Text,
                    MatKhau = txtpass.Text,
                    Quyen = cbrole.SelectedValue.ToString()
                };
                db.TaiKhoans.Add(kh);
                db.SaveChanges();
                MessageBox.Show("Thêm tài khoản thành công");
            }
            catch (Microsoft.EntityFrameworkCore.DbUpdateException ex)
            {
                //MessageBox.Show("Lỗi khi thêm khách hàng: " + ex.Message);
                MessageBox.Show(ex.InnerException?.Message);
            }
            this.Close();
        }

        private void Form_AddTaiKhoan_Load(object sender, EventArgs e)
        {
            var roles = new List<dynamic>
            {
                new { Value = "Admin", Text = "Quản trị viên" },
                new { Value = "GiaoDichVien", Text = "Giao dịch viên" },
                new { Value = "KiemSoatVien", Text = "Kiểm soát viên" },
                new { Value = "KeToanVien", Text = "Kế toán viên" }
            };

            cbrole.DataSource = roles;
            cbrole.DisplayMember = "Text";
            cbrole.ValueMember = "Value";
        }
    }
}
