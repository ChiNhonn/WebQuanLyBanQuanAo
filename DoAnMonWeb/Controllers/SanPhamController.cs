using DoAnMonWeb.Models;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.Extensions.Logging.EventSource.LoggingEventSource;

namespace DoAnMonWeb.Controllers
{
    public class SanPhamController : Controller
    {
        public readonly ApplicationDbContext _context;
        public SanPhamController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var dsThamKhao = _context.SanPhams.ToList();
            return View(dsThamKhao);
        }
        public IActionResult Search(string search)
        {
            var allProducts = _context.SanPhams.ToList();
            if (!string.IsNullOrWhiteSpace(search))
            {
                var keywords = search.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                                     .Select(k => k.Trim().ToLower())
                                     .ToList();

                allProducts = allProducts.Where(p => keywords.Any(k =>
                                p.TenSP.ToLower().Contains(k))).ToList();
            }
            ViewBag.Keyword = search;
            return View("Search", allProducts);
        }

    }
}
