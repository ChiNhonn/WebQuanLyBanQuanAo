using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DoAnMonWeb.Models
{
    [Table("kichco")]
    public class KichCo
    {
        [Key]
        public int MaKichCo { get; set; }
        [Required(ErrorMessage = "Tên không được để trống!")]
        public string TenKichCo { get; set; }
    }
}
