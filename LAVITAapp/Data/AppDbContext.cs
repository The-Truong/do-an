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
                new Hang { Ma = 1, TenHang = "Laptop Dell Inspiron", LoaiHang = "Laptop", SoLuongTon = 40, DonGia = 18500000 },
                new Hang { Ma = 2, TenHang = "Chuot Logitech M331", LoaiHang = "Phu Kien", SoLuongTon = 120, DonGia = 350000 },
                new Hang { Ma = 3, TenHang = "Ban Phim Logitech K120", LoaiHang = "Phu Kien", SoLuongTon = 90, DonGia = 250000 },
                new Hang { Ma = 4, TenHang = "Man Hinh LG 24 inch", LoaiHang = "Man Hinh", SoLuongTon = 35, DonGia = 3200000 },
                new Hang { Ma = 5, TenHang = "SSD Samsung 1TB", LoaiHang = "Luu Tru", SoLuongTon = 55, DonGia = 2100000 }
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
                    Ma = 1,
                    NgayDat = new DateTime(2026, 7, 15),
                    NgayGiao = new DateTime(2026, 7, 18),
                    MaKhach = 1,
                    TrangThai = "Đã duyệt",
                    MoTa = "Đơn hàng thiết bị văn phòng"
                },
                new DonHang
                {
                    Ma = 2,
                    NgayDat = new DateTime(2026, 7, 17),
                    NgayGiao = new DateTime(2026, 7, 21),
                    MaKhach = 1,
                    TrangThai = "Chờ duyệt",
                    MoTa = "Đang kiểm tra tồn kho"
                },
                new DonHang
                {
                    Ma = 3,
                    NgayDat = new DateTime(2026, 7, 18),
                    NgayGiao = new DateTime(2026, 7, 22),
                    MaKhach = 2,
                    TrangThai = "Đã giao",
                    MoTa = "Đã giao đầy đủ"
                },
                new DonHang
                {
                    Ma = 4,
                    NgayDat = new DateTime(2026, 7, 19),
                    NgayGiao = new DateTime(2026, 7, 23),
                    MaKhach = 2,
                    TrangThai = "Hủy",
                    MoTa = "Khách hủy đơn hàng"
                },
                new DonHang
                {
                    Ma = 5,
                    NgayDat = new DateTime(2026, 7, 20),
                    NgayGiao = new DateTime(2026, 7, 24),
                    MaKhach = 3,
                    TrangThai = "Đã duyệt",
                    MoTa = "Khách hàng VIP"
                },
                new DonHang
                {
                    Ma = 6,
                    NgayDat = new DateTime(2026, 7, 21),
                    NgayGiao = new DateTime(2026, 7, 25),
                    MaKhach = 3,
                    TrangThai = "Đã giao",
                    MoTa = "Đã xuất kho và giao thành công"
                }
            );
            modelBuilder.Entity<DuLieuDatHang>().HasData(
                new DuLieuDatHang
                {
                    Ma = 1,
                    MaDonHang = 1,
                    MaHang = 1,
                    SoLuong = 2,
                    DonGia = 18500000
                },
                new DuLieuDatHang
                {
                    Ma = 2,
                    MaDonHang = 1,
                    MaHang = 2,
                    SoLuong = 1,
                    DonGia = 350000
                },
                new DuLieuDatHang
                {
                    Ma = 3,
                    MaDonHang = 2,
                    MaHang = 4,
                    SoLuong = 1,
                    DonGia = 3200000
                },
                new DuLieuDatHang
                {
                    Ma = 4,
                    MaDonHang = 2,
                    MaHang = 5,
                    SoLuong = 2,
                    DonGia = 2100000
                },
                new DuLieuDatHang
                {
                    Ma = 5,
                    MaDonHang = 3,
                    MaHang = 3,
                    SoLuong = 5,
                    DonGia = 250000
                },
                new DuLieuDatHang
                {
                    Ma = 6,
                    MaDonHang = 4,
                    MaHang = 2,
                    SoLuong = 3,
                    DonGia = 350000
                },
                new DuLieuDatHang
                {
                    Ma = 7,
                    MaDonHang = 5,
                    MaHang = 1,
                    SoLuong = 1,
                    DonGia = 18500000
                },
                new DuLieuDatHang
                {
                    Ma = 8,
                    MaDonHang = 5,
                    MaHang = 5,
                    SoLuong = 4,
                    DonGia = 2100000
                },
                new DuLieuDatHang
                {
                    Ma = 9,
                    MaDonHang = 6,
                    MaHang = 3,
                    SoLuong = 10,
                    DonGia = 250000
                },
                new DuLieuDatHang
                {
                    Ma = 10,
                    MaDonHang = 6,
                    MaHang = 4,
                    SoLuong = 2,
                    DonGia = 3200000
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
                    MaHoaDon = 1,
                    MaDonHang = 4,
                    NgayLap = new DateTime(2026, 7, 20),
                    DaThuTien = true
                },
                new HoaDon
                {
                    MaHoaDon = 2,
                    MaDonHang = 3,
                    NgayLap = new DateTime(2026, 7, 21),
                    DaThuTien = false
                },
                new HoaDon
                {
                    MaHoaDon = 3,
                    MaDonHang = 5,
                    NgayLap = new DateTime(2026, 7, 22),
                    DaThuTien = true
                },
                new HoaDon
                {
                    MaHoaDon = 4,
                    MaDonHang = 1,
                    NgayLap = new DateTime(2026, 7, 22),
                    DaThuTien = false
                },
                new HoaDon
                {
                    MaHoaDon = 5,
                    MaDonHang = 2,
                    NgayLap = new DateTime(2026, 7, 23),
                    DaThuTien = true
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
