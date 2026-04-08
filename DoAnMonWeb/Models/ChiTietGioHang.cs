using System.ComponentModel.DataAnnotations;

namespace DoAnMonWeb.Models
{
    public class ChiTietGioHang
    {
        [Key]
        public int MaChiTietGioHang { get; set; }
        public int MaGioHang { get; set; }
        public int MaChiTiet { get; set; }
        public int SoLuong { get; set; }
    }
}
