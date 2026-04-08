using System.ComponentModel.DataAnnotations;

namespace DoAnMonWeb.Models
{
    public class GioHang
    {
        [Key]
        public int MaGioHang { get; set; }
        public int MaKhachHang { get; set; }
        public DateTime? NgayTao { get; set; }

    }
}
