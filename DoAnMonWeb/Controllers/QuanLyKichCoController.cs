using Microsoft.AspNetCore.Mvc;
using DoAnMonWeb.Models;

namespace DoAnMonWeb.Controllers
{
    public class QuanLyKichCoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public QuanLyKichCoController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult ThemKC()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ThemKC(KichCo kc)
        {
            _context.KichCos.Add(kc);
            _context.SaveChanges();
            return RedirectToAction("Index", "QuanLySP", new { tab = "kichco" });
        }

        public IActionResult SuaKC(int id)
        {
            var kc = _context.KichCos.Find(id);
            if (kc == null) return NotFound();
            return View(kc);
        }

        [HttpPost]
        public IActionResult SuaKC(KichCo kc)
        {
            var kcSua = _context.KichCos.Find(kc.MaKichCo);
            if (kcSua == null) return NotFound();

            kcSua.TenKichCo = kc.TenKichCo;
            _context.SaveChanges();

            return RedirectToAction("Index", "QuanLySP", new { tab = "kichco" });
        }

        public IActionResult XoaKC(int id)
        {
            var kc = _context.KichCos.Find(id);
            if (kc != null)
            {
                _context.KichCos.Remove(kc);
                _context.SaveChanges();
            }

            return RedirectToAction("Index", "QuanLySP", new { tab = "kichco" });
        }
    }
}