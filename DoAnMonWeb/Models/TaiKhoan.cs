using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DoAnMonWeb.Models
{
    [Table("taikhoan")]
    public class TaiKhoan
    {
        [Key]
        public int MaTK { get; set; }
        public string Ten { get; set; }
        public string Email { get; set; }
        public string MatKhau { get; set; }
        public string FullName { get; set; }
        public string Sdt { get; set; }
        public string DiaChi { get; set; }
        public string GioiTinh { get; set; }
        public string? VaiTro { get; set; }
        public DateTime? ThoiGianTao { get; set; } = DateTime.Now;
        public string? Otp { get; set; }
    }

}
