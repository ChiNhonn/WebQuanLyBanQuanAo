using DoAnMonWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace DoAnMonWeb.Controllers
{
    public class DonHangController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;
        public DonHangController(ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public IActionResult DatHang()
        {
            var MaTK = HttpContext.Session.GetInt32("MaTK");
            if (MaTK != null)
            {
                ViewBag.DanhSachDiaChi = _context.DiaChis.Where(d => d.MaTK == MaTK).ToList();
            }
            else
            {
                ViewBag.DanhSachDiaChi = new List<DiaChi>();
            }

            var JSongiohang = HttpContext.Session.GetString("GioHang");
            var giohang = new List<GioHangItem>();
            if (!string.IsNullOrEmpty(JSongiohang))
            {
                giohang = JsonConvert.DeserializeObject<List<GioHangItem>>(JSongiohang);
            }

            ViewBag.GioHang = giohang;
            ViewBag.TongTien = giohang.Sum(x => x.ThanhTien);
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> XacNhanDatHang(int? MaDiaChi, string PhuongThuc, string GhiChu, string HoTenKhach, string SdtKhach, string DiaChiKhach)
        {
            var MaTK = HttpContext.Session.GetInt32("MaTK");
            var jsonCart = HttpContext.Session.GetString("GioHang");
            if (string.IsNullOrEmpty(jsonCart)) return RedirectToAction("Index", "SanPham");

            var gioHang = JsonConvert.DeserializeObject<List<GioHangItem>>(jsonCart);

            var donHang = new DonHang
            {
                MaTK = MaTK,
                TongTien = gioHang.Sum(x => x.ThanhTien),
                PhuongThucThanhToan = PhuongThuc,
                GhiChu = GhiChu,
                TrangThai = "Mới",
                NgayDat = DateTime.Now,
                DaThanhToan = false
            };

            if (MaTK != null && MaDiaChi != null)
            {
                var dc = _context.DiaChis.FirstOrDefault(d => d.MaDiaChi == MaDiaChi);
                if (dc != null)
                {
                    donHang.TenNguoiNhan = dc.HoTen;
                    donHang.SoDienThoai = dc.Sdt;
                    donHang.DiaChiGiaoHang = dc.DiaChiChiTiet;
                }
            }
            else
            {
                donHang.TenNguoiNhan = HoTenKhach;
                donHang.SoDienThoai = SdtKhach;
                donHang.DiaChiGiaoHang = DiaChiKhach;
            }

            _context.DonHangs.Add(donHang);
            await _context.SaveChangesAsync();

            foreach (var item in gioHang)
            {
                _context.ChiTietDonHangs.Add(new ChiTietDonHang
                {
                    MaDonHang = donHang.MaDonHang,
                    MaChiTiet = item.MaSP,
                    SoLuong = item.SoLuong,
                    Gia = item.Gia
                });
            }
            await _context.SaveChangesAsync();

            HttpContext.Session.Remove("GioHang");

            if (PhuongThuc == "VNPAY")
            {
                string url = CreatePaymentUrl(donHang);
                return Redirect(url);
            }

            return RedirectToAction("DatHangThanhCong", new { id = donHang.MaDonHang });
        }

        public string CreatePaymentUrl(DonHang model)
        {
            var vnpay = new VnPayLibrary();
            var config = _configuration.GetSection("Vnpay");

            var ipAddress = HttpContext.Connection.RemoteIpAddress?.ToString();

            vnpay.AddRequestData("vnp_Version", config["Version"]);
            vnpay.AddRequestData("vnp_Command", config["Command"]);
            vnpay.AddRequestData("vnp_TmnCode", config["TmnCode"]);

            vnpay.AddRequestData("vnp_Amount", ((long)(model.TongTien * 100)).ToString());
            vnpay.AddRequestData("vnp_CreateDate", DateTime.Now.ToString("yyyyMMddHHmmss"));
            vnpay.AddRequestData("vnp_ExpireDate", DateTime.Now.AddMinutes(15).ToString("yyyyMMddHHmmss"));

            vnpay.AddRequestData("vnp_CurrCode", config["CurrCode"]);
            vnpay.AddRequestData("vnp_IpAddr", ipAddress);
            vnpay.AddRequestData("vnp_Locale", config["Locale"]);

            vnpay.AddRequestData("vnp_OrderInfo", $"Thanh toan don hang {model.MaDonHang}");
            vnpay.AddRequestData("vnp_OrderType", "other");
            vnpay.AddRequestData("vnp_ReturnUrl", config["ReturnUrl"]);
            vnpay.AddRequestData("vnp_TxnRef", model.MaDonHang.ToString());

            return vnpay.CreateRequestUrl(config["BaseUrl"], config["HashSecret"]);
        }
        public IActionResult PaymentCallback()
        {
            var vnpayData = Request.Query;
            var vnpay = new VnPayLibrary();
            var hashSecret = _configuration["Vnpay:HashSecret"];

            foreach (var (key, value) in vnpayData)
            {
                if (!string.IsNullOrEmpty(key) && key.StartsWith("vnp_"))
                {
                    vnpay.AddResponseData(key, value);
                }
            }

            var secureHash = vnpayData["vnp_SecureHash"].ToString();
            if (string.IsNullOrEmpty(secureHash))
                return View("LoiThanhToan");

            int.TryParse(vnpay.GetResponseData("vnp_TxnRef"), out int orderId);
            string responseCode = vnpay.GetResponseData("vnp_ResponseCode");

            bool checkSignature = vnpay.ValidateSignature(secureHash, hashSecret);

            if (checkSignature && responseCode == "00")
            {
                var donHang = _context.DonHangs.Find(orderId);
                if (donHang != null)
                {
                    donHang.DaThanhToan = true;
                    donHang.TrangThai = "Đã thanh toán";
                    _context.SaveChanges();
                }
                return RedirectToAction("DatHangThanhCong", new { id = orderId });
            }

            return View("LoiThanhToan");
        }
        public IActionResult DatHangThanhCong(int id)
        {
            ViewBag.MaDonHang = id;
            return View();
        }
    }
}