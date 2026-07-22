using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAVITAapp.Models
{
    public class HoaDon
    {
        [Key]
        [DisplayName("Mã Hóa Đơn")]
        public int MaHoaDon { get; set; }
        [DisplayName("Mã Đơn Hàng")]
        public int MaDonHang { get; set; }
        [DisplayName("Ngày Lập")]
        public DateTime NgayLap { get; set; }
        [DisplayName("Trạng Thái Thu Tiền")]
        public bool DaThuTien { get; set; }
    }
}
