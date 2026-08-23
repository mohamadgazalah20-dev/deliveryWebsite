using Microsoft.AspNetCore.Mvc;
using DeliveryWebsite.Models;

namespace DeliveryWebsite.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

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

            string message = $"طلب توصيل جديد عبر الموقع 🛵\n" +
                             $"--------------------\n" +
                             $"👤 الاسم: {model.CustomerName}\n" +
                             $"📞 الهاتف: {model.PhoneNumber}\n" +
                             $"📍 العنوان: {model.Location}\n";

            if (!string.IsNullOrEmpty(model.Latitude) && !string.IsNullOrEmpty(model.Longitude))
            {
                string navigationLink = $"https://www.google.com/maps/dir/?api=1&destination={model.Latitude},{model.Longitude}";
                message += $"🗺️ اضغط هنا لرسم الطريق إلى بيت الزبون:\n{navigationLink}\n";
            }

            message += $"🛒 الطلب: {model.OrderDetails}";

            string myPhoneNumber = "96171708532";
            string encodedMessage = Uri.EscapeDataString(message);
            string whatsappUrl = $"https://wa.me/{myPhoneNumber}?text={encodedMessage}";

            return Redirect(whatsappUrl);
        }
    }
}