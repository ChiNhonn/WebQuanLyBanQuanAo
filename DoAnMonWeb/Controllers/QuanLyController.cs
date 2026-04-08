using DoAnMonWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DoAnMonWeb.Controllers
{
    public class QuanLyController : Controller
    {
        private readonly ApplicationDbContext _context;

        public QuanLyController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("VaiTro") != "Admin")
            {
                return View("Dashboard");
            }
            var list = _context.SanPhams.ToList();
            ViewBag.Count = list.Count;

            return View(list);

        }
        public IActionResult DangXuat()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("DashboardLogin", "TaiKhoan");
        }
    }
}
