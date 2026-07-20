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

namespace LAVITAapp.View.QuanLyKhachHang
{
    public partial class Form_ThemKhachHang : Form
    {
        AppDbContext db = new AppDbContext();
        public Form_ThemKhachHang()
        {
            this.Size = new Size(1204, 551);
            InitializeComponent();
            new Guna2ShadowForm().SetShadowForm(this);
        }

        private void btadd_Click(object sender, EventArgs e)
        {
            try
            {
                if (guna2ComboBox1.SelectedValue == null)
                {
                    MessageBox.Show("Vui lòng chọn kiểm soát viên.");
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
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin khách hàng");
                    return;
                }
                KhachHang kh = new KhachHang()
                {
                    HoTen = txtten.Text.Trim(),
                    CMND = txtcancuoc.Text.Trim(),
                    DiaChi = txtdiachi.Text.Trim(),
                    MaBuuChinh = txtbuuchinh.Text.Trim(),
                    ThanhPho = txtthanhpho.Text.Trim(),
                    SoDienThoai = txtdienthoai.Text.Trim(),
                    MaThue = txtthue.Text.Trim(),
                    TinDung = double.Parse(txttindung.Text.Trim()),
                    MaKSV = Convert.ToInt32(guna2ComboBox1.SelectedValue)
                };
                db.KhachHangs.Add(kh);
                db.SaveChanges();
                MessageBox.Show("Thêm khách hàng thành công");
            }
            catch (Microsoft.EntityFrameworkCore.DbUpdateException ex)
            {
                //MessageBox.Show("Lỗi khi thêm khách hàng: " + ex.Message);
                MessageBox.Show(ex.InnerException?.Message);
            }
            this.Close();
        }

        private void btreturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form_ThemKhachHang_Load(object sender, EventArgs e)
        {
            guna2ComboBox1.DataSource = db.Set<NhanVien>()
            .Select(nv => new
            {
                nv.Ma,
                HienThi = $"NV{nv.Ma:D3} - {nv.HoTen}"
            })
            .ToList();
            guna2ComboBox1.DisplayMember = "HienThi";
            guna2ComboBox1.ValueMember = "Ma";
        }
    }
}
