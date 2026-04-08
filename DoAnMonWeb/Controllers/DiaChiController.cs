using Microsoft.AspNetCore.Mvc;
using DoAnMonWeb.Models;

namespace DoAnMonWeb.Controllers
{
    public class DiaChiController : Controller
    {
        private readonly ApplicationDbContext _context;
        public DiaChiController(ApplicationDbContext context) { _context = context; }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Them(DiaChi model, string Ho, string Ten)
        {
            var maTK = HttpContext.Session.GetInt32("MaTK");
            if (maTK == null) return RedirectToAction("DangNhap", "TaiKhoan");

            model.HoTen = (Ho + " " + Ten).Trim();
            model.MaTK = (int)maTK;

            var coDiaChiChua = _context.DiaChis.Any(x => x.MaTK == maTK);
            if (!coDiaChiChua) model.IsDefault = true;
            else if (model.IsDefault)
            {
                var dcs = _context.DiaChis.Where(x => x.MaTK == maTK).ToList();
                foreach (var item in dcs) item.IsDefault = false;
            }

            _context.DiaChis.Add(model);
            _context.SaveChanges();

            TempData["Success"] = "Thêm địa chỉ thành công!";
            return RedirectToAction("DashboardLogin", "TaiKhoan");
        }
        [HttpPost]
        public IActionResult CapNhap(DiaChi model)
        {
            var MaTK = HttpContext.Session.GetInt32("MaTK");
            if (MaTK == null) return RedirectToAction("DangNhap", "TaiKhoan");

            var dcGoc = _context.DiaChis.FirstOrDefault(x => x.MaDiaChi == model.MaDiaChi && x.MaTK == MaTK);
            if(dcGoc != null)
            {
                dcGoc.HoTen = model.HoTen;
                dcGoc.Sdt = model.Sdt;
                dcGoc.DiaChiChiTiet = model.DiaChiChiTiet;
                dcGoc.LoaiDiaChi = model.LoaiDiaChi;
                if(model.IsDefault)
                {
                    var danhsachkhac = _context.DiaChis.Where(x => x.MaTK == MaTK && x.MaDiaChi != model.MaDiaChi).ToList();
                    foreach(var dc in danhsachkhac)
                    {
                        dc.IsDefault = false;
                    }
                    dcGoc.IsDefault = true;
                }else
                {
                    dcGoc.IsDefault = model.IsDefault;
                }
                _context.SaveChanges();
                TempData["Success"] = "Cập nhật địa chỉ thành công!";
            }
            else
            {
                TempData["Error"] = "Không tìm thấy địa chỉ để cập nhật.";
            }
            return RedirectToAction("DashboardLogin", "TaiKhoan");
        }

        public IActionResult Xoa(int id)
        {
            var dc = _context.DiaChis.Find(id);
            if (dc != null)
            {
                _context.DiaChis.Remove(dc);
                _context.SaveChanges();
                TempData["Success"] = "Đã xóa địa chỉ.";
            }
            return RedirectToAction("DashboardLogin", "TaiKhoan");
        }
    }
}