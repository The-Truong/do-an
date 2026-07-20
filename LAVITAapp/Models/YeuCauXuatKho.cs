using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAVITAapp.Models
{
    public class YeuCauXuatKho
    {
        [Key]
        public string Ma { get; set; }

        [Required]
        public DateTime NgayYeuCau { get; set; }

        public bool DaXuatKho { get; set; }

        [Required]
        public string MaDonHang { get; set; }
        public DonHang? DonHang { get; set; }

        [Required]
        public string MaNhanVien { get; set; }
        public NhanVien? NhanVienGiaoHang { get; set; }
    }
}
