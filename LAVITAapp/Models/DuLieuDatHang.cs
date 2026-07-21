using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAVITAapp.Models
{
    public class DuLieuDatHang
    {
        [Key]
        [DisplayName("Mã")]
        public int Ma { get; set; }
        [DisplayName("Mã Đơn Hàng")]
        public int MaDonHang { get; set; }
        [DisplayName("Mã Hàng")]
        public int MaHang { get; set; }
        [DisplayName("Số Lượng")]
        public int SoLuong { get; set; }
        [DisplayName("Đơn Giá")]
        public double DonGia { get; set; }
        public Hang? Hang { get; set; }
        public DonHang? DonHang { get; set; }

    }
}
