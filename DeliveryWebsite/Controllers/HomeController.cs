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
public IActionResult Index(OrderModel model)
{
    if (string.IsNullOrWhiteSpace(model.CustomerName) || 
        string.IsNullOrWhiteSpace(model.PhoneNumber) || 
        string.IsNullOrWhiteSpace(model.Location) || 
        string.IsNullOrWhiteSpace(model.OrderDetails))
    {
        ViewBag.Error = "الرجاء تعبئة جميع الحقول!";
        return View(model);
    }

    // تجهيز نص الرسالة بشكل طبيعي تماماً بدون %0A
    string message = $"طلب توصيل جديد عبر الموقع! 🚀\n" +
                     $"------------------\n" +
                     $"👤 الاسم: {model.CustomerName}\n" +
                     $"📞 الهاتف: {model.PhoneNumber}\n" +
                     $"📍 الموقع: {model.Location}\n" +
                     $"🛒 الطلب: {model.OrderDetails}";

    // رقم هاتفك
    string myPhoneNumber = "96171708532"; 

    // تحويل النص العربي والرموز تلقائياً إلى صيغة آمنة للرابط
    string encodedMessage = Uri.EscapeDataString(message);

    string whatsappUrl = $"https://wa.me/{myPhoneNumber}?text={encodedMessage}";

    return Redirect(whatsappUrl);
}
    }
}