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

namespace LAVITAapp.View.QuanLyHangTonKho
{
    public partial class UC_HangTonKho : UserControl
    {
        AppDbContext db = new AppDbContext();
        public UC_HangTonKho()
        {
            InitializeComponent();
        }

        private void UC_HangTonKho_Load(object sender, EventArgs e)
        {
            loadData();
        }

        void loadData()
        {
            dgvhanghoa.DataSource = db.Hangs.ToList();
            var category = new List<dynamic>
            {
                new { Value = "Laptop", Text = "Laptop" },
                new { Value = "Phu Kien", Text = "Phụ Kiện" },
                new { Value = "Man Hinh", Text = "Màn Hình" },
                new { Value = "Luu Tru", Text = "Lưu Trữ" }
            };

            cbcategory.DataSource = category;
            cbcategory.DisplayMember = "Text";
            cbcategory.ValueMember = "Value";
        }
        void ClearForm()
        {
            txttenhang.Text = "";
            txtsoluong.Text = "";
            txtsearch.Text = "";
            txtdongia.Text = "";
        }

        private void btlammoi_Click(object sender, EventArgs e)
        {
            loadData();
            ClearForm();
        }

        private void btthem_Click(object sender, EventArgs e)
        {
            new Form_ThemHang().ShowDialog();
            loadData();
        }

        private void btsua_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvhanghoa.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn một món hàng để sửa.");
                    return;
                }

                int row = dgvhanghoa.CurrentCell.RowIndex;

                if (!int.TryParse(dgvhanghoa.Rows[dgvhanghoa.CurrentRow.Index].Cells[0].Value.ToString(), out int maKH))
                {
                    MessageBox.Show("Vui lòng chọn món hàng hợp lệ để sửa.");
                    return;
                }

                if (string.IsNullOrWhiteSpace(txttenhang.Text) ||
                    string.IsNullOrWhiteSpace(txtsoluong.Text) ||
                    string.IsNullOrWhiteSpace(txtdongia.Text))
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin món hàng.");
                    return;
                }
                DialogResult result = MessageBox.Show($"Sửa thông tin món hàng {maKH}?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result != DialogResult.Yes)
                {
                    return;
                }
                var kh = db.Hangs.Find(maKH);
                if (kh != null)
                {
                    kh.TenHang = txttenhang.Text.Trim();
                    if (!int.TryParse(txtsoluong.Text.Trim(), out int soluong))
                    {
                        MessageBox.Show("Số lượng phải là số hợp lệ.");
                        return;
                    }
                    kh.SoLuongTon = soluong;
                    if (!double.TryParse(txtdongia.Text.Trim(), out double dongia))
                    {
                        MessageBox.Show("Đơn giá phải là số hợp lệ.");
                        return;
                    }
                    kh.DonGia = dongia;
                    if (cbcategory.SelectedValue == null)
                    {
                        MessageBox.Show("Vui lòng chọn loại hàng.");
                        return;
                    }

                    kh.LoaiHang = cbcategory.SelectedValue.ToString();
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

        private void btxoa_Click(object sender, EventArgs e)
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

                if (dgvhanghoa.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn một món hàng để xóa.");
                    return;
                }

                int row = dgvhanghoa.CurrentCell.RowIndex;

                if (!int.TryParse(dgvhanghoa.Rows[dgvhanghoa.CurrentRow.Index].Cells[0].Value.ToString(), out int maKH))
                {
                    MessageBox.Show("Vui lòng chọn món hàng hợp lệ để xóa.");
                    return;
                }

                DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa món hàng này không?",
                                                      "Xác nhận xóa",
                                                      MessageBoxButtons.YesNo,
                                                      MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    var kh = db.Hangs.Find(maKH);
                    if (kh == null)
                    {
                        //MessageBoxHelper.ShowError("Không tìm thấy độc giả.");
                        MessageBox.Show("Không tìm thấy món hàng.");
                        return;
                    }

                    db.Hangs.Remove(kh);
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
            var result = db.Hangs.Where(d => d.TenHang.Contains(keyword)).ToList();
            dgvhanghoa.DataSource = result;
        }

        private void dgvhanghoa_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvhanghoa.ClearSelection();
            dgvhanghoa.CurrentCell = null;
        }

        private void dgvhanghoa_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvhanghoa.Columns[e.ColumnIndex].Name == "Ma" && e.Value != null)
            {
                int so;
                if (int.TryParse(e.Value.ToString(), out so))
                {
                    e.Value = "HH" + so.ToString("D3");
                    e.FormattingApplied = true;
                }
            }
        }
    }
}
