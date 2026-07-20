using LAVITAapp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAVITAapp.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<DonHang> DonHangs { get; set; }
        public DbSet<DuLieuDatHang> DuLieuDatHangs { get; set; }
        public DbSet<Hang> Hangs { get; set; }
        public DbSet<HoaDon> HoaDons { get; set; }
        public DbSet<KhachHang> KhachHangs { get; set; }
        public DbSet<NhanVien> NhanViens { get; set; }
        public DbSet<TaiKhoan> TaiKhoans { get; set; }
        public DbSet<ToKhaiKienHang> ToKhaiKienHangs { get; set; }
        public DbSet<YeuCauXuatKho> YeuCauXuatKhos { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb;Initial Catalog=lavitaa;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<NhanVien>().HasData(
                new NhanVien { Ma = 1, HoTen = "Nguyen Van Binh", Luong = 15000000, MaPhong = "PKD", TenPhong = "Phong Kinh Doanh", ChucVu = "GiaoDichVien" },
                new NhanVien { Ma = 2, HoTen = "Tran Thi Huong", Luong = 16000000, MaPhong = "PKS", TenPhong = "Phong Kiem Soat", ChucVu = "KiemSoatVien" },
                new NhanVien { Ma = 3, HoTen = "Le Van Minh", Luong = 15500000, MaPhong = "PKS", TenPhong = "Phong Kiem Soat", ChucVu = "KiemSoatVien" },
                new NhanVien { Ma = 4, HoTen = "Pham Quoc Tuan", Luong = 14500000, MaPhong = "PKT", TenPhong = "Phong Ke Toan", ChucVu = "KeToanVien" },
                new NhanVien { Ma = 5, HoTen = "Vo Thi Mai", Luong = 13000000, MaPhong = "PGH", TenPhong = "Phong Giao Hang", ChucVu = "NhanVienGiaoHang" }
                );
            modelBuilder.Entity<Hang>().HasData(
                new Hang { Ma = "H001", TenHang = "Laptop Dell Inspiron", MoTa = "Core i5 RAM 16GB", LoaiHang = "Laptop", SoLuongTon = 40, DonGia = 18500000 },
                new Hang { Ma = "H002", TenHang = "Chuot Logitech M331", MoTa = "Khong day", LoaiHang = "Phu Kien", SoLuongTon = 120, DonGia = 350000 },
                new Hang { Ma = "H003", TenHang = "Ban Phim Logitech K120", MoTa = "USB", LoaiHang = "Phu Kien", SoLuongTon = 90, DonGia = 250000 },
                new Hang { Ma = "H004", TenHang = "Man Hinh LG 24 inch", MoTa = "Full HD IPS", LoaiHang = "Man Hinh", SoLuongTon = 35, DonGia = 3200000 },
                new Hang { Ma = "H005", TenHang = "SSD Samsung 1TB", MoTa = "NVMe Gen4", LoaiHang = "Luu Tru", SoLuongTon = 55, DonGia = 2100000 }
                );
            modelBuilder.Entity<KhachHang>().HasData(
                new KhachHang
                {
                    Ma = 1,
                    HoTen = "Nguyen Van An",
                    CMND = "079123456789",
                    DiaChi = "12 Le Loi",
                    MaBuuChinh = "700000",
                    ThanhPho = "TP.HCM",
                    SoDienThoai = "0901234567",
                    MaThue = "0311111111",
                    TinDung = 150000000,
                    MaKSV = 2
                },
                new KhachHang
                {
                    Ma = 2,
                    HoTen = "Tran Thi Hoa",
                    CMND = "079987654321",
                    DiaChi = "25 Nguyen Hue",
                    MaBuuChinh = "700000",
                    ThanhPho = "TP.HCM",
                    SoDienThoai = "0912345678",
                    MaThue = "0312222222",
                    TinDung = 90000000,
                    MaKSV = 2
                },

                new KhachHang
                {
                    Ma = 3,
                    HoTen = "Pham Minh Duc",
                    CMND = "079112233445",
                    DiaChi = "88 Cach Mang Thang Tam",
                    MaBuuChinh = "700000",
                    ThanhPho = "TP.HCM",
                    SoDienThoai = "0933456789",
                    MaThue = "0313333333",
                    TinDung = 250000000,
                    MaKSV = 3
                }
                );

            modelBuilder.Entity<DonHang>().HasData(
                new DonHang
                {
                    Ma = "DH001",
                    NgayDat = new DateTime(2026, 7, 10),
                    NgayGiao = new DateTime(2026, 7, 15),
                    MaKhach = "KH001"
                },
                new DonHang
                {
                    Ma = "DH002",
                    NgayDat = new DateTime(2026, 7, 11),
                    NgayGiao = new DateTime(2026, 7, 16),
                    MaKhach = "KH002"
                },

                new DonHang
                {
                    Ma = "DH003",
                    NgayDat = new DateTime(2026, 7, 12),
                    NgayGiao = new DateTime(2026, 7, 17),
                    MaKhach = "KH003"
                }
                );
            modelBuilder.Entity<DuLieuDatHang>().HasData(
                new DuLieuDatHang
                {
                    Ma = "CT001",
                    MaDonHang = "DH001",
                    MaHang = "H001",
                    SoLuong = 2,
                    DonGia = 18500000,
                    TrangThai = true,
                    MoTa = "Don hop le"
                },
                new DuLieuDatHang
                {
                    Ma = "CT002",
                    MaDonHang = "DH001",
                    MaHang = "H002",
                    SoLuong = 2,
                    DonGia = 350000,
                    TrangThai = true,
                    MoTa = "Don hop le"
                },
                new DuLieuDatHang
                {
                    Ma = "CT003",
                    MaDonHang = "DH002",
                    MaHang = "H004",
                    SoLuong = 1,
                    DonGia = 3200000,
                    TrangThai = true,
                    MoTa = "Don hop le"
                },
                new DuLieuDatHang
                {
                    Ma = "CT004",
                    MaDonHang = "DH002",
                    MaHang = "H005",
                    SoLuong = 2,
                    DonGia = 2100000,
                    TrangThai = true,
                    MoTa = "Don hop le"
                },
                new DuLieuDatHang
                {
                    Ma = "CT005",
                    MaDonHang = "DH003",
                    MaHang = "H003",
                    SoLuong = 5,
                    DonGia = 250000,
                    TrangThai = false,
                    MoTa = "Vuot muc ton kho"
                }
                );
            modelBuilder.Entity<TaiKhoan>().HasData(
                new TaiKhoan
                {
                    TenDangNhap = "admin01",
                    MatKhau = "123456",
                    Quyen = "admin"
                },
                new TaiKhoan
                {
                    TenDangNhap = "giaodich01",
                    MatKhau = "123456",
                    Quyen = "nhanvien"
                },
                new TaiKhoan
                {
                    TenDangNhap = "ksv01",
                    MatKhau = "123456",
                    Quyen = "nhanvien"
                },
                new TaiKhoan
                {
                    TenDangNhap = "ksv02",
                    MatKhau = "123456",
                    Quyen = "nhanvien"
                },
                new TaiKhoan
                {
                    TenDangNhap = "ketoan01",
                    MatKhau = "123456",
                    Quyen = "nhanvien"
                },
                new TaiKhoan
                {
                    TenDangNhap = "giaohang01",
                    MatKhau = "123456",
                    Quyen = "nhanvien"
                }
            );
            modelBuilder.Entity<HoaDon>().HasData(
                new HoaDon
                {
                    Ma = "HD001",
                    NgayLap = new DateTime(2026, 7, 10),
                    TongTien = 37700000,
                    DaThanhToan = true,
                    MaDonHang = "DH001",
                    MaKeToan = "NV004"
                },
                new HoaDon
                {
                    Ma = "HD002",
                    NgayLap = new DateTime(2026, 7, 11),
                    TongTien = 7400000,
                    DaThanhToan = false,
                    MaDonHang = "DH002",
                    MaKeToan = "NV004"
                }
            );
            modelBuilder.Entity<ToKhaiKienHang>().HasData(
                new ToKhaiKienHang
                {
                    Ma = "TK001",
                    NgayLap = new DateTime(2026, 7, 10),
                    GhiChu = "Dong goi theo don DH001",
                    MaDonHang = "DH001"
                },
                new ToKhaiKienHang
                {
                    Ma = "TK002",
                    NgayLap = new DateTime(2026, 7, 11),
                    GhiChu = "Dong goi theo don DH002",
                    MaDonHang = "DH002"
                }
            );

            modelBuilder.Entity<YeuCauXuatKho>().HasData(
                new YeuCauXuatKho
                {
                    Ma = "YC001",
                    NgayYeuCau = new DateTime(2026, 7, 10),
                    DaXuatKho = true,
                    MaDonHang = "DH001",
                    MaNhanVien = "NV005"
                },
                new YeuCauXuatKho
                {
                    Ma = "YC002",
                    NgayYeuCau = new DateTime(2026, 7, 11),
                    DaXuatKho = false,
                    MaDonHang = "DH002",
                    MaNhanVien = "NV005"
                }
            );
        }
    }
}
