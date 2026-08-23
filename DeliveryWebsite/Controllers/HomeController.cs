using Microsoft.AspNetCore.Mvc;
using DeliveryWebsite.Models;

namespace DeliveryWebsite.Controllers
{
    public class HomeController : Controller
    {
        // صفحة العرض (GET)
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        // استقبال الطلب وإرساله إلى الواتساب (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(OrderModel model)
        {
            if (string.IsNullOrWhiteSpace(model.CustomerName) ||
                string.IsNullOrWhiteSpace(model.PhoneNumber) ||
                string.IsNullOrWhiteSpace(model.Location) ||
                string.IsNullOrWhiteSpace(model.OrderDetails))
            {
                ViewBag.Error = "الرجاء تعبئة جميع الحقول المطلوبة!";
                return View(model);
            }

            // تجهيز نص رسالة الواتساب
            string message = $"طلب توصيل جديد عبر الموقع 🛵\n" +
                             $"--------------------\n" +
                             $"👤 الاسم: {model.CustomerName}\n" +
                             $"📞 الهاتف: {model.PhoneNumber}\n" +
                             $"📍 العنوان: {model.Location}\n";

            // إضافة رابط الملاحة المباشر الذي يرسم الطريق لمنزل الزبون عند النقر عليه
            if (!string.IsNullOrEmpty(model.Latitude) && !string.IsNullOrEmpty(model.Longitude))
            {
                string navigationLink = $"https://www.google.com/maps/dir/?api=1&destination={model.Latitude},{model.Longitude}";
                message += $"🗺️ اضغط هنا لرسم الطريق إلى بيت الزبون:\n{navigationLink}\n";
            }

            message += $"🛒 الطلب: {model.OrderDetails}";

            // رقم الهاتف الخاص بك لاستلام الطلبات (مع رمز الدولة)
            string myPhoneNumber = "96171708532";
            string encodedMessage = Uri.EscapeDataString(message);
            string whatsappUrl = `https://wa.me/{myPhoneNumber}?text={encodedMessage}`;

            return Redirect(whatsappUrl);
        }
    }
}