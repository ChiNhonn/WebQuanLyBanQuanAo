using DoAnMonWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebBanQuanAo.Controllers;

namespace DoAnMonWeb.Controllers
{
    public class TaiKhoanController : Controller
    {
        public readonly ApplicationDbContext _context;

        public TaiKhoanController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult DangKy()
        {
            return View();
        }
        [HttpPost]
        public IActionResult DangKy(TaiKhoan tk)
        {
            if (ModelState.IsValid)
            {
                tk.MatKhau = PassHash.hashPass(tk.MatKhau);
                tk.VaiTro = "User";
                _context.TaiKhoans.Add(tk);
                _context.SaveChanges();
                TempData["Success"] = "Đăng ký thành công!";
                return RedirectToAction("Index", "SanPham");
            }

            return View(tk);
        }
        public IActionResult DangNhap()
        {
            return View();
        }

        [HttpPost]
        public IActionResult DangNhap(TaiKhoan model)
        {
            string passHash = PassHash.hashPass(model.MatKhau);

            var tk = _context.TaiKhoans.FirstOrDefault(t => t.Ten == model.Ten && t.MatKhau == passHash);
            if (tk != null)
            {
                HttpContext.Session.SetString("Ten", tk.Ten);
                HttpContext.Session.SetInt32("MaTK", tk.MaTK);
                HttpContext.Session.SetString("FullName", tk.FullName);
                HttpContext.Session.SetString("Email", tk.Email);
                HttpContext.Session.SetString("Sdt", tk.Sdt);
                HttpContext.Session.SetString("GioiTinh", tk.GioiTinh);
                HttpContext.Session.SetString("VaiTro", tk.VaiTro);
                if (tk.VaiTro == "Admin")
                {
                    return RedirectToAction("Index", "QuanLySP");

                }
                else
                {
                    return RedirectToAction("DashboardLogin", "TaiKhoan");
                }
            }
            else
            {
                ViewBag.Error = "Sai tài khoản hoặc mật khẩu";
            }

            return View(model);
        }

        public IActionResult DashboardLogin()
            {
                var MaTK = HttpContext.Session.GetInt32("MaTK");
                var FullName = HttpContext.Session.GetString("FullName");

                if (MaTK == null || FullName == null)
                {
                    return RedirectToAction("Index", "SanPham");
                }
                var ListDonHang = _context.DonHangs
                    .Where(d => d.MaTK == MaTK)
                    .OrderByDescending(d => d.NgayDat)
                    .ToList();

                var ListYeuThich = _context.YeuThichs
                    .Include(y => y.SanPham) 
                    .Where(y => y.MaTK == MaTK)
                    .Select(y => new YeuThichItem
                    {
                        MaSP = y.SanPham.MaSP,
                        TenSP = y.SanPham.TenSP,
                        HinhAnh = y.SanPham.HinhAnh,
                        Gia = y.SanPham.Gia
                    })
                    .ToList();
                var ListDiaChi = _context.DiaChis
                    .Where(d => d.MaTK == MaTK)
                    .ToList();
           
            ViewBag.MaTK = MaTK;
                ViewBag.Ten = HttpContext.Session.GetString("Ten");
                ViewBag.FullName = FullName;
                ViewBag.Email = HttpContext.Session.GetString("Email");
                ViewBag.Sdt = HttpContext.Session.GetString("Sdt");
                ViewBag.GioiTinh = HttpContext.Session.GetString("GioiTinh");
                ViewBag.VaiTro = HttpContext.Session.GetString("VaiTro");

                ViewBag.DanhSachDonHang = ListDonHang;
                ViewBag.DanhSachYeuThich = ListYeuThich;
                ViewBag.DanhSachDiaChi = ListDiaChi;
                return View("Dashboard");
            }
    public IActionResult SuaTK(int id)
        {
            var tk = _context.TaiKhoans.Find(id);
            return View(tk);
        }
        [HttpPost]
        public IActionResult CapNhatTK(TaiKhoan tk)
        {
            var existingTk = _context.TaiKhoans.Find(tk.MaTK);
            if (existingTk != null)
            {
                existingTk.FullName = tk.FullName;
                existingTk.GioiTinh = tk.GioiTinh;
                existingTk.Email = tk.Email;
                existingTk.Sdt = tk.Sdt;

                _context.SaveChanges();

                HttpContext.Session.SetString("FullName", tk.FullName ?? "");
                HttpContext.Session.SetString("Email", tk.Email ?? "");
                HttpContext.Session.SetString("Sdt", tk.Sdt ?? "");
                HttpContext.Session.SetString("GioiTinh", tk.GioiTinh ?? "");

                TempData["Success"] = "Cập nhật thông tin thành công!";
            }
            else
            {
                TempData["Error"] = "Tài khoản không tồn tại!";
            }

            return RedirectToAction("DashboardLogin");
        }
        public IActionResult DangXuat()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "SanPham");
        }
    }
}
