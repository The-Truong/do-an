using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAVITAapp.Models
{
    public class Hang
    {
        [Key]
        public string Ma { get; set; }
        [Required]
        public string TenHang { get; set; }
        public string? MoTa { get; set; }
        public string? LoaiHang { get; set; }
        [Required]
        public int SoLuongTon { get; set; }
        [Required]
        public double DonGia { get; set; }
        public List<DuLieuDatHang>? DuLieuDatHangs { get; set; }
    }
}
