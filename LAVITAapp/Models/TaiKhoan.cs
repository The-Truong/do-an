using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAVITAapp.Models
{
    public class TaiKhoan
    {
        [Key]
        [Display(Name = "Tên Đăng Nhập")]
        public string? TenDangNhap { get; set; }
        [Display(Name = "Mật Khẩu")]
        public string? MatKhau { get; set; }
        [Display(Name = "Quyền")]
        public string? Quyen { get; set; }
    }
}
