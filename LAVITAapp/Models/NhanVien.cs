using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAVITAapp.Models
{
    public class NhanVien
    {
        [Key]
        [DisplayName("Mã Nhân Viên")]
        public int Ma { get; set; }
        [DisplayName("Tên Nhân Viên")]
        public string HoTen { get; set; }
        [DisplayName("Lương")]
        public double Luong { get; set; }
        [DisplayName("Mã Phòng")]
        public string MaPhong { get; set; }
        [DisplayName("Tên Phòng")]
        public string TenPhong { get; set; }
        [DisplayName("Chức Vụ")]
        public string ChucVu { get; set; }
        public List<KhachHang>? KhachHangs { get; set; }
    }
}
