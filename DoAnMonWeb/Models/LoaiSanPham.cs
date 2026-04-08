using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DoAnMonWeb.Models
{
    [Table("loaisanpham")]

    public class LoaiSanPham
    {        
        [Key]
        public int MaLoai { get; set; }
        [Required(ErrorMessage = "Tên không được để trống!")]
        public string TenLoai { get; set; }
    }
}
