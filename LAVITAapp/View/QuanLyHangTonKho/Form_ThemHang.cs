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
    public partial class Form_ThemHang : Form
    {
        AppDbContext db = new AppDbContext();
        public Form_ThemHang()
        {
            InitializeComponent();
        }

        private void btreturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btadd_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbcategory.SelectedValue == null)
                {
                    MessageBox.Show("Vui lòng chọn loại sản phẩm.");
                    return;
                }
                if (string.IsNullOrWhiteSpace(txtdongia.Text) ||
                    string.IsNullOrWhiteSpace(txtsoluong.Text) ||
                    string.IsNullOrWhiteSpace(txttenhang.Text))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin hàng hóa");
                    return;
                }
                Hang kh = new Hang()
                {
                    TenHang = txttenhang.Text,
                    LoaiHang = cbcategory.SelectedValue.ToString(),
                    SoLuongTon = int.Parse(txtsoluong.Text),
                    DonGia = double.Parse(txtdongia.Text)
                };
                db.Hangs.Add(kh);
                db.SaveChanges();
                MessageBox.Show("Thêm hàng hóa thành công");
            }
            catch (Microsoft.EntityFrameworkCore.DbUpdateException ex)
            {
                //MessageBox.Show("Lỗi khi thêm khách hàng: " + ex.Message);
                MessageBox.Show(ex.InnerException?.Message);
            }
            this.Close();
        }

        private void Form_ThemHang_Load(object sender, EventArgs e)
        {
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
    }
}
