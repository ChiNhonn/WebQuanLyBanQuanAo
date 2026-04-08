using Microsoft.AspNetCore.Mvc;
using DoAnMonWeb.Models;

namespace DoAnMonWeb.Controllers
{
    public class QuanLyTaiKhoanController : Controller
    {
        private readonly ApplicationDbContext _context;

        public QuanLyTaiKhoanController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var list = _context.TaiKhoans.ToList();
            return View(list);
        }
        public IActionResult XoaTK(int id)
        {
            var tk = _context.TaiKhoans.Find(id);
            if (tk != null)
            {
                _context.TaiKhoans.Remove(tk);
                _context.SaveChanges();
            }
            return RedirectToAction("Index", "QuanLySP");
        }

        [HttpPost]
        public IActionResult DoiVaiTro(int id, string vaiTro)
        {
            var tk = _context.TaiKhoans.Find(id);
            if (tk == null) return NotFound();

            tk.VaiTro = vaiTro;
            _context.SaveChanges();

            return RedirectToAction("Index", "QuanLySP");
        }
        public IActionResult ChiTietTK(int id)
        {
            var tk = _context.TaiKhoans.FirstOrDefault(x => x.MaTK == id);

            if (tk == null) return NotFound();

            return View(tk);
        }
    }
}