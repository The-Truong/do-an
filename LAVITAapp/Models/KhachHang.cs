using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAVITAapp.Models
{
    public class KhachHang
    {
        [Key]
        [DisplayName("Mã Khách Hàng")]
        public int Ma { get; set; }
        [DisplayName("Tên Khách Hàng")]
        public string HoTen { get; set; }
        [DisplayName("CMND")]
        public string CMND { get; set; }
        [DisplayName("Địa Chỉ")]
        public string? DiaChi { get; set; }
        [DisplayName("Mã Bưu Chính")]
        public string? MaBuuChinh { get; set; }
        [DisplayName("Mã Thành Phố")]
        public string? ThanhPho { get; set; }
        [DisplayName("Số Điện Thoại")]
        public string SoDienThoai { get; set; }
        [DisplayName("Mã Thuế")]
        public string MaThue { get; set; }
        [DisplayName("Tín Dụng")]
        public double TinDung { get; set; }
        // them vao
        [ForeignKey("NhanVien")]
        public int MaKSV { get; set; }
        public NhanVien? KiemSoatVien { get; set; }
        public List<DuLieuDatHang>? DonDatHangs { get; set; }
        public List<DonHang>? DonHangs { get; set; }
    }
}
