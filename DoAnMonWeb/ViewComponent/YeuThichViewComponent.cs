using DoAnMonWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;

namespace DoAnMonWeb.ViewComponent
{
    public class YeuThichViewComponent : Microsoft.AspNetCore.Mvc.ViewComponent
    {
        public readonly ApplicationDbContext _context;
        public YeuThichViewComponent(ApplicationDbContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke()
        {
            var maTK = HttpContext.Session.GetInt32("MaTK");
            int TongSoLuong = 0;
            if (maTK != null)
            {
                TongSoLuong = _context.YeuThichs.Count(x => x.MaTK == maTK);
            }
            else
            {
                var jsonYeuthich = HttpContext.Session.GetString("YeuThich");
                if (!string.IsNullOrEmpty(jsonYeuthich))
                {
                    var yeuthich = JsonConvert.DeserializeObject<List<YeuThichItem>>(jsonYeuthich);
                    TongSoLuong = yeuthich.Count;
                }
            }

            return View(TongSoLuong);
        }
    }
}
