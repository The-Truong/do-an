using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAVITAapp.Models
{
    public class Hang
    {
        [Key]
        [DisplayName("Mã Hàng")]
        public string Ma { get; set; }
        [DisplayName("Tên Hàng")]
        public string TenHang { get; set; }
        [DisplayName("Mô Tả")]
        public string? MoTa { get; set; }
        [DisplayName("Loại Hàng")]
        public string? LoaiHang { get; set; }
        [DisplayName("Số Lượng Tồn")]
        public int SoLuongTon { get; set; }
        [DisplayName("Đơn Giá")]
        public double DonGia { get; set; }
        public List<DuLieuDatHang>? DuLieuDatHangs { get; set; }
    }
}
