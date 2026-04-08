using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DoAnMonWeb.Models
{
    [Table("chitietdonhang")]
    public class ChiTietDonHang
    {
        [Key]
        public int MaChiTietDonHang { get; set; }
        public int MaDonHang { get; set; }
        public int MaChiTiet { get; set; }
        public int SoLuong { get; set; }
        public decimal Gia { get; set; }
        [ForeignKey("MaChiTiet")]
        public virtual SanPham? SanPham { get; set; }
    }
}
