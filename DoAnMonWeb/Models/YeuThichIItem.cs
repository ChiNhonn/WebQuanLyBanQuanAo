using Microsoft.AspNetCore.Mvc;

namespace DoAnMonWeb.Models
{
    public class YeuThichItem
    {
        public int MaSP { get; set; }
        public string TenSP { get; set; }
        public string HinhAnh { get; set; }
        public decimal Gia { get; set; }
        public int SoLuong { get; set; }

        public string size { get; set; }
    }
}
