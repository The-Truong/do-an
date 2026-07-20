using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAVITAapp.Models
{
    public class ToKhaiKienHang
    {
        [Key]
        public string Ma { get; set; }

        [Required]
        public DateTime NgayLap { get; set; }

        public string? GhiChu { get; set; }

        [Required]
        public string MaDonHang { get; set; }
        public DonHang? DonHang { get; set; }
    }
}
