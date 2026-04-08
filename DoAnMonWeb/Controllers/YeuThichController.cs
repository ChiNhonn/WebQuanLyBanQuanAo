using Microsoft.AspNetCore.Mvc;
using DoAnMonWeb.Models;
using Newtonsoft.Json;

namespace DoAnMonWeb.Controllers
{
    public class YeuThichController : Controller
    {
        public readonly ApplicationDbContext _context;
        public YeuThichController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var yeuthich = YeuThich();
            return View(yeuthich);
        }
        public List<YeuThichItem> YeuThich()
        {
            var yeuthich = HttpContext.Session.GetString("YeuThich");
            if (yeuthich == null)
            {
                return new List<YeuThichItem>();
            }
            return JsonConvert.DeserializeObject<List<YeuThichItem>>(yeuthich);
        }
        public IActionResult ThemYeuThich(int id, string size)
        {
            var maTK = HttpContext.Session.GetInt32("MaTK");

            if (maTK != null)
            {
                var daTonTai = _context.YeuThichs.Any(x => x.MaTK == maTK && x.MaSP == id);
                if (!daTonTai)
                {
                    var newItem = new YeuThich
                    {
                        MaTK = (int)maTK,
                        MaSP = id,
                        NgayThem = DateTime.Now
                    };
                    _context.YeuThichs.Add(newItem);
                    _context.SaveChanges();
                    TempData["Success"] = "Đã lưu vào danh sách yêu thích của bạn!";
                }
                else
                {
                    TempData["Success"] = "Sản phẩm này đã có trong danh sách yêu thích.";
                }
            }
            else
            {
                var yeuthich = YeuThich();
                var item = yeuthich.FirstOrDefault(x => x.MaSP == id);

                if (item != null)
                {
                    item.SoLuong++;
                }
                else
                {
                    var sp = _context.SanPhams.FirstOrDefault(x => x.MaSP == id);
                    if (sp != null)
                    {
                        yeuthich.Add(new YeuThichItem
                        {
                            MaSP = sp.MaSP,
                            TenSP = sp.TenSP,
                            HinhAnh = sp.HinhAnh,
                            Gia = sp.Gia,
                            SoLuong = 1,
                            size = size
                        });
                    }
                }
                HttpContext.Session.SetString("YeuThich", JsonConvert.SerializeObject(yeuthich));
                TempData["Success"] = "Đã thêm yêu thích tạm thời!";
            }
            return RedirectToAction("Index", "SanPham");
        }
        public IActionResult XoaYeuThich(int id)
        {
            var maTK = HttpContext.Session.GetInt32("MaTK");

            if (maTK != null)
            {
                var itemDb = _context.YeuThichs.FirstOrDefault(x => x.MaTK == maTK && x.MaSP == id);
                if (itemDb != null)
                {
                    _context.YeuThichs.Remove(itemDb);
                    _context.SaveChanges();
                    TempData["Success"] = "Đã xóa khỏi danh sách yêu thích.";
                }
            }
            else
            {
                var yeuthich = YeuThich();
                var itemSession = yeuthich.FirstOrDefault(x => x.MaSP == id);
                if (itemSession != null)
                {
                    yeuthich.Remove(itemSession);
                    HttpContext.Session.SetString("YeuThich", JsonConvert.SerializeObject(yeuthich));
                    TempData["Success"] = "Đã xóa khỏi danh sách tạm thời.";
                }
            }
            return RedirectToAction("DashboardLogin", "TaiKhoan");
        }
    }
}
