using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DoAnMonWeb.Models
{
    [Table("yeuthich")]
    public class YeuThich
    {
        [Key]
        public int MaYeuThich { get; set; }
        public int MaTK { get; set; }
        public int MaSP { get; set; }
        public DateTime? NgayThem { get; set; }
        [ForeignKey("MaSP")]
        public virtual SanPham? SanPham { get; set; }
        [ForeignKey("MaTK")]
        public virtual TaiKhoan? TaiKhoan { get; set; }
    }
}