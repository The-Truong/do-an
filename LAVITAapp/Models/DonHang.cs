using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAVITAapp.Models
{
    public class DonHang
    {
        [Key]
        public string Ma { get; set; }
        [Required]
        public DateTime NgayDat { get; set; }
        [Required]
        public DateTime NgayGiao { get; set; }
        //public string MaHang { get; set; }
        //public string TenHang { get; set; }
        //public int SoLuong { get; set; }
        //public double DonGia { get; set; }
        [Required]
        public string MaKhach { get; set; }
        public KhachHang? KhachHang { get; set; }
        public List<DuLieuDatHang> DuLieuDatHangs { get; set; }
    }

}
