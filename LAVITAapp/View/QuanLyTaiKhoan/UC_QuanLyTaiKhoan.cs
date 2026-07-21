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
    public partial class UC_QuanLyTaiKhoan : UserControl
    {
        AppDbContext db = new AppDbContext();
        public UC_QuanLyTaiKhoan()
        {
            InitializeComponent();
        }

        private void UC_QuanLyTaiKhoan_Load(object sender, EventArgs e)
        {
            loadData();

        }

        void loadData()
        {
            dgvtaikhoan.DataSource = null;
            dgvtaikhoan.DataSource = db.TaiKhoans.ToList();
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
        void ClearForm()
        {
            txtpass.Text = "";
            txtsearch.Text = "";
            txtuser.Text = "";
        }
        private void guna2Button5_Click(object sender, EventArgs e)
        {
            loadData();
            ClearForm();
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            new Form_AddTaiKhoan().ShowDialog();
            loadData();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvtaikhoan.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn tài khoản để sửa.");
                    return;
                }

                int row = dgvtaikhoan.CurrentCell.RowIndex;
                string maTK = dgvtaikhoan.Rows[dgvtaikhoan.CurrentRow.Index].Cells[0].Value?.ToString();
                if (string.IsNullOrWhiteSpace(maTK))
                {
                    MessageBox.Show("Vui lòng chọn tài khoản hợp lệ để sửa.");
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtpass.Text) ||
                    string.IsNullOrWhiteSpace(txtuser.Text))
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin tài khoản.");
                    return;
                }
                DialogResult result = MessageBox.Show($"Sửa thông tin khách hàng {maTK}?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result != DialogResult.Yes)
                {
                    return;
                }
                var tk = db.TaiKhoans.Find(maTK);
                if (tk != null)
                {
                    tk.MatKhau = txtpass.Text.Trim();
                    if (cbrole.SelectedValue == null)
                    {
                        MessageBox.Show("Vui lòng chọn phân quyền.");
                        return;
                    }

                    tk.Quyen = cbrole.SelectedValue.ToString();
                    db.SaveChanges();
                }
                MessageBox.Show("Cập nhật thông tin thành công!");
                loadData();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật: " + ex.Message);
            }
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            try
            {
                //if (dgvkhachhang.CurrentRow == null)
                //{
                //    MessageBox.Show("Vui lòng chọn một khách hàng để xóa.");
                //    return;
                //}

                ////if (!int.TryParse(dgvkhachhang.Rows[dgvkhachhang.CurrentRow.Index].Cells[0].Value.ToString(), out int maDG))
                ////{
                ////    MessageBox.Show("Mã độc giả không hợp lệ.");
                ////    return;
                ////}
                //string maKH = dgvkhachhang.Rows[dgvkhachhang.CurrentRow.Index].Cells[0].Value?.ToString();

                if (dgvtaikhoan.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn một tài khoản để xóa.");
                    return;
                }

                string maTK = dgvtaikhoan.Rows[dgvtaikhoan.CurrentRow.Index].Cells[0].Value?.ToString();
                if (string.IsNullOrWhiteSpace(maTK))
                {
                    MessageBox.Show("Vui lòng chọn tài khoản hợp lệ để xóa.");
                    return;
                }

                DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa tài khoản này không?",
                                                      "Xác nhận xóa",
                                                      MessageBoxButtons.YesNo,
                                                      MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    var kh = db.TaiKhoans.Find(maTK);
                    if (kh == null)
                    {
                        //MessageBoxHelper.ShowError("Không tìm thấy độc giả.");
                        MessageBox.Show("Không tìm thấy tài khoản.");
                        return;
                    }

                    db.TaiKhoans.Remove(kh);
                    db.SaveChanges();
                    //MessageBoxHelper.ShowSuccess("Xóa độc giả thành công!");
                    MessageBox.Show("Xóa thành công.");
                    loadData();
                    ClearForm();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa: " + ex.Message);
            }
        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtsearch.Text.Trim();
            var result = db.TaiKhoans.Where(d => d.TenDangNhap.Contains(keyword)).ToList();
            dgvtaikhoan.DataSource = result;
        }

        private void dgvtaikhoan_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvtaikhoan.ClearSelection();
            dgvtaikhoan.CurrentCell = null;
        }

        private void dgvtaikhoan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = dgvtaikhoan.CurrentRow.Index;
            txtuser.Text = dgvtaikhoan.Rows[row].Cells[0].Value.ToString();
            txtpass.Text = dgvtaikhoan.Rows[row].Cells[1].Value.ToString();
            string role = dgvtaikhoan.Rows[row].Cells[2].Value.ToString();
            cbrole.SelectedValue = role;
        }
    }
}
