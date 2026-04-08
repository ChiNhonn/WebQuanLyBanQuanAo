using DoAnMonWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DoAnMonWeb.Controllers
{
    public class GioHangController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GioHangController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var giohang = Giohang();
            return View(giohang);
        }
        public List<GioHangItem> Giohang()
        {
            var cart = HttpContext.Session.GetString("GioHang");

            if (cart == null)
            {
                return new List<GioHangItem>();
            }

            return JsonConvert.DeserializeObject<List<GioHangItem>>(cart);
        }
        public IActionResult ThemGioHang(int id, string size)
        {
            var giohang = Giohang();

            var item = giohang.FirstOrDefault(x => x.MaSP == id && x.Size == size);

            if (item != null)
            {
                item.SoLuong++;
            }
            else
            {
                var sp = _context.SanPhams.FirstOrDefault(x => x.MaSP == id);

                if (sp != null)
                {
                    giohang.Add(new GioHangItem
                    {
                        MaSP = sp.MaSP,
                        TenSP = sp.TenSP,
                        HinhAnh = sp.HinhAnh,
                        Gia = sp.Gia,
                        SoLuong = 1,
                        Size = size
                    });
                }
            }

            HttpContext.Session.SetString("GioHang", JsonConvert.SerializeObject(giohang));
            TempData["Success"] = "Đã thêm sản phẩm vào giỏ hàng!";
            return RedirectToAction("Index", "SanPham");
        }
        public IActionResult XoaSanPham(int id, string size)
        {
            var giohang = Giohang();
            var item = giohang.FirstOrDefault(x => x.MaSP == id && x.Size == size);
            if(item != null)
            {
                giohang.Remove(item);
            }
            HttpContext.Session.SetString("GioHang", JsonConvert.SerializeObject(giohang));
            TempData["Success"] = " Đã xóa sản phẩm khỏi giỏ hàng.";
            return RedirectToAction("Index");

        }
        public IActionResult TangSoLuong(int id, string size)
        {
            var giohang = Giohang();
            var item = giohang.FirstOrDefault(x => x.MaSP == id && x.Size == size);

            if (item != null)
            {
                item.SoLuong++;
            }

            HttpContext.Session.SetString("GioHang", JsonConvert.SerializeObject(giohang));
            return RedirectToAction("Index");
        }

        public IActionResult GiamSoLuong(int id, string size)
        {
            var giohang = Giohang();
            var item = giohang.FirstOrDefault(x => x.MaSP == id && x.Size == size);

            if (item != null)
            {
                if (item.SoLuong > 1)
                {
                    item.SoLuong--;
                }
                else
                {
                    giohang.Remove(item); 
                }
            }
            HttpContext.Session.SetString("GioHang", JsonConvert.SerializeObject(giohang));
            return RedirectToAction("Index");
        }
    }
}