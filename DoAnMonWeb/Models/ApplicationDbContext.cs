
using Microsoft.EntityFrameworkCore;

namespace DoAnMonWeb.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<LoaiSanPham> LoaiSanPhams { get; set; }
        public DbSet<SanPham> SanPhams { get; set; }
        public DbSet<ChiTietSanPham> ChiTietSanPhams { get; set; }

        public DbSet<TaiKhoan> TaiKhoans { get; set; }

        public DbSet<DonHang> DonHangs { get; set; }
        public DbSet<ChiTietDonHang> ChiTietDonHangs { get; set; }
        public DbSet<GioHang> GioHangs { get; set; }

        public DbSet<ChiTietGioHang> ChiTietGioHangs { get; set; }
        public DbSet<MauSac> MauSacs { get; set; }

        public DbSet<KichCo> KichCos { get; set; }
        public DbSet<YeuThich> YeuThichs { get; set; }
        public DbSet<DiaChi> DiaChis { get; set; }
    }
}
