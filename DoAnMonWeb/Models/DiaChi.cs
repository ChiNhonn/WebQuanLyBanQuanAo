using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DoAnMonWeb.Models
{
    [Table("diachi")]
    public class DiaChi
    {
        [Key]
        public int MaDiaChi { get; set; }
        public int MaTK { get; set; }
        public string HoTen { get; set; }
        public string Sdt { get; set; }
        public string DiaChiChiTiet { get; set; }
        public string LoaiDiaChi { get; set; }
        public bool IsDefault { get; set; }
    }
}