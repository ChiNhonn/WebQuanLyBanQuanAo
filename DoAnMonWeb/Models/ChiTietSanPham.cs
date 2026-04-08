using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DoAnMonWeb.Models
{
    [Table("chitietsanpham")]
    public class ChiTietSanPham
    {
        [Key]
        public int MaChiTiet { get; set; }
        public int MaSP { get; set; }
        public int MaKichCo { get; set; }
        public int MaMauSac { get; set; }
        public int SoLuong { get; set; }
    }
}
