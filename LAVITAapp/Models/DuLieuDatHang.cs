using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAVITAapp.Models
{
    public class DuLieuDatHang
    {
        [Key]
        public string Ma { get; set; }
        public int SoLuong { get; set; }
        public double DonGia { get; set; }
        public bool TrangThai { get; set; }
        public string? MoTa { get; set; }
        //public string MaHang { get; set; }
        //public string TenHang { get; set; }
        //public int SoLuong { get; set; }
        //public double DonGia { get; set; }
        [Required]
        public string MaHang { get; set; }
        public Hang? Hang { get; set; }
        [Required]
        public string MaDonHang { get; set; }
        public DonHang? DonHang { get; set; }

    }
}
