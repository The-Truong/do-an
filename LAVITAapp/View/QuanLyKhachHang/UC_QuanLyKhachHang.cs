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

namespace LAVITAapp.View.QuanLyKhachHang
{
    public partial class UC_QuanLyKhachHang : UserControl
    {
        AppDbContext db = new AppDbContext();
        public UC_QuanLyKhachHang()
        {
            InitializeComponent();
        }

        private void UC_QuanLyKhachHang_Load(object sender, EventArgs e)
        {
            loadData();
        }

        void loadData()
        {
            dgvkhachhang.DataSource = db.KhachHangs.ToList();
            dgvkhachhang.Columns["KiemSoatVien"].Visible = false;
            guna2ComboBox1.DataSource = db.Set<NhanVien>()
            .Select(nv => new
            {
                nv.Ma,
                HienThi = $"NV{nv.Ma:D3} - {nv.HoTen}"
            })
            .ToList();
            guna2ComboBox1.DisplayMember = "HienThi";
            guna2ComboBox1.ValueMember = "Ma";
            dgvkhachhang.Columns[0].Width = 100;
            dgvkhachhang.Columns[1].Width = 180;
            dgvkhachhang.Columns[2].Width = 150;
            dgvkhachhang.Columns[3].Width = 250;
            dgvkhachhang.Columns[4].Width = 150;
            dgvkhachhang.Columns[5].Width = 150;
        }
        void ClearForm()
        {
            txtten.Text = "";
            txtcancuoc.Text = "";
            txtdiachi.Text = "";
            txtbuuchinh.Text = "";
            txtthanhpho.Text = "";
            txtdienthoai.Text = "";
            txtthue.Text = "";
            txttindung.Text = "";
        }

        private void btlammoi_Click(object sender, EventArgs e)
        {
            loadData();
            ClearForm();
        }

        private void btthem_Click(object sender, EventArgs e)
        {
            new Form_ThemKhachHang().ShowDialog();
            loadData();
        }

        private void btsua_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvkhachhang.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn một khách hàng để sửa.");
                    return;
                }

                int row = dgvkhachhang.CurrentCell.RowIndex;

                if (!int.TryParse(dgvkhachhang.Rows[dgvkhachhang.CurrentRow.Index].Cells[0].Value.ToString(), out int maKH))
                {
                    MessageBox.Show("Vui lòng chọn khách hàng hợp lệ để sửa.");
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtten.Text) ||
                    string.IsNullOrWhiteSpace(txtcancuoc.Text) ||
                    string.IsNullOrWhiteSpace(txtdiachi.Text) ||
                    string.IsNullOrWhiteSpace(txtbuuchinh.Text) ||
                    string.IsNullOrWhiteSpace(txtthanhpho.Text) ||
                    string.IsNullOrWhiteSpace(txtdienthoai.Text) ||
                    string.IsNullOrWhiteSpace(txtthue.Text) ||
                    string.IsNullOrWhiteSpace(txttindung.Text))
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin khách hàng.");
                    return;
                }
                DialogResult result = MessageBox.Show($"Sửa thông tin khách hàng {maKH}?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result != DialogResult.Yes)
                {
                    return;
                }
                var kh = db.KhachHangs.Find(maKH);
                if (kh != null)
                {
                    kh.HoTen = txtten.Text.Trim();
                    kh.CMND = txtcancuoc.Text.Trim();
                    kh.DiaChi = txtdiachi.Text.Trim();
                    kh.MaBuuChinh = txtbuuchinh.Text.Trim();
                    kh.ThanhPho = txtthanhpho.Text.Trim();
                    kh.SoDienThoai = txtdienthoai.Text.Trim();
                    kh.MaThue = txtthue.Text.Trim();
                    if (!double.TryParse(txttindung.Text.Trim(), out double tinDung))
                    {
                        MessageBox.Show("Tín dụng phải là số hợp lệ.");
                        return;
                    }
                    kh.TinDung = tinDung;
                    if (guna2ComboBox1.SelectedValue == null)
                    {
                        MessageBox.Show("Vui lòng chọn kiểm soát viên.");
                        return;
                    }

                    kh.MaKSV = Convert.ToInt32(guna2ComboBox1.SelectedValue);
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

                if (dgvkhachhang.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn một khách hàng để xóa.");
                    return;
                }

                int row = dgvkhachhang.CurrentCell.RowIndex;

                if (!int.TryParse(dgvkhachhang.Rows[dgvkhachhang.CurrentRow.Index].Cells[0].Value.ToString(), out int maKH))
                {
                    MessageBox.Show("Vui lòng chọn khách hàng hợp lệ để xóa.");
                    return;
                }

                DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa khách hàng này không?",
                                                      "Xác nhận xóa",
                                                      MessageBoxButtons.YesNo,
                                                      MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    var kh = db.KhachHangs.Find(maKH);
                    if (kh == null)
                    {
                        //MessageBoxHelper.ShowError("Không tìm thấy độc giả.");
                        MessageBox.Show("Không tìm thấy khách hàng.");
                        return;
                    }

                    db.KhachHangs.Remove(kh);
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

        private void txttimkiem_TextChanged(object sender, EventArgs e)
        {
            string keyword = txttimkiem.Text.Trim();
            var result = db.KhachHangs.Where(d => d.HoTen.Contains(keyword)).ToList();
            dgvkhachhang.DataSource = result;
        }

        private void dgvkhachhang_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvkhachhang.ClearSelection();
            dgvkhachhang.CurrentCell = null;
        }

        private void dgvkhachhang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = dgvkhachhang.CurrentRow.Index;
            txtten.Text = dgvkhachhang.Rows[row].Cells[1].Value.ToString();
            txtcancuoc.Text = dgvkhachhang.Rows[row].Cells[2].Value.ToString();
            txtdiachi.Text = dgvkhachhang.Rows[row].Cells[3].Value.ToString();
            txtbuuchinh.Text = dgvkhachhang.Rows[row].Cells[4].Value.ToString();
            txtthanhpho.Text = dgvkhachhang.Rows[row].Cells[5].Value.ToString();
            txtdienthoai.Text = dgvkhachhang.Rows[row].Cells[6].Value.ToString();
            txtthue.Text = dgvkhachhang.Rows[row].Cells[7].Value.ToString();
            txttindung.Text = dgvkhachhang.Rows[row].Cells[8].Value.ToString();
            guna2ComboBox1.SelectedValue = Convert.ToInt32(dgvkhachhang.Rows[row].Cells["MaKSV"].Value);
        }

        private void dgvkhachhang_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvkhachhang.Columns[e.ColumnIndex].Name == "Ma" && e.Value != null)
            {
                int so;
                if (int.TryParse(e.Value.ToString(), out so))
                {
                    e.Value = "KH" + so.ToString("D3");
                    e.FormattingApplied = true;
                }
            }
            if (dgvkhachhang.Columns[e.ColumnIndex].Name == "MaKSV" && e.Value != null)
            {
                int so;
                if (int.TryParse(e.Value.ToString(), out so))
                {
                    e.Value = "NV" + so.ToString("D3");
                    e.FormattingApplied = true;
                }
            }
        }
    }
}
