namespace DoAnMonWeb.Models
{
    public class GioHangItem
    {
        public int MaSP { get; set; }
        public string TenSP { get; set; }
        public string HinhAnh { get; set; }
        public Decimal Gia { get; set; }
        public int SoLuong { get; set; }
        public string Size { get; set; }
        public Decimal ThanhTien => SoLuong * Gia;
    }
}
