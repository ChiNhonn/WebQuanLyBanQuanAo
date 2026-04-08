using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using DoAnMonWeb.Models;
namespace DoAnMonWeb.ViewComponent
{
    public class GioHangViewComponent : Microsoft.AspNetCore.Mvc.ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var JSongiohang = HttpContext.Session.GetString("GioHang");
            int TongSoLuong = 0;
            if (!string.IsNullOrEmpty(JSongiohang))
            {
                var giohang = JsonConvert.DeserializeObject<List<GioHangItem>>(JSongiohang);
                TongSoLuong = giohang.Sum(x => x.SoLuong);
            }
            return View(TongSoLuong);
        }
    }
}
