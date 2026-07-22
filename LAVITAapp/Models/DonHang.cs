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
    public class DonHang
    {
        [Key]
        [DisplayName("Mã Đơn Hàng")]
        public int Ma { get; set; }
        [DisplayName("Ngày Đặt")]
        public DateTime NgayDat { get; set; }
        [DisplayName("Ngày Giao")]
        public DateTime NgayGiao { get; set; }
        [ForeignKey("KhachHang")]
        [DisplayName("Mã Khách Hàng")]
        public int MaKhach { get; set; }
        [DisplayName("Trạng Thái")]
        public string TrangThai { get; set; }
        [DisplayName("Mô Tả")]
        public string? MoTa { get; set; }
        public KhachHang? KhachHang { get; set; }
        public List<DuLieuDatHang>? DuLieuDatHangs { get; set; }
    }

}
