using Microsoft.AspNetCore.Mvc;
using DeliveryWebsite.Models;

namespace DeliveryWebsite.Controllers
{
    public class HomeController : Controller
    {
        // 1. صفحة العرض (GET)
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        // 2. دالة استقبال الطلب عبر الـ Form (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(OrderModel model)
        {
            if (string.IsNullOrWhiteSpace(model.CustomerName) ||
                string.IsNullOrWhiteSpace(model.PhoneNumber) ||
                string.IsNullOrWhiteSpace(model.Location) ||
                string.IsNullOrWhiteSpace(model.OrderDetails))
            {
                ViewBag.Error = "الرجاء تعبئة جميع الحقول!";
                return View(model);
            }

            // تجهيز رسالة الواتساب
            string message = $"طلب توصيل جديد عبر الموقع 🛵\n" +
                             $"--------------------\n" +
                             $"👤 الاسم: {model.CustomerName}\n" +
                             $"📞 الهاتف: {model.PhoneNumber}\n" +
                             $"📍 الموقع: {model.Location}\n" +
                             $"🛒 الطلب: {model.OrderDetails}";

            string myPhoneNumber = "96171708532";
            string encodedMessage = Uri.EscapeDataString(message);
            string whatsappUrl = $"https://wa.me/{myPhoneNumber}?text={encodedMessage}";

            return Redirect(whatsappUrl);
        }
    }
}