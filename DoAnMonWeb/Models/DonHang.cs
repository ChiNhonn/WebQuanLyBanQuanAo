using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DoAnMonWeb.Models
{
    [Table("donhang")]
    public class DonHang
    {
        [Key]
        public int MaDonHang { get; set; }
        public int? MaTK { get; set; }
        public decimal TongTien { get; set; }
        public string TrangThai { get; set; }
        public string PhuongThucThanhToan { get; set; }
        public DateTime? NgayDat { get; set; }

        public string? DiaChiGiaoHang { get; set; }

        public string? SoDienThoai { get; set; }

        public string? GhiChu { get; set; }
        public bool DaThanhToan { get; set; } = false;
        public string? TenNguoiNhan { get; set; }
    }
}
