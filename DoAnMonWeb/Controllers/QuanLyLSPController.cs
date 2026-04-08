using Microsoft.AspNetCore.Mvc;
using DoAnMonWeb.Models;
namespace DoAnMonWeb.Controllers
{
    public class QuanLyLSPController : Controller
    {
        public readonly ApplicationDbContext _context;
        public QuanLyLSPController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var list = _context.LoaiSanPhams.ToList();
            return View(list);
        }
        public IActionResult ThemLSP()
        {
            ViewBag.LoaiList = _context.LoaiSanPhams.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult ThemLSP(LoaiSanPham lsp, IFormFile file)
        {
            _context.LoaiSanPhams.Add(lsp);
            _context.SaveChanges();
            return RedirectToAction("Index", "QuanLySP");
        }
        public IActionResult SuaLSP(int id)
        {
            ViewBag.LoaiList = _context.LoaiSanPhams.ToList();
            var lsp = _context.LoaiSanPhams.Find(id);
            return View(lsp);
        }
        [HttpPost]
        public IActionResult SuaLSP(LoaiSanPham lsp)
        {
            var lspSua = _context.LoaiSanPhams.Find(lsp.MaLoai);
            if (lspSua == null) return NotFound();
            lspSua.TenLoai = lsp.TenLoai;
            _context.SaveChanges();
            return RedirectToAction("Index", "QuanLySP");
        }
        public IActionResult XoaLSP(int id)
        {
            var lsp = _context.LoaiSanPhams.Find(id);
            if (lsp == null) return NotFound();
            _context.LoaiSanPhams.Remove(lsp);
            _context.SaveChanges();
            return RedirectToAction("Index", "QuanLySP");
        }
    }
}
