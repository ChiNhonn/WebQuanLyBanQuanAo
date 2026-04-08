using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DoAnMonWeb.Models
{
    [Table("sanpham")]
    public class SanPham
    {
        [Key]
        [Column("MaSP")]
        public int MaSP { get; set; }

        [Column("TenSP")]
        [Required(ErrorMessage = "Tên sản phẩm không được để trống!")]
        public string TenSP { get; set; }

        [Column("Gia")]
        [Required(ErrorMessage = "Không được để trống!")]
        public decimal Gia { get; set; }

        [Column("MoTa")]
        public string MoTa { get; set; }

        [Column("HinhAnh")]
        [Required(ErrorMessage = "Hình không được để trống!")]
        public string HinhAnh { get; set; }

        [Column("MaLoai")]
        public int MaLoai { get; set; }
    }
}
