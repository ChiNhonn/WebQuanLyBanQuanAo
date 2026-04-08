using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DoAnMonWeb.Models
{
    [Table("mausac")]

    public class MauSac
    {
        [Key]
        public int MaMauSac { get; set; }
        [Required(ErrorMessage = "Tên không được để trống!")]
        public string TenMauSac { get; set; }
    }
}
