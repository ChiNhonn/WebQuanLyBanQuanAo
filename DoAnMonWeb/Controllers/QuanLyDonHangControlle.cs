using Microsoft.AspNetCore.Mvc;
using DoAnMonWeb.Models;

namespace DoAnMonWeb.Controllers
{
    public class QuanLyDonHangController : Controller
    {
        private readonly ApplicationDbContext _context;

        public QuanLyDonHangController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var list = _context.DonHangs.ToList();
            return View(list);
        }
        [HttpPost]
        public IActionResult CapNhatTrangThai(int id, string trangThai)
        {
            var dh = _context.DonHangs.Find(id);
            if (dh == null) return NotFound();

            dh.TrangThai = trangThai;
            _context.SaveChanges();

            return RedirectToAction("Index", "QuanLySP");
        }
        public IActionResult ChiTiet(int id)
        {
            var list = (from ct in _context.ChiTietDonHangs
                        join spct in _context.ChiTietSanPhams on ct.MaChiTiet equals spct.MaChiTiet
                        join sp in _context.SanPhams on spct.MaSP equals sp.MaSP
                        where ct.MaDonHang == id
                        select new
                        {
                            TenSP = sp.TenSP,
                            SoLuong = ct.SoLuong,
                            Gia = ct.Gia,
                            Mau = spct.MaMauSac,
                            Size = spct.MaKichCo
                        }).ToList();

            ViewBag.ChiTietList = list;
            ViewBag.MaDonHang = id;

            return View();
        }
    }
}