using Microsoft.AspNetCore.Mvc;
using DoAnMonWeb.Models;

namespace DoAnMonWeb.Controllers
{
    public class QuanLyMauSacController : Controller
    {
        private readonly ApplicationDbContext _context;

        public QuanLyMauSacController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult ThemMS()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ThemMS(MauSac mau)
        {
            _context.MauSacs.Add(mau);
            _context.SaveChanges();
            return RedirectToAction("Index", "QuanLySP");
        }
        public IActionResult SuaMS(int id)
        {
            var mau = _context.MauSacs.Find(id);
            return View(mau);
        }

        [HttpPost]
        public IActionResult SuaMS(MauSac mau)
        {
            var mauSua = _context.MauSacs.Find(mau.MaMauSac);
            if (mauSua == null) return NotFound();

            mauSua.TenMauSac = mau.TenMauSac;
            _context.SaveChanges();

            return RedirectToAction("Index", "QuanLySP");
        }
        public IActionResult XoaMS(int id)
        {
            var mau = _context.MauSacs.Find(id);
            if (mau != null)
            {
                _context.MauSacs.Remove(mau);
                _context.SaveChanges();
            }
            return RedirectToAction("Index", "QuanLySP");
        }
    }
}