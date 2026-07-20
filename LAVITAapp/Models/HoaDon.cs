using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAVITAapp.Models
{
    public class HoaDon
    {
        [Key]
        public string Ma { get; set; }

        [Required]
        public DateTime NgayLap { get; set; }

        public double TongTien { get; set; }

        public bool DaThanhToan { get; set; }

        [Required]
        public string MaDonHang { get; set; }
        public DonHang? DonHang { get; set; }

        [Required]
        public string MaKeToan { get; set; }
        public NhanVien? KeToanVien { get; set; }
    }
}
