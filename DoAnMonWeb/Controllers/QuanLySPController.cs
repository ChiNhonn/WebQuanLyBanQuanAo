using Microsoft.AspNetCore.Mvc;
using DoAnMonWeb.Models;
using Microsoft.AspNetCore.Http.Metadata;

namespace DoAnMonWeb.Controllers
{
    public class QuanLySPController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _environment;
        public QuanLySPController(ApplicationDbContext context, IWebHostEnvironment _envi)
        {
            _context = context;
            _environment = _envi;
        }
        public IActionResult Index()
        {
            ViewBag.TongDoanhThu = _context.DonHangs.Where(d => d.DaThanhToan == true).Sum(d => d.TongTien);
            ViewBag.DonHangMoiCount = _context.DonHangs.Count(d => d.TrangThai == "Mới");
            ViewBag.UserCount = _context.TaiKhoans.Count(t => t.VaiTro == "User");
            ViewBag.ProductCount = _context.SanPhams.Count();
            ViewBag.RecentOrders = _context.DonHangs
                                        .OrderByDescending(d => d.NgayDat)
                                        .Take(5)
                                        .ToList();

            var list = _context.SanPhams.ToList();
            var loaiList = _context.LoaiSanPhams.ToList();
            var kichCoList = _context.KichCos.ToList();
            var mauSacList = _context.MauSacs.ToList();
            var donhangList = _context.DonHangs.ToList();
            var taikhoan = _context.TaiKhoans.ToList();
            ViewBag.LoaiList = loaiList;
            ViewBag.KichCoList = kichCoList;
            ViewBag.MauSacList = mauSacList;
            ViewBag.DonHangList = donhangList;
            ViewBag.TaiKhoanList = taikhoan;
            return View(list);
        }
        public IActionResult ThemSP()
        {
            ViewBag.LoaiList = _context.LoaiSanPhams.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult ThemSP(SanPham sp, IFormFile file)
        {
            if (file != null)
            {
                string fileName = Path.GetFileName(file.FileName);
                string path = Path.Combine(_environment.WebRootPath, "images/QuanAo", fileName);
                if (System.IO.File.Exists(path))
                {
                    ModelState.AddModelError("HinhAnh", "File đã tồn tại, vui lòng đổi tên khác!");
                    return View(sp);
                }
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
                sp.HinhAnh = fileName;
            }
            _context.SanPhams.Add(sp);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult SuaSP(int id)
        {
            ViewBag.LoaiList = _context.LoaiSanPhams.ToList();
            var sp = _context.SanPhams.Find(id);
            return View(sp);
        }

        [HttpPost]
        public IActionResult SuaSP(SanPham sp, IFormFile file)
        {
            var spSua = _context.SanPhams.Find(sp.MaSP);
            if (spSua == null) return NotFound();

            spSua.TenSP = sp.TenSP;
            spSua.Gia = sp.Gia;
            spSua.MoTa = sp.MoTa;
            spSua.MaLoai = sp.MaLoai;

            if (file != null)
            {
                string fileName = Path.GetFileName(file.FileName);
                string path = Path.Combine(_environment.WebRootPath, "images/QuanAo", fileName);
                if (!System.IO.File.Exists(path))
                {
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                    spSua.HinhAnh = fileName;
                }
                else
                {
                    spSua.HinhAnh = fileName;
                }
            }

            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult XoaSP(int id)
        {
            var sp = _context.SanPhams.Find(id);
            if (sp != null)
            {
                _context.SanPhams.Remove(sp);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

    }
}
